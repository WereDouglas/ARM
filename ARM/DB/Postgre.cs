using ARM.Util;
using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM.DB
{
	public static class Postgre
	{
		//public static NpgsqlConnection Conn = new NpgsqlConnection("Server=http://4bea510b.ngork.io;Port=5432;User Id=postgres;Password=Admin;Database=arm;");
		//http://4bea510b.ngork.io
		//  public static NpgsqlConnection Conn = new NpgsqlConnection("Server=10.0.0.3;Port=5432;User Id=postgres;Password=Admin;Database=arm;");
		//  public static string port 
		public static NpgsqlConnection Conn = new NpgsqlConnection("Server=" + Helper.serverIP + ";Port=" + Helper.port + ";User Id=postgres;Password=Admin;Database=arm;");
		static NpgsqlDataReader Readers = null;
		static NpgsqlCommand cmd = null;
		//public static NpgsqlConnection Conn = new NpgsqlConnection("Server=omnierps.com;Port=5432;User Id=omnierps_admin;Password=Omni.2018;Database=omnierps_arm;");

		public static bool Open()
		{
			bool ans = false;
			try
			{
				Conn.Open();
				ans = true;
			}
			catch (Exception exp)
			{
				Console.WriteLine("Error Connecting " + exp.Message);
				ans = false;
			}
			return ans;
		}
		public static List<T> DataReaderMapToList<T>(NpgsqlDataReader dr)
		{
			List<T> list = new List<T>();
			T obj = default(T);
			while (dr.Read())
			{
				obj = Activator.CreateInstance<T>();
				foreach (PropertyInfo prop in obj.GetType().GetProperties())
				{
					if (!object.Equals(dr[prop.Name], DBNull.Value))
					{
						prop.SetValue(obj, dr[prop.Name], null);
					}
				}
				list.Add(obj);
			}
			return list;
		}
		public static bool Close()
		{
			bool ans = false;
			try
			{
				Conn.Close();
				ans = true;
			}
			catch (Exception)
			{
				Console.WriteLine("Error :S");
				ans = false;
			}
			return ans;
		}

		public static NpgsqlDataReader Reading(string query)
		{
			try
			{
				Readers = null;
				Open();
				cmd = new NpgsqlCommand(query, Conn);
				Readers = cmd.ExecuteReader();

			}
			catch (Exception c)
			{
				Close();
				//throw;// (c.Message.ToString());
			}
			return Readers;

		}

		public static int Query(string query)
		{
			Int32 rowsaffected = 0;

			try
			{
				Open();
			}
			catch
			{
			}

			NpgsqlCommand command = new NpgsqlCommand(query, Conn);
			rowsaffected = command.ExecuteNonQuery();
			try
			{
				Close();
			}
			catch (Exception c)
			{
				Close();
				//throw;
				Console.WriteLine("ERROR EXECUTING QUERY!" + c.Message);
				//Helper.Exceptions(c.Message, " ERROR EXECUTING QUERY! DBCONNECT QueryPostgre() ");
				return 0;
			}
			return rowsaffected;
		}

		public static string Insert(Object objGen)
		{
			Int32 rowsaffected = 0;
			//try
			//{


			// Get type and properties (vector)
			Type typeObj = objGen.GetType();
			PropertyInfo[] properties = typeObj.GetProperties();

			// Get table
			string[] type = typeObj.ToString().Split('.');
			string table = type[2].ToLower();

			// Start mounting string to insert
			string SQL = "INSERT INTO " + table + " VALUES (";

			// It goes from second until second to last
			for (int i = 0; i < properties.Length - 1; i++)
			{
				object propValue = properties[i].GetValue(objGen, null);
				string[] typeValue = propValue.GetType().ToString().Split('.');
				if (typeValue[1].Equals("String"))
				{
					SQL += "'" + propValue.ToString() + "',";
				}
				else if (typeValue[1].Equals("DateTime"))
				{
					SQL += "'" + Convert.ToDateTime(propValue.ToString()).ToShortDateString() + "',";
				}

				else
				{
					SQL += propValue.ToString() + ",";
				}
			}

			// get last attribute here
			object lastValue = properties[properties.Length - 1].GetValue(objGen, null);
			string[] lastType = lastValue.GetType().ToString().Split('.');
			if (lastType[1].Equals("String"))
			{
				SQL += "'" + lastValue.ToString() + "'";
			}
			else if (lastType[1].Equals("DateTime"))
			{
				SQL += "'" + Convert.ToDateTime(lastValue.ToString()).ToShortDateString() + "'";
			}

			else
			{
				SQL += lastValue.ToString();
			}

			// Ends string builder
			SQL += ");";

			// Execute command

			Open();
			NpgsqlCommand command = new NpgsqlCommand(SQL, Conn);
			rowsaffected = command.ExecuteNonQuery();

			Close();
			return SQL;
			//}
			//catch (Exception c)
			//{
			//    Console.WriteLine("Errr on insert!" + c.Message);
			//    return "";
			//}


		}



		public static string CreateDBSQL(Object objGen)
		{
			//try
			//{
			// Open();

			// Get type and properties (vector)
			Type typeObj = objGen.GetType();
			PropertyInfo[] properties = typeObj.GetProperties();

			// Get table
			string[] type = typeObj.ToString().Split('.');
			string table = type[2].ToLower();

			// Start mounting string to insert           
			string SQL = "CREATE TABLE IF NOT  EXISTS " + table + "  (";

			// It goes from second until second to last
			for (int i = 0; i < properties.Length - 1; i++)
			{
				//object propValue = properties[i].GetValue(objGen, null);
				string[] typeValue = properties[i].ToString().Split(' ');
				if (typeValue[1].ToString().IndexOf("image", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					SQL += "" + typeValue[1].ToString() + " text,";
				}
				else if (typeValue[1].ToString().IndexOf("strings", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					SQL += "" + typeValue[1].ToString() + " text,";
				}
				else
				{
					SQL += "" + typeValue[1].ToString() + " varchar(1000),";
				}

			}

			// get last attribute here           
			string[] lastType = properties[properties.Length - 1].ToString().Split(' ');
			if (lastType[1].ToString().IndexOf("image", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				SQL += "" + lastType[1].ToString() + " text";
			}
			else if (lastType[1].ToString().IndexOf("strings", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				SQL += "" + lastType[1].ToString() + " text";
			}
			else
			{
				SQL += "" + lastType[1].ToString() + " varchar(1000)";
			}


			// SQL += "" + lastType[1].ToString() + " varchar(1000)";


			// Ends string builder
			SQL += ");";


			return SQL;
			//}
			//catch (Exception c)
			//{
			//    Console.WriteLine("Errr on insert!" + c.Message);
			//    return "";
			//}
		}


		public static string datalocation()
		{
			string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
			string appPath = Path.GetDirectoryName(Application.ExecutablePath);
			//   string fullFilePath = Path.Combine(appPath, "casesLite.txt");
			string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			return "Data Source=" + dir + "\\cases.db;";
			/// 
			// Helper.GrantAccess(appPath + "\\pos.bbs;");
			// return "Data Source=" + appPath + "\\pos.bbs;";
		}
		public static string XMLFile()
		{
			string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
			string appPath = Path.GetDirectoryName(Application.ExecutablePath);
			string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			return dir + "\\cases.xml";

		}

		public static string Documents()
		{
			string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
			string appPath = Path.GetDirectoryName(Application.ExecutablePath);
			string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			if (!Directory.Exists(dir + "\\CASE\\"))
			{
				DirectoryInfo dim = Directory.CreateDirectory(dir + "\\CASE\\");
				Console.WriteLine("The directory was created successfully at {0}.",
				Directory.GetCreationTime(dir + "\\CASE\\"));
			}
			GrantAccess(dir + "\\CASE\\");
			return dir + "\\CASE\\";

		}
		private static void GrantAccess(string file)
		{
			bool exists = System.IO.Directory.Exists(file);

			if (exists)
			{
				DirectoryInfo di = System.IO.Directory.CreateDirectory(file);
				Console.WriteLine("The Folder is created Sucessfully");
			}
			else
			{
				Console.WriteLine("The Folder already exists");
			}
			DirectoryInfo dInfo = new DirectoryInfo(file);
			DirectorySecurity dSecurity = dInfo.GetAccessControl();
			dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
			dInfo.SetAccessControl(dSecurity);

		}
		public static void createDB(String SQL)
		{
			Open();
			NpgsqlCommand command = new NpgsqlCommand(SQL, Conn);
			Int32 rowsaffected = command.ExecuteNonQuery();
			Close();
		}


		public static string EmptyDBSQL(Object objGen)
		{
			//try
			//{
			// Open();

			// Get type and properties (vector)
			Type typeObj = objGen.GetType();
			PropertyInfo[] properties = typeObj.GetProperties();

			// Get table
			string[] type = typeObj.ToString().Split('.');
			string table = type[2].ToLower();

			// Start mounting string to insert           
			string SQL = "DELETE FROM " + table + "";

			return SQL;
			//}
			//catch (Exception c)
			//{
			//    Console.WriteLine("Errr on insert!" + c.Message);
			//    return "";
			//}
		}



		public static string Update(Object objGen, string idValue)
		{
			Int32 rowsaffected = 0;
			//try
			//{


			// Get table
			string[] type = objGen.GetType().ToString().Split('.');
			string table = type[2].ToLower();

			// Start building
			string SQL = "UPDATE " + table + " SET ";

			// Get types and properties
			Type type2 = objGen.GetType();
			PropertyInfo[] properties = type2.GetProperties();

			// Goes until second to last
			for (int i = 0; i < properties.Length - 1; i++)
			{
				object propValue = properties[i].GetValue(objGen, null);
				string[] nameAttribute = properties[i].ToString().Split(' ');
				string[] typeAttribute = propValue.GetType().ToString().Split('.');

				if (typeAttribute[1].Equals("String"))
				{
					SQL += nameAttribute[1] + " = '" + propValue.ToString() + "',";
				}
				else if (typeAttribute[1].Equals("DateTime"))
				{
					SQL += nameAttribute[1] + "= '" + Convert.ToDateTime(propValue.ToString()).ToShortDateString() + "',";
				}
				else
				{
					SQL += nameAttribute[1] + " = " + propValue.ToString() + ",";
				}
			}

			// Process last attribute
			object lastValue = properties[properties.Length - 1].GetValue(objGen, null);
			string[] lastType = lastValue.GetType().ToString().Split('.');
			string[] ultimoCampo = properties[properties.Length - 1].ToString().Split(' ');
			if (lastType[1].Equals("String"))
			{
				SQL += ultimoCampo[1] + " = '" + lastValue.ToString() + "'";
			}
			else if (lastType[1].Equals("DateTime"))
			{
				SQL += ultimoCampo[1] + "= '" + Convert.ToDateTime(lastValue.ToString()).ToShortDateString() + "'";
			}
			else
			{
				SQL += ultimoCampo[1] + " = " + lastValue.ToString();
			}

			// Ends string builder
			SQL += " WHERE id = '" + idValue + "';";


			//}
			//catch (Exception)
			//{
			//    Console.WriteLine("Errr on update!");
			//}

			Open();
			NpgsqlCommand command = new NpgsqlCommand(SQL, Conn);
			rowsaffected = command.ExecuteNonQuery();

			Close();
			return SQL;
			//}
			//catch (Exception c)
			//{
			//    Console.WriteLine("Errr on insert!" + c.Message);
			//    return "";
			//}


		}


		public static void Execute(string query)
		{
			//try
			//{

			//}
			//catch (Exception c)
			//{
			//    Console.WriteLine("Errr on update!" + c.Message.ToString());
			//}


			Open();
			NpgsqlCommand command = new NpgsqlCommand(query, Conn);
			Int32 rowsaffected = command.ExecuteNonQuery();

			Close();

			//}
			//catch (Exception c)
			//{
			//    Console.WriteLine("Errr on insert!" + c.Message);
			//    return "";
			//}


		}
		public static void Delete(string table, string idValue)
		{
			//try
			//{
			Open();

			string SQL = "DELETE FROM " + table + " WHERE id = '" + idValue + "';";

			NpgsqlCommand command = new NpgsqlCommand(SQL, Conn);
			Int32 rowsaffected = command.ExecuteNonQuery();

			Close();
			//}
			//catch (Exception)
			//{
			//    Console.WriteLine("Errr on update!");
			//}
		}
		public static List<Object> QueryTable(string table)
		{
			try
			{
				Open();

				List<Object> lstSelect = new List<Object>();
				string SQL = "SELECT * FROM " + table + ";";

				NpgsqlCommand command = new NpgsqlCommand(SQL, Conn);
				NpgsqlDataReader dr = command.ExecuteReader();

				while (dr.Read())
				{
					for (int i = 0; i < dr.FieldCount; i++)
					{
						lstSelect.Add(dr[i]);
					}
				}

				Close();

				return lstSelect;
			}
			catch (Exception)
			{
				Console.WriteLine("Errr on query!");
				return null;
			}
		}
		public static double Max(string SQL)
		{

			var answer = scalar(SQL);
			return Convert.ToDouble(answer);
		}
		public static string value(string Q)
		{
			var answer = scalar(Q);
			return answer;
		}
		public static string scalar(string query)
		{
			Open();
			cmd = new NpgsqlCommand(query, Conn);
			object results = cmd.ExecuteScalar();
			Close();
			return results.ToString();
		}


	}
}

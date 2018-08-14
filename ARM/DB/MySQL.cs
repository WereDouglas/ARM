using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ARM.DB
{
	public static class MySQL
	{
		public static MySqlConnection Conn = new MySqlConnection("Server=novariss.com;Database=novaris2_arm;UID=novaris2_arm;Password=Arm.2018");
		static MySqlDataReader Reader =null;
		static MySqlCommand Cmd = null;
		public static string scalar(string query)
		{
			Open();
			Cmd = new MySqlCommand(query, Conn);
			object results = Cmd.ExecuteScalar();
			Close();
			return results.ToString();
		}
		public static string save(string query)
		{
			Open();
			Cmd = new MySqlCommand(query, Conn);
			Int32 rowsaffected = Cmd.ExecuteNonQuery();
			Close();
			return rowsaffected.ToString();
		}

		public static List<T> DataReaderMapToList<T>(MySqlDataReader dr)
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
						if (prop.PropertyType == typeof(int))
						{
							prop.SetValue(obj, Convert.ToInt32(dr[prop.Name]), null);
						}
						else if (prop.PropertyType == typeof(double))
						{
							prop.SetValue(obj, Convert.ToDouble(dr[prop.Name]), null);
						}
						else {
							prop.SetValue(obj, dr[prop.Name], null);
						}
					}					
				}
				list.Add(obj);
			}
			return list;
		}

		public static MySqlDataReader Reading(string query)
		{
			Reader = null;
			Open();
			Cmd = new MySqlCommand(query, Conn);
			Reader = Cmd.ExecuteReader();
		   //Close();
			return Reader;
		}

		public static string Insert(Object objGen)
		{
			Int32 rowsaffected = 0;
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
			MySqlCommand command = new MySqlCommand(SQL, Conn);
			try
			{
				rowsaffected = command.ExecuteNonQuery();
			}
			catch (Exception u)
			{

				System.Diagnostics.Debug.WriteLine(u.Message);

			}

			Close();
			return rowsaffected.ToString();
		}
		public static void Update(Object objGen, string idValue)
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
			try
			{
				Open();
				MySqlCommand command = new MySqlCommand(SQL, Conn);
				rowsaffected = command.ExecuteNonQuery();

				Close();

			}
			catch (Exception c)
			{
				Console.WriteLine("Errr on insert!" + c.Message);

			}
		}
		public static string value(string Q)
		{
			var answer = scalar(Q);
			return answer;
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
					SQL += "" + typeValue[1].ToString().ToLower() + " text,";
				}
				else if (typeValue[1].ToString().IndexOf("strings", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					SQL += "" + typeValue[1].ToString().ToLower() + " text,";
				}
				else
				{
					SQL += "" + typeValue[1].ToString().ToLower() + " varchar(1000),";
				}

			}

			// get last attribute here           
			string[] lastType = properties[properties.Length - 1].ToString().Split(' ');
			if (lastType[1].ToString().IndexOf("image", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				SQL += "" + lastType[1].ToString().ToLower() + " text";
			}
			else if (lastType[1].ToString().IndexOf("strings", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				SQL += "" + lastType[1].ToString().ToLower() + " text";
			}
			else
			{
				SQL += "" + lastType[1].ToString().ToLower() + " varchar(1000)";
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


		public static void createDB(String SQL)
		{
			Open();
			MySqlCommand command = new MySqlCommand(SQL, Conn);
			Int32 rowsaffected = command.ExecuteNonQuery();
			Close();
		}
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
				Conn.Close();
				Conn.Open();
				System.Diagnostics.Debug.WriteLine("Error :Opening MySQL Connection" + exp.Message);
				if (exp.Message.Contains("open")) { ans = true; } else { ans = false; }
				
			}
			return ans;
		}
		public static bool Close()
		{
			bool ans = false;
			try
			{
				Conn.Close();
				ans = true;
			}
			catch (Exception exp)
			{
				System.Diagnostics.Debug.WriteLine("Error :Closing MySQL Connection" + exp);
				ans = false;
			}
			return ans;
		}
		public static string Query(string query)
		{
			Int32 rowsaffected = 0;
			Open();
			MySqlCommand command = new MySqlCommand(query, Conn);
			try
			{
				rowsaffected = command.ExecuteNonQuery();
			}
			catch (Exception c)
			{
				Console.WriteLine("Errr on insert!" + c.Message);
			}
			Close();
			return rowsaffected.ToString();
		}
		public static void Execute(string query)
		{
			try
			{
				Open();
				Cmd = new MySqlCommand(query, Conn);
				Int32 rowsaffected = Cmd.ExecuteNonQuery();
				Close();
			}
			catch (Exception c)
			{
				Console.WriteLine("Errr on update!" + c.Message.ToString());
			}

		}
		public static void Delete(string table, string idValue)
		{

			Open();

			string SQL = "DELETE FROM " + table + " WHERE id = '" + idValue + "';";

			Cmd = new MySqlCommand(SQL, Conn);
			Int32 rowsaffected = Cmd.ExecuteNonQuery();

			Close();

		}
		public static List<Object> QueryTable(string table)
		{
			try
			{
				Open();

				List<Object> lstSelect = new List<Object>();
				string SQL = "SELECT * FROM " + table + ";";

				Cmd = new MySqlCommand(SQL, Conn);
				MySqlDataReader dr = Cmd.ExecuteReader();

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


	}
}

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
    public static class DBConnect
    {
        public static NpgsqlConnection conn = new NpgsqlConnection("Server=10.0.0.251;Port=5432;User Id=postgres;Password=Admin;Database=arm;");
        static NpgsqlDataReader Readers = null;
        static NpgsqlCommand cmd = null;

        public static void OpenConn()
        {
            try
            {
                conn.Open();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error :S");
            }
        }

        public static void CloseConn()
        {
            try
            {
                conn.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Error :S");
            }
        }


        public static NpgsqlDataReader Reading(string query)
        {
            Readers = null;
            DBConnect.OpenConn();
            cmd = new NpgsqlCommand(query, DBConnect.conn);
            Readers = cmd.ExecuteReader();
            return Readers;

        }


        public static string save(string query)
        {
            Int32 rowsaffected = 0;

            //try
            //{
            OpenConn();

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            rowsaffected = command.ExecuteNonQuery();

            CloseConn();
            // return rowsaffected.ToString();
            //}
            //catch (Exception c)
            //{
            //    Console.WriteLine("Errr on insert!" + c.Message);
            //    return "";
            //}

            return rowsaffected.ToString();
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

            OpenConn();
            NpgsqlCommand command = new NpgsqlCommand(SQL, conn);
            rowsaffected = command.ExecuteNonQuery();

            CloseConn();
            return rowsaffected.ToString();
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
            // OpenConn();

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
                SQL += "" + typeValue[1].ToString() + " varchar(255),";

            }

            // get last attribute here           
            string[] lastType = properties[properties.Length - 1].ToString().Split(' ');

            SQL += "" + lastType[1].ToString() + " varchar(255)";


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
        public static void createSQLLiteDB(String SQL)
        {
            OpenConn();
            NpgsqlCommand command = new NpgsqlCommand(SQL, conn);
            Int32 rowsaffected = command.ExecuteNonQuery();
            CloseConn();
        }


        public static string EmptyDBSQL(Object objGen)
        {
            //try
            //{
            // OpenConn();

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


        public static string GenerateQuery(Object objGen)
        {
            //try
            //{

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

            return SQL;

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

            OpenConn();
            NpgsqlCommand command = new NpgsqlCommand(SQL, conn);
            rowsaffected = command.ExecuteNonQuery();

            CloseConn();

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


            OpenConn();
            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            Int32 rowsaffected = command.ExecuteNonQuery();

            CloseConn();

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
            OpenConn();

            string SQL = "DELETE FROM " + table + " WHERE id = '" + idValue + "';";

            NpgsqlCommand command = new NpgsqlCommand(SQL, conn);
            Int32 rowsaffected = command.ExecuteNonQuery();

            CloseConn();
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
                OpenConn();

                List<Object> lstSelect = new List<Object>();
                string SQL = "SELECT * FROM " + table + ";";

                NpgsqlCommand command = new NpgsqlCommand(SQL, conn);
                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        lstSelect.Add(dr[i]);
                    }
                }

                CloseConn();

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

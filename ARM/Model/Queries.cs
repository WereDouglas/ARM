using ARM.DB;
using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
    public class Queries
    {
        private string id;
        private string by;
        private string strings;
        private bool executed;        
        private string created;        
        private string companyID;
        public Queries() { }

        public Queries(string id, string by, string strings, bool executed, string created, string companyID)
        {
            this.Id = id;
            this.By = by;
            this.Strings = strings;
            this.Executed = executed;
            this.Created = created;
            this.CompanyID = companyID;
        }

        static List<Queries> p = new List<Queries>();  
        public static List<Queries> List()
        {
            p.Clear();
            string Q = "SELECT * FROM Queries ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Queries ps = new Queries(Reader["id"].ToString(), Reader["by"].ToString(), Reader["strings"].ToString(),Convert.ToBoolean(Reader["executed"]),Reader["created"].ToString(), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Queries> List(string Q)
        {
            p.Clear();

            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Queries ps = new Queries(Reader["id"].ToString(), Reader["by"].ToString(), Reader["strings"].ToString(), Convert.ToBoolean(Reader["executed"]), Reader["created"].ToString(), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Queries> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Queries ps = new Queries(Reader["id"].ToString(), Reader["by"].ToString(), Reader["strings"].ToString(), Convert.ToBoolean(Reader["executed"]), Reader["created"].ToString(), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;

        }
        static Queries c;

        public string Id { get => id; set => id = value; }
        public string By { get => by; set => by = value; }
        public string Strings { get => strings; set => strings = value; }
        public bool Executed { get => executed; set => executed = value; }
        public string Created { get => created; set => created = value; }
        public string CompanyID { get => companyID; set => companyID = value; }

        public static Queries Select(string ID)
        {
            string Q = "SELECT * FROM queries WHERE id = '" + ID + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                c = new Queries(Reader["id"].ToString(), Reader["by"].ToString(), Reader["strings"].ToString(), Convert.ToBoolean(Reader["executed"]), Reader["created"].ToString(), Reader["companyID"].ToString());
            }
            DBConnect.CloseConn();
            return c;

        }
    }

}

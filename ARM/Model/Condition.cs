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
    public class Condition
    {
        private string id;        
        private string customerID;
        private string name;
        private string type;        
        private string details;
        private string created; 
        private bool sync;
        private string companyID;        

        public Condition() { }

        public Condition(string id, string customerID, string name, string type, string details, string created, bool sync, string companyID)
        {
            this.Id = id;
            this.CustomerID = customerID;
            this.Name = name;
            this.Type = type;
            this.Details = details;
            this.Created = created;
            this.Sync = sync;
            this.CompanyID = companyID;
        }

        static List<Condition> p = new List<Condition>();

       
        public static List<Condition> List()
        {
            p.Clear();
            string Q = "SELECT * FROM condition ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Condition ps = new Condition(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["details"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]),Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Condition> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Condition ps = new Condition(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["details"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Condition> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Condition ps = new Condition(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["details"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;

        }
        private static Condition c = new Condition();

        public string Id { get => id; set => id = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public string Details { get => details; set => details = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }

        public static Condition Select(string customerID)
        {
            string Q = "SELECT * FROM condition WHERE id = '" + customerID + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                c = new Condition(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["details"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());

            }
            DBConnect.CloseConn();
            return c;

        }
    }

}

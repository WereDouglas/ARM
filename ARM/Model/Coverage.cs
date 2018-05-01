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
    public class Coverage
    {
        private string id;
        private string customerID;
        private string name;
        private string type;//state ,federal,private{company ,self out of pocket } , Employer group
        private string category;//state ,federal,private
        private string no;       
        private string created;
        private bool sync;
        private string companyID;
        public Coverage() { }

        public Coverage(string id, string customerID, string name, string type, string category, string no, string created, bool sync, string companyID)
        {
            this.Id = id;
            this.CustomerID = customerID;
            this.Name = name;
            this.Type = type;
            this.Category = category;
            this.No = no;
            this.Created = created;
            this.Sync = sync;
            this.CompanyID = companyID;
        }

        static List<Coverage> p = new List<Coverage>();

       

        public static List<Coverage> List()
        {
            p.Clear();
            string Q = "SELECT * FROM coverage ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Coverage ps = new Coverage(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["category"].ToString(), Reader["no"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Coverage> List(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenConn();
                NpgsqlDataReader Reader = DBConnect.Reading(Q);
                while (Reader.Read())
                {
                    Coverage ps = new Coverage(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["category"].ToString(), Reader["no"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseConn();
            }
            catch { }
            return p;
        }
        public static List<Coverage> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Coverage ps = new Coverage(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["category"].ToString(), Reader["no"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;
        }
        static List<Coverage> c = new List<Coverage>();

        public string Id { get => id; set => id = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public string Category { get => category; set => category = value; }
        public string No { get => no; set => no = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }
        private static Coverage k = new Coverage();
        public static Coverage Select(string id)
        {
            string Q = "SELECT * FROM coverage WHERE id = '" + id + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                k = new Coverage(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["category"].ToString(), Reader["no"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
              
            }
            DBConnect.CloseConn();
            return k;

        }
    }

}

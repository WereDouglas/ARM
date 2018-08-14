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
    public class Exceptions
    {
        private string id;
        private string message;
        private string created;
        private string process;     
       private string sync; private string companyID;
        public Exceptions() { }

        public Exceptions(string id, string message, string created, string process, string sync,string companyID)
        {
            this.Id = id;
            this.Message = message;
            this.Created = created;
            this.Process = process;
            this.Sync = sync;
			this.CompanyID = companyID;
        }

        static List<Exceptions> p = new List<Exceptions>();

        public string Id { get => id; set => id = value; }
        public string Message { get => message; set => message = value; }
        public string Created { get => created; set => created = value; }
        public string Process { get => process; set => process = value; }
        public string Sync { get => sync; set => sync = value; } public string CompanyID { get => companyID; set => companyID = value; }

        public static List<Exceptions> List(string start,string end)
        {
            try
            {
                p.Clear();
                string Q = "SELECT * FROM exceptions WHERE  (created::date >= '" + start + "'::date AND  created::date <= '" + end + "'::date) ;";
                // string Q = "SELECT * FROM Exceptions ";
               
                MySqlDataReader Reader = MySQL.Reading(Q);
                while (Reader.Read())
                {
                    Exceptions ps = new Exceptions(Reader["id"].ToString(), Reader["message"].ToString(), Reader["created"].ToString(), Reader["process"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
               
            }
            catch { }
            return p;

        }
        public static List<Exceptions> List(string Q)
        {
            try
            {
                p.Clear();
              
                MySqlDataReader Reader = MySQL.Reading(Q);
                while (Reader.Read())
                {
                    Exceptions ps = new Exceptions(Reader["id"].ToString(), Reader["message"].ToString(), Reader["created"].ToString(), Reader["process"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch {

            }
            return p;

        }
    }

}

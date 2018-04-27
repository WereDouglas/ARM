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
    public class Service
    {
        private string id;
        private string caseID;
        private string customerID;       
        private string starts;
        private string ends;       
        private string type;//outpatient ,Planned inpatient ,Emergency inpatient ,skilled nursing facility ,Long term services & supports/longterm care ,Home health,Durable medical equipment,Diagnostic study ,Hospice,Office visit, Personal care services ,Other
        private string place;//Hospital,Ambulatory surgery center,office,Home,Independent lab,Nursing facility,Other     
        private string information;
        private string created;
        private string procedureCode;
        private string description;
        private string reqStart;
        private string reqEnd;
        private string authStart;
        private string authEnd;
        private bool sync;
        private string companyID;
        public Service() { }

      

        static List<Service> p = new List<Service>();

       

        public static List<Service> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
              //  Service ps = new Service(Reader["id"].ToString(), Reader["caseID"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["no"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
               // p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
        public static List<Service> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                   // Service ps = new Service(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["no"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                   // p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;
        }
        static List<Service> c = new List<Service>();

        

        public static List<Service> Select(string id)
        {
            string Q = "SELECT * FROM coverage WHERE customerID = '" + id + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                //Service k = new Service(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["no"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
               // c.Add(k);
            }
            DBConnect.CloseConn();
            return c;

        }
    }

}

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

        public Service(string id, string caseID, string customerID, string starts, string ends, string type, string place, string information, string created, string procedureCode, string description, string reqStart, string reqEnd, string authStart, string authEnd, bool sync, string companyID)
        {
            this.Id = id;
            this.CaseID = caseID;
            this.CustomerID = customerID;
            this.Starts = starts;
            this.Ends = ends;
            this.Type = type;
            this.Place = place;
            this.Information = information;
            this.Created = created;
            this.ProcedureCode = procedureCode;
            this.Description = description;
            this.ReqStart = reqStart;
            this.ReqEnd = reqEnd;
            this.AuthStart = authStart;
            this.AuthEnd = authEnd;
            this.Sync = sync;
            this.CompanyID = companyID;
        }

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

        public string Id { get => id; set => id = value; }
        public string CaseID { get => caseID; set => caseID = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string Starts { get => starts; set => starts = value; }
        public string Ends { get => ends; set => ends = value; }
        public string Type { get => type; set => type = value; }
        public string Place { get => place; set => place = value; }
        public string Information { get => information; set => information = value; }
        public string Created { get => created; set => created = value; }
        public string ProcedureCode { get => procedureCode; set => procedureCode = value; }
        public string Description { get => description; set => description = value; }
        public string ReqStart { get => reqStart; set => reqStart = value; }
        public string ReqEnd { get => reqEnd; set => reqEnd = value; }
        public string AuthStart { get => authStart; set => authStart = value; }
        public string AuthEnd { get => authEnd; set => authEnd = value; }
        public bool Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }

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

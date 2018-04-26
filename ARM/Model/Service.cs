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
        private string icd10;
        private string starts;
        private string ends;
        private string cptCode;
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

        public Service(string id, string caseID, string icd10, string starts, string ends, string cptCode, string type, string place, string information, string created, bool sync, string companyID)
        {
            this.Id1 = id;
            this.CaseID = caseID;
            this.Icd10 = icd10;
            this.Starts = starts;
            this.Ends = ends;
            this.CptCode = cptCode;
            this.Type1 = type;
            this.Place = place;
            this.Information = information;
            this.Created1 = created;
            this.Sync1 = sync;
            this.CompanyID1 = companyID;
        }

        static List<Service> p = new List<Service>();

       

        public static List<Service> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Service ps = new Service(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["no"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
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
                    Service ps = new Service(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["no"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;
        }
        static List<Service> c = new List<Service>();

        public string Id { get => Id1; set => Id1 = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => Type1; set => Type1 = value; }
        public string No { get => no; set => no = value; }
        public string Created { get => Created1; set => Created1 = value; }
        public bool Sync { get => Sync1; set => Sync1 = value; }
        public string CompanyID { get => CompanyID1; set => CompanyID1 = value; }
        public string Id1 { get => id; set => id = value; }
        public string CaseID { get => caseID; set => caseID = value; }
        public string Icd10 { get => icd10; set => icd10 = value; }
        public string Starts { get => starts; set => starts = value; }
        public string Ends { get => ends; set => ends = value; }
        public string CptCode { get => cptCode; set => cptCode = value; }
        public string Type1 { get => type; set => type = value; }
        public string Place { get => place; set => place = value; }
        public string Information { get => information; set => information = value; }
        public string Created1 { get => created; set => created = value; }
        public bool Sync1 { get => sync; set => sync = value; }
        public string CompanyID1 { get => companyID; set => companyID = value; }

        public static List<Service> Select(string id)
        {
            string Q = "SELECT * FROM coverage WHERE customerID = '" + id + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Service k = new Service(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["no"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                c.Add(k);
            }
            DBConnect.CloseConn();
            return c;

        }
    }

}

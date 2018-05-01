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
    public class Cases
    {
        private string id;
        private string date;
        private string no;
        private string provideNo;
        private string coverageID;
        private string customerID;
        private string practitionerID;
        private string practitionerType;//participating /non participating
        private string roleType;//participating /non participating              
        private string type;//outpatient ,Planned inpatient ,Emergency inpatient ,skilled nursing facility ,Long term services & supports/longterm care ,Home health,Durable medical equipment,Diagnostic study ,Hospice,Office visit, Personal care services ,Other
        private string place;//Hospital,Ambulatory surgery center,office,Home,Independent lab,Nursing facility,Other     
        private string information;
        private string created;
        private string reqStart;
        private string reqEnd;
        private string authStart;
        private string authEnd;
        private bool sync;
        private string companyID;
        public Cases() { }

        public Cases(string id, string date, string no, string provideNo, string coverageID, string customerID, string practitionerID, string practitionerType, string roleType, string type, string place, string information, string created, string reqStart, string reqEnd, string authStart, string authEnd, bool sync, string companyID)
        {
            this.Id = id;
            this.Date = date;
            this.No = no;
            this.ProvideNo = provideNo;
            this.CoverageID = coverageID;
            this.CustomerID = customerID;
            this.PractitionerID = practitionerID;
            this.PractitionerType = practitionerType;
            this.RoleType = roleType;
            this.Type = type;
            this.Place = place;
            this.Information = information;
            this.Created = created;
            this.ReqStart = reqStart;
            this.ReqEnd = reqEnd;
            this.AuthStart = authStart;
            this.AuthEnd = authEnd;
            this.Sync = sync;
            this.CompanyID = companyID;
        }

        static List<Cases> p = new List<Cases>();



        public static List<Cases> List(string Q)
        {
            //try
            //{
                p.Clear();
                DBConnect.OpenConn();
                NpgsqlDataReader Reader = DBConnect.Reading(Q);
                while (Reader.Read())
                {
                    Cases ps = new Cases(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["provideNo"].ToString(), Reader["coverageID"].ToString(), Reader["customerID"].ToString(), Reader["practitionerID"].ToString(), Reader["practitionerType"].ToString(), Reader["roleType"].ToString(), Reader["type"].ToString(), Reader["place"].ToString(), Reader["information"].ToString(), Reader["created"].ToString(), Reader["reqStart"].ToString(), Reader["reqEnd"].ToString(), Reader["authStart"].ToString(), Reader["authEnd"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseConn();
            //}
            //catch (Exception e)
            //{

            //    System.Diagnostics.Debug.WriteLine("" + e);
            //}
            return p;
        }
        public static List<Cases> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Cases ps = new Cases(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["provideNo"].ToString(), Reader["coverageID"].ToString(), Reader["customerID"].ToString(), Reader["practitionerID"].ToString(), Reader["practitionerType"].ToString(), Reader["roleType"].ToString(), Reader["type"].ToString(), Reader["place"].ToString(), Reader["information"].ToString(), Reader["created"].ToString(), Reader["reqStart"].ToString(), Reader["reqEnd"].ToString(), Reader["authStart"].ToString(), Reader["authEnd"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;
        }
        static List<Cases> c = new List<Cases>();

        public string Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public string No { get => no; set => no = value; }
        public string ProvideNo { get => provideNo; set => provideNo = value; }
        public string CoverageID { get => coverageID; set => coverageID = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string PractitionerID { get => practitionerID; set => practitionerID = value; }
        public string PractitionerType { get => practitionerType; set => practitionerType = value; }
        public string RoleType { get => roleType; set => roleType = value; }
        public string Type { get => type; set => type = value; }
        public string Place { get => place; set => place = value; }
        public string Information { get => information; set => information = value; }
        public string Created { get => created; set => created = value; }
        public string ReqStart { get => reqStart; set => reqStart = value; }
        public string ReqEnd { get => reqEnd; set => reqEnd = value; }
        public string AuthStart { get => authStart; set => authStart = value; }
        public string AuthEnd { get => authEnd; set => authEnd = value; }
        public bool Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }
        private static Cases k = new Cases();
        public static Cases Select(string id)
        {
            string Q = "SELECT * FROM cases WHERE id = '" + id + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                k = new Cases(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["provideNo"].ToString(), Reader["coverageID"].ToString(), Reader["customerID"].ToString(), Reader["practitionerID"].ToString(), Reader["practitionerType"].ToString(), Reader["roleType"].ToString(), Reader["type"].ToString(), Reader["place"].ToString(), Reader["information"].ToString(), Reader["created"].ToString(), Reader["reqStart"].ToString(), Reader["reqEnd"].ToString(), Reader["authStart"].ToString(), Reader["authEnd"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                
            }
            DBConnect.CloseConn();
            return k;

        }
    }

}

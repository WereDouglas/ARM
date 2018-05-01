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
    public class ICD10
    {
        private string id;
        private string caseID;
        private string code;     
        private string name;                
        private string created;      
        private bool sync;
        private string companyID;
        public ICD10() { }

        public ICD10(string id, string caseID, string code, string name, string created, bool sync, string companyID)
        {
            this.Id = id;
            this.CaseID = caseID;
            this.Code = code;
            this.Name = name;
            this.Created = created;
            this.Sync = sync;
            this.CompanyID = companyID;
        }

        private static List<ICD10> p = new List<ICD10>();

        public string Id { get => id; set => id = value; }
        public string CaseID { get => caseID; set => caseID = value; }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }

        public static List<ICD10> List(string Q)
        {
            p.Clear();
          //  string Q = "SELECT * FROM ICD10 WHERE caseID = '"+caseID+"' ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                ICD10 ps = new ICD10(Reader["id"].ToString(), Reader["caseID"].ToString(), Reader["code"].ToString(), Reader["name"].ToString(),Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<ICD10> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    ICD10 ps = new ICD10(Reader["id"].ToString(), Reader["caseID"].ToString(), Reader["code"].ToString(), Reader["name"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;

        }
        public static List<ICD10> ListUpload(string Q)
        {
            p.Clear();
             
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                ICD10 ps = new ICD10(Reader["id"].ToString(), Reader["caseID"].ToString(), Reader["code"].ToString(), Reader["name"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }

    }

}

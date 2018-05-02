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
    public class Dosage
    {
        private string id;
        private string serviceID;
        private string customerID;
        private string medication;
        private string amount;
        private string route;
        private string freq;
        private string starts;
        private string dc;       
        private string details;
        private string created; 
        private bool sync;
        private string companyID;
        

        public Dosage() { }

        public Dosage(string id, string serviceID, string customerID, string medication, string amount, string route, string freq, string starts, string dc, string details, string created, bool sync, string companyID)
        {
            this.Id = id;
            this.ServiceID = serviceID;
            this.CustomerID = customerID;
            this.Medication = medication;
            this.Amount = amount;
            this.Route = route;
            this.Freq = freq;
            this.Starts = starts;
            this.Dc = dc;
            this.Details = details;
            this.Created = created;
            this.Sync = sync;
            this.CompanyID = companyID;
        }

        static List<Dosage> p = new List<Dosage>();

        
        public static List<Dosage> List()
        {
            p.Clear();
            string Q = "SELECT * FROM customer ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Dosage ps = new Dosage(Reader["id"].ToString(), Reader["serviceID"].ToString(), Reader["customerID"].ToString(), Reader["medication"].ToString(), Reader["dosage"].ToString(), Reader["route"].ToString(), Reader["freq"].ToString(), Reader["starts"].ToString(), Reader["dc"].ToString(),Reader["details"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Dosage> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Dosage ps = new Dosage(Reader["id"].ToString(), Reader["serviceID"].ToString(), Reader["customerID"].ToString(), Reader["medication"].ToString(), Reader["amount"].ToString(), Reader["route"].ToString(), Reader["freq"].ToString(), Reader["starts"].ToString(), Reader["dc"].ToString(), Reader["details"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Dosage> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Dosage ps = new Dosage(Reader["id"].ToString(), Reader["serviceID"].ToString(), Reader["customerID"].ToString(), Reader["medication"].ToString(), Reader["amount"].ToString(), Reader["route"].ToString(), Reader["freq"].ToString(), Reader["starts"].ToString(), Reader["dc"].ToString(), Reader["details"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;

        }
        private static Dosage m = new Dosage();

        public string Id { get => id; set => id = value; }
        public string ServiceID { get => serviceID; set => serviceID = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string Medication { get => medication; set => medication = value; }
        public string Amount { get => amount; set => amount = value; }
        public string Route { get => route; set => route = value; }
        public string Freq { get => freq; set => freq = value; }
        public string Starts { get => starts; set => starts = value; }
        public string Dc { get => dc; set => dc = value; }
        public string Details { get => details; set => details = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }

        public static Dosage Select(string customerID)
        {
            string Q = "SELECT * FROM customer WHERE id = '" + customerID + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                m = new Dosage(Reader["id"].ToString(), Reader["serviceID"].ToString(), Reader["customerID"].ToString(), Reader["medication"].ToString(), Reader["amount"].ToString(), Reader["route"].ToString(), Reader["freq"].ToString(), Reader["starts"].ToString(), Reader["dc"].ToString(), Reader["details"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
            }
            DBConnect.CloseConn();
            return m;

        }
    }

}

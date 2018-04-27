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
        private string dosage;
        private string route;
        private string freq;
        private string starting;
        private string dc;
        private string n;
        private string c;
        private string details;
        private string created; 
        private bool sync;
        private string companyID;
        

        public Dosage() { }

        public Dosage(string id, string serviceID, string customerID, string medication, string dosage, string route, string freq, string starting, string dc, string n, string c, string details, string created, bool sync, string companyID)
        {
            this.id = id;
            this.serviceID = serviceID;
            this.customerID = customerID;
            this.medication = medication;
            this.dosage = dosage;
            this.route = route;
            this.freq = freq;
            this.starting = starting;
            this.dc = dc;
            this.n = n;
            this.c = c;
            this.details = details;
            this.created = created;
            this.sync = sync;
            this.companyID = companyID;
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
                Dosage ps = new Dosage(Reader["id"].ToString(), Reader["serviceID"].ToString(), Reader["customerID"].ToString(), Reader["medication"].ToString(), Reader["dosage"].ToString(), Reader["route"].ToString(), Reader["freq"].ToString(), Reader["starting"].ToString(), Reader["dc"].ToString(),Reader["n"].ToString(), Reader["c"].ToString(), Reader["details"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
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
                Dosage ps = new Dosage(Reader["id"].ToString(), Reader["serviceID"].ToString(), Reader["customerID"].ToString(), Reader["medication"].ToString(), Reader["dosage"].ToString(), Reader["route"].ToString(), Reader["freq"].ToString(), Reader["starting"].ToString(), Reader["dc"].ToString(), Reader["n"].ToString(), Reader["c"].ToString(), Reader["details"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
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
                    Dosage ps = new Dosage(Reader["id"].ToString(), Reader["serviceID"].ToString(), Reader["customerID"].ToString(), Reader["medication"].ToString(), Reader["dosage"].ToString(), Reader["route"].ToString(), Reader["freq"].ToString(), Reader["starting"].ToString(), Reader["dc"].ToString(), Reader["n"].ToString(), Reader["c"].ToString(), Reader["details"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;

        }
        private static Dosage m = new Dosage();
        public static Dosage Select(string customerID)
        {
            string Q = "SELECT * FROM customer WHERE id = '" + customerID + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                m = new Dosage(Reader["id"].ToString(), Reader["serviceID"].ToString(), Reader["customerID"].ToString(), Reader["medication"].ToString(), Reader["dosage"].ToString(), Reader["route"].ToString(), Reader["freq"].ToString(), Reader["starting"].ToString(), Reader["dc"].ToString(), Reader["n"].ToString(), Reader["c"].ToString(), Reader["details"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());

            }
            DBConnect.CloseConn();
            return m;

        }
    }

}

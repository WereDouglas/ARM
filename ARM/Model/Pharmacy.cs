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
    public class Pharmacy
    {
        private string id;
        private string serviceID;
        private string customerID;
        private string name;
        private string contact;
        private string address;
        private string npi;
        private string city;
        private string state;
        private string zip;            
        private string created;
        private string sync;
        private string companyID;      

        public Pharmacy() { }

        public Pharmacy(string id, string serviceID, string customerID, string name, string contact, string address, string npi, string city, string state, string zip, string created, string sync, string companyID)
        {
            this.Id = id;
            this.ServiceID = serviceID;
            this.CustomerID = customerID;
            this.Name = name;
            this.Contact = contact;
            this.Address = address;
            this.Npi = npi;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.Created = created;
            this.Sync = sync;
            this.CompanyID = companyID;
        }

        static List<Pharmacy> p = new List<Pharmacy>();

        public static List<Pharmacy> List()
        {
            p.Clear();
            string Q = "SELECT * FROM customer ";
            DBConnect.OpenConn();
            MySqlDataReader Reader = MySQL.Reading(Q);
            while (Reader.Read())
            {
                Pharmacy ps = new Pharmacy(Reader["id"].ToString(), Reader["serviceID"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["npi"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseMySqlConn();
            return p;

        }
        public static List<Pharmacy> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            MySqlDataReader Reader = MySQL.Reading(Q);
            while (Reader.Read())
            {
                Pharmacy ps = new Pharmacy(Reader["id"].ToString(), Reader["serviceID"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["npi"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseMySqlConn();
            return p;

        }
        public static List<Pharmacy> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = MySQL.Reading(Q);
                while (Reader.Read())
                {
                    Pharmacy ps = new Pharmacy(Reader["id"].ToString(), Reader["serviceID"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["npi"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;

        }
        private static Pharmacy c = new Pharmacy();

        public string Id { get => id; set => id = value; }
        public string ServiceID { get => serviceID; set => serviceID = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string Name { get => name; set => name = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Address { get => address; set => address = value; }
        public string Npi { get => npi; set => npi = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Zip { get => zip; set => zip = value; }
        public string Created { get => created; set => created = value; }
        public string Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }

        public static Pharmacy Select(string customerID)
        {
            string Q = "SELECT * FROM customer WHERE id = '" + customerID + "'";
            DBConnect.OpenConn();
            MySqlDataReader Reader = MySQL.Reading(Q);
            while (Reader.Read())
            {
                c = new Pharmacy(Reader["id"].ToString(), Reader["serviceID"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["npi"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
            }
            DBConnect.CloseMySqlConn();
            return c;

        }
    }

}

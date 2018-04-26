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

        public Dosage(string id, string name, string contact, string address, string no, string city, string state, string zip, string created, string ssn, string dob, string category,bool sync,string companyID, string image)
        {
            this.Id = id;
            this.Name = name;
            this.Contact = contact;
            this.Address = address;
            this.No = no;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.Created = created;
            this.Ssn = ssn;
            this.Dob = dob;
            this.Category = category;
            this.Sync = sync;
            this.CompanyID = companyID;
            this.Image = image;
        }

        static List<Dosage> p = new List<Dosage>();

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Address { get => address; set => address = value; }

        public string No { get => no; set => no = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Zip { get => zip; set => zip = value; }
        public string Created { get => created; set => created = value; }
        public string Ssn { get => ssn; set => ssn = value; }
        public string Dob { get => dob; set => dob = value; }
        public string Category { get => category; set => category = value; }
        public bool Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }
        public string Image { get => image; set => image = value; }
        public static List<Dosage> List()
        {
            p.Clear();
            string Q = "SELECT * FROM customer ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Dosage ps = new Dosage(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["ssn"].ToString(), Reader["dob"].ToString(), Reader["category"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());
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
                Dosage ps = new Dosage(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["ssn"].ToString(), Reader["dob"].ToString(), Reader["category"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());
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
                    Dosage ps = new Dosage(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["ssn"].ToString(), Reader["dob"].ToString(), Reader["category"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;

        }
        private static Dosage c = new Dosage();
        public static Dosage Select(string customerID)
        {
            string Q = "SELECT * FROM customer WHERE id = '" + customerID + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                c = new Dosage(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["ssn"].ToString(), Reader["dob"].ToString(), Reader["category"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());

            }
            DBConnect.CloseConn();
            return c;

        }
    }

}

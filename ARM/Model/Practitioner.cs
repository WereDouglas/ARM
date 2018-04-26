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
    public class Practitioner
    {
        private string id;
        private string name;
        private string customerID;
        private string contact;
        private string npi;//National Provider Identifier
        private string address;
        private string office;
        private string providerID;
        private string tin;
        private string officePhone;
        private string officeFax;
        private string city;
        private string zip;
        private string state;
        private string speciality;
        private string type;//participating //non participating
        private string created;       
        private bool sync;
        private string companyID;
        private string image;

        public Practitioner() { }

        public Practitioner(string id, string name, string contact, string address, string no, string city, string state, string zip, string created, string ssn, string dob, string category,bool sync,string companyID, string image)
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

        static List<Practitioner> p = new List<Practitioner>();

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
        public static List<Practitioner> List()
        {
            p.Clear();
            string Q = "SELECT * FROM customer ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Practitioner ps = new Practitioner(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["ssn"].ToString(), Reader["dob"].ToString(), Reader["category"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Practitioner> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Practitioner ps = new Practitioner(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["ssn"].ToString(), Reader["dob"].ToString(), Reader["category"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Practitioner> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Practitioner ps = new Practitioner(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["ssn"].ToString(), Reader["dob"].ToString(), Reader["category"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;

        }
        private static Practitioner c = new Practitioner();
        public static Practitioner Select(string customerID)
        {
            string Q = "SELECT * FROM customer WHERE id = '" + customerID + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                c = new Practitioner(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["ssn"].ToString(), Reader["dob"].ToString(), Reader["category"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());

            }
            DBConnect.CloseConn();
            return c;

        }
    }

}

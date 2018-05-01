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
    public class Company
    {
        private string id;
        private string name;       
        private string contact;
        private string email;
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
        private string created;
        private bool sync;
        private string companyID;
        private string image;

        static List<Company> p = new List<Company>();
        public Company() { }

        public Company(string id, string name, string contact, string email, string npi, string address, string office, string providerID, string tin, string officePhone, string officeFax, string city, string zip, string state, string speciality, string created, bool sync, string companyID, string image)
        {
            this.Id = id;
            this.Name = name;
            this.Contact = contact;
            this.Email = email;
            this.Npi = npi;
            this.Address = address;
            this.Office = office;
            this.ProviderID = providerID;
            this.Tin = tin;
            this.OfficePhone = officePhone;
            this.OfficeFax = officeFax;
            this.City = city;
            this.Zip = zip;
            this.State = state;
            this.Speciality = speciality;
            this.Created = created;
            this.Sync = sync;
            this.CompanyID = companyID;
            this.Image = image;
        }

        static Company c = new Company();

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Email { get => email; set => email = value; }
        public string Npi { get => npi; set => npi = value; }
        public string Address { get => address; set => address = value; }
        public string Office { get => office; set => office = value; }
        public string ProviderID { get => providerID; set => providerID = value; }
        public string Tin { get => tin; set => tin = value; }
        public string OfficePhone { get => officePhone; set => officePhone = value; }
        public string OfficeFax { get => officeFax; set => officeFax = value; }
        public string City { get => city; set => city = value; }
        public string Zip { get => zip; set => zip = value; }
        public string State { get => state; set => state = value; }
        public string Speciality { get => speciality; set => speciality = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }
        public string Image { get => image; set => image = value; }

        public static List<Company> List()
        {
            string Q = "SELECT * FROM company";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Company c = new Company(Reader["id"].ToString(),Reader["name"].ToString(), Reader["contact"].ToString(),Reader["email"].ToString(), Reader["npi"].ToString(), Reader["address"].ToString(), Reader["office"].ToString(), Reader["providerID"].ToString(), Reader["tin"].ToString(), Reader["officePhone"].ToString(), Reader["officeFax"].ToString(), Reader["city"].ToString(), Reader["zip"].ToString(), Reader["state"].ToString(), Reader["speciality"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());
                p.Add(c);
            }
            DBConnect.CloseConn();

            return p;
        }
        public static List<Company> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Company c = new Company(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["email"].ToString(), Reader["npi"].ToString(), Reader["address"].ToString(), Reader["office"].ToString(), Reader["providerID"].ToString(), Reader["tin"].ToString(), Reader["officePhone"].ToString(), Reader["officeFax"].ToString(), Reader["city"].ToString(), Reader["zip"].ToString(), Reader["state"].ToString(), Reader["speciality"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());
                p.Add(c);
            }
            DBConnect.CloseConn();
            return p;
        }
        public static List<Company> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Company ps = new Company(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["email"].ToString(), Reader["npi"].ToString(), Reader["address"].ToString(), Reader["office"].ToString(), Reader["providerID"].ToString(), Reader["tin"].ToString(), Reader["officePhone"].ToString(), Reader["officeFax"].ToString(), Reader["city"].ToString(), Reader["zip"].ToString(), Reader["state"].ToString(), Reader["speciality"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;

        }
        public static Company Select()
        {
           
            string Q = "SELECT * FROM company LIMIT 1";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                c = new Company(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["email"].ToString(), Reader["npi"].ToString(), Reader["address"].ToString(), Reader["office"].ToString(), Reader["providerID"].ToString(), Reader["tin"].ToString(), Reader["officePhone"].ToString(), Reader["officeFax"].ToString(), Reader["city"].ToString(), Reader["zip"].ToString(), Reader["state"].ToString(), Reader["speciality"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());
            }
            DBConnect.CloseConn();
            return c;

        }
    }
}
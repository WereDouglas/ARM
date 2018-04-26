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
    public class Vendor
    {
        private string id;
        private string name;
        private string email;
        private string contact;
        private string address;
        private string no;
        private string city;
        private string state;
        private string zip;
        private string created;
        private string category;
       private bool sync; private string companyID;
        private string image;
        public Vendor() { }
        public Vendor(string id, string name, string email, string contact, string address, string no, string city, string state, string zip, string created, string category,bool sync,string companyID, string image)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Contact = contact;
            this.Address = address;
            this.No = no;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.Created = created;
            this.Category = category;
            this.Sync = sync;
            this.CompanyID = companyID;
            this.Image = image;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Address { get => address; set => address = value; }
        public string No { get => no; set => no = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Zip { get => zip; set => zip = value; }
        public string Created { get => created; set => created = value; }
        public string Category { get => category; set => category = value; }
        public bool Sync { get => sync; set => sync = value; } public string CompanyID { get => companyID; set => companyID = value; }
        public string Image { get => image; set => image = value; }

        static List<Vendor> p = new List<Vendor>();
        public static List<Vendor> List()
        {
            p.Clear();
            string Q = "SELECT * FROM Vendor ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Vendor ps = new Vendor(Reader["id"].ToString(), Reader["name"].ToString(), Reader["email"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["category"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
        public static List<Vendor> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Vendor ps = new Vendor(Reader["id"].ToString(), Reader["name"].ToString(), Reader["email"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["category"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Vendor> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Vendor ps = new Vendor(Reader["id"].ToString(), Reader["name"].ToString(), Reader["email"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["category"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();

            }
            catch { }
            return p;

        }
        static Vendor c = new Vendor();
        public static Vendor Select(string vID)
        {
            string Q = "SELECT * FROM vendor WHERE id = '" + vID + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                c = new Vendor(Reader["id"].ToString(), Reader["name"].ToString(), Reader["email"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["category"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());

            }
            DBConnect.CloseConn();
            return c;

        }
    }

}

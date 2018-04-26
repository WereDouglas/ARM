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
    public class Emergency
    {
        private string id;
        private string customerID;
        private string name;
        private string contact;
        private string address;
        private string no;
        private string city;
        private string state;
        private string zip;
        private string gender;
        private string relationship;
        private string created;
        private bool sync;
        private string companyID;
        private string image;       

        static List<Emergency> p = new List<Emergency>();

        
        public static List<Emergency> List()
        {
            p.Clear();
            string Q = "SELECT * FROM emergency ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Emergency ps = new Emergency(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["ssn"].ToString(), Reader["dob"].ToString(), Reader["category"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Emergency> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Emergency ps = new Emergency(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["ssn"].ToString(), Reader["dob"].ToString(), Reader["category"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Emergency> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Emergency ps = new Emergency(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["ssn"].ToString(), Reader["dob"].ToString(), Reader["category"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;

        }
        private static Emergency c = new Emergency();

        public string Id { get => id; set => id = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string Name { get => name; set => name = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Address { get => address; set => address = value; }
        public string No { get => no; set => no = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Zip { get => zip; set => zip = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Relationship { get => relationship; set => relationship = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }
        public string Image { get => image; set => image = value; }
        public Emergency() { }
        public Emergency(string id, string customerID, string name, string contact, string address, string no, string city, string state, string zip, string gender, string relationship, string created, bool sync, string companyID, string image)
        {
            this.Id = id;
            this.CustomerID = customerID;
            this.Name = name;
            this.Contact = contact;
            this.Address = address;
            this.No = no;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.Gender = gender;
            this.Relationship = relationship;
            this.Created = created;
            this.Sync = sync;
            this.CompanyID = companyID;
            this.Image = image;
        }

        public static Emergency Select(string ID)
        {
            string Q = "SELECT * FROM emergency WHERE id = '" + ID + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                c = new Emergency(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["ssn"].ToString(), Reader["dob"].ToString(), Reader["category"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["image"].ToString());

            }
            DBConnect.CloseConn();
            return c;

        }
    }

}

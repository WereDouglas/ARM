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
    public class Users
    {
        private string id;
        private string name;
        private string email;
        private string contact;
        private string address;
        private string city;
        private string state;
        private string zip;
        private string category;
        private string gender;
        private string created;
       private bool sync;
        private string companyID;
        private string password;
        private string image;
        public Users() { }

        public Users(string id, string name, string email, string contact, string address, string city, string state, string zip, string category, string gender, string created,bool sync,string companyID, string password, string image)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Contact = contact;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.Category = category;
            this.Gender = gender;
            this.Created = created;
            this.Sync = sync;this.CompanyID = companyID;
            this.Password = password;
            this.Image = image;
        }

        static List<Users> p = new List<Users>();

        public static List<Users> List()
        {
            p.Clear();
            string Q = "SELECT * FROM users";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Users ps = new Users(Reader["id"].ToString(), Reader["name"].ToString(), Reader["email"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["category"].ToString(), Reader["gender"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["password"].ToString(), Reader["image"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Users> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Users ps = new Users(Reader["id"].ToString(), Reader["name"].ToString(), Reader["email"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["category"].ToString(), Reader["gender"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["password"].ToString(), Reader["image"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Users> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Users ps = new Users(Reader["id"].ToString(), Reader["name"].ToString(), Reader["email"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["category"].ToString(), Reader["gender"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["password"].ToString(), Reader["image"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
                
            }
            catch { }
            return p;

        }
        private static Users c = new Users();

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Zip { get => zip; set => zip = value; }
        public string Category { get => category; set => category = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; } public string CompanyID { get => companyID; set => companyID = value; }
        public string Password { get => password; set => password = value; }
        public string Image { get => image; set => image = value; }

        public static Users Select(string userID)
        {

            string Q = "SELECT * FROM users WHERE id = '" + userID + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                c = new Users(Reader["id"].ToString(), Reader["name"].ToString(), Reader["email"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["category"].ToString(), Reader["gender"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString(), Reader["password"].ToString(), Reader["image"].ToString());

            }
            DBConnect.CloseConn();
            return c;

        }
    }

}

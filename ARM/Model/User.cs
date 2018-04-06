using ARM.DB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
    public class User
    {
        private string id;
        private string name;
        private string contact;
        private string address;
        private string image;
        private string password;
        private string no;
        private string city;
        private string state;
        private string zip;
        private string category;
        private string gender;
        private string created;
        private bool sync;
        public User() { }

        public User(string id, string name, string contact, string address, string image, string password, string no, string city, string state, string zip, string category, string gender, string created, bool sync)
        {
            this.Id = id;
            this.Name = name;
            this.Contact = contact;
            this.Address = address;
            this.Image = image;
            this.Password = password;
            this.No = no;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.Category = category;
            this.Gender = gender;
            this.Created = created;
            this.Sync = sync;
        }

        static List<User> p = new List<User>();

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Address { get => address; set => address = value; }
        public string Image { get => image; set => image = value; }
        public string Password { get => password; set => password = value; }
        public string No { get => no; set => no = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Zip { get => zip; set => zip = value; }
        public string Category { get => category; set => category = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }

        public static List<User> List()
        {
            string Q = "SELECT * FROM User ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                User ps = new User(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["image"].ToString(), Reader["password"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["category"].ToString(), Reader["gender"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
    }

}

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
        private string address;
        private string contact;
        private string email;
        private string fax;
        private string tel;
        private string created;
        private bool sync;
        private string image;

        static List<Company> p = new List<Company>();
        public Company() { }

        public Company(string id, string name, string address, string contact, string email, string fax, string tel, string created, bool sync, string image)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Contact = contact;
            this.Email = email;
            this.Fax = fax;
            this.Tel = tel;
            this.Created = created;
            this.Sync = sync;
            this.Image = image;
        }

        static Company c = new Company();

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Email { get => email; set => email = value; }
        public string Fax { get => fax; set => fax = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }
        public string Image { get => image; set => image = value; }

        public static List<Company> List()
        {
            string Q = "SELECT * FROM company";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Company c = new Company(Reader["id"].ToString(), Reader["name"].ToString(), Reader["address"].ToString(), Reader["contact"].ToString(), Reader["email"].ToString(), Reader["fax"].ToString(), Reader["tel"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["image"].ToString());
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
                Company c = new Company(Reader["id"].ToString(), Reader["name"].ToString(), Reader["address"].ToString(), Reader["contact"].ToString(), Reader["email"].ToString(), Reader["fax"].ToString(), Reader["tel"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["image"].ToString());
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
                    Company ps = new Company(Reader["id"].ToString(), Reader["name"].ToString(), Reader["address"].ToString(), Reader["contact"].ToString(), Reader["email"].ToString(), Reader["fax"].ToString(), Reader["tel"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["image"].ToString());
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
                c = new Company(Reader["id"].ToString(), Reader["name"].ToString(), Reader["address"].ToString(), Reader["contact"].ToString(), Reader["email"].ToString(), Reader["fax"].ToString(), Reader["tel"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["image"].ToString());
            }
            DBConnect.CloseConn();
            return c;

        }
    }
}
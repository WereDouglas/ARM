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
    public class Insurance
    {
        private string id;
        private string customerID;
        private string name;
        private string type;
        private string image;
        private string no;
        private string address;
        private string contact;
        private string zip;
        private string created;
        private bool sync;
        public Insurance() { }

        public Insurance(string id, string customerID, string name, string type, string image, string no, string address, string contact, string zip, string created, bool sync)
        {
            this.Id = id;
            this.CustomerID = customerID;
            this.Name = name;
            this.Type = type;
            this.Image = image;
            this.No = no;
            this.Address = address;
            this.Contact = contact;
            this.Zip = zip;
            this.Created = created;
            this.Sync = sync;
        }

        static List<Insurance> p = new List<Insurance>();

        public string Id { get => id; set => id = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public string Image { get => image; set => image = value; }
        public string No { get => no; set => no = value; }
        public string Address { get => address; set => address = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Zip { get => zip; set => zip = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }

        public static List<Insurance> List()
        {
            p.Clear();
            string Q = "SELECT * FROM Insurance ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Insurance ps = new Insurance(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["image"].ToString(), Reader["no"].ToString(), Reader["address"].ToString(), Reader["contact"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Insurance> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Insurance ps = new Insurance(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["image"].ToString(), Reader["no"].ToString(), Reader["address"].ToString(), Reader["contact"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
        public static List<Insurance> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Insurance ps = new Insurance(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["image"].ToString(), Reader["no"].ToString(), Reader["address"].ToString(), Reader["contact"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;
        }
        static List<Insurance> c = new List<Insurance>();
        public static List<Insurance> Select(string id)
        {
            string Q = "SELECT * FROM insurance WHERE customerID = '" + id + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Insurance k = new Insurance(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["image"].ToString(), Reader["no"].ToString(), Reader["address"].ToString(), Reader["contact"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
                c.Add(k);
            }
            DBConnect.CloseConn();
            return c;

        }
    }

}

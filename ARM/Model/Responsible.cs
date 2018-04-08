using ARM.DB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
    public class Responsible
    {
        private string id;
        private string userID;
        private string customerID;           
        private string created;      
        private bool sync;
        public Responsible() { }

        public Responsible(string id, string userID, string customerID, string created, bool sync)
        {
            this.Id = id;
            this.UserID = userID;
            this.CustomerID = customerID;
            this.Created = created;
            this.Sync = sync;
        }

        static List<Responsible> p = new List<Responsible>();

        public string Id { get => id; set => id = value; }
        public string UserID { get => userID; set => userID = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }

        public static List<Responsible> List()
        {
            string Q = "SELECT * FROM Responsible ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Responsible ps = new Responsible(Reader["id"].ToString(), Reader["userID"].ToString(), Reader["customerID"].ToString(),Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
    }

}

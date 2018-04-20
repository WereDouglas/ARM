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
    public class Delivery
    {
        private string id;
        private string date;
        private string no;
        private string type;
        private string userID;
        private string customerID;
        private string comments;
        private string deliveredBy;
        private string dateReceived;
        private string receivedBy;
        private string signature;
        private double total;
        private string created;
        private bool sync;

        public Delivery() { }

        public Delivery(string id, string date, string no, string type, string userID, string customerID, string comments, string deliveredBy, string dateReceived, string receivedBy, string signature, double total, string created, bool sync)
        {
            this.Id = id;
            this.Date = date;
            this.No = no;
            this.Type = type;
            this.UserID = userID;
            this.CustomerID = customerID;
            this.Comments = comments;
            this.DeliveredBy = deliveredBy;
            this.DateReceived = dateReceived;
            this.ReceivedBy = receivedBy;
            this.Signature = signature;
            this.Total = total;
            this.Created = created;
            this.Sync = sync;
        }


        public string Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public string No { get => no; set => no = value; }
        public string Type { get => type; set => type = value; }
        public string UserID { get => userID; set => userID = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string Comments { get => comments; set => comments = value; }
        public string DeliveredBy { get => deliveredBy; set => deliveredBy = value; }
        public string DateReceived { get => dateReceived; set => dateReceived = value; }
        public string ReceivedBy { get => receivedBy; set => receivedBy = value; }
        public string Signature { get => signature; set => signature = value; }
        public double Total { get => total; set => total = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }
        static List<Delivery> p = new List<Delivery>();
        public static List<Delivery> List()
        {
            p.Clear();
            string Q = "SELECT * FROM Delivery ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Delivery ps = new Delivery(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["type"].ToString(), Reader["userID"].ToString(), Reader["customerID"].ToString(), Reader["comments"].ToString(), Reader["deliveredBy"].ToString(), Reader["dateReceived"].ToString(), Reader["receivedBy"].ToString(), Reader["signature"].ToString(), Convert.ToDouble(Reader["total"]), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
        public static List<Delivery> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Delivery ps = new Delivery(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["type"].ToString(), Reader["userID"].ToString(), Reader["customerID"].ToString(), Reader["comments"].ToString(), Reader["deliveredBy"].ToString(), Reader["dateReceived"].ToString(), Reader["receivedBy"].ToString(), Reader["signature"].ToString(), Convert.ToDouble(Reader["total"]), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
        public static List<Delivery> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Delivery ps = new Delivery(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["type"].ToString(), Reader["userID"].ToString(), Reader["customerID"].ToString(), Reader["comments"].ToString(), Reader["deliveredBy"].ToString(), Reader["dateReceived"].ToString(), Reader["receivedBy"].ToString(), Reader["signature"].ToString(), Convert.ToDouble(Reader["total"]), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;
        }
        private static Delivery c = new Delivery();
        public static Delivery Select(string ID)
        {

            string Q = "SELECT * FROM delivery WHERE id = '" + ID + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                c = new Delivery(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["type"].ToString(), Reader["userID"].ToString(), Reader["customerID"].ToString(), Reader["comments"].ToString(), Reader["deliveredBy"].ToString(), Reader["dateReceived"].ToString(), Reader["receivedBy"].ToString(), Reader["signature"].ToString(), Convert.ToDouble(Reader["total"]), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
            }
            DBConnect.CloseConn();
            return c;

        }
    }

}

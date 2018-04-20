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
    public class Follow
    {
        private string id;
        private string customerID;
        private string userID;
        private string itemID;
        private string type;
        private string diagnosis;
        private string hospitalisation;
        private string source;
        private string length;
        private string need;
        private string goal;
        private string results;
        private string recommend;
        private string followVisit;
        private string followPhone;
        private string next;
        private string pu;
        private string signature;
        private string authoriser;
        private string relationship;
        private string reason;
        private string created;
        private bool sync;
        public Follow() { }

        public Follow(string id, string customerID, string userID, string itemID, string type, string diagnosis, string hospitalisation, string source, string length, string need, string goal, string results, string recommend, string followVisit, string followPhone, string next, string pu, string signature, string authoriser, string relationship, string reason, string created, bool sync)
        {
            this.Id = id;
            this.CustomerID = customerID;
            this.UserID = userID;
            this.ItemID = itemID;
            this.Type = type;
            this.Diagnosis = diagnosis;
            this.Hospitalisation = hospitalisation;
            this.Source = source;
            this.Length = length;
            this.Need = need;
            this.Goal = goal;
            this.Results = results;
            this.Recommend = recommend;
            this.FollowVisit = followVisit;
            this.FollowPhone = followPhone;
            this.Next = next;
            this.Pu = pu;
            this.Signature = signature;
            this.Authoriser = authoriser;
            this.Relationship = relationship;
            this.Reason = reason;
            this.Created = created;
            this.Sync = sync;
        }

        static List<Follow> p = new List<Follow>();

        public string Id { get => id; set => id = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string UserID { get => userID; set => userID = value; }
        public string ItemID { get => itemID; set => itemID = value; }
        public string Type { get => type; set => type = value; }
        public string Diagnosis { get => diagnosis; set => diagnosis = value; }
        public string Hospitalisation { get => hospitalisation; set => hospitalisation = value; }
        public string Source { get => source; set => source = value; }
        public string Length { get => length; set => length = value; }
        public string Need { get => need; set => need = value; }
        public string Goal { get => goal; set => goal = value; }
        public string Results { get => results; set => results = value; }
        public string Recommend { get => recommend; set => recommend = value; }
        public string FollowVisit { get => followVisit; set => followVisit = value; }
        public string FollowPhone { get => followPhone; set => followPhone = value; }
        public string Next { get => next; set => next = value; }
        public string Pu { get => pu; set => pu = value; }
        public string Signature { get => signature; set => signature = value; }
        public string Authoriser { get => authoriser; set => authoriser = value; }
        public string Relationship { get => relationship; set => relationship = value; }
        public string Reason { get => reason; set => reason = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }

        public static List<Follow> List()
        {
            string Q = "SELECT * FROM Follow ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Follow ps = new Follow(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["userID"].ToString(), Reader["itemID"].ToString(), Reader["type"].ToString(), Reader["diagnosis"].ToString(), Reader["hospitalisation"].ToString(), Reader["source"].ToString(), Reader["length"].ToString(), Reader["need"].ToString(), Reader["goal"].ToString(), Reader["results"].ToString(), Reader["recommend"].ToString(), Reader["followVisit"].ToString(), Reader["followPhone"].ToString(), Reader["next"].ToString(), Reader["pu"].ToString(), Reader["signature"].ToString(), Reader["authoriser"].ToString(), Reader["relationship"].ToString(), Reader["reason"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Follow> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Follow ps = new Follow(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["userID"].ToString(), Reader["itemID"].ToString(), Reader["type"].ToString(), Reader["diagnosis"].ToString(), Reader["hospitalisation"].ToString(), Reader["source"].ToString(), Reader["length"].ToString(), Reader["need"].ToString(), Reader["goal"].ToString(), Reader["results"].ToString(), Reader["recommend"].ToString(), Reader["followVisit"].ToString(), Reader["followPhone"].ToString(), Reader["next"].ToString(), Reader["pu"].ToString(), Reader["signature"].ToString(), Reader["authoriser"].ToString(), Reader["relationship"].ToString(), Reader["reason"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Follow> ListOnline(string Q)
        {
            p.Clear();
            try
            {
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Follow ps = new Follow(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["userID"].ToString(), Reader["itemID"].ToString(), Reader["type"].ToString(), Reader["diagnosis"].ToString(), Reader["hospitalisation"].ToString(), Reader["source"].ToString(), Reader["length"].ToString(), Reader["need"].ToString(), Reader["goal"].ToString(), Reader["results"].ToString(), Reader["recommend"].ToString(), Reader["followVisit"].ToString(), Reader["followPhone"].ToString(), Reader["next"].ToString(), Reader["pu"].ToString(), Reader["signature"].ToString(), Reader["authoriser"].ToString(), Reader["relationship"].ToString(), Reader["reason"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;

        }
        static Follow c = new Follow();
        public static Follow Select(string id)
        {
            string Q = "SELECT * FROM follow WHERE id = '" + id + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                c = new Follow(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["userID"].ToString(), Reader["itemID"].ToString(), Reader["type"].ToString(), Reader["diagnosis"].ToString(), Reader["hospitalisation"].ToString(), Reader["source"].ToString(), Reader["length"].ToString(), Reader["need"].ToString(), Reader["goal"].ToString(), Reader["results"].ToString(), Reader["recommend"].ToString(), Reader["followVisit"].ToString(), Reader["followPhone"].ToString(), Reader["next"].ToString(), Reader["pu"].ToString(), Reader["signature"].ToString(), Reader["authoriser"].ToString(), Reader["relationship"].ToString(), Reader["reason"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));

            }
            DBConnect.CloseConn();
            return c;

        }
    }

}

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
    public class Account
    {
        private string id;
        private string userID;
        private string bank;
        private string accountNo;
        private string routing;
        private string created;
        private bool sync;
        private string companyID;
        public Account() { }

        public Account(string id, string userID, string bank, string accountNo, string routing, string created, bool sync,string companyID)
        {
            this.Id = id;
            this.UserID = userID;
            this.Bank = bank;
            this.AccountNo = accountNo;
            this.Routing = routing;
            this.Created = created;
            this.Sync = sync;
            this.CompanyID = companyID;
        }

        static List<Account> p = new List<Account>();

        public string Id { get => id; set => id = value; }
        public string UserID { get => userID; set => userID = value; }
        public string Bank { get => bank; set => bank = value; }
        public string AccountNo { get => accountNo; set => accountNo = value; }
        public string Routing { get => routing; set => routing = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; } public string CompanyID { get => companyID; set => companyID = value; }

        public static List<Account> List()
        {
            p.Clear();
            string Q = "SELECT * FROM Account ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Account ps = new Account(Reader["id"].ToString(), Reader["userID"].ToString(), Reader["bank"].ToString(), Reader["accountNo"].ToString(),Reader["routing"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Account> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Account ps = new Account(Reader["id"].ToString(), Reader["userID"].ToString(), Reader["bank"].ToString(), Reader["accountNo"].ToString(), Reader["routing"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Account> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Account ps = new Account(Reader["id"].ToString(), Reader["userID"].ToString(), Reader["bank"].ToString(), Reader["accountNo"].ToString(), Reader["routing"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
                return p;
            }
            catch
            {
                return p;

            }
           
        }
    }

}

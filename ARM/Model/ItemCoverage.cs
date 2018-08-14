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
    public class ItemCoverage
    {
        private string id;
        private string transactionID;
        private string itemID;
        private string coverageID;     
        private double percentage;
        private double amount;
        private string created;      
        private string sync;
        private string companyID;
        public ItemCoverage() { }

        public ItemCoverage(string id, string transactionID, string itemID, string coverageID, double percentage, double amount, string created, string sync, string companyID)
        {
            this.Id = id;
            this.CaseTransactionID = transactionID;
            this.ItemID = itemID;
            this.CoverageID = coverageID;
            this.Percentage = percentage;
            this.Amount = amount;
            this.Created = created;
            this.Sync = sync;
            this.CompanyID = companyID;
        }

        private static List<ItemCoverage> p = new List<ItemCoverage>();

        public string Id { get => id; set => id = value; }
        public string CaseTransactionID { get => transactionID; set => transactionID = value; }
        public string ItemID { get => itemID; set => itemID = value; }
        public string CoverageID { get => coverageID; set => coverageID = value; }
        public double Percentage { get => percentage; set => percentage = value; }
        public double Amount { get => amount; set => amount = value; }
        public string Created { get => created; set => created = value; }
        public string Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }

        public static List<ItemCoverage> List(string itemID,string transactionID)
        {
            p.Clear();
            string Q = "SELECT * FROM ItemCoverage WHERE itemID = '"+itemID+"' AND transactionID = '"+transactionID+"' ";
            DBConnect.OpenConn();
            MySqlDataReader Reader = MySQL.Reading(Q);
            while (Reader.Read())
            {
                ItemCoverage ps = new ItemCoverage(Reader["id"].ToString(), Reader["transactionID"].ToString(), Reader["itemID"].ToString(), Reader["coverage"].ToString(),Convert.ToDouble(Reader["percentage"]), Convert.ToDouble(Reader["amount"]), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseMySqlConn();
            return p;

        }
        public static List<ItemCoverage> List(string Q)
        {
            p.Clear();           
            DBConnect.OpenConn();
            MySqlDataReader Reader = MySQL.Reading(Q);
            while (Reader.Read())
            {
                ItemCoverage ps = new ItemCoverage(Reader["id"].ToString(), Reader["transactionID"].ToString(), Reader["itemID"].ToString(), Reader["coverage"].ToString(), Convert.ToDouble(Reader["percentage"]), Convert.ToDouble(Reader["amount"]), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseMySqlConn();
            return p;

        }
        public static List<ItemCoverage> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = MySQL.Reading(Q);
                while (Reader.Read())
                {
                    ItemCoverage ps = new ItemCoverage(Reader["id"].ToString(), Reader["transactionID"].ToString(), Reader["itemID"].ToString(), Reader["coverage"].ToString(), Convert.ToDouble(Reader["percentage"]), Convert.ToDouble(Reader["amount"]), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;

        }
        public static List<ItemCoverage> ListUpload(string Q)
        {
            p.Clear();
             
            DBConnect.OpenConn();
            MySqlDataReader Reader = MySQL.Reading(Q);
            while (Reader.Read())
            {
                ItemCoverage ps = new ItemCoverage(Reader["id"].ToString(), Reader["transactionID"].ToString(), Reader["itemID"].ToString(), Reader["coverage"].ToString(), Convert.ToDouble(Reader["percentage"]), Convert.ToDouble(Reader["amount"]), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseMySqlConn();
            return p;

        }

    }

}

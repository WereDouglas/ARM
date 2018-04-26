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
    public class Transaction
    {
        private string id;
        private string date;
        private string no;
        private string itemID;
        private string caseID;
        private double qty;
        private double cost;
        private string units;
        private double total;
        private string created;
        private bool sync;
        private string companyID;


        static List<Transaction> p = new List<Transaction>();

        public string Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public string No { get => no; set => no = value; }
        public string ItemID { get => itemID; set => itemID = value; }
        public string CaseID { get => caseID; set => caseID = value; }
        public double Qty { get => qty; set => qty = value; }
        public double Cost { get => cost; set => cost = value; }
        public string Units { get => units; set => units = value; }
        public double Total { get => total; set => total = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }

        public Transaction() { }

        public Transaction(string id, string date, string no, string itemID, string caseID, double qty, double cost, string units, double total, string created, bool sync, string companyID)
        {
            this.Id = id;
            this.Date = date;
            this.No = no;
            this.ItemID = itemID;
            this.CaseID = caseID;
            this.Qty = qty;
            this.Cost = cost;
            this.Units = units;
            this.Total = total;
            this.Created = created;
            this.Sync = sync;
            this.CompanyID = companyID;
        }

        public static List<Transaction> List()
        {
            p.Clear();
            string Q = "SELECT * FROM Transaction ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Transaction ps = new Transaction(Reader["id"].ToString(), Reader["date"].ToString(),Reader["no"].ToString(), Reader["itemID"].ToString(), Reader["caseID"].ToString(), Convert.ToDouble(Reader["qty"]), Convert.ToDouble(Reader["cost"]),Reader["units"].ToString(), Convert.ToDouble(Reader["total"]), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
        public static List<Transaction> ListNo(string no)
        {
            p.Clear();
            string Q = "SELECT * FROM Transaction WHERE no = '" + no + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Transaction ps = new Transaction(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["itemID"].ToString(), Reader["caseID"].ToString(), Convert.ToDouble(Reader["qty"]), Convert.ToDouble(Reader["cost"]), Reader["units"].ToString(), Convert.ToDouble(Reader["total"]), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
        public static List<Transaction> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Transaction ps = new Transaction(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["itemID"].ToString(), Reader["caseID"].ToString(), Convert.ToDouble(Reader["qty"]), Convert.ToDouble(Reader["cost"]), Reader["units"].ToString(), Convert.ToDouble(Reader["total"]), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
        public static List<Transaction> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Transaction ps = new Transaction(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["itemID"].ToString(), Reader["caseID"].ToString(), Convert.ToDouble(Reader["qty"]), Convert.ToDouble(Reader["cost"]), Reader["units"].ToString(), Convert.ToDouble(Reader["total"]), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;
        }
    }

}

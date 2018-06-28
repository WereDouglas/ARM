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
    public class Deduction
    {
        private string id;
        private string date;
        private string no;
        private string userID;
        private string category;     
        private string details;
        private double amount;
        private string paid;
        private string created;      
        private bool sync;
        private string companyID;
        public Deduction() { }

        public Deduction(string id, string date, string no, string userID, string category, string details, double amount, string paid, string created, bool sync, string companyID)
        {
            this.Id = id;
            this.Date = date;
            this.No = no;
            this.UserID = userID;
            this.Category = category;
            this.Details = details;
            this.Amount = amount;
            this.Paid = paid;
            this.Created = created;
            this.Sync = sync;
            this.CompanyID = companyID;
        }

        private static List<Deduction> p = new List<Deduction>();

        public string Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public string No { get => no; set => no = value; }
        public string UserID { get => userID; set => userID = value; }
        public string Category { get => category; set => category = value; }
        public string Details { get => details; set => details = value; }
        public double Amount { get => amount; set => amount = value; }
        public string Paid { get => paid; set => paid = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }
       

        public static List<Deduction> List(string Q)
        {
            try
            {
                p.Clear();
          //  string Q = "SELECT * FROM Deduction WHERE caseID = '"+caseID+"' ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Deduction ps = new Deduction(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["userID"].ToString(), Reader["category"].ToString(), Reader["details"].ToString(), Convert.ToDouble(Reader["amount"]), Reader["paid"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            }
            catch { }
            return p;

        }
        public static List<Deduction> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Deduction ps = new Deduction(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["userID"].ToString(), Reader["category"].ToString(), Reader["details"].ToString(), Convert.ToDouble(Reader["amount"]), Reader["paid"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;

        }
        public static List<Deduction> ListUpload(string Q)
        {
            p.Clear();
             
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Deduction ps = new Deduction(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["userID"].ToString(), Reader["category"].ToString(), Reader["details"].ToString(), Convert.ToDouble(Reader["amount"]), Reader["paid"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }

    }

}

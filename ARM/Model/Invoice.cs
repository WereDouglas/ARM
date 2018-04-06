using ARM.DB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
    public class Invoice
    {
        private string id;
        private string date;
        private string no;
        private string type;
        private string category;
        private string vendorID;
        private string customerID;
        private string method;        
        private string total;
        private string terms;
        private string tax;
        private string paid;
        private string balance;
        private string itemCount;
        private string userID;
        private string created;        
        private bool sync;

        public Invoice() { }

        public Invoice(string id, string date, string no, string type, string category, string vendorID, string customerID, string method, string total, string terms, string tax, string paid, string balance, string itemCount, string userID, string created, bool sync)
        {
            this.Id = id;
            this.Date = date;
            this.No = no;
            this.Type = type;
            this.Category = category;
            this.VendorID = vendorID;
            this.CustomerID = customerID;
            this.Method = method;
            this.Total = total;
            this.Terms = terms;
            this.Tax = tax;
            this.Paid = paid;
            this.Balance = balance;
            this.ItemCount = itemCount;
            this.UserID = userID;
            this.Created = created;
            this.Sync = sync;
        }

        static List<Invoice> p = new List<Invoice>();

        public string Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public string No { get => no; set => no = value; }
        public string Type { get => type; set => type = value; }
        public string Category { get => category; set => category = value; }
        public string VendorID { get => vendorID; set => vendorID = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string Method { get => method; set => method = value; }
        public string Total { get => total; set => total = value; }
        public string Terms { get => terms; set => terms = value; }
        public string Tax { get => tax; set => tax = value; }
        public string Paid { get => paid; set => paid = value; }
        public string Balance { get => balance; set => balance = value; }
        public string ItemCount { get => itemCount; set => itemCount = value; }
        public string UserID { get => userID; set => userID = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }

        public static List<Invoice> List()
        {
            string Q = "SELECT * FROM Invoice ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Invoice ps = new Invoice(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["type"].ToString(), Reader["category"].ToString(), Reader["vendorID"].ToString(), Reader["customerID"].ToString(), Reader["method"].ToString(), Reader["total"].ToString(), Reader["terms"].ToString(), Reader["tax"].ToString(), Reader["paid"].ToString(), Reader["balance"].ToString(), Reader["itemCount"].ToString(), Reader["userID"].ToString(), Reader["created"].ToString(),Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
    }

}

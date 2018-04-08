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
        private double total;
        private string terms;
        private double tax;
        private double paid;
        private double balance;
        private int itemCount;
        private string userID;
        private string created;        
        private bool sync;

        public Invoice() { }

        public Invoice(string id, string date, string no, string type, string category, string vendorID, string customerID, string method, double total, string terms, double tax, double paid, double balance, int itemCount, string userID, string created, bool sync)
        {
            this.id = id;
            this.date = date;
            this.no = no;
            this.type = type;
            this.category = category;
            this.vendorID = vendorID;
            this.customerID = customerID;
            this.method = method;
            this.total = total;
            this.terms = terms;
            this.tax = tax;
            this.paid = paid;
            this.balance = balance;
            this.itemCount = itemCount;
            this.userID = userID;
            this.created = created;
            this.sync = sync;
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
        public double Total { get => total; set => total = value; }
        public string Terms { get => terms; set => terms = value; }
        public double Tax { get => tax; set => tax = value; }
        public double Paid { get => paid; set => paid = value; }
        public double Balance { get => balance; set => balance = value; }
        public int ItemCount { get => itemCount; set => itemCount = value; }
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
                Invoice ps = new Invoice(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["type"].ToString(), Reader["category"].ToString(), Reader["vendorID"].ToString(), Reader["customerID"].ToString(), Reader["method"].ToString(), Convert.ToDouble(Reader["total"]), Reader["terms"].ToString(), Convert.ToDouble(Reader["tax"]), Convert.ToDouble(Reader["paid"]), Convert.ToDouble(Reader["balance"]),Convert.ToInt32( Reader["itemCount"]), Reader["userID"].ToString(), Reader["created"].ToString(),Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
    }

}

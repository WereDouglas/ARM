using ARM.DB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
    public class Payment
    {
        private string id;
        private string date;
        private string no;     
        private string type;
        private string method;
        private double amount;
        private double balance;       
        private string created;        
        private bool sync;

        public Payment() { }

        public Payment(string id, string date, string no, string type, string method, double amount, double balance, string created, bool sync)
        {
            this.Id = id;
            this.Date = date;
            this.No = no;
            this.Type = type;
            this.Method = method;
            this.Amount = amount;
            this.Balance = balance;
            this.Created = created;
            this.Sync = sync;
        }

        static List<Payment> p = new List<Payment>();

        public string Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public string No { get => no; set => no = value; }
        public string Type { get => type; set => type = value; }
        public string Method { get => method; set => method = value; }
        public double Amount { get => amount; set => amount = value; }
        public double Balance { get => balance; set => balance = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }

        public static List<Payment> List()
        {
            p.Clear();
            string Q = "SELECT * FROM Payment ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Payment ps = new Payment(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["type"].ToString(), Reader["method"].ToString(), Convert.ToDouble( Reader["amount"]), Convert.ToDouble(Reader["balance"]), Reader["created"].ToString(),Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
    }

}

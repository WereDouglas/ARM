using ARM.DB;
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
        private string total;       
        private string qty;
        private string cost;       
        private string created;        
        private bool sync;

        public Transaction() { }

        public Transaction(string id, string date, string no, string itemID, string total, string qty, string cost, string created, bool sync)
        {
            this.Id = id;
            this.Date = date;
            this.No = no;
            this.ItemID = itemID;
            this.Total = total;
            this.Qty = qty;
            this.Cost = cost;
            this.Created = created;
            this.Sync = sync;
        }

        static List<Transaction> p = new List<Transaction>();

        public string Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public string No { get => no; set => no = value; }
        public string ItemID { get => itemID; set => itemID = value; }
        public string Total { get => total; set => total = value; }
        public string Qty { get => qty; set => qty = value; }
        public string Cost { get => cost; set => cost = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }

        public static List<Transaction> List()
        {
            string Q = "SELECT * FROM Transaction ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Transaction ps = new Transaction(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["itemID"].ToString(), Reader["total"].ToString(), Reader["qty"].ToString(), Reader["cost"].ToString(),Reader["created"].ToString(),Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
    }

}

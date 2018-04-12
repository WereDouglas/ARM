using ARM.DB;
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
        private double bank;
        private double accountNo;           
        private string created;      
        private bool sync;
        public Account() { }

        public Account(string id, string userID, double bank, double accountNo, string created, bool sync)
        {
            this.Id = id;
            this.UserID = userID;
            this.Bank = bank;
            this.AccountNo = accountNo;
            this.Created = created;
            this.Sync = sync;
        }

        static List<Account> p = new List<Account>();

        public string Id { get => id; set => id = value; }
        public string UserID { get => userID; set => userID = value; }
        public double Bank { get => bank; set => bank = value; }
        public double AccountNo { get => accountNo; set => accountNo = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }

        public static List<Account> List()
        {
            p.Clear();
            string Q = "SELECT * FROM Account ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Account ps = new Account(Reader["id"].ToString(), Reader["userID"].ToString(), Convert.ToDouble(Reader["bank"]),Convert.ToDouble( Reader["accountNo"]),Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
    }

}

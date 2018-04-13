﻿using ARM.DB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
    public class Rate
    {
        private string id;
        private string userID;
        private double amount;
        private double period;
        private string units;        
        private string created;      
        private bool sync;
        public Rate() { }

        public Rate(string id, string userID, double amount, double period, string units, string created, bool sync)
        {
            this.Id = id;
            this.UserID = userID;
            this.Amount = amount;
            this.Period = period;
            this.Units = units;
            this.Created = created;
            this.Sync = sync;
        }

        static List<Rate> p = new List<Rate>();

        public string Id { get => id; set => id = value; }
        public string UserID { get => userID; set => userID = value; }
        public double Amount { get => amount; set => amount = value; }
        public double Period { get => period; set => period = value; }
        public string Units { get => units; set => units = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }

        public static List<Rate> List()
        {
            p.Clear();
            string Q = "SELECT * FROM Rate ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Rate ps = new Rate(Reader["id"].ToString(), Reader["userID"].ToString(), Convert.ToDouble(Reader["amount"]),Convert.ToDouble( Reader["period"]), Reader["units"].ToString(),Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
       static Rate c;
        public static Rate Select(string ID)
        {
            string Q = "SELECT * FROM rate WHERE userID = '" + ID + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                c = new Rate(Reader["id"].ToString(), Reader["userID"].ToString(),Convert.ToDouble( Reader["amount"]), Convert.ToDouble(Reader["period"]), Reader["units"].ToString(),Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));

            }
            DBConnect.CloseConn();
            return c;

        }
    }

}

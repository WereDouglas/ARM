﻿using ARM.DB;
using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
    public class Delivery
    {
        private string id;
        private string no;
        private string date;
        private string caseID;
        private string orderID;
        private string type;
        private string practitionerID;
        private string customerID;
        private string comments;
        private string deliveredBy;
        private string dateReceived;
        private string receivedBy;
        private string signature;
        private string reason;
        private string name;       
        private double total;
        private string created;
        private bool sync;
        private string companyID;

        public Delivery() { }

        public Delivery(string id, string no, string date, string caseID, string orderID, string type, string practitionerID, string customerID, string comments, string deliveredBy, string dateReceived, string receivedBy, string signature, string reason, string name, double total, string created, bool sync, string companyID)
        {
            this.Id = id;
            this.No = no;
            this.Date = date;
            this.CaseID = caseID;
            this.OrderID = orderID;
            this.Type = type;
            this.PractitionerID = practitionerID;
            this.CustomerID = customerID;
            this.Comments = comments;
            this.DeliveredBy = deliveredBy;
            this.DateReceived = dateReceived;
            this.ReceivedBy = receivedBy;
            this.Signature = signature;
            this.Reason = reason;
            this.Name = name;
            this.Total = total;
            this.Created = created;
            this.Sync = sync;
            this.CompanyID = companyID;
        }

        static List<Delivery> p = new List<Delivery>();
        public static List<Delivery> List()
        {
            p.Clear();
            string Q = "SELECT * FROM Delivery ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Delivery ps = new Delivery(Reader["id"].ToString(), Reader["no"].ToString(), Reader["date"].ToString(), Reader["caseID"].ToString(), Reader["orderID"].ToString(), Reader["type"].ToString(), Reader["practitionerID"].ToString(), Reader["customerID"].ToString(), Reader["comments"].ToString(), Reader["deliveredBy"].ToString(), Reader["dateReceived"].ToString(), Reader["receivedBy"].ToString(), Reader["signature"].ToString(), Reader["reason"].ToString(), Reader["name"].ToString(), Convert.ToDouble(Reader["total"]), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
        public static List<Delivery> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Delivery ps = new Delivery(Reader["id"].ToString(), Reader["no"].ToString(), Reader["date"].ToString(), Reader["caseID"].ToString(), Reader["orderID"].ToString(), Reader["type"].ToString(), Reader["practitionerID"].ToString(), Reader["customerID"].ToString(), Reader["comments"].ToString(), Reader["deliveredBy"].ToString(), Reader["dateReceived"].ToString(), Reader["receivedBy"].ToString(), Reader["signature"].ToString(), Reader["reason"].ToString(), Reader["name"].ToString(), Convert.ToDouble(Reader["total"]), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
        public static List<Delivery> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Delivery ps = new Delivery(Reader["id"].ToString(), Reader["no"].ToString(), Reader["date"].ToString(), Reader["caseID"].ToString(), Reader["orderID"].ToString(), Reader["type"].ToString(), Reader["practitionerID"].ToString(), Reader["customerID"].ToString(), Reader["comments"].ToString(), Reader["deliveredBy"].ToString(), Reader["dateReceived"].ToString(), Reader["receivedBy"].ToString(), Reader["signature"].ToString(), Reader["reason"].ToString(), Reader["name"].ToString(), Convert.ToDouble(Reader["total"]), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;
        }
        private static Delivery c = new Delivery();

        public string Id { get => id; set => id = value; }
        public string No { get => no; set => no = value; }
        public string Date { get => date; set => date = value; }
        public string CaseID { get => caseID; set => caseID = value; }
        public string OrderID { get => orderID; set => orderID = value; }
        public string Type { get => type; set => type = value; }
        public string PractitionerID { get => practitionerID; set => practitionerID = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string Comments { get => comments; set => comments = value; }
        public string DeliveredBy { get => deliveredBy; set => deliveredBy = value; }
        public string DateReceived { get => dateReceived; set => dateReceived = value; }
        public string ReceivedBy { get => receivedBy; set => receivedBy = value; }
        public string Signature { get => signature; set => signature = value; }
        public string Reason { get => reason; set => reason = value; }
        public string Name { get => name; set => name = value; }
        public double Total { get => total; set => total = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }

        public static Delivery Select(string ID)
        {

            string Q = "SELECT * FROM delivery WHERE id = '" + ID + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                c = new Delivery(Reader["id"].ToString(), Reader["no"].ToString(), Reader["date"].ToString(), Reader["caseID"].ToString(), Reader["orderID"].ToString(), Reader["type"].ToString(), Reader["practitionerID"].ToString(), Reader["customerID"].ToString(), Reader["comments"].ToString(), Reader["deliveredBy"].ToString(), Reader["dateReceived"].ToString(), Reader["receivedBy"].ToString(), Reader["signature"].ToString(), Reader["reason"].ToString(), Reader["name"].ToString(), Convert.ToDouble(Reader["total"]), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
            }
            DBConnect.CloseConn();
            return c;

        }
    }

}

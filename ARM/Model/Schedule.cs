using ARM.DB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
  public class Schedule
    {
        private string id;
        private string customerID;
        private string userID;
        private string starts;
        private string ends;
        private string location;
        private string address;        
        private string details;       
        private string indicator;
        private string period;
        private string category;//appointment or shift 
        private string status;
        private string created;
        private bool sync;

      
        public Schedule() { }

        public Schedule(string id, string customerID, string userID, string starts, string ends, string location, string address, string details, string indicator, string period, string category, string status, string created, bool sync)
        {
            this.Id = id;
            this.CustomerID = customerID;
            this.UserID = userID;
            this.Starts = starts;
            this.Ends = ends;
            this.Location = location;
            this.Address = address;
            this.Details = details;
            this.Indicator = indicator;
            this.Period = period;
            this.Category = category;
            this.Status = status;
            this.Created = created;
            this.Sync = sync;
        }

        public string Id { get => id; set => id = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string UserID { get => userID; set => userID = value; }
        public string Starts { get => starts; set => starts = value; }
        public string Ends { get => ends; set => ends = value; }
        public string Location { get => location; set => location = value; }
        public string Address { get => address; set => address = value; }
        public string Details { get => details; set => details = value; }
        public string Indicator { get => indicator; set => indicator = value; }
        public string Period { get => period; set => period = value; }
        public string Category { get => category; set => category = value; }
        public string Status { get => status; set => status = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }
        static List<Schedule> p = new List<Schedule>();
        public static List<Schedule> List()
        {
            string Q = "SELECT * FROM Schedule ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Schedule ps = new Schedule(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["userID"].ToString(), Reader["starts"].ToString(), Reader["ends"].ToString(), Reader["location"].ToString(), Reader["address"].ToString(), Reader["details"].ToString(), Reader["indicator"].ToString(), Reader["period"].ToString(), Reader["category"].ToString(), Reader["status"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
    }
}

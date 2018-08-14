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
    public class Orders
    {
        private string id;
        private string no;
        private string customerID;
        private string userID;        
        private string orderDate;
		private string orderTime;
		private string orderBy;
        private string dispenseDate;
		private string dispenseTime;
		private string dispenseBy;
        private string customerType;
        private string diagnosis;
        private string surgery;
        private string clinicalDate;        
        private string instructions;
		private string hospital;
		private string home;
		private string preopRm;
		private string preopHome;
		private string postopRm;
		private string roomNo;
		private string setupDate;
		private string dateNeeded;
		private string facility;
		private string clinic;
		private string other;
		private string notified;
		private string authorised;
		private string insurance;
		private string contacted;
		private string sent;
		private string returned;
		private string dateSent;
		private string dateReturned;
        private string practitionerID;        
        private string created;
        private string sync;
        private string companyID;
        public Orders() { }

		public Orders(string id, string no, string customerID, string userID, string orderDate, string orderTime, string orderBy, string dispenseDate, string dispenseTime, string dispenseBy, string customerType, string diagnosis, string surgery, string clinicalDate, string instructions, string hospital, string home, string preopRm, string preopHome, string postopRm, string roomNo, string setupDate, string dateNeeded, string facility, string clinic, string other, string notified, string authorised, string insurance, string contacted, string sent, string returned, string dateSent, string dateReturned, string practitionerID, string created, string sync, string companyID)
		{
			this.Id = id;
			this.No = no;
			this.CustomerID = customerID;
			this.UserID = userID;
			this.OrderDate = orderDate;
			this.OrderTime = orderTime;
			this.OrderBy = orderBy;
			this.DispenseDate = dispenseDate;
			this.DispenseTime = dispenseTime;
			this.DispenseBy = dispenseBy;
			this.CustomerType = customerType;
			this.Diagnosis = diagnosis;
			this.Surgery = surgery;
			this.ClinicalDate = clinicalDate;
			this.Instructions = instructions;
			this.Hospital = hospital;
			this.Home = home;
			this.PreopRm = preopRm;
			this.PreopHome = preopHome;
			this.PostopRm = postopRm;
			this.RoomNo = roomNo;
			this.SetupDate = setupDate;
			this.DateNeeded = dateNeeded;
			this.Facility = facility;
			this.Clinic = clinic;
			this.Other = other;
			this.Notified = notified;
			this.Authorised = authorised;
			this.Insurance = insurance;
			this.Contacted = contacted;
			this.Sent = sent;
			this.Returned = returned;
			this.DateSent = dateSent;
			this.DateReturned = dateReturned;
			this.PractitionerID = practitionerID;
			this.Created = created;
			this.Sync = sync;
			this.CompanyID = companyID;
		}

		static List<Orders> p = new List<Orders>();
        public static List<Orders> List()
        {
            p.Clear();
            string Q = "SELECT * FROM orders ";
           
            MySqlDataReader Reader = MySQL.Reading(Q);
            while (Reader.Read())
            {
                Orders ps = new Orders(Reader["id"].ToString(), Reader["no"].ToString(), Reader["customerID"].ToString(), Reader["userID"].ToString(), Reader["orderDate"].ToString(), Reader["orderTime"].ToString(), Reader["orderBy"].ToString(), Reader["dispenseDate"].ToString(), Reader["dispenseTime"].ToString(), Reader["dispenseBy"].ToString(), Reader["customerType"].ToString(), Reader["diagnosis"].ToString(), Reader["surgery"].ToString(), Reader["clinicalDate"].ToString(),Reader["instructions"].ToString(), Reader["hospital"].ToString(), Reader["home"].ToString(), Reader["preopRm"].ToString(), Reader["preopHome"].ToString(), Reader["postopRm"].ToString(),Reader["roomNo"].ToString(), Reader["setupDate"].ToString(), Reader["dateNeeded"].ToString(), Reader["facility"].ToString(), Reader["clinic"].ToString(), Reader["other"].ToString(), Reader["notified"].ToString(), Reader["authorised"].ToString(), Reader["insurance"].ToString(), Reader["contacted"].ToString(), Reader["sent"].ToString(), Reader["returned"].ToString(), Reader["dateSent"].ToString(), Reader["dateReturned"].ToString(), Reader["practitionerID"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());

                p.Add(ps);
            }
            DBConnect.CloseMySqlConn();
            return p;
        }
        public static List<Orders> List(string Q)
        {
            p.Clear();
          
            MySqlDataReader Reader = MySQL.Reading(Q);
            while (Reader.Read())
            {
                Orders ps = new Orders(Reader["id"].ToString(), Reader["no"].ToString(), Reader["customerID"].ToString(), Reader["userID"].ToString(), Reader["orderDate"].ToString(), Reader["orderTime"].ToString(), Reader["orderBy"].ToString(), Reader["dispenseDate"].ToString(), Reader["dispenseTime"].ToString(), Reader["dispenseBy"].ToString(), Reader["customerType"].ToString(), Reader["diagnosis"].ToString(), Reader["surgery"].ToString(), Reader["clinicalDate"].ToString(), Reader["instructions"].ToString(), Reader["hospital"].ToString(), Reader["home"].ToString(), Reader["preopRm"].ToString(), Reader["preopHome"].ToString(), Reader["postopRm"].ToString(), Reader["roomNo"].ToString(), Reader["setupDate"].ToString(), Reader["dateNeeded"].ToString(), Reader["facility"].ToString(), Reader["clinic"].ToString(), Reader["other"].ToString(), Reader["notified"].ToString(), Reader["authorised"].ToString(), Reader["insurance"].ToString(), Reader["contacted"].ToString(), Reader["sent"].ToString(), Reader["returned"].ToString(), Reader["dateSent"].ToString(), Reader["dateReturned"].ToString(), Reader["practitionerID"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());

				p.Add(ps);
            }
            DBConnect.CloseMySqlConn();
            return p;
        }
		static MySqlDataReader Reader = null;
		public static List<Orders> ListOnline(string Q)
        {
			p.Clear();
			//       try
			//       {
			//                    
			//           MySqlDataReader Reader = MySQL.Reading(Q);
			//           while (Reader.Read())
			//           {
			//               Orders ps = new Orders(Reader["id"].ToString(), Reader["no"].ToString(), Reader["customerID"].ToString(), Reader["userID"].ToString(), Reader["orderDate"].ToString(), Reader["orderTime"].ToString(), Reader["orderBy"].ToString(), Reader["dispenseDate"].ToString(), Reader["dispenseTime"].ToString(), Reader["dispenseBy"].ToString(), Reader["customerType"].ToString(), Reader["diagnosis"].ToString(), Reader["surgery"].ToString(), Reader["clinicalDate"].ToString(), Reader["instructions"].ToString(), Reader["hospital"].ToString(), Reader["home"].ToString(), Reader["preopRm"].ToString(), Reader["preopHome"].ToString(), Reader["postopRm"].ToString(), Reader["roomNo"].ToString(), Reader["setupDate"].ToString(), Reader["dateNeeded"].ToString(), Reader["facility"].ToString(), Reader["clinic"].ToString(), Reader["other"].ToString(), Reader["notified"].ToString(), Reader["authorised"].ToString(), Reader["insurance"].ToString(), Reader["contacted"].ToString(), Reader["sent"].ToString(), Reader["returned"].ToString(), Reader["dateSent"].ToString(), Reader["dateReturned"].ToString(), Reader["practitionerID"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
			//p.Add(ps);
			//           }
			//           DBConnect.CloseMySqlConn();
			//       }
			//       catch { }

			Reader = MySQL.Reading(Q);
			p = MySQL.DataReaderMapToList<Orders>(Reader);
			return p;
        }
        private static Orders c = new Orders();

		public string Id { get => id; set => id = value; }
		public string No { get => no; set => no = value; }
		public string CustomerID { get => customerID; set => customerID = value; }
		public string UserID { get => userID; set => userID = value; }
		public string OrderDate { get => orderDate; set => orderDate = value; }
		public string OrderTime { get => orderTime; set => orderTime = value; }
		public string OrderBy { get => orderBy; set => orderBy = value; }
		public string DispenseDate { get => dispenseDate; set => dispenseDate = value; }
		public string DispenseTime { get => dispenseTime; set => dispenseTime = value; }
		public string DispenseBy { get => dispenseBy; set => dispenseBy = value; }
		public string CustomerType { get => customerType; set => customerType = value; }
		public string Diagnosis { get => diagnosis; set => diagnosis = value; }
		public string Surgery { get => surgery; set => surgery = value; }
		public string ClinicalDate { get => clinicalDate; set => clinicalDate = value; }
		public string Instructions { get => instructions; set => instructions = value; }
		public string Hospital { get => hospital; set => hospital = value; }
		public string Home { get => home; set => home = value; }
		public string PreopRm { get => preopRm; set => preopRm = value; }
		public string PreopHome { get => preopHome; set => preopHome = value; }
		public string PostopRm { get => postopRm; set => postopRm = value; }
		public string RoomNo { get => roomNo; set => roomNo = value; }
		public string SetupDate { get => setupDate; set => setupDate = value; }
		public string DateNeeded { get => dateNeeded; set => dateNeeded = value; }
		public string Facility { get => facility; set => facility = value; }
		public string Clinic { get => clinic; set => clinic = value; }
		public string Other { get => other; set => other = value; }
		public string Notified { get => notified; set => notified = value; }
		public string Authorised { get => authorised; set => authorised = value; }
		public string Insurance { get => insurance; set => insurance = value; }
		public string Contacted { get => contacted; set => contacted = value; }
		public string Sent { get => sent; set => sent = value; }
		public string Returned { get => returned; set => returned = value; }
		public string DateSent { get => dateSent; set => dateSent = value; }
		public string DateReturned { get => dateReturned; set => dateReturned = value; }
		public string PractitionerID { get => practitionerID; set => practitionerID = value; }
		public string Created { get => created; set => created = value; }
		public string Sync { get => sync; set => sync = value; }
		public string CompanyID { get => companyID; set => companyID = value; }

		public static Orders Select(string ID)
		{
			string Q = "SELECT * FROM orders WHERE  id = '" + ID + "'";
		
			MySqlDataReader Reader = MySQL.Reading(Q);
			while (Reader.Read())
			{
				c = new Orders(Reader["id"].ToString(), Reader["no"].ToString(), Reader["customerID"].ToString(), Reader["userID"].ToString(), Reader["orderDate"].ToString(), Reader["orderTime"].ToString(), Reader["orderBy"].ToString(), Reader["dispenseDate"].ToString(), Reader["dispenseTime"].ToString(), Reader["dispenseBy"].ToString(), Reader["customerType"].ToString(), Reader["diagnosis"].ToString(), Reader["surgery"].ToString(), Reader["clinicalDate"].ToString(), Reader["instructions"].ToString(), Reader["hospital"].ToString(), Reader["home"].ToString(), Reader["preopRm"].ToString(), Reader["preopHome"].ToString(), Reader["postopRm"].ToString(), Reader["roomNo"].ToString(), Reader["setupDate"].ToString(), Reader["dateNeeded"].ToString(), Reader["facility"].ToString(), Reader["clinic"].ToString(), Reader["other"].ToString(), Reader["notified"].ToString(), Reader["authorised"].ToString(), Reader["insurance"].ToString(), Reader["contacted"].ToString(), Reader["sent"].ToString(), Reader["returned"].ToString(), Reader["dateSent"].ToString(), Reader["dateReturned"].ToString(), Reader["practitionerID"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());

			}
			DBConnect.CloseMySqlConn();			
			return c;
		
        }
		public static Orders SelectNo(string no)
		{
			string Q = "SELECT * FROM orders WHERE  no = '" + no + "'";
			
			MySqlDataReader Reader = MySQL.Reading(Q);
			while (Reader.Read())
			{
				c = new Orders(Reader["id"].ToString(), Reader["no"].ToString(), Reader["customerID"].ToString(), Reader["userID"].ToString(), Reader["orderDate"].ToString(), Reader["orderTime"].ToString(), Reader["orderBy"].ToString(), Reader["dispenseDate"].ToString(), Reader["dispenseTime"].ToString(), Reader["dispenseBy"].ToString(), Reader["customerType"].ToString(), Reader["diagnosis"].ToString(), Reader["surgery"].ToString(), Reader["clinicalDate"].ToString(), Reader["instructions"].ToString(), Reader["hospital"].ToString(), Reader["home"].ToString(), Reader["preopRm"].ToString(), Reader["preopHome"].ToString(), Reader["postopRm"].ToString(), Reader["roomNo"].ToString(), Reader["setupDate"].ToString(), Reader["dateNeeded"].ToString(), Reader["facility"].ToString(), Reader["clinic"].ToString(), Reader["other"].ToString(), Reader["notified"].ToString(), Reader["authorised"].ToString(), Reader["insurance"].ToString(), Reader["contacted"].ToString(), Reader["sent"].ToString(), Reader["returned"].ToString(), Reader["dateSent"].ToString(), Reader["dateReturned"].ToString(), Reader["practitionerID"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
			}
			DBConnect.CloseMySqlConn();
			return c;

		}
	}


}

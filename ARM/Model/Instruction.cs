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
    public class Instruction
    {
        private string id;
		private string no;
		private string customerID;
		private string altContact;
		private string date;
		private string initial;
		private string followup;
		private string type;
		private string delivered;		
        private string safety;
        private string pathways;
        private string operation;		
		private string environment;
		private string rugs;		
        private string fire;
        private string cord;
        private string issues;
        private string electrical;
        private string inouts;
		private string appropriate;
		private string understand;
		private string returns;
		private string caregiver;
		private string safetyOther;
		private string physicalLimit;
		private string ambulatory;
		private string bath;
		private string beds;
		private string seat;
		private string scooter;
		private string manual;
		private string power;
		private string handling;
		private string equipmentOther;
		private string rights;
		private string available;
		private string privacy;
		private string standards;
		private string demonstration;
		private string cleaning;
		private string letter;
		private string complaint;
		private string warranty;
		private string instructions;
		private string aob;
		private string notes;
		private string visit;
		private string phone;
		private string patientSign;
		private string employee;
		private string employeeSign;
		private string kinName;
		private string otherSign;
		private string kinContact;
		private string relationship;
		private string representative;
        private string reason;
        private string userSignature;
        private string created;
        private string sync;
        private string companyID;
		private string userID;

		private static Instruction c = new Instruction();       

		public Instruction() { }

		public Instruction(string id, string no, string customerID, string altContact, string date, string initial, string followup, string type, string delivered, string safety, string pathways, string operation, string environment, string rugs, string fire, string cord, string issues, string electrical, string inouts, string appropriate, string understand, string returns, string caregiver, string safetyOther, string physicalLimit, string ambulatory, string bath, string beds, string seat, string scooter, string manual, string power, string handling, string equipmentOther, string rights, string available, string privacy, string standards, string demonstration, string cleaning, string letter, string complaint, string warranty, string instructions, string aob, string notes, string visit, string phone, string patientSign, string employee, string employeeSign, string kinName, string otherSign, string kinContact, string relationship, string representative, string reason, string userSignature, string created, string sync, string companyID, string userID)
		{
			this.Id = id;
			this.No = no;
			this.CustomerID = customerID;
			this.AltContact = altContact;
			this.Date = date;
			this.Initial = initial;
			this.Followup = followup;
			this.Type = type;
			this.Delivered = delivered;
			this.Safety = safety;
			this.Pathways = pathways;
			this.Operation = operation;
			this.Environment = environment;
			this.Rugs = rugs;
			this.Fire = fire;
			this.Cord = cord;
			this.Issues = issues;
			this.Electrical = electrical;
			this.Inouts = inouts;
			this.Appropriate = appropriate;
			this.Understand = understand;
			this.Returns = returns;
			this.Caregiver = caregiver;
			this.SafetyOther = safetyOther;
			this.PhysicalLimit = physicalLimit;
			this.Ambulatory = ambulatory;
			this.Bath = bath;
			this.Beds = beds;
			this.Seat = seat;
			this.Scooter = scooter;
			this.Manual = manual;
			this.Power = power;
			this.Handling = handling;
			this.EquipmentOther = equipmentOther;
			this.Rights = rights;
			this.Available = available;
			this.Privacy = privacy;
			this.Standards = standards;
			this.Demonstration = demonstration;
			this.Cleaning = cleaning;
			this.Letter = letter;
			this.Complaint = complaint;
			this.Warranty = warranty;
			this.Instructions = instructions;
			this.Aob = aob;
			this.Notes = notes;
			this.Visit = visit;
			this.Phone = phone;
			this.PatientSign = patientSign;
			this.Employee = employee;
			this.EmployeeSign = employeeSign;
			this.KinName = kinName;
			this.OtherSign = otherSign;
			this.KinContact = kinContact;
			this.Relationship = relationship;
			this.Representative = representative;
			this.Reason = reason;
			this.UserSignature = userSignature;
			this.Created = created;
			this.Sync = sync;
			this.CompanyID = companyID;
			this.UserID = userID;
		}

		static List<Instruction> p = new List<Instruction>();

		public string Id { get => id; set => id = value; }
		public string No { get => no; set => no = value; }
		public string CustomerID { get => customerID; set => customerID = value; }
		public string AltContact { get => altContact; set => altContact = value; }
		public string Date { get => date; set => date = value; }
		public string Initial { get => initial; set => initial = value; }
		public string Followup { get => followup; set => followup = value; }
		public string Type { get => type; set => type = value; }
		public string Delivered { get => delivered; set => delivered = value; }
		public string Safety { get => safety; set => safety = value; }
		public string Pathways { get => pathways; set => pathways = value; }
		public string Operation { get => operation; set => operation = value; }
		public string Environment { get => environment; set => environment = value; }
		public string Rugs { get => rugs; set => rugs = value; }
		public string Fire { get => fire; set => fire = value; }
		public string Cord { get => cord; set => cord = value; }
		public string Issues { get => issues; set => issues = value; }
		public string Electrical { get => electrical; set => electrical = value; }
		public string Inouts { get => inouts; set => inouts = value; }
		public string Appropriate { get => appropriate; set => appropriate = value; }
		public string Understand { get => understand; set => understand = value; }
		public string Returns { get => returns; set => returns = value; }
		public string Caregiver { get => caregiver; set => caregiver = value; }
		public string SafetyOther { get => safetyOther; set => safetyOther = value; }
		public string PhysicalLimit { get => physicalLimit; set => physicalLimit = value; }
		public string Ambulatory { get => ambulatory; set => ambulatory = value; }
		public string Bath { get => bath; set => bath = value; }
		public string Beds { get => beds; set => beds = value; }
		public string Seat { get => seat; set => seat = value; }
		public string Scooter { get => scooter; set => scooter = value; }
		public string Manual { get => manual; set => manual = value; }
		public string Power { get => power; set => power = value; }
		public string Handling { get => handling; set => handling = value; }
		public string EquipmentOther { get => equipmentOther; set => equipmentOther = value; }
		public string Rights { get => rights; set => rights = value; }
		public string Available { get => available; set => available = value; }
		public string Privacy { get => privacy; set => privacy = value; }
		public string Standards { get => standards; set => standards = value; }
		public string Demonstration { get => demonstration; set => demonstration = value; }
		public string Cleaning { get => cleaning; set => cleaning = value; }
		public string Letter { get => letter; set => letter = value; }
		public string Complaint { get => complaint; set => complaint = value; }
		public string Warranty { get => warranty; set => warranty = value; }
		public string Instructions { get => instructions; set => instructions = value; }
		public string Aob { get => aob; set => aob = value; }
		public string Notes { get => notes; set => notes = value; }
		public string Visit { get => visit; set => visit = value; }
		public string Phone { get => phone; set => phone = value; }
		public string PatientSign { get => patientSign; set => patientSign = value; }
		public string Employee { get => employee; set => employee = value; }
		public string EmployeeSign { get => employeeSign; set => employeeSign = value; }
		public string KinName { get => kinName; set => kinName = value; }
		public string OtherSign { get => otherSign; set => otherSign = value; }
		public string KinContact { get => kinContact; set => kinContact = value; }
		public string Relationship { get => relationship; set => relationship = value; }
		public string Representative { get => representative; set => representative = value; }
		public string Reason { get => reason; set => reason = value; }
		public string UserSignature { get => userSignature; set => userSignature = value; }
		public string Created { get => created; set => created = value; }
		public string Sync { get => sync; set => sync = value; }
		public string CompanyID { get => companyID; set => companyID = value; }
		public string UserID { get => userID; set => userID = value; }

		public static List<Instruction> List()
        {
            p.Clear();
            string Q = "SELECT * FROM instruction ";
            DBConnect.OpenConn();
            MySqlDataReader Reader = MySQL.Reading(Q);
            while (Reader.Read())
            {
                Instruction ps = new Instruction(Reader["id"].ToString(), Reader["no"].ToString(), Reader["customerID"].ToString(), Reader["altContact"].ToString(), Reader["date"].ToString(), Reader["initial"].ToString(), Reader["followup"].ToString(), Reader["type"].ToString(), Reader["delivered"].ToString(), Reader["safety"].ToString(), Reader["pathways"].ToString(), Reader["operation"].ToString(), Reader["environment"].ToString(), Reader["rugs"].ToString(), Reader["fire"].ToString(), Reader["cord"].ToString(), Reader["issues"].ToString(), Reader["electrical"].ToString(), Reader["inouts"].ToString(), Reader["appropriate"].ToString(), Reader["understand"].ToString(), Reader["returns"].ToString(), Reader["caregiver"].ToString(), Reader["safetyOther"].ToString(),Reader["physicallimit"].ToString(), Reader["ambulatory"].ToString(), Reader["bath"].ToString(), Reader["beds"].ToString(), Reader["seat"].ToString(), Reader["scooter"].ToString(), Reader["manual"].ToString(), Reader["power"].ToString(), Reader["handling"].ToString(), Reader["equipmentOther"].ToString(), Reader["rights"].ToString(), Reader["available"].ToString(), Reader["privacy"].ToString(), Reader["standards"].ToString(), Reader["demonstration"].ToString(), Reader["cleaning"].ToString(), Reader["letter"].ToString(), Reader["complaint"].ToString(), Reader["warranty"].ToString(), Reader["instructions"].ToString(), Reader["aob"].ToString(), Reader["notes"].ToString(), Reader["visit"].ToString(), Reader["phone"].ToString(), Reader["patientSign"].ToString(), Reader["employee"].ToString(), Reader["employeeSign"].ToString(), Reader["kinName"].ToString(), Reader["otherSign"].ToString(), Reader["kinContact"].ToString(), Reader["relationship"].ToString(), Reader["representative"].ToString(), Reader["reason"].ToString(), Reader["userSignature"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(),Reader["userID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseMySqlConn();
            return p;

        }
        public static List<Instruction> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            MySqlDataReader Reader = MySQL.Reading(Q);
            while (Reader.Read())
            {
                Instruction ps = new Instruction(Reader["id"].ToString(), Reader["no"].ToString(), Reader["customerID"].ToString(), Reader["altContact"].ToString(), Reader["date"].ToString(), Reader["initial"].ToString(), Reader["followup"].ToString(), Reader["type"].ToString(), Reader["delivered"].ToString(), Reader["safety"].ToString(), Reader["pathways"].ToString(), Reader["operation"].ToString(), Reader["environment"].ToString(), Reader["rugs"].ToString(), Reader["fire"].ToString(), Reader["cord"].ToString(), Reader["issues"].ToString(), Reader["electrical"].ToString(), Reader["inouts"].ToString(), Reader["appropriate"].ToString(), Reader["understand"].ToString(), Reader["returns"].ToString(), Reader["caregiver"].ToString(), Reader["safetyOther"].ToString(), Reader["physicallimit"].ToString(), Reader["ambulatory"].ToString(), Reader["bath"].ToString(), Reader["beds"].ToString(), Reader["seat"].ToString(), Reader["scooter"].ToString(), Reader["manual"].ToString(), Reader["power"].ToString(), Reader["handling"].ToString(), Reader["equipmentOther"].ToString(), Reader["rights"].ToString(), Reader["available"].ToString(), Reader["privacy"].ToString(), Reader["standards"].ToString(), Reader["demonstration"].ToString(), Reader["cleaning"].ToString(), Reader["letter"].ToString(), Reader["complaint"].ToString(), Reader["warranty"].ToString(), Reader["instructions"].ToString(), Reader["aob"].ToString(), Reader["notes"].ToString(), Reader["visit"].ToString(), Reader["phone"].ToString(), Reader["patientSign"].ToString(), Reader["employee"].ToString(), Reader["employeeSign"].ToString(), Reader["kinName"].ToString(), Reader["otherSign"].ToString(), Reader["kinContact"].ToString(), Reader["relationship"].ToString(), Reader["representative"].ToString(), Reader["reason"].ToString(), Reader["userSignature"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["userID"].ToString());
				p.Add(ps);
            }
            DBConnect.CloseMySqlConn();
            return p;

        }
       
        public static Instruction Select(string id)
        {
            string Q = "SELECT * FROM instruction WHERE id = '" + id + "'";
            DBConnect.OpenConn();
            MySqlDataReader Reader = MySQL.Reading(Q);
            while (Reader.Read())
            {
                c = new Instruction(Reader["id"].ToString(), Reader["no"].ToString(), Reader["customerID"].ToString(), Reader["altContact"].ToString(), Reader["date"].ToString(), Reader["initial"].ToString(), Reader["followup"].ToString(), Reader["type"].ToString(), Reader["delivered"].ToString(), Reader["safety"].ToString(), Reader["pathways"].ToString(), Reader["operation"].ToString(), Reader["environment"].ToString(), Reader["rugs"].ToString(), Reader["fire"].ToString(), Reader["cord"].ToString(), Reader["issues"].ToString(), Reader["electrical"].ToString(), Reader["inouts"].ToString(), Reader["appropriate"].ToString(), Reader["understand"].ToString(), Reader["returns"].ToString(), Reader["caregiver"].ToString(), Reader["safetyOther"].ToString(), Reader["physicallimit"].ToString(), Reader["ambulatory"].ToString(), Reader["bath"].ToString(), Reader["beds"].ToString(), Reader["seat"].ToString(), Reader["scooter"].ToString(), Reader["manual"].ToString(), Reader["power"].ToString(), Reader["handling"].ToString(), Reader["equipmentOther"].ToString(), Reader["rights"].ToString(), Reader["available"].ToString(), Reader["privacy"].ToString(), Reader["standards"].ToString(), Reader["demonstration"].ToString(), Reader["cleaning"].ToString(), Reader["letter"].ToString(), Reader["complaint"].ToString(), Reader["warranty"].ToString(), Reader["instructions"].ToString(), Reader["aob"].ToString(), Reader["notes"].ToString(), Reader["visit"].ToString(), Reader["phone"].ToString(), Reader["patientSign"].ToString(), Reader["employee"].ToString(), Reader["employeeSign"].ToString(), Reader["kinName"].ToString(), Reader["otherSign"].ToString(), Reader["kinContact"].ToString(), Reader["relationship"].ToString(), Reader["representative"].ToString(), Reader["reason"].ToString(), Reader["userSignature"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["userID"].ToString());
			}
			DBConnect.CloseMySqlConn();
            return c;

        }
		public static Instruction SelectNo(string no)
		{
			string Q = "SELECT * FROM instruction WHERE no = '" + no + "'";
			DBConnect.OpenConn();
			MySqlDataReader Reader = MySQL.Reading(Q);
			while (Reader.Read())
			{
				c = new Instruction(Reader["id"].ToString(), Reader["no"].ToString(), Reader["customerID"].ToString(), Reader["altContact"].ToString(), Reader["date"].ToString(), Reader["initial"].ToString(), Reader["followup"].ToString(), Reader["type"].ToString(), Reader["delivered"].ToString(), Reader["safety"].ToString(), Reader["pathways"].ToString(), Reader["operation"].ToString(), Reader["environment"].ToString(), Reader["rugs"].ToString(), Reader["fire"].ToString(), Reader["cord"].ToString(), Reader["issues"].ToString(), Reader["electrical"].ToString(), Reader["inouts"].ToString(), Reader["appropriate"].ToString(), Reader["understand"].ToString(), Reader["returns"].ToString(), Reader["caregiver"].ToString(), Reader["safetyOther"].ToString(), Reader["physicallimit"].ToString(), Reader["ambulatory"].ToString(), Reader["bath"].ToString(), Reader["beds"].ToString(), Reader["seat"].ToString(), Reader["scooter"].ToString(), Reader["manual"].ToString(), Reader["power"].ToString(), Reader["handling"].ToString(), Reader["equipmentOther"].ToString(), Reader["rights"].ToString(), Reader["available"].ToString(), Reader["privacy"].ToString(), Reader["standards"].ToString(), Reader["demonstration"].ToString(), Reader["cleaning"].ToString(), Reader["letter"].ToString(), Reader["complaint"].ToString(), Reader["warranty"].ToString(), Reader["instructions"].ToString(), Reader["aob"].ToString(), Reader["notes"].ToString(), Reader["visit"].ToString(), Reader["phone"].ToString(), Reader["patientSign"].ToString(), Reader["employee"].ToString(), Reader["employeeSign"].ToString(), Reader["kinName"].ToString(), Reader["otherSign"].ToString(), Reader["kinContact"].ToString(), Reader["relationship"].ToString(), Reader["representative"].ToString(), Reader["reason"].ToString(), Reader["userSignature"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["userID"].ToString());
			}
			DBConnect.CloseMySqlConn();
			return c;

		}
	}


}

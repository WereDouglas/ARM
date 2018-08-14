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
    public class Certificate
    {
        private string id;
        private string no;
        private string cusID;
        private string cusName;        
        private string cusDob;
        private string cusPhone;
		private string provID;
		private string provName;
		private string provPhone;
		private string mobility;
        private string endurance;
        private string activity;
		private string skin;
		private string respiration;
		private string adl;
		private string speech;
		private string nutritional;
		private string source;
        private double weight;
        private double height;        
        private string suitable;
        private string date;
        private string pracName;
        private string pracSign;        
        private string signDate;       
        private string pracID;
        private string pracPhone;            
        private string created;
        private string sync;
        private string companyID;
		private string po;
		private string saturation;
		private string additional;
		private string face;
		private string practionercompleted;
		private string dateFace;
		private string patientNo;
		public Certificate() { }

		public Certificate(string id, string no, string cusID, string cusName, string cusDob, string cusPhone, string provID, string provName, string provPhone, string mobility, string endurance, string activity, string skin, string respiration, string adl, string speech, string nutritional, string source, double weight, double height, string suitable, string date, string pracName, string pracSign, string signDate, string pracID, string pracPhone, string created, string sync, string companyID, string po, string saturation, string additional, string face, string practionercompleted,string dateFace,string patientNo)
		{
			this.Id = id;
			this.No = no;
			this.CusID = cusID;
			this.CusName = cusName;
			this.CusDob = cusDob;
			this.CusPhone = cusPhone;
			this.ProvID = provID;
			this.ProvName = provName;
			this.ProvPhone = provPhone;
			this.Mobility = mobility;
			this.Endurance = endurance;
			this.Activity = activity;
			this.Skin = skin;
			this.Respiration = respiration;
			this.Adl = adl;
			this.Speech = speech;
			this.Nutritional = nutritional;
			this.Source = source;
			this.Weight = weight;
			this.Height = height;
			this.Suitable = suitable;
			this.Date = date;
			this.PracName = pracName;
			this.PracSign = pracSign;
			this.SignDate = signDate;
			this.PracID = pracID;
			this.PracPhone = pracPhone;
			this.Created = created;
			this.Sync = sync;
			this.CompanyID = companyID;
			this.Po = po;
			this.Saturation = saturation;
			this.Additional = additional;
			this.Face = face;
			this.Practionercompleted = practionercompleted;
			this.DateFace = dateFace;
			this.PatientNo = patientNo;
		}

		static List<Certificate> p = new List<Certificate>();
        public static List<Certificate> List()
        {
            p.Clear();
            string Q = "SELECT * FROM certificate ";
           
            MySqlDataReader Reader = MySQL.Reading(Q);
            while (Reader.Read())
            {
                Certificate ps = new Certificate(Reader["id"].ToString(), Reader["no"].ToString(), Reader["cusID"].ToString(), Reader["cusName"].ToString(), Reader["cusDob"].ToString(), Reader["cusPhone"].ToString(), Reader["provID"].ToString(), Reader["provName"].ToString(), Reader["provPhone"].ToString(), Reader["mobility"].ToString(), Reader["endurance"].ToString(), Reader["activity"].ToString(), Reader["skin"].ToString(), Reader["respiration"].ToString(), Reader["adl"].ToString(), Reader["speech"].ToString(), Reader["nutritional"].ToString(), Reader["source"].ToString(), Convert.ToDouble(Reader["weight"]), Convert.ToDouble(Reader["height"]), Reader["suitable"].ToString(), Reader["date"].ToString(), Reader["pracName"].ToString(), Reader["pracSign"].ToString(), Reader["signDate"].ToString(), Reader["pracID"].ToString(), Reader["pracPhone"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["po"].ToString(), Reader["saturation"].ToString(), Reader["additional"].ToString(), Reader["face"].ToString(), Reader["practionercompleted"].ToString(), Reader["dateface"].ToString(), Reader["patientNo"].ToString());
				p.Add(ps);
            }
            DBConnect.CloseMySqlConn();
            return p;
        }
        public static List<Certificate> List(string Q)
        {
            p.Clear();
           
            MySqlDataReader Reader = MySQL.Reading(Q);
            while (Reader.Read())
            {
                Certificate ps = new Certificate(Reader["id"].ToString(), Reader["no"].ToString(), Reader["cusID"].ToString(), Reader["cusName"].ToString(), Reader["cusDob"].ToString(), Reader["cusPhone"].ToString(), Reader["provID"].ToString(), Reader["provName"].ToString(), Reader["provPhone"].ToString(), Reader["mobility"].ToString(), Reader["endurance"].ToString(), Reader["activity"].ToString(), Reader["skin"].ToString(), Reader["respiration"].ToString(), Reader["adl"].ToString(), Reader["speech"].ToString(), Reader["nutritional"].ToString(), Reader["source"].ToString(), Convert.ToDouble(Reader["weight"]), Convert.ToDouble(Reader["height"]), Reader["suitable"].ToString(), Reader["date"].ToString(), Reader["pracName"].ToString(), Reader["pracSign"].ToString(), Reader["signDate"].ToString(), Reader["pracID"].ToString(), Reader["pracPhone"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["po"].ToString(), Reader["saturation"].ToString(), Reader["additional"].ToString(), Reader["face"].ToString(), Reader["practionercompleted"].ToString(), Reader["dateface"].ToString(), Reader["patientNo"].ToString());
				p.Add(ps);
            }
            DBConnect.CloseMySqlConn();
            return p;
        }
        public static List<Certificate> ListOnline(string Q)
        {
            try
            {
                p.Clear();
               
                MySqlDataReader Reader = MySQL.Reading(Q);
                while (Reader.Read())
                {
                    Certificate ps = new Certificate(Reader["id"].ToString(), Reader["no"].ToString(), Reader["cusID"].ToString(), Reader["cusName"].ToString(), Reader["cusDob"].ToString(), Reader["cusPhone"].ToString(), Reader["provID"].ToString(), Reader["provName"].ToString(), Reader["provPhone"].ToString(), Reader["mobility"].ToString(), Reader["endurance"].ToString(), Reader["activity"].ToString(), Reader["skin"].ToString(), Reader["respiration"].ToString(), Reader["adl"].ToString(), Reader["speech"].ToString(), Reader["nutritional"].ToString(), Reader["source"].ToString(), Convert.ToDouble(Reader["weight"]), Convert.ToDouble(Reader["height"]), Reader["suitable"].ToString(), Reader["date"].ToString(), Reader["pracName"].ToString(), Reader["pracSign"].ToString(), Reader["signDate"].ToString(), Reader["pracID"].ToString(), Reader["pracPhone"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["po"].ToString(), Reader["saturation"].ToString(), Reader["additional"].ToString(), Reader["face"].ToString(), Reader["practionercompleted"].ToString(), Reader["dateface"].ToString(), Reader["patientNo"].ToString());
					p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;
        }
        private static Certificate c = new Certificate();

		public string Id { get => id; set => id = value; }
		public string No { get => no; set => no = value; }
		public string CusID { get => cusID; set => cusID = value; }
		public string CusName { get => cusName; set => cusName = value; }
		public string CusDob { get => cusDob; set => cusDob = value; }
		public string CusPhone { get => cusPhone; set => cusPhone = value; }
		public string ProvID { get => provID; set => provID = value; }
		public string ProvName { get => provName; set => provName = value; }
		public string ProvPhone { get => provPhone; set => provPhone = value; }
		public string Mobility { get => mobility; set => mobility = value; }
		public string Endurance { get => endurance; set => endurance = value; }
		public string Activity { get => activity; set => activity = value; }
		public string Skin { get => skin; set => skin = value; }
		public string Respiration { get => respiration; set => respiration = value; }
		public string Adl { get => adl; set => adl = value; }
		public string Speech { get => speech; set => speech = value; }
		public string Nutritional { get => nutritional; set => nutritional = value; }
		public string Source { get => source; set => source = value; }
		public double Weight { get => weight; set => weight = value; }
		public double Height { get => height; set => height = value; }
		public string Suitable { get => suitable; set => suitable = value; }
		public string Date { get => date; set => date = value; }
		public string PracName { get => pracName; set => pracName = value; }
		public string PracSign { get => pracSign; set => pracSign = value; }
		public string SignDate { get => signDate; set => signDate = value; }
		public string PracID { get => pracID; set => pracID = value; }
		public string PracPhone { get => pracPhone; set => pracPhone = value; }
		public string Created { get => created; set => created = value; }
		public string Sync { get => sync; set => sync = value; }
		public string CompanyID { get => companyID; set => companyID = value; }
		public string Po { get => po; set => po = value; }
		public string Saturation { get => saturation; set => saturation = value; }
		public string Additional { get => additional; set => additional = value; }
		public string Face { get => face; set => face = value; }
		public string Practionercompleted { get => practionercompleted; set => practionercompleted = value; }
		public string DateFace { get => dateFace; set => dateFace = value; }
		public string PatientNo { get => patientNo; set => patientNo = value; }

		public static Certificate Select(string no)
        {
            string Q = "SELECT * FROM certificate WHERE no = '" + no + "'";
          
            MySqlDataReader Reader = MySQL.Reading(Q);
            while (Reader.Read())
            {
                c = new Certificate(Reader["id"].ToString(), Reader["no"].ToString(), Reader["cusID"].ToString(), Reader["cusName"].ToString(), Reader["cusDob"].ToString(), Reader["cusPhone"].ToString(), Reader["provID"].ToString(), Reader["provName"].ToString(), Reader["provPhone"].ToString(), Reader["mobility"].ToString(), Reader["endurance"].ToString(), Reader["activity"].ToString(), Reader["skin"].ToString(), Reader["respiration"].ToString(), Reader["adl"].ToString(), Reader["speech"].ToString(), Reader["nutritional"].ToString(), Reader["source"].ToString(), Convert.ToDouble(Reader["weight"]), Convert.ToDouble(Reader["height"]), Reader["suitable"].ToString(), Reader["date"].ToString(), Reader["pracName"].ToString(), Reader["pracSign"].ToString(), Reader["signDate"].ToString(), Reader["pracID"].ToString(), Reader["pracPhone"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["po"].ToString(), Reader["saturation"].ToString(), Reader["additional"].ToString(), Reader["face"].ToString(), Reader["practionercompleted"].ToString(), Reader["dateface"].ToString(), Reader["patientNo"].ToString());
			}
			//DBConnect.CloseMySqlConn();
			return c;
        }
		public static Certificate SelectNo(string no)
		{
			string Q = "SELECT * FROM certificate WHERE  no = '" + no + "'";
			
			MySqlDataReader Reader = MySQL.Reading(Q);
			while (Reader.Read())
			{
				c = new Certificate(Reader["id"].ToString(), Reader["no"].ToString(), Reader["cusID"].ToString(), Reader["cusName"].ToString(), Reader["cusDob"].ToString(), Reader["cusPhone"].ToString(), Reader["provID"].ToString(), Reader["provName"].ToString(), Reader["provPhone"].ToString(), Reader["mobility"].ToString(), Reader["endurance"].ToString(), Reader["activity"].ToString(), Reader["skin"].ToString(), Reader["respiration"].ToString(), Reader["adl"].ToString(), Reader["speech"].ToString(), Reader["nutritional"].ToString(), Reader["source"].ToString(), Convert.ToDouble(Reader["weight"].ToString()), Convert.ToDouble(Reader["height"].ToString()), Reader["suitable"].ToString(), Reader["date"].ToString(), Reader["pracName"].ToString(), Reader["pracSign"].ToString(), Reader["signDate"].ToString(), Reader["pracID"].ToString(), Reader["pracPhone"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["po"].ToString(), Reader["saturation"].ToString(), Reader["additional"].ToString(), Reader["face"].ToString(), Reader["practionercompleted"].ToString(), Reader["dateface"].ToString(), Reader["patientNo"].ToString());
			}
			DBConnect.CloseMySqlConn();
			return c;

		}
	}


}

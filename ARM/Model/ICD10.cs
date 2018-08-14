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
	public class ICD10
	{
		private string id;
		private string no;
		private string code;
		private string name;
		private string diagnosis;
		private string less6;
		private string greater6;
		private string onset;
		private string created;
		private string sync;
		private string companyID;
		public ICD10() { }

		public ICD10(string id, string no, string code, string name, string diagnosis, string less6, string greater6, string onset, string created, string sync, string companyID)
		{
			this.Id = id;
			this.No = no;
			this.Code = code;
			this.Name = name;
			this.Diagnosis = diagnosis;
			this.Less6 = less6;
			this.Greater6 = greater6;
			this.Onset = onset;
			this.Created = created;
			this.Sync = sync;
			this.CompanyID = companyID;
		}
		private static List<ICD10> p = new List<ICD10>();

		public string Id { get => id; set => id = value; }
		public string No { get => no; set => no = value; }
		public string Code { get => code; set => code = value; }
		public string Name { get => name; set => name = value; }
		public string Diagnosis { get => diagnosis; set => diagnosis = value; }
		public string Less6 { get => less6; set => less6 = value; }
		public string Greater6 { get => greater6; set => greater6 = value; }
		public string Onset { get => onset; set => onset = value; }
		public string Created { get => created; set => created = value; }
		public string Sync { get => sync; set => sync = value; }
		public string CompanyID { get => companyID; set => companyID = value; }

		public static List<ICD10> List(string Q)
		{
			p.Clear();
			//  string Q = "SELECT * FROM ICD10 WHERE no = '"+no+"' ";
			try
			{
				DBConnect.OpenConn();
				MySqlDataReader Reader = MySQL.Reading(Q);
				while (Reader.Read())
				{
					ICD10 ps = new ICD10(Reader["id"].ToString(), Reader["no"].ToString(), Reader["code"].ToString(), Reader["name"].ToString(), Reader["diagnosis"].ToString(), Reader["less6"].ToString(), Reader["greater6"].ToString(), Reader["onset"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
					p.Add(ps);
				}

				DBConnect.CloseMySqlConn();
			}
			catch { }
			return p;

		}
		public static List<ICD10> ListOnline(string Q)
		{
			try
			{
				p.Clear();
				DBConnect.OpenMySqlConn();
				MySqlDataReader Reader = MySQL.Reading(Q);
				while (Reader.Read())
				{
					ICD10 ps = new ICD10(Reader["id"].ToString(), Reader["no"].ToString(), Reader["code"].ToString(), Reader["name"].ToString(), Reader["diagnosis"].ToString(), Reader["less6"].ToString(), Reader["greater6"].ToString(), Reader["onset"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
					p.Add(ps);
				}
				DBConnect.CloseMySqlConn();
			}
			catch { }
			return p;

		}
		public static List<ICD10> ListUpload(string Q)
		{
			p.Clear();

			DBConnect.OpenConn();
			MySqlDataReader Reader = MySQL.Reading(Q);
			while (Reader.Read())
			{
				ICD10 ps = new ICD10(Reader["id"].ToString(), Reader["no"].ToString(), Reader["code"].ToString(), Reader["name"].ToString(), Reader["diagnosis"].ToString(), Reader["less6"].ToString(), Reader["greater6"].ToString(), Reader["onset"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
				p.Add(ps);
			}
			DBConnect.CloseMySqlConn();
			return p;

		}

	}

}

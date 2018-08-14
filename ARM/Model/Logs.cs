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
	public class Logs
	{
		private string id;
		private string name;
		private string actions;
		private string created;
		private string sync;
		private string companyID;
		public Logs() { }

		public Logs(string id, string name, string actions, string created, string sync, string companyID)
		{
			this.Id = id;
			this.Name = name;
			this.Actions = actions;
			this.Created = created;
			this.Sync = sync;
			this.CompanyID = companyID;
		}

		static List<Logs> p = new List<Logs>();


		public static List<Logs> List()
		{
			p.Clear();
			string Q = "SELECT * FROM logs ";
		
			MySqlDataReader Reader = MySQL.Reading(Q);
			while (Reader.Read())
			{
				Logs ps = new Logs(Reader["id"].ToString(), Reader["name"].ToString(), Reader["actions"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
				p.Add(ps);
			}
			DBConnect.CloseMySqlConn();
			return p;

		}
		public static List<Logs> List(string Q)
		{
			p.Clear();
			try
			{
				
				MySqlDataReader Reader = MySQL.Reading(Q);
				while (Reader.Read())
				{
					Logs ps = new Logs(Reader["id"].ToString(), Reader["name"].ToString(), Reader["actions"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
					p.Add(ps);
				}
				DBConnect.CloseMySqlConn();
			}
			catch (Exception p)
			{

				Console.WriteLine(p.Message);
			}
			return p;

		}
		public static List<Logs> ListOnline(string Q)
		{
			try
			{
				p.Clear();
				
				MySqlDataReader Reader = MySQL.Reading(Q);
				while (Reader.Read())
				{
					Logs ps = new Logs(Reader["id"].ToString(), Reader["name"].ToString(), Reader["actions"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
					p.Add(ps);
				}
				DBConnect.CloseMySqlConn();
			}
			catch
			{


			}
			return p;

		}
		static Logs c;

		public string Id { get => id; set => id = value; }
		public string Name { get => name; set => name = value; }
		public string Actions { get => actions; set => actions = value; }
		public string Created { get => created; set => created = value; }
		public string Sync { get => sync; set => sync = value; }
		public string CompanyID { get => companyID; set => companyID = value; }

		public static Logs Select(string ID)
		{
			string Q = "SELECT * FROM logs WHERE id = '" + ID + "'";
			
			MySqlDataReader Reader = MySQL.Reading(Q);
			while (Reader.Read())
			{
				c = new Logs(Reader["id"].ToString(), Reader["name"].ToString(), Reader["actions"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
			}
			DBConnect.CloseMySqlConn();
			return c;

		}
	}

}

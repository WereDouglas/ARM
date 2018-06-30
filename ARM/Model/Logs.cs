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
		private bool sync;
		private string companyID;
		public Logs() { }

		public Logs(string id, string name, string actions, string created, bool sync, string companyID)
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
			string Q = "SELECT * FROM Logs ";
			DBConnect.OpenConn();
			NpgsqlDataReader Reader = DBConnect.Reading(Q);
			while (Reader.Read())
			{
				Logs ps = new Logs(Reader["id"].ToString(), Reader["name"].ToString(), Reader["actions"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
				p.Add(ps);
			}
			DBConnect.CloseConn();
			return p;

		}
		public static List<Logs> List(string Q)
		{
			p.Clear();
			try
			{
				DBConnect.OpenConn();
				NpgsqlDataReader Reader = DBConnect.Reading(Q);
				while (Reader.Read())
				{
					Logs ps = new Logs(Reader["id"].ToString(), Reader["name"].ToString(), Reader["actions"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
					p.Add(ps);
				}
				DBConnect.CloseConn();
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
				DBConnect.OpenMySqlConn();
				MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
				while (Reader.Read())
				{
					Logs ps = new Logs(Reader["id"].ToString(), Reader["name"].ToString(), Reader["actions"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
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
		public bool Sync { get => sync; set => sync = value; }
		public string CompanyID { get => companyID; set => companyID = value; }

		public static Logs Select(string ID)
		{
			string Q = "SELECT * FROM rate WHERE userID = '" + ID + "'";
			DBConnect.OpenConn();
			NpgsqlDataReader Reader = DBConnect.Reading(Q);
			while (Reader.Read())
			{
				c = new Logs(Reader["id"].ToString(), Reader["name"].ToString(), Reader["actions"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
			}
			DBConnect.CloseConn();
			return c;

		}
	}

}

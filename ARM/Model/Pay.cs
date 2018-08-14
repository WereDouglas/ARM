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
	public class Pay
	{
		private string id;
		private string date;
		private string no;
		private string userID;
		private string method;
		private string starts;
		private string ends;
		private int week;
		private double rate;
		private double hours;
		private double amount;
		private double overtimeHrs;
		private double overtimeRate;
		private double overtimePay;
		private double deductions;
		private double payment;
		private string paid;
		private string created;
		private string companyID;

		public Pay() { }

		public Pay(string id, string date, string no, string userID, string method, string starts, string ends, int week, double rate, double hours, double amount, double overtimeHrs, double overtimeRate, double overtimePay, double deductions, double payment, string paid, string created, string companyID)
		{
			this.Id = id;
			this.Date = date;
			this.No = no;
			this.UserID = userID;
			this.Method = method;
			this.Starts = starts;
			this.Ends = ends;
			this.Week = week;
			this.Rate = rate;
			this.Hours = hours;
			this.Amount = amount;
			this.OvertimeHrs = overtimeHrs;
			this.OvertimeRate = overtimeRate;
			this.OvertimePay = overtimePay;
			this.Deductions = deductions;
			this.Payment = payment;
			this.Paid = paid;
			this.Created = created;
			this.CompanyID = companyID;
		}

		static List<Pay> p = new List<Pay>();

		public string Id { get => id; set => id = value; }
		public string Date { get => date; set => date = value; }
		public string No { get => no; set => no = value; }
		public string UserID { get => userID; set => userID = value; }
		public string Method { get => method; set => method = value; }
		public string Starts { get => starts; set => starts = value; }
		public string Ends { get => ends; set => ends = value; }
		public int Week { get => week; set => week = value; }
		public double Rate { get => rate; set => rate = value; }
		public double Hours { get => hours; set => hours = value; }
		public double Amount { get => amount; set => amount = value; }
		public double OvertimeHrs { get => overtimeHrs; set => overtimeHrs = value; }
		public double OvertimeRate { get => overtimeRate; set => overtimeRate = value; }
		public double OvertimePay { get => overtimePay; set => overtimePay = value; }
		public double Deductions { get => deductions; set => deductions = value; }
		public double Payment { get => payment; set => payment = value; }
		public string Paid { get => paid; set => paid = value; }
		public string Created { get => created; set => created = value; }
		public string CompanyID { get => companyID; set => companyID = value; }

		public static List<Pay> List()
		{
			p.Clear();
			string Q = "SELECT * FROM pay ";

			MySqlDataReader Reader = MySQL.Reading(Q);
			while (Reader.Read())
			{
				Pay ps = new Pay(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["userID"].ToString(), Reader["method"].ToString(), Reader["starts"].ToString(), Reader["ends"].ToString(), Convert.ToInt32(Reader["week"].ToString()), Convert.ToDouble(Reader["rate"]), Convert.ToDouble(Reader["hours"]), Convert.ToDouble(Reader["amount"]), Convert.ToDouble(Reader["overtimehrs"]), Convert.ToDouble(Reader["overtimerate"]), Convert.ToDouble(Reader["overtimepay"]), Convert.ToDouble(Reader["deductions"]), Convert.ToDouble(Reader["payment"]), Reader["paid"].ToString(), Reader["created"].ToString(), Reader["companyID"].ToString());
				p.Add(ps);
			}
			DBConnect.CloseMySqlConn();
			return p;
		}
		public static List<Pay> List(string Q)
		{
			try
			{
				p.Clear();
				
				MySqlDataReader Reader = MySQL.Reading(Q);
				while (Reader.Read())
				{
					Pay ps = new Pay(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["userID"].ToString(), Reader["method"].ToString(), Reader["starts"].ToString(), Reader["ends"].ToString(), Convert.ToInt32(Reader["week"].ToString()), Convert.ToDouble(Reader["rate"]), Convert.ToDouble(Reader["hours"]), Convert.ToDouble(Reader["amount"]), Convert.ToDouble(Reader["overtimehrs"]), Convert.ToDouble(Reader["overtimerate"]), Convert.ToDouble(Reader["overtimepay"]), Convert.ToDouble(Reader["deductions"]), Convert.ToDouble(Reader["payment"]), Reader["paid"].ToString(), Reader["created"].ToString(), Reader["companyID"].ToString());
					p.Add(ps);
				}
				DBConnect.CloseMySqlConn();
			}
			catch { }
			return p;
		}
		public static List<Pay> ListOnline(string Q)
		{
			try
			{
				p.Clear();
				MySqlDataReader Reader = MySQL.Reading(Q);
				while (Reader.Read())
				{
					Pay ps = new Pay(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["userID"].ToString(), Reader["method"].ToString(), Reader["starts"].ToString(), Reader["ends"].ToString(), Convert.ToInt32(Reader["week"].ToString()), Convert.ToDouble(Reader["rate"]), Convert.ToDouble(Reader["hours"]), Convert.ToDouble(Reader["amount"]), Convert.ToDouble(Reader["overtimehrs"]), Convert.ToDouble(Reader["overtimerate"]), Convert.ToDouble(Reader["overtimepay"]), Convert.ToDouble(Reader["deductions"]), Convert.ToDouble(Reader["payment"]), Reader["paid"].ToString(), Reader["created"].ToString(), Reader["companyID"].ToString());
					p.Add(ps);
				}
				DBConnect.CloseMySqlConn();
			}
			catch { }
			return p;
		}
		public static bool Exists(string start, string end, string userID)
		{
			p.Clear();
			string Q = "SELECT * FROM pay WHERE starts = '" + start + "' AND ends ='" + end + "' AND userID = '" + userID + "' ";

			MySqlDataReader Reader = MySQL.Reading(Q);
			while (Reader.Read())
			{
				Pay ps = new Pay(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["userID"].ToString(), Reader["method"].ToString(), Reader["starts"].ToString(), Reader["ends"].ToString(), Convert.ToInt32(Reader["week"].ToString()), Convert.ToDouble(Reader["rate"]), Convert.ToDouble(Reader["hours"]), Convert.ToDouble(Reader["amount"]), Convert.ToDouble(Reader["overtimehrs"]), Convert.ToDouble(Reader["overtimerate"]), Convert.ToDouble(Reader["overtimepay"]), Convert.ToDouble(Reader["deductions"]), Convert.ToDouble(Reader["payment"]), Reader["paid"].ToString(), Reader["created"].ToString(), Reader["companyID"].ToString());
				p.Add(ps);
			}
			DBConnect.CloseMySqlConn();
			if (p.Count > 0)
			{
				return true;

			}
			else { return false; }

		}
		static Pay c = new Pay();
		public static Pay Select(string no)
		{
			string Q = "SELECT * FROM pay WHERE no = '" + no + "'";

			MySqlDataReader Reader = MySQL.Reading(Q);
			while (Reader.Read())
			{
				c = new Pay(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["userID"].ToString(), Reader["method"].ToString(), Reader["starts"].ToString(), Reader["ends"].ToString(), Convert.ToInt32(Reader["week"].ToString()), Convert.ToDouble(Reader["rate"]), Convert.ToDouble(Reader["hours"]), Convert.ToDouble(Reader["amount"]), Convert.ToDouble(Reader["overtimehrs"]), Convert.ToDouble(Reader["overtimerate"]), Convert.ToDouble(Reader["overtimepay"]), Convert.ToDouble(Reader["deductions"]), Convert.ToDouble(Reader["payment"]), Reader["paid"].ToString(), Reader["created"].ToString(), Reader["companyID"].ToString());
			}
			DBConnect.CloseMySqlConn();
			return c;

		}
	}

}

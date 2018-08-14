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
	public class CaseTransaction
	{
		private string id;
		private string date;
		private string no;
		private string itemID;
		private string caseID;
		private string deliveryID;
		private double qty;
		private double cost;
		private string units;
		private double total;
		private double tax;
		private double coverage;
		private double self;
		private double payable;
		private string limits;
		private string setting;
		private string period;
		private string height;
		private string weight;
		private string instruction;
		private string created;
		private string sync;
		private string companyID;

		public CaseTransaction() { }
		static List<CaseTransaction> p = new List<CaseTransaction>();

		public CaseTransaction(string id, string date, string no, string itemID, string caseID, string deliveryID, double qty, double cost, string units, double total, double tax, double coverage, double self, double payable, string limits, string setting, string period, string height, string weight, string instruction, string created, string sync, string companyID)
		{
			this.Id = id;
			this.Date = date;
			this.No = no;
			this.ItemID = itemID;
			this.CaseID = caseID;
			this.DeliveryID = deliveryID;
			this.Qty = qty;
			this.Cost = cost;
			this.Units = units;
			this.Total = total;
			this.Tax = tax;
			this.Coverage = coverage;
			this.Self = self;
			this.Payable = payable;
			this.Limits = limits;
			this.Setting = setting;
			this.Period = period;
			this.Height = height;
			this.Weight = weight;
			this.Instruction = instruction;
			this.Created = created;
			this.Sync = sync;
			this.CompanyID = companyID;
		}
		public string Id { get => id; set => id = value; }
		public string Date { get => date; set => date = value; }
		public string No { get => no; set => no = value; }
		public string ItemID { get => itemID; set => itemID = value; }
		public string CaseID { get => caseID; set => caseID = value; }
		public string DeliveryID { get => deliveryID; set => deliveryID = value; }
		public double Qty { get => qty; set => qty = value; }
		public double Cost { get => cost; set => cost = value; }
		public string Units { get => units; set => units = value; }
		public double Total { get => total; set => total = value; }
		public double Tax { get => tax; set => tax = value; }
		public double Coverage { get => coverage; set => coverage = value; }
		public double Self { get => self; set => self = value; }
		public double Payable { get => payable; set => payable = value; }
		public string Limits { get => limits; set => limits = value; }
		public string Setting { get => setting; set => setting = value; }
		public string Period { get => period; set => period = value; }
		public string Height { get => height; set => height = value; }
		public string Weight { get => weight; set => weight = value; }
		public string Instruction { get => instruction; set => instruction = value; }
		public string Created { get => created; set => created = value; }
		public string Sync { get => sync; set => sync = value; }
		public string CompanyID { get => companyID; set => companyID = value; }


		public static List<CaseTransaction> List()
		{
			p.Clear();
			string Q = "SELECT * FROM casetransaction";
		
			MySqlDataReader Reader = MySQL.Reading(Q);
			while (Reader.Read())
			{
				CaseTransaction ps = new CaseTransaction(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["itemID"].ToString(), Reader["caseID"].ToString(), Reader["deliveryID"].ToString(), Convert.ToDouble(Reader["qty"]), Convert.ToDouble(Reader["cost"]), Reader["units"].ToString(), Convert.ToDouble(Reader["total"]), Convert.ToDouble(Reader["tax"]), Convert.ToDouble(Reader["coverage"]), Convert.ToDouble(Reader["self"]), Convert.ToDouble(Reader["payable"]), Reader["limits"].ToString(), Reader["setting"].ToString(), Reader["period"].ToString(), Reader["height"].ToString(), Reader["weight"].ToString(), Reader["instruction"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
				p.Add(ps);
			}
			DBConnect.CloseMySqlConn();
			return p;
		}
		public static List<CaseTransaction> ListNo(string no)
		{
			p.Clear();
			string Q = "SELECT * FROM casetransaction WHERE no = '" + no + "'";
			
			MySqlDataReader Reader = MySQL.Reading(Q);
			while (Reader.Read())
			{
				CaseTransaction ps = new CaseTransaction(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["itemID"].ToString(), Reader["caseID"].ToString(), Reader["deliveryID"].ToString(), Convert.ToDouble(Reader["qty"]), Convert.ToDouble(Reader["cost"]), Reader["units"].ToString(), Convert.ToDouble(Reader["total"]), Convert.ToDouble(Reader["tax"]), Convert.ToDouble(Reader["coverage"]), Convert.ToDouble(Reader["self"]), Convert.ToDouble(Reader["payable"]), Reader["limits"].ToString(), Reader["setting"].ToString(), Reader["period"].ToString(), Reader["height"].ToString(), Reader["weight"].ToString(), Reader["instruction"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
				p.Add(ps);
			}
			DBConnect.CloseMySqlConn();
			return p;
		}
		static MySqlDataReader Reader;
		public static List<CaseTransaction> List(string Q)
		{
			p.Clear();
			//try
			//{		
				
			//	MySqlDataReader Reader = MySQL.Reading(Q);
			//	while (Reader.Read())
			//	{
			//		CaseTransaction ps = new CaseTransaction(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["itemID"].ToString(), Reader["caseID"].ToString(), Reader["deliveryID"].ToString(), Convert.ToDouble(Reader["qty"]), Convert.ToDouble(Reader["cost"]), Reader["units"].ToString(), Convert.ToDouble(Reader["total"]), Convert.ToDouble(Reader["tax"]), Convert.ToDouble(Reader["coverage"]), Convert.ToDouble(Reader["self"]), Convert.ToDouble(Reader["payable"]), Reader["limits"].ToString(), Reader["setting"].ToString(), Reader["period"].ToString(), Reader["height"].ToString(), Reader["weight"].ToString(), Reader["instruction"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString());
			//		p.Add(ps);
			//	}
			//	DBConnect.CloseMySqlConn();
			//}
			//catch { }

			Reader = MySQL.Reading(Q);
			p =MySQL.DataReaderMapToList<CaseTransaction>(Reader);
			return p;
		}
		
	}

}

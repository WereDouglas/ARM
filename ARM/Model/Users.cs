using ARM.DB;
using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
	public class Users
	{
		private string id;
		private string name;
		private string email;
		private string contact;
		private string address;
		private string city;
		private string state;
		private string zip;
		private string category;
		private string ssn;
		private string speciality;
		private string gender;
		private string created;
		private string sync;
		private string companyID;
		private string password;
		private string image;
		private string department;
		private string active;
		private string level;
		public Users() { }

		public Users(string id, string name, string email, string contact, string address, string city, string state, string zip, string category, string ssn, string speciality, string gender, string created, string sync, string companyID, string password, string image, string department, string active, string level)
		{
			this.Id = id;
			this.Name = name;
			this.Email = email;
			this.Contact = contact;
			this.Address = address;
			this.City = city;
			this.State = state;
			this.Zip = zip;
			this.Category = category;
			this.Ssn = ssn;
			this.Speciality = speciality;
			this.Gender = gender;
			this.Created = created;
			this.Sync = sync;
			this.CompanyID = companyID;
			this.Password = password;
			this.Image = image;
			this.Department = department;
			this.Active = active;
			this.Level = level;
		}

		static List<Users> p = new List<Users>();
		static MySqlDataReader Reader;
		public static List<Users> List()
		{
			//string Q = "SELECT * FROM users";
			//Reader = MySQL.Reading(Q);
			//p = DataReaderMapToList<Users>(Reader);
			p.Clear();
			string Q = "SELECT * FROM users";
			//try
			//{
				

			//	MySqlDataReader Reader = MySQL.Reading(Q);
			//	while (Reader.Read())
			//	{
			//		Users ps = new Users(Reader["id"].ToString(), Reader["name"].ToString(), Reader["email"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["category"].ToString(), Reader["ssn"].ToString(), Reader["speciality"].ToString(), Reader["gender"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["password"].ToString(), Reader["image"].ToString(), Reader["department"].ToString(), Reader["active"].ToString(), Reader["level"].ToString());
			//		p.Add(ps);
			//	}
			//	DBConnect.CloseMySqlConn();
			//}
			//catch { }
			Reader = MySQL.Reading(Q);		
			p = MySQL.DataReaderMapToList<Users>(Reader);
			return p;

		}
		
		public static List<Users> List(string Q)
		{
			p.Clear();
			
			//MySqlDataReader Reader = MySQL.Reading(Q);
			//while (Reader.Read())
			//{
			//	Users ps = new Users(Reader["id"].ToString(), Reader["name"].ToString(), Reader["email"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["category"].ToString(), Reader["ssn"].ToString(), Reader["speciality"].ToString(), Reader["gender"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["password"].ToString(), Reader["image"].ToString(), Reader["department"].ToString(), Reader["active"].ToString(), Reader["level"].ToString());
			//	p.Add(ps);
			//}
			//DBConnect.CloseMySqlConn();

			Reader =MySQL.Reading(Q);
			p = MySQL.DataReaderMapToList<Users>(Reader);
			return p;

		}		
		private static Users c = new Users();


		public string Id { get => id; set => id = value; }
		public string Name { get => name; set => name = value; }
		public string Email { get => email; set => email = value; }
		public string Contact { get => contact; set => contact = value; }
		public string Address { get => address; set => address = value; }
		public string City { get => city; set => city = value; }
		public string State { get => state; set => state = value; }
		public string Zip { get => zip; set => zip = value; }
		public string Category { get => category; set => category = value; }
		public string Ssn { get => ssn; set => ssn = value; }
		public string Speciality { get => speciality; set => speciality = value; }
		public string Gender { get => gender; set => gender = value; }
		public string Created { get => created; set => created = value; }
		public string Sync { get => sync; set => sync = value; }
		public string CompanyID { get => companyID; set => companyID = value; }
		public string Password { get => password; set => password = value; }
		public string Image { get => image; set => image = value; }
		public string Department { get => department; set => department = value; }
		public string Active { get => active; set => active = value; }
		public string Level { get => level; set => level = value; }

		public static Users Select(string userID)
		{
			string Q = "SELECT * FROM users WHERE id = '" + userID + "'";
			
			MySqlDataReader Reader = MySQL.Reading(Q);
			while (Reader.Read())
			{
				c = new Users(Reader["id"].ToString(), Reader["name"].ToString(), Reader["email"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["category"].ToString(), Reader["ssn"].ToString(), Reader["speciality"].ToString(), Reader["gender"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["password"].ToString(), Reader["image"].ToString(), Reader["department"].ToString(), Reader["active"].ToString(), Reader["level"].ToString());
			}
			DBConnect.CloseMySqlConn();
			return c;

		}
		public static Users Single(string Q)
		{		

			MySqlDataReader Reader = MySQL.Reading(Q);
			while (Reader.Read())
			{
				c = new Users(Reader["id"].ToString(), Reader["name"].ToString(), Reader["email"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["category"].ToString(), Reader["ssn"].ToString(), Reader["speciality"].ToString(), Reader["gender"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["password"].ToString(), Reader["image"].ToString(), Reader["department"].ToString(), Reader["active"].ToString(), Reader["level"].ToString());
			}
			DBConnect.CloseMySqlConn();
			return c;

		}
	}

}

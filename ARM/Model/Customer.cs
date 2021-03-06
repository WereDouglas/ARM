﻿using ARM.DB;
using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
    public class Customer
    {
        private string id;
        private string name;
        private string contact;
        private string address;
        private string no;
        private string city;
        private string state;
        private string zip;
        private string created;
        private string ssn;
        private string dob;
        private string category;
        private string height;
        private string weight;
        private string sync;
        private string companyID;
        private string gender;
        private string image;
		private string race;

		public Customer() { }

        public Customer(string id, string name, string contact, string address, string no, string city, string state, string zip, string created, string ssn, string dob, string category, string height, string weight, string gender, string sync, string companyID, string image,string race)
        {
            this.Id = id;
            this.Name = name;
            this.Contact = contact;
            this.Address = address;
            this.No = no;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.Created = created;
            this.Ssn = ssn;
            this.Dob = dob;
            this.Category = category;
            this.Height = height;
            this.Weight = weight;
            this.Sync = sync;
            this.CompanyID = companyID;
            this.Gender = gender;
            this.Image = image;
			this.Race = race;
		}

        static List<Customer> p = new List<Customer>();


        public static List<Customer> List()
        {
            try
            {
                p.Clear();
                string Q = "SELECT * FROM customer ORDER by no ASC ";
				MySqlDataReader Reader = MySQL.Reading(Q);
				while (Reader.Read())
                {
                    Customer ps = new Customer(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["ssn"].ToString(), Reader["dob"].ToString(), Reader["category"].ToString(), Reader["height"].ToString(), Reader["weight"].ToString(), Reader["gender"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["image"].ToString(), Reader["race"].ToString());
                    p.Add(ps);
                }
				DBConnect.CloseMySqlConn();
			}
            catch { }
            return p;

        }
		static MySqlDataReader Reader;
		public static List<Customer> List(string Q)
		{
			//try
			//{
			//	p.Clear();
			//	MySqlDataReader Reader = MySQL.Reading(Q);
			//	while (Reader.Read())
			//	{
			//		Customer ps = new Customer(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["ssn"].ToString(), Reader["dob"].ToString(), Reader["category"].ToString(), Reader["height"].ToString(), Reader["weight"].ToString(), Reader["gender"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["image"].ToString(), Reader["race"].ToString());
			//		p.Add(ps);
			//	}
			//	DBConnect.CloseMySqlConn();
			//}
			//catch { }

			p.Clear();
			Reader = MySQL.Reading(Q);
			p = MySQL.DataReaderMapToList<Customer>(Reader);
			return p;


		}
        private static Customer c = new Customer();

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Address { get => address; set => address = value; }
        public string No { get => no; set => no = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Zip { get => zip; set => zip = value; }
        public string Created { get => created; set => created = value; }
        public string Ssn { get => ssn; set => ssn = value; }
        public string Dob { get => dob; set => dob = value; }
        public string Category { get => category; set => category = value; }
        public string Height { get => height; set => height = value; }
        public string Weight { get => weight; set => weight = value; }
        public string Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Image { get => image; set => image = value; }
		public string Race { get => race; set => race = value; }

		public static Customer Select(string customerID)
        {
            string Q = "SELECT * FROM customer WHERE id = '" + customerID + "'";
			MySqlDataReader Reader = MySQL.Reading(Q);
			while (Reader.Read())
            {
                c = new Customer(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["ssn"].ToString(), Reader["dob"].ToString(), Reader["category"].ToString(), Reader["height"].ToString(), Reader["weight"].ToString(), Reader["gender"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["image"].ToString(), Reader["race"].ToString());
			}
			DBConnect.CloseMySqlConn();
			return c;

        }
		public static Customer Single(string Q)
		{			
			MySqlDataReader Reader = MySQL.Reading(Q);
			while (Reader.Read())
			{
				c = new Customer(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["ssn"].ToString(), Reader["dob"].ToString(), Reader["category"].ToString(), Reader["height"].ToString(), Reader["weight"].ToString(), Reader["gender"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["image"].ToString(), Reader["race"].ToString());
			}
			DBConnect.CloseMySqlConn();
			return c;

		}
	}

}

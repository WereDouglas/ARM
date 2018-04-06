﻿using ARM.DB;
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
        private string image;
        private string no;
        private string city;
        private string state;
        private string zip;
        private string created;
        private string category;
        private bool sync;
        public Customer() { }
        public Customer(string id, string name, string contact, string address, string image, string no, string city, string state, string zip, string created, string category, bool sync)
        {
            this.Id = id;
            this.Name = name;
            this.Contact = contact;
            this.Address = address;
            this.Image = image;
            this.No = no;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.Created = created;
            this.Category = category;
            this.Sync = sync;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Address { get => address; set => address = value; }
        public string Image { get => image; set => image = value; }
        public string No { get => no; set => no = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Zip { get => zip; set => zip = value; }
        public string Created { get => created; set => created = value; }
        public string Category { get => category; set => category = value; }
        public bool Sync { get => sync; set => sync = value; }

        static List<Customer> p = new List<Customer>();
        public static List<Customer> List()
        {
            string Q = "SELECT * FROM customer ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Customer ps = new Customer(Reader["id"].ToString(), Reader["name"].ToString(), Reader["contact"].ToString(), Reader["address"].ToString(), Reader["image"].ToString(), Reader["no"].ToString(), Reader["city"].ToString(), Reader["state"].ToString(), Reader["zip"].ToString(), Reader["created"].ToString(), Reader["category"].ToString(), Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
    }

}
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
    public class Item
    {
        private string id;
        private string name;
        private string category;
        private string type;
        private string description;
        private string cost;
        private string batchNo;
        private string serialNo;
        private string barcode;
        private string unitOfMeasure;
        private string measureDescription;
        private string manufacturer;
        private string created;
        private bool sync;
        private string image;
        public Item() { }

        public Item(string id, string name, string category, string type, string description, string cost, string batchNo, string serialNo, string barcode, string unitOfMeasure, string measureDescription, string manufacturer, string created, bool sync, string image)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Type = type;
            this.Description = description;
            this.Cost = cost;
            this.BatchNo = batchNo;
            this.SerialNo = serialNo;
            this.Barcode = barcode;
            this.UnitOfMeasure = unitOfMeasure;
            this.MeasureDescription = measureDescription;
            this.Manufacturer = manufacturer;
            this.Created = created;
            this.Sync = sync;
            this.Image = image;
        }

        static List<Item> p = new List<Item>();
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public string Type { get => type; set => type = value; }
        public string Description { get => description; set => description = value; }
        public string Cost { get => cost; set => cost = value; }
        public string BatchNo { get => batchNo; set => batchNo = value; }
        public string SerialNo { get => serialNo; set => serialNo = value; }
        public string Barcode { get => barcode; set => barcode = value; }
        public string UnitOfMeasure { get => unitOfMeasure; set => unitOfMeasure = value; }
        public string MeasureDescription { get => measureDescription; set => measureDescription = value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }
        public string Image { get => image; set => image = value; }

        public static List<Item> List()
        {
            p.Clear();
            string Q = "SELECT * FROM Item ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Item ps = new Item(Reader["id"].ToString(), Reader["name"].ToString(), Reader["category"].ToString(), Reader["type"].ToString(), Reader["description"].ToString(), Reader["cost"].ToString(), Reader["batchNo"].ToString(), Reader["serialNo"].ToString(), Reader["barcode"].ToString(), Reader["unitOfMeasure"].ToString(), Reader["measureDescription"].ToString(), Reader["manufacturer"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["image"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        public static List<Item> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Item ps = new Item(Reader["id"].ToString(), Reader["name"].ToString(), Reader["category"].ToString(), Reader["type"].ToString(), Reader["description"].ToString(), Reader["cost"].ToString(), Reader["batchNo"].ToString(), Reader["serialNo"].ToString(), Reader["barcode"].ToString(), Reader["unitOfMeasure"].ToString(), Reader["measureDescription"].ToString(), Reader["manufacturer"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["image"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
        public static List<Item> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Item ps = new Item(Reader["id"].ToString(), Reader["name"].ToString(), Reader["category"].ToString(), Reader["type"].ToString(), Reader["description"].ToString(), Reader["cost"].ToString(), Reader["batchNo"].ToString(), Reader["serialNo"].ToString(), Reader["barcode"].ToString(), Reader["unitOfMeasure"].ToString(), Reader["measureDescription"].ToString(), Reader["manufacturer"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["image"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();
            }
            catch { }
            return p;
        }
        static Item c = new Item();
        public static Item Select(string ID)
        {
            string Q = "SELECT * FROM item WHERE id = '" + ID + "'";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                c = new Item(Reader["id"].ToString(), Reader["name"].ToString(), Reader["category"].ToString(), Reader["type"].ToString(), Reader["description"].ToString(), Reader["cost"].ToString(), Reader["batchNo"].ToString(), Reader["serialNo"].ToString(), Reader["barcode"].ToString(), Reader["unitOfMeasure"].ToString(), Reader["measureDescription"].ToString(), Reader["manufacturer"].ToString(), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["image"].ToString());
            }
            DBConnect.CloseConn();
            return c;

        }


    }

}

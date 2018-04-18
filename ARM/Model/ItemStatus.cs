﻿using ARM.DB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
    public class ItemStatus
    {
        private string id;
        private string followID;
        private string title;     
        private string status;
        private string details;           
        private string created;      
        private bool sync;
        public ItemStatus() { }

        public ItemStatus(string id, string followID, string title, string status, string details, string created, bool sync)
        {
            this.Id = id;
            this.FollowID = followID;
            this.Title = title;
            this.Status = status;
            this.Details = details;
            this.Created = created;
            this.Sync = sync;
        }

        public string Id { get => id; set => id = value; }
        public string FollowID { get => followID; set => followID = value; }
        public string Title { get => title; set => title = value; }
        public string Status { get => status; set => status = value; }
        public string Details { get => details; set => details = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }
        private static List<ItemStatus> p = new List<ItemStatus>();
        public static List<ItemStatus> List(string followID)
        {
            p.Clear();
            string Q = "SELECT * FROM ItemStatus WHERE followID = '" + followID + "' ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                ItemStatus ps = new ItemStatus(Reader["id"].ToString(), Reader["followID"].ToString(), Reader["title"].ToString(), Reader["status"].ToString(), Reader["details"].ToString(),Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
        
    }

}
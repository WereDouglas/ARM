using ARM.DB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
    public class ItemReview
    {
        private string id;
        private string title;
        private string description;           
        private string created;      
        private bool sync;
        public ItemReview() { }

        public ItemReview(string id, string title, string description, string created, bool sync)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Created = created;
            this.Sync = sync;
        }

        static List<ItemReview> p = new List<ItemReview>();

        public string Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }

        public static List<ItemReview> List()
        {
            string Q = "SELECT * FROM Review ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                ItemReview ps = new ItemReview(Reader["id"].ToString(), Reader["title"].ToString(),Reader["description"].ToString(),Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
    }

}

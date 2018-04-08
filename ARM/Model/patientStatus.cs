using ARM.DB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
    public class PatientStatus
    {
        private string id;
        private string title;     
        private string values;
        private string description;           
        private string created;      
        private bool sync;
        public PatientStatus() { }

        public PatientStatus(string id, string title, string values, string description, string created, bool sync)
        {
            this.Id = id;
            this.Title = title;
            this.Values = values;
            this.Description = description;
            this.Created = created;
            this.Sync = sync;
        }

        static List<PatientStatus> p = new List<PatientStatus>();

        public string Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Values { get => values; set => values = value; }
        public string Description { get => description; set => description = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }

        public static List<PatientStatus> List()
        {
            string Q = "SELECT * FROM PatientStatus ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                PatientStatus ps = new PatientStatus(Reader["id"].ToString(), Reader["title"].ToString(), Reader["values"].ToString(), Reader["description"].ToString(),Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
    }

}

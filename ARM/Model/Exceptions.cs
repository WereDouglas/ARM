using ARM.DB;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
    public class Exceptions
    {
        private string id;
        private string message;
        private string created;
        private string process;     
        private bool sync;
        public Exceptions() { }

        public Exceptions(string id, string message, string created, string process, bool sync)
        {
            this.Id = id;
            this.Message = message;
            this.Created = created;
            this.Process = process;
            this.Sync = sync;
        }

        static List<Exceptions> p = new List<Exceptions>();

        public string Id { get => id; set => id = value; }
        public string Message { get => message; set => message = value; }
        public string Created { get => created; set => created = value; }
        public string Process { get => process; set => process = value; }
        public bool Sync { get => sync; set => sync = value; }

        public static List<Exceptions> List(string start,string end)
        {
            string Q = "SELECT * FROM exceptions WHERE  (created::date >= '" + start + "'::date AND  created::date <= '" + end + "'::date) ;";
           // string Q = "SELECT * FROM Exceptions ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Exceptions ps = new Exceptions(Reader["id"].ToString(), Reader["message"].ToString(), Reader["created"].ToString(),Reader["process"].ToString(), Convert.ToBoolean(Reader["sync"]));
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;

        }
    }

}

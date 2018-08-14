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
    public class Coverage
    {
        private string id;
        private string customerID;
        private string name;
        private string type;//state ,federal,private{company ,self out of pocket } , Employer group
        private string category;//state ,federal,private
        private string no;       
        private string created;
        private string sync;
        private string companyID;
		private string expires;
		public Coverage() { }

        public Coverage(string id, string customerID, string name, string type, string category, string no, string created, string sync, string companyID, string expires)
		{
            this.Id = id;
            this.CustomerID = customerID;
            this.Name = name;
            this.Type = type;
            this.Category = category;
            this.No = no;
            this.Created = created;
            this.Sync = sync;
            this.CompanyID = companyID;
			this.Expires = expires;
		}

        static List<Coverage> p = new List<Coverage>();

       

        public static List<Coverage> List()
        {
            p.Clear();
            string Q = "SELECT * FROM coverage ";
           
            MySqlDataReader Reader = MySQL.Reading(Q);
            while (Reader.Read())
            {
                Coverage ps = new Coverage(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["category"].ToString(), Reader["no"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["expires"].ToString());
				p.Add(ps);
            }
            DBConnect.CloseMySqlConn();
            return p;

        }
		static MySqlDataReader Reader;
		public static List<Coverage> List(string Q)
        {
     //       try
     //       {
     //           p.Clear();
               
     //           MySqlDataReader Reader = MySQL.Reading(Q);
     //           while (Reader.Read())
     //           {
     //               Coverage ps = new Coverage(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["category"].ToString(), Reader["no"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["expires"].ToString());
					//p.Add(ps);
     //           }
     //           DBConnect.CloseMySqlConn();
     //       }
     //       catch { }

			Reader = MySQL.Reading(Q);
			p = MySQL.DataReaderMapToList<Coverage>(Reader);
			return p;
        }
       
        static List<Coverage> c = new List<Coverage>();

        public string Id { get => id; set => id = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public string Category { get => category; set => category = value; }
        public string No { get => no; set => no = value; }
        public string Created { get => created; set => created = value; }
        public string Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }
		public string Expires { get => expires; set => expires = value; }

		private static Coverage k = new Coverage();
        public static Coverage Select(string id)
        {
            string Q = "SELECT * FROM coverage WHERE id = '" + id + "'";
           
            MySqlDataReader Reader = MySQL.Reading(Q);
            while (Reader.Read())
            {
                k = new Coverage(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["category"].ToString(), Reader["no"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["expires"].ToString());
			}
			DBConnect.CloseMySqlConn();
            return k;

        }
		public static Coverage SelectType(string customerID,string type)
		{
			string Q = "SELECT * FROM coverage WHERE type = '" + type + "' AND customerid = '"+customerID+"'";
			
			MySqlDataReader Reader = MySQL.Reading(Q);
			while (Reader.Read())
			{
				k = new Coverage(Reader["id"].ToString(), Reader["customerID"].ToString(), Reader["name"].ToString(), Reader["type"].ToString(), Reader["category"].ToString(), Reader["no"].ToString(), Reader["created"].ToString(), Reader["sync"].ToString(), Reader["companyID"].ToString(), Reader["expires"].ToString());
			}
			DBConnect.CloseMySqlConn();
			return k;

		}
	}

}

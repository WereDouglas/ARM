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
    public class Deliveries
    {
        private string id;
        private string date;
        private string no;
        private string itemID;
        private double total;
        private double qty;
        private double cost;
        private string created;
       private bool sync; private string companyID;
      

        public Deliveries() { }

        public Deliveries(string id, string date, string no, string itemID, double total, double qty, double cost, string created, bool sync,string companyID)
        {
            this.Id = id;
            this.Date = date;
            this.No = no;
            this.ItemID = itemID;
            this.Total = total;
            this.Qty = qty;
            this.Cost = cost;
            this.Created = created;
            this.Sync = sync;
            this.CompanyID = companyID;
        }

        static List<Deliveries> p = new List<Deliveries>();

        public string Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public string No { get => no; set => no = value; }
        public string ItemID { get => itemID; set => itemID = value; }
        public double Total { get => total; set => total = value; }
        public double Qty { get => qty; set => qty = value; }
        public double Cost { get => cost; set => cost = value; }
        public string Created { get => created; set => created = value; }
        public bool Sync { get => sync; set => sync = value; }
        public string CompanyID { get => companyID; set => companyID = value; }

       
        public static List<Deliveries> List()
        {
            p.Clear();
            string Q = "SELECT * FROM Deliveries ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Deliveries ps = new Deliveries(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["itemID"].ToString(), Convert.ToDouble(Reader["total"]), Convert.ToDouble(Reader["qty"]), Convert.ToDouble(Reader["cost"]), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
        public static List<Deliveries> ListNo(string no)
        {
            p.Clear();
            string Q = "SELECT * FROM Deliveries WHERE no = '"+no+"' ";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Deliveries ps = new Deliveries(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["itemID"].ToString(), Convert.ToDouble(Reader["total"]), Convert.ToDouble(Reader["qty"]), Convert.ToDouble(Reader["cost"]), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
        public static List<Deliveries> List(string Q)
        {
            p.Clear();
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                Deliveries ps = new Deliveries(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["itemID"].ToString(), Convert.ToDouble(Reader["total"]), Convert.ToDouble(Reader["qty"]), Convert.ToDouble(Reader["cost"]), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                p.Add(ps);
            }
            DBConnect.CloseConn();
            return p;
        }
        public static List<Deliveries> ListOnline(string Q)
        {
            try
            {
                p.Clear();
                DBConnect.OpenMySqlConn();
                MySqlDataReader Reader = DBConnect.ReadingMySql(Q);
                while (Reader.Read())
                {
                    Deliveries ps = new Deliveries(Reader["id"].ToString(), Reader["date"].ToString(), Reader["no"].ToString(), Reader["itemID"].ToString(), Convert.ToDouble(Reader["total"]), Convert.ToDouble(Reader["qty"]), Convert.ToDouble(Reader["cost"]), Reader["created"].ToString(), Convert.ToBoolean(Reader["sync"]), Reader["companyID"].ToString());
                    p.Add(ps);
                }
                DBConnect.CloseMySqlConn();

            }
            catch { }
            return p;
        }
    }

}

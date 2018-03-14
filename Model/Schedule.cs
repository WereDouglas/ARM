using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Model
{
  public class Schedule
    {
        private string id;
        private string clientID;
        private string empID;
        private string starts;
        private string ends;
        private string location;
        private string address;        
        private string details;       
        private string indicator;
        private string period;
        private string category;//appointment or shift 
        private string status;
        private string created;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string ClientID
        {
            get
            {
                return clientID;
            }

            set
            {
                clientID = value;
            }
        }

        public string EmpID
        {
            get
            {
                return empID;
            }

            set
            {
                empID = value;
            }
        }

        public string Starts
        {
            get
            {
                return starts;
            }

            set
            {
                starts = value;
            }
        }

        public string Ends
        {
            get
            {
                return ends;
            }

            set
            {
                ends = value;
            }
        }

        public string Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Details
        {
            get
            {
                return details;
            }

            set
            {
                details = value;
            }
        }

        public string Indicator
        {
            get
            {
                return indicator;
            }

            set
            {
                indicator = value;
            }
        }

        public string Period
        {
            get
            {
                return period;
            }

            set
            {
                period = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string Created
        {
            get
            {
                return created;
            }

            set
            {
                created = value;
            }
        }
        public Schedule() { }
        public Schedule(string id, string clientID, string empID, string starts, string ends, string location, string address, string details, string indicator, string period, string category, string status, string created)
        {
            this.Id = id;
            this.ClientID = clientID;
            this.EmpID = empID;
            this.Starts = starts;
            this.Ends = ends;
            this.Location = location;
            this.Address = address;
            this.Details = details;
            this.Indicator = indicator;
            this.Period = period;
            this.Category = category;
            this.Status = status;
            this.Created = created;
        }
        public static List<Schedule> List()
        {
            List<Schedule> events = new List<Schedule>();
            //string SQL = "SELECT * FROM events";


            //SQLiteDataReader Reader = DBConnect.ReadingLite(SQL);
            //while (Reader.Read())
            //{
            //    Events p = new Events(Reader["id"].ToString(), Reader["details"].ToString(), Reader["starts"].ToString(), Reader["ends"].ToString(), Reader["users"].ToString(), Reader["file"].ToString(), Reader["created"].ToString(), Reader["fileid"].ToString(), Reader["status"].ToString(), Reader["userid"].ToString(), Reader["dated"].ToString(), Reader["notif"].ToString(), Reader["priority"].ToString(), Reader["sync"].ToString(), Reader["cal"].ToString(), Reader["contact"].ToString(), Reader["email"].ToString(), Reader["department"].ToString(), Reader["orgid"].ToString(), Reader["cost"].ToString(), Reader["no"].ToString());
            //    events.Add(p);
            //}
            //Reader.Close();


            return events;

        }
    }
}

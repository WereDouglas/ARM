using ARM.DB;
using ARM.Model;
using ARM.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Sync
{
    public class Downloading
    {
        public Downloading() { }
        public static List<Users> u = new List<Users>();
        public static void User()
        {
            u = Users.ListOnline("SELECT * FROM users WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Downloading Users ... " + u.Count);
            foreach (var h in u)
            {
                string Query = "DELETE from users WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Users c = new Users(h.Id, h.Name, h.Email, h.Contact, h.Address, h.City, h.State, h.Zip, h.Category, h.Gender, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, h.Password, h.Image);
                if (DBConnect.InsertPostgre(c) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.Name.ToString());
                    Users u = new Users(h.Id, h.Name, h.Email, h.Contact, h.Address, h.City, h.State, h.Zip, h.Category, h.Gender, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, h.Password, h.Image);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Downloading Updating .. " + h.Name.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Downloading Users complete");
        }
        public static List<Customer> c = new List<Customer>();
        public static void Customers()
        {
            c = Customer.ListOnline("SELECT * FROM customer WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading Customer ... " + u.Count);
            foreach (var h in c)
            {
                string Query = "DELETE from customer WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Customer c = new Customer(h.Id, h.Name, h.Contact, h.Address, h.No, h.City, h.State, h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), h.Ssn, h.Dob, h.Category, true, h.Image);
                if (DBConnect.InsertPostgre(c) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Name.ToString());
                    Customer u = new Customer(h.Id, h.Name, h.Contact, h.Address, h.No, h.City, h.State, h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), h.Ssn, h.Dob, h.Category, true, h.Image);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Name.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading Customer Complete");
        }
        public static List<Schedule> s = new List<Schedule>();
        public static void Schedules()
        {
            s = Schedule.ListOnline("SELECT * FROM schedule WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading Schedule ... " + u.Count);
            foreach (var h in s)
            {
                string Query = "DELETE from schedule WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Schedule c = new Schedule(h.Id, h.Date, h.CustomerID, h.UserID, h.Starts, h.Ends, h.Location, h.Address, h.Details, h.Indicator, h.Period, h.Category, h.Status, h.Cost, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                if (DBConnect.InsertPostgre(c) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Starts.ToString());
                    Schedule u = new Schedule(h.Id, h.Date, h.CustomerID, h.UserID, h.Starts, h.Ends, h.Location, h.Address, h.Details, h.Indicator, h.Period, h.Category, h.Status, h.Cost, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Starts.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading Schedule Complete");
        }
        public static List<Item> i = new List<Item>();
        public static void Items()
        {
            i = Item.List("SELECT * FROM item WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading products ... " + u.Count);
            foreach (var h in i)
            {
                string Query = "DELETE from item WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Item p = new Item(h.Id, h.Name, h.Category, h.Type, h.Description, h.Cost, h.BatchNo, h.SerialNo, h.Barcode, h.UnitOfMeasure, h.MeasureDescription, h.Manufacturer, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, h.Image);
                if (DBConnect.InsertPostgre(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Name.ToString());
                    Item u = new Item(h.Id, h.Name, h.Category, h.Type, h.Description, h.Cost, h.BatchNo, h.SerialNo, h.Barcode, h.UnitOfMeasure, h.MeasureDescription, h.Manufacturer, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, h.Image);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Name.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading Item Complete");
        }

    }
}


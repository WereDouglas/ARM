using ARM.DB;
using ARM.Model;
using ARM.Util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Sync
{
    public class Uploading
    {
        public Uploading()
        {
        }
        public static List<Users> u = new List<Users>();

        public static void User()
        {
            u = Users.List("SELECT * FROM users WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading Users ... " + u.Count);
            foreach (var h in u)
            {
                string Query = "DELETE from users WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Users c = new Users(h.Id, h.Name, h.Email, h.Contact, h.Address, h.City, h.State, h.Zip, h.Category, h.Gender, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, h.Password, h.Image);             
                if (DBConnect.InsertMySQL(c) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Name.ToString());
                    Users u = new Users(h.Id, h.Name, h.Email, h.Contact, h.Address, h.City, h.State, h.Zip, h.Category, h.Gender, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, h.Password, h.Image);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Name.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading Users Complete");
        }
        public static List<Customer> c = new List<Customer>();

        public static void Customers()
        {
            c = Customer.List("SELECT * FROM customer WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading Customer ... " + c.Count);
            foreach (var h in c)
            {
                string Query = "DELETE from customer WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Customer c = new Customer(h.Id, h.Name,h.Contact, h.Address,h.No, h.City, h.State, h.Zip,DateTime.Now.ToString("dd-MM-yyyy H:m:s"), h.Ssn,h.Dob,h.Category,true, h.Image);
                if (DBConnect.InsertMySQL(c) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Name.ToString());
                    Customer u = new Customer(h.Id, h.Name, h.Contact, h.Address, h.No, h.City, h.State, h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), h.Ssn, h.Dob, h.Category, true, h.Image);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Name.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading Customer Complete");
        }
        public static List<Schedule> s = new List<Schedule>();
        public static void Schedules()
        {
            s = Schedule.List("SELECT * FROM schedule WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading Schedule ... " + s.Count);
            foreach (var h in s)
            {
                string Query = "DELETE from schedule WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);

                Schedule c = new Schedule(h.Id,h.Date,h.CustomerID,h.UserID,h.Starts,h.Ends,h.Location,h.Address,h.Details,h.Indicator,h.Period,h.Category,h.Status,h.Cost, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                if (DBConnect.InsertMySQL(c) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Starts.ToString());
                    Schedule u = new Schedule(h.Id, h.Date, h.CustomerID, h.UserID, h.Starts, h.Ends, h.Location, h.Address, h.Details, h.Indicator, h.Period, h.Category, h.Status, h.Cost, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Starts.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading Schedule Complete");
        }
        public static List<Company> p = new List<Company>();
        public static void Companys()
        {
            p = Company.List("SELECT * FROM company WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading Company ... " + p.Count);
            foreach (var h in p)
            {
                string Query = "DELETE from company WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Company p = new Company(h.Id,h.Name,h.Address,h.Contact,h.Email,h.Fax,h.Tel, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true,h.Image);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Name.ToString());
                    Company u = new Company(h.Id, h.Name, h.Address, h.Contact, h.Email, h.Fax, h.Tel, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, h.Image);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Name.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading Company Complete");
        }
        public static List<Item> i = new List<Item>();
        public static void Items()
        {
            i = Item.List("SELECT * FROM item WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading products ... " + i.Count);
            foreach (var h in i)
            {
                string Query = "DELETE from item WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Item p = new Item(h.Id,h.Name, h.Category, h.Type, h.Description, h.Cost, h.BatchNo,h.SerialNo,h.Barcode,h.UnitOfMeasure,h.MeasureDescription,h.Manufacturer, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, h.Image);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Name.ToString());
                    Item u = new Item(h.Id, h.Name, h.Category, h.Type, h.Description, h.Cost, h.BatchNo, h.SerialNo, h.Barcode, h.UnitOfMeasure, h.MeasureDescription, h.Manufacturer, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, h.Image);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Name.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading Item Complete");
        }
        public static List<Delivery> d = new List<Delivery>();
        public static void Deliverys()
        {
            d = Delivery.List("SELECT * FROM delivery WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading delivery ... " + d.Count);
            foreach (var h in d)
            {
                string Query = "DELETE from delivery WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Delivery p = new Delivery(h.Id,h.Date,h.No,h.Type,h.UserID,h.CustomerID,h.Comments,h.DeliveredBy,h.DateReceived,h.ReceivedBy,h.Signature,h.Total,DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Date.ToString());
                    Delivery u = new Delivery(h.Id, h.Date, h.No, h.Type, h.UserID, h.CustomerID, h.Comments, h.DeliveredBy, h.DateReceived, h.ReceivedBy, h.Signature, h.Total, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Date.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading delivery Complete");
        }
        public static List<Deliveries> y = new List<Deliveries>();
        public static void Deliverie()
        {
            y = Deliveries.List("SELECT * FROM deliveries WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading deliveries ... " +y.Count);
            foreach (var h in y)
            {
                string Query = "DELETE from deliveries WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Deliveries p = new Deliveries(h.Id,h.Date, h.No, h.ItemID, h.Total, h.Qty, h.Cost,DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Date.ToString());
                    Deliveries u = new Deliveries(h.Id, h.Date, h.No, h.ItemID, h.Total, h.Qty, h.Cost, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Date.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading deliveries Complete");
        }

    }
}

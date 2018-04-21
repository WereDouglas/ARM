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
                Customer c = new Customer(h.Id, h.Name, h.Contact, h.Address, h.No, h.City, h.State, h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), h.Ssn, h.Dob, h.Category, true, h.Image);
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
        public static List<Vendor> v = new List<Vendor>();

        public static void Vendors()
        {
            v = Vendor.List("SELECT * FROM vendor WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading Vendor ... " + v.Count);
            foreach (var h in v)
            {
                string Query = "DELETE from vendor WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Vendor c = new Vendor(h.Id, h.Name, h.Email, h.Contact, h.Address, h.No, h.City, h.State, h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), h.Category, true, h.Image);
                if (DBConnect.InsertMySQL(c) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Name.ToString());
                    Vendor u = new Vendor(h.Id, h.Name, h.Email, h.Contact, h.Address, h.No, h.City, h.State, h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), h.Category, true, h.Image);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Name.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading Vendors Complete");
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

                Schedule c = new Schedule(h.Id, h.Date, h.CustomerID, h.UserID, h.Starts, h.Ends, h.Location, h.Address, h.Details, h.Indicator, h.Period, h.Category, h.Status, h.Cost, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
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
                Company p = new Company(h.Id, h.Name, h.Address, h.Contact, h.Email, h.Fax, h.Tel, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, h.Image);
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
                Item p = new Item(h.Id, h.Name, h.Category, h.Type, h.Description, h.Cost, h.BatchNo, h.SerialNo, h.Barcode, h.UnitOfMeasure, h.MeasureDescription, h.Manufacturer, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, h.Image);
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
                Delivery p = new Delivery(h.Id, h.Date, h.No, h.Type, h.UserID, h.CustomerID, h.Comments, h.DeliveredBy, h.DateReceived, h.ReceivedBy, h.Signature, h.Total, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
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
            MedicalForm._Form1.FeedBack("Uploading deliveries ... " + y.Count);
            foreach (var h in y)
            {
                string Query = "DELETE from deliveries WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Deliveries p = new Deliveries(h.Id, h.Date, h.No, h.ItemID, h.Total, h.Qty, h.Cost, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
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
        public static List<Invoice> n = new List<Invoice>();
        public static void Invoices()
        {
            n = Invoice.List("SELECT * FROM invoice WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading invoice ... " + n.Count);
            foreach (var h in n)
            {
                string Query = "DELETE from invoice WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Invoice p = new Invoice(h.Id, h.Date, h.No, h.Type, h.Category, h.VendorID, h.CustomerID, h.Method, h.Total, h.Terms, h.Tax, h.Paid, h.Balance, h.Amount, h.ItemCount, h.UserID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Date.ToString());
                    Invoice u = new Invoice(h.Id, h.Date, h.No, h.Type, h.Category, h.VendorID, h.CustomerID, h.Method, h.Total, h.Terms, h.Tax, h.Paid, h.Balance, h.Amount, h.ItemCount, h.UserID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Date.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading invoice Complete");
        }
        public static List<Transaction> t = new List<Transaction>();
        public static void Transactions()
        {
            t = Transaction.List("SELECT * FROM transaction WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading transaction ... " + t.Count);
            foreach (var h in t)
            {
                string Query = "DELETE from transaction WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Transaction p = new Transaction(h.Id, h.Date, h.No, h.ItemID, h.Total, h.Qty, h.Cost, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Date.ToString());
                    Transaction u = new Transaction(h.Id, h.Date, h.No, h.ItemID, h.Total, h.Qty, h.Cost, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Date.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading transactions Complete");
        }
        public static List<Payment> k = new List<Payment>();
        public static void Payments()
        {
            k = Payment.List("SELECT * FROM payment WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading payment ... " + t.Count);
            foreach (var h in k)
            {
                string Query = "DELETE from payment WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Payment p = new Payment(h.Id, h.Date, h.No, h.Type, h.Method, h.Amount, h.Balance, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Date.ToString());
                    Payment u = new Payment(h.Id, h.Date, h.No, h.Type, h.Method, h.Amount, h.Balance, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Date.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading payment Complete");
        }

        public static List<Orders> o = new List<Orders>();
        public static void Order()
        {
            o = Orders.List("SELECT * FROM orders WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading orders ... " + o.Count);
            foreach (var h in o)
            {
                string Query = "DELETE from orders WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Orders p = new Orders(h.Id, h.CustomerID, h.UserID, h.ItemID, h.OrderDateTime, h.OrderBy, h.DispenseDateTime, h.DispenseBy, h.CustomerType, h.Diagnosis, h.Surgery, h.ClinicalDate, h.EquipmentLimits, h.EquipmentHeights, h.EquipmentWeights, h.EquipmentInstructions, h.EquipmentPeriod, h.SetupLocation, h.SetupDate, h.DischargeLocation, h.DischargeDate, h.Notification, h.NotificationDate, h.Authoriz, h.AuthorizationDate, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, h.Action, h.Other);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.DispenseBy.ToString());
                    Orders u = new Orders(h.Id, h.CustomerID, h.UserID, h.ItemID, h.OrderDateTime, h.OrderBy, h.DispenseDateTime, h.DispenseBy, h.CustomerType, h.Diagnosis, h.Surgery, h.ClinicalDate, h.EquipmentLimits, h.EquipmentHeights, h.EquipmentWeights, h.EquipmentInstructions, h.EquipmentPeriod, h.SetupLocation, h.SetupDate, h.DischargeLocation, h.DischargeDate, h.Notification, h.NotificationDate, h.Authoriz, h.AuthorizationDate, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, h.Action, h.Other);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.DispenseBy.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading orders Complete");
        }
        public static List<Instruction> j = new List<Instruction>();
        public static void Instructions()
        {
            j = Instruction.List("SELECT * FROM instrucions WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading instructions ... " + j.Count);
            foreach (var h in j)
            {
                string Query = "DELETE from instructions WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Instruction p = new Instruction(h.Id, h.CustomerID, h.UserID, h.ItemID, h.Date, h.Type, h.AltContact, h.Safety, h.Appropriate, h.AppropriateSelection, h.SafetyOther, h.Phone, h.EquipmentType, h.EquipmentOther, h.Additional, h.AdditionalNotes, h.FollowUp, h.Signature, h.KinName, h.KinContact, h.KinAddress, h.Reason, h.UserSignature, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Date.ToString());
                    Instruction u = new Instruction(h.Id, h.CustomerID, h.UserID, h.ItemID, h.Date, h.Type, h.AltContact, h.Safety, h.Appropriate, h.AppropriateSelection, h.SafetyOther, h.Phone, h.EquipmentType, h.EquipmentOther, h.Additional, h.AdditionalNotes, h.FollowUp, h.Signature, h.KinName, h.KinContact, h.KinAddress, h.Reason, h.UserSignature, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Date.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading instructions Complete");
        }
        public static List<Follow> a = new List<Follow>();
        public static void Follows()
        {
            a = Follow.List("SELECT * FROM follow WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading follow ... " + a.Count);
            foreach (var h in a)
            {
                string Query = "DELETE from follow WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Follow p = new Follow(h.Id, h.CustomerID, h.UserID, h.ItemID, h.Type, h.Diagnosis, h.Hospitalisation, h.Source, h.Length, h.Need, h.Goal, h.Results, h.Recommend, h.FollowVisit, h.FollowPhone, h.Next, h.Pu, h.Signature, h.Authoriser, h.Relationship, h.Reason, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Type.ToString());
                    Follow u = new Follow(h.Id, h.CustomerID, h.UserID, h.ItemID, h.Type, h.Diagnosis, h.Hospitalisation, h.Source, h.Length, h.Need, h.Goal, h.Results, h.Recommend, h.FollowVisit, h.FollowPhone, h.Next, h.Pu, h.Signature, h.Authoriser, h.Relationship, h.Reason, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Type.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading Follows Complete");
        }
        public static List<ItemReview> w = new List<ItemReview>();
        public static void ItemReveiews()
        {
            w = ItemReview.List("SELECT * FROM itemReview WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading item reviews... " + w.Count);
            foreach (var h in w)
            {
                string Query = "DELETE from itemReview WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                ItemReview p = new ItemReview(h.Id, h.FollowID, h.Title, h.Status, h.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Details.ToString());
                    ItemReview u = new ItemReview(h.Id, h.FollowID, h.Title, h.Status, h.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Details.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading item reviews Complete");
        }
        public static List<ItemStatus> q = new List<ItemStatus>();
        public static void ItemStatuses()
        {
            q = ItemStatus.List("SELECT * FROM itemStatus WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading item status... " + q.Count);
            foreach (var h in q)
            {
                string Query = "DELETE from itemStatus WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                ItemStatus p = new ItemStatus(h.Id, h.FollowID, h.Title, h.Status, h.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Details.ToString());
                    ItemReview u = new ItemReview(h.Id, h.FollowID, h.Title, h.Status, h.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Details.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading item status Complete");
        }

        public static List<Rate> b = new List<Rate>();
        public static void Rates()
        {
            b = Rate.List("SELECT * FROM rate WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading rates... " + b.Count);
            foreach (var h in b)
            {
                string Query = "DELETE from rate WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Rate p = new Rate(h.Id, h.UserID, h.Amount, h.Period, h.Units, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Amount.ToString());
                    Rate u = new Rate(h.Id, h.UserID, h.Amount, h.Period, h.Units, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Amount.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading item status Complete");
        }
        public static List<Account> l = new List<Account>();
        public static void Accounts()
        {
            l = Account.List("SELECT * FROM account WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading Accounts... " + l.Count);
            foreach (var h in l)
            {
                string Query = "DELETE from account WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Account p = new Account(h.Id, h.UserID, h.Bank, h.AccountNo, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Bank.ToString());
                    Account u = new Account(h.Id, h.UserID, h.Bank, h.AccountNo, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Bank.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading Accounts Complete");
        }
        public static List<Responsible> e = new List<Responsible>();
        public static void Repsonsibles()
        {
            e = Responsible.List("SELECT * FROM responsible WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading Responsible... " + e.Count);
            foreach (var h in e)
            {
                string Query = "DELETE from responsible WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Responsible p = new Responsible(h.Id, h.UserID, h.CustomerID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Id.ToString());
                    Responsible u = new Responsible(h.Id, h.UserID, h.CustomerID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Id.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading Patient  Complete");
        }
        public static List<Insurance> f = new List<Insurance>();
        public static void Insurances()
        {
            f = Insurance.List("SELECT * FROM insurance WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Uploading Insurance... " + f.Count);
            foreach (var h in f)
            {
                string Query = "DELETE from insurance WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Insurance p = new Insurance(h.Id, h.CustomerID,h.Name,h.Type,h.Image,h.No,h.Address,h.Contact,h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Uploading ... " + h.Id.ToString());
                    Insurance u = new Insurance(h.Id, h.CustomerID, h.Name, h.Type, h.Image, h.No, h.Address, h.Contact, h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true);
                    DBConnect.UpdatePostgre(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Id.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Uploading Insurance Complete");
        }



    }
}

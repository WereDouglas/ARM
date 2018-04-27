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
                Users c = new Users(h.Id, h.Name, h.Email, h.Contact, h.Address, h.City, h.State, h.Zip, h.Category, h.Gender, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true,Helper.CompanyID,h.Password, h.Image);
                if (DBConnect.InsertPostgre(c) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.Name.ToString());
                    Users u = new Users(h.Id, h.Name, h.Email, h.Contact, h.Address, h.City, h.State, h.Zip, h.Category, h.Gender, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true,Helper.CompanyID,h.Password, h.Image);
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
            MedicalForm._Form1.FeedBack("Downloading Customer ... " + u.Count);
            foreach (var h in c)
            {
                string Query = "DELETE from customer WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Customer c = new Customer(h.Id, h.Name, h.Contact, h.Address, h.No, h.City, h.State, h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), h.Ssn, h.Dob, h.Category, h.Height, h.Weight, true, Helper.CompanyID, h.Image);
                if (DBConnect.InsertPostgre(c) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.Name.ToString());
                    Customer u = new Customer(h.Id, h.Name, h.Contact, h.Address, h.No, h.City, h.State, h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), h.Ssn, h.Dob, h.Category, h.Height, h.Weight, true, Helper.CompanyID, h.Image);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Name.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Downloading Customer Complete");
        }
        public static List<Schedule> s = new List<Schedule>();
        public static void Schedules()
        {
            s = Schedule.ListOnline("SELECT * FROM schedule WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Downloading Schedule ... " + u.Count);
            foreach (var h in s)
            {
                string Query = "DELETE from schedule WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Schedule c = new Schedule(h.Id, h.Date, h.CustomerID, h.UserID, h.Starts, h.Ends, h.Location, h.Address, h.Details, h.Indicator, h.Period, h.Category, h.Status, h.Cost, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertPostgre(c) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.Starts.ToString());
                    Schedule u = new Schedule(h.Id, h.Date, h.CustomerID, h.UserID, h.Starts, h.Ends, h.Location, h.Address, h.Details, h.Indicator, h.Period, h.Category, h.Status, h.Cost, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Starts.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Downloading Schedule Complete");
        }
        public static List<Product> i = new List<Product>();
        public static void Items()
        {
            i = Product.ListOnline("SELECT * FROM item WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Downloading products ... " + u.Count);
            foreach (var h in i)
            {
                string Query = "DELETE from item WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Product p = new Product(h.Id, h.Name, h.Code, h.Category, h.Type, h.Description, h.Cost, h.Batch, h.Serial, h.Barcode, h.UnitOfMeasure, h.MeasureDescription, h.Manufacturer, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID, h.Image);
                if (DBConnect.InsertPostgre(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.Name.ToString());
                    Product u = new Product(h.Id, h.Name, h.Code, h.Category, h.Type, h.Description, h.Cost, h.Batch, h.Serial, h.Barcode, h.UnitOfMeasure, h.MeasureDescription, h.Manufacturer, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID, h.Image);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Name.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Downloading Item Complete");
        }
        public static List<Delivery> d = new List<Delivery>();
        public static void Deliverys()
        {
            d = Delivery.ListOnline("SELECT * FROM delivery WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Downloading delivery ... " + d.Count);
            foreach (var h in d)
            {
                string Query = "DELETE from delivery WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Delivery p = new Delivery(h.Id, h.Date, h.CaseID, h.OrderID, h.Type, h.PractitionerID, h.CustomerID, h.Comments, h.DeliveredBy, h.DateReceived, h.ReceivedBy, h.Signature, h.Reason, h.Name, Convert.ToDouble(h.Total), DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID);
                if (DBConnect.InsertPostgre(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.Date.ToString());
                    Delivery u = new Delivery(h.Id, h.Date, h.CaseID, h.OrderID, h.Type, h.PractitionerID, h.CustomerID, h.Comments, h.DeliveredBy, h.DateReceived, h.ReceivedBy, h.Signature, h.Reason, h.Name, Convert.ToDouble(h.Total), DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Date.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Downloading delivery Complete");
        }
      
        public static List<Invoice> n = new List<Invoice>();
        public static void Invoices()
        {
            n = Invoice.ListOnline("SELECT * FROM invoice WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Downloading invoice ... " + n.Count);
            foreach (var h in n)
            {
                string Query = "DELETE from invoice WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Invoice p = new Invoice(h.Id, h.Date, h.No, h.Type, h.Category, h.VendorID, h.CustomerID, h.Method, h.Total, h.Terms, h.Tax, h.Paid, h.Balance, h.Amount, h.ItemCount, h.UserID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertPostgre(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.Date.ToString());
                    Invoice u = new Invoice(h.Id, h.Date, h.No, h.Type, h.Category, h.VendorID, h.CustomerID, h.Method, h.Total, h.Terms, h.Tax, h.Paid, h.Balance, h.Amount, h.ItemCount, h.UserID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Date.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Downloading invoice Complete");
        }
        public static List<Transaction> t = new List<Transaction>();
        public static void Transactions()
        {
            t = Transaction.ListOnline("SELECT * FROM transaction WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Downloading transaction ... " + t.Count);
            foreach (var h in t)
            {
                string Query = "DELETE from transaction WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Transaction p = new Transaction(h.Id, h.Date, h.No, h.ItemID, h.Total, h.Qty, h.Cost, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertPostgre(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.Date.ToString());
                    Transaction u = new Transaction(h.Id, h.Date, h.No, h.ItemID, h.Total, h.Qty, h.Cost, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Date.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Downloading transactions Complete");
        }
        public static List<Payment> k = new List<Payment>();
        public static void Payments()
        {
            k = Payment.ListOnline("SELECT * FROM payment WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Downloading payment ... " + t.Count);
            foreach (var h in k)
            {
                string Query = "DELETE from payment WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Payment p = new Payment(h.Id, h.Date, h.No, h.Type, h.Method, h.Amount, h.Balance, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertPostgre(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.Date.ToString());
                    Payment u = new Payment(h.Id, h.Date, h.No, h.Type, h.Method, h.Amount, h.Balance, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Date.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Downloading payment Complete");
        }

        public static List<Orders> o = new List<Orders>();
        public static void Order()
        {
            o = Orders.ListOnline("SELECT * FROM orders WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Downloading orders ... " + o.Count);
            foreach (var h in o)
            {
                string Query = "DELETE from orders WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Orders p = new Orders(h.Id, h.CaseID, h.CustomerID, h.UserID, h.OrderDateTime, h.OrderBy, h.DispenseDateTime, h.DispenseBy, h.CustomerType, h.Diagnosis, h.Surgery, h.ClinicalDate, h.SetupLocation, h.SetupDate, h.DischargeLocation, h.DischargeDate, h.Notification, h.NotificationDate, h.Authoriz, h.AuthorizationDate, h.Action, h.Other, h.PractitionerID, h.Safety, h.Appropriate, h.AppropriateSelection, h.SafetyOther, h.Phone, h.EquipmentType, h.EquipmentOther, h.Additional, h.AdditionalNotes, h.FollowUp, h.Signature, h.EmergencyID, h.Reason, h.UserSignature, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID);
                if (DBConnect.InsertPostgre(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.DispenseBy.ToString());
                    Orders u = new Orders(h.Id, h.CaseID, h.CustomerID, h.UserID, h.OrderDateTime, h.OrderBy, h.DispenseDateTime, h.DispenseBy, h.CustomerType, h.Diagnosis, h.Surgery, h.ClinicalDate, h.SetupLocation, h.SetupDate, h.DischargeLocation, h.DischargeDate, h.Notification, h.NotificationDate, h.Authoriz, h.AuthorizationDate, h.Action, h.Other, h.PractitionerID, h.Safety, h.Appropriate, h.AppropriateSelection, h.SafetyOther, h.Phone, h.EquipmentType, h.EquipmentOther, h.Additional, h.AdditionalNotes, h.FollowUp, h.Signature, h.EmergencyID, h.Reason, h.UserSignature, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.DispenseBy.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Downloading orders Complete");
        }
        public static List<Instruction> j = new List<Instruction>();
        public static void Instructions()
        {
            j = Instruction.ListOnline("SELECT * FROM instruction WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Downloading instruction ... " + j.Count);
            foreach (var h in j)
            {
                string Query = "DELETE from instructions WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Instruction p = new Instruction(h.Id, h.CustomerID, h.UserID, h.ItemID, h.Date, h.Type, h.AltContact, h.Safety, h.Appropriate, h.AppropriateSelection, h.SafetyOther, h.Phone, h.EquipmentType, h.EquipmentOther, h.Additional, h.AdditionalNotes, h.FollowUp, h.Signature, h.KinName, h.KinContact, h.KinAddress, h.Reason, h.UserSignature, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertPostgre(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.Date.ToString());
                    Instruction u = new Instruction(h.Id, h.CustomerID, h.UserID, h.ItemID, h.Date, h.Type, h.AltContact, h.Safety, h.Appropriate, h.AppropriateSelection, h.SafetyOther, h.Phone, h.EquipmentType, h.EquipmentOther, h.Additional, h.AdditionalNotes, h.FollowUp, h.Signature, h.KinName, h.KinContact, h.KinAddress, h.Reason, h.UserSignature, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Date.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Downloading instructions Complete");
        }
        public static List<Follow> a = new List<Follow>();
        public static void Follows()
        {
            a = Follow.ListOnline("SELECT * FROM follow WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Downloading follow ... " + a.Count);
            foreach (var h in a)
            {
                string Query = "DELETE from follow WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Follow p = new Follow(h.Id, h.CustomerID, h.UserID, h.ItemID, h.Type, h.Diagnosis, h.Hospitalisation, h.Source, h.Length, h.Need, h.Goal, h.Results, h.Recommend, h.FollowVisit, h.FollowPhone, h.Next, h.Pu, h.Signature, h.Authoriser, h.Relationship, h.Reason, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertPostgre(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.Type.ToString());
                    Follow u = new Follow(h.Id, h.CustomerID, h.UserID, h.ItemID, h.Type, h.Diagnosis, h.Hospitalisation, h.Source, h.Length, h.Need, h.Goal, h.Results, h.Recommend, h.FollowVisit, h.FollowPhone, h.Next, h.Pu, h.Signature, h.Authoriser, h.Relationship, h.Reason, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Type.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Downloading Follows Complete");
        }
        public static List<ItemReview> w = new List<ItemReview>();
        public static void ItemReviews()
        {
            w = ItemReview.ListOnline("SELECT * FROM itemReview WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Downloading item reviews... " + w.Count);
            foreach (var h in w)
            {
                string Query = "DELETE from itemReview WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                ItemReview p = new ItemReview(h.Id, h.FollowID, h.Title, h.Status, h.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertPostgre(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.Details.ToString());
                    ItemReview u = new ItemReview(h.Id, h.FollowID, h.Title, h.Status, h.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Details.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Downloading item reviews Complete");
        }
        public static List<ItemStatus> q = new List<ItemStatus>();
        public static void ItemStatuses()
        {
            q = ItemStatus.ListOnline("SELECT * FROM itemStatus WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Downloading item status... " + q.Count);
            foreach (var h in q)
            {
                string Query = "DELETE from itemStatus WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                ItemStatus p = new ItemStatus(h.Id, h.FollowID, h.Title, h.Status, h.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertPostgre(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.Details.ToString());
                    ItemReview u = new ItemReview(h.Id, h.FollowID, h.Title, h.Status, h.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Details.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Downloading item status Complete");
        }

        public static List<Rate> b = new List<Rate>();
        public static void Rates()
        {
            b = Rate.ListOnline("SELECT * FROM rate WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Downloading rates... " + b.Count);
            foreach (var h in b)
            {
                string Query = "DELETE from rate WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Rate p = new Rate(h.Id, h.UserID, h.Amount, h.Period, h.Units, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertPostgre(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.Amount.ToString());
                    Rate u = new Rate(h.Id, h.UserID, h.Amount, h.Period, h.Units, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Amount.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Downloading item status Complete");
        }
        public static List<Account> l = new List<Account>();
        public static void Accounts()
        {
            l = Account.ListOnline("SELECT * FROM account WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Downloading Accounts... " + l.Count);
            foreach (var h in l)
            {
                string Query = "DELETE from account WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Account p = new Account(h.Id, h.UserID, h.Bank, h.AccountNo, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertPostgre(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.Bank.ToString());
                    Account u = new Account(h.Id, h.UserID, h.Bank, h.AccountNo, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Bank.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Downloading Accounts Complete");
        }
        public static List<Responsible> e = new List<Responsible>();
        public static void Repsonsibles()
        {
            e = Responsible.ListOnline("SELECT * FROM responsible WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Downloading Responsible... " + e.Count);
            foreach (var h in e)
            {
                string Query = "DELETE from responsible WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Responsible p = new Responsible(h.Id, h.UserID, h.CustomerID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertPostgre(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.Id.ToString());
                    Responsible u = new Responsible(h.Id, h.UserID, h.CustomerID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Id.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Downloading Patient  Complete");
        }
        public static List<Coverage> f = new List<Coverage>();
        public static void Coverages()
        {
            f = Coverage.ListOnline("SELECT * FROM coverage WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Downloading Coverage... " + f.Count);
            foreach (var h in f)
            {
                string Query = "DELETE from coverage WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Coverage p = new Coverage(h.Id, h.CustomerID, h.Name, h.Type, h.Category, h.No, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID);
                if (DBConnect.InsertPostgre(p) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.Id.ToString());
                    Coverage u = new Coverage(h.Id, h.CustomerID, h.Name, h.Type, h.Category, h.No, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Id.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Downloading Coverage Complete");
        }
        public static List<Vendor> v = new List<Vendor>();
        public static void Vendors()
        {
            v = Vendor.ListOnline("SELECT * FROM vendor WHERE sync = 'false'");
            MedicalForm._Form1.FeedBack("Downloading Vendor ... " + v.Count);
            foreach (var h in v)
            {
                string Query = "DELETE from vendor WHERE id ='" + h.Id + "'";
                DBConnect.QueryPostgre(Query);
                Vendor c = new Vendor(h.Id, h.Name, h.Email, h.Contact, h.Address, h.No, h.City, h.State, h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), h.Category, true,Helper.CompanyID,h.Image);
                if (DBConnect.InsertPostgre(c) != "")
                {
                    MedicalForm._Form1.FeedBack("Downloading ... " + h.Name.ToString());
                    Vendor u = new Vendor(h.Id, h.Name, h.Email, h.Contact, h.Address, h.No, h.City, h.State, h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), h.Category, true,Helper.CompanyID,h.Image);
                    DBConnect.UpdateMySql(u, h.Id);
                    MedicalForm._Form1.FeedBack("Updating .. " + h.Name.ToString());
                }
            }
            MedicalForm._Form1.FeedBack("Downloading Vendors Complete");
        }


    }
}


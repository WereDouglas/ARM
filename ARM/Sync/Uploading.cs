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
            u = Users.List("SELECT * FROM users");
            AdvancedForm._Form1.FeedBack("Uploading Users ... " + u.Count);
            foreach (var h in u)
            {
                string Query = "DELETE from users WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Users c = new Users(h.Id, h.Name, h.Email, h.Contact, h.Address, h.City, h.State, h.Zip, h.Category, h.Ssn, h.Speciality, h.Gender, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID, h.Password, h.Image);
                if (DBConnect.InsertMySQL(c) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.Name.ToString());
                    Users u = new Users(h.Id, h.Name, h.Email, h.Contact, h.Address, h.City, h.State, h.Zip, h.Category, h.Ssn, h.Speciality, h.Gender, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID, h.Password, h.Image);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.Name.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading Users Complete");
        }
        
        public static List<Customer> c = new List<Customer>();

        public static void Customers()
        {
            List<Customer> k = Customer.List("SELECT * FROM customer ");
            AdvancedForm._Form1.FeedBack("Uploading Customer ... " + k.Count);
            foreach (var h in k)
            {
                string Query = "DELETE from customer WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Customer c = new Customer(h.Id, h.Name, h.Contact, h.Address, h.No, h.City, h.State, h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), h.Ssn, h.Dob, h.Category, h.Height,h.Weight,h.Gender,true,Helper.CompanyID,h.Image);
                if (DBConnect.InsertMySQL(c) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.Name.ToString());
                    Customer u = new Customer(h.Id, h.Name, h.Contact, h.Address, h.No, h.City, h.State, h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), h.Ssn, h.Dob, h.Category, h.Height, h.Weight,h.Gender, true, Helper.CompanyID, h.Image);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.Name.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading Customer Complete");
        }
        public static List<Vendor> v = new List<Vendor>();
        public static void Vendors()
        {
            v = Vendor.List("SELECT * FROM vendor ");
            AdvancedForm._Form1.FeedBack("Uploading Vendor ... " + v.Count);
            foreach (var h in v)
            {
                string Query = "DELETE from vendor WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Vendor c = new Vendor(h.Id, h.Name, h.Email, h.Contact, h.Address, h.No, h.City, h.State, h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), h.Category, true,Helper.CompanyID,h.Image);
                if (DBConnect.InsertMySQL(c) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.Name.ToString());
                    Vendor u = new Vendor(h.Id, h.Name, h.Email, h.Contact, h.Address, h.No, h.City, h.State, h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), h.Category, true,Helper.CompanyID,h.Image);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.Name.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading Vendors Complete");
        }
        public static List<Schedule> s = new List<Schedule>();
        public static void Schedules()
        {
            s = Schedule.List("SELECT * FROM schedule ");
            AdvancedForm._Form1.FeedBack("Uploading Schedule ... " + s.Count);
            foreach (var h in s)
            {
                string Query = "DELETE from schedule WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);

                Schedule c = new Schedule(h.Id, h.Date, h.CustomerID, h.UserID, h.Starts, h.Ends, h.Location, h.Address, h.Details, h.Indicator, h.Period, h.Category, h.Status, h.Cost, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID,h.Week);
                if (DBConnect.InsertMySQL(c) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.Starts.ToString());
                    Schedule u = new Schedule(h.Id, h.Date, h.CustomerID, h.UserID, h.Starts, h.Ends, h.Location, h.Address, h.Details, h.Indicator, h.Period, h.Category, h.Status, h.Cost, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID,h.Week);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.Starts.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading Schedule Complete");
        }
        public static List<Company> p = new List<Company>();
        public static void Companys()
        {
            p = Company.List("SELECT * FROM company ");
            AdvancedForm._Form1.FeedBack("Uploading Company ... " + p.Count);
            foreach (var h in p)
            {
                string Query = "DELETE from company WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Company p = new Company(h.Id, h.Name,h.Contact, h.Email,h.Npi, h.Address, h.Office,h.ProviderID,h.Tin,h.OfficePhone,h.OfficeFax,h.City,h.Zip,h.State,h.Speciality, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true,Helper.CompanyID,h.Image);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.Name.ToString());
                    Company u = new Company(h.Id, h.Name, h.Contact, h.Email, h.Npi, h.Address, h.Office, h.ProviderID, h.Tin, h.OfficePhone, h.OfficeFax, h.City, h.Zip, h.State, h.Speciality, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID, h.Image);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.Name.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading Company Complete");
        }
        public static List<Product> i = new List<Product>();
        public static void Items()
        {
            i = Product.List("SELECT * FROM product ");
            AdvancedForm._Form1.FeedBack("Uploading products ... " + i.Count);
            foreach (var h in i)
            {
                string Query = "DELETE from product WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Product p = new Product(h.Id, h.Name,h.Code, h.Category, h.Type, h.Description, h.Cost, h.Batch, h.Serial, h.Barcode, h.UnitOfMeasure, h.MeasureDescription, h.Manufacturer, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true,Helper.CompanyID,h.Image);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.Name.ToString());
                    Product u = new Product(h.Id, h.Name, h.Code, h.Category, h.Type, h.Description, h.Cost, h.Batch, h.Serial, h.Barcode, h.UnitOfMeasure, h.MeasureDescription, h.Manufacturer, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID, h.Image);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.Name.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading Item Complete");
        }
        public static List<Delivery> d = new List<Delivery>();
        public static void Deliverys()
        {
            d = Delivery.List("SELECT * FROM delivery ");
            AdvancedForm._Form1.FeedBack("Uploading delivery ... " + d.Count);
            foreach (var h in d)
            {
                string Query = "DELETE from delivery WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Delivery p = new Delivery(h.Id, h.No, h.Date, h.CaseID, h.OrderID, h.Type, h.PractitionerID, h.CustomerID, h.Comments, h.DeliveredBy, h.DateReceived, h.ReceivedBy, h.Signature, h.Reason, h.Name, Convert.ToDouble(h.Total), DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.Date.ToString());
                    Delivery u = new Delivery(h.Id, h.No, h.Date, h.CaseID, h.OrderID, h.Type, h.PractitionerID, h.CustomerID, h.Comments, h.DeliveredBy, h.DateReceived, h.ReceivedBy, h.Signature, h.Reason, h.Name, Convert.ToDouble(h.Total), DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.Date.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading delivery Complete");
        }
       
        public static List<Invoice> n = new List<Invoice>();
        public static void Invoices()
        {
            n = Invoice.List("SELECT * FROM invoice ");
            AdvancedForm._Form1.FeedBack("Uploading invoice ... " + n.Count);
            foreach (var h in n)
            {
                string Query = "DELETE from invoice WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Invoice p = new Invoice(h.Id, h.Date, h.No, h.Type, h.Category, h.VendorID, h.CustomerID, h.Method, h.Total, h.Terms, h.Tax, h.Paid, h.Balance, h.Amount, h.ItemCount, h.UserID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.Date.ToString());
                    Invoice u = new Invoice(h.Id, h.Date, h.No, h.Type, h.Category, h.VendorID, h.CustomerID, h.Method, h.Total, h.Terms, h.Tax, h.Paid, h.Balance, h.Amount, h.ItemCount, h.UserID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.Date.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading invoice Complete");
        }
        public static List<Transaction> t = new List<Transaction>();
        public static void Transactions()
        {
            t = Transaction.List("SELECT * FROM transaction ");
            AdvancedForm._Form1.FeedBack("Uploading transaction ... " + t.Count);
            foreach (var h in t)
            {
                string Query = "DELETE from transaction WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Transaction p = new Transaction(h.Id, h.Date, h.No, h.ItemID, h.CaseID, h.DeliveryID, h.Qty, h.Cost, h.Units, h.Total, h.Tax, h.Coverage, h.Self, h.Payable, h.Limits, h.Setting, h.Period, h.Height, h.Weight, h.Instruction, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.Date.ToString());
                    Transaction u = new Transaction(h.Id, h.Date, h.No, h.ItemID, h.CaseID, h.DeliveryID, h.Qty, h.Cost, h.Units, h.Total, h.Tax, h.Coverage, h.Self, h.Payable, h.Limits, h.Setting, h.Period, h.Height, h.Weight, h.Instruction, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.Date.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading transactions Complete");
        }
        public static List<Payment> k = new List<Payment>();
        public static void Payments()
        {
            k = Payment.List("SELECT * FROM payment ");
            AdvancedForm._Form1.FeedBack("Uploading payment ... " + t.Count);
            foreach (var h in k)
            {
                string Query = "DELETE from payment WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Payment p = new Payment(h.Id, h.Date, h.No, h.Type, h.Method, h.Amount, h.Balance, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.Date.ToString());
                    Payment u = new Payment(h.Id, h.Date, h.No, h.Type, h.Method, h.Amount, h.Balance, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.Date.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading payment Complete");
        }

        public static List<Orders> o = new List<Orders>();
        public static void Order()
        {
            o = Orders.List("SELECT * FROM orders ");
            AdvancedForm._Form1.FeedBack("Uploading orders ... " + o.Count);
            foreach (var h in o)
            {
                string Query = "DELETE from orders WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Orders p = new Orders(h.Id,h.CaseID, h.CustomerID, h.UserID, h.OrderDateTime, h.OrderBy, h.DispenseDateTime, h.DispenseBy, h.CustomerType, h.Diagnosis, h.Surgery, h.ClinicalDate,h.SetupLocation,h.SetupDate,h.DischargeLocation,h.DischargeDate,h.Notification,h.NotificationDate,h.Authoriz,h.AuthorizationDate,h.Action,h.Other,h.PractitionerID,h.Safety,h.Appropriate,h.AppropriateSelection,h.SafetyOther,h.Phone,h.EquipmentType,h.EquipmentOther,h.Additional,h.AdditionalNotes,h.FollowUp,h.Signature,h.EmergencyID,h.Reason,h.UserSignature,DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true,Helper.CompanyID);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.DispenseBy.ToString());
                    Orders u = new Orders(h.Id, h.CaseID, h.CustomerID, h.UserID, h.OrderDateTime, h.OrderBy, h.DispenseDateTime, h.DispenseBy, h.CustomerType, h.Diagnosis, h.Surgery, h.ClinicalDate, h.SetupLocation, h.SetupDate, h.DischargeLocation, h.DischargeDate, h.Notification, h.NotificationDate, h.Authoriz, h.AuthorizationDate, h.Action, h.Other, h.PractitionerID, h.Safety, h.Appropriate, h.AppropriateSelection, h.SafetyOther, h.Phone, h.EquipmentType, h.EquipmentOther, h.Additional, h.AdditionalNotes, h.FollowUp, h.Signature, h.EmergencyID, h.Reason, h.UserSignature, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.DispenseBy.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading orders Complete");
        }
        public static List<Instruction> j = new List<Instruction>();
        public static void Instructions()
        {
            j = Instruction.List("SELECT * FROM instruction ");
            AdvancedForm._Form1.FeedBack("Uploading instructions ... " + j.Count);
            foreach (var h in j)
            {
                string Query = "DELETE from instruction WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Instruction p = new Instruction(h.Id, h.CustomerID, h.UserID, h.ItemID, h.Date, h.Type, h.AltContact, h.Safety, h.Appropriate, h.AppropriateSelection, h.SafetyOther, h.Phone, h.EquipmentType, h.EquipmentOther, h.Additional, h.AdditionalNotes, h.FollowUp, h.Signature, h.KinName, h.KinContact, h.KinAddress, h.Reason, h.UserSignature, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.Date.ToString());
                    Instruction u = new Instruction(h.Id, h.CustomerID, h.UserID, h.ItemID, h.Date, h.Type, h.AltContact, h.Safety, h.Appropriate, h.AppropriateSelection, h.SafetyOther, h.Phone, h.EquipmentType, h.EquipmentOther, h.Additional, h.AdditionalNotes, h.FollowUp, h.Signature, h.KinName, h.KinContact, h.KinAddress, h.Reason, h.UserSignature, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.Date.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading instructions Complete");
        }
        public static List<Follow> a = new List<Follow>();
        public static void Follows()
        {
            a = Follow.List("SELECT * FROM follow ");
            AdvancedForm._Form1.FeedBack("Uploading follow ... " + a.Count);
            foreach (var h in a)
            {
                string Query = "DELETE from follow WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Follow p = new Follow(h.Id, h.CustomerID, h.UserID, h.ItemID, h.Type, h.Diagnosis, h.Hospitalisation, h.Source, h.Length, h.Need, h.Goal, h.Results, h.Recommend, h.FollowVisit, h.FollowPhone, h.Next, h.Pu, h.Signature, h.Authoriser, h.Relationship, h.Reason, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.Type.ToString());
                    Follow u = new Follow(h.Id, h.CustomerID, h.UserID, h.ItemID, h.Type, h.Diagnosis, h.Hospitalisation, h.Source, h.Length, h.Need, h.Goal, h.Results, h.Recommend, h.FollowVisit, h.FollowPhone, h.Next, h.Pu, h.Signature, h.Authoriser, h.Relationship, h.Reason, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.Type.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading Follows Complete");
        }
        public static List<ItemReview> w = new List<ItemReview>();
        public static void ItemReviews()
        {
            w = ItemReview.ListUpload("SELECT * FROM productReview ");
            AdvancedForm._Form1.FeedBack("Uploading product reviews... " + w.Count);
            foreach (var h in w)
            {
                string Query = "DELETE from productReview WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                ItemReview p = new ItemReview(h.Id, h.FollowID, h.Title, h.Status, h.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.Details.ToString());
                    ItemReview u = new ItemReview(h.Id, h.FollowID, h.Title, h.Status, h.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.Details.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading product reviews Complete");
        }
        public static List<ItemStatus> q = new List<ItemStatus>();
        public static void ItemStatuses()
        {
            q = ItemStatus.ListUpload("SELECT * FROM productStatus ");
            AdvancedForm._Form1.FeedBack("Uploading product status... " + q.Count);
            foreach (var h in q)
            {
                string Query = "DELETE from productStatus WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                ItemStatus p = new ItemStatus(h.Id, h.FollowID, h.Title, h.Status, h.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.Details.ToString());
                    ItemReview u = new ItemReview(h.Id, h.FollowID, h.Title, h.Status, h.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.Details.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading product status Complete");
        }

        public static List<Rate> b = new List<Rate>();
        public static void Rates()
        {
            b = Rate.List("SELECT * FROM rate ");
            AdvancedForm._Form1.FeedBack("Uploading rates... " + b.Count);
            foreach (var h in b)
            {
                string Query = "DELETE from rate WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Rate p = new Rate(h.Id, h.UserID, h.Amount, h.Period, h.Units, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.Amount.ToString());
                    Rate u = new Rate(h.Id, h.UserID, h.Amount, h.Period, h.Units, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.Amount.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading product status Complete");
        }
        public static List<Account> l = new List<Account>();
        public static void Accounts()
        {
            l = Account.List("SELECT * FROM account ");
            AdvancedForm._Form1.FeedBack("Uploading Accounts... " + l.Count);
            foreach (var h in l)
            {
                string Query = "DELETE from account WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Account p = new Account(h.Id, h.UserID, h.Bank, h.AccountNo,h.Routing, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.Bank.ToString());
                    Account u = new Account(h.Id, h.UserID, h.Bank, h.AccountNo,h.Routing, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.Bank.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading Accounts Complete");
        }
        public static List<Responsible> e = new List<Responsible>();
        public static void Repsonsibles()
        {
            e = Responsible.List("SELECT * FROM responsible ");
            AdvancedForm._Form1.FeedBack("Uploading Responsible... " + e.Count);
            foreach (var h in e)
            {
                string Query = "DELETE from responsible WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Responsible p = new Responsible(h.Id, h.UserID, h.CustomerID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.Id.ToString());
                    Responsible u = new Responsible(h.Id, h.UserID, h.CustomerID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),true,Helper.CompanyID);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.Id.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading Patient  Complete");
        }
        public static List<Coverage> f = new List<Coverage>();
        public static void Insurances()
        {
            f = Coverage.List("SELECT * FROM coverage ");
            AdvancedForm._Form1.FeedBack("Uploading Insurance... " + f.Count);
            foreach (var h in f)
            {
                string Query = "DELETE from coverage WHERE id ='" + h.Id + "'";
                DBConnect.QueryMySql(Query);
                Coverage p = new Coverage(h.Id, h.CustomerID, h.Name, h.Type,h.Category, h.No, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID);
                if (DBConnect.InsertMySQL(p) != "")
                {
                    AdvancedForm._Form1.FeedBack("Uploading ... " + h.Id.ToString());
                    Coverage u = new Coverage(h.Id, h.CustomerID, h.Name, h.Type, h.Category, h.No, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), true, Helper.CompanyID);
                    DBConnect.UpdatePostgre(u, h.Id);
                    AdvancedForm._Form1.FeedBack("Updating .. " + h.Id.ToString());
                }
            }
            AdvancedForm._Form1.FeedBack("Uploading Insurance Complete");
        }
      


    }
}

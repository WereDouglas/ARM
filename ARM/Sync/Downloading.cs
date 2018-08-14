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
			GenericCollection.users.Clear();
			List<Users> u = Users.List("SELECT * FROM users");
			ProcessWindow._Form1.FeedBack("Downloading Users ... " + u.Count);
			foreach (var h in u)
			{
				ProcessWindow._Form1.FeedBack("Adding ... " + h.Name.ToString());
				Users c = new Users(h.Id, h.Name, h.Email, h.Contact, h.Address, h.City, h.State, h.Zip, h.Category, h.Ssn, h.Speciality, h.Gender, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID, h.Password, h.Image, h.Department, h.Active, h.Level);
				GenericCollection.users.Add(c);
			}
			ProcessWindow._Form1.FeedBack("Downloading Users complete");
		}
		public static List<Practitioner> p = new List<Practitioner>();
		public static void Practitioners()
		{
			GenericCollection.practitioners.Clear();
			List<Practitioner> u = Practitioner.List("SELECT * FROM practitioner");
			ProcessWindow._Form1.FeedBack("Downloading practitioners ... " + u.Count);
			foreach (var h in u)
			{
				ProcessWindow._Form1.FeedBack("Adding ... " + h.Name.ToString());
				Practitioner c = new Practitioner(h.Id,h.Name, h.CustomerID, h.Contact,h.Npi, h.Address,h.Office,h.ProviderID,h.Tin,h.OfficePhone,h.OfficeFax, h.City,h.Zip, h.State, h.Speciality, h.Sub, h.Gender, h.Type,h.Created,h.Sync, Helper.CompanyID, h.Image);
				GenericCollection.practitioners.Add(c);
			}
			ProcessWindow._Form1.FeedBack("Downloading Practitioners complete");
		}
		public static List<Customer> c = new List<Customer>();
		public static void Customers()
		{
			GenericCollection.customers.Clear();
			c = Customer.List("SELECT * FROM customer order by no ASC");
			ProcessWindow._Form1.FeedBack("Downloading Customer ... " + u.Count);
			foreach (var h in c)
			{
				ProcessWindow._Form1.FeedBack("Downloading ... " + h.Name.ToString());
				Customer c = new Customer(h.Id, h.Name, h.Contact, h.Address, h.No, h.City, h.State, h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), h.Ssn, h.Dob, h.Category, h.Height, h.Weight, h.Gender, "true", Helper.CompanyID, h.Image, h.Race);
				GenericCollection.customers.Add(c);

			}
			ProcessWindow._Form1.FeedBack("Downloading Customer Complete");
		}
		public static List<Coverage> f = new List<Coverage>();
		public static void Coverages()
		{
			GenericCollection.coverage.Clear();
			f = Coverage.List("SELECT * FROM coverage ");
			ProcessWindow._Form1.FeedBack("Downloading Coverage... " + f.Count);
			foreach (var h in f)
			{
				Coverage p = new Coverage(h.Id, h.CustomerID, h.Name, h.Type, h.Category, h.No, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID, h.Expires);
				ProcessWindow._Form1.FeedBack("Downloading ... " + h.Id.ToString());
				Coverage u = new Coverage(h.Id, h.CustomerID, h.Name, h.Type, h.Category, h.No, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID, h.Expires);
				GenericCollection.coverage.Add(u);

			}
			ProcessWindow._Form1.FeedBack("Downloading Coverage Complete");
		}
		public static List<Schedule> s = new List<Schedule>();
		public static void Schedules()
		{
			GenericCollection.schedules.Clear();
			s = Schedule.ListOnline("SELECT * FROM schedule");
			ProcessWindow._Form1.FeedBack("Downloading Schedule ... " + u.Count);
			foreach (var h in s)
			{
				Schedule c = new Schedule(h.Id, h.Date, h.CustomerID, h.UserID, h.Starts, h.Ends, h.Location, h.Address, h.Details, h.Indicator, h.Period, h.Category, h.Status, h.Cost, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID, h.Week);
				GenericCollection.schedules.Add(c);
				ProcessWindow._Form1.FeedBack("Downloading ... " + h.Starts.ToString());
			}
			ProcessWindow._Form1.FeedBack("Downloading Schedules Complete");
		}
		public static List<Rate> b = new List<Rate>();
		public static void Rates()
		{
			GenericCollection.rates.Clear();
			b = Rate.ListOnline("SELECT * FROM rate ");
			ProcessWindow._Form1.FeedBack("Downloading rates... " + b.Count);
			foreach (var h in b)
			{
				Rate p = new Rate(h.Id, h.UserID, h.Amount, h.Period, h.Units, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
				GenericCollection.rates.Add(p);
				ProcessWindow._Form1.FeedBack("Updating .. ....." + h.Amount.ToString());
			}
			ProcessWindow._Form1.FeedBack("Downloading rates complete");
		}
		public static List<Account> l = new List<Account>();
		public static void Accounts()
		{
			GenericCollection.accounts.Clear();
			l = Account.ListOnline("SELECT * FROM account");
			ProcessWindow._Form1.FeedBack("Downloading Accounts... " + l.Count);
			foreach (var h in l)
			{
				Account p = new Account(h.Id, h.UserID, h.Bank, h.AccountNo, h.Routing, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
				GenericCollection.accounts.Add(p);
				ProcessWindow._Form1.FeedBack("Downloading ... " + h.Bank.ToString());
			}
			ProcessWindow._Form1.FeedBack("Downloading Accounts Complete");
		}
		public static List<Responsible> e = new List<Responsible>();
		public static void Responsibles()
		{
			GenericCollection.responsibles.Clear();
			e = Responsible.ListOnline("SELECT * FROM responsible");
			ProcessWindow._Form1.FeedBack("Downloading Responsible... " + e.Count);
			foreach (var h in e)
			{
				Responsible p = new Responsible(h.Id, h.UserID, h.CustomerID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
				GenericCollection.responsibles.Add(p);

			}
			ProcessWindow._Form1.FeedBack("Downloading Responsibility  Complete");
		}
		public static List<Emergency> em = new List<Emergency>();
		public static void Emergencies()
		{
			GenericCollection.emergencies.Clear();
			List<Emergency> u = Emergency.List("SELECT * FROM emergency");
			ProcessWindow._Form1.FeedBack("Downloading emergency contacts... " + u.Count);
			foreach (var h in u)
			{
				ProcessWindow._Form1.FeedBack("Adding ... " + h.Name.ToString());
				Emergency c = new Emergency(h.Id, h.CustomerID,h.Name, h.Contact,h.Address,h.No,h.City,h.State,h.Zip, h.Gender, h.Relationship, h.Created, h.Sync, Helper.CompanyID, h.Image);
				GenericCollection.emergencies.Add(c);
			}
			ProcessWindow._Form1.FeedBack("Downloading Emergency complete");
		}
		public static List<Pay> py = new List<Pay>();
		public static void Pays()
		{
			GenericCollection.pay.Clear();
			List<Pay> u = Pay.ListOnline("SELECT * FROM pay");
			ProcessWindow._Form1.FeedBack("Downloading Payments... " + u.Count);
			foreach (var h in u)
			{
				ProcessWindow._Form1.FeedBack("Adding ... " + h.Date.ToString());
				Pay c = new Pay(h.Id,h.Date,h.No,h.UserID,h.Method,h.Starts,h.Ends,h.Week,h.Rate,h.Hours,h.Amount,h.OvertimeHrs,h.OvertimeRate,h.OvertimePay,h.Deductions,h.Payment,h.Paid,h.Created,Helper.CompanyID);
				GenericCollection.pay.Add(c);
			}
			ProcessWindow._Form1.FeedBack("Downloading payment complete");
		}
		public static List<Product> i = new List<Product>();
		public static void Items()
		{
			i = Product.List("SELECT * FROM product WHERE companyID ='" + Helper.CompanyID + "' ");
			ProcessWindow._Form1.FeedBack("Downloading products ... " + u.Count);
			foreach (var h in i)
			{
				string Query = "DELETE from product WHERE id ='" + h.Id + "'";
				MySQL.Query(Query);
				
				Product p = new Product(h.Id, h.Name, h.Code, h.Category, h.Type, h.Description, h.Cost, h.Batch, h.Serial, h.Barcode, h.UnitOfMeasure, h.MeasureDescription, h.Manufacturer, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID, h.Image, h.Expires);
				if (MySQL.Insert(p) != "")
				{
					ProcessWindow._Form1.FeedBack("Downloading ... " + h.Name.ToString());
					Product u = new Product(h.Id, h.Name, h.Code, h.Category, h.Type, h.Description, h.Cost, h.Batch, h.Serial, h.Barcode, h.UnitOfMeasure, h.MeasureDescription, h.Manufacturer, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID, h.Image, h.Expires);
					DBConnect.UpdateMySql(u, h.Id);
					ProcessWindow._Form1.FeedBack("Updating .. " + h.Name.ToString());
				}
			}
			ProcessWindow._Form1.FeedBack("Downloading Item Complete");
		}
		public static List<Delivery> d = new List<Delivery>();
		public static void Deliverys()
		{
			d = Delivery.List("SELECT * FROM delivery WHERE companyID ='" + Helper.CompanyID + "' ");
			ProcessWindow._Form1.FeedBack("Downloading delivery ... " + d.Count);
			foreach (var h in d)
			{
				string Query = "DELETE from delivery WHERE id ='" + h.Id + "'";
				MySQL.Query(Query);
				Delivery p = new Delivery(h.Id, h.No, h.Date, h.Deliveries, h.Followup, h.Pickup, h.Type, h.PractitionerID, h.CustomerID, h.Comments, h.DeliveredBy, h.DateReceived, h.ReceivedBy, h.Signature, h.Reason, h.Name, Convert.ToDouble(h.Total), DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
				if (MySQL.Insert(p) != "")
				{
					ProcessWindow._Form1.FeedBack("Downloading ... " + h.Date.ToString());
					Delivery u = new Delivery(h.Id, h.No, h.Date, h.Deliveries, h.Followup, h.Pickup, h.Type, h.PractitionerID, h.CustomerID, h.Comments, h.DeliveredBy, h.DateReceived, h.ReceivedBy, h.Signature, h.Reason, h.Name, Convert.ToDouble(h.Total), DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
					DBConnect.UpdateMySql(u, h.Id);
					ProcessWindow._Form1.FeedBack("Updating .. " + h.Date.ToString());
				}
			}
			ProcessWindow._Form1.FeedBack("Downloading delivery Complete");
		}
		public static List<Invoice> n = new List<Invoice>();
		public static void Invoices()
		{
			n = Invoice.ListOnline("SELECT * FROM invoice WHERE companyID ='" + Helper.CompanyID + "' ");
			ProcessWindow._Form1.FeedBack("Downloading invoice ... " + n.Count);
			foreach (var h in n)
			{
				string Query = "DELETE from invoice WHERE id ='" + h.Id + "'";
				MySQL.Query(Query);
				Invoice p = new Invoice(h.Id, h.Date, h.No, h.Type, h.Category, h.VendorID, h.CustomerID, h.Method, h.Total, h.Terms, h.Tax, h.Paid, h.Balance, h.Amount, h.ItemCount, h.UserID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
				if (MySQL.Insert(p) != "")
				{
					ProcessWindow._Form1.FeedBack("Downloading ... " + h.Date.ToString());
					Invoice u = new Invoice(h.Id, h.Date, h.No, h.Type, h.Category, h.VendorID, h.CustomerID, h.Method, h.Total, h.Terms, h.Tax, h.Paid, h.Balance, h.Amount, h.ItemCount, h.UserID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
					DBConnect.UpdateMySql(u, h.Id);
					ProcessWindow._Form1.FeedBack("Updating .. " + h.Date.ToString());
				}
			}
			ProcessWindow._Form1.FeedBack("Downloading invoice Complete");
		}
		public static List<CaseTransaction> t = new List<CaseTransaction>();
		public static void CaseTransactions()
		{
			t = CaseTransaction.List("SELECT * FROM transaction WHERE companyID ='" + Helper.CompanyID + "' ");
			ProcessWindow._Form1.FeedBack("Downloading transaction ... " + t.Count);
			foreach (var h in t)
			{
				string Query = "DELETE from transaction WHERE id ='" + h.Id + "'";
				MySQL.Query(Query);
				CaseTransaction p = new CaseTransaction(h.Id, h.Date, h.No, h.ItemID, h.CaseID, h.DeliveryID, h.Qty, h.Cost, h.Units, h.Total, h.Tax, h.Coverage, h.Self, h.Payable, h.Limits, h.Setting, h.Period, h.Height, h.Weight, h.Instruction, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
				if (MySQL.Insert(p) != "")
				{
					ProcessWindow._Form1.FeedBack("Downloading ... " + h.Date.ToString());
					CaseTransaction u = new CaseTransaction(h.Id, h.Date, h.No, h.ItemID, h.CaseID, h.DeliveryID, h.Qty, h.Cost, h.Units, h.Total, h.Tax, h.Coverage, h.Self, h.Payable, h.Limits, h.Setting, h.Period, h.Height, h.Weight, h.Instruction, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
					DBConnect.UpdateMySql(u, h.Id);
					ProcessWindow._Form1.FeedBack("Updating .. " + h.Date.ToString());
				}
			}
			ProcessWindow._Form1.FeedBack("Downloading transactions Complete");
		}
		public static List<Payment> k = new List<Payment>();
		public static void Payments()
		{
			k = Payment.ListOnline("SELECT * FROM payment WHERE companyID ='" + Helper.CompanyID + "' ");
			ProcessWindow._Form1.FeedBack("Downloading payment ... " + t.Count);
			foreach (var h in k)
			{
				string Query = "DELETE from payment WHERE id ='" + h.Id + "'";
				MySQL.Query(Query);
				Payment p = new Payment(h.Id, h.Date, h.No, h.Type, h.Method, h.Amount, h.Balance, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
				if (MySQL.Insert(p) != "")
				{
					ProcessWindow._Form1.FeedBack("Downloading ... " + h.Date.ToString());
					Payment u = new Payment(h.Id, h.Date, h.No, h.Type, h.Method, h.Amount, h.Balance, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
					DBConnect.UpdateMySql(u, h.Id);
					ProcessWindow._Form1.FeedBack("Updating .. " + h.Date.ToString());
				}
			}
			ProcessWindow._Form1.FeedBack("Downloading payment Complete");
		}

		public static List<Orders> o = new List<Orders>();
		public static void Order()
		{
			o = Orders.ListOnline("SELECT * FROM orders WHERE companyID ='" + Helper.CompanyID + "' ");
			ProcessWindow._Form1.FeedBack("Downloading orders ... " + o.Count);
			foreach (var h in o)
			{
				string Query = "DELETE from orders WHERE id ='" + h.Id + "'";
				MySQL.Query(Query);
				Orders p = new Orders(h.Id, h.No, h.CustomerID, h.UserID, h.OrderDate, h.OrderTime, h.OrderBy, h.DispenseDate, h.DispenseTime, h.DispenseBy, h.CustomerType, h.Diagnosis, h.Surgery, h.ClinicalDate, h.Instructions, h.Hospital, h.Home, h.PreopRm, h.PreopHome, h.PostopRm, h.RoomNo, h.SetupDate, h.DateNeeded, h.Facility, h.Clinic, h.Other, h.Notified, h.Authorised, h.Insurance, h.Contacted, h.Sent, h.Returned, h.DateSent, h.DateReturned, h.PractitionerID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
				if (MySQL.Insert(p) != "")
				{
					ProcessWindow._Form1.FeedBack("Downloading ... " + h.DispenseBy.ToString());
					Orders u = new Orders(h.Id, h.No, h.CustomerID, h.UserID, h.OrderDate, h.OrderTime, h.OrderBy, h.DispenseDate, h.DispenseTime, h.DispenseBy, h.CustomerType, h.Diagnosis, h.Surgery, h.ClinicalDate, h.Instructions, h.Hospital, h.Home, h.PreopRm, h.PreopHome, h.PostopRm, h.RoomNo, h.SetupDate, h.DateNeeded, h.Facility, h.Clinic, h.Other, h.Notified, h.Authorised, h.Insurance, h.Contacted, h.Sent, h.Returned, h.DateSent, h.DateReturned, h.PractitionerID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
					DBConnect.UpdateMySql(u, h.Id);
					ProcessWindow._Form1.FeedBack("Updating .. " + h.DispenseBy.ToString());
				}
			}
			ProcessWindow._Form1.FeedBack("Downloading orders Complete");
		}
		public static List<Instruction> j = new List<Instruction>();
		public static void Instructions()
		{
			j = Instruction.List("SELECT * FROM instruction WHERE companyID ='" + Helper.CompanyID + "' ");
			ProcessWindow._Form1.FeedBack("Downloading instruction ... " + j.Count);
			foreach (var h in j)
			{
				string Query = "DELETE from instructions WHERE id ='" + h.Id + "'";
				MySQL.Query(Query);
				Instruction p = new Instruction(h.Id, h.No, h.CustomerID, h.AltContact, h.Date, h.Initial, h.Followup, h.Type, h.Delivered, h.Safety, h.Pathways, h.Operation, h.Environment, h.Rugs, h.Fire, h.Cord, h.Issues, h.Electrical, h.Inouts, h.Appropriate, h.Understand, h.Returns, h.Caregiver, h.SafetyOther, h.PhysicalLimit, h.Ambulatory, h.Bath, h.Beds, h.Seat, h.Scooter, h.Manual, h.Power, h.Handling, h.EquipmentOther, h.Rights, h.Available, h.Privacy, h.Standards, h.Demonstration, h.Cleaning, h.Letter, h.Complaint, h.Warranty, h.Instructions, h.Aob, h.Notes, h.Visit, h.Phone, h.PatientSign, h.Employee, h.EmployeeSign, h.KinName, h.OtherSign, h.KinContact, h.Relationship, h.Representative, h.Reason, h.UserSignature, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID, Helper.UserID);
				if (MySQL.Insert(p) != "")
				{
					ProcessWindow._Form1.FeedBack("Downloading ... " + h.Date.ToString());
					Instruction u = new Instruction(h.Id, h.No, h.CustomerID, h.AltContact, h.Date, h.Initial, h.Followup, h.Type, h.Delivered, h.Safety, h.Pathways, h.Operation, h.Environment, h.Rugs, h.Fire, h.Cord, h.Issues, h.Electrical, h.Inouts, h.Appropriate, h.Understand, h.Returns, h.Caregiver, h.SafetyOther, h.PhysicalLimit, h.Ambulatory, h.Bath, h.Beds, h.Seat, h.Scooter, h.Manual, h.Power, h.Handling, h.EquipmentOther, h.Rights, h.Available, h.Privacy, h.Standards, h.Demonstration, h.Cleaning, h.Letter, h.Complaint, h.Warranty, h.Instructions, h.Aob, h.Notes, h.Visit, h.Phone, h.PatientSign, h.Employee, h.EmployeeSign, h.KinName, h.OtherSign, h.KinContact, h.Relationship, h.Representative, h.Reason, h.UserSignature, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID, Helper.UserID);
					DBConnect.UpdateMySql(u, h.Id);
					ProcessWindow._Form1.FeedBack("Updating .. " + h.Date.ToString());
				}
			}
			ProcessWindow._Form1.FeedBack("Downloading instructions Complete");
		}
		public static List<Follow> a = new List<Follow>();
		public static void Follows()
		{
			a = Follow.ListOnline("SELECT * FROM follow WHERE companyID ='" + Helper.CompanyID + "' ");
			ProcessWindow._Form1.FeedBack("Downloading follow ... " + a.Count);
			foreach (var h in a)
			{
				string Query = "DELETE from follow WHERE id ='" + h.Id + "'";
				MySQL.Query(Query);
				Follow p = new Follow(h.Id, h.CustomerID, h.UserID, h.ItemID, h.Type, h.Diagnosis, h.Hospitalisation, h.Source, h.Length, h.Need, h.Goal, h.Results, h.Recommend, h.FollowVisit, h.FollowPhone, h.Next, h.Pu, h.Signature, h.Authoriser, h.Relationship, h.Reason, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
				if (MySQL.Insert(p) != "")
				{
					ProcessWindow._Form1.FeedBack("Downloading ... " + h.Type.ToString());
					Follow u = new Follow(h.Id, h.CustomerID, h.UserID, h.ItemID, h.Type, h.Diagnosis, h.Hospitalisation, h.Source, h.Length, h.Need, h.Goal, h.Results, h.Recommend, h.FollowVisit, h.FollowPhone, h.Next, h.Pu, h.Signature, h.Authoriser, h.Relationship, h.Reason, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
					DBConnect.UpdateMySql(u, h.Id);
					ProcessWindow._Form1.FeedBack("Updating .. " + h.Type.ToString());
				}
			}
			ProcessWindow._Form1.FeedBack("Downloading Follows Complete");
		}
		public static List<ItemReview> w = new List<ItemReview>();
		public static void ItemReviews()
		{
			w = ItemReview.ListOnline("SELECT * FROM itemReview WHERE companyID ='" + Helper.CompanyID + "' ");
			ProcessWindow._Form1.FeedBack("Downloading product reviews... " + w.Count);
			foreach (var h in w)
			{
				string Query = "DELETE from itemReview WHERE id ='" + h.Id + "'";
				MySQL.Query(Query);
				ItemReview p = new ItemReview(h.Id, h.FollowID, h.Title, h.Status, h.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
				if (MySQL.Insert(p) != "")
				{
					ProcessWindow._Form1.FeedBack("Downloading ... " + h.Details.ToString());
					ItemReview u = new ItemReview(h.Id, h.FollowID, h.Title, h.Status, h.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
					DBConnect.UpdateMySql(u, h.Id);
					ProcessWindow._Form1.FeedBack("Updating .. " + h.Details.ToString());
				}
			}
			ProcessWindow._Form1.FeedBack("Downloading product reviews Complete");
		}
		public static List<ItemStatus> q = new List<ItemStatus>();
		public static void ItemStatuses()
		{
			q = ItemStatus.ListOnline("SELECT * FROM itemStatus WHERE companyID ='" + Helper.CompanyID + "' ");
			ProcessWindow._Form1.FeedBack("Downloading product status... " + q.Count);
			foreach (var h in q)
			{
				string Query = "DELETE from itemStatus WHERE id ='" + h.Id + "'";
				MySQL.Query(Query);
				ItemStatus p = new ItemStatus(h.Id, h.FollowID, h.Title, h.Status, h.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
				if (MySQL.Insert(p) != "")
				{
					ProcessWindow._Form1.FeedBack("Downloading ... " + h.Details.ToString());
					ItemReview u = new ItemReview(h.Id, h.FollowID, h.Title, h.Status, h.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "true", Helper.CompanyID);
					DBConnect.UpdateMySql(u, h.Id);
					ProcessWindow._Form1.FeedBack("Updating .. " + h.Details.ToString());
				}
			}
			ProcessWindow._Form1.FeedBack("Downloading product status Complete");
		}


		public static List<Vendor> v = new List<Vendor>();
		public static void Vendors()
		{
			v = Vendor.List("SELECT * FROM vendor WHERE companyID ='" + Helper.CompanyID + "' ");
			ProcessWindow._Form1.FeedBack("Downloading Vendor ... " + v.Count);
			foreach (var h in v)
			{
				string Query = "DELETE from vendor WHERE id ='" + h.Id + "'";
				MySQL.Query(Query);
				Vendor c = new Vendor(h.Id, h.Name, h.Email, h.Contact, h.Address, h.No, h.City, h.State, h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), h.Category, "true", Helper.CompanyID, h.Image);
				if (MySQL.Insert(c) != "")
				{
					ProcessWindow._Form1.FeedBack("Downloading ... " + h.Name.ToString());
					Vendor u = new Vendor(h.Id, h.Name, h.Email, h.Contact, h.Address, h.No, h.City, h.State, h.Zip, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), h.Category, "true", Helper.CompanyID, h.Image);
					DBConnect.UpdateMySql(u, h.Id);
					ProcessWindow._Form1.FeedBack("Updating .. " + h.Name.ToString());
				}
			}
			ProcessWindow._Form1.FeedBack("Downloading Vendors Complete");
		}


	}
}


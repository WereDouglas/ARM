﻿using ARM.DB;
using ARM.Model;
using ARM.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ARM
{
	public partial class OrderIntakeForm : MetroFramework.Forms.MetroForm
	{
		Dictionary<string, string> UserDictionary = new Dictionary<string, string>();
		Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
		Dictionary<string, string> kinDictionary = new Dictionary<string, string>();
		Dictionary<string, bool> SetupDictionary = new Dictionary<string, bool>();
		Dictionary<string, bool> DischargeDictionary = new Dictionary<string, bool>();
		Dictionary<string, bool> ActionDictionary = new Dictionary<string, bool>();
		Dictionary<string, string> PractitionerDictionary = new Dictionary<string, string>();
		Dictionary<string, string> ProductDictionary = new Dictionary<string, string>();
		Dictionary<string, string> CoverDictionary = new Dictionary<string, string>();

		Dictionary<string, bool> TypeDictionary = new Dictionary<string, bool>();
		Dictionary<string, bool> PlaceDictionary = new Dictionary<string, bool>();

		Dictionary<string, bool> SafetyDictionary = new Dictionary<string, bool>();
		Dictionary<string, bool> AppropriateDictionary = new Dictionary<string, bool>();
		Dictionary<string, bool> EquipmentDictionary = new Dictionary<string, bool>();
		Dictionary<string, bool> AdditionalDictionary = new Dictionary<string, bool>();

		string CustomerID;
		string UserID;
		string OrderID;
		string CaseID;
		string EmergencyID;
		string PractitionerID;
		double Total = 0;

		private Orders o;
		private Cases cs;
		public OrderIntakeForm(string orderID)
		{
			InitializeComponent();
			AutoCompleteUser();
			AutoCompleteCustomer();
			AutoCompleteEmergency();

			GenericCollection.transactions = new List<Transaction>();
			if (!string.IsNullOrEmpty(orderID))
			{
				OrderID = orderID;
				LoadEdit(OrderID);
				
				try
				{

				}
				catch (Exception m)
				{
					Helper.Exceptions(m.Message + "Loading order intake form for editing ");

				}

			}
			if (string.IsNullOrEmpty(orderID))
			{
				
				updateBtn.Visible = false;
				try
				{
					noTxt.Text = (DBConnect.Max("SELECT MAX(CAST(no AS DOUBLE PRECISION)) FROM orders") + 1).ToString();
				}
				catch
				{
					noTxt.Text = " 1 ";
				}
			}
			
			printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
		}
		private void LoadCase(string id)
		{
			

			

			try
			{
				//CustomerID = CustomerDictionary[customerCbx.Text];
				c = new Customer();//.Select(ItemID);
				c = Customer.Select(CustomerID);
				subscriberInfoTxt.Text = "Name: " + c.Name + "\t DOB: " + c.Dob + " \r\n Address: " + c.Address + "\r\n City/state: " + c.City + " " + c.State + "\t Zip: " + c.Zip + " \r\n  Phone: " + c.Contact + "\t Soc.Sec.#: " + c.Ssn;

				System.Drawing.Image img = Helper.Base64ToImage(c.Image);
				System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
				cusPbx.Image = bmp;
				GraphicsPath gp = new GraphicsPath();
				gp.AddEllipse(cusPbx.DisplayRectangle);
				cusPbx.Region = new Region(gp);
				cusPbx.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			catch { }
			//try
			//{
			string Q = "SELECT * FROM coverage WHERE customerID='" + CustomerID + "' ";
			foreach (Coverage c in Coverage.List(Q))
			{
				insuranceInfoTxt.Text = insuranceInfoTxt.Text + "\r\n " + c.Type + "\r\n" + "Name: " + c.Name + "\t ID# : " + c.No + " \r\n  " + " \r\n  Type: " + c.Type;
			}

			//}
			//catch { }

			try
			{
				
				Practitioner c = new Practitioner();//.Select(ItemID);
				c = Practitioner.Select(PractitionerID);
				userTxt.Text = "Name: " + c.Name + "\t Speciality" + c.Speciality + " \r\n Address: " + c.Address + "\r\n City/state: " + c.City + " " + c.State + "\t Zip: " + c.Zip + " \r\n  Phone: " + c.Contact + "\t";

				System.Drawing.Image img = Helper.Base64ToImage(c.Image);
				System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
				userPbx.Image = bmp;
				GraphicsPath gp = new GraphicsPath();
				gp.AddEllipse(cusPbx.DisplayRectangle);
				userPbx.Region = new Region(gp);
				userPbx.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			catch { }
			string Qs = "SELECT * FROM casetransaction WHERE caseID = '" + noTxt.Text + "'";
			foreach (CaseTransaction j in CaseTransaction.List(Qs))
			{
				//try
				//{

				Transaction t = new Transaction(j.Id, j.Date, j.No, j.ItemID, j.CaseID, j.DeliveryID, j.Qty, j.Cost, j.Units, j.Total, j.Tax, j.Coverage, j.Self, j.Payable, j.Limits, j.Setting, j.Period, j.Height, j.Weight, j.Instruction, j.Created, false, Helper.CompanyID);
				GenericCollection.transactions.Add(t);
				//}
				//catch { }

			}
			LoadTransactions();
		}


		private void LoadEdit(string id)
		{
			submitBtn.Visible = false;
			OrderID = id;
			o = new Orders();//.Select(UsersID);
			o = Orders.Select(OrderID);
			CustomerID = o.CustomerID;
			CaseID = o.No;
			CustomerID = o.CustomerID;
			PractitionerID = o.PractitionerID;
		
			noTxt.Text = o.No;
			orderDateTxt.Text = Convert.ToDateTime(o.OrderDateTime).ToString("dd-MM-yyyy");
			recievedCbx.Text = o.OrderBy;
			dispenseDateTxt.Text = Convert.ToDateTime(o.DispenseDateTime).ToString("dd-MM-yyyy");
			dispensedCbx.Text = o.DispenseBy;
			recievedCbx.Text = o.OrderBy;
			diagnosisTxt.Text = o.Diagnosis;
			surgeryTxt.Text = o.Surgery;
			LoadCase(o.No);
			
			setupDate.Text = Convert.ToDateTime(o.SetupDate).ToString("dd-MM-yyyy");			
			
			neededDateTxt.Text = Convert.ToDateTime(o.DateNeeded).ToString("dd-MM-yyyy");
			roomTxt.Text = o.RoomNo;
			if (o.Hospital == "Yes") {hospitalChk.Checked = true; } else { hospitalChk.Checked = false; }
			if (o.PreopRm == "Yes") {preRmChk.Checked = true; } else { preRmChk.Checked = false; }
			if (o.PostopRm == "Yes") { postRmChk.Checked = true; } else { postRmChk.Checked = false; }
			if (o.Home == "Yes") { homeChk.Checked = true; } else { homeChk.Checked = false; }
			if (o.PreopHome == "Yes") { preHomeChk.Checked = true; } else { preHomeChk.Checked = false; }
			if (o.Clinic == "Yes") {clinicChk.Checked = true; } else { clinicChk.Checked = false; }
			if (o.Facility == "Yes") { facilityChk.Checked = true; } else { facilityChk.Checked = false; }
			if (o.Notified == "Yes") { notifiedChk.Checked = true; } else { notifiedChk.Checked = false; }
			if (o.Authorised == "Yes") {authorisationChk.Checked = true; } else { authorisationChk.Checked = false; }
			if (o.Insurance == "Yes") { insuranceChk.Checked = true; } else { insuranceChk.Checked = false; }
			if (o.Contacted == "Yes") { contactedChk.Checked = true; } else { contactedChk.Checked = false; }
			if (o.Sent == "Yes") { cmnSentChk.Checked = true; } else { cmnSentChk.Checked = false; }
			if (o.Returned == "Yes") { cmnReturnedChk.Checked = true; } else { cmnReturnedChk.Checked = false; }
			dateSentTxt.Text = Convert.ToDateTime(o.DateSent).ToString("dd-MM-yyyy");
			dateReturnedTxt.Text = Convert.ToDateTime(o.DateReturned).ToString("dd-MM-yyyy");
			otherTxt.Text = o.Other;
			try
			{
				PractitionerID = o.PractitionerID;
				Practitioner c = new Practitioner();//.Select(ItemID);
				c = Practitioner.Select(PractitionerID);
				userTxt.Text = "Name: " + c.Name + "\t Speciality" + c.Speciality + " \r\n Address: " + c.Address + "\r\n City/state: " + c.City + " " + c.State + "\t Zip: " + c.Zip + " \r\n  Phone: " + c.Contact + "\t";

				System.Drawing.Image img = Helper.Base64ToImage(c.Image);
				System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
				userPbx.Image = bmp;
				GraphicsPath gp = new GraphicsPath();
				gp.AddEllipse(cusPbx.DisplayRectangle);
				userPbx.Region = new Region(gp);
				userPbx.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			catch { }

			otherTxt.Text = o.Other;
			recievedCbx.Text = o.OrderBy;
			dispensedCbx.Text = o.DispenseBy;
			dispenseDateTxt.Text = Convert.ToDateTime(o.DispenseDateTime).ToString();
			diagnosisTxt.Text = o.Diagnosis;
			surgeryTxt.Text = o.Surgery;
			otherTxt.Text = o.Other;


			try
			{
				//CustomerID = CustomerDictionary[customerCbx.Text];
				c = new Customer();//.Select(ItemID);
				c = Customer.Select(o.CustomerID);
				subscriberInfoTxt.Text = "Name: " + c.Name + "\t DOB: " + c.Dob + " \r\n Address: " + c.Address + "\r\n City/state: " + c.City + " " + c.State + "\t Zip: " + c.Zip + " \r\n  Phone: " + c.Contact + "\t Soc.Sec.#: " + c.Ssn;

				System.Drawing.Image img = Helper.Base64ToImage(c.Image);
				System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
				cusPbx.Image = bmp;
				GraphicsPath gp = new GraphicsPath();
				gp.AddEllipse(cusPbx.DisplayRectangle);
				cusPbx.Region = new Region(gp);
				cusPbx.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			catch { }
			try
			{
				string Q = "SELECT * FROM coverage WHERE customerID = '" + o.CustomerID + "' ";
				foreach (Coverage c in Coverage.List(Q))
				{
					insuranceInfoTxt.Text = insuranceInfoTxt.Text + "\r\n" + "Name: " + c.Name + "\t ID# : " + c.No + " \r\n  " + " \r\n  Type: " + c.Type;
				}

			}
			catch { }
			LoadTransactions();

		}
		private void metroLabel1_Click(object sender, EventArgs e)
		{

		}

		private void button4_Click(object sender, EventArgs e)
		{

		}


		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{

			if (string.IsNullOrEmpty(PractitionerID))
			{
				MessageBox.Show("Please select a Doctor  ");
			}
			string hospital = hospitalChk.Checked ? "Yes" : "No";
			string preopRm = preRmChk.Checked ? "Yes" : "No";		
			string postopRm = postRmChk.Checked ? "Yes" : "No";
			string home = homeChk.Checked ? "Yes" : "No";
			string preopHome = preHomeChk.Checked ? "Yes" : "No";
			string facility = facilityChk.Checked ? "Yes" : "No";
			string clinic = clinicChk.Checked ? "Yes" : "No";
			string notified = notifiedChk.Checked ? "Yes" : "No";
			string authorisation = authorisationChk.Checked ? "Yes" : "No";
			string insurance =insuranceChk.Checked ? "Yes" : "No";
			string contacted = contactedChk.Checked ? "Yes" : "No";
			string sent =cmnSentChk.Checked ? "Yes" : "No";
			string returned = cmnReturnedChk.Checked ? "Yes" : "No";

			string id = Guid.NewGuid().ToString();
			if (MessageBox.Show("YES or NO?", "Save information ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				foreach (Transaction t in GenericCollection.transactions)
				{
					CaseTransaction c = new CaseTransaction(t.Id, Convert.ToDateTime(orderDateTxt.Text).ToString("dd-MM-yyyy"), noTxt.Text, t.ItemID, noTxt.Text, "", t.Qty, t.Cost, t.Units, t.Total, t.Tax, t.Coverage, t.Self, t.Payable, t.Limits, t.Setting, t.Period, t.Height, t.Weight, t.Instruction, t.Created, false, Helper.CompanyID);
					string saving = DBConnect.InsertPostgre(c);
					if (saving != "")
					{
						Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(saving), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
						DBConnect.InsertPostgre(q);
					}
				}
				foreach (ItemCoverage t in GenericCollection.itemCoverage)
				{
					ItemCoverage c = new ItemCoverage(t.Id, t.TransactionID, t.ItemID, t.CoverageID, t.Percentage, t.Amount, t.Created, false, Helper.CompanyID);
					string mg = DBConnect.InsertPostgre(c);
					if (mg != "")
					{
						Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(mg), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
						DBConnect.InsertPostgre(q);
					}
				}
				Orders i = new Orders(id, noTxt.Text, CustomerID, Helper.UserID, Convert.ToDateTime(orderDateTxt.Text).ToString("dd-MM-yyyy"), recievedCbx.Text, Convert.ToDateTime(dispenseDateTxt.Text).ToString("dd-MM-yyyy"), dispensedCbx.Text,typeCbx.Text, diagnosisTxt.Text, surgeryTxt.Text, Convert.ToDateTime(clinicalDateTxt.Text).ToString("dd-MM-yyyy"),specificTxt.Text,hospital,home,preopRm,preopHome,postopRm,roomTxt.Text,Convert.ToDateTime(setupDate.Text).ToString("dd-MM-yyyy"),Convert.ToDateTime(neededDateTxt.Text).ToString("dd-MM-yyyy"),facility,clinic,otherTxt.Text,notified,authorisation,insurance,contacted,sent,returned,Convert.ToDateTime(dateSentTxt.Text).ToString("dd-MM-yyyy"), Convert.ToDateTime(dateReturnedTxt.Text).ToString("dd-MM-yyyy"),PractitionerID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID);
				string save = DBConnect.InsertPostgre(i);
				if (save != "")
				{
					Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
					DBConnect.InsertPostgre(q);
					MessageBox.Show("Information Saved");
					this.Close();
				}
			}
			else
			{
				MessageBox.Show("Report can not be Generated unless information is saved !");
			}
		}
		private void AutoCompleteUser()
		{

			AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
			UserDictionary.Clear();
			foreach (Users v in Users.List())
			{
				AutoItem.Add((v.Name));
				if (!UserDictionary.ContainsKey(v.Name))
				{
					UserDictionary.Add(v.Name, v.Id);
					recievedCbx.Items.Add(v.Name);
					dispensedCbx.Items.Add(v.Name);
					userCbx.Items.Add(v.Name);
				}
			}
			userCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
			userCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
			userCbx.AutoCompleteCustomSource = AutoItem;

		}

		private void AutoCompleteEmergency()
		{
			AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
			kinDictionary.Clear();
			string Q = "SELECT * FROM emergency WHERE customerID = '" + CustomerID + "' ";
			foreach (Emergency v in Emergency.List(Q))
			{
				AutoItem.Add((v.Name));

				if (!kinDictionary.ContainsKey(v.Name))
				{
					kinDictionary.Add(v.Name, v.Id);
					// kinCbx.Items.Add(v.Name);
				}
			}

		}
		private void AutoCompleteCustomer()
		{
			AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
			CustomerDictionary.Clear();
			foreach (Customer c in Customer.List())
			{
				AutoItem.Add((c.Name));

				if (!CustomerDictionary.ContainsKey(c.Name))
				{
					CustomerDictionary.Add(c.Name, c.Id);
					customerCbx.Items.Add(c.Name);

				}
			}
			customerCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
			customerCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
			customerCbx.AutoCompleteCustomSource = AutoItem;
		}
		Customer c;
		Coverage ins;
		Users u;

		private void userCbx_SelectedIndexChanged(object sender, EventArgs e)
		{


		}
		string ItemID;
		Product i;
		private void productCbx_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			//Print(panel1);
			OrderReport form = new OrderReport(noTxt.Text);//Print(panel1);
			form.Show();
		}
		public void Print(System.Windows.Forms.Panel pnl)
		{
			panel1 = pnl;
			GetPrintArea(pnl);
			previewdlg.Document = printdoc1;
			try
			{
				previewdlg.ShowDialog();
			}
			catch { }
		}
		//Rest of the code
		Bitmap MemoryImage;
		public void GetPrintArea(Panel pnl)
		{
			MemoryImage = new Bitmap(pnl.Width, pnl.Height);
			pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			if (MemoryImage != null)
			{
				e.Graphics.DrawImage(MemoryImage, 0, 0);
				base.OnPaint(e);
			}
		}
		void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
		{
			Rectangle pagearea = e.PageBounds;
			e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			using (CustomerDemo form = new CustomerDemo(CustomerID, "Patient"))
			{
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{
					// LoadingCalendarLite();
				}
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{

		}
		Product k = new Product();
		DataTable t = new DataTable();

		public void LoadTransactions()
		{
			// create and execute query  
			t = new DataTable();
			t.Columns.Add("id");
			t.Columns.Add("ItemID");
			t.Columns.Add("Product");
			t.Columns.Add("Qty");
			t.Columns.Add("Cost");
			t.Columns.Add("Total");
			t.Columns.Add("Limit");
			t.Columns.Add("Setting");
			t.Columns.Add("Period");
			t.Columns.Add("Height");
			t.Columns.Add("Weight");
			t.Columns.Add("Instruction");
			t.Columns.Add(new DataColumn("Delete", typeof(Image)));

			Image delete = new Bitmap(Properties.Resources.Cancel_16);
			string Q = "SELECT * FROM CaseTransaction WHERE no = '" + noTxt.Text + "'";
			foreach (Transaction j in GenericCollection.transactions)
			{
				try
				{
					k = Product.Select(j.ItemID);
					t.Rows.Add(new object[] { j.Id, j.ItemID, k.Name, j.Qty, j.Cost.ToString("N0"), j.Total.ToString("N0"), j.Limits, j.Setting, j.Period, j.Height, j.Weight, j.Instruction, delete });

				}
				catch (Exception m)
				{
					MessageBox.Show("" + m.Message);
					Helper.Exceptions(m.Message + "Viewing users {each transaction list }" + j.ItemID);
				}
			}
			Total = Transaction.List(Q).Sum(r => r.Total);
			totalLbl.Text = Total.ToString("N0");

			dtGrid.DataSource = t;

			dtGrid.AllowUserToAddRows = false;
			// dtGrid.Columns["View"].DefaultCellStyle.BackColor = Color.LightGreen;
			//  dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;

			dtGrid.Columns["id"].Visible = false;
			dtGrid.Columns["ItemID"].Visible = false;
		}

		private void kinCbx_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				// EmergencyID = kinDictionary[kinCbx.Text];
				Emergency c = new Emergency();//.Select(ItemID);
				c = Emergency.Select(EmergencyID);
				// emergencyDetails.Text = "Name: " + c.Name + "\t \r\n Address: " + c.Address + "\r\n City/state: " + c.City + " " + c.State + "\t Zip: " + c.Zip + " \r\n  Phone: " + c.Contact + "\t Relationship" + c.Relationship + "\t ";

			}
			catch { }
		}

		private void updateBtn_Click(object sender, EventArgs e)
		{
			string hospital = hospitalChk.Checked ? "Yes" : "No";
			string preopRm = preRmChk.Checked ? "Yes" : "No";
			string postopRm = postRmChk.Checked ? "Yes" : "No";
			string home = homeChk.Checked ? "Yes" : "No";
			string preopHome = preHomeChk.Checked ? "Yes" : "No";
			string facility = facilityChk.Checked ? "Yes" : "No";
			string clinic = clinicChk.Checked ? "Yes" : "No";
			string notified = notifiedChk.Checked ? "Yes" : "No";
			string authorisation = authorisationChk.Checked ? "Yes" : "No";
			string insurance = insuranceChk.Checked ? "Yes" : "No";
			string contacted = contactedChk.Checked ? "Yes" : "No";
			string sent = cmnSentChk.Checked ? "Yes" : "No";
			string returned = cmnReturnedChk.Checked ? "Yes" : "No";


			var DischargeJson = JsonConvert.SerializeObject(DischargeDictionary);
			var ActionJson = JsonConvert.SerializeObject(ActionDictionary);
			var SetupJson = JsonConvert.SerializeObject(SetupDictionary);
			string id = Guid.NewGuid().ToString();
			if (MessageBox.Show("YES or NO?", "Update this Order? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{

				Orders i = new Orders(OrderID, noTxt.Text, CustomerID, Helper.UserID, Convert.ToDateTime(orderDateTxt.Text).ToString("dd-MM-yyyy"), recievedCbx.Text, Convert.ToDateTime(dispenseDateTxt.Text).ToString("dd-MM-yyyy"), dispensedCbx.Text, typeCbx.Text, diagnosisTxt.Text, surgeryTxt.Text, Convert.ToDateTime(clinicalDateTxt.Text).ToString("dd-MM-yyyy"), specificTxt.Text, hospital, home, preopRm, preopHome, postopRm, roomTxt.Text, Convert.ToDateTime(setupDate.Text).ToString("dd-MM-yyyy"), Convert.ToDateTime(neededDateTxt.Text).ToString("dd-MM-yyyy"), facility, clinic, otherTxt.Text, notified, authorisation, insurance, contacted, sent, returned, Convert.ToDateTime(dateSentTxt.Text).ToString("dd-MM-yyyy"), Convert.ToDateTime(dateReturnedTxt.Text).ToString("dd-MM-yyyy"), PractitionerID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID);
				string save = DBConnect.UpdatePostgre(i, OrderID);
				Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
				DBConnect.InsertPostgre(q);

				MessageBox.Show("Information Updated ! ");
				this.Close();


			}
		}

		private void button7_Click_1(object sender, EventArgs e)
		{
			using (AddPurchase form = new AddPurchase(noTxt.Text, noTxt.Text, Convert.ToDateTime(orderDateTxt.Text).ToString("dd-MM-yyyy"), CustomerID))
			{
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{
					LoadTransactions();
				}
			}
		}
		private void AutoCompletePractitioner(string customerID)
		{
			AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
			PractitionerDictionary.Clear();
			string Q = "SELECT * FROM practitioner WHERE customerID = '" + CustomerID + "'";
			foreach (Practitioner c in Practitioner.List(Q))
			{
				AutoItem.Add((c.Name));
				if (!PractitionerDictionary.ContainsKey(c.Name))
				{
					PractitionerDictionary.Add(c.Name, c.Id);
					practitionerCbx.Items.Add(c.Name);
				}
			}
		}

		private void customerCbx_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				CustomerID = CustomerDictionary[customerCbx.Text];
				c = new Customer();//.Select(ItemID);
				c = Customer.Select(CustomerID);
				subscriberInfoTxt.Text = "Name: " + c.Name + "\t DOB: " + c.Dob + " \r\n Address: " + c.Address + "\r\n City/state: " + c.City + " " + c.State + "\t Zip: " + c.Zip + " \r\n  Phone: " + c.Contact + "\t Soc.Sec.#: " + c.Ssn + "\t Gender: " + c.Gender;

				System.Drawing.Image img = Helper.Base64ToImage(c.Image);
				System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
				cusPbx.Image = bmp;
				GraphicsPath gp = new GraphicsPath();
				gp.AddEllipse(cusPbx.DisplayRectangle);
				cusPbx.Region = new Region(gp);
				cusPbx.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			catch { }
			AutoCompletePractitioner(CustomerID);
			AutoCompleteCoverage(CustomerID);
			//try
			//{
			string Q = "SELECT * FROM coverage WHERE customerID='" + CustomerID + "' ";
			foreach (Coverage c in Coverage.List(Q))
			{
				insuranceInfoTxt.Text = insuranceInfoTxt.Text + "\r\n " + c.Type + "\r\n" + "Name: " + c.Name + "\t ID# : " + c.No + " \r\n  " + " \r\n  Type: " + c.Type;
			}
			//}
			//catch { }
		}
		private void AutoCompleteCoverage(string cusID)
		{
			AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
			CoverDictionary.Clear();
			string Q = "SELECT * FROM coverage WHERE customerID = '" + cusID + "' ";
			foreach (Coverage c in Coverage.List(Q))
			{
				AutoItem.Add((c.Name));

				if (!CoverDictionary.ContainsKey(c.Name))
				{
					CoverDictionary.Add(c.Name, c.Id);
					//	coverageCbx.Items.Add(c.Name);
				}
			}
			//productTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
			//productTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
			//productTxt.AutoCompleteCustomSource = AutoItem;

		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			using (CustomerDemo form = new CustomerDemo(null, "Patient"))
			{
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{
					AutoCompleteCustomer();
				}
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			using (InsuranceDialog form = new InsuranceDialog(CustomerID))
			{
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{

				}
			}
		}

		private void button4_Click_1(object sender, EventArgs e)
		{
			using (PractitionerDialog form = new PractitionerDialog(CustomerID, ""))
			{
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{
					AutoCompletePractitioner(CustomerID);

				}
			}
		}

		private void practitionerCbx_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				PractitionerID = PractitionerDictionary[practitionerCbx.Text];

			}
			catch { }
		}

		private void label52_Click(object sender, EventArgs e)
		{

		}

		private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{

				if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
				{
					if (MessageBox.Show("YES or No?", "Are you sure you want to remove this product ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
					{
						var itemToRemove = GenericCollection.transactions.Single(r => r.ItemID == dtGrid.Rows[e.RowIndex].Cells["ItemID"].Value.ToString());
						GenericCollection.transactions.Remove(itemToRemove);
						LoadTransactions();
						//Helper.Log(Helper.userID, Helper.username, "Updated rent values " + updateID + "- " + dtGrid.Rows[e.RowIndex].Cells["date"].Value.ToString());
					}
				}

			}
			catch { }
		}

		private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			string columnName = dtGrid.Columns[e.ColumnIndex].HeaderText;
			//try
			//{
			//	String Query = "UPDATE coverage SET " + columnName + " ='" + dtGrid.Rows[e.RowIndex].Cells[columnName].Value.ToString() + "' WHERE Id = '" + dtGrid.Rows[e.RowIndex].Cells["Id"].Value.ToString() + "'";
			//	DBConnect.QueryPostgre(Query);

			//	Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
			//	DBConnect.InsertPostgre(q);
			//}
			//catch (Exception c)
			//{
			//	MessageBox.Show(c.Message.ToString());
			//	//Helper.Exceptions(c.Message, "Editing Sales grid");
			//	MessageBox.Show("You have an invalid entry !");
			//}

			Update("coverage", dtGrid.Columns[e.ColumnIndex].HeaderText, dtGrid.Rows[e.RowIndex].Cells[columnName].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["Id"].Value.ToString());
		}
		private void Update(string table, string column, string value, string id)
		{
			try
			{
				String Query = "UPDATE " + table + " SET " + column + " ='" + value + "' WHERE Id = '" + id + "'";
				DBConnect.QueryPostgre(Query);
				Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
				DBConnect.InsertPostgre(q);
			}
			catch (Exception c)
			{
				MessageBox.Show(c.Message.ToString());
				Helper.Exceptions(c.Message, "Editing Order intakes data grid");
			}
		}
		private void userCbx_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			try
			{
				UserID = UserDictionary[userCbx.Text];
				Users c = new Users();//.Select(ItemID);
				c = Users.Select(UserID);
				userTxt.Text = "Name: " + c.Name + "\t Speciality" + c.Speciality + " \r\n Address: " + c.Address + "\r\n City/state: " + c.City + " " + c.State + "\t Zip: " + c.Zip + " \r\n  Phone: " + c.Contact + "\t";

				System.Drawing.Image img = Helper.Base64ToImage(c.Image);
				System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
				userPbx.Image = bmp;
				GraphicsPath gp = new GraphicsPath();
				gp.AddEllipse(cusPbx.DisplayRectangle);
				userPbx.Region = new Region(gp);
				userPbx.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			catch { }
		}
	}
}

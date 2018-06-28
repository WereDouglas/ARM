using ARM.DB;
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
	public partial class InstructionDeliveryForm : MetroFramework.Forms.MetroForm
	{
		Dictionary<string, string> UserDictionary = new Dictionary<string, string>();
		Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
		Dictionary<string, string> kinDictionary = new Dictionary<string, string>();
		Dictionary<string, bool> SetupDictionary = new Dictionary<string, bool>();
		Dictionary<string, bool> DischargeDictionary = new Dictionary<string, bool>();
		Dictionary<string, bool> ActionDictionary = new Dictionary<string, bool>();

		string CustomerID;
		string UserID;
		string OrderNo;
		string ID;
		string EmergencyID;
		string PractitionerID;
		string No;
		public InstructionDeliveryForm(string id, string no)
		{
			InitializeComponent();
			AutoCompleteUser();
			AutoCompleteCustomer();
			AutoCompleteEmergency();
			if (!string.IsNullOrEmpty(id))
			{
				LoadEdit(id);
				try
				{

				}
				catch (Exception m)
				{
					Helper.Exceptions(m.Message + "Loading order intake form for editing ");

				}
			}
			if (!string.IsNullOrEmpty(no))
			{
				noTxt.Text = no;
				updateBtn.Visible = false;
				LoadOrder(no);

			}
			printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
		}
		private void LoadOrder(string no)
		{
			updateBtn.Visible = false;
			Orders o;
			GenericCollection.transactions = new List<Transaction>();
			No = no;
			noTxt.Text = no;
			o = new Orders();//.Select(UsersID);
			o = Orders.SelectNo(no);
			CustomerID = o.CustomerID;
			PractitionerID = o.PractitionerID;
			No = o.No;
			
			UserID = o.UserID;

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
			
			string Q = "SELECT * FROM casetransaction WHERE caseID = '" + noTxt.Text + "'";
			foreach (CaseTransaction j in CaseTransaction.List(Q))
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

		double Total = 0;

		private Instruction i;

		private void LoadEdit(string id)
		{
			submitBtn.Visible = false;
			ID = id;
			i = new Instruction();//.Select(UsersID);
			i = Instruction.Select(id);

			CustomerID = i.CustomerID;
			noTxt.Text = i.No;
		
			if (i.Initial == "Yes") { initialChk.Checked = true; } else { initialChk.Checked =false; }
			if (i.Followup == "Yes") {followChk.Checked = true; } else { followChk.Checked = false; }
			if (i.Delivered == "Yes") { deliveredChk.Checked = true; } else { deliveredChk.Checked = false; }
			if (i.Safety == "Yes") { safetyChk.Checked = true; } else { safetyChk.Checked = false; }
			if (i.Pathways == "Yes") { pathChk.Checked = true; } else { pathChk.Checked = false; }
			if (i.Operation == "Yes") { operationChk.Checked = true; } else { operationChk.Checked = false; }
			if (i.Environment == "Yes") { environmentChk.Checked = true; } else { environmentChk.Checked = false; }
			if (i.Rugs == "Yes") { rugsChk.Checked = true; } else { rugsChk.Checked = false; }
			if (i.Fire == "Yes") { fireChk.Checked = true; } else { fireChk.Checked = false; }
			if (i.Cord == "Yes") { cordChk.Checked = true; } else { cordChk.Checked = false; }
			if (i.Issues == "Yes") { issuesChk.Checked = true; } else { issuesChk.Checked = false; }
			if (i.Electrical == "Yes") { electricalChk.Checked = true; } else { electricalChk.Checked = false; }
			if (i.Inout == "Yes") { inoutChk.Checked = true; } else { inoutChk.Checked = false; }

			if (i.Understand == "Yes") { understandChk.Checked = true; } else { understandChk.Checked = false; }
			if (i.Demonstration == "Yes") { demonChk.Checked = true; } else { demonChk.Checked = false; }
			if (i.Caregiver == "Yes") {caregiverChk.Checked = true; } else { caregiverChk.Checked = false; }

			if (i.Appropriate == "Yes") { yesRadioBtn.Checked = true; } else { noRadioBtn.Checked = false; }

			if (i.Ambulatory == "Yes") { ambChk.Checked = true; } else { ambChk.Checked = false; }
			if (i.Bath == "Yes") { bathChk.Checked = true; } else { bathChk.Checked = false; }
			if (i.Beds == "Yes") { bedChk.Checked = true; } else { bedChk.Checked = false; }
			if (i.Seat == "Yes") { seatChk.Checked = true; } else { seatChk.Checked = false; }
			if (i.Scooter == "Yes") { scootChk.Checked = true; } else { scootChk.Checked = false; }
			if (i.Manual == "Yes") { manualChk.Checked = true; } else { manualChk.Checked = false; }
			if (i.Power == "Yes") { powerChk.Checked = true; } else { powerChk.Checked = false; }
			if (i.Handling == "Yes") { handlingChk.Checked = true; } else { handlingChk.Checked = false; }
			equipmentOtherTxt.Text = i.EquipmentOther;

			if (i.Rights == "Yes") { rightsChk.Checked = true; } else { rightsChk.Checked = false; }
			if (i.Available == "Yes") { availChk.Checked = true; } else { availChk.Checked = false; }
			if (i.Privacy == "Yes") { privacyChk.Checked = true; } else { privacyChk.Checked = false; }
			if (i.Standards == "Yes") { standardChk.Checked = true; } else { standardChk.Checked = false; }
			if (i.Instructions == "Yes") { instructionChk.Checked = true; } else { instructionChk.Checked = false; }
			if (i.Delivered == "Yes") { deliveredChk.Checked = true; } else { deliveredChk.Checked = false; }
			if (i.Cleaning == "Yes") { cleanChk.Checked = true; } else { cleanChk.Checked = false; }
			if (i.Letter == "Yes") { letterChk.Checked = true; } else { letterChk.Checked = false; }
			if (i.Complaint == "Yes") { complaintChk.Checked = true; } else { complaintChk.Checked = false; }
			if (i.Warranty == "Yes") { warrantyChk.Checked = true; } else { warrantyChk.Checked = false; }
			if (i.Instructions == "Yes") { instructionChk.Checked = true; } else { instructionChk.Checked = false; }
			if (i.Aob == "Yes") { aobChk.Checked = true; } else { aobChk.Checked = false; }		

			if (i.Visit == "Yes") { visitChk.Checked = true; } else { visitChk.Checked = false; }
			if (i.Phone == "Yes") { phoneChk.Checked = true; } else { phoneChk.Checked = false; }

			signatureTxt.Text = i.PatientSign;
			userCbx.Text = i.Employee;
			userSignatureTxt.Text = i.EmployeeSign;
			limitTxt.Text = i.PhysicalLimit;
			safetyOtherTxt.Text = i.SafetyOther;
			kinContactTxt.Text = i.KinContact;
			kinCbx.Text = i.KinName;
			representativeTxt.Text = i.Representative;			
			additionNotesTxt.Text = i.Notes;
			
			otherSignatureCbx.Text = i.OtherSign;
			kinCbx.Text = i.KinName;
			kinCbx_SelectedIndexChanged(null, null);
			reasonTxt.Text = i.Reason;
			userSignatureTxt.Text = i.UserSignature;
			try
			{
				//CustomerID = CustomerDictionary[customerCbx.Text];
				c = new Customer();//.Select(ItemID);
				c = Customer.Select(i.CustomerID);
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
				string Q = "SELECT * FROM coverage WHERE customerID = '" + i.CustomerID + "' ";
				foreach (Coverage c in Coverage.List(Q))
				{
					// insuranceInfoTxt.Text = insuranceInfoTxt.Text + "\r\n" + "Name: " + c.Name + "\t ID# : " + c.No + " \r\n  " + " \r\n  Type: " + c.Type;
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

			string initial = initialChk.Checked ? "Yes" : "No";
			string followup = initialChk.Checked ? "Yes" : "No";
			string delivered = initialChk.Checked ? "Yes" : "No";
			string safety = initialChk.Checked ? "Yes" : "No";
			string path = initialChk.Checked ? "Yes" : "No";
			string operation = initialChk.Checked ? "Yes" : "No";
			string environment = initialChk.Checked ? "Yes" : "No";
			string rugs = initialChk.Checked ? "Yes" : "No";
			string fire = initialChk.Checked ? "Yes" : "No";
			string cord = initialChk.Checked ? "Yes" : "No";
			string issues = initialChk.Checked ? "Yes" : "No";
			string electricals = initialChk.Checked ? "Yes" : "No";
			string inout = initialChk.Checked ? "Yes" : "No";
			string appropriate = initialChk.Checked ? "Yes" : "No";
			string understand = initialChk.Checked ? "Yes" : "No";
			string returns = initialChk.Checked ? "Yes" : "No";
			string caregiver = initialChk.Checked ? "Yes" : "No";
			string amb = initialChk.Checked ? "Yes" : "No";
			string bath = initialChk.Checked ? "Yes" : "No";
			string beds = initialChk.Checked ? "Yes" : "No";
			string seat = initialChk.Checked ? "Yes" : "No";
			string scooter = initialChk.Checked ? "Yes" : "No";
			string manual = initialChk.Checked ? "Yes" : "No";
			string power = initialChk.Checked ? "Yes" : "No";
			string handling = initialChk.Checked ? "Yes" : "No";
			string rights= initialChk.Checked ? "Yes" : "No";
			string avail = initialChk.Checked ? "Yes" : "No";
			string priv = initialChk.Checked ? "Yes" : "No";
			string standards = initialChk.Checked ? "Yes" : "No";
			string demons = initialChk.Checked ? "Yes" : "No";
			string clean = initialChk.Checked ? "Yes" : "No";
			string letter = initialChk.Checked ? "Yes" : "No";
			string complaint = initialChk.Checked ? "Yes" : "No";
			string warranty = initialChk.Checked ? "Yes" : "No";
			string instruct = initialChk.Checked ? "Yes" : "No";
			string aob = initialChk.Checked ? "Yes" : "No";
			string visit = initialChk.Checked ? "Yes" : "No";
			string phone = initialChk.Checked ? "Yes" : "No";

			string type = initialChk.Checked ? "Initial Delivery" : "Follow-up";			
			appropriate = yesRadioBtn.Checked ? "Yes" : "No";
			appropriate = noRadioBtn.Checked ? "No" : "Yes";
			
			
			safetyOtherTxt.Text = i.SafetyOther;

			
			string id = Guid.NewGuid().ToString();
			if (MessageBox.Show("YES or NO?", "Submit Order? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				Instruction i = new Instruction(id, noTxt.Text, CustomerID,alternativeTxt.Text,Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"),initial,followup, type,delivered,safety,path,operation,environment,rugs,fire,cord,issues,electricals,inout,appropriate,understand,returns,caregiver,safetyOtherTxt.Text,limitTxt.Text,amb,bath,beds,seat,scooter,manual,power,handling,equipmentOtherTxt.Text,rights,avail,priv,standards,demons,clean,letter,complaint,warranty,instruct,aob,additionNotesTxt.Text,visit,phone,signatureTxt.Text,userCbx.Text,userSignatureTxt.Text,kinCbx.Text,otherSignatureCbx.Text,kinContactTxt.Text,relationshipTxt.Text,representativeTxt.Text,reasonTxt.Text,userSignatureTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID,Helper.UserID);
				string save = DBConnect.InsertPostgre(i);
				if (save != "")
				{
					Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
					DBConnect.InsertPostgre(q);
					MessageBox.Show("Information Saved");
					this.Close();
				}

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
					userCbx.Items.Add(v.Name);
					// recievedCbx.Items.Add(v.Name);
					//dispensedCbx.Items.Add(v.Name);
				}
			}

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
					kinCbx.Items.Add(v.Name);
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

				}
			}
		}
		Customer c;
		Coverage ins;
		Users u;

		private void userCbx_SelectedIndexChanged(object sender, EventArgs e)
		{


		}
		string ItemID;
		Product p;
		private void productCbx_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			//Print(panel1);
			InstructionReport form = new InstructionReport(noTxt.Text);//Print(panel1);
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
			t.Columns.Add("Description");
			

			
			string Q = "SELECT * FROM CaseTransaction WHERE caseID = '" + noTxt.Text + "'";
			foreach (CaseTransaction j in CaseTransaction.List(Q))
			{
				try
				{
					k = Product.Select(j.ItemID);
					t.Rows.Add(new object[] { j.Id, j.ItemID, k.Name, k.Description });

				}
				catch (Exception m)
				{
					MessageBox.Show("" + m.Message);
					Helper.Exceptions(m.Message + "Viewing users {each transaction list }" + j.ItemID);
				}
			}
			Total = Transaction.List(Q).Sum(r => r.Total);
			// totalLbl.Text = Total.ToString("N0");

			dtGrid.DataSource = t;

			//dtGrid.AllowUserToAddRows = false;
			// dtGrid.Columns["View"].DefaultCellStyle.BackColor = Color.LightGreen;
			//  dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;

			dtGrid.Columns["id"].Visible = false;
			dtGrid.Columns["ItemID"].Visible = false;
		}

		private void kinCbx_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void updateBtn_Click(object sender, EventArgs e)
		{
			string initial = initialChk.Checked ? "Yes" : "No";
			string followup = initialChk.Checked ? "Yes" : "No";
			string delivered = initialChk.Checked ? "Yes" : "No";
			string safety = initialChk.Checked ? "Yes" : "No";
			string path = initialChk.Checked ? "Yes" : "No";
			string operation = initialChk.Checked ? "Yes" : "No";
			string environment = initialChk.Checked ? "Yes" : "No";
			string rugs = initialChk.Checked ? "Yes" : "No";
			string fire = initialChk.Checked ? "Yes" : "No";
			string cord = initialChk.Checked ? "Yes" : "No";
			string issues = initialChk.Checked ? "Yes" : "No";
			string electricals = initialChk.Checked ? "Yes" : "No";
			string inout = initialChk.Checked ? "Yes" : "No";
			string appropriate = initialChk.Checked ? "Yes" : "No";
			string understand = initialChk.Checked ? "Yes" : "No";
			string returns = initialChk.Checked ? "Yes" : "No";
			string caregiver = initialChk.Checked ? "Yes" : "No";
			string amb = initialChk.Checked ? "Yes" : "No";
			string bath = initialChk.Checked ? "Yes" : "No";
			string beds = initialChk.Checked ? "Yes" : "No";
			string seat = initialChk.Checked ? "Yes" : "No";
			string scooter = initialChk.Checked ? "Yes" : "No";
			string manual = initialChk.Checked ? "Yes" : "No";
			string power = initialChk.Checked ? "Yes" : "No";
			string handling = initialChk.Checked ? "Yes" : "No";
			string rights = initialChk.Checked ? "Yes" : "No";
			string avail = initialChk.Checked ? "Yes" : "No";
			string priv = initialChk.Checked ? "Yes" : "No";
			string standards = initialChk.Checked ? "Yes" : "No";
			string demons = initialChk.Checked ? "Yes" : "No";
			string clean = initialChk.Checked ? "Yes" : "No";
			string letter = initialChk.Checked ? "Yes" : "No";
			string complaint = initialChk.Checked ? "Yes" : "No";
			string warranty = initialChk.Checked ? "Yes" : "No";
			string instruct = initialChk.Checked ? "Yes" : "No";
			string aob = initialChk.Checked ? "Yes" : "No";
			string visit = initialChk.Checked ? "Yes" : "No";
			string phone = initialChk.Checked ? "Yes" : "No";

			string type = initialChk.Checked ? "Initial Delivery" : "Follow-up";
			appropriate = yesRadioBtn.Checked ? "Yes" : "No";
			appropriate = noRadioBtn.Checked ? "No" : "Yes";


			safetyOtherTxt.Text = i.SafetyOther;

			
			appropriate = yesRadioBtn.Checked ? "Yes" : "No";
			appropriate = noRadioBtn.Checked ? "No" : "Yes";
			
		
			if (MessageBox.Show("YES or NO?", "Update this Order? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				Instruction i = new Instruction(ID, noTxt.Text, CustomerID, alternativeTxt.Text, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), initial, followup, type, delivered, safety, path, operation, environment, rugs, fire, cord, issues, electricals, inout, appropriate, understand, returns, caregiver, safetyOtherTxt.Text, limitTxt.Text, amb, bath, beds, seat, scooter, manual, power, handling, equipmentOtherTxt.Text, rights, avail, priv, standards, demons, clean, letter, complaint, warranty, instruct, aob, additionNotesTxt.Text, visit, phone, signatureTxt.Text, userCbx.Text, userSignatureTxt.Text, kinCbx.Text, otherSignatureCbx.Text, kinContactTxt.Text, relationshipTxt.Text, representativeTxt.Text, reasonTxt.Text, userSignatureTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID, Helper.UserID);
				string save = DBConnect.UpdatePostgre(i, ID);
				Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
				DBConnect.InsertPostgre(q);

				MessageBox.Show("Information Updated ! ");
				this.Close();


			}
		}

		private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void kinCbx_SelectedIndexChanged_1(object sender, EventArgs e)
		{

		}

		private void label10_Click(object sender, EventArgs e)
		{

		}
	}
}

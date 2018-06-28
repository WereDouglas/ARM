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
	public partial class CertificateInputForm : MetroFramework.Forms.MetroForm
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
		string No;
		string EmergencyID;
		string PractitionerID;
		public CertificateInputForm(string id, string no)
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

			}
			if (!string.IsNullOrEmpty(no))
			{
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
			providerIDTxt.Text = Helper.NPI;
			providerNameTxt.Text = Helper.CompanyName;
			providerUserTxt.Text = Helper.UserName;
			providerPhoneTxt.Text = Helper.UserName;
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
				patientNameTxt.Text = c.Name;
				idTxt.Text = c.No;
				dobTxt.Text = c.Dob;
				contactTxt.Text = c.Contact;
			}
			catch { }

			try
			{
				PractitionerID = o.PractitionerID;
				Practitioner c = new Practitioner();//.Select(ItemID);
				c = Practitioner.Select(PractitionerID);
				physicianTxt.Text = "Name: " + c.Name + "\t Speciality" + c.Speciality + " \r\n Address: " + c.Address + "\r\n City/state: " + c.City + " " + c.State + "\t Zip: " + c.Zip + " \r\n  Phone: " + c.Contact + "\t";

				System.Drawing.Image img = Helper.Base64ToImage(c.Image);
				System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
				userPbx.Image = bmp;
				GraphicsPath gp = new GraphicsPath();
				gp.AddEllipse(cusPbx.DisplayRectangle);
				userPbx.Region = new Region(gp);
				userPbx.SizeMode = PictureBoxSizeMode.StretchImage;
				pracIDTxt.Text = c.ProviderID;
				practitionerTxt.Text = c.Name;
				signatureTxt.Text = "";
				dateTxt.Text = Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy");
				phoneTxt.Text = c.Contact;


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
			dateTxt.Text= Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy");
			dayTxt.Text = Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy");
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

			Dictionary<string, bool> safetyValues = JsonConvert.DeserializeObject<Dictionary<string, bool>>(i.Safety);
			

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
		Dictionary<string, bool> SafetyDictionary = new Dictionary<string, bool>();
		Dictionary<string, bool> AppropriateDictionary = new Dictionary<string, bool>();
		Dictionary<string, bool> EquipmentDictionary = new Dictionary<string, bool>();
		Dictionary<string, bool> AdditionalDictionary = new Dictionary<string, bool>();
		private void button3_Click(object sender, EventArgs e)
		{
			
			bool mobility = mobYesBn.Checked ? true: false;
			bool endurance = enduranceBn.Checked ? true : false;
			bool activity = activityBn.Checked ? true : false;
			bool skin = skinBn.Checked ? true : false;
			bool respiration = respirationBn.Checked ? true : false;
			bool adl = adlBn.Checked ? true : false;
			bool speech = speechBn.Checked ? true : false;
			bool nutritional = nutritionBn.Checked ? true : false;
			string source = sourceSoleBn.Checked ? "sole" : "primary";
			bool suitable = suitableBn.Checked ? true : false;

			//appropriate = 

			string id = Guid.NewGuid().ToString();
			if (MessageBox.Show("YES or NO?", "Submit Order? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				Certificate i = new Certificate(id, noTxt.Text,idTxt.Text,patientNameTxt.Text,dobTxt.Text,phoneTxt.Text,providerIDTxt.Text,providerNameTxt.Text,providerPhoneTxt.Text,mobility,endurance,activity,skin,respiration,adl,speech,nutritional,source,Convert.ToDouble(weightTxt.Text), Convert.ToDouble(heightTxt.Text),suitable,dayTxt.Text,practitionerTxt.Text,signatureTxt.Text,dateTxt.Text,pracIDTxt.Text,phoneTxt.Text,DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID,poTxt.Text,saturationTxt.Text);
				string save =  DBConnect.InsertPostgre(i);
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
			CertificateReport form = new CertificateReport(noTxt.Text);//Print(panel1);
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
			t.Columns.Add("HCPCS Code");
			t.Columns.Add("Product");
			t.Columns.Add("Description");
			t.Columns.Add("Period");
			t.Columns.Add("Quantity Ordered/x1 Month*");
			t.Columns.Add("Frequency of Use*Justification/Comments/Calories Per Day");
			foreach (Transaction j in GenericCollection.transactions)
			{
				try
				{
					k = Product.Select(j.ItemID);
					t.Rows.Add(new object[] { j.Id, j.ItemID,k.Code, k.Name,k.Description,j.Period ,j.Qty, j.Instruction });

				}
				catch (Exception m)
				{
					MessageBox.Show("" + m.Message);
					Helper.Exceptions(m.Message + "Viewing  Certificate inputs {each transaction list }" + j.ItemID);
				}
			}
			//Total = Transaction.List(Q).Sum(r => r.Total);
			// totalLbl.Text = Total.ToString("N0");

			dtGrid.DataSource = t;
		
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
			
			var SafetyJson = JsonConvert.SerializeObject(SafetyDictionary);
			var AppropriateJson = JsonConvert.SerializeObject(AppropriateDictionary);
			var EquipmentJson = JsonConvert.SerializeObject(EquipmentDictionary);
			var AdditionalJson = JsonConvert.SerializeObject(AdditionalDictionary);
			
			var DischargeJson = JsonConvert.SerializeObject(DischargeDictionary);
			var ActionJson = JsonConvert.SerializeObject(ActionDictionary);
			var SetupJson = JsonConvert.SerializeObject(SetupDictionary);
			string id = Guid.NewGuid().ToString();
			if (MessageBox.Show("YES or NO?", "Update this Order? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				//Instruction i = new Instruction(ID, noTxt.Text, CustomerID, Helper.UserID, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), typeCbx.Text, delivered, kinContactTxt.Text, SafetyJson, appropriate, AppropriateJson, otherTxt.Text, limitTxt.Text, EquipmentJson, equipmentOtherTxt.Text, AdditionalJson, additionNotesTxt.Text, followUpCbx.Text, signatureTxt.Text, kinCbx.Text, kinContactTxt.Text, emergencyDetails.Text, reasonTxt.Text, userSignatureTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID);
				string save = "";// DBConnect.UpdatePostgre(i, ID);
				Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
				DBConnect.InsertPostgre(q);

				MessageBox.Show("Information Updated ! ");
				this.Close();


			}
		}

		private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void userCbx_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			try
			{
				UserID = UserDictionary[userCbx.Text];
				Users c = new Users();//.Select(ItemID);
				c = Users.Select(UserID);
				providerUserTxt.Text =  c.Name;
				providerPhoneTxt.Text = c.Contact;

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

		private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void textBox9_TextChanged(object sender, EventArgs e)
		{

		}
	}
}

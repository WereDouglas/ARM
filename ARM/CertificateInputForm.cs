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
			GenericCollection.icd10 = new List<ICD10>();
			GenericCollection.caseTransactions = new List<CaseTransaction>();
			if (!string.IsNullOrEmpty(id))
			{
				LoadEdit(id);
				try
				{

				}
				catch (Exception m)
				{
					Helper.Exceptions(m.Message, "Loading order intake form for editing ");

				}
			}
			else
			{

				if (!string.IsNullOrEmpty(no))
				{
					LoadOrder(no);
					noTxt.Text = no;
					updateBtn.Visible = false;

				}

			}
			printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
		}
		private void LoadOrder(string no)
		{
			updateBtn.Visible = false;
			Orders o;
			GenericCollection.caseTransactions = new List<CaseTransaction>();
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
			GenericCollection.caseTransactions.Clear();
			GenericCollection.icd10.Clear();
			string Q = "SELECT * FROM casetransaction WHERE no = '" + noTxt.Text + "'";
			foreach (CaseTransaction j in CaseTransaction.List(Q))
			{
				//try
				//{

				CaseTransaction t = new CaseTransaction(j.Id, j.Date, j.No, j.ItemID, j.CaseID, j.DeliveryID, j.Qty, j.Cost, j.Units, j.Total, j.Tax, j.Coverage, j.Self, j.Payable, j.Limits, j.Setting, j.Period, j.Height, j.Weight, j.Instruction, j.Created, false, Helper.CompanyID);
				GenericCollection.caseTransactions.Add(t);
				//}
				//catch { }

			}
			LoadCaseTransactions();
			dateTxt.Text = Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy");
			dayTxt.Text = Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy");

			GenericCollection.icd10.Clear();
			string Qs = "SELECT * FROM icd10 WHERE no = '" + noTxt.Text + "'";
			GenericCollection.icd10 = ICD10.List(Qs);
			LoadDiagnosis();
		}

		double Total = 0;

		private Certificate i;

		private void LoadEdit(string id)
		{
			submitBtn.Visible = false;
			ID = id;
			i = new Certificate();//.Select(UsersID);
			try
			{
				i = Certificate.Select(id);
			}
			catch
			{

				MessageBox.Show("Certificate information not yet saved");

			}
			noTxt.Text = i.No;
			idTxt.Text = i.CusID;
			patientNameTxt.Text = i.CusName;
			dobTxt.Text = i.CusDob;
			contactTxt.Text = i.CusPhone;

			providerIDTxt.Text = i.PracID;
			providerNameTxt.Text = i.ProvName;
			providerUserTxt.Text = i.PracName;
			providerPhoneTxt.Text = i.ProvPhone;
			additionalTxt.Text = i.Additional;
			if (i.Mobility == true) { mobYesBn.Checked = true; }
			if (i.Mobility == false) { mobNoBn.Checked = true; }
			if (i.Endurance == true) { enduranceBn.Checked = true; }
			if (i.Endurance == false) { enduranceNoBn.Checked = true; }
			if (i.Activity == true) { activityBn.Checked = true; }
			if (i.Activity == false) { activityNoBn.Checked = true; }
			if (i.Skin == true) { skinBn.Checked = true; }
			if (i.Skin == false) { skinNoBn.Checked = true; }
			if (i.Respiration == true) { respirationBn.Checked = true; }
			if (i.Respiration == false) { respirationNoBn.Checked = true; }
			if (i.Adl == true) { adlBn.Checked = true; }
			if (i.Adl == false) { adlNoBn.Checked = true; }
			if (i.Speech == true) { speechBn.Checked = true; }
			if (i.Speech == false) { speechNoBn.Checked = true; }
			if (i.Nutritional == true) { nutritionBn.Checked = true; }
			if (i.Nutritional == false) { nutritionNoBn.Checked = true; }
			if (i.Source == "sole") { sourceSoleBn.Checked = true; } else if (i.Source == "primary") { primarySourceBn.Checked = true; }
			heightTxt.Text = i.Height.ToString();
			weightTxt.Text = i.Weight.ToString();
			dateTxt.Text = i.Date;
			if (i.Suitable == true) { suitableBn.Checked = true; }
			if (i.Suitable == false) { suitableNoBn.Checked = true; }
			if (i.Face == "Yes") { faceYesBn.Checked = true; } else if (i.Face == "No") { faceNoBn.Checked = true; } else if (i.Face == "N/A") { faceNaBn.Checked = true; }

			completedTxt.Text = i.Practionercompleted;
			practitionerTxt.Text = i.PracName;
			pracIDTxt.Text = i.PracID;
			signatureTxt.Text = i.PracSign;
			dateTxt.Text = i.SignDate;
			phoneTxt.Text = i.PracPhone;

			try
			{
				//CustomerID = CustomerDictionary[customerCbx.Text];
				c = new Customer();//.Select(ItemID);
				c = Customer.Select(i.CusID);
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
				string Qw = "SELECT * FROM coverage WHERE customerID = '" + i.CusID + "' ";
				foreach (Coverage c in Coverage.List(Qw))
				{
					// insuranceInfoTxt.Text = insuranceInfoTxt.Text + "\r\n" + "Name: " + c.Name + "\t ID# : " + c.No + " \r\n  " + " \r\n  Type: " + c.Type;
				}

			}
			catch { }


			LoadOrder(id);


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

			bool mobility = mobYesBn.Checked ? true : false;
			bool endurance = enduranceBn.Checked ? true : false;
			bool activity = activityBn.Checked ? true : false;
			bool skin = skinBn.Checked ? true : false;
			bool respiration = respirationBn.Checked ? true : false;
			bool adl = adlBn.Checked ? true : false;
			bool speech = speechBn.Checked ? true : false;
			bool nutritional = nutritionBn.Checked ? true : false;
			string source = sourceSoleBn.Checked ? "sole" : "primary";
			bool suitable = suitableBn.Checked ? true : false;

			string face = "";
			if (faceYesBn.Checked) { face = "Yes"; } else if (faceNoBn.Checked) { face = "No"; } else if (faceNaBn.Checked) { face = "N/A"; }
			if (string.IsNullOrEmpty(face))
			{

				MessageBox.Show("Is face to face completed ?");
				return;
			}
			//appropriate = 

			string id = Guid.NewGuid().ToString();
			if (MessageBox.Show("YES or NO?", "Submit Order? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				double weight = 0;
				double height = 0;
				try
				{
					height = Convert.ToDouble(heightTxt.Text);

				}
				catch
				{
				}
				try
				{
					weight = Convert.ToDouble(weightTxt.Text);

				}
				catch
				{


				}
				Certificate i = new Certificate(id, noTxt.Text, idTxt.Text, patientNameTxt.Text, dobTxt.Text, phoneTxt.Text, providerIDTxt.Text, providerNameTxt.Text, providerPhoneTxt.Text, mobility, endurance, activity, skin, respiration, adl, speech, nutritional, source,weight, height, suitable, dayTxt.Text, practitionerTxt.Text, signatureTxt.Text, dateTxt.Text, pracIDTxt.Text, phoneTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID, poTxt.Text, saturationTxt.Text, additionalTxt.Text, face, completedTxt.Text);
				string save = DBConnect.InsertPostgre(i);
				if (save != "")
				{
					Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
					DBConnect.InsertPostgre(q);
					foreach (ICD10 t in GenericCollection.icd10)
					{
						ICD10 c = new ICD10(t.Id, noTxt.Text, t.Code, t.Name, t.Diagnosis, t.Less6, t.Greater6, t.Onset, t.Created, false, Helper.CompanyID);
						string doing = DBConnect.InsertPostgre(c);
						if (doing != "")
						{
							Queries qs = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(doing), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
							DBConnect.InsertPostgre(qs);
						}
					}


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

		public void LoadCaseTransactions()
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
			foreach (CaseTransaction j in GenericCollection.caseTransactions)
			{
				try
				{
					k = Product.Select(j.ItemID);
					t.Rows.Add(new object[] { j.Id, j.ItemID, k.Code, k.Name, k.Description, j.Period, j.Qty, j.Instruction });

				}
				catch (Exception m)
				{
					MessageBox.Show("" + m.Message);
					Helper.Exceptions(m.Message, "Viewing  Certificate inputs {each transaction list }" + j.ItemID);
				}
			}
			//Total = CaseTransaction.List(Q).Sum(r => r.Total);
			// totalLbl.Text = Total.ToString("N0");

			dtGridEquip.DataSource = t;

			// dtGrid.Columns["View"].DefaultCellStyle.BackColor = Color.LightGreen;
			//  dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;

			dtGridEquip.Columns["id"].Visible = false;
			dtGridEquip.Columns["ItemID"].Visible = false;
		}

		private void kinCbx_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void updateBtn_Click(object sender, EventArgs e)
		{

			string face = "";
			if (faceYesBn.Checked) { face = "Yes"; } else if (faceNoBn.Checked) { face = "No"; } else if (faceNaBn.Checked) { face = "N/A"; }
			if (string.IsNullOrEmpty(face))
			{

				MessageBox.Show("Is face to face completed ?");
				return;
			}

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
			try
			{
				if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
				{
					if (MessageBox.Show("YES or No?", "Are you sure you want to remove this information ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
					{
						Helper.Log(Helper.UserName, "Deleting of ICD10 list on CMN " + noTxt.Text + "");
						string Query = "DELETE from icd10 WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
						DBConnect.QueryPostgre(Query);
						Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
						DBConnect.InsertPostgre(q);
						MessageBox.Show("Information deleted");
						GenericCollection.caseTransactions.Clear();
						string Q = "SELECT * FROM casetransaction WHERE no = '" + noTxt.Text + "'";
						LoadDiagnosis();
					}
				}
			}
			catch (Exception c)
			{
				Helper.Exceptions(c.Message, "Deleting on order intake Grid data ");
			}

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
				providerUserTxt.Text = c.Name;
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

		private void button6_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Certificate ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				string Query = "DELETE from certificate WHERE no ='" + noTxt.Text + "'";
				DBConnect.QueryPostgre(Query);
				Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
				DBConnect.InsertPostgre(q);
				MessageBox.Show("Information deleted");
				Helper.Log(Helper.UserName, "Deleted Certificate " + noTxt.Text + " TIME:" + DateTime.Now);

			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			using (CertificateInputForm form = new CertificateInputForm(noTxt.Text, ""))
			{
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{
					//LoadData();
				}
			}

			//LoadEdit(noTxt.Text);


		}

		private void button10_Click(object sender, EventArgs e)
		{
			using (AddDiagnosis form = new AddDiagnosis(noTxt.Text, CustomerID))
			{
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{
					LoadDiagnosis();
				}
			}
		}
		public void LoadDiagnosis()
		{



			// create and execute query  
			t = new DataTable();

			t.Columns.Add("id");
			t.Columns.Add("Code");
			t.Columns.Add("Name");
			t.Columns.Add("Diagnosis");
			t.Columns.Add("Less than 6 months");
			t.Columns.Add("Greater than 6 months");
			t.Columns.Add("Date of onset");
			t.Columns.Add(new DataColumn("Delete", typeof(Image)));

			Image delete = new Bitmap(Properties.Resources.Cancel_16);

			foreach (ICD10 j in GenericCollection.icd10)
			{
				try
				{

					t.Rows.Add(new object[] { j.Id, j.Code, j.Name, j.Diagnosis, j.Less6, j.Greater6, j.Onset, delete });

				}
				catch (Exception m)
				{
					MessageBox.Show("" + m.Message);
					Helper.Exceptions(m.Message, "Viewing users {each transaction list }" + j.Name);
				}
			}

			dtGrid.DataSource = t;
			dtGrid.AllowUserToAddRows = false;
			// dtGrid.Columns["View"].DefaultCellStyle.BackColor = Color.LightGreen;
			//  dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;

			dtGrid.Columns["id"].Visible = false;
		}

		private void dtGridEquip_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
				{
					if (MessageBox.Show("YES or No?", "Are you sure you want to remove this information ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
					{
						Helper.Log(Helper.UserName, "Deleting of ICD10 list on CMN " + noTxt.Text + "");
						string Query = "DELETE from icd10 WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
						DBConnect.QueryPostgre(Query);
						Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
						DBConnect.InsertPostgre(q);
						MessageBox.Show("Information deleted");
						GenericCollection.caseTransactions.Clear();
						string Q = "SELECT * FROM casetransaction WHERE no = '" + noTxt.Text + "'";
						LoadDiagnosis();
					}
				}
			}
			catch (Exception c)
			{
				Helper.Exceptions(c.Message, "Deleting on order intake Grid data ");
			}
		}
	}
}

﻿using ARM.DB;
using ARM.Model;
using ARM.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
	public partial class CustomerDemo : MetroFramework.Forms.MetroForm
	{
		string CustomerID;
		public CustomerDemo(string customerID, string category)
		{

			InitializeComponent();
			this.Text = category;
			try
			{
				noTxt.Text =(Convert.ToDouble(MySQL.value("SELECT MAX( cast(no as unsigned)) FROM customer ORDER BY no DESC LIMIT 1")) + 1).ToString();
			}
			catch
			{
				noTxt.Text = "1";
			}
			if (!string.IsNullOrEmpty(customerID))
			{
				CustomerID = customerID;
				Profile(customerID);
				saveBtn.Visible = false;
			}
			else
			{

				CustomerID = Guid.NewGuid().ToString();
				updateBtn.Visible = false;
			}
			categoryCbx.Text = category;
			AutoCompleteState();
		}
		private void AutoCompleteState()
		{
			AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
			foreach (String v in States.Abbreviations())
			{
				AutoItem.Add((v));
				stateTxt.Items.Add(v);
			}
			stateTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
			stateTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
			stateTxt.AutoCompleteCustomSource = AutoItem;
		}
		private Customer c;
		private void Profile(string customerID)
		{
			CustomerID = customerID;
			c = new Customer();//.Select(customerID);
			c =Customer.Select(CustomerID);
			nameTxt.Text = c.Name;
			noTxt.Text = c.No;
			contactTxt.Text = c.Contact;
			addressTxt.Text = c.Address;
			cityTxt.Text = c.City;
			stateTxt.Text = c.State;
			zipTxt.Text = c.Zip;
			ssnTxt.Text = c.Ssn;
			dobTxt.Text = c.Dob;
			categoryCbx.Text = c.Category;
			heightTxt.Text = c.Height;
			weightTxt.Text = c.Weight;
			genderCbx.Text = c.Gender;
			raceCbx.Text = c.Race;
			try
			{
				Image img = Helper.Base64ToImage(c.Image.ToString());
				System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
				//Bitmap bps = new Bitmap(bmp, 50, 50);
				imgCapture.Image = bmp;
				imgCapture.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			catch (Exception t)
			{
				MessageBox.Show(t.Message);
				Helper.Exceptions(t.Message, "view load image for window ");

			}
			LoadCondition();
			LoadCoverage();
			LoadEmergency();
			LoadPractitioner();
		}
		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			string exists = "";
			try
			{
				exists = MySQL.value("SELECT no FROM customers WHERE no  = '" + noTxt.Text + "'");
			}
			catch
			{


			}
			//.value(string table, string value, string column, string variable)
			if (!string.IsNullOrEmpty(exists))
			{

				int no = Convert.ToInt32(exists);
				noTxt.Text = (no + 1).ToString();
				MessageBox.Show("The patient number " + noTxt.Text + " is already in use.New Patient number assigned " + noTxt.Text);
			}

			MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
			string fullimage = Helper.ImageToBase64(stream);
			if (string.IsNullOrEmpty(categoryCbx.Text))
			{
				MessageBox.Show("Please select the category !");
				return;
			}
			if (Convert.ToDateTime(dobTxt.Text).ToString("dd-MM-yyyy") == DateTime.Now.ToString("dd-MM-yyyy"))
			{
				MessageBox.Show("Date of birth of is invalid  !");
				return;
			}
			Customer c = new Customer(CustomerID, nameTxt.Text, contactTxt.Text, addressTxt.Text, noTxt.Text, cityTxt.Text, stateTxt.Text, zipTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), ssnTxt.Text, dobTxt.Text, categoryCbx.Text, Helper.CleanString(heightTxt.Text), weightTxt.Text, genderCbx.Text, "false", Helper.CompanyID, fullimage, raceCbx.Text);
			MySQL.Insert(c);

			MessageBox.Show("Information Saved");
			Helper.CurrentCustomer = nameTxt.Text;
			Helper.Log(Helper.UserName, "Created new customer " + nameTxt.Text);
			this.DialogResult = DialogResult.OK;
			this.Dispose();

		}
		private void Update(string customerID)
		{

			MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
			string fullimage = Helper.ImageToBase64(stream);
			Customer c = new Customer(customerID, nameTxt.Text, contactTxt.Text, addressTxt.Text, noTxt.Text, cityTxt.Text, stateTxt.Text, zipTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), ssnTxt.Text, dobTxt.Text, categoryCbx.Text, heightTxt.Text, weightTxt.Text, genderCbx.Text, "false", Helper.CompanyID, fullimage, raceCbx.Text);
			DBConnect.UpdateMySql(c, customerID);
		
			MessageBox.Show("Information Updated");
			Helper.Log(Helper.UserName, " Updated Customer details  " + nameTxt.Text);
			this.DialogResult = DialogResult.OK;
			this.Dispose();

		}

		private void contactTxt_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar)
			&& !char.IsDigit(e.KeyChar)
			&& e.KeyChar != '.')
			{
				e.Handled = true;
			}

			// only allow two decimal point
			if (e.KeyChar == '.'
				&& (sender as TextBox).Text.IndexOf('.') > -1)
			{
				e.Handled = true;
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			using (InsuranceDialog form = new InsuranceDialog(CustomerID))
			{
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{
					LoadCoverage();
				}
			}
		}
		DataTable t = new DataTable();
		public void LoadCoverage()
		{
			// create and execute query  
			t = new DataTable();

			t.Columns.Add("id");
			t.Columns.Add("Name");
			t.Columns.Add("Type");
			t.Columns.Add("Category");
			t.Columns.Add("No.");
			t.Columns.Add(new DataColumn("Delete", typeof(Image)));

			Image delete = new Bitmap(Properties.Resources.Cancel_16);
			//string Q = "SELECT * FROM coverage WHERE customerID = '" + CustomerID + "' ";
			foreach (Coverage j in GenericCollection.coverage.Where(u => u.CustomerID == CustomerID))
			{
				try
				{

					t.Rows.Add(new object[] { j.Id, j.Name, j.Type, j.Category, j.No, delete });

				}
				catch (Exception m)
				{
					MessageBox.Show("" + m.Message);
					Helper.Exceptions(m.Message, "Viewing users {each transaction list }" + j.Name);
				}
			}

			dtGridCoverage.DataSource = t;
			dtGridCoverage.AllowUserToAddRows = false;
			dtGridCoverage.Columns["id"].Visible = false;

		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(CustomerID))
			{
				Update(CustomerID);
				return;
			}
		}

		private void button4_Click_1(object sender, EventArgs e)
		{
			using (ConditionDialog form = new ConditionDialog(CustomerID))
			{
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{
					LoadCondition();
				}
			}
		}

		private void tabBio_Click(object sender, EventArgs e)
		{

		}

		private void dtGridCoverage_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{

				if (e.ColumnIndex == dtGridCoverage.Columns["Delete"].Index && e.RowIndex >= 0)
				{

					if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Information? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
					{
						string Query = "DELETE from coverage WHERE id ='" + dtGridCoverage.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
						MySQL.Query(Query);
						GenericCollection.coverage.RemoveAll(r => r.Id == dtGridCoverage.Rows[e.RowIndex].Cells["id"].Value.ToString());
						MessageBox.Show("Information deleted");
						LoadCoverage();

					}

				}

			}
			catch (Exception c)
			{
				MessageBox.Show(c.Message.ToString() + "");
			}
		}
		public void LoadEmergency()
		{
			// create and execute query  
			t = new DataTable();

			t.Columns.Add("id");
			t.Columns.Add("uri");
			t.Columns.Add(new DataColumn("Img", typeof(Bitmap)));//1
			t.Columns.Add("No");
			t.Columns.Add("Name");
			t.Columns.Add("Contact");
			t.Columns.Add("Address");
			t.Columns.Add("City");
			t.Columns.Add("State");
			t.Columns.Add("Zip");
			t.Columns.Add("Gender");
			t.Columns.Add("Relationship");
			t.Columns.Add("Sync");
			t.Columns.Add("Created");

			t.Columns.Add(new DataColumn("Delete", typeof(Image)));//1


			Bitmap b = new Bitmap(50, 50);
			using (Graphics g = Graphics.FromImage(b))
			{
				g.DrawString("Loading...", this.Font, new SolidBrush(Color.Black), 0f, 0f);
			}
			Image view = new Bitmap(Properties.Resources.Note_Memo_16);
			Image delete = new Bitmap(Properties.Resources.Server_Delete_16);
			string Q = "SELECT * FROM emergency WHERE customerID = '" + CustomerID + "' ";
			foreach (Emergency c in GenericCollection.emergencies.Where(u => u.CustomerID == CustomerID))
			{
				try
				{
					t.Rows.Add(new object[] { c.Id, c.Image as string, b, c.No, c.Name, c.Contact, c.Address, c.City, c.State, c.Zip, c.Gender, c.Relationship, c.Sync, c.Created, delete });

				}
				catch (Exception m)
				{
					MessageBox.Show("" + m.Message);
					Helper.Exceptions(m.Message, "Viewing customer {each customer list }" + c.Name);
				}
			}

			dtGridEmerg.DataSource = t;

			ThreadPool.QueueUserWorkItem(delegate
			{
				foreach (DataRow row in t.Rows)
				{
					try
					{

						Image img = Helper.Base64ToImage(row["uri"].ToString().Replace('"', ' ').Trim());
						System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
						Bitmap bps = new Bitmap(bmp, 50, 50);
						Image dstImage = Helper.CropToCircle(bps, Color.White);
						row["Img"] = dstImage;

					}
					catch
					{

					}
				}
			});

			dtGridEmerg.AllowUserToAddRows = false;
			// dtGrid.Columns["View"].DefaultCellStyle.BackColor = Color.LightGreen;
			//  dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
			dtGridEmerg.RowTemplate.Height = 60;
			dtGridEmerg.Columns["uri"].Visible = false;
			dtGridEmerg.Columns["id"].Visible = false;
			// dtGrid.Columns["select"].Width = 30;

		}

		public void LoadPractitioner()
		{			
			t = new DataTable();
			t.Columns.Add("id");
			t.Columns.Add("uri");
			t.Columns.Add(new DataColumn("Img", typeof(Bitmap)));
			t.Columns.Add("Name");
			t.Columns.Add("Contact");
			t.Columns.Add("Address");
			t.Columns.Add("City");
			t.Columns.Add("State");
			t.Columns.Add("Zip");
			t.Columns.Add("Gender");
		
			t.Columns.Add("Created");
			t.Columns.Add(new DataColumn("Delete", typeof(Image)));

			Bitmap b = new Bitmap(50, 50);
			using (Graphics g = Graphics.FromImage(b))
			{
				g.DrawString("Loading...", this.Font, new SolidBrush(Color.Black), 0f, 0f);
			}
			Image view = new Bitmap(Properties.Resources.Note_Memo_16);
			Image delete = new Bitmap(Properties.Resources.Server_Delete_16);
			//string Q = "SELECT * FROM practitioner WHERE customerID = '" + CustomerID + "' ";
			foreach (Practitioner c in GenericCollection.practitioners.Where(u => u.CustomerID == CustomerID))
			{
				try
				{
					t.Rows.Add(new object[] { c.Id, c.Image as string, b, c.Name, c.Contact, c.Address, c.City, c.State, c.Zip, c.Gender, c.Created, delete });

				}
				catch (Exception m)
				{
					MessageBox.Show("" + m.Message);
					Helper.Exceptions(m.Message, "Viewing customer {each customer list }" + c.Name);
				}
			}

			dtGridMed.DataSource = t;
			ThreadPool.QueueUserWorkItem(delegate
			{
				foreach (DataRow row in t.Rows)
				{
					try
					{

						Image img = Helper.Base64ToImage(row["uri"].ToString().Replace('"', ' ').Trim());
						System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
						Bitmap bps = new Bitmap(bmp, 50, 50);
						Image dstImage = Helper.CropToCircle(bps, Color.White);
						row["Img"] = dstImage;

					}
					catch
					{

					}
				}
			});

			dtGridMed.AllowUserToAddRows = false;
			// dtGrid.Columns["View"].DefaultCellStyle.BackColor = Color.LightGreen;
			//  dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
			dtGridMed.RowTemplate.Height = 60;
			dtGridMed.Columns["uri"].Visible = false;
			dtGridMed.Columns["id"].Visible = false;
			// dtGrid.Columns["select"].Width = 30;

		}

		private void dtGridEmerg_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == dtGridEmerg.Columns["Delete"].Index && e.RowIndex >= 0)
			{
				if (MessageBox.Show("YES or No?", "Are you sure you want to delete this information? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
				{
					string Query = "DELETE from emergency WHERE id ='" + dtGridEmerg.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
					MySQL.Query(Query);
					GenericCollection.emergencies.RemoveAll(r => r.Id == dtGridEmerg.Rows[e.RowIndex].Cells["id"].Value.ToString());
					MessageBox.Show("Information deleted");
					LoadEmergency();

				}

			}
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			using (EmergencyDialog form = new EmergencyDialog(CustomerID))
			{
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{
					LoadEmergency();
				}
			}
		}
		public void LoadCondition()
		{
			// create and execute query  
			t = new DataTable();

			t.Columns.Add("id");
			t.Columns.Add("Name");
			t.Columns.Add("Type");
			t.Columns.Add("Details");			
			t.Columns.Add("Created");
			t.Columns.Add(new DataColumn("Delete", typeof(Image)));

			Image delete = new Bitmap(Properties.Resources.Server_Delete_16);
			//string Q = "SELECT * FROM condition WHERE customerID = '" + CustomerID + "' ";
			foreach (Conditions c in GenericCollection.conditions.Where(u=>u.CustomerID==CustomerID))
			{
				try
				{
					t.Rows.Add(new object[] { c.Id, c.Name, c.Type, c.Details,c.Created, delete });

				}
				catch (Exception m)
				{
					MessageBox.Show("" + m.Message);
					Helper.Exceptions(m.Message, "Viewing customer {each customer list }" + c.Name);
				}
			}

			dtGridCond.DataSource = t;
			dtGridCond.AllowUserToAddRows = false;
			// dtGrid.Columns["View"].DefaultCellStyle.BackColor = Color.LightGreen;
			//  dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
			dtGridCond.RowTemplate.Height = 60;

			dtGridCond.Columns["id"].Visible = false;


		}

		private void dtGridCond_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == dtGridCond.Columns["Delete"].Index && e.RowIndex >= 0)
			{
				if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Customer? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
				{
					string Query = "DELETE from condition WHERE id ='" + dtGridCond.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
					MySQL.Query(Query);
					GenericCollection.conditions.RemoveAll(r => r.Id == dtGridCond.Rows[e.RowIndex].Cells["id"].Value.ToString());
					MessageBox.Show("Information deleted");
					LoadCondition();

				}

			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			using (PractitionerDialog form = new PractitionerDialog(CustomerID, ""))
			{
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{
					LoadPractitioner();
				}
			}
		}

		private void imgCapture_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();
			open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
			if (open.ShowDialog() == DialogResult.OK)
			{
				// display image in picture box
				imgCapture.Image = new Bitmap(open.FileName);
				imgCapture.SizeMode = PictureBoxSizeMode.StretchImage;
				fileUrlTxtBx.Text = open.FileName;
			}
		}

		private void dtGridMed_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == dtGridMed.Columns["Delete"].Index && e.RowIndex >= 0)
			{
				if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Practitioner? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
				{
					string Query = "DELETE from practitioner WHERE id ='" + dtGridMed.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
					MySQL.Query(Query);
					GenericCollection.practitioners.RemoveAll(r => r.Id == dtGridMed.Rows[e.RowIndex].Cells["id"].Value.ToString());
					Helper.Log(Helper.UserName, "Deleted Doctor " + dtGridMed.Rows[e.RowIndex].Cells["practitioner"].Value.ToString() + "  " + DateTime.Now);

					MessageBox.Show("Information deleted");
					LoadPractitioner();

				}

			}
		}

		private void dtGridEmerg_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			string columnName = dtGridEmerg.Columns[e.ColumnIndex].HeaderText;
			try
			{
				String Query = "UPDATE emergency SET " + columnName + " ='" + dtGridEmerg.Rows[e.RowIndex].Cells[columnName].Value.ToString() + "' WHERE id = '" + dtGridEmerg.Rows[e.RowIndex].Cells["Id"].Value.ToString() + "'";
				MySQL.Query(Query);				
			}
			catch (Exception c)
			{
				//MessageBox.Show(c.Message.ToString());
				Helper.Exceptions(c.Message, "Editing Emergency contact grid");
				//MessageBox.Show("You have an invalid entry !");
			}

		}
		bool complete = true;
		

		private void contactTxt_TextChanged(object sender, EventArgs e)
		{
			contactTxt.Text = Helper.PhoneFormat(contactTxt.Text);
		}

		private void dtGridMed_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			string columnName = dtGridMed.Columns[e.ColumnIndex].HeaderText;
			try
			{

				String Query = "UPDATE practitioner SET " + columnName + " ='" + dtGridMed.Rows[e.RowIndex].Cells[columnName].Value.ToString() + "' WHERE id = '" + dtGridMed.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
				MySQL.Query(Query);				
				Helper.Log(Helper.UserName, "Updating practitioner " + dtGridMed.Rows[e.RowIndex].Cells["name"].Value.ToString() + "  " + DateTime.Now);

			}
			catch (Exception c)
			{
				//MessageBox.Show(c.Message.ToString());
				Helper.Exceptions(c.Message, "Editing of practitioners in cell content grid");
				//MessageBox.Show("You have an invalid entry !");
			}
		}
	}
}

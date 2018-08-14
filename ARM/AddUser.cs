using ARM.DB;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
	public partial class AddUser : MetroFramework.Forms.MetroForm
	{
		string UsersID;
		public AddUser(string UsersID)
		{
			InitializeComponent();

			if (!string.IsNullOrEmpty(UsersID))
			{

				Profile(UsersID);
			}
			else
			{

				updateBtn.Visible = false;
			}
			AutoCompleteState();
			if (string.IsNullOrEmpty(Helper.Level))
			{
				levelCbx.Text = "1";
			}

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
		private Users c;
		private void Profile(string usersID)
		{
			UsersID = usersID;
			c = new Users();//.Select(UsersID);
			c =Users.Select(UsersID);
			nameTxt.Text = c.Name;
			contactTxt.Text = c.Contact;
			addressTxt.Text = c.Address;
			cityTxt.Text = c.City;
			stateTxt.Text = c.State;
			zipTxt.Text = c.Zip;
			categoryCbx.Text = c.Category;
			genderCbx.Text = c.Gender;
			socialTxt.Text = c.Ssn;
			specialityCbx.Text = c.Speciality;
			emailTxt.Text = c.Email;
			button3.Visible = false;
			departmentCbx.Text = c.Department;
			levelCbx.Text = c.Level;

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
			if (!complete)
			{
				MessageBox.Show("Incomplete Fields");
			}
			if (!string.IsNullOrEmpty(UsersID))
			{
				Update(UsersID);
				return;
			}
			string level = "";
			try
			{
				if (string.IsNullOrEmpty(Helper.Level) && Convert.ToInt32(Helper.Level) < 5)
				{
					level = "1";
				}
				else
				{
					level = levelCbx.Text;
				}
			}
			catch (Exception r)
			{
				//MessageBox.Show(c.Message.ToString());
				Helper.Exceptions(r.Message, "Editing User cell content grid user level value ");
			}
			if (string.IsNullOrEmpty(levelCbx.Text))
			{
				MessageBox.Show("You have an invalid entry please select access level !");
				levelCbx.BackColor = Color.Red;
				return;
			}
			if (string.IsNullOrEmpty(departmentCbx.Text))
			{
				MessageBox.Show("Please input the department !");
				departmentCbx.BackColor = Color.Red;
				return;
			}
			MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
			string fullimage = Helper.ImageToBase64(stream);
			string id = Guid.NewGuid().ToString();
			Users c = new Users(id, nameTxt.Text, emailTxt.Text, contactTxt.Text, addressTxt.Text, cityTxt.Text, stateTxt.Text, zipTxt.Text, categoryCbx.Text, socialTxt.Text, specialityCbx.Text, genderCbx.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "false", Helper.CompanyID, Helper.MD5Hash(passwordTxt.Text), fullimage, departmentCbx.Text, "No", level);
			MySQL.Insert(c);
			GenericCollection.users.Add(c);

			MessageBox.Show("Information Saved");
			Helper.Log(Helper.UserName, "Adding user " + DateTime.Now);

			this.DialogResult = DialogResult.OK;
			this.Dispose();

		}
		string Query;
		private void Update(string UsersID)
		{
			MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
			string fullimage = Helper.ImageToBase64(stream);

			var obj = GenericCollection.users.FirstOrDefault(x => x.Id == UsersID);
			if (obj != null) { obj.Name = this.nameTxt.Text; obj.Address = addressTxt.Text; obj.City = cityTxt.Text; obj.State = stateTxt.Text; obj.Zip = zipTxt.Text; obj.Email = emailTxt.Text; obj.Image = fullimage; obj.Contact = contactTxt.Text; obj.Category = categoryCbx.Text; obj.Speciality = specialityCbx.Text; obj.Sync = "false"; obj.Department = departmentCbx.Text; obj.Level = levelCbx.Text; }

			if (passwordTxt.Text != "")
			{
				if (Helper.UserID == UsersID)
				{
					Query = "UPDATE users SET name='" + this.nameTxt.Text + "',address='" + addressTxt.Text + "',city='" + cityTxt.Text + "',state='" + stateTxt.Text + "',zip='" + zipTxt.Text + "',password='" + Helper.MD5Hash(this.passwordTxt.Text) + "',email='" + this.emailTxt.Text + "',image='" + fullimage + "',contact='" + contactTxt.Text + "',speciality='" + specialityCbx.Text + "',category='" + categoryCbx.Text + "',sync='false',department = '" + departmentCbx.Text + "',level='" + levelCbx.Text + "' WHERE Id = '" + UsersID + "'";
					
				}
				else
				{
					Helper.Log(Helper.UserName, "Tried to update user password, not cool  " + nameTxt.Text);
					MessageBox.Show("Access Denied ! ");
					return;
				}
			}
			else
			{
				Query = "UPDATE users SET name='" + this.nameTxt.Text + "',address='" + addressTxt.Text + "',city='" + cityTxt.Text + "',state='" + stateTxt.Text + "',zip='" + zipTxt.Text + "',email='" + this.emailTxt.Text + "',image='" + fullimage + "',contact='" + contactTxt.Text + "',category='" + categoryCbx.Text + "',speciality='" + specialityCbx.Text + "',sync='false',department = '" + departmentCbx.Text + "',level='" + levelCbx.Text + "' WHERE Id = '" + UsersID + "'";
			}
			
			MySQL.Query(Query);
			
			Helper.Log(Helper.UserName, "Updated user information " + nameTxt.Text);
			MessageBox.Show("Information Updated");
			this.DialogResult = DialogResult.OK;
			this.Dispose();
		}
		private void confirmTxt_Leave(object sender, EventArgs e)
		{
			if (confirmTxt.Text != passwordTxt.Text)
			{
				MessageBox.Show("Passwords donot match ");
			}
		}

		private void metroLabel9_Click(object sender, EventArgs e)
		{

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

		private void zipTxt_KeyPress(object sender, KeyPressEventArgs e)
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
		bool complete = true;
		private void emailTxt_Leave(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(emailTxt.Text))
			{
				if (!Helper.IsValidEmail(emailTxt.Text))
				{
					emailTxt.BackColor = Color.Red;
					MessageBox.Show("Invalid Email !");
					complete = false;
				}
				else
				{
					complete = true;

				}
			}
			else
			{
				emailTxt.BackColor = Color.Red;

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

		private void genderCbx_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void updateBtn_Click(object sender, EventArgs e)
		{
			if (!complete)
			{
				MessageBox.Show("Incomplete Fields");
			}
			if (!string.IsNullOrEmpty(UsersID))
			{
				Update(UsersID);
				return;
			}
		}

		private void contactTxt_TextChanged(object sender, EventArgs e)
		{
			contactTxt.Text = Helper.PhoneFormat(contactTxt.Text);
		}
	}
}

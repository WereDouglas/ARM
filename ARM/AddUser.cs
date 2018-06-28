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
		private Users c;
        private void Profile(string usersID)
        {
            UsersID = usersID;
            c = new Users();//.Select(UsersID);
            c = Users.Select(UsersID);
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
                Helper.Exceptions(t.Message + "view load image for window ");

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
			if (!complete) {

				MessageBox.Show("Incomplete Fields");
			}

			if (!string.IsNullOrEmpty(UsersID))
            {
                Update(UsersID);
                return;
            }
            MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = Helper.ImageToBase64(stream);

            string id = Guid.NewGuid().ToString();
            Users c = new Users(id, nameTxt.Text, emailTxt.Text, contactTxt.Text, addressTxt.Text, cityTxt.Text, stateTxt.Text, zipTxt.Text, categoryCbx.Text,socialTxt.Text,specialityCbx.Text, genderCbx.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID, Helper.MD5Hash(passwordTxt.Text), fullimage);

            string save = DBConnect.InsertPostgre(c);
            if (save != "")
            {
                Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                DBConnect.InsertPostgre(q);

                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }
        string Query;
        private void Update(string UsersID)
        {

            MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = Helper.ImageToBase64(stream);

            if (passwordTxt.Text != "")
            {
                Query = "UPDATE users SET name='" + this.nameTxt.Text + "',address='" + addressTxt.Text + "',city='" + cityTxt.Text + "',state='" + stateTxt.Text + "',zip='" + zipTxt.Text + "',password='" + Helper.MD5Hash(this.passwordTxt.Text) + "',email='" + this.emailTxt.Text + "',image='" + fullimage + "',contact='" + contactTxt.Text + "',speciality='" + specialityCbx.Text + "',category='" + categoryCbx.Text + "',sync='false' WHERE Id = '" + UsersID + "'";
            }
            else
            {
                Query = "UPDATE users SET name='" + this.nameTxt.Text + "',address='" + addressTxt.Text + "',city='" + cityTxt.Text + "',state='" + stateTxt.Text + "',zip='" + zipTxt.Text + "',email='" + this.emailTxt.Text + "',image='" + fullimage + "',contact='" + contactTxt.Text + "',category='" + categoryCbx.Text + "',speciality='"+specialityCbx.Text+"',sync='false' WHERE Id = '" + UsersID + "'";

            }
            DBConnect.QueryPostgre(Query);

            Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
            DBConnect.InsertPostgre(q);

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
			else {
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
	}
}

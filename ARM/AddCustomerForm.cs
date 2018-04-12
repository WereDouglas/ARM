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
    public partial class AddCustomerForm : MetroFramework.Forms.MetroForm
    {
        string CustomerID;
        public AddCustomerForm(string customerID)
        {
            InitializeComponent();
            try
            {
                noTxt.Text = (DBConnect.Max("SELECT MAX(CAST(no AS DOUBLE PRECISION)) FROM customer") + 1).ToString();
            }
            catch
            {
                noTxt.Text = " 1 ";
            }
            if (!string.IsNullOrEmpty(customerID))
            {
                Profile(customerID);
            }
        }
        private Customer c;
        private void Profile(string customerID)
        {
            CustomerID = customerID;
            c = new Customer();//.Select(customerID);
            c = Customer.Select(customerID);
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CustomerID))
            {

                Update(CustomerID);
                return;
            }
            MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = Helper.ImageToBase64(stream);

            string id = Guid.NewGuid().ToString();
            Customer c = new Customer(id, nameTxt.Text, contactTxt.Text, addressTxt.Text, noTxt.Text, cityTxt.Text, stateTxt.Text, zipTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), ssnTxt.Text, dobTxt.Text, categoryCbx.Text, false, fullimage);
            if (DBConnect.Insert(c) != "")
            {
                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }
        private void Update(string customerID)
        {

            MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = Helper.ImageToBase64(stream);
            Customer c = new Customer(customerID, nameTxt.Text, contactTxt.Text, addressTxt.Text, noTxt.Text, cityTxt.Text, stateTxt.Text, zipTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), ssnTxt.Text, dobTxt.Text, categoryCbx.Text, false, fullimage);
            DBConnect.Update(c, customerID);

            MessageBox.Show("Information Updated");
            this.DialogResult = DialogResult.OK;
            this.Dispose();

        }
    }
}

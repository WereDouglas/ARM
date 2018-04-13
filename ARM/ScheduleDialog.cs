﻿using ARM.DB;
using ARM.Model;
using ARM.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
    public partial class ScheduleDialog : MetroFramework.Forms.MetroForm
    {

        Dictionary<string, string> UserDictionary = new Dictionary<string, string>();
        Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
        string CustomerID;
        string UserID;
        public ScheduleDialog(string start, string end, string date)
        {
            InitializeComponent();

            startHrTxt.Format = DateTimePickerFormat.Custom;
            startHrTxt.CustomFormat = "HH:mm:ss"; // Only use hours and minutes
            startHrTxt.ShowUpDown = true;

            endHrTxt.Format = DateTimePickerFormat.Custom;
            endHrTxt.CustomFormat = "HH:mm:ss"; // Only use hours and minutes
            endHrTxt.ShowUpDown = true;


            if (!String.IsNullOrEmpty(start))
            {

                startHrTxt.Text = Convert.ToDateTime(start).ToShortTimeString();
                endHrTxt.Text = Convert.ToDateTime(end).ToShortTimeString();
                openedDate.Text = date;

            }
            AutoCompleteCustomer();
            AutoCompleteUser();
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
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(categoryCbx.Text)) {
                categoryCbx.BackColor = Color.Red;
                MessageBox.Show(" Please select the category ");
                return;
            }
            if (string.IsNullOrEmpty(statusCbx.Text))
            {
                statusCbx.BackColor = Color.Red;
                MessageBox.Show(" Please select the status ");
                return;
            }

            if (startHrTxt.Text == "" || endHrTxt.Text == "")
            {
                MessageBox.Show("Please input the start time and end time for the Schedule ");
                return;
            }
            string ID = Guid.NewGuid().ToString();
            var start = Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd") + "T" + this.startHrTxt.Text;
            var end = Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd") + "T" + this.endHrTxt.Text;
           

            Schedule _event = new Schedule(ID, Convert.ToDateTime(this.openedDate.Text).ToString("yyyy-MM-dd"), CustomerID, UserID, start, end, locationTxt.Text, locationTxt.Text, Helper.CleanString(this.detailsTxt.Text), categoryCbx.Text, periodTxt.Text, categoryCbx.Text, statusCbx.Text, Convert.ToDouble(totalTxt.Text), DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), false);
            if (DBConnect.Insert(_event) != "")
            {
                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }

        }
        string Query;
        private void Update(string itemID)
        {

            //MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            //string fullimage = Helper.ImageToBase64(stream);
            //Item c = new Item(itemID, nameTxt.Text, categoryCbx.Text, typeCbx.Text, descriptionxt.Text, costTxt.Text, batchTxt.Text, serialTxt.Text, barTxt.Text, unitTxt.Text, unitDescTxt.Text, manuTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, fullimage);
            //DBConnect.Update(c, itemID);
            //MessageBox.Show("Information Updated");
            //this.DialogResult = DialogResult.OK;
            //this.Dispose();
        }
        Customer c;
        private void customerCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CustomerID = CustomerDictionary[customerCbx.Text];
                c = new Customer();//.Select(ItemID);
                c = Customer.Select(CustomerID);
                locationTxt.Text = c.Address + " " + c.City + " " + c.State;
                Image img = Helper.Base64ToImage(c.Image);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                cusPbx.Image = bmp;
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(cusPbx.DisplayRectangle);
                cusPbx.Region = new Region(gp);
                cusPbx.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch { }
        }
        Users u;
        Rate r;
        private void userCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                UserID = UserDictionary[userCbx.Text];
                u = new Users();//.Select(ItemID);
                u = Users.Select(UserID);
                Image img = Helper.Base64ToImage(u.Image);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                userPbx.Image = bmp;
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(userPbx.DisplayRectangle);
                userPbx.Region = new Region(gp);
                userPbx.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch { }
            r = new Rate();
            r = Rate.Select(UserID);
            costTxt.Text = r.Amount.ToString();
            totalTxt.Text = (r.Amount * Convert.ToDouble(periodTxt.Text)).ToString();
            try
            {
                
            }
            catch
            {
                costTxt.Text = "0";
                totalTxt.Text = "0";

            }
        }

        private void ScheduleDialog_Load(object sender, EventArgs e)
        {

        }

        private void categoryCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Convert.ToDateTime(openedDate.Text).ToString("dd-MM-yyyy") + " " + startHrTxt.Text);
           var start = Convert.ToDateTime(Convert.ToDateTime(startHrTxt.Text).ToString("HH:mm:ss"));
           var end = Convert.ToDateTime(Convert.ToDateTime(endHrTxt.Text).ToString("HH:mm:ss"));
            var hours = (end - start).TotalHours;
            periodTxt.Text = hours.ToString();
        }
    }
}
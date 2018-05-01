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
    public partial class AddVendor : MetroFramework.Forms.MetroForm
    {
        string VendorID;
        public AddVendor(string vendorID)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(vendorID))
            {

                Profile(vendorID);
            }
        }
        private Vendor c;
        private void Profile(string vendorID)
        {
            VendorID = vendorID;
            c = new Vendor();//.Select(VendorID);
            c = Vendor.Select(vendorID);
            nameTxt.Text = c.Name;
            contactTxt.Text = c.Contact;
            addressTxt.Text = c.Address;
            cityTxt.Text = c.City;
            stateTxt.Text = c.State;
            zipTxt.Text = c.Zip;
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
            if (!string.IsNullOrEmpty(VendorID))
            {
                Update(VendorID);
                return;
            }
            MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = Helper.ImageToBase64(stream);

            string id = Guid.NewGuid().ToString();
            Vendor c = new Vendor(id,nameTxt.Text,emailTxt.Text, contactTxt.Text, addressTxt.Text, noTxt.Text, cityTxt.Text, stateTxt.Text, zipTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), categoryCbx.Text, false, Helper.CompanyID, fullimage);
            if (DBConnect.InsertPostgre(c) != "")
            {
                Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.InsertPostgre(c)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                DBConnect.InsertPostgre(q);
                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }
        string Query;
        private void Update(string vendorID)
        {

            MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = Helper.ImageToBase64(stream);
            Vendor c = new Vendor(vendorID, nameTxt.Text, emailTxt.Text, contactTxt.Text, addressTxt.Text, noTxt.Text, cityTxt.Text, stateTxt.Text, zipTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), categoryCbx.Text, false, Helper.CompanyID, fullimage);
            DBConnect.UpdatePostgre(c, vendorID);
            MessageBox.Show("Information Updated");
            this.DialogResult = DialogResult.OK;
            this.Dispose();
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

        private void emailTxt_Leave(object sender, EventArgs e)
        {
            if (!Helper.Email(emailTxt.Text))
            {
                emailTxt.BackColor = Color.Red;
                MessageBox.Show("Invalid Email !");
            }
        }
    }
}

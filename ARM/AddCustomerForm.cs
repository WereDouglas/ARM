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
    public partial class AddCustomerForm : MetroFramework.Forms.MetroForm
    {
        string CustomerID;
        public AddCustomerForm(string customerID,string category)
        {
            
            InitializeComponent();
            this.Text = category;
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
                saveBtn.Visible = false;
            }
            else {

                CustomerID = Guid.NewGuid().ToString();
                updateBtn.Visible = false;
            }
            categoryCbx.Text = category;
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
           
            MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = Helper.ImageToBase64(stream);
           
            Customer c = new Customer(CustomerID, nameTxt.Text, contactTxt.Text, addressTxt.Text, noTxt.Text, cityTxt.Text, stateTxt.Text, zipTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), ssnTxt.Text, dobTxt.Text, categoryCbx.Text, false,Helper.CompanyID, fullimage);
            if (DBConnect.InsertPostgre(c) != "")
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
            Customer c = new Customer(customerID, nameTxt.Text, contactTxt.Text, addressTxt.Text, noTxt.Text, cityTxt.Text, stateTxt.Text, zipTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), ssnTxt.Text, dobTxt.Text, categoryCbx.Text, false, Helper.CompanyID, fullimage);
            DBConnect.UpdatePostgre(c, customerID);

            MessageBox.Show("Information Updated");
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
            using (InsuranceDialog form = new InsuranceDialog(CustomerID,noTxt.Text))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CustomerID))
            {

                Update(CustomerID);
                return;
            }
        }
    }
}

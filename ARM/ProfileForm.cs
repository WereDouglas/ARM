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
    public partial class ProfileForm : MetroFramework.Forms.MetroForm
    {
        string CompanyID="";
        public ProfileForm(string companyID)
        {
            InitializeComponent();
            try
            {
                Profile(companyID);
            }
            catch(Exception p) {
                CompanyID = "";
                MessageBox.Show("No profile defined " + p.Message);
               
            }
            
        }
        private Company c;
        private void Profile(string companyID)
        {
            CompanyID = companyID;     
            c = new Company();//.Select(CompanyID);
            c = Company.Select();
            nameTxt.Text = c.Name;
            contactTxt.Text = c.Contact;
            addressTxt.Text = c.Address;
            telTxt.Text = c.Tel;
            emailTxt.Text = c.Email;
            faxTxt.Text = c.Fax;
            
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
            if (!string.IsNullOrEmpty(CompanyID))
            {
                Update(CompanyID);
                return;
            }
            MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = Helper.ImageToBase64(stream);

            string id = Guid.NewGuid().ToString();
            Company c = new Company(id, nameTxt.Text,addressTxt.Text,contactTxt.Text, emailTxt.Text, faxTxt.Text, telTxt.Text,DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false,fullimage);
            if (DBConnect.InsertPostgre(c) != "")
            {
                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }
        string Query;
        private void Update(string CompanyID)
        {
            MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = Helper.ImageToBase64(stream);
            Company c = new Company(CompanyID, nameTxt.Text, addressTxt.Text, contactTxt.Text, emailTxt.Text, faxTxt.Text, telTxt.Text,DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, fullimage);
            DBConnect.UpdatePostgre(c, CompanyID);
           
                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
          
        }
      
    }
}

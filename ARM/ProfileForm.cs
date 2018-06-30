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
        string CompanyID = "";
        public ProfileForm(string companyID)
        {
            InitializeComponent();
            
            if (string.IsNullOrEmpty(companyID))
            {
                CompanyID = Guid.NewGuid().ToString();
                updateBtn.Visible = false;
                try
                {
                    createPostgreDB();
                }
                catch(Exception p) {

                    MessageBox.Show("No profile defined " + p.Message);

                }
            }
            else
            {
                try
                {
                    Profile(companyID);
                }
                catch (Exception p)
                {
                    CompanyID = "";
                    //  MessageBox.Show("No profile defined " + p.Message);
                    if (MessageBox.Show("YES or No?", "Setup Database ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        createPostgreDB();
                    }
                }


                saveBtn.Visible = false;
                CompanyID = companyID;
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
            telTxt.Text = c.OfficePhone;
            emailTxt.Text = c.Email;
            faxTxt.Text = c.OfficeFax;
			specialityTxt.Text = c.Speciality;
			npiTxt.Text = c.Npi;
			tinTxt.Text = c.Tin;
			officeTxt.Text = c.Office;
			providerNoTxt.Text = c.ProviderID;
			officePhoneTxt.Text = c.OfficePhone;
			officeFaxTxt.Text = c.OfficeFax;

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
                Helper.Exceptions(t.Message , "view load image for window ");

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
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


            Company c = new Company(CompanyID,nameTxt.Text, contactTxt.Text, emailTxt.Text,npiTxt.Text,addressTxt.Text,officeTxt.Text,providerNoTxt.Text,tinTxt.Text, faxTxt.Text, telTxt.Text, "","","","",DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, CompanyID, fullimage);
            string save = DBConnect.InsertPostgre(c);
            if (save != "")
            {
                Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                DBConnect.InsertPostgre(q);
                Helper.CompanyID = CompanyID;
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
            Company c = new Company(CompanyID, nameTxt.Text, contactTxt.Text, emailTxt.Text, npiTxt.Text,addressTxt.Text,officePhoneTxt.Text, providerNoTxt.Text, tinTxt.Text, officePhoneTxt.Text,officeFaxTxt.Text,"", "", "", specialityTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, CompanyID, fullimage);
            string save = DBConnect.UpdatePostgre(c, CompanyID);

            Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
            DBConnect.InsertPostgre(q);

            MessageBox.Show("Information Updated !");
            this.DialogResult = DialogResult.OK;
            this.Dispose();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Query = "UPDATE company SET sync ='false'";
            DBConnect.QueryPostgre(Query);
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CompanyID))
            {
                Update(CompanyID);
                return;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AdvancedForm f = new AdvancedForm();
            f.Show();
        }
        private void createPostgreDB()
        {
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Customer()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Exceptions()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Users()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Invoice()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Product()));

            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Vendor()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Invoice()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Transaction()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Payment()));

            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Schedule()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Rate()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Account()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Responsible()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Coverage()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new ItemCoverage()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Orders()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Instruction()));

            
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Delivery()));

            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new ItemReview()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new PatientStatus()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Follow()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new ItemStatus()));

            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Company()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Practitioner()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Care()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Cases()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Conditions()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Dosage()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Emergency()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Facility()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new ICD10()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new PatientFollowStatus()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Pharmacy()));

            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Service()));
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
           

            string Query = "drop schema arm cascade;";
            DBConnect.QueryPostgre(Query);

            //string Query = "drop schema arm cascade;";
            //DBConnect.QueryPostgre(Query);
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SettingsForm form = new SettingsForm())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}

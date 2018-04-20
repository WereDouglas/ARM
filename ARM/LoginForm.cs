using ARM.DB;
using ARM.Model;
using ARM.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        public int r = 9;
        public LoginForm()
        {

            InitializeComponent();
            InitializeCulture();
        }
        protected void InitializeCulture()
        {
            CultureInfo CI = new CultureInfo("en-Gb");
            CI.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";

            Thread.CurrentThread.CurrentCulture = CI;
            Thread.CurrentThread.CurrentUICulture = CI;
            //  base.InitializeCulture();
            newInstallation();
        }
        private void newInstallation()
        {
            try
            {
                string c = Company.List().First().Name;

                Image img = Helper.Base64ToImage(Company.List().First().Image);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                //Bitmap bps = new Bitmap(bmp, 50, 50);
                pictureBox2.Image = bmp;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                Helper.CompanyID = Company.List().First().Id;
            }
            catch
            {
                
                
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Helper.UserID = Users.List().First().Id;
            Helper.UserImage = Users.List().First().Image;
            Helper.UserName = Users.List().First().Name;
            //  Helper.Log(Helper.UserName, "Log in ");
            Helper.CompanyID = Company.List().First().Id;
            if (medicalChk.Checked)
            {

                MedicalForm frm = new MedicalForm();
                frm.Show();
            }
            if (payrollChk.Checked)
            {
                HrmForm f = new HrmForm();
                f.Show();
            }
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            createPostgreDB();
        }
        private void createPostgreDB()
        {
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Customer()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Exceptions()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Users()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Invoice()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Item()));
           
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Vendor()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Invoice()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Transaction()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Payment()));

            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Schedule()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Rate()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Account()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Responsible()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Insurance()));

            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Orders()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Instruction()));

            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Deliveries()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Delivery()));

            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new ItemReview()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new PatientStatus()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Follow()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new ItemStatus()));

            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Company()));
        }

        private void createMySqlDB()
        {
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Customer()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Exceptions()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Users()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Invoice()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Item()));

            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Vendor()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Invoice()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Transaction()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Payment()));

            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Schedule()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Rate()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Account()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Responsible()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Insurance()));

            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Orders()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Instruction()));

            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Deliveries()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Delivery()));

            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new ItemReview()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new PatientStatus()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Follow()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new ItemStatus()));

            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Company()));
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            createMySqlDB();
        }
    }
}

﻿using ARM.DB;
using ARM.Model;
using ARM.Util;
using Npgsql;
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
using System.Xml.Linq;

namespace ARM
{
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        public int r = 9;
        public LoginForm()
        {
            InitializeComponent();
           /// LoadingWindow.ShowSplashScreen();
           
           
            InitializeCulture();
           /// LoadingWindow.CloseForm();
            LoadSettings();
            autocomplete();
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
            loginBtn.Visible = false;
            if (contactTxt.Text == "" || passwordTxt.Text == "")
            {
                MessageBox.Show("Insert login credentials");
                loginBtn.Visible = true;
                return;
            }
            try
            {
               

                Helper.contact = u.Where(g => g.Contact.Contains(contactTxt.Text) && g.Password.Equals(Helper.MD5Hash(passwordTxt.Text))).First().Contact;
            }
            catch
            {
                MessageBox.Show("Invalid login credentials");
                loginBtn.Visible = true;
                return;

            }
            if (String.IsNullOrEmpty(Helper.contact))
            {
                MessageBox.Show("Access denied contact undefined");
                loginBtn.Visible = true;
            }
            else
            {

                Helper.UserID = u.Where(g => g.Contact.Contains(contactTxt.Text) && g.Password.Equals(Helper.MD5Hash(passwordTxt.Text))).First().Id;
                Helper.UserImage = u.Where(g => g.Contact.Contains(contactTxt.Text) && g.Password.Equals(Helper.MD5Hash(passwordTxt.Text))).First().Image;
                Helper.UserName = u.Where(g => g.Contact.Contains(contactTxt.Text) && g.Password.Equals(Helper.MD5Hash(passwordTxt.Text))).First().Name;

                //  Helper.Log(Helper.UserName, "Log in ");
                Helper.CompanyID = Company.List().First().Id;
                if (medicalChk.Checked)
                {

                    MedicalForm frm = new MedicalForm();
                    frm.Show();
                    this.Hide();
                }
                if (payrollChk.Checked)
                {
                    HrmForm f = new HrmForm();
                    f.Show();
                    this.Hide();
                }
                loginBtn.Visible = true;
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

        private void button4_Click(object sender, EventArgs e)
        {

            using (SettingsForm form = new SettingsForm())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadSettings();
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }
        private void LoadSettings()
        {
            XDocument xmlDoc = null;
            try
            {
                xmlDoc = XDocument.Load(Helper.XMLFile());
            }
            catch {

                using (SettingsForm form = new SettingsForm())
                {
                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        LoadSettings();
                    }
                }

            }

            xmlDoc = XDocument.Load(Helper.XMLFile());
            var servers = from person in xmlDoc.Descendants("Server")
           
                          select new
                          {
                              Name = person.Element("Name").Value,
                              Ip = person.Element("Ip").Value

                          };
            foreach (var server in servers)
            {
                
                Helper.serverName = server.Name;
                Helper.serverIP  = server.Ip;

            }

            if (!string.IsNullOrEmpty(Helper.serverName))
            {
                Helper.serverIP = Helper.IPAddressCheck(Helper.serverName);
                lblStatus.Text += Helper.serverIP + ": " + Helper.serverName;
                if (!string.IsNullOrEmpty(Helper.serverIP))
                {
                    DBConnect.conn = new NpgsqlConnection("Server=" + Helper.serverIP + ";Port=5432;User Id=postgres;Password=Admin;Database=arm;");

                    if (TestServerConnection())
                    {
                        lblStatus.Text = lblStatus.Text + " Server connected you can continue to login";
                        lblStatus.ForeColor = Color.Green;
                        autocomplete();
                    }
                    else
                    {

                        lblStatus.Text = ("You are not able to connect to the server contact the administrator for further assistance");
                        lblStatus.ForeColor = Color.Red;
                    }

                } else {

                    lblStatus.Text = ("No server IP defined !");
                    lblStatus.ForeColor = Color.Red;
                }

            }
            else
            {
                MessageBox.Show("Please start the server");
                return;
            }  
           
        }
        
        
        List<Users> u = new List<Users>();
        private bool TestServerConnection()
        {
              u = Users.List();
            try
            {

                if (u.Count() < 0)
                {
                    lblStatus.Text = ("You are not able to connect to the server contact the administrator for further assistance");
                    lblStatus.ForeColor = Color.Red;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception c)
            {
                System.Diagnostics.Debug.WriteLine(c.ToString());
               
                MessageBox.Show(c.Message.ToString());
                lblStatus.Text = ("You are not able to connect to the server contact the administrator for further assistance");
                lblStatus.ForeColor = Color.Red;
                return false;

            }
        }
        private void autocomplete()
        
            {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            DataTable dt = new DataTable();
            foreach (Users u in Users.List())
            {
                AutoItem.Add(u.Contact);
            }
            contactTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            contactTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            contactTxt.AutoCompleteCustomSource = AutoItem;
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();

        }

        private void passwordTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBtn.PerformClick();
            }
        }
    }
}

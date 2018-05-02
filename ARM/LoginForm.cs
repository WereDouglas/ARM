using ARM.DB;
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
using AutoUpdaterDotNET;

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

        private void createMySqlDB()
        {
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Customer()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Exceptions()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Users()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Invoice()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Product()));

            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Vendor()));
            
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Transaction()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Payment()));

            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Schedule()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Rate()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Account()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Responsible()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Coverage()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new ItemCoverage()));

            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Orders()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Instruction()));


            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Delivery()));

            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new ItemReview()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new PatientStatus()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Follow()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new ItemStatus()));

            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Company()));

            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new CaseTransaction()));

            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Practitioner()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Care()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Cases()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Conditions()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Dosage()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Emergency()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Facility()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new ICD10()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new PatientFollowStatus()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Pharmacy()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Service()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new CaseTransaction()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Queries()));

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

            AutoUpdater.Start("http://arm.novariss.com/file/update.xml");

            //AutoUpdater.Start(Helper.fileUrl + "update.xml");
           // AutoUpdater.Start("http://rbsoft.org/updates/AutoUpdaterTest.xml");
            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.Mandatory = true;
            AutoUpdater.ReportErrors = true;
            // AutoUpdater.OpenDownloadPage = true;
            // AutoUpdater.DownloadPath = Environment.CurrentDirectory;


            //System.Timers.Timer timer = new System.Timers.Timer
            //{
            //    Interval = 2 * 60 * 1000,
            //    SynchronizingObject = this
            //};
            //timer.Elapsed += delegate
            //{
            //    AutoUpdater.Start("http://rbsoft.org/updates/AutoUpdaterTest.xml");
            //};
            //timer.Start();
            //http://caseprofessional.pro/file/
        }
        private void LoadCompany()
        {
            try
            {
                c = Company.Select();
                if (string.IsNullOrEmpty(c.Name))
                {

                    using (ProfileForm form = new ProfileForm(""))
                    {
                        DialogResult dr = form.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            LoadUsers();
                        }
                    }

                }
                else
                {

                    Helper.CompanyID = c.Id;
                    LoadUsers();

                }
            }
            catch (Exception c)
            {
                // MessageBox.Show(c.Message);
                using (ProfileForm form = new ProfileForm(""))
                {
                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        if (string.IsNullOrEmpty(Helper.CompanyID))
                        {
                            LoadUsers();
                        }
                    }
                }

            }
        }
        private void LoadUsers()
        {

            try
            {
                u = Users.List();
                if (u.Count() < 1)
                {

                    using (AddUser form = new AddUser(""))
                    {
                        DialogResult dr = form.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            lblStatus.Text = lblStatus.Text + " Server connected you can continue to login ";
                            lblStatus.ForeColor = Color.Gray;
                            autocomplete();
                        }
                    }

                    return;
                }
                else
                {
                    lblStatus.Text = lblStatus.Text + " Server connected you can continue to login ";
                    lblStatus.ForeColor = Color.Gray;
                    autocomplete();
                    return;
                }
            }
            catch (Exception c)
            {
                System.Diagnostics.Debug.WriteLine(c.ToString());

                MessageBox.Show(c.Message.ToString());
                lblStatus.Text = ("No users defined");
                lblStatus.ForeColor = Color.Red;
                return;

            }

        }
        private void LoadSettings()
        {
            lblStatus.Text = "";
            XDocument xmlDoc = null;
            try
            {
                xmlDoc = XDocument.Load(Helper.XMLFile());
            }
            catch
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
                Helper.serverIP = server.Ip;

            }

            if (!string.IsNullOrEmpty(Helper.serverName))
            {
                try
                {
                    Helper.serverIP = Helper.IPAddressCheck(Helper.serverName);
                }
                catch (Exception c)
                {

                    MessageBox.Show(" " + c.Message);
                    return;

                }
                lblStatus.Text += Helper.serverIP + ": " + Helper.serverName;
                if (!string.IsNullOrEmpty(Helper.serverIP))
                {
                    DBConnect.conn = new NpgsqlConnection("Server=" + Helper.serverIP + ";Port=5432;User Id=postgres;Password=Admin;Database=arm;");

                    LoadCompany();

                }
                else
                {

                    lblStatus.Text = (" No server IP defined !");
                    lblStatus.ForeColor = Color.Red;
                }

            }
            else
            {
                MessageBox.Show(" Please start the server");
                return;
            }

        }


        List<Users> u = new List<Users>();
        Company c = new Company();

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

        private void button3_Click_1(object sender, EventArgs e)
        {
            createPostgreDB();

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
          
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Dosage()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Emergency()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Facility()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new ICD10()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new PatientFollowStatus()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Pharmacy()));

            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Service()));

            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new CaseTransaction()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Queries()));

            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Conditions()));


        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdvancedForm f =new AdvancedForm();
             f.Show();
        }
    }
}

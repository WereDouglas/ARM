using ARM.DB;
using ARM.Model;
using ARM.Sync;
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
    public partial class AdvancedForm : MetroFramework.Forms.MetroForm
    {
        public int r = 9;
        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        public static AdvancedForm _Form1;
        public AdvancedForm()
        {
            InitializeComponent();
            /// LoadingWindow.ShowSplashScreen();
            InitializeCulture();
            LoadTables();

            backgroundWorker.DoWork += backgroundWorker1_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker.WorkerReportsProgress = true;


            _Form1 = this;           
            processLbl.Visible = false;

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            if (DBConnect.CloseMySqlConn())
            {
                if (action=="Upload") {
                    for (int i = 0; i < 42; i++)
                    {
                        FeedBack("PROCESS " + i.ToString());
                        UploadProcess(i); backgroundWorker.ReportProgress(i);
                        Thread.Sleep(1500);
                    }
                } else if (action=="Download") {

                    for (int i = 0; i < 42; i++)
                    {
                        FeedBack("PROCESS " + i.ToString());
                        DownloadProcess(i); backgroundWorker.ReportProgress(i);
                        Thread.Sleep(1500);
                    }
                }
            }
            else
            {
                FeedBack("No internet connection ");
                backgroundWorker.Dispose();
            }

        }
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            try
            {
                toolStripProgressBar1.Value = e.ProgressPercentage;
            }
            catch { }
        }
        private void UploadProcess(int count)
        {
            int val = count;
            switch (val)
            {
                case 1:
                    Uploading.Items();                   
                    break;                
                
                case 3:
                    Uploading.Customers();
                    break;
                case 4:
                    Uploading.User();
                    break;
                case 5:
                    Uploading.Schedules();
                    break;
                case 6:
                    Uploading.Companys();
                    break;
                case 7:
                    
                    break;
                case 8:
                   
                    break;
                case 9:
                   
                    break;
                case 10:

                    break;
                case 11:

                    break;
                case 12:
                    Uploading.Deliverys();
                    break;
                case 13:
                   
                    break;
                case 14:
                    Uploading.Invoices();
                    break;
                case 15:
                    
                    break;
                case 16:
                    Uploading.Transactions();
                    break;
                case 17:
                   
                    break;
                case 18:
                    Uploading.Payments();
                    break;
                case 19:
                    
                    break;
                case 20:
                    Uploading.Order();
                    break;
                case 21:
                   
                    break;
                case 22:
                    Uploading.Instructions();
                    break;
                case 23:
                    
                    break;
                case 24:
                    Uploading.Follows();
                    break;
                case 25:
                    
                    break;
                case 26:
                    Uploading.ItemReviews();
                    break;
                case 27:
                    
                    break;
                case 28:
                    Uploading.Vendors();
                    break;
                case 29:
                    
                    break;
                case 30:
                    Uploading.ItemStatuses();
                    break;
                case 31:
                    
                    break;
                case 32:
                    Uploading.Rates();
                    break;
                case 33:
                    
                    break;
                case 34:
                    Uploading.Accounts();
                    break;
                case 35:
                    
                    break;
                case 36:
                    Uploading.Repsonsibles();
                    break;
                case 37:
                    
                    break;
                case 38:
                    Uploading.Insurances();
                    break;
                case 39:
                    
                    break;
                case 40:

                    break;
                case 41:

                    if (DBConnect.CloseMySqlConn())
                    {
                        FeedBack("Uploading of information complete");
                        backgroundWorker.Dispose();
                        return;
                    }
                    else
                    {
                        FeedBack("No valid connection ");
                    }
                    break;
                case 42:

                    break;
                default:
                    FeedBack("Processing");
                    break;
            }

        }

        private void DownloadProcess(int count)
        {
            int val = count;
            switch (val)
            {
                case 1:
                   
                    break;
                case 2:
                    Downloading.User();
                    break;
                case 3:
                   
                    break;
                case 4:
                    Downloading.Customers();
                    break;
                case 5:
                   
                    break;
                case 6:
                     Downloading.Schedules();
                    break;
                case 7:
                   
                    break;
                case 8:
                  
                    break;
                case 9:
                    Downloading.Items();
                    break;
                case 10:

                    break;
                case 11:

                    break;
                case 12:
                    
                    break;
                case 13:
                    Downloading.Deliverys();
                    break;
                case 14:
                    
                    break;
                case 15:
                    Downloading.Invoices();
                    break;
                case 16:
                  
                    break;
                case 17:
                    Downloading.Transactions();
                    break;
                case 18:
                    
                    break;
                case 19:
                    Downloading.Payments();
                    break;
                case 20:
                   
                    break;
                case 21:
                    Downloading.Order();
                    break;
                case 22:
                   
                    break;
                case 23:
                    Downloading.Instructions();
                    break;
                case 24:
                    
                    break;
                case 25:
                    Downloading.Follows();//.SendEmail();
                    break;
                case 26:
                    
                    break;
                case 27:
                    Downloading.ItemReviews();
                    break;
                case 28:
                    
                    break;
                case 29:
                    Downloading.Vendors();
                    break;
                case 30:
                   
                    break;
                case 31:
                    Downloading.ItemStatuses();
                    break;
                case 32:
                    
                    break;
                case 33:
                    Downloading.Rates();
                    break;
                case 34:
                   
                    break;
                case 35:
                    Downloading.Accounts();
                    break;
                case 36:
                    
                    break;
                case 37:
                    Downloading.Repsonsibles();
                    break;
                case 38:
                    
                    break;
                case 39:
                    Downloading.Coverages();
                    break;
                case 40:

                    break;
                case 41:

                    if (DBConnect.CloseMySqlConn())
                    {
                        FeedBack(" Downloading of information complete");
                        backgroundWorker.Dispose();
                        return;
                    }
                    else
                    {
                        FeedBack("No valid connection ");
                    }
                    break;
                case 42:

                    break;
                default:
                    FeedBack("Processing");
                    break;
            }

        }
        public void FeedBack(string text)
        {
            try
            {
                Invoke((MethodInvoker)delegate
                {

                    // processLbl.Text = "Last:  " + Helper.lastSync;
                    processLbl.Text = processLbl.Text + text + "\r\n";
                    processLbl.ForeColor = Color.White;
                });
            }
            catch
            {


            }

        }

        DataTable t ;
        private void LoadTables()
        {
            DBConnect.OpenConn();
            t = new DataTable();
            //string query = "SELECT * FROM information_schema.tables WHERE  table_type = 'BASE TABLE' ";

            string query = "SELECT table_name  FROM information_schema.tables WHERE table_schema = 'public'  AND table_type = 'BASE TABLE'";
            NpgsqlCommand cmd = new NpgsqlCommand(query, DBConnect.conn);
            NpgsqlDataReader Reader;
            Reader = cmd.ExecuteReader();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("Name");
            t.Columns.Add(new DataColumn("Online", typeof(Image)));
            t.Columns.Add(new DataColumn("Offline", typeof(Image)));
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));


            Image online = new Bitmap(Properties.Resources.Command_Refresh_16);
            Image offline = new Bitmap(Properties.Resources.Server_Delete_16);
            Image delete = new Bitmap(Properties.Resources.Cancel_16);
            while (Reader.Read())
            {
                t.Rows.Add(new object[] { false, Reader["table_name"], online, offline,delete });
            }
            DBConnect.CloseConn();

            dtGrid.DataSource = t;
            dtGrid.AllowUserToAddRows = false;
            this.dtGrid.Columns["Name"].DefaultCellStyle.BackColor = Color.Bisque;
          

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
           
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Dosage()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Emergency()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Facility()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new ICD10()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new PatientFollowStatus()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Pharmacy()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Service()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new CaseTransaction()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Queries()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Deduction()));

            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Conditions()));
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Pay()));
			DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Certificate()));
			DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Logs()));

		}

        private void button2_Click_1(object sender, EventArgs e)
        {
            createMySqlDB();
        }

        private void AdvancedForm_Load(object sender, EventArgs e)
        {

        }
     
        private void AdvancedForm_FormClosed(object sender, FormClosedEventArgs e)
        {

           

        }

      

        private void button3_Click_1(object sender, EventArgs e)
        {
            using (SettingsForm form = new SettingsForm())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                   
                }
            }

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

            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new CaseTransaction()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Queries()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Deduction()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Pay()));
			DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Certificate()));
			DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Logs()));




		}
        private string action;
        private void button1_Click(object sender, EventArgs e)
        {
            processLbl.Visible = true;
            action = "Upload";
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
            else {

                MessageBox.Show("Processing ....................");
            }
        }

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtGrid.Columns["Online"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("YES or No?", "Are you sure you want to Reset these files for resynchronisation online ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {                   

                        string Query = "UPDATE " + dtGrid.Rows[e.RowIndex].Cells["name"].Value.ToString() + " SET `sync`='false' WHERE companyID = '"+Helper.CompanyID+"'";
                        DBConnect.QueryMySql(Query);
                        MessageBox.Show("Information Reset online for synchronisation");                 

                }

            }
            try
            {

                if (e.ColumnIndex == dtGrid.Columns["Offline"].Index && e.RowIndex >= 0)
                {
                    if (MessageBox.Show("YES or No?", "Are you sure you want to Reset this information  for resynchronisation offline ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string Query = "UPDATE " + dtGrid.Rows[e.RowIndex].Cells["name"].Value.ToString() + " SET `sync`='false'";
                        DBConnect.QueryPostgre(Query);
                        MessageBox.Show("Information Reset offline for synchronisation");                      
                    }
                  

                }
            }
            catch { }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            createPostgreDB();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

            if (processLbl.Visible == true)
            {
                processLbl.Visible = false;
            }
            else
            {
                processLbl.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {            
            processLbl.Visible = true;
            action = "Download";
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
            else
            {

                MessageBox.Show("Processing ....................");
            }
        }

        private void processLbl_TextChanged(object sender, EventArgs e)
        {
            processLbl.SelectionStart = processLbl.Text.Length;
            processLbl.ScrollToCaret();
        }
    }
}

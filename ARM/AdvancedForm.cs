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

namespace ARM
{
    public partial class AdvancedForm : MetroFramework.Forms.MetroForm
    {
        public int r = 9;
        public AdvancedForm()
        {
            InitializeComponent();
            /// LoadingWindow.ShowSplashScreen();
            InitializeCulture();
            LoadTables();
         

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
            DBConnect.createMySqlDB(DBConnect.CreateDBSQL(new Condition()));
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
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Condition()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Dosage()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Emergency()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Facility()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new ICD10()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new PatientFollowStatus()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Pharmacy()));

            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Service()));

            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new CaseTransaction()));
            DBConnect.createPostgreDB(DBConnect.CreateDBSQL(new Queries()));


            

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> tables = new List<string>();
            DBConnect.OpenConn();


            string query = "SELECT table_name  FROM information_schema.tables WHERE table_schema = 'public'  AND table_type = 'BASE TABLE'";
            NpgsqlCommand cmd = new NpgsqlCommand(query, DBConnect.conn);
            NpgsqlDataReader Reader;
            Reader = cmd.ExecuteReader();
           
            while (Reader.Read())
            {              

                tables.Add(Reader["table_name"].ToString());
            }
            DBConnect.CloseConn();

            foreach (var p in tables) {

                string Query = "UPDATE "+p+" SET sync ='false'";
                Queries q = new Queries(Guid.NewGuid().ToString(),Helper.UserName,Helper.CleanString(query),false,DateTime.Now.Date.ToString("dd-MM-yyyy"),Helper.CompanyName);

                DBConnect.InsertPostgre(q);
              //  DBConnect.QueryPostgre(Query);
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
    }
}

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
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
    public partial class MedicalForm : MetroFramework.Forms.MetroForm
    {
        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        public static MedicalForm _Form1;

        public MedicalForm()
        {
            InitializeComponent();
            LoadProfile();

            backgroundWorker.DoWork += backgroundWorker1_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker.WorkerReportsProgress = true;
            

            _Form1 = this;
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1 * 60 * 2000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
            backgroundWorker.RunWorkerAsync();

        }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            if (DBConnect.CloseMySqlConn())
            {
                for (int i = 0; i < 4; i++)
                {
                    FeedBack("PROCESS " + i.ToString());
                    process(i); backgroundWorker.ReportProgress(i);
                    Thread.Sleep(1500);
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
        private void process(int count)
        {
            int val = count;
            switch (val)
            {
                case 1:
                    Synchronisation.Querying();
                    break;
                case 2:

                    if (DBConnect.CloseMySqlConn())
                    {
                        FeedBack("Uploading and Downloading of information complete");
                        backgroundWorker.Dispose();
                        return;
                    }
                    else
                    {
                        FeedBack("No valid connection ");
                    }
                    break;
                case 3:

                    break;
                default:
                    FeedBack("Processing");
                    break;
            }

        }
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            List<Queries> u = Queries.List("SELECT * FROM queries WHERE executed = 'false'");
           // toolStripProgressBar1.Maximum = u.Count;
            MedicalForm._Form1.FeedBack("Running Queries ... " + u.Count);
            if (u.Count > 0)
            {
                if (!backgroundWorker.IsBusy)
                {
                    backgroundWorker.RunWorkerAsync();
                }
            }
            else {
                MedicalForm._Form1.FeedBack("No pending queries to run ... " + u.Count);

            }
        }
        private void LoadProfile()
        {
            usernameLbl.Text = Helper.UserName;
            try
            {
                Image img = Helper.Base64ToImageCropped(Helper.UserImage);
                userPbx.Image = img;
            }
            catch (Exception p)
            {
                Helper.Exceptions(p.Message, "Loading the user image !");
            }
            try
            {
                Helper.CompanyImage = Company.Select().Image;
                Helper.CompanyName = Company.Select().Name;
                Helper.CompanyAddress= Company.Select().Address;
                Helper.CompanyContact = Company.Select().Contact;
                Helper.CompanyFax = Company.Select().OfficeFax;
                Image img = Helper.Base64ToImage(Company.Select().Image);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                //Bitmap bps = new Bitmap(bmp, 50, 50);
                pictureBox1.Image = bmp;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception p)
            {
                // Helper.Exceptions(p.Message, "Loading the Company Logo !");
            }

        }
      

        private void exceptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExceptionForm frm = new ExceptionForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }



        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            TransactionForm frm = new TransactionForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }


        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            InvoiceForm frm = new InvoiceForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            PaymentForm frm = new PaymentForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            OrderForm frm = new OrderForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            InstructionForm frm = new InstructionForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            DeliveryForm frm = new DeliveryForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }



        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            using (ProfileForm form = new ProfileForm(Helper.CompanyID))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
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

        private void processLbl_TextChanged(object sender, EventArgs e)
        {
            processLbl.SelectionStart = processLbl.Text.Length;
            processLbl.ScrollToCaret();
        }

        private void MedicalForm_Load(object sender, EventArgs e)
        {
            LoadingWindow.ShowSplashScreen();
            DashboardForm frm = new DashboardForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
            LoadingWindow.CloseForm();
        }

        private void MedicalForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            //this.Close();
            LoginForm t = new LoginForm();
            t.Show();
        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadingWindow.ShowSplashScreen();
            DashboardForm frm = new DashboardForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
            LoadingWindow.CloseForm();
        }

        private void addToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (CustomerDemo form = new CustomerDemo(null, "Patient"))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    viewToolStripMenuItem_Click_1(null, null);
                }
            }
        }

        private void viewToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CustomerForm frm = new CustomerForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripDropDownButton3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            using (AddItem form = new AddItem(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    toolStripMenuItem6_Click_1(null, null);
                }
            }
        }

        private void toolStripMenuItem6_Click_1(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            using (AddVendor form = new AddVendor(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    toolStripMenuItem16_Click(null, null);
                }
            }
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            VendorForm frm = new VendorForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            using (AddUser form = new AddUser(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    toolStripMenuItem18_Click(null, null);
                }
            }
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            UserForm frm = new UserForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoginForm r = new LoginForm();
            r.Show();
            this.Close();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            LoginForm r = new LoginForm();
            r.Show();
            this.Close();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
			OrderIntakeForm f = new OrderIntakeForm(null);
			f.Show();
		}

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            OrderForm frm = new OrderForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void queriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueriesForm frm = new QueriesForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void resetForUploadToolStripMenuItem_Click(object sender, EventArgs e)
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

            foreach (var p in tables)
            {

                string Query = "UPDATE " + p + " SET sync ='false'";
                Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(query), false, DateTime.Now.Date.ToString("dd-MM-yyyy"), Helper.CompanyName);

                DBConnect.InsertPostgre(q);
                //  DBConnect.QueryPostgre(Query);
            }
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddCaseTransaction form = new AddCaseTransaction(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    toolStripMenuItem16_Click(null, null);
                }
            }
        }

		private void orderIntakeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OrderIntakeForm f = new OrderIntakeForm(null);
			f.Show();
		}

		private void instructionDeliveryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			InstructionDeliveryForm f = new InstructionDeliveryForm(null,null);
			f.Show();
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			
		}

		private void logsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LogsForm frm = new LogsForm();
			frm.TopLevel = false;
			panel1.Controls.Add(frm);
			frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			frm.Dock = DockStyle.Fill;
			frm.Show();
		}

		private void instructionDeliveryToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			InstructionForm frm = new InstructionForm();
			frm.TopLevel = false;
			panel1.Controls.Add(frm);
			frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			frm.Dock = DockStyle.Fill;
			frm.Show();
		}

		private void myProfileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (AddUser form = new AddUser(Helper.UserID))
			{
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{
					
				}
			}
		}

		private void Shifts_Click(object sender, EventArgs e)
		{
			OrderIntakeForm f = new OrderIntakeForm(null);
			f.Show();
		}
	}
}

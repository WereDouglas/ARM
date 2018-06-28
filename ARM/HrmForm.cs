using ARM.DB;
using ARM.Model;
using ARM.Sync;
using ARM.Util;
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
    public partial class HrmForm : MetroFramework.Forms.MetroForm
    {
        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        public static HrmForm _Form1;
        public HrmForm()
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
                Image img = Helper.Base64ToImage(Company.Select().Image);
                Helper.CompanyAddress = Company.Select().Name;
                Helper.CompanyContact = Company.Select().Name;
                Helper.CompanyFax = Company.Select().OfficeFax;
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
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            if (DBConnect.CloseMySqlConn())
            {
                for (int i = 0; i < 30; i++)
                {
                    FeedBack("PROCESS " + i.ToString());
                    //  process(i); backgroundWorker.ReportProgress(i);
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
                    Uploading.User();
                    break;
                case 2:
                    Downloading.User();
                    break;
                case 3:
                    Uploading.Customers();
                    break;
                case 4:
                    Downloading.Customers();
                    break;
                case 5:
                    Uploading.Schedules();
                    break;
                case 6:
                    Downloading.Schedules();
                    break;
                case 7:
                    Uploading.Companys();
                    break;
                case 8:
                    Uploading.Items();
                    break;
                case 9:
                    Downloading.Items();
                    break;
                case 10:

                    break;
                case 11:

                    break;
                case 12:
                    Uploading.Deliverys();
                    break;
                case 13:
                    Downloading.Deliverys();
                    break;
                case 14:
                    Uploading.Invoices();
                    break;
                case 15:
                    Downloading.Invoices();
                    break;
                case 16:
                    Uploading.Transactions();
                    break;
                case 17:
                    Downloading.Transactions();
                    break;
                case 18:
                    Uploading.Payments();
                    break;
                case 19:
                    Downloading.Payments();
                    break;
                case 20:
                    Uploading.Order();
                    break;
                case 21:
                    Downloading.Order();
                    break;
                case 22:
                    Uploading.Instructions();
                    break;
                case 23:
                    Downloading.Instructions();
                    break;
                case 24:
                    Uploading.Follows();
                    break;
                case 25:
                    Downloading.Follows();//.SendEmail();
                    break;
                case 26:
                    Uploading.ItemReviews();
                    break;
                case 27:
                    Downloading.ItemReviews();
                    break;
                case 28:
                    Uploading.Vendors();
                    break;
                case 29:
                    Downloading.Vendors();
                    break;
                case 30:
                    Uploading.ItemStatuses();
                    break;
                case 31:
                    Downloading.ItemStatuses();
                    break;
                case 32:
                    Uploading.Rates();
                    break;
                case 33:
                    Downloading.Rates();
                    break;
                case 34:
                    Uploading.Accounts();
                    break;
                case 35:
                    Downloading.Accounts();
                    break;
                case 36:
                    Uploading.Repsonsibles();
                    break;
                case 37:
                    Downloading.Repsonsibles();
                    break;
                case 38:
                    Uploading.Insurances();
                    break;
                case 39:
                    Downloading.Coverages();
                    break;
                case 40:

                    break;
                case 41:

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
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
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


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            ScheduleForm frm = new ScheduleForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click_1(object sender, EventArgs e)
        {

        }

        private void HrmForm_Load(object sender, EventArgs e)
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

        private void toolStripSplitButton3_ButtonClick(object sender, EventArgs e)
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

        private void processLbl_TextChanged(object sender, EventArgs e)
        {
            processLbl.SelectionStart = processLbl.Text.Length;
            processLbl.ScrollToCaret();
        }

        private void HrmForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
            LoginForm t = new LoginForm();
            t.Show();
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
            using (ScheduleDialog form = new ScheduleDialog(null, null, null))
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
            CalendarForm frm = new CalendarForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            using (RateDialog form = new RateDialog(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    toolStripMenuItem2_Click_1(null, null);
                }
            }
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            RateForm frm = new RateForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            using (InsuranceDialog form = new InsuranceDialog(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    toolStripMenuItem4_Click_1(null, null);


                }
            }
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            InsuranceForm frm = new InsuranceForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            using (AccountDialog form = new AccountDialog(null))
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
            AccountForm frm = new AccountForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            CareForm frm = new CareForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            using (CareDialog form = new CareDialog(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    toolStripMenuItem8_Click(null, null);
                }
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            using (CustomerDemo form = new CustomerDemo(null, "Patient"))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    toolStripMenuItem10_Click(null, null);
                }
            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            CustomerForm frm = new CustomerForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            UserForm frm = new UserForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            using (AddUser form = new AddUser(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    toolStripMenuItem12_Click(null, null);
                }
            }
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            LoginForm r = new LoginForm();
            r.Show();
            this.Close();
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DeductionDialog form = new DeductionDialog(null,null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    viewToolStripMenuItem1_Click(null, null);
                }
            }
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeductionForm frm = new DeductionForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PayrollForm frm = new PayrollForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void generatePayRollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PayForm form = new PayForm(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    paymentToolStripMenuItem_Click(null, null);
                }
            }
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SlipPayForm frm = new SlipPayForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
    }
}

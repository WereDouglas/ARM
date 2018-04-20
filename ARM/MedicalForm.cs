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
                for (int i = 0; i < 30; i++)
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
                    Uploading.Deliverie();
                    break;
                case 11:
                    Uploading.Deliverys();
                    break;
                case 12:

                    break;
                case 13:

                    break;
                case 14:

                    break;
                case 15:

                    break;
                case 16:

                    break;
                case 17:

                    break;
                case 18:
                    break;
                case 19:

                    break;
                case 20:

                    break;
                case 21:

                    break;
                case 22:

                    break;
                case 23:

                    break;
                case 24:

                    break;
                case 25:
                    //Download.SendEmail();
                    break;
                case 26:
                    // Download.DownloadWallet();
                    break;
                case 27:
                    // Download.DownloadEvents();
                    break;
                case 28:
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
                case 29:
                    break;
                default:
                    FeedBack("Processing");
                    break;
            }

        }
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
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
        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            FollowForm f = new FollowForm(null);
            f.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DmeForm d = new DmeForm();
            d.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddItem form = new AddItem(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (AddItem form = new AddItem(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddItem it = new AddItem(null);
            it.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void deliveryPickupTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void orderIntakeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dMEInstructionDeliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void followUpPlanOfCareToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PurchaseForm form = new PurchaseForm())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PurchaseForm form = new PurchaseForm())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddCustomerForm form = new AddCustomerForm(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (AddCustomerForm form = new AddCustomerForm(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            using (AddSupplierForm form = new AddSupplierForm())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void unitsOfMeasureToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            PhysiciansForm frm = new PhysiciansForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddVendor form = new AddVendor(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddUser form = new AddUser(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void purchasesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm();
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

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            CustomerForm frm = new CustomerForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            VendorForm frm = new VendorForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            UserForm frm = new UserForm();
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

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            DeliveryPickupForm f = new DeliveryPickupForm(null);
            f.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            OrderIntakeForm o = new OrderIntakeForm(null);
            o.Show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            AddInstructionDelivery d = new AddInstructionDelivery(null);
            d.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            FollowForm f = new FollowForm(null);
            f.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {

            using (AddTransaction form = new AddTransaction(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
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

        private void deliveriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeliveriesForm frm = new DeliveriesForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            FollowUpForm frm = new FollowUpForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            using (ProfileForm form = new ProfileForm(null))
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

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

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
    }
}

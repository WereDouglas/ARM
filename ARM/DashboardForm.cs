using ARM.DB;
using ARM.Model;
using ARM.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;

namespace ARM
{
    public partial class DashboardForm : Form
    {
        private List<CalendarItem> _items = new List<CalendarItem>();
        public DashboardForm()
        {
            InitializeComponent();
            Report();
            invoiceLbl.Text = Invoice.List().Count().ToString();
            paidLbl.Text = Schedule.List().Where(t => t.Status.Contains("Paid")).Count().ToString();
            pendingLbl.Text = Schedule.List().Where(t => t.Status.Contains("Pending")).Count().ToString();
            customerLbl.Text = Customer.List().Count().ToString();
            itemLbl.Text = Product.List().Count().ToString();
            LoadData();
        }
        List<Product> items = new List<Product>();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        DataTable t = new DataTable();
        public void LoadData()
        {
            // create and execute query  
            t = new DataTable();
          
            t.Columns.Add("uri");
            t.Columns.Add(new DataColumn("Img", typeof(Bitmap)));//1
            t.Columns.Add("No");
            t.Columns.Add("Name");
            t.Columns.Add("Contact");
            t.Columns.Add("Address");
            t.Columns.Add("City");
            t.Columns.Add("State");
            t.Columns.Add("Zip");
           


            Bitmap b = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawString("Loading...", this.Font, new SolidBrush(Color.Black), 0f, 0f);
            }
          
            foreach (Customer c in Customer.List())
            {
                try
                {
                    t.Rows.Add(new object[] {c.Image as string, b, c.No, c.Name, c.Contact, c.Address, c.City, c.State, c.Zip});

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message + "Viewing customer {each customer list }" + c.Name);
                }
            }

            dtGrid.DataSource = t;
            dtGrid.Columns["uri"].Visible = false;


            ThreadPool.QueueUserWorkItem(delegate
            {
                foreach (DataRow row in t.Rows)
                {
                    try
                    {

                        Image img = Helper.Base64ToImage(row["uri"].ToString().Replace('"', ' ').Trim());
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                        Bitmap bps = new Bitmap(bmp, 50, 50);
                        Image dstImage = Helper.CropToCircle(bps, Color.White);
                        row["Img"] = dstImage;

                    }
                    catch
                    {

                    }
                }
            });

            dtGrid.AllowUserToAddRows = false;
            // dtGrid.Columns["View"].DefaultCellStyle.BackColor = Color.LightGreen;
            //  dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
            dtGrid.RowTemplate.Height = 60;
            dtGrid.Columns["uri"].Visible = false;
           
            // dtGrid.Columns["select"].Width = 30;

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Report()
        {
            List<Invoice> reports = new List<Invoice>();
            InvoiceBindingSource.DataSource = Invoice.List("SELECT * FROM invoice WHERE (date::date >= date_trunc('week', CURRENT_TIMESTAMP - interval '1 week') and  date::date < date_trunc('week', CURRENT_TIMESTAMP))");
            reportViewer1.RefreshReport();


        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}

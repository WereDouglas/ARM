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
        }
        List<Item> items = new List<Item>();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
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

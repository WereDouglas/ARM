using ARM.DB;
using ARM.Model;
using ARM.Util;
using Npgsql;
using System;
using System.Collections;
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

namespace ARM
{
    public partial class PayrollForm : Form
    {
        string toDate;
        string fromDate;
        public PayrollForm()
        {
            InitializeComponent();
            fromDate = DateTime.Now.ToString("dd-MM-yyyy");
            toDate = DateTime.Now.ToString("dd-MM-yyyy");


        }
        List<Schedule> invoices = new List<Schedule>();

        DataTable t = new DataTable();
     
        private void label1_Click(object sender, EventArgs e)
        {

        }
       

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("YES or No?", "Are you sure you want to delete these Schedules? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                foreach (var item in selectedIDs)
                {
                    string Query = "DELETE from schedule WHERE id ='" + item + "'";
                    DBConnect.QueryPostgre(Query);
                    Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.InsertPostgre(Query)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                    DBConnect.InsertPostgre(q);
                    //  MessageBox.Show("Information deleted");


                }
            }
        }
        List<string> selectedIDs = new List<string>();
      


        private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string Query = "UPDATE schedule SET sync ='false'";
            DBConnect.QueryPostgre(Query);
        }

        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            using (ScheduleDialog form = new ScheduleDialog(null, null, null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                }
            }
        }
        List<Payroll> reports = new List<Payroll>();
        private void button1_Click(object sender, EventArgs e)
        {

            fromDate = Convert.ToDateTime(fromDateTxt.Text).ToString("dd-MM-yyyy");
            toDate = Convert.ToDateTime(toDateTxt.Text).ToString("dd-MM-yyyy");
            LoadingWindow.ShowSplashScreen();
            //string SQL = "SELECT SUM(CAST(expense.total as float)) AS total FROM expense WHERE expense.clientID= '" + clientID + "' AND expense.offsets ='Yes'  AND  expense.date::date >= '" + fromDate + "'::date AND  expense.date::date <= '" + toDate + "'::date AND expense.offsets ='Yes' ;";

            Payroll r = new Payroll();
            string Q = "SELECT schedule.period AS total,users.name AS employee,customer.name AS client,account.bank AS account,account.routing AS route,schedule.starts AS date,schedule.period AS hours,rate.amount AS rate  FROM schedule LEFT JOIN users ON schedule.userID = users.id LEFT JOIN customer ON schedule.customerID = customer.id LEFT JOIN rate ON users.id = rate.userID LEFT JOIN account ON users.id = account.userid  WHERE (schedule.date::date >= '" + fromDate + "'::date AND  schedule.date::date <= '" + toDate + "'::date)";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {               
                r = new Payroll(Reader["employee"].ToString(), Reader["client"].ToString(), Reader["account"].ToString() + "  " + Reader["route"].ToString(), 0,Convert.ToDateTime(Reader["date"]).ToString("dd-ddd"), Convert.ToDouble(Reader["hours"]),Convert.ToDouble(Reader["rate"]),Convert.ToDouble(Reader["total"]), 0,0);//deduction,payable
                reports.Add(r);
            }
            DBConnect.CloseConn();

            /** end restaurant profit**/
            // Microsoft.Reporting.WinForms.ReportParameter rp = new Microsoft.Reporting.WinForms.ReportParameter("week", week.ToString());
            // this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp });
            this.PayrollBindingSource.DataSource = reports;
            reportViewer1.RefreshReport();
            LoadingWindow.CloseForm();
        }

        private void PayrollForm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void toDateTxt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void fromDateTxt_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

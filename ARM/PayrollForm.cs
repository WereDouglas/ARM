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


            double total = 0;
            double hrs = 0;
            double payOver = 0;
            double days = 0;

            fromDate = Convert.ToDateTime(startLbl.Text).ToString("dd-MM-yyyy");
            toDate = Convert.ToDateTime(endLbl.Text).ToString("dd-MM-yyyy");

            LoadingWindow.ShowSplashScreen();
            LoadDeduction(fromDate, toDate);
            string Qs = "SELECT starts,period,userID,customerID FROM schedule  WHERE (date::date >= '" + fromDate + "'::date AND  date::date <= '" + toDate + "'::date)";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader1 = DBConnect.Reading(Qs);
            OnDays l = new OnDays();
            List<OnDays> oD = new List<OnDays>();
            while (Reader1.Read())
            {
                l = new OnDays(Convert.ToDateTime(Reader1["starts"]).ToString("ddd"), Reader1["period"].ToString(), Reader1["userID"].ToString(), Reader1["customerID"].ToString());
                oD.Add(l);
            }
            DBConnect.CloseConn();


            Payroll r = new Payroll();
            string Q = "SELECT users.name,rate.period AS maxs ,customer.name AS client,customer.id AS customerID,rate.amount,account.bank,account.routing,SUM(cast(schedule.period AS float)) AS totalhours,SUM(cast(schedule.cost AS float)) AS cost,schedule.userID AS userID FROM schedule LEFT JOIN users ON schedule.userID = users.id LEFT JOIN customer ON schedule.customerID = customer.id LEFT JOIN rate ON users.id = rate.userID LEFT JOIN account ON users.id = account.userid LEFT JOIN deduction ON users.id = deduction.userID  WHERE (schedule.date::date >= '" + fromDate + "'::date AND  schedule.date::date <= '" + toDate + "'::date) GROUP BY schedule.userID,users.name,customer.name,users.name,account.bank,account.routing,rate.amount,rate.period,customer.id";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            int ct = 0;
            double ded = 0;

            double totalHrs = 0;
            double maxs = 0;
			double amount = 0;
			while (Reader.Read())
            {

                if (ct == 1)
                {
                    ded = deductionDictionary.Where(u => u.Key.Contains(Reader["userID"].ToString())).Sum(k => k.Value);
                }
                else
                {
                    ded = 0;
                }

                totalHrs = Convert.ToDouble(Reader["totalhours"]);
				try
				{
					maxs = Convert.ToDouble(Reader["maxs"]);
				}
				catch {
				}
				try
				{
					amount = Convert.ToDouble(Reader["amount"]);
				}
				catch
				{
				}
				total = Convert.ToDouble(Reader["cost"]);
                double overtime = 0;
                if (totalHrs > maxs)
                {
                    overtime = totalHrs - maxs;
                }
                else
                {
                    overtime = 0;
                }
                double half = amount / 2;
                double timeHalf = amount + half;
                double overtimePay = timeHalf * overtime;
                double pay = (total + overtimePay) - ded;
                string daying = "";

                foreach (OnDays u in oD.Where(y => y.UserID.Contains(Reader["userID"].ToString()) && y.ClientID.Contains(Reader["customerID"].ToString())))
                {
                    daying = daying + "\n" + u.Day + "\t\t" + u.Hrs;
                }
                r = new Payroll(Reader["name"].ToString(), Reader["client"].ToString(), Reader["bank"].ToString() + "  " + Reader["routing"].ToString(), daying, days, "", Convert.ToDouble(Reader["totalhours"]), amount, Convert.ToDouble(Reader["cost"]), ded, pay, overtime, overtimePay);

                reports.Add(r);
                ct++;
            }
            DBConnect.CloseConn();

            /** end restaurant profit**/
            // Microsoft.Reporting.WinForms.ReportParameter rp = new Microsoft.Reporting.WinForms.ReportParameter("week", week.ToString());
            // this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp });
            this.PayrollBindingSource.DataSource = reports;
            reportViewer1.RefreshReport();
            LoadingWindow.CloseForm();
        }
        Dictionary<string, double> deductionDictionary = new Dictionary<string, double>();
        private void LoadDeduction(string from, string to)
        {
            deductionDictionary.Clear();
            deductionDictionary = new Dictionary<string, double>();
            string Q = "SELECT userID,SUM(cast(amount AS float)) AS amount FROM deduction  WHERE (date::date >= '" + from + "'::date AND date::date <= '" + to + "'::date) GROUP BY userID";

            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                if (!deductionDictionary.ContainsKey(Reader["userID"].ToString()))
                {
                    deductionDictionary.Add(Reader["userID"].ToString(), Convert.ToDouble(Reader["amount"]));
                }

            }
            Reader.Close();
            DBConnect.CloseConn();

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

        private void dateTxt_ValueChanged(object sender, EventArgs e)
        {
            fillUp(Convert.ToDateTime(dateTxt.Text));
        }
        string month;
        private void fillUp(DateTime d)
        {
            month = d.ToString("MMMM");
            int year = Convert.ToInt32(d.ToString("yyyy"));

            int week = Helper.GetIso8601WeekOfYear(d);
            weekLbl.Text = week.ToString();
            startLbl.Text = Helper.FirstDateOfWeek(year, week).Date.ToString("dd-MM-yyyy");
            endLbl.Text = Convert.ToDateTime(startLbl.Text).AddDays(+6).Date.ToString("dd-MM-yyyy");
        }
    
}
    public class OnDays
    {

        string day;
        string hrs;
        string userID;
        string clientID;
        public OnDays() { }

        public OnDays(string day, string hrs, string userID, string clientID)
        {
            this.Day = day;
            this.Hrs = hrs;
            this.UserID = userID;
            this.ClientID = clientID;
        }

        public string Day { get => day; set => day = value; }
        public string Hrs { get => hrs; set => hrs = value; }
        public string UserID { get => userID; set => userID = value; }
        public string ClientID { get => clientID; set => clientID = value; }
    }
}

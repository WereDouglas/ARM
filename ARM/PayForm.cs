using ARM.DB;
using ARM.Model;
using ARM.Util;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ARM
{
    public partial class PayForm : MetroFramework.Forms.MetroForm
    {
        Dictionary<string, string> UserDictionary = new Dictionary<string, string>();
        Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
        Dictionary<string, string> PractitionerDictionary = new Dictionary<string, string>();
        string toDate;
        string fromDate;
        string CustomerID;
        string UserID;
        string ID;

        public PayForm(string id)
        {
            InitializeComponent();
            fromDate = DateTime.Now.ToString("dd-MM-yyyy");
            toDate = DateTime.Now.ToString("dd-MM-yyyy");
            // dateTxt.Text = DateTime.Now.ToString("dd-MM-yyyy");
            AutoCompleteUser();
            printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
            if (!string.IsNullOrEmpty(id))
            {
				ID = id;
				LoadEdit(ID);
			}
        }
        private void PayForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                fromDate = DateTime.Now.ToString("dd-MM-yyyy");
                toDate = DateTime.Now.ToString("dd-MM-yyyy");
                btnSubmit.Visible = false;
            }
            else
            {
                try
                {
                    noLbl.Text = (DBConnect.Max("SELECT MAX(CAST(no AS DOUBLE PRECISION)) FROM pay") + 1).ToString();
                }
                catch
                {
                    noLbl.Text = "1";
                }
            }
        }
        private Pay c;
        private void LoadEdit(string no)
        {

            c = new Pay();//.Select(UsersID);
            c = Pay.Select(no);
            UserID = c.UserID;
			hourTxt.Text = c.Hours.ToString("N0");
			workedTxt.Text = c.Hours.ToString();
			weekLbl.Text = c.Week.ToString();
			totalPayTxt.Text = c.Payment.ToString("N0");
			fromDate = c.Starts;
			toDate = c.Ends;
			       
            dateTxt.Text = Convert.ToDateTime(c.Date).ToString();
			fillUp(Convert.ToDateTime(c.Date));
			userCbx.Text = UserDictionary.FirstOrDefault(r => r.Value.Contains(c.UserID)).Key;
            LoadDed(c.No);
            noLbl.Text = c.No;
            paidCbx.Text = c.Paid;
            methodCbx.Text = c.Method;
			//userCbx_SelectedIndexChanged(null, null);
			LoadData( fromDate, toDate,UserID);
		}
        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Pay.Exists(startLbl.Text, endLbl.Text, UserID))
            {

                MessageBox.Show("A pay slip has already been saved !", "Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(paidCbx.Text))
            {
                MessageBox.Show("Has the payment been made !", "Paid", MessageBoxButtons.OK, MessageBoxIcon.Question);
                paidCbx.BackColor = Color.Red;
                return;
            }
            if (MessageBox.Show("YES or No?", "Confirm submission ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Pay i = new Pay(Guid.NewGuid().ToString(), Convert.ToDateTime(DateTime.Now.Date).ToString("dd-MM-yyyy"), noLbl.Text, UserID, methodCbx.Text, startLbl.Text, endLbl.Text, Convert.ToInt32(weekLbl.Text), Convert.ToDouble(rateLbl.Text), Convert.ToDouble(hourTxt.Text), Convert.ToDouble(totalPayTxt.Text), Convert.ToDouble(overtimeTxt.Text), Convert.ToDouble(rateHalfTxt.Text), Convert.ToDouble(overPayTxt.Text), Convert.ToDouble(totalDeductionTxt.Text), Convert.ToDouble(totalPayTxt.Text), paidCbx.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                string save = DBConnect.InsertPostgre(i);

                if (save != "")
                {
                    Queries qi = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                    DBConnect.InsertPostgre(qi);
                    string Query = "";
                    if (paidCbx.Text == "Yes")
                    {
                        Query = "Update schedule SET status = 'Paid' WHERE WHERE (date::date >= '" + fromDate + "'::date AND  date::date <= '" + toDate + "'::date) AND UserID ='" + UserID + "'";
                    }
                    else
                    {
                        Query = "Update schedule SET status = 'Pending' WHERE WHERE (date::date >= '" + fromDate + "'::date AND  date::date <= '" + toDate + "'::date) AND UserID ='" + UserID + "'";
                    }
                    DBConnect.QueryPostgre(Query);
                    Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                    DBConnect.InsertPostgre(q);

                    MessageBox.Show("Information Saved");
                    this.Close();
                }


            }

        }
        private void AutoCompleteUser()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            UserDictionary.Clear();
            foreach (Users v in Users.List())
            {
                AutoItem.Add((v.Name));

                if (!UserDictionary.ContainsKey(v.Name))
                {
                    UserDictionary.Add(v.Name, v.Id);
                    userCbx.Items.Add(v.Name);

                }
            }
        }

        private void AutoCompleteCustomer()
        {
        }
        private void AutoCompletePractitioner(string customerID)
        {

        }

        private void customerCbx_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        Users u;


        public void Print(System.Windows.Forms.Panel pnl)
        {
            panel1 = pnl;
            GetPrintArea(pnl);
            previewdlg.Document = printdoc1;
            try
            {
                previewdlg.ShowDialog();
            }
            catch { }
        }
        //Rest of the code
        Bitmap MemoryImage;
        public void GetPrintArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (MemoryImage != null)
            {
                e.Graphics.DrawImage(MemoryImage, 0, 0);
                base.OnPaint(e);
            }
        }
        void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }


        double Total = 0;



        private void updateBtn_Click(object sender, EventArgs e)
        {



        }

        private void userCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(weekLbl.Text) < 1)
                {
					MessageBox.Show("Please Select the date !");
                    return;
				}
            }
            catch
            {
                MessageBox.Show("Please Select the date !");
                return;
            }
            try
            {
                UserID = UserDictionary[userCbx.Text];
                u = new Users();//.Select(ItemID);
                u = Users.Select(UserID);
                Image img = Helper.Base64ToImage(u.Image);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                userPbx.Image = bmp;
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(userPbx.DisplayRectangle);
                userPbx.Region = new Region(gp);
                userPbx.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch { }
            if (!string.IsNullOrEmpty(UserID))
            {
                LoadData(fromDate, toDate, UserID);
            }
            LoadDed(noLbl.Text);  
        }
        private void LoadInfo()
        {
            string Q = "SELECT rate.period AS maxs,rate.amount,account.bank,account.routing,SUM(cast(schedule.period AS float)) AS totalhours,SUM(cast(schedule.cost AS float)) AS cost,schedule.userID AS userID FROM schedule LEFT JOIN users ON schedule.userID = users.id LEFT JOIN rate ON users.id = rate.userID LEFT JOIN account ON users.id = account.userid WHERE (schedule.date::date >= '" + fromDate + "'::date AND  schedule.date::date <= '" + toDate + "'::date) AND schedule.userID='" + UserID + "' GROUP BY schedule.userID,users.name,users.name,account.bank,account.routing,rate.amount,rate.period";
            DBConnect.OpenConn();
            NpgsqlDataReader Reader = DBConnect.Reading(Q);
            while (Reader.Read())
            {
                double maxs = 0;
                maxs = Convert.ToDouble(Reader["maxs"]);

                double overtime = 0;
                if (hrs > maxs)
                {
                    overtime = hrs - maxs;
                }
                else
                {
                    overtime = 0;
                    maxs = Convert.ToDouble(Reader["totalhours"]);
                }
                double half = Convert.ToDouble(Reader["amount"]) / 2;
                double timeHalf = Convert.ToDouble(Reader["amount"]) + half;
                double overtimePay = timeHalf * overtime;

                // hourTxt.Text = hrs.ToString();

                overtimeTxt.Text = overtime.ToString();
                rateLbl.Text = Reader["amount"].ToString();
                rateHalfTxt.Text = timeHalf.ToString();
                overPayTxt.Text = overtimePay.ToString();

                // hourTxt.Text = total.ToString();//

                double newhrs = maxs;
                double newPay = maxs * Convert.ToDouble(Reader["amount"]);

                hourTxt.Text = newhrs.ToString();
                workedTxt.Text = newPay.ToString("N0");
                totalPayTxt.Text = ((overtime + newPay) - deduction).ToString("N0");
            }
			DBConnect.CloseConn();
        }
        DataTable t = new DataTable();
        Dictionary<string, double> hoursDictionary = new Dictionary<string, double>();
        Dictionary<string, double> costDictionary = new Dictionary<string, double>();
        double cost = 0;
        double hrs = 0;
        public void LoadData(string fromDate, string toDate, string userID)
        {

            // create and execute query  
            t = new DataTable();

            t.Columns.Add("ID");
            t.Columns.Add("Date");
            t.Columns.Add("Customer");
            t.Columns.Add("Start");
            t.Columns.Add("End");
            t.Columns.Add("Details");
            t.Columns.Add("Indicator");
            t.Columns.Add("Period");
            t.Columns.Add("Category");
            t.Columns.Add("Status");
            t.Columns.Add("Rate");
            t.Columns.Add("Cost");
            t.Columns.Add("Week");
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));

            Image delete = new Bitmap(Properties.Resources.Server_Delete_16);
            string Q = "SELECT * FROM schedule WHERE (date::date >= '" + fromDate + "'::date AND  date::date <= '" + toDate + "'::date) AND UserID ='" + userID + "'";
            hoursDictionary.Clear();
            costDictionary.Clear();
            foreach (Schedule c in Schedule.List(Q))
            {
                string user = "";
                string cus = "";
                try { user = Users.Select(c.UserID).Name; } catch { }
                try { cus = Customer.Select(c.CustomerID).Name; } catch { }
                double rate = Convert.ToDouble(c.Cost) / Convert.ToDouble(c.Period);
                t.Rows.Add(new object[] { c.Id, c.Date, cus, c.Starts, c.Ends, c.Details, c.Indicator, c.Period, c.Category, c.Status, rate, c.Cost, c.Week, delete });

                hoursDictionary.Add(c.Id, Convert.ToDouble(c.Period));
                costDictionary.Add(c.Id, Convert.ToDouble(c.Cost));
            }
            hrs = hoursDictionary.Sum(y => y.Value);
            hourTxt.Text = hrs.ToString();
            dtGrid.DataSource = t;
            totalPayTxt.Text = costDictionary.Sum(y => y.Value).ToString();
            cost = costDictionary.Sum(y => y.Value);
            workedTxt.Text = cost.ToString("N0");
            rateLbl.Text = (cost / hrs).ToString("N0");
            dtGrid.AllowUserToAddRows = false;
            dtGrid.Columns["Start"].DefaultCellStyle.BackColor = Color.LightGreen;
            dtGrid.Columns["End"].DefaultCellStyle.BackColor = Color.LightPink;
            dtGrid.Columns["ID"].Visible = false;
            string summary = "";
            foreach (DataGridViewRow row in dtGrid.Rows)
            {
                try
                {
                    summary = row.Cells["Status"].Value.ToString();
                }
                catch { }
                if (summary.Contains("Paid"))
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                    row.DefaultCellStyle.Font = new Font("Calibri", 9.5F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
                else if (summary.Contains("Pending"))
                {
                    row.DefaultCellStyle.ForeColor = Color.DarkGray;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }
        private void dateTxt_ValueChanged(object sender, EventArgs e)
        {
			fillUp(Convert.ToDateTime(dateTxt.Text));
			userCbx_SelectedIndexChanged(null, null);
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
            fromDate = Convert.ToDateTime(startLbl.Text).ToString("dd-MM-yyyy");
            toDate = Convert.ToDateTime(endLbl.Text).ToString("dd-MM-yyyy");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtSlip.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Deduction? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from deduction WHERE id ='" + dtSlip.Rows[e.RowIndex].Cells["ID"].Value.ToString() + "'";
                    DBConnect.QueryPostgre(Query);

                    Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.InsertPostgre(Query)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                    DBConnect.InsertPostgre(q);
                    MessageBox.Show("Information deleted");
                    LoadDed(noLbl.Text);

                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {

        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            using (DeductionDialog form = new DeductionDialog(noLbl.Text, UserID))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadDed(noLbl.Text);
                }
            }
        }
        Dictionary<string, double> deductionDictionary = new Dictionary<string, double>();
        double deduction = 0;
        public void LoadDed(string no)
        {
            // create and execute query  
            t = new DataTable();

            t.Columns.Add("ID");
            t.Columns.Add("No");
            t.Columns.Add("Category");
            t.Columns.Add("Details");
            t.Columns.Add("Amount");
            t.Columns.Add("Paid");
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));

            Image delete = new Bitmap(Properties.Resources.Server_Delete_16);
            deductionDictionary.Clear();
            string Q = "SELECT * FROM deduction WHERE no = '" + no + "'";
            foreach (Deduction c in Deduction.List(Q))
            {
                try
                {
                    t.Rows.Add(new object[] { c.Id, c.No, c.Category, c.Details, c.Amount, c.Paid, delete });
                    deductionDictionary.Add(c.Id, c.Amount);
                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message + "Viewing deductions on slip {each Pay list }" + c.No);
                }
            }
            dtSlip.DataSource = t;
            dtSlip.AllowUserToAddRows = false;
            dtSlip.Columns["ID"].Visible = false;
            deduction = deductionDictionary.Sum(o => o.Value);
            totalDeductionTxt.Text = deduction.ToString("N0");
            totalPayTxt.Text = (cost - deduction).ToString("N0");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            overtimeTxt.Text = "0";
            rateLbl.Text = "0";
            rateHalfTxt.Text = "0";
            overPayTxt.Text = "0";
            hourTxt.Text = "0";
            workedTxt.Text = "0";
            totalPayTxt.Text = "0";
            if (checkBox1.Checked)
            {
                LoadInfo();
            }
            else
            {
                LoadData(fromDate, toDate, UserID);
                LoadDed(noLbl.Text);
            }
        }

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Schedule? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from schedule WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString() + "'";
                    DBConnect.QueryPostgre(Query);
                    Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                    DBConnect.InsertPostgre(q);
                    MessageBox.Show("Information deleted");
                    LoadData(fromDate, toDate, UserID);
                }
			}
            if (dtGrid.Columns[e.ColumnIndex].Name.Contains("Status"))
            {
                using (StateDialog form = new StateDialog(dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString()))
                {
                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        LoadData(fromDate, toDate, UserID);
                    }
                }

            }
        }


    }
}

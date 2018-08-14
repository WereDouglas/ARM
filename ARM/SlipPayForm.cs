using ARM.DB;
using ARM.Model;
using ARM.Util;
using MySql.Data.MySqlClient;
using Npgsql;
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

namespace ARM
{
    public partial class SlipPayForm : Form
    {
        string toDate;
        string fromDate;
        public SlipPayForm()
        {
            InitializeComponent();
            fromDate = DateTime.Now.ToString("dd-MM-yyyy");
            toDate = DateTime.Now.ToString("dd-MM-yyyy");
            LoadData(fromDate, toDate);
            
        }
        List<Customer> customers = new List<Customer>();
        DataTable t = new DataTable();
        public void LoadData(string fromDate, string toDate)
        {
            
            // create and execute query  
            t = new DataTable();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("id");
            t.Columns.Add("uri");
            t.Columns.Add(new DataColumn("Img", typeof(Bitmap)));//1
            t.Columns.Add("Name");
            t.Columns.Add("No");
            t.Columns.Add("Date");           
            t.Columns.Add("Method");
            t.Columns.Add("Start");
            t.Columns.Add("Ending");
            t.Columns.Add("Days");
            t.Columns.Add("Week");
            t.Columns.Add("Rate");
            t.Columns.Add("Hours");
            t.Columns.Add("Amount");
            t.Columns.Add("Over time Hours");
            t.Columns.Add("Over time Rate");
            t.Columns.Add("Over time Pay");
            t.Columns.Add("Deductions");
            t.Columns.Add("Paid");                    
            t.Columns.Add(new DataColumn("View", typeof(Image)));
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));
            Bitmap b = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawString("Loading...", this.Font, new SolidBrush(Color.Black), 0f, 0f);
            }
            Image view = new Bitmap(Properties.Resources.Note_Memo_16);
            Image delete = new Bitmap(Properties.Resources.Server_Delete_16);


            string Q = "SELECT * FROM pay WHERE (`date` >= '" + fromDate + "'  AND  `date` <= '" + toDate + "')";
            foreach (Pay c in Pay.List(Q))
            {
                string daying = "";
                string Qs = "SELECT starts,period,userID,customerID FROM schedule  WHERE (`date` >= '" + c.Starts + "' AND  `date` <= '" + c.Ends + "')";

				MySqlDataReader Reader1 = MySQL.Reading(Qs);
                OnDays l = new OnDays();
                List<OnDays> oD = new List<OnDays>();
                while (Reader1.Read())
                {
                    l = new OnDays(Convert.ToDateTime(Reader1["starts"]).ToString("ddd"), Reader1["period"].ToString(), Reader1["userID"].ToString(), Reader1["customerID"].ToString());
                    oD.Add(l);
                }
                DBConnect.CloseMySqlConn();
                int ct = 1;
                foreach (OnDays u in oD.Where(y => y.UserID.Contains(c.UserID)))
                {
                    daying = daying + "\n" + ct++ +"." +  u.Day + "\t\t-" + u.Hrs +"Hrs ";
                }
                string user = "";
                
                string imageUs = "";
                try { user = GenericCollection.users.Where(r => r.Id == c.UserID).First().Name; } catch { }
                try { imageUs = GenericCollection.users.Where(r => r.Id == c.UserID).First().Image; } catch { }

                try
                {
                    t.Rows.Add(new object[] { "false", c.Id, imageUs as string, b,user, c.No,c.Date,c.Method,c.Starts,c.Ends, daying, c.Week,c.Rate,c.Hours,c.Amount.ToString("N0"),c.OvertimeHrs,c.OvertimeRate,c.OvertimePay.ToString("N0"), c.Deductions.ToString("N0"),c.Paid, view, delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message , "Viewing pay slips { list }" + c.Date);
                }
            }

            dtGrid.DataSource = t;

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
            dtGrid.Columns["Start"].DefaultCellStyle.BackColor = Color.LightGreen;
            dtGrid.Columns["Ending"].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
            dtGrid.RowTemplate.Height = 60;
            dtGrid.Columns["uri"].Visible = false;
            dtGrid.Columns["id"].Visible = false;
           // dtGrid.Columns["select"].Width = 30;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string filterField = "Name";
        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                t.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, searchTxt.Text);
            }
            catch (Exception c)
            {
                Helper.Exceptions(c.Message , "Searching users by selection");

            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("YES or No?", "Are you sure you want to delete these customers? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                foreach (var item in selectedIDs)
                {
                    string Query = "DELETE from pay WHERE id ='" + item + "'";
                    MySQL.Query(Query);

                    
					Helper.Log(Helper.UserName, "Deleted payment information " + item + "  " + DateTime.Now);
				}
            }
        }
        List<string> selectedIDs = new List<string>();
        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == dtGrid.Columns["Select"].Index && e.RowIndex >= 0)
            {
				dtGrid.CurrentCell.Value = dtGrid.CurrentCell.FormattedValue.ToString() == "True" ? false : true;
				dtGrid.RefreshEdit();
				if (selectedIDs.Contains(dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString()))
				{
					selectedIDs.Remove(dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
				}
				else
				{
					selectedIDs.Add(dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
				}
			}
            if (e.ColumnIndex == dtGrid.Columns["View"].Index && e.RowIndex >= 0)
            {
                using (PayForm form = new PayForm(dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString()))
                {
                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        LoadData(fromDate, toDate);
                    }    
                }
            }
            try
            {
                if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    if (MessageBox.Show("YES or No?", "Are you sure you want to delete this pay slip? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string Query = "DELETE from pay WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                        MySQL.Query(Query);                       
                        MessageBox.Show("Information deleted");
                        LoadData(fromDate, toDate);

                    }
                   
                }

            }
            catch { }
        }

        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (String.IsNullOrEmpty(dtGrid.Rows[e.RowIndex].Cells["name"].Value.ToString()))
            {
                MessageBox.Show("Please input a name ");
                return;
            }
            string ID = dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
            //Customer _c = new Customer(ID, dtGrid.Rows[e.RowIndex].Cells["name"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["contact"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["address"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["city"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["state"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["zip"].Value.ToString(),DateTime.Now.ToString("dd-MM-yyyy"),dtGrid.Rows[e.RowIndex].Cells["SOC-SEC#"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["Date Of Birth"].Value.ToString(),dtGrid.Rows[e.RowIndex].Cells["category"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["height"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["weight"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["gender"].Value.ToString(), "false",Helper.CompanyID, dtGrid.Rows[e.RowIndex].Cells["uri"].Value.ToString());
            //string save = DBConnect.UpdateMySql(_c, ID);
            //Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), "false", DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
            //MySQL.Insert(q);

        }

        private void dtGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fromDate = Convert.ToDateTime(fromDateTxt.Text).ToString("dd-MM-yyyy");
            toDate = Convert.ToDateTime(toDateTxt.Text).ToString("dd-MM-yyyy");

            LoadingWindow.ShowSplashScreen();
            LoadData(fromDate, toDate);
            LoadingWindow.CloseForm();
        }

		private void toolStripButton4_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in dtGrid.Rows)
			{
				row.Cells["select"].Value = true;
				if (!selectedIDs.Contains(row.Cells["id"].Value.ToString()))
				{
					selectedIDs.Add(row.Cells["id"].Value.ToString());
				}
			}
		}

		private void toolStripButton6_Click(object sender, EventArgs e)
		{
			List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
			foreach (DataGridViewRow row in dtGrid.Rows)
			{
				row.Cells["select"].Value = false;
				selectedIDs.Remove(row.Cells["id"].Value.ToString());
			}
		}
	}
}

using ARM.DB;
using ARM.Model;
using ARM.Util;
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
    public partial class ScheduleForm : Form
    {
        string toDate;
        string fromDate;
        public ScheduleForm()
        {
            InitializeComponent();
            fromDate = DateTime.Now.ToString("dd-MM-yyyy");
            toDate = DateTime.Now.ToString("dd-MM-yyyy");

            LoadData(fromDate,toDate);

        }
        List<Schedule> invoices = new List<Schedule>();

        DataTable t = new DataTable();
        public void LoadData(string fromDate,string toDate)
        {
           
            // create and execute query  
            t = new DataTable();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("ID");
            t.Columns.Add("Date");
            t.Columns.Add("Customer");
            t.Columns.Add("User");
            t.Columns.Add("Start");
            t.Columns.Add("End");
            t.Columns.Add("Location");
            t.Columns.Add("Address");
            t.Columns.Add("Details");
            t.Columns.Add("Indicator");
            t.Columns.Add("Period");  
            t.Columns.Add("Category");
            t.Columns.Add("Status");
            t.Columns.Add("Cost");
            t.Columns.Add("Sync");
            t.Columns.Add("Created");
            t.Columns.Add("Week");
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));

            Image view = new Bitmap(Properties.Resources.Note_Memo_16);
            Image delete = new Bitmap(Properties.Resources.Server_Delete_16);
            string Q = "SELECT * FROM schedule WHERE (date::date >= '" + fromDate + "'::date AND  date::date <= '" + toDate + "'::date)";

            foreach (Schedule c in Schedule.List(Q))
            {
                string user = "";
                string cus = "";
                try { user = Users.Select(c.UserID).Name; } catch { }
                try { cus = Customer.Select(c.CustomerID).Name; } catch { }
               // try
               // {
                    t.Rows.Add(new object[] { false, c.Id, c.Date, cus, user, c.Starts, c.Ends, c.Location, c.Address, c.Details, c.Indicator, c.Period, c.Category, c.Status, c.Cost, c.Sync, c.Created,c.Week,  delete });

               // }
               // catch (Exception m)
               // {
                 //   MessageBox.Show("" + m.Message);
                    //Helper.Exceptions(m.Message + "Viewing customer {each schedule list }" + cus);
                //}
            }

            dtGrid.DataSource = t;

            dtGrid.AllowUserToAddRows = false;
            dtGrid.Columns["Start"].DefaultCellStyle.BackColor = Color.LightGreen;
            dtGrid.Columns["End"].DefaultCellStyle.BackColor = Color.LightPink;
            dtGrid.Columns["ID"].Visible = false;
            string summary = "";
            foreach (DataGridViewRow row in dtGrid.Rows)
            {

                try
                {
                    summary = row.Cells["Category"].Value.ToString();
                }
                catch { }
                if (summary.Contains("Shift"))
                {
                    row.DefaultCellStyle.ForeColor = Color.Tomato;
                    row.DefaultCellStyle.Font = new Font("Calibri", 9.5F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Pink;
                }

            }
          

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string filterField = "User";
        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                t.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, searchTxt.Text);
            }
            catch (Exception c)
            {
                Helper.Exceptions(c.ToString() + "Searching users by selection");

            }
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
                    Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                    DBConnect.InsertPostgre(q);
                    //  MessageBox.Show("Information deleted");


                }
            }
        }
        List<string> selectedIDs = new List<string>();
        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == dtGrid.Columns["Select"].Index && e.RowIndex >= 0)
            {
                if (selectedIDs.Contains(dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString()))
                {
                    selectedIDs.Remove(dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());

                }
                else
                {
                    selectedIDs.Add(dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                }
            }
          
            try
            {

                

            }
            catch { }

            if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
            {

                if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Schedule? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from schedule WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString() + "'";
                    DBConnect.QueryPostgre(Query);

                    Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName,Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                    DBConnect.InsertPostgre(q);

                    MessageBox.Show("Information deleted");
                    LoadData(fromDate,toDate);

                }

            }

            if (dtGrid.Columns[e.ColumnIndex].Name.Contains("Status"))
            {
                using (StateDialog form = new StateDialog(dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString()))
                {
                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                     
                    }
                }

            }


        }
        


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
            if (!Helper.validateInt(dtGrid.Rows[e.RowIndex].Cells["week"].Value.ToString()))
            {
                MessageBox.Show("The week must be an integer");
                return;
            }
            
                string Query = "Update schedule SET week = '"+ dtGrid.Rows[e.RowIndex].Cells["week"].Value.ToString() + "' WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString() + "'";
                DBConnect.QueryPostgre(Query);
                Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                DBConnect.InsertPostgre(q);

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

        private void button1_Click(object sender, EventArgs e)
        {
            fromDate = Convert.ToDateTime(fromDateTxt.Text).ToString("dd-MM-yyyy");
            toDate = Convert.ToDateTime(toDateTxt.Text).ToString("dd-MM-yyyy");

            LoadingWindow.ShowSplashScreen();
            LoadData(fromDate, toDate);
            LoadingWindow.CloseForm();
            //LoadData();
        }
    }
}

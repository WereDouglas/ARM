using ARM.DB;
using ARM.Model;
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
    public partial class LogsForm : Form
    {
        string From = "";
        string To = "";
        ToolStripControlHost dateFrom;
        ToolStripControlHost dateTo;

        public LogsForm()
        {
            InitializeComponent();

            fromDate = DateTime.Now.ToString("dd-MM-yyyy");
            toDate = DateTime.Now.ToString("dd-MM-yyyy");
            LoadData(fromDate, toDate);
           
        }
       
        List<Logs> ex = new List<Logs>();
        
        DataTable t = new DataTable();
        public void LoadData(string start, string end)
        {
            t = new DataTable();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("id");           
            t.Columns.Add("Name");
			t.Columns.Add("Action");
			t.Columns.Add("Sync");
            t.Columns.Add("Created");      
           
           
            string Q = "SELECT * FROM logs WHERE   `created` >= '" + fromDate + "' AND  `created` <= '" + toDate + "'";
            foreach (Logs c in Logs.List(Q))
            {
                try
                {
                    t.Rows.Add(new object[] { "false", c.Id, c.Name,c.Actions,c.Sync,c.Created });

                }
                catch (Exception m)
                {
                    MessageBox.Show(""+ m.Message);
                   
                }
            }
            dtGrid.DataSource = t; 
            //dtGrid.AllowUserToAddRows = false;            
         //   dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;           
            dtGrid.Columns["Id"].Visible = false;   

        }
        string filterField = "Message";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                t.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, searchTxt.Text);
            }
            catch (Exception c)
            {
                Helper.Exceptions(c.ToString() , "Searching Logs by filter Field");

            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
			try
			{
				if (Convert.ToInt32(Helper.Level) < 5)
				{
					MessageBox.Show("Access Denied !");
					return;
				}
			}
			catch (Exception c)
			{
				//MessageBox.Show(c.Message.ToString());
				Helper.Exceptions(c.Message, "Access level error ");
				//MessageBox.Show("You have an invalid entry !");
				return;
			}
			if (MessageBox.Show("YES or No?", "Are you sure you want to delete this information ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				foreach (var item in selectedIDs)
				{
					string Query = "DELETE from logs WHERE id ='" + item + "'";
					MySQL.Query(Query);
					Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), "false", DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
					MySQL.Insert(q);
					//MessageBox.Show("Information deleted" + item);
					Helper.Log(Helper.UserName, "Deleted logs  " + item + "  " + DateTime.Now);
				}
			}	
			Helper.Log( Helper.UserName, "LOGS DELETION FOR THE PERIOD OF ");
        }
		List<string> selectedIDs = new List<string>();
		private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
		}
        string toDate;
        string fromDate;

        private void button1_Click(object sender, EventArgs e)
        {
            fromDate = Convert.ToDateTime(fromDateTxt.Text).ToString("dd-MM-yyyy");
            toDate = Convert.ToDateTime(toDateTxt.Text).ToString("dd-MM-yyyy");
            LoadingWindow.ShowSplashScreen();
            LoadData(fromDate, toDate);
            LoadingWindow.CloseForm();

        }

		private void toolStripButton6_Click(object sender, EventArgs e)
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

		private void toolStripButton4_Click(object sender, EventArgs e)
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

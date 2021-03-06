﻿using ARM.DB;
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
			fromDate = DateTime.Now.ToString("yyyy-MM-dd");
			toDate = DateTime.Now.ToString("yyyy-MM-dd");

			LoadData(fromDate, toDate);

		}
		List<Schedule> invoices = new List<Schedule>();

		DataTable t = new DataTable();
		public void LoadData(string fromDate, string toDate)
		{

			// create and execute query  
			t = new DataTable();
			t.Columns.Add(new DataColumn("Select", typeof(bool)));
			t.Columns.Add("id");
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
			t.Columns.Add("Rate");
			t.Columns.Add("Cost");

			t.Columns.Add("Week");
			t.Columns.Add(new DataColumn("Delete", typeof(Image)));

			Image view = new Bitmap(Properties.Resources.Note_Memo_16);
			Image delete = new Bitmap(Properties.Resources.Server_Delete_16);
			string Q = "SELECT * FROM schedule WHERE `date` >= '" + fromDate + "' AND  `date` <= '" + toDate + "'";

			foreach (Schedule c in Schedule.List(Q))
			{
				string user = "";
				string cus = "";
				try { user = GenericCollection.users.Where(r => r.Id == c.UserID).First().Name; } catch { }
				try { cus = GenericCollection.customers.Where(r => r.Id == c.CustomerID).First().Name; } catch { }
				// try
				// {
				double rate = Convert.ToDouble(c.Cost) / Convert.ToDouble(c.Period);
				t.Rows.Add(new object[] { "false", c.Id, c.Date, cus, user, c.Starts, c.Ends, c.Location, c.Address, c.Details, c.Indicator, c.Period, c.Category, c.Status, rate, c.Cost, c.Week, delete });

				// }
				// catch (Exception m)
				// {
				//   MessageBox.Show("" + m.Message);
				//Helper.Exceptions(m.Message , "Viewing customer {each schedule list }" + cus);
				//}
			}

			dtGrid.DataSource = t;

			dtGrid.AllowUserToAddRows = false;
			dtGrid.Columns["Start"].DefaultCellStyle.BackColor = Color.LightGreen;
			dtGrid.Columns["End"].DefaultCellStyle.BackColor = Color.LightPink;
			dtGrid.Columns["id"].Visible = false;
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
					row.DefaultCellStyle.ForeColor = Color.Black;
				}
				else
				{

					row.DefaultCellStyle.ForeColor = Color.Black;
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
				Helper.Exceptions(c.Message, "Searching users by selection");

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
					MySQL.Query(Query);

					//  MessageBox.Show("Information deleted");
					Helper.Log(Helper.UserName, "Deleted schedule " + item + "  " + DateTime.Now);

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

			try
			{

				if (dtGrid.Columns[e.ColumnIndex].Name.Contains("Status"))
				{
					using (StateDialog form = new StateDialog(dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString()))
					{
						DialogResult dr = form.ShowDialog();
						if (dr == DialogResult.OK)
						{

						}
					}

				}

			}
			catch { }

			if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
			{

				if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Schedule? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
				{
					string Query = "DELETE from schedule WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
					MySQL.Query(Query);
					Helper.Log(Helper.UserName, "Deleted schedule " + dtGrid.Rows[e.RowIndex].Cells["customer"].Value.ToString() + "  " + DateTime.Now);
					MessageBox.Show("Information deleted");
					LoadData(fromDate, toDate);

				}
			}
		}

		private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (!Helper.validateInt(dtGrid.Rows[e.RowIndex].Cells["week"].Value.ToString()))
			{
				MessageBox.Show("The week must be an integer");
				return;
			}
			string Query = "Update schedule SET week = '" + dtGrid.Rows[e.RowIndex].Cells["week"].Value.ToString() + "' WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
			MySQL.Query(Query);
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
			fromDate = Convert.ToDateTime(fromDateTxt.Text).ToString("yyyy-MM-dd");
			toDate = Convert.ToDateTime(toDateTxt.Text).ToString("yyyy-MM-dd");

			LoadingWindow.ShowSplashScreen();
			LoadData(fromDate, toDate);
			LoadingWindow.CloseForm();
			//LoadData();
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
		private void toolStripButton4_Click_1(object sender, EventArgs e)
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

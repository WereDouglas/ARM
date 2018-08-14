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

namespace ARM
{
	public partial class TransactionForm : Form
	{
		public TransactionForm()
		{
			InitializeComponent();
			LoadData();

		}

		List<CaseTransaction> invoices = new List<CaseTransaction>();

		DataTable t = new DataTable();
		public void LoadData()
		{
			// create and execute query  
			t = new DataTable();
			t.Columns.Add(new DataColumn("Select", typeof(bool)));
			t.Columns.Add("id");
			t.Columns.Add("Order No.");
			t.Columns.Add("Date");
			t.Columns.Add("Product");
			t.Columns.Add("Quantity");
			t.Columns.Add("Cost");
			t.Columns.Add("Total");

			t.Columns.Add("Created");
			t.Columns.Add(new DataColumn("Delete", typeof(Image)));

			Image delete = new Bitmap(Properties.Resources.Server_Delete_16);
			foreach (Model.CaseTransaction c in Model.CaseTransaction.List())
			{
				string prod = "";

				try { prod = Product.Select(c.ItemID).Name; } catch { }

				try
				{
					t.Rows.Add(new object[] { "false", c.Id, c.No, c.Date, prod, c.Qty, c.Cost.ToString("N0"), c.Total.ToString("N0"), c.Created, delete });

				}
				catch (Exception m)
				{
					MessageBox.Show("" + m.Message);
					Helper.Exceptions(m.Message, "Viewing CaseTransactions {each transaction list }" + c.No);
				}
			}

			dtGrid.DataSource = t;
			dtGrid.AllowUserToAddRows = false;
			dtGrid.Columns["Cost"].DefaultCellStyle.BackColor = Color.LightGreen;
			//  dtGrid.Columns["Total"].DefaultCellStyle.BackColor = Color.Azure;
			dtGrid.Columns["id"].Visible = false;
			// dtGrid.Columns["select"].Width = 30;

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}
		string filterField = "Product";
		private void searchTxt_TextChanged(object sender, EventArgs e)
		{
			try
			{
				t.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, searchTxt.Text);
			}
			catch (Exception c)
			{
				Helper.Exceptions(c.Message, "Searching CaseTransactions by product");

			}
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("YES or No?", "Are you sure you want to delete these CaseTransaction? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				foreach (var item in selectedIDs)
				{
					string Query = "DELETE from casetransaction WHERE id ='" + item + "'";
					MySQL.Query(Query);
					Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(MySQL.Insert(Query)), "false", DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
					MySQL.Insert(q);
					Helper.Log(Helper.UserName, "Deleted transaction by id  " + item + "  " + DateTime.Now);
				}
			}
			MessageBox.Show("Information deleted");
			LoadData();
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
				if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
				{
					if (MessageBox.Show("YES or No?", "Are you sure you want to delete this CaseTransaction? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
					{
						string Query = "DELETE from casetransaction WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
						MySQL.Query(Query);
						Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), "false", DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
						MySQL.Insert(q);
						MessageBox.Show("Information deleted");
						Helper.Log(Helper.UserName, "Deleted transaction " + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "  " + DateTime.Now);

						LoadData();

					}
				}
			}
			catch(Exception c)
			{
				MessageBox.Show(c.Message.ToString());
				Helper.Exceptions(c.Message, " Deleting of transaction form ");
			}
		}

		private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			string Query = "UPDATE transaction SET sync ='false'";
			MySQL.Query(Query);
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

		private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}
	}
}

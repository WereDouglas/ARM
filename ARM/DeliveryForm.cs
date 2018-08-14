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
	public partial class DeliveryForm : Form
	{
		public DeliveryForm()
		{
			InitializeComponent();
			LoadData();

		}
		List<Delivery> invoices = new List<Delivery>();

		DataTable t = new DataTable();
		public void LoadData()
		{
			// create and execute query  
			t = new DataTable();
			t.Columns.Add(new DataColumn("Select", typeof(bool)));
			t.Columns.Add("id");
			t.Columns.Add("No");
			t.Columns.Add("Date");
			t.Columns.Add("Type");
			t.Columns.Add("Customer");
			t.Columns.Add("Doctor/Physician");
			t.Columns.Add("Comments");
			t.Columns.Add("Delivered by");
			t.Columns.Add("Received on");
			t.Columns.Add("Received by");
			t.Columns.Add("Signature");
			t.Columns.Add("Total");
			t.Columns.Add("Created");
			t.Columns.Add(new DataColumn("View", typeof(Image)));
			t.Columns.Add(new DataColumn("Delete", typeof(Image)));

			Image view = new Bitmap(Properties.Resources.Note_Memo_16);
			Image delete = new Bitmap(Properties.Resources.Server_Delete_16);

			foreach (Delivery c in Delivery.List())
			{
				string user = "";
				string cus = "";
				string prac = "";

				try { cus = Customer.Select(c.CustomerID).Name; } catch { }
				try { prac = Practitioner.Select(c.PractitionerID).Name; } catch { }

				try
				{
					t.Rows.Add(new object[] { "false", c.Id, c.No, c.Date, c.Type, cus, prac, c.Comments, c.DeliveredBy, c.DateReceived, c.ReceivedBy, c.Signature, c.Total.ToString("n0"), c.Created, view, delete });

				}
				catch (Exception m)
				{
					MessageBox.Show("" + m.Message);
					Helper.Exceptions(m.Message, "Viewing customer {each customer list }" + c.Date);
				}
			}

			dtGrid.DataSource = t;
			dtGrid.AllowUserToAddRows = false;
			dtGrid.Columns["Customer"].DefaultCellStyle.BackColor = Color.LightGreen;
			dtGrid.Columns["Total"].DefaultCellStyle.BackColor = Color.LightPink;
			dtGrid.Columns["id"].Visible = false;


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
				Helper.Exceptions(c.Message, "Searching users by selection");

			}
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("YES or No?", "Are you sure you want to delete these Delivery? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{

				foreach (var item in selectedIDs)
				{
					string Query = "DELETE from delivery WHERE id ='" + item + "'";
					MySQL.Query(Query);

					Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(MySQL.Insert(Query)), "false", DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
					MySQL.Insert(q);
					//  MessageBox.Show("Information deleted");
					Helper.Log(Helper.UserName, "Deleting devlivery information  " + item + "  " + DateTime.Now);
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
				DeliveryReport form = new DeliveryReport(dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString());//Print(panel1);
				form.Show();
				//using (DeliveryPickupForm form = new DeliveryPickupForm(dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString()))
				//            {
				//                DialogResult dr = form.ShowDialog();
				//                if (dr == DialogResult.OK)
				//                {
				//                    LoadData();
				//                }
				//            }
			}
			try
			{

				if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
				{

					if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Delivery? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
					{
						string Query = "DELETE from delivery WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
						MySQL.Query(Query);


						Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(MySQL.Insert(Query)), "false", DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
						MySQL.Insert(q);
						MessageBox.Show("Information deleted");
						LoadData();

					}

				}

			}
			catch { }
		}

		private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

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

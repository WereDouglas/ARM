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
	public partial class CertificateForm : Form
	{
		public CertificateForm()
		{
			InitializeComponent();
			
		}
		List<Instruction> invoices = new List<Instruction>();

		DataTable t = new DataTable();
		public void LoadData()
		{
			// create and execute query  
			t = new DataTable();
			t.Columns.Add(new DataColumn("Select", typeof(bool)));
			t.Columns.Add("id");
			t.Columns.Add("uriCus");
			t.Columns.Add(new DataColumn("ImgCus", typeof(Bitmap)));//1  
			t.Columns.Add("Patient");
			t.Columns.Add("No");
			t.Columns.Add("Doctor");
			t.Columns.Add("Doctor phone");
			t.Columns.Add("Signed");
			t.Columns.Add("Date");
			t.Columns.Add("Face to face");
			t.Columns.Add("Created");
			t.Columns.Add(new DataColumn("View", typeof(Image)));
			t.Columns.Add(new DataColumn("Delete", typeof(Image)));

			Image view = new Bitmap(Properties.Resources.Note_Memo_16);
			Image delete = new Bitmap(Properties.Resources.Server_Delete_16);

			Bitmap b = new Bitmap(50, 50);
			using (Graphics g = Graphics.FromImage(b))
			{
				g.DrawString("Loading...", this.Font, new SolidBrush(Color.Black), 0f, 0f);
			}
			
			foreach (Certificate c in Certificate.List())
			{
				string imageCus = "";
				string cus = "";
				try { imageCus = Customer.Select(c.CusID).Image; } catch { }
				try { cus = Customer.Select(c.CusID).Name; } catch { }
				try
				{
					t.Rows.Add(new object[] { "false", c.Id, imageCus as string, b, cus, c.No, c.PracName, c.PracPhone,c.PracSign, c.Date, c.DateFace, c.Created, view, delete });

				}
				catch (Exception m)
				{
					MessageBox.Show("" + m.Message);
					Helper.Exceptions(m.Message, "Viewing customer {each customer list } Setup date" + cus);
				}
			}

			dtGrid.DataSource = t;
			ThreadPool.QueueUserWorkItem(delegate
			{
				foreach (DataRow row in t.Rows)
				{
					try
					{
						Image img = Helper.Base64ToImageCropped(row["uriCus"].ToString().Replace('"', ' ').Trim());
						row["ImgCus"] = img;
					}
					catch
					{

					}
				}
			});

			dtGrid.AllowUserToAddRows = false;
			//dtGrid.Columns["Customer"].DefaultCellStyle.BackColor = Color.LightGreen;
			dtGrid.Columns["id"].Visible = false;
			dtGrid.Columns["ImgCus"].DefaultCellStyle.BackColor = Color.LightGreen;
			dtGrid.Columns["uriCus"].Visible = false;

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
			if (MessageBox.Show("YES or No?", "Are you sure you want to delete this information ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				foreach (var item in selectedIDs)
				{
					string Query = "DELETE from certificate WHERE id ='" + item + "'";
					MySQL.Query(Query);
					Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(MySQL.Insert(Query)), "false", DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
					MySQL.Insert(q);
					//  MessageBox.Show("Information deleted");
					Helper.Log(Helper.UserName, "Deleted CMNs " + item + "  " + DateTime.Now);
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
				CertificateReport form = new CertificateReport(dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString());
				form.Show();
			}
			try
			{
				if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
				{

					if (MessageBox.Show("YES or No?", "Are you sure you want to this information  ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
					{
						string Query = "DELETE from certificate WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
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

		private void CertificateForm_Load(object sender, EventArgs e)
		{
			LoadData();
		}
	}
}

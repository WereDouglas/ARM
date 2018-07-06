using ARM.DB;
using ARM.Model;
using ARM.Util;
using Newtonsoft.Json;
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
	public partial class OrderForm : Form
	{
		public OrderForm()
		{
			InitializeComponent();

			LoadData();

		}
		List<Orders> invoices = new List<Orders>();

		DataTable t = new DataTable();
		public void LoadData()
		{
			// create and execute query  
			t = new DataTable();
			t.Columns.Add(new DataColumn("Select", typeof(bool)));
			t.Columns.Add("id");
			t.Columns.Add("No");
			t.Columns.Add("uriCus");
			t.Columns.Add(new DataColumn("ImgCus", typeof(Bitmap)));//1  
			t.Columns.Add("Customer");
			t.Columns.Add("Physician");
			t.Columns.Add("Date & Time");
			t.Columns.Add("By");
			t.Columns.Add("Dispensed On");
			t.Columns.Add("Dispensed By");
			t.Columns.Add("Type");
			t.Columns.Add("Diagnosis");
			t.Columns.Add("Surgery");
			t.Columns.Add("Clinical Date");
			t.Columns.Add("Hospital");
			t.Columns.Add("Home");
			t.Columns.Add("Setup Date");
			t.Columns.Add("Date needed");
			t.Columns.Add("Notified");
			t.Columns.Add("Authorised");
			t.Columns.Add("CMN sent");
			t.Columns.Add("Date sent");
			t.Columns.Add("CMN returned");
			t.Columns.Add("Date returned");

			t.Columns.Add("CMN");
			t.Columns.Add("Instructions");
			t.Columns.Add("New delivery");
			t.Columns.Add(new DataColumn("View", typeof(Image)));
			t.Columns.Add(new DataColumn("Delete", typeof(Image)));

			Image view = new Bitmap(Properties.Resources.Note_Memo_16);
			Image delete = new Bitmap(Properties.Resources.Server_Delete_16);

			Bitmap b = new Bitmap(50, 50);
			using (Graphics g = Graphics.FromImage(b))
			{
				g.DrawString("Loading...", this.Font, new SolidBrush(Color.Black), 0f, 0f);
			}
			Bitmap b2 = new Bitmap(50, 50);
			using (Graphics g = Graphics.FromImage(b2))
			{
				g.DrawString("Loading...", this.Font, new SolidBrush(Color.Black), 0f, 0f);
			}

			foreach (Orders c in Orders.List())
			{
				string imageCus = "";
				string doctor = "";

				try { imageCus = Customer.Select(c.CustomerID).Image; } catch { }



				string cus = "";

				try { cus = Customer.Select(c.CustomerID).Name; } catch { }
				try { doctor = Practitioner.Select(c.PractitionerID).Name; } catch { }
				try
				{
					t.Rows.Add(new object[] { false, c.Id, c.No, imageCus as string, b, cus, doctor, c.OrderDate + " TIME: " + c.OrderTime, c.OrderBy, c.DispenseDate + " TIME: " + c.OrderTime, c.DispenseBy, c.CustomerType, c.Diagnosis, c.Surgery, c.ClinicalDate, c.Hospital, c.Home, c.SetupDate, c.DateNeeded, c.Notified, c.Authorised, c.Sent, c.DateSent, c.Returned, c.DateReturned, "CMN", "Instructions", "New Delivery", view, delete });
				}
				catch (Exception m)
				{
					MessageBox.Show("" + m.Message);
					Helper.Exceptions(m.Message, "Viewing customer {each customer list } Setup date" + c.ClinicalDate);
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
			ThreadPool.QueueUserWorkItem(delegate
			{
				foreach (DataRow row in t.Rows)
				{
					try
					{
						Image img = Helper.Base64ToImageCropped(row["uriPro"].ToString().Replace('"', ' ').Trim());
						row["imgPro"] = img;
					}
					catch
					{

					}
				}
			});

			dtGrid.AllowUserToAddRows = false;
			dtGrid.Columns["Physician"].DefaultCellStyle.BackColor = Color.WhiteSmoke;
			dtGrid.Columns["id"].Visible = false;
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
					string Query = "DELETE from orders WHERE id ='" + item + "'";
					DBConnect.QueryPostgre(Query);
					Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.InsertPostgre(Query)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
					DBConnect.InsertPostgre(q);
					//  MessageBox.Show("Information deleted");
					Helper.Log(Helper.UserName, "Deleted Order intake  " + item + "  " + DateTime.Now);
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
				using (OrderIntakeForm form = new OrderIntakeForm(dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString()))
				{
					DialogResult dr = form.ShowDialog();
					if (dr == DialogResult.OK)
					{
						LoadData();
					}
				}
			}
			//CertificateInputForm
			if (e.ColumnIndex == dtGrid.Columns["Instructions"].Index && e.RowIndex >= 0)
			{
				string exists = "";
				try
				{
					exists = DBConnect.value("SELECT no FROM instruction WHERE no  = '" + dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString() + "'");
				}
				catch (Exception y)
				{
					exists = "";
				}
				if (!string.IsNullOrEmpty(exists))
				{
					if (MessageBox.Show("YES or No?", "Instruction Delivery form exist would you like to load it  ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
					{
						using (InstructionDeliveryForm form = new InstructionDeliveryForm(dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString(), ""))
						{
							DialogResult dr = form.ShowDialog();
							if (dr == DialogResult.OK)
							{
								LoadData();
							}
						}
					}
					else
					{
						using (InstructionDeliveryForm form = new InstructionDeliveryForm("", dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString()))
						{
							DialogResult dr = form.ShowDialog();
							if (dr == DialogResult.OK)
							{
								LoadData();
							}
						}
					}
				}
				else {

					using (InstructionDeliveryForm form = new InstructionDeliveryForm("", dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString()))
					{
						DialogResult dr = form.ShowDialog();
						if (dr == DialogResult.OK)
						{
							LoadData();
						}
					}
				}				
			}
			if (e.ColumnIndex == dtGrid.Columns["CMN"].Index && e.RowIndex >= 0)
			{
				string exists = "";
				try
				{
					exists = DBConnect.value("SELECT no FROM certificate WHERE no  = '" + dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString() + "'");
				}
				catch (Exception y)
				{
					//MessageBox.Show( y.Message + noTxt.Text);
					exists = "";
				}
				if (!string.IsNullOrEmpty(exists))
				{
					if (MessageBox.Show("YES or No?", "CMN exists would you like to load it  ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
					{
						using (CertificateInputForm form = new CertificateInputForm(dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString(), ""))
						{
							DialogResult dr = form.ShowDialog();
							if (dr == DialogResult.OK)
							{
								//LoadData();
							}
						}
					}
					else
					{

						using (CertificateInputForm form = new CertificateInputForm("", dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString()))
						{
							DialogResult dr = form.ShowDialog();
							if (dr == DialogResult.OK)
							{
								//LoadData();
							}
						}
					}
				}
				else
				{
					using (CertificateInputForm form = new CertificateInputForm("", dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString()))
					{
						DialogResult dr = form.ShowDialog();
						if (dr == DialogResult.OK)
						{
							//LoadData();
						}
					}
				}

			}
			if (e.ColumnIndex == dtGrid.Columns["New delivery"].Index && e.RowIndex >= 0)
			{
				string exists = "";
				try
				{
					exists = DBConnect.value("SELECT no FROM delivery WHERE no  = '" + dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString() + "'");
				}
				catch (Exception y)
				{
					exists = "";
				}
				if (!string.IsNullOrEmpty(exists))
				{
					if (MessageBox.Show("YES or No?", "Order Delivery exists would you like to load it  ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
					{
						using (DeliveryPickupForm form = new DeliveryPickupForm(dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString(), ""))
						{
							DialogResult dr = form.ShowDialog();
							if (dr == DialogResult.OK)
							{
								LoadData();
							}
						}
					}
					else
					{
						using (DeliveryPickupForm form = new DeliveryPickupForm("", dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString()))
						{
							DialogResult dr = form.ShowDialog();
							if (dr == DialogResult.OK)
							{
								LoadData();
							}
						}
					}
				}
				else
				{
					using (DeliveryPickupForm form = new DeliveryPickupForm("", dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString()))
					{
						DialogResult dr = form.ShowDialog();
						if (dr == DialogResult.OK)
						{
							LoadData();
						}
					}
				}
			}
			try
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
				if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
				{
					if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Order? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
					{
						string Query = "DELETE from orders WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
						DBConnect.QueryPostgre(Query);
						Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
						DBConnect.InsertPostgre(q);
						string Query2 = "DELETE from casetransaction WHERE no ='" + dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString() + "'";
						DBConnect.QueryPostgre(Query2);
						Queries qa = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query2), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
						DBConnect.InsertPostgre(qa);

						string Query3 = "DELETE from certificate WHERE no ='" + dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString() + "'";
						DBConnect.QueryPostgre(Query3);
						Queries qas = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query3), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
						DBConnect.InsertPostgre(qas);

						string Query4 = "DELETE from delivery WHERE no ='" + dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString() + "'";
						DBConnect.QueryPostgre(Query4);
						Queries qa1 = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query4), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
						DBConnect.InsertPostgre(qa1);

						string Query5 = "DELETE from invoice WHERE no ='" + dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString() + "'";
						DBConnect.QueryPostgre(Query5);
						Queries qa2 = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query5), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
						DBConnect.InsertPostgre(qa2);

						string Query6 = "DELETE from instruction WHERE no ='" + dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString() + "'";
						DBConnect.QueryPostgre(Query6);
						Queries qa3 = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query6), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
						DBConnect.InsertPostgre(qa3);


						MessageBox.Show("Information deleted");
						Helper.Log(Helper.UserName, "Deleted order " + dtGrid.Rows[e.RowIndex].Cells["no"] + "  " + DateTime.Now);
						LoadData();
					}
				}
			}
			catch { }
		}

		private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void toolStripButton4_Click(object sender, EventArgs e)
		{
			string Query = "UPDATE order SET sync ='false'";
			DBConnect.QueryPostgre(Query);
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			OrderIntakeForm o = new OrderIntakeForm("");
			o.Show();
		}

		private void toolStripButton4_Click_1(object sender, EventArgs e)
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

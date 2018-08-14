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
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
	public partial class UserForm : Form
	{
		public UserForm()
		{
			InitializeComponent();
		}
		List<Users> users = new List<Users>();

		DataTable t = new DataTable();
		public void LoadData()
		{
			// create and execute query  
			t = new DataTable();
			t.Columns.Add("#");
			t.Columns.Add(new DataColumn("Select", typeof(bool)));
			t.Columns.Add("id");
			t.Columns.Add("uri");
			t.Columns.Add(new DataColumn("Img", typeof(Bitmap)));
			t.Columns.Add("Name");
			t.Columns.Add("Email");
			t.Columns.Add("Contact");
			t.Columns.Add("Address");
			t.Columns.Add("City");
			t.Columns.Add("State");
			t.Columns.Add("Zip");
			t.Columns.Add("Category");
			t.Columns.Add("Speciality");
			t.Columns.Add("Gender");
			t.Columns.Add("Active");
			t.Columns.Add("Level");
			t.Columns.Add("Department");
			t.Columns.Add("Created");
			t.Columns.Add(new DataColumn("View", typeof(Image)));
			t.Columns.Add(new DataColumn("Delete", typeof(Image)));

			Bitmap b = new Bitmap(50, 50);
			using (Graphics g = Graphics.FromImage(b))
			{
				g.DrawString("Loading...", this.Font, new SolidBrush(Color.Black), 0f, 0f);
			}
			Image view = new Bitmap(Properties.Resources.Note_Memo_16);
			Image delete = new Bitmap(Properties.Resources.Server_Delete_16);
			int ct = 1;
			foreach (Users c in GenericCollection.users)
			{
				try
				{
					t.Rows.Add(new object[] {ct++, "false", c.Id, c.Image as string, b, c.Name, c.Email, c.Contact, c.Address, c.City, c.State, c.Zip, c.Category, c.Speciality, c.Gender, c.Active, c.Level, c.Department, c.Created, view, delete });

				}
				catch (Exception m)
				{
					MessageBox.Show("" + m.Message);
					Helper.Exceptions(m.Message, "Viewing users {each users list }" + c.Name);
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
			// dtGrid.Columns["View"].DefaultCellStyle.BackColor = Color.LightGreen;
			//  dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
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
				Helper.Exceptions(c.Message, "Searching users by selection");

			}
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			this.Close();
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
			if (MessageBox.Show("YES or No?", "Are you sure you want to delete these Users? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				foreach (var item in selectedIDs)
				{
					string Query = "DELETE from users WHERE id ='" + item + "'";
					MySQL.Query(Query);
					GenericCollection.users.RemoveAll(r => r.Id == item);					
					Helper.Log(Helper.UserName, "Deleted user " + item + "  " + DateTime.Now);
				}
			}
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
			if (e.ColumnIndex == dtGrid.Columns["View"].Index && e.RowIndex >= 0)
			{
				if (Convert.ToInt32(Helper.Level) < 5)
				{
					MessageBox.Show("Access Denied !");
					return;
				}
				using (AddUser form = new AddUser(dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString()))
				{
					DialogResult dr = form.ShowDialog();
					if (dr == DialogResult.OK)
					{
						LoadData();
					}
				}
			}
			try
			{
				if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
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
						MessageBox.Show("Access Denied WITH ERROR !");
						return;
					}
					if (MessageBox.Show("YES or No?", "Are you sure you want to delete this User? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
					{
						string Query = "DELETE from users WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
						MySQL.Query(Query);
						GenericCollection.users.RemoveAll (r=>r.Id== dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
						MessageBox.Show("Information deleted");
						Helper.Log(Helper.UserName, "Deleted user " + dtGrid.Rows[e.RowIndex].Cells["name"].Value.ToString() + "  " + DateTime.Now);
						LoadData();
					}
				}
			}

			catch { }
			try
			{
				if (e.ColumnIndex == dtGrid.Columns["Active"].Index && e.RowIndex >= 0)
				{
					//string URI = "https://platform.clickatell.com/messages/http/send?apiKey=jKgp8Hx8SpyqTrt_Mg69Eg==&to=+19784579809&content=test";
					//string myParameters = "param1=value1&param2=value2&param3=value3";

					//using (WebClient wc = new WebClient())

					//{
					//	wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
					//	string HtmlResult = wc.UploadString(URI, myParameters);
					//}
					Dictionary<string, string> Params = new Dictionary<string, string>();

					//adding the parameters to the dictionary
					Params.Add("content", "WE ARE TESTING");
					Params.Add("to", "+19784579809");
					//if (from != "") { Params.Add("from", from); }
					//if (delivery != "") { Params.Add("scheduledDeliveryTime", delivery); }

					//if (api != "")
					//{
						//response = Api.SendSMS("jKgp8Hx8SpyqTrt_Mg69Eg==", Params);
						MessageBox.Show(response);
					dynamic results = Api.SendSMS("jKgp8Hx8SpyqTrt_Mg69Eg==", Params);
					foreach (dynamic res in results)
					{
						Console.Write((string)res["number"] + ",");
						Console.Write((string)res["status"] + ","); // status is either "Success" or "error message"
						Console.Write((string)res["statusCode"] + ",");
						Console.Write((string)res["messageId"] + ",");
						Console.WriteLine((string)res["cost"]);
					}
					//}
					//else
					//{
					//	MessageBox.Show("Error: API Key cannot be blank");
					//}
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
						MessageBox.Show("Access Denied WITH ERROR !");
						return;
					}

					if (MessageBox.Show("YES or No?", "Change user status ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
					{						
						string Query = "";
						string status = dtGrid.Rows[e.RowIndex].Cells["active"].Value.ToString();
						string id = dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
						var obj = GenericCollection.users.FirstOrDefault(x => x.Id == id);
						if (status == "Yes")
						{
							Query = "UPDATE users SET active = 'No' WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
							if (obj != null) { obj.Active = "No"; }
						}
						else
						{
							Query = "UPDATE users SET active = 'Yes' WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
							if (obj != null) { obj.Active = "Yes"; }
						}
						MySQL.Query(Query);						
						MessageBox.Show("Information updated");
						Helper.Log(Helper.UserName, "Changed user status " + dtGrid.Rows[e.RowIndex].Cells["name"].Value.ToString() + "  " + DateTime.Now);
						LoadData();
					}
				}
			}
			catch { }
		}
		private string response;
		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			using (AddUser form = new AddUser(null))
			{
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{
					LoadData();
				}
			}
		}
		Users u;
		private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			u = new Users();
			string columnName = dtGrid.Columns[e.ColumnIndex].HeaderText;
			string id = dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
			var obj = GenericCollection.users.FirstOrDefault(x => x.Id == id);
			try
			{
				var success = GenericCollection.users.GetType().GetProperty(columnName).GetValue(obj, null);
				if (obj != null)
				{ obj.GetType().GetProperty(columnName).SetValue(u, dtGrid.Rows[e.RowIndex].Cells[columnName].Value.ToString()); }
				//if (obj != null) { obj.Active = "No"; }
			}
			catch (Exception c)
			{
				
				Helper.Exceptions(c.Message, " Editing User using object ");
				
			}
			try
			{
				String Query = "UPDATE users SET " + columnName + " ='" + dtGrid.Rows[e.RowIndex].Cells[columnName].Value.ToString() + "' WHERE id = '" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
				MySQL.Query(Query);
				Helper.Log(Helper.UserName, "Updating user " + dtGrid.Rows[e.RowIndex].Cells["name"].Value.ToString() + "  " + DateTime.Now);
			}
			catch (Exception c)
			{
				//MessageBox.Show(c.Message.ToString());
				Helper.Exceptions(c.Message, "Editing User cell content grid");
				//MessageBox.Show("You have an invalid entry !");
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

		private void toolStripSeparator1_Click(object sender, EventArgs e)
		{

		}

		private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void UserForm_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void toolStripButton7_Click(object sender, EventArgs e)
		{
			UserReport f = new UserReport();
			f.Show();
		}

		private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}


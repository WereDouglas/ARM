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
    public partial class PaymentForm : Form
    {
        public PaymentForm()
        {
            InitializeComponent();
            LoadData();

        }
        List<Payment> invoices = new List<Payment>();

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
            t.Columns.Add("Method");
            t.Columns.Add("Amount");
            t.Columns.Add("Balance");           
            t.Columns.Add("Sync");
            t.Columns.Add("Created");            
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));  
            
            Image delete = new Bitmap(Properties.Resources.Server_Delete_16);
            foreach(Model.Payment c in Model.Payment.List())
            {
               
                try
                {
                    t.Rows.Add(new object[] { false, c.Id, c.No, c.Date, c.Type, c.Method, c.Amount.ToString("N0"), c.Balance.ToString("N0"), c.Sync, c.Created, delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message , "Viewing customer {each payment list }" + c.No);
                }
            }

            dtGrid.DataSource = t;
            dtGrid.AllowUserToAddRows = false;
           // dtGrid.Columns["Amount"].DefaultCellStyle.BackColor = Color.LightGreen;
           // dtGrid.Columns["Balance"].DefaultCellStyle.BackColor = Color.Red;
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
                Helper.Exceptions(c.Message , "Searching users by selection");

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
			if (MessageBox.Show("YES or No?", "Are you sure you want to delete these Payment? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                foreach (var item in selectedIDs)
                {
                    string Query = "DELETE from transaction WHERE id ='" + item + "'";
                    DBConnect.QueryPostgre(Query);
                    Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.InsertPostgre(Query)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                    DBConnect.InsertPostgre(q);
					Helper.Log(Helper.UserName, "Deleted logs  " + item + "  " + DateTime.Now);

				}
			}
           MessageBox.Show("Information deleted");
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
                    if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Payment? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string Query = "DELETE from payment WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                        DBConnect.QueryPostgre(Query);
                        Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.InsertPostgre(Query)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                        DBConnect.InsertPostgre(q);
                        MessageBox.Show("Information deleted");
						Helper.Log(Helper.UserName, "Changed deleted payment " + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "  " + DateTime.Now);

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

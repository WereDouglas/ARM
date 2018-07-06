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
    public partial class RateForm : Form
    {
        public RateForm()
        {
            InitializeComponent();
            LoadData();

        }
        DataTable t = new DataTable();
        public void LoadData()
        {
            // create and execute query  
            t = new DataTable();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("id");
            t.Columns.Add("Employee");
            t.Columns.Add("Amount");
            t.Columns.Add("Unit");
            t.Columns.Add("Max");
            t.Columns.Add("Sync");
            t.Columns.Add("Created");
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));//1
            t.Columns.Add("userID");

          //  t.Columns.Add(new DataColumn("Delete", typeof(Image)));
         
            Image delete = new Bitmap(Properties.Resources.Server_Delete_16);

            foreach (Rate c in Rate.List())
            {               
                string user = "";               
                try { user = Users.Select(c.UserID).Name; } catch { }
                try
                {
                    t.Rows.Add(new object[] { false, c.Id,user,c.Amount,c.Units,c.Period, c.Sync, c.Created, delete ,c.UserID});

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message , "Viewing customer {each customer list }" + user);
                }
            }

            dtGrid.DataSource = t;
            dtGrid.AllowUserToAddRows = false;
           // dtGrid.Columns["Amount"].DefaultCellStyle.BackColor = Color.LightGreen;
           // dtGrid.Columns["Unit"].DefaultCellStyle.BackColor = Color.LightGray;
            dtGrid.Columns["id"].Visible = false;
            dtGrid.Columns["userID"].Visible = false;
           

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string filterField = "Physician";
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
            if (MessageBox.Show("YES or No?", "Are you sure you want to delete these Rates? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                foreach (var item in selectedIDs)
                {
                    string Query = "DELETE from rate WHERE id ='" + item + "'";
                    DBConnect.QueryPostgre(Query);
                    Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.InsertPostgre(Query)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                    DBConnect.InsertPostgre(q);
					Helper.Log(Helper.UserName, "Deleted rates " + item + "  " + DateTime.Now);

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

                if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
                {

                    if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Rate? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string Query = "DELETE from rate WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                        DBConnect.QueryPostgre(Query);
                        Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.InsertPostgre(Query)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                        DBConnect.InsertPostgre(q);
                        MessageBox.Show("Information deleted");
                        LoadData();
						Helper.Log(Helper.UserName, "Deleted rate information for  " + dtGrid.Rows[e.RowIndex].Cells["Employee"].Value.ToString() + "  " + DateTime.Now);

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
            string Query = "UPDATE rate SET sync ='false'";
            DBConnect.QueryPostgre(Query);
        }

        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string ID = dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
            double max = Convert.ToDouble(dtGrid.Rows[e.RowIndex].Cells["max"].Value);
            Rate _c = new Rate(ID, dtGrid.Rows[e.RowIndex].Cells["userID"].Value.ToString(),Convert.ToDouble(dtGrid.Rows[e.RowIndex].Cells["amount"].Value), max, dtGrid.Rows[e.RowIndex].Cells["unit"].Value.ToString(), DateTime.Now.ToString("dd-MM-yyyy"),false, Helper.CompanyID);
            string save = DBConnect.UpdatePostgre(_c, ID);
            Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
            DBConnect.InsertPostgre(q);
			Helper.Log(Helper.UserName, "Updated rate information " + dtGrid.Rows[e.RowIndex].Cells["Employee"].Value.ToString() + "  " + DateTime.Now);

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

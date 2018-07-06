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
    public partial class DeductionForm : Form
    {
        public DeductionForm()
        {
            InitializeComponent();
            LoadData();

        }
        List<Deduction> invoices = new List<Deduction>();

        DataTable t = new DataTable();
        public void LoadData()
        {
            // create and execute query  
            t = new DataTable();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("ID");
            t.Columns.Add("uriUs");
            t.Columns.Add(new DataColumn("ImgUs", typeof(Bitmap)));
            t.Columns.Add("userID");
            t.Columns.Add("No");
            t.Columns.Add("Employee");
            t.Columns.Add("Category");
            t.Columns.Add("Details");
            t.Columns.Add("Amount");
            t.Columns.Add("Paid");
            t.Columns.Add("Sync");
            t.Columns.Add("Created");
            t.Columns.Add(new DataColumn("View", typeof(Image)));
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));
            Image view = new Bitmap(Properties.Resources.Note_Memo_16);
            Image delete = new Bitmap(Properties.Resources.Server_Delete_16);

            Bitmap b2 = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(b2))
            {
                g.DrawString("Loading...", this.Font, new SolidBrush(Color.Black), 0f, 0f);
            }
            string Q = "SELECT * FROM deduction";
            foreach (Deduction c in Deduction.List(Q))
            {
                string user = "";
                string imageUs = "";
                try { user = Users.Select(c.UserID).Name; } catch { }
                try { imageUs = Users.Select(c.UserID).Image; } catch { }
                try
                {
                    t.Rows.Add(new object[] { false, c.Id, imageUs as string, b2,c.UserID ,c.No,user, c.Category, c.Details, c.Amount, c.Paid, c.Sync, c.Created, view, delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message , "Viewing customer {each schedule list }" + user);
                }
            }

            dtGrid.DataSource = t;
           
            ThreadPool.QueueUserWorkItem(delegate
            {
                foreach (DataRow row in t.Rows)
                {
                    try
                    {

                        Image img = Helper.Base64ToImage(row["uriUs"].ToString().Replace('"', ' ').Trim());
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                        Bitmap bps = new Bitmap(bmp, 50, 50);
                        Image dstImage = Helper.CropToCircle(bps, Color.White);
                        row["ImgUs"] = dstImage;

                    }
                    catch
                    {

                    }
                }
            });
            dtGrid.AllowUserToAddRows = false;


            dtGrid.Columns["ID"].Visible = false;
            dtGrid.Columns["userID"].Visible = false;
            dtGrid.Columns["uriUs"].Visible = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string filterField = "Date";
        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                t.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, searchTxt.Text);
            }
            catch (Exception c)
            {
                Helper.Exceptions(c.Message , "Searching Deduction of patients by selection");

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("YES or No?", "Are you sure you want to delete these Deductions? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                foreach (var item in selectedIDs)
                {
                    string Query = "DELETE from deduction WHERE id ='" + item + "'";
                    DBConnect.QueryPostgre(Query);
                    Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.InsertPostgre(Query)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                    DBConnect.InsertPostgre(q);
					Helper.Log(Helper.UserName, "Deleted deduction information " + item + "  " + DateTime.Now);
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
            if (e.ColumnIndex == dtGrid.Columns["View"].Index && e.RowIndex >= 0)
            {
                using (DeductionDialog form = new DeductionDialog(dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["userID"].Value.ToString()))
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
                    if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Deduction? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string Query = "DELETE from deduction WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString() + "'";
                        DBConnect.QueryPostgre(Query);

                        Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.InsertPostgre(Query)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                        DBConnect.InsertPostgre(q);
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string Query = "UPDATE deduction SET sync ='false'";
            DBConnect.QueryPostgre(Query);
        }

        

        private void dtGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!Helper.validateDouble(dtGrid.Rows[e.RowIndex].Cells["amount"].Value.ToString()))
            {
                MessageBox.Show("Invalid amount");
            }
            try
            {
                Deduction _c = new Deduction(dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["date"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["userID"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["category"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["details"].Value.ToString(), Convert.ToDouble(dtGrid.Rows[e.RowIndex].Cells["amount"].Value), dtGrid.Rows[e.RowIndex].Cells["paid"].Value.ToString(), DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID);
               string save =  DBConnect.UpdatePostgre(_c, dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
                Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                DBConnect.InsertPostgre(q);

            }
            catch (Exception c)
            {
                Helper.Exceptions(c.Message, "Editing cost of goods grid");
                MessageBox.Show("You have an invalid entry !");
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

		private void toolStripButton4_Click(object sender, EventArgs e)
		{
			List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
			foreach (DataGridViewRow row in dtGrid.Rows)
			{
				row.Cells["select"].Value = false;
				selectedIDs.Remove(row.Cells["id"].Value.ToString());
			}
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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
	}
}

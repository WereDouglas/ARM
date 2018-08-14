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
    public partial class CareForm : Form
    {
        public CareForm()
        {
            InitializeComponent();
          

        }
        List<Responsible> invoices = new List<Responsible>();

        DataTable t = new DataTable();
        public void LoadData()
        {
            // create and execute query  
            t = new DataTable();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("id");
            t.Columns.Add("uriCus");
            t.Columns.Add(new DataColumn("ImgCus", typeof(Bitmap))); 
            t.Columns.Add("Patient");
            t.Columns.Add("uriUs");
            t.Columns.Add(new DataColumn("ImgUs", typeof(Bitmap)));
            t.Columns.Add("User");           
        
            t.Columns.Add("Created");           
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));          
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
            foreach (Responsible c in Responsible.List())
            {
                string user = "";
                string cus = "";
                string imageCus = "";
                string imageUs = "";
                try { user = GenericCollection.users.Where(r => r.Id == c.UserID).First().Name; } catch { }
                try { imageUs = GenericCollection.users.Where(r => r.Id == c.UserID).First().Image; } catch { }
                try { cus = GenericCollection.customers.Where(r => r.Id == c.CustomerID).First().Name; } catch { }
                try { imageCus = GenericCollection.customers.Where(r => r.Id == c.CustomerID).First().Image; } catch { }
                try
                {
                    t.Rows.Add(new object[] { "false", c.Id, imageCus as string, b, cus, imageUs as string, b2, user, c.Created, delete });

                }
                catch (Exception m)
                {
                    //MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message , "Viewing customer {each schedule list }" + cus);
                }
            }

            dtGrid.DataSource = t;           
            ThreadPool.QueueUserWorkItem(delegate
            {
                foreach (DataRow row in t.Rows)
                {
                    try
                    {

                        Image img = Helper.Base64ToImage(row["uriCus"].ToString().Replace('"', ' ').Trim());
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                        Bitmap bps = new Bitmap(bmp, 50, 50);
                        Image dstImage = Helper.CropToCircle(bps, Color.White);
                        row["ImgCus"] = dstImage;

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
            dtGrid.Columns["id"].Visible = false;
            dtGrid.Columns["uriCus"].Visible = false;
            dtGrid.Columns["uriUs"].Visible = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string filterField = "Customer";
        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                t.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, searchTxt.Text);
            }
            catch (Exception c)
            {
                Helper.Exceptions(c.Message , "Searching Care of patients by selection");

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
                    string Query = "DELETE from responsible WHERE id ='" + item + "'";
                    MySQL.Query(Query);
                   
					Helper.Log(Helper.UserName, "Deletion of care information " + item + "  " + DateTime.Now);

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

                    if (MessageBox.Show("YES or No?", "Are you sure you want to delete this information ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string Query = "DELETE from responsible WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                        MySQL.Query(Query);                       
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
            string Query = "UPDATE responsible SET sync ='false'";
            MySQL.Query(Query);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            using (CareDialog form = new CareDialog(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {

                }
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

		private void toolStripButton2_Click_1(object sender, EventArgs e)
		{
			List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
			foreach (DataGridViewRow row in dtGrid.Rows)
			{
				row.Cells["select"].Value = false;
				selectedIDs.Remove(row.Cells["id"].Value.ToString());
			}
		}

		private void CareForm_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void toolStripButton4_Click_1(object sender, EventArgs e)
		{
			using (CareDialog form = new CareDialog(null))
			{
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{
					LoadData();
				}
			}
		}
	}
}

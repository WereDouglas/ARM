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
            LoadData();

        }
        List<Responsible> invoices = new List<Responsible>();

        DataTable t = new DataTable();
        public void LoadData()
        {
            // create and execute query  
            t = new DataTable();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("ID");
            t.Columns.Add("uriCus");
            t.Columns.Add(new DataColumn("ImgCus", typeof(Bitmap)));//1  
            t.Columns.Add("Customer");
            t.Columns.Add("uriUs");
            t.Columns.Add(new DataColumn("ImgUs", typeof(Bitmap)));//1  
            t.Columns.Add("User");           
            t.Columns.Add("Sync");
            t.Columns.Add("Created");
            t.Columns.Add(new DataColumn("View", typeof(Image)));
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));

            Image view = new Bitmap(Properties.Resources.Document_Edit_24__1_);
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
                try { user = Users.Select(c.UserID).Name; } catch { }
                try { imageUs = Users.Select(c.UserID).Image; } catch { }

                try { cus = Customer.Select(c.CustomerID).Name; } catch { }
                try { imageCus = Customer.Select(c.CustomerID).Image; } catch { }
                try
                {
                    t.Rows.Add(new object[] { false, c.Id, imageCus as string, b, cus, imageUs as string, b2, user, c.Sync, c.Created, view, delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message + "Viewing customer {each schedule list }" + cus);
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
            dtGrid.Columns["Customer"].DefaultCellStyle.BackColor = Color.LightGreen;
            dtGrid.Columns["User"].DefaultCellStyle.BackColor = Color.Wheat;

            dtGrid.Columns["ImgUs"].DefaultCellStyle.BackColor = Color.Wheat;
            dtGrid.Columns["ImgCus"].DefaultCellStyle.BackColor =  Color.LightGreen;

            dtGrid.Columns["ID"].Visible = false;
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
                Helper.Exceptions(c.ToString() + "Searching Care of patients by selection");

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("YES or No?", "Are you sure you want to delete these Responsibles? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                foreach (var item in selectedIDs)
                {
                    string Query = "DELETE from responsible WHERE id ='" + item + "'";
                    DBConnect.QueryPostgre(Query);
                    //  MessageBox.Show("Information deleted");
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
                using (CareDialog form = new CareDialog(dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString()))
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

                    if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Responsible? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string Query = "DELETE from responsible WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString() + "'";
                        DBConnect.QueryPostgre(Query);
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
            DBConnect.QueryPostgre(Query);
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
    }
}

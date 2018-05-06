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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();

            LoadData();
            
        }
        List<Customer> customers = new List<Customer>();

        DataTable t = new DataTable();
        public void LoadData()
        {
            // create and execute query  
            t = new DataTable();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("customerID");
            t.Columns.Add("uri");
            t.Columns.Add(new DataColumn("Img", typeof(Bitmap)));//1
            t.Columns.Add("No");
            t.Columns.Add("Name");
            t.Columns.Add("Contact");
            t.Columns.Add("Address");
            t.Columns.Add("City");
            t.Columns.Add("State");
            t.Columns.Add("Zip");
            t.Columns.Add("SOC-SEC#");
            t.Columns.Add("Date Of Birth");
            t.Columns.Add("Gender");
            t.Columns.Add("Height");
            t.Columns.Add("Weight");
            t.Columns.Add("Category");
            t.Columns.Add("Sync");
            t.Columns.Add("Created");
            t.Columns.Add(new DataColumn("View", typeof(Image)));
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));//1


            Bitmap b = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawString("Loading...", this.Font, new SolidBrush(Color.Black), 0f, 0f);
            }
            Image view = new Bitmap(Properties.Resources.Note_Memo_16);
            Image delete = new Bitmap(Properties.Resources.Server_Delete_16);

            foreach (Customer c in Customer.List())
            {
                try
                {
                    t.Rows.Add(new object[] { false, c.Id, c.Image as string, b, c.No, c.Name, c.Contact, c.Address, c.City, c.State, c.Zip, c.Ssn, c.Dob,c.Gender,c.Height,c.Weight, c.Category, c.Sync, c.Created, view, delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message + "Viewing customer {each customer list }" + c.Name);
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
            dtGrid.Columns["customerID"].Visible = false;
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
                Helper.Exceptions(c.ToString() + "Searching users by selection");

            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("YES or No?", "Are you sure you want to delete these customers? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                foreach (var item in selectedIDs)
                {
                    string Query = "DELETE from customer WHERE id ='" + item + "'";
                    DBConnect.QueryPostgre(Query);
                    Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                    DBConnect.InsertPostgre(q);
                }
            }
        }
        List<string> selectedIDs = new List<string>();
        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == dtGrid.Columns["Select"].Index && e.RowIndex >= 0)
            {
                if (selectedIDs.Contains(dtGrid.Rows[e.RowIndex].Cells["customerID"].Value.ToString()))
                {
                    selectedIDs.Remove(dtGrid.Rows[e.RowIndex].Cells["customerID"].Value.ToString());
                   

                }
                else
                {
                    selectedIDs.Add(dtGrid.Rows[e.RowIndex].Cells["customerID"].Value.ToString());
                    
                }
            }
            if (e.ColumnIndex == dtGrid.Columns["View"].Index && e.RowIndex >= 0)
            {
                using (CustomerDemo form = new CustomerDemo(dtGrid.Rows[e.RowIndex].Cells["customerID"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["category"].Value.ToString()))
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
                    if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Customer? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string Query = "DELETE from customer WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["customerID"].Value.ToString() + "'";
                            DBConnect.QueryPostgre(Query);
                        Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
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
            if (e.ColumnIndex == 1)
            {
                using (CustomerDemo form = new CustomerDemo(dtGrid.Rows[e.RowIndex].Cells["customerID"].Value.ToString(),dtGrid.Rows[e.RowIndex].Cells["category"].Value.ToString()))
                {
                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                    }
                }
            }
        }

        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (String.IsNullOrEmpty(dtGrid.Rows[e.RowIndex].Cells["name"].Value.ToString()))
            {
                MessageBox.Show("Please input a name ");
                return;
            }
            string ID = dtGrid.Rows[e.RowIndex].Cells["customerID"].Value.ToString();
            Customer _c = new Customer(ID, dtGrid.Rows[e.RowIndex].Cells["name"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["contact"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["address"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["city"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["state"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["zip"].Value.ToString(),DateTime.Now.ToString("dd-MM-yyyy"),dtGrid.Rows[e.RowIndex].Cells["SOC-SEC#"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["Date Of Birth"].Value.ToString(),dtGrid.Rows[e.RowIndex].Cells["category"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["height"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["weight"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["gender"].Value.ToString(), false,Helper.CompanyID, dtGrid.Rows[e.RowIndex].Cells["uri"].Value.ToString());
            string save = DBConnect.UpdatePostgre(_c, ID);
            Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
            DBConnect.InsertPostgre(q);

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string Query = "UPDATE customer SET sync ='false'";
            DBConnect.QueryPostgre(Query);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            using (CustomerDemo form = new CustomerDemo(null,null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void dtGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

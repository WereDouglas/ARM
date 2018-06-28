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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();

            LoadData();
           
        }
        List<Users> users = new List<Users>();

        DataTable t = new DataTable();
        public void LoadData()
        {
            // create and execute query  
            t = new DataTable();
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
            t.Columns.Add("Sync");
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

            foreach (Users c in Users.List())
            {
                try
                {
                    t.Rows.Add(new object[] { false, c.Id, c.Image as string, b, c.Name,c.Email,c.Contact, c.Address, c.City, c.State, c.Zip,c.Category,c.Speciality,c.Gender, c.Sync, c.Created, view, delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message + "Viewing users {each users list }" + c.Name);
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
                Helper.Exceptions(c.ToString() + "Searching users by selection");

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("YES or No?", "Are you sure you want to delete these Users? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                foreach (var item in selectedIDs)
                {
                    string Query = "DELETE from users WHERE id ='" + item + "'";
                    DBConnect.QueryPostgre(Query);
                    Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                    DBConnect.InsertPostgre(q);
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

                    if (MessageBox.Show("YES or No?", "Are you sure you want to delete this User? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string Query = "DELETE from users WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
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
                using (AddUser form = new AddUser(dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString()))
                {
                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                    }
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string Query = "UPDATE users SET sync ='false'";
            DBConnect.QueryPostgre(Query);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            using (AddUser form = new AddUser(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
			string columnName = dtGrid.Columns[e.ColumnIndex].HeaderText;	
			try
			{
				String Query = "UPDATE users SET " + columnName + " ='" + dtGrid.Rows[e.RowIndex].Cells[columnName].Value.ToString() + "' WHERE Id = '" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
				DBConnect.QueryPostgre(Query);
				Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
				DBConnect.InsertPostgre(q);
			}
			catch (Exception c)
			{
				MessageBox.Show(c.Message.ToString());
				Helper.Exceptions(c.Message, "Editing User cell content grid");
				MessageBox.Show("You have an invalid entry !");
			}
			
		}
    }
}

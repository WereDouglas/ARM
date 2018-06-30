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
    public partial class FollowUpForm : Form
    {
        public FollowUpForm()
        {
            InitializeComponent();

            LoadData();


        }
        List<Follow> invoices = new List<Follow>();

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
            t.Columns.Add("Physician");
            t.Columns.Add("Product");
            t.Columns.Add("uriPro");
            t.Columns.Add(new DataColumn("imgPro", typeof(Bitmap)));//1  
            t.Columns.Add("Type");
            t.Columns.Add("Diagnosis");
            t.Columns.Add("Hospitalisation");
            t.Columns.Add("Source");
            t.Columns.Add("Length");
            t.Columns.Add("Need");
            t.Columns.Add("Goal");
            t.Columns.Add("Results");
            t.Columns.Add("Recommendation");
            t.Columns.Add("Follow visit");
            t.Columns.Add("Follow phone");
            t.Columns.Add("Next");
            t.Columns.Add("P/U");
            t.Columns.Add("Signature");
            t.Columns.Add("Authoriser");
            t.Columns.Add("Relationship");
            t.Columns.Add("Reason");          
            t.Columns.Add("Created");
            t.Columns.Add("Sync");          
           
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

            foreach (Follow c in Follow.List())
            {
                string imageCus = "";
                string imagePro = "";

                try { imageCus = Customer.Select(c.CustomerID).Image; } catch { }
                try { imagePro = Product.Select(c.ItemID).Image; } catch { }

                string prod = "";
                string cus = "";
                string phy = "";
                try { prod = Product.Select(c.ItemID).Name; } catch { }
                try { cus = Customer.Select(c.CustomerID).Name; } catch { }
                try { phy = Users.Select(c.UserID).Name; } catch { }
                try
                {
                    t.Rows.Add(new object[] { false, c.Id, imageCus as string, b, c.CustomerID +" "+ cus, c.UserID + " "+ phy, c.ItemID+" "+ prod, imagePro as string, b2, c.Type, c.Diagnosis, c.Hospitalisation, c.Source, c.Length, c.Need, c.Goal, c.Results, c.Recommend, c.FollowVisit, c.FollowPhone, c.Next, c.Pu, c.Signature, c.Authoriser, c.Relationship, c.Reason,c.Created, c.Sync,view, delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message , "Viewing Follow Up {each follow list } Setup date" + c.UserID);
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
            dtGrid.Columns["Customer"].DefaultCellStyle.BackColor = Color.LightGreen;
            dtGrid.Columns["Physician"].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dtGrid.Columns["ID"].Visible = false;
            dtGrid.Columns["ImgCus"].DefaultCellStyle.BackColor = Color.LightGreen;
            dtGrid.Columns["uriCus"].Visible = false;

            dtGrid.Columns["uriPro"].Visible = false;
            dtGrid.Columns["imgPro"].DefaultCellStyle.BackColor = Color.Wheat;


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
            if (MessageBox.Show("YES or No?", "Are you sure you want to delete these invoices? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                foreach (var item in selectedIDs)
                {
                    string Query = "DELETE from follow WHERE id ='" + item + "'";
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
                using (FollowForm form = new FollowForm(dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString()))
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

                    if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Follow? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string Query = "DELETE from follow WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString() + "'";
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

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string Query = "UPDATE follow SET sync ='false'";
            DBConnect.QueryPostgre(Query);
            string Query1 = "UPDATE itemReview SET sync ='false'";
            DBConnect.QueryPostgre(Query1);
            string Query2 = "UPDATE itemStatus SET sync ='false'";
            DBConnect.QueryPostgre(Query2);
            string Query3 = "UPDATE patientStatus SET sync ='false'";
            DBConnect.QueryPostgre(Query3);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            FollowForm f = new FollowForm(null);
            f.Show();
        }
    }
}

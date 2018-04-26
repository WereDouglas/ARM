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
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();

            LoadData();

        }
        List<Account> invoices = new List<Account>();

        DataTable t = new DataTable();
        public void LoadData()
        {
            // create and execute query  
            t = new DataTable();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("ID");
            t.Columns.Add("Physician");
            t.Columns.Add("Bank");
            t.Columns.Add("Account No.");           
            t.Columns.Add("Sync");
            t.Columns.Add("Created");           
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));           
            Image delete = new Bitmap(Properties.Resources.Server_Delete_16);

            foreach (Account c in Account.List())
            {               
                string user = "";               
                try { user = Users.Select(c.UserID).Name; } catch { }
                try
                {
                    t.Rows.Add(new object[] { false, c.Id,user,c.Bank,c.AccountNo, c.Sync, c.Created, delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message + "Viewing customer {each customer list }" + user);
                }
            }

            dtGrid.DataSource = t;
            dtGrid.AllowUserToAddRows = false;
            dtGrid.Columns["Bank"].DefaultCellStyle.BackColor = Color.LightGreen;
            dtGrid.Columns["Account No."].DefaultCellStyle.BackColor = Color.Red;
            dtGrid.Columns["ID"].Visible = false;
           

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
                Helper.Exceptions(c.ToString() + "Searching users by selection");

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("YES or No?", "Are you sure you want to delete these accounts? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                foreach (var item in selectedIDs)
                {
                    string Query = "DELETE from account WHERE id ='" + item + "'";
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
                    Console.WriteLine("REMOVED this id " + dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());

                }
                else
                {
                    selectedIDs.Add(dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    Console.WriteLine("ADDED ITEM " + dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                }
            }
           
            try
            {

                if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
                {

                    if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Account? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string Query = "DELETE from account WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString() + "'";
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
            string Query = "UPDATE account SET sync ='false'";
            DBConnect.QueryPostgre(Query);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            using (AccountDialog form = new AccountDialog(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {

                }
            }
        }
    }
    
    
}

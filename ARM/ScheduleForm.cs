using ARM.DB;
using ARM.Model;
using ARM.Util;
using System;
using System.Collections;
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
    public partial class ScheduleForm : Form
    {
        public ScheduleForm()
        {
            InitializeComponent();

            LoadData();

        }
        List<Schedule> invoices = new List<Schedule>();

        DataTable t = new DataTable();
        public void LoadData()
        {
            // create and execute query  
            t = new DataTable();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("ID");
            t.Columns.Add("Date");
            t.Columns.Add("Customer");
            t.Columns.Add("User");
            t.Columns.Add("Start");
            t.Columns.Add("End");
            t.Columns.Add("Location");
            t.Columns.Add("Address");
            t.Columns.Add("Details");
            t.Columns.Add("Indicator");
            t.Columns.Add("Period");
          
           // t.Columns.Add(new DataColumn("Category", typeof(DataGridViewComboBoxColumn)));
            t.Columns.Add("Category");
            t.Columns.Add("Status");
            t.Columns.Add("Cost");
            t.Columns.Add("Sync");
            t.Columns.Add("Created");
            
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));

            Image view = new Bitmap(Properties.Resources.Document_Edit_24__1_);
            Image delete = new Bitmap(Properties.Resources.Server_Delete_16);





            foreach (Schedule c in Schedule.List())
            {
                string user = "";
                string cus = "";
                try { user = Vendor.Select(c.UserID).Name; } catch { }
                try { cus = Customer.Select(c.CustomerID).Name; } catch { }
                try
                {
                    t.Rows.Add(new object[] { false, c.Id, c.Date, cus, user, c.Starts, c.Ends, c.Location, c.Address, c.Details, c.Indicator, c.Period, c.Category, c.Status, c.Cost, c.Sync, c.Created,  delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message + "Viewing customer {each schedule list }" + cus);
                }
            }

            dtGrid.DataSource = t;

            dtGrid.AllowUserToAddRows = false;
            dtGrid.Columns["Start"].DefaultCellStyle.BackColor = Color.LightGreen;
            dtGrid.Columns["End"].DefaultCellStyle.BackColor = Color.LightCoral;
            dtGrid.Columns["ID"].Visible = false;
            string summary = "";
            foreach (DataGridViewRow row in dtGrid.Rows)
            {

                try
                {
                    summary = row.Cells["Category"].Value.ToString();
                }
                catch { }
                if (summary.Contains("Shift"))
                {
                    row.DefaultCellStyle.ForeColor = Color.Azure;
                    row.DefaultCellStyle.Font = new Font("Calibri", 9.5F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Orange;
                }

            }
            DataTable dtConnectorSource = new DataTable();

            dtConnectorSource.Columns.Add("ConnectorName", typeof(int));
            dtConnectorSource.Columns.Add("ConnectorNameDisplay", typeof(String));

            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.DataSource = dtConnectorSource;
            cmb.DisplayMember = "ConnectorNameDisplay";
            cmb.ValueMember = "ConnectorName";

            cmb.DataPropertyName = "ConnectorName";

            dtGrid.Columns.Add(cmb);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string filterField = "User";
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
            if (MessageBox.Show("YES or No?", "Are you sure you want to delete these Schedules? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                foreach (var item in selectedIDs)
                {
                    string Query = "DELETE from schedule WHERE id ='" + item + "'";
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
          
            try
            {

                if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
                {

                    if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Schedule? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string Query = "DELETE from schedule WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString() + "'";
                        DBConnect.QueryPostgre(Query);
                        MessageBox.Show("Information deleted");
                        LoadData();

                    }

                }

            }
            catch { }

            //// Bind grid cell with combobox and than bind combobox with datasource.  
            //DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();

            //// Check the column  cell, in which it click.  
            //if (dtGrid.Columns[e.ColumnIndex].Name.Contains("Category"))
            //{
            //    // On click of datagridview cell, attched combobox with this click cell of datagridview  
            //    DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
            //    dgvCmb.HeaderText = "Name";
            //    dgvCmb.Items.Add("Ghanashyam");
            //    dgvCmb.Items.Add("Jignesh");
            //    dgvCmb.Items.Add("Ishver");
            //    dgvCmb.Items.Add("Anand");
            //    dgvCmb.Name = "cmbName";
            //    dtGrid.Columns.Add(dgvCmb);
            //}

            if (dtGrid.Columns[e.ColumnIndex].Name.Contains("Status"))
            {
              
            }


        }
        private DataGridViewComboBoxColumn CreateComboBox()
        {
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            {
                combo.Name = "comboColumn";
                combo.HeaderText = "Grade";
                ArrayList drl = new ArrayList();
                drl.Add("GS1");
                drl.Add("GS2");
                drl.Add("WG1");
                drl.Add("WG2");
                combo.Items.AddRange(drl.ToArray());
                combo.DataSource = drl;
                //combo.ValueMember = "EmployeeID";
                //combo.DisplayMember = "Grade";
                //combo.DataPropertyName = "Grade";
            }
            return combo;
        }


        private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string Query = "UPDATE schedule SET sync ='false'";
            DBConnect.QueryPostgre(Query);
        }

        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            using (ScheduleDialog form = new ScheduleDialog(null, null, null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                }
            }
        }
    }
}

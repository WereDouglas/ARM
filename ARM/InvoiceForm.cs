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
    public partial class InvoiceForm : Form
    {
        public InvoiceForm()
        {
            InitializeComponent();

            LoadData();

        }
        List<Invoice> invoices = new List<Invoice>();

        DataTable t = new DataTable();
        public void LoadData()
        {
            // create and execute query  
            t = new DataTable();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("ID");
            t.Columns.Add("No");
            t.Columns.Add("Date");
            t.Columns.Add("Type");
            t.Columns.Add("Category");
            t.Columns.Add("Vendor");
            t.Columns.Add("Customer");
            t.Columns.Add("Method");
            t.Columns.Add("Total");
            t.Columns.Add("Terms");
            t.Columns.Add("Tax");
            t.Columns.Add("Paid");
            t.Columns.Add("Balance");
            t.Columns.Add("By");
            t.Columns.Add("Qty");
            t.Columns.Add("Amount");
            t.Columns.Add("Sync");
            t.Columns.Add("Created");
            t.Columns.Add(new DataColumn("View", typeof(Image)));
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));//1



            Image view = new Bitmap(Properties.Resources.Document_Edit_24__1_);
            Image delete = new Bitmap(Properties.Resources.Server_Delete_16);

            foreach (Invoice c in Invoice.List())
            {
                string ven = "";
                string cus = "";
                try { ven = Vendor.Select(c.VendorID).Name; } catch { }
                try { cus = Customer.Select(c.CustomerID).Name; } catch { }
                try
                {
                    t.Rows.Add(new object[] { false, c.Id, c.No, c.Date, c.Type, c.Category, ven, cus, c.Method, c.Total.ToString("N0"), c.Terms, c.Tax.ToString("N0"), c.Paid.ToString("N0"), c.Balance.ToString("N0"), c.UserID,c.ItemCount,c.Amount.ToString("N0"), c.Sync, c.Created, view, delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message + "Viewing customer {each customer list }" + c.No);
                }
            }

            dtGrid.DataSource = t;

            dtGrid.AllowUserToAddRows = false;
            dtGrid.Columns["Paid"].DefaultCellStyle.BackColor = Color.LightGreen;
            dtGrid.Columns["Balance"].DefaultCellStyle.BackColor = Color.Red;
            dtGrid.Columns["ID"].Visible = false;
            dtGrid.Columns["select"].Width = 30;

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
            if (MessageBox.Show("YES or No?", "Are you sure you want to delete these invoices? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                foreach (var item in selectedIDs)
                {
                    string Query = "DELETE from customer WHERE id ='" + item + "'";
                    DBConnect.save(Query);
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
                    selectedIDs.Add(dtGrid.Rows[e.RowIndex].Cells["customerID"].Value.ToString());
                    Console.WriteLine("ADDED ITEM " + dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                }
            }
            if (e.ColumnIndex == dtGrid.Columns["View"].Index && e.RowIndex >= 0)
            {
                using (AddTransaction form = new AddTransaction(dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString()))
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

                    if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Invoice? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string Query = "DELETE from customer WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["customerID"].Value.ToString() + "'";
                        DBConnect.save(Query);
                        MessageBox.Show("Information deleted");
                        LoadData();

                    }
                    Console.WriteLine("DELETE on row {0} clicked", e.RowIndex + dtGrid.Rows[e.RowIndex].Cells[0].Value.ToString() + dtGrid.Rows[e.RowIndex].Cells[2].Value.ToString());

                }

            }
            catch { }
        }

        private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}

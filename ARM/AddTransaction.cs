using ARM.DB;
using ARM.Model;
using ARM.Util;
using Microsoft.Reporting.WinForms;
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
    public partial class AddTransaction : Form
    {
        Dictionary<string, string> VendorDictionary = new Dictionary<string, string>();
        Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
        public AddTransaction(string No)
        {
            InitializeComponent();
            try
            {
                noTxt.Text = (DBConnect.Max("SELECT MAX(CAST(no AS DOUBLE PRECISION)) FROM invoice") + 1).ToString();
            }
            catch
            {
                noTxt.Text = " 1 ";
            }
         GenericCollection.transactions = new List<Transaction>();

        }
       
        private void AutoCompleteVendor()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            VendorDictionary.Clear();
            foreach (Vendor v in Vendor.List())
            {
                AutoItem.Add((v.Name));

                if (!VendorDictionary.ContainsKey(v.Name))
                {
                    VendorDictionary.Add(v.Name, v.Id);
                }
            }
            vendorTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            vendorTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            vendorTxt.AutoCompleteCustomSource = AutoItem;

        }
        private void AutoCompleteCustomer()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            CustomerDictionary.Clear();
            foreach (Customer c in Customer.List())
            {
                AutoItem.Add((c.Name));

                if (!CustomerDictionary.ContainsKey(c.Name))
                {
                    CustomerDictionary.Add(c.Name, c.Id);
                }
            }
            customerTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            customerTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            customerTxt.AutoCompleteCustomSource = AutoItem;

        }
        List<Users> users = new List<Users>();
        Product k = new Product();
        DataTable t = new DataTable();
        double Total = 0;
        public void LoadTransactions()
        {
            // create and execute query  
            t = new DataTable();

            t.Columns.Add("id");
            t.Columns.Add("ItemID");
            t.Columns.Add("Product");
            t.Columns.Add("Qty");
            t.Columns.Add("Cost");
            t.Columns.Add("Total");
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));
            Image delete = new Bitmap(Properties.Resources.Cancel_16);

            foreach (Transaction j in GenericCollection.transactions)
            {
                try
                {
                    k = Product.Select(j.ItemID);
                    t.Rows.Add(new object[] { j.Id, j.ItemID, k.Name, j.Qty, j.Cost.ToString("N0"), j.Total.ToString("N0"), delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message + "Viewing users {each transaction list }" + j.ItemID);
                }
            }
            Total = GenericCollection.transactions.Sum(r => r.Total);
            totalTxt.Text = Total.ToString("N0");

            dtGrid.DataSource = t;

            dtGrid.AllowUserToAddRows = false;
            // dtGrid.Columns["View"].DefaultCellStyle.BackColor = Color.LightGreen;
            //  dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;

            dtGrid.Columns["id"].Visible = false;
            dtGrid.Columns["ItemID"].Visible = false;
            ItemCountTxt.Text = GenericCollection.transactions.Count().ToString();


        }

        private void label1_Click(object sender, EventArgs e)
        {

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
                    //  MessageBox.Show("Information deleted");
                }
            }
        }
        List<string> selectedIDs = new List<string>();
        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
                {

                    if (MessageBox.Show("YES or No?", "Are you sure you want to remove this product ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        // GenericCollection.transactions.Remove(u=>u.dtGrid.Columns["itemID"].Index);
                        var itemToRemove = GenericCollection.transactions.Single(r => r.ItemID == dtGrid.Rows[e.RowIndex].Cells["ItemID"].Value.ToString());
                        GenericCollection.transactions.Remove(itemToRemove);
                        LoadTransactions();

                    }
                }

            }
            catch { }
        }


        private void AddTransaction_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (AddPurchase form = new AddPurchase(noTxt.Text, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadTransactions();
                }
            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        string VendorID = "";
        Vendor v;
        private void vendorTxt_Leave(object sender, EventArgs e)
        {
            try
            {
                VendorID = VendorDictionary[vendorTxt.Text];
                v = new Vendor();//.Select(ItemID);
                v = Vendor.Select(VendorID);
                Image img = Helper.Base64ToImage(v.Image);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                vendorPbx.Image = bmp;
                vendorPbx.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch { }
        }

        private void amountTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void categoryCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoryCbx.Text == "Sale")
            {

                AutoCompleteCustomer();
                typeCbx.Text = "Credit";
                vendorTxt.Text = Helper.CompanyName;
            }
            if (categoryCbx.Text == "Purchase")
            {
                AutoCompleteVendor();
                typeCbx.Text = "Debit";
                customerTxt.Text = Helper.CompanyName;
                CustomerID = Helper.CompanyID;

            }
            if (categoryCbx.Text == "Rent")
            {
                AutoCompleteVendor();

            }
            if (categoryCbx.Text == "Maintenance")
            {
                AutoCompleteVendor();
            }
        }
        string CustomerID;
        Customer c;

        public object ReportBindingSource { get; }

        private void customerTxt_Leave(object sender, EventArgs e)
        {
            try
            {
                CustomerID = CustomerDictionary[customerTxt.Text];
                c = new Customer();//.Select(ItemID);
                c = Customer.Select(CustomerID);
                Image img = Helper.Base64ToImage(c.Image);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                vendorPbx.Image = bmp;
                vendorPbx.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch { }
        }


        private void amountTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                balanceTxt.Text =(Math.Round((Total - Convert.ToDouble(amountTxt.Text)),2)).ToString();
                if ((Math.Round((Total - Convert.ToDouble(amountTxt.Text)), 2))<0) {
                    MessageBox.Show("Balance cannot be negative");
                    balanceTxt.BackColor = Color.Red;
                    return;

                }
            }
            catch { }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(amountTxt.Text))
            {
                amountTxt.BackColor = Color.Red;
                MessageBox.Show("How much is being paid ? ");
                return;
            }
            if (GenericCollection.transactions.Count < 1)
            {

                MessageBox.Show("No Products Defined !");
                return;
            }
            if (string.IsNullOrEmpty(categoryCbx.Text))
            {
                categoryCbx.BackColor = Color.Red;
                MessageBox.Show("How much is being paid ? ");
                return;
            }
            if (string.IsNullOrEmpty(typeCbx.Text))
            {
                typeCbx.BackColor = Color.Red;
                MessageBox.Show("How much is being paid ? ");
                return;
            }
            taxTxt.Text = string.IsNullOrEmpty(taxTxt.Text) ? "0" : taxTxt.Text;
            amountTxt.Text = string.IsNullOrEmpty(amountTxt.Text) ? "0" : amountTxt.Text;
            methodCbx.Text = string.IsNullOrEmpty(methodCbx.Text) ? "none" : "none";
          
            string Iid = Guid.NewGuid().ToString();
            Invoice i = new Invoice(Iid, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), noTxt.Text, typeCbx.Text, categoryCbx.Text, VendorID, CustomerID, methodCbx.Text, Total, termsTxt.Text, Convert.ToDouble(taxTxt.Text), Convert.ToDouble(amountTxt.Text), Convert.ToDouble(balanceTxt.Text), Convert.ToDouble(amountTxt.Text), Convert.ToInt32(ItemCountTxt.Text), Helper.UserID, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),false,Helper.CompanyID);
            if (DBConnect.InsertPostgre(i) != "")
            {
                foreach (Transaction t in GenericCollection.transactions)
                {
                    Transaction c = new Transaction(t.Id, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), noTxt.Text, t.ItemID, t.Total, t.Qty, t.Cost, t.Created,false,Helper.CompanyID);
                    if (DBConnect.InsertPostgre(c) != "")
                    {
                    }
                }

                string Pid = Guid.NewGuid().ToString();
                Payment p = new Payment(Pid, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), noTxt.Text, typeCbx.Text, methodCbx.Text, Convert.ToDouble(amountTxt.Text), Convert.ToDouble(balanceTxt.Text), DateTime.Now.ToString("dd-MM-yyyy H:m:s"),false,Helper.CompanyID);
                if (DBConnect.InsertPostgre(p) != "")
                {
                }               
            }
            using (ReceiptForm form = new ReceiptForm(noTxt.Text))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //  LoadData();
                }
            }

            button3.Visible = false;

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {
            button4_Click(null, null);
        }

        private void InvoiceBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void TransactionBingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void balanceTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
            && !char.IsDigit(e.KeyChar)
            && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow two decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void taxTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
            && !char.IsDigit(e.KeyChar)
            && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow two decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}

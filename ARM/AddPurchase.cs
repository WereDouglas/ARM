using ARM.Model;
using ARM.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
    public partial class AddPurchase : MetroFramework.Forms.MetroForm
    {
        Dictionary<string, string> ProductDictionary = new Dictionary<string, string>();
        string No;
        string CaseID;
        string Date;
        String CustomerID;
        public AddPurchase(string caseID,string no, string date,string customerID)
        {
            InitializeComponent();
            AutoCompleteProduct();
            No = no;
            Date = date;
            CustomerID = customerID;
           TransactionID = Guid.NewGuid().ToString();
            if (!string.IsNullOrEmpty(caseID)) { CaseID = caseID; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void AutoCompleteProduct()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            ProductDictionary.Clear();
            foreach (Product v in Product.List())
            {
                AutoItem.Add((v.Name));

                if (!ProductDictionary.ContainsKey(v.Name))
                {
                    ProductDictionary.Add(v.Name, v.Id);
                    productTxt.Items.Add(v.Name);
                }
            }
            //productTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            //productTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //productTxt.AutoCompleteCustomSource = AutoItem;
            GenericCollection.itemCoverage = new List<ItemCoverage>();
        }
        string ItemID;
        Product i;
        private void productTxt_Leave(object sender, EventArgs e)
        {
            
        }
        string TransactionID;
        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble (qtyTxt.Text)<1) {

                qtyTxt.BackColor = Color.Red;
                MessageBox.Show("Please input the quantity");
                return;
            }           
         
            Transaction t = new Transaction(TransactionID, Date, No, ItemID,CaseID, Convert.ToDouble(qtyTxt.Text), Convert.ToDouble(costTxt.Text), measureTxt.Text,Convert.ToDouble(amountTxt.Text), DateTime.Now.ToString("dd-MM-yyyy H:m:s"),false,Helper.CompanyID);
            GenericCollection.transactions.Add(t);
            this.DialogResult = DialogResult.OK;
            this.Dispose();

        }

        private void qtyTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                amountTxt.Text = (Convert.ToDouble(costTxt.Text) * Convert.ToDouble(qtyTxt.Text)).ToString();
            }
            catch { }
        }

        private void productTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ItemID = ProductDictionary[productTxt.Text];
                i = new Product();//.Select(ItemID);
                i = Product.Select(ItemID);
                Image img = Helper.Base64ToImage(i.Image);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                productPbx.Image = bmp;
                productPbx.SizeMode = PictureBoxSizeMode.StretchImage;
                costTxt.Text = i.Cost;
                measureTxt.Text = i.UnitOfMeasure;
                measureDesTxt.Text = i.MeasureDescription;
                ManufacturerTxt.Text = i.Manufacturer;
                descriptionTxt.Text = i.Description;
            }
            catch { }
        }

        private void qtyTxt_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void qtyTxt_KeyPress(object sender, KeyPressEventArgs e)
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
        DataTable t;
        Double VariableTotal = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            using (AddCoverage form = new AddCoverage(TransactionID, CustomerID, ItemID, VariableTotal))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadCoverage();
                }
            }
        }
        public void LoadCoverage()
        {
            // create and execute query  
            t = new DataTable();
            t.Columns.Add("id");
            t.Columns.Add("%");
            t.Columns.Add("Amount");            
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));
            Image delete = new Bitmap(Properties.Resources.Cancel_16);

            foreach (ItemCoverage j in GenericCollection.itemCoverage)
            {
                try
                {
                     Product  k = Product.Select(j.ItemID);
                    t.Rows.Add(new object[] { j.Id, j.Percentage, j.Amount, delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message + "Viewing Coverage {each coverage item in the coverage list }" + j.ItemID);
                }
            }
             VariableTotal  = Convert.ToDouble( amountTxt.Text) - GenericCollection.itemCoverage.Sum(r => r.Amount);

            

            dtGrid.DataSource = t;

            dtGrid.AllowUserToAddRows = false;
            // dtGrid.Columns["View"].DefaultCellStyle.BackColor = Color.LightGreen;
            //  dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;

            dtGrid.Columns["id"].Visible = false;
            dtGrid.Columns["ItemID"].Visible = false;
            


        }

        private void taxPercTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                totalTxt.Text = ((Convert.ToDouble(taxPercTxt.Text) / 100) * Convert.ToDouble(amountTxt.Text)).ToString();
            }
            catch { }
        }
    }
}

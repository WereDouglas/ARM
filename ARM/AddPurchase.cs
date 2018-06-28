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
        Dictionary<string, string> CodeDictionary = new Dictionary<string, string>();
        string No;
        string CaseID;
        string Date;
        String CustomerID;
        public AddPurchase(string caseID, string no, string date, string customerID)
        {
            InitializeComponent();
            AutoCompleteProduct();
            AutoCompleteCode();
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
        private void AutoCompleteCode()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            CodeDictionary.Clear();
            foreach (Product v in Product.List())
            {
                AutoItem.Add((v.Code));

                if (!CodeDictionary.ContainsKey(v.Code))
                {
                    CodeDictionary.Add(v.Code, v.Id);
                   
                }
            }
            codeTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            codeTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            codeTxt.AutoCompleteCustomSource = AutoItem;
            
        }
        string ItemID;
        Product i;
        private void productTxt_Leave(object sender, EventArgs e)
        {

        }
        string TransactionID;
        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(qtyTxt.Text) < 1)
            {
                qtyTxt.BackColor = Color.Red;
                MessageBox.Show("Please input the quantity");
                return;
            }
			try
			{
				double val = Convert.ToDouble(costTxt.Text);
			}
			catch {

				MessageBox.Show("Product has invalid cost value ");
				return;

			}

			Transaction t = new Transaction(TransactionID, Date, No, ItemID, CaseID, "", Convert.ToDouble(qtyTxt.Text), Convert.ToDouble(costTxt.Text), measureTxt.Text, Payable, Tax, TotalCoverage, TotalSelf, Payable, "", "", "", "", "", "", DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID);
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
                codeTxt.Text = i.Code;
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
            using (AddCoverage form = new AddCoverage(TransactionID, CustomerID, ItemID,Convert.ToDouble(amountTxt.Text)))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadCoverage();
                }
            }
        }
        Double TotalCoverage = 0;
        Double TotalSelf = 0;
        public void LoadCoverage()
        {
            // create and execute query  
            t = new DataTable();
            t.Columns.Add("id");
            t.Columns.Add("Provider");
            t.Columns.Add("%");
            t.Columns.Add("Amount");
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));
            Image delete = new Bitmap(Properties.Resources.Cancel_16);

            foreach (ItemCoverage j in GenericCollection.itemCoverage)
            {
                try
                {
                    string coverage = "";
                   
                    coverage = Coverage.Select(j.CoverageID).Name;
                    t.Rows.Add(new object[] { j.Id,coverage, j.Percentage, j.Amount, delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message + "Viewing Coverage {each coverage item in the coverage list }" + j.ItemID);
                }
            }
            VariableTotal = Convert.ToDouble(amountTxt.Text) - GenericCollection.itemCoverage.Sum(r => r.Amount);
            TotalCoverage = GenericCollection.itemCoverage.Sum(r => r.Amount);
            TotalSelf = Convert.ToDouble(amountTxt.Text) - TotalCoverage;
            selfTxt.Text = TotalSelf.ToString();

            dtGrid.DataSource = t;

            dtGrid.AllowUserToAddRows = false;
            // dtGrid.Columns["View"].DefaultCellStyle.BackColor = Color.LightGreen;
            //  dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;

            dtGrid.Columns["id"].Visible = false;
            
        }
        double Tax = 0;
        double Payable = 0;
        private void taxPercTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Tax =Math.Round( ((Convert.ToDouble(taxPercTxt.Text) / 100) * Convert.ToDouble(amountTxt.Text)),2);
                taxTxt.Text = Tax.ToString();

            }
            catch { }


            try
            {
                Payable = Math.Round((Convert.ToDouble(amountTxt.Text) + Tax),2);
                payableTxt.Text = (Convert.ToDouble(amountTxt.Text) + Tax).ToString();
            }
            catch { }
        }

        private void codeTxt_Leave(object sender, EventArgs e)
        {
            try
            {
                ItemID = CodeDictionary[codeTxt.Text];
               
                i = new Product();//.Select(ItemID);
                i = Product.Select(ItemID);
                productTxt.Text = i.Name;

              
            }
            catch { }
        }

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

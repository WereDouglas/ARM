using ARM.DB;
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
    public partial class AddCoverage : MetroFramework.Forms.MetroForm
    {
        Dictionary<string, string> CoverDictionary = new Dictionary<string, string>();
        string No;
        string Date;
        string CustomerID;
        string TransID;
        string CoverID;
        double Total;
        public AddCoverage(string transactionID, string customerID, string itemID, double total)
        {
            InitializeComponent();


            CustomerID = customerID;
            TransID = transactionID;
            Total = total;
            ItemID = itemID;
            try
            {

                i = new Product();//.Select(ItemID);
                i = Product.Select(ItemID);
                productLbl.Text = i.Name;

            }
            catch { }
            AutoCompleteCoverage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void AutoCompleteCoverage()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            CoverDictionary.Clear();
            string Q = "SELECT * FROM coverage WHERE customerID = '" + CustomerID + "' ";
            foreach (Coverage c in Coverage.List(Q))
            {
                AutoItem.Add((c.Name));

                if (!CoverDictionary.ContainsKey(c.Name))
                {
                    CoverDictionary.Add(c.Name, c.Id);
                    CoverageCbx.Items.Add(c.Name);
                }
            }
            //productTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            //productTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //productTxt.AutoCompleteCustomSource = AutoItem;

        }
        string ItemID;
        Product i;


        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(percTxt.Text) < 0)
            {

                percTxt.BackColor = Color.Red;
                MessageBox.Show("Please input the percentage contribution !");
                return;
            }
            string id = Guid.NewGuid().ToString();
            ItemCoverage t = new ItemCoverage(id, TransID, ItemID, CoverID, Convert.ToDouble(percTxt.Text), Convert.ToDouble(amountTxt.Text), DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID);
            GenericCollection.itemCoverage.Add(t);

            ItemCoverage c = new ItemCoverage(t.Id, t.CaseTransactionID, t.ItemID, t.CoverageID, t.Percentage, t.Amount, t.Created, false, Helper.CompanyID);
            string save = DBConnect.InsertPostgre(c);
            if (save  != "")
            {
                Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                DBConnect.InsertPostgre(q);
            }
            this.DialogResult = DialogResult.OK;
            this.Dispose();

        }
        private void qtyTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                amountTxt.Text = (Total * (Convert.ToDouble(percTxt.Text) / 100)).ToString();
            }
            catch { }
        }

        private void productTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CoverID = CoverDictionary[CoverageCbx.Text];

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



    }
}

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
        string Date;
        public AddPurchase(string no, string date)
        {
            InitializeComponent();
            AutoCompleteProduct();
            No = no;
            Date = date;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void AutoCompleteProduct()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            ProductDictionary.Clear();
            foreach (Item v in Item.List())
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

        }
        string ItemID;
        Item i;
        private void productTxt_Leave(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble (qtyTxt.Text)<1) {

                qtyTxt.BackColor = Color.Red;
                MessageBox.Show("Please input the quantity");
                return;
            }
            string id = Guid.NewGuid().ToString();
         
            Transaction t = new Transaction(id, Date, No, ItemID, Convert.ToDouble(amountTxt.Text), Convert.ToDouble(qtyTxt.Text), Convert.ToDouble(costTxt.Text), DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false);
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
                i = new Item();//.Select(ItemID);
                i = Item.Select(ItemID);
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
    }
}

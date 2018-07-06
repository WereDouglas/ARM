using ARM.DB;
using ARM.Model;
using ARM.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
    public partial class InsuranceDialog : MetroFramework.Forms.MetroForm
    {

        Dictionary<string, string> UserDictionary = new Dictionary<string, string>();
        Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
        string CustomerID;
        string UserID;
        public InsuranceDialog(string customerID)
        {
            InitializeComponent();
           
            CustomerID = customerID;
            AutoCompleteCustomer();           
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
                  // customerCbx.Items.Add(c.Name);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(typeCbx.Text))
            {
                typeCbx.BackColor = Color.Red;
                MessageBox.Show(" Please select the type of Insurance");
                return;
            }
            string ID = Guid.NewGuid().ToString();
            Coverage _e = new Coverage(ID,CustomerID,nameTxt.Text,typeCbx.Text,catCbx.Text,noTxt.Text, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"),false,Helper.CompanyID,Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"));
            string save = DBConnect.InsertPostgre(_e);
            if (save != "")
            {
                Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                DBConnect.InsertPostgre(q);

                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }

        }
        string Query;
        private void Update(string itemID)
        {
            //MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            //string fullimage = Helper.ImageToBase64(stream);
            //Item c = new Item(itemID, nameTxt.Text, categoryCbx.Text, typeCbx.Text, descriptionxt.Text, costTxt.Text, batchTxt.Text, serialTxt.Text, barTxt.Text, unitTxt.Text, unitDescTxt.Text, manuTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, fullimage);
            //DBConnect.Update(c, itemID);
            //MessageBox.Show("Information Updated");
            //this.DialogResult = DialogResult.OK;
            //this.Dispose();
        }
        Customer c;
        
        Users u;
        Rate r;
       
        private void InsuranceDialog_Load(object sender, EventArgs e)
        {

        }

    }
}

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
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ARM
{
    public partial class OrderIntakeForm : MetroFramework.Forms.MetroForm
    {
        Dictionary<string, string> UserDictionary = new Dictionary<string, string>();
        Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
        Dictionary<string, string> ProductDictionary = new Dictionary<string, string>();
        string CustomerID;
        string UserID;
        public OrderIntakeForm()
        {
            InitializeComponent();
            AutoCompleteUser();
            AutoCompleteCustomer();
            AutoCompleteProduct();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        Dictionary<string, bool> SetupDictionary = new Dictionary<string, bool>();
        Dictionary<string, bool> DischargeDictionary = new Dictionary<string, bool>();
        Dictionary<string, bool> ActionDictionary = new Dictionary<string, bool>();
        private void button3_Click(object sender, EventArgs e)
        {
            string strSetup = "";
            string strDischarge = "";
            string strAction = "";
            foreach (var s in setupListBx.CheckedItems)
            {
                SetupDictionary.Add(s.ToString(), true);
                strSetup += s.ToString()+":true,";
            }

            foreach (var pair in SetupDictionary)
            {
                System.Diagnostics.Debug.WriteLine("{0}, {1}", pair.Key, pair.Value);
            }
            foreach (var s in dischargeListBx.CheckedItems)
            {
                DischargeDictionary.Add(s.ToString(), true);
                strDischarge += s.ToString() + ":true,";
            }
            foreach (var s in actionListBx.CheckedItems)
            {
                ActionDictionary.Add(s.ToString(), true);
                strAction += s.ToString() + ":true,";
            }
            string id = Guid.NewGuid().ToString();
            Order i = new Order(id, CustomerID, UserID, ItemID ,orderDate.Text,recievedCbx.Text,dispenseDateTxt.Text,dispensedCbx.Text,subscriberTypeTxt.Text,diagnosisTxt.Text,surgeryTxt.Text, Convert.ToDateTime(clinicalDateTxt.Text).ToString("dd-MM-yyyy"), limitTxt.Text,heightTxt.Text,weightTxt.Text,instructionTxt.Text,periodTxt.Text, strSetup,setupDate.Text,strDischarge, Convert.ToDateTime(dispenseDateTxt.Text).ToString("dd-MM-yyyy"),strAction,Convert.ToDateTime(dateNotifiedTxt.Text).ToString("dd-MM-yyyy"),"", Convert.ToDateTime(dateAuthTxt.Text).ToString("dd-MM-yyyy"), DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false,strAction,otherTxt.Text);
            //if (DBConnect.Insert(i) != "")
            //{

            //    MessageBox.Show("Information Saved");
            //    this.Close();
            //}

        }
        private void AutoCompleteUser()
        {

            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            UserDictionary.Clear();
            foreach (Users v in Users.List())
            {
                AutoItem.Add((v.Name));

                if (!UserDictionary.ContainsKey(v.Name))
                {
                    UserDictionary.Add(v.Name, v.Id);
                    userCbx.Items.Add(v.Name);
                    recievedCbx.Items.Add(v.Name);
                    dispensedCbx.Items.Add(v.Name);
                }
            }

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
                    productCbx.Items.Add(v.Name);
                }
            }
           
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
                    customerCbx.Items.Add(c.Name);
                }
            }
        }
        Customer c;
        Insurance ins;
        private void customerCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CustomerID = CustomerDictionary[customerCbx.Text];
                c = new Customer();//.Select(ItemID);
                c = Customer.Select(CustomerID);
                subscriberInfoTxt.Text = "Name: " + c.Name + "\t DOB: " + c.Dob + " \r\n Address: " + c.Address + "\r\n City/state: " + c.City + " " + c.State + "\t Zip: " + c.Zip + " \r\n  Phone: " + c.Contact + "\t Soc.Sec.#: " + c.Ssn;
                subscriberTypeTxt.Text = c.Category;
                System.Drawing.Image img = Helper.Base64ToImage(c.Image);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                cusPbx.Image = bmp;
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(cusPbx.DisplayRectangle);
                cusPbx.Region = new Region(gp);
                cusPbx.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch { }
            try
            {

                foreach (Insurance c in Insurance.Select(CustomerID))
                {
                    insuranceInfoTxt.Text = "" + c.Type + "\r\n" + "Name: " + c.Name + "\t ID# : " + c.No + " \r\n Address: " + c.Address + "\t Zip: " + c.Zip + " \r\n  Phone: " + c.Contact;
                }

            }
            catch { }
        }
        Users u;

        private void userCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UserID = UserDictionary[userCbx.Text];
                u = new Users();//.Select(ItemID);
                u = Users.Select(UserID);
                System.Drawing.Image img = Helper.Base64ToImage(u.Image);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                userPbx.Image = bmp;
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(userPbx.DisplayRectangle);
                userPbx.Region = new Region(gp);
                userPbx.SizeMode = PictureBoxSizeMode.StretchImage;
                physicianTxt.Text = "Name: " + u.Name + "\t Phone: " + u.Contact + " \r\n Address: " + u.Address + "\t City/state: " + u.City + " " + u.State + "\t Zip: " + u.Zip + " \r\n";

            }
            catch { }

        }
        string ItemID;
        Item i;
        private void productCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ItemID = ProductDictionary[productCbx.Text];
                i = new Item();//.Select(ItemID);
                i = Item.Select(ItemID);
                System.Drawing.Image img = Helper.Base64ToImage(i.Image);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                productPbx.Image = bmp;
                productPbx.SizeMode = PictureBoxSizeMode.StretchImage;
                //costTxt.Text = i.Cost;
                // measureTxt.Text = i.UnitOfMeasure;
                // measureDesTxt.Text = i.MeasureDescription;
                //ManufacturerTxt.Text = i.Manufacturer;
                //descriptionTxt.Text = i.Description;
            }
            catch { }
        }
        
    }
}

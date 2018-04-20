using ARM.DB;
using ARM.Model;
using ARM.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ARM
{
    public partial class OrderIntakeForm : MetroFramework.Forms.MetroForm
    {
        Dictionary<string, string> UserDictionary = new Dictionary<string, string>();
        Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
        Dictionary<string, string> ProductDictionary = new Dictionary<string, string>();

        Dictionary<string, bool> SetupDictionary = new Dictionary<string, bool>();
        Dictionary<string, bool> DischargeDictionary = new Dictionary<string, bool>();
        Dictionary<string, bool> ActionDictionary = new Dictionary<string, bool>();

        string CustomerID;
        string UserID;
        string OrderID;
        public OrderIntakeForm(string id)
        {
            InitializeComponent();
            AutoCompleteUser();
            AutoCompleteCustomer();
            AutoCompleteProduct();
            if (!string.IsNullOrEmpty(id))
            {
                OrderID = id;
                LoadEdit(id);
            }
            printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
        }
        private Orders o;
        private void LoadEdit(string id)
        {
            OrderID = id;
            o = new Orders();//.Select(UsersID);
            o = Orders.Select(id);

            CustomerID = o.CustomerID;
            customerCbx.Text = CustomerDictionary.First(e => e.Value == o.CustomerID).Key;
            customerCbx_SelectedIndexChanged(null, null);

            UserID = o.UserID;
            userCbx.Text = UserDictionary.First(e => e.Value == o.UserID).Key;
            userCbx_SelectedIndexChanged(null, null);

            ItemID = o.ItemID;
            productCbx.Text = ProductDictionary.First(e => e.Value == o.ItemID).Key;
            productCbx_SelectedIndexChanged(null, null);

            recievedCbx.Text = o.OrderBy;
            dispensedCbx.Text = o.DispenseBy;
            dispenseDateTxt.Text = Convert.ToDateTime(o.DispenseDateTime).ToString();
            diagnosisTxt.Text = o.Diagnosis;
            surgeryTxt.Text = o.Surgery;
            limitTxt.Text = o.EquipmentLimits;
            heightTxt.Text = o.EquipmentHeights;
            weightTxt.Text = o.EquipmentWeights;
            periodTxt.Text = o.EquipmentPeriod;
            instructionTxt.Text = o.EquipmentInstructions;
            otherTxt.Text = o.Other;
            // dateAuthTxt.Text = Convert.ToDateTime(o.AuthorizationDate).ToString();
            // dateNotifiedTxt.Text = Convert.ToDateTime(o.NotificationDate).ToString();
            Dictionary<string, bool> setUpValues = JsonConvert.DeserializeObject<Dictionary<string, bool>>(o.SetupLocation);
            setupListBx.Items.Clear();
            foreach (var t in setUpValues)
            {
                setupListBx.Items.Add(t.Key,t.Value);
            }

            Dictionary<string, bool> actionValues = JsonConvert.DeserializeObject<Dictionary<string, bool>>(o.Action);
            actionListBx.Items.Clear();
            foreach (var t in actionValues)
            {
                actionListBx.Items.Add(t.Key, t.Value);
            }

            Dictionary<string, bool> dischargeValues = JsonConvert.DeserializeObject<Dictionary<string, bool>>(o.DischargeLocation);
            dischargeListBx.Items.Clear();
            foreach (var t in dischargeValues)
            {
                dischargeListBx.Items.Add(t.Key, t.Value);
            }

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

        private void button3_Click(object sender, EventArgs e)
        {           
            foreach (var s in setupListBx.CheckedItems)
            {
                SetupDictionary.Add(s.ToString(), true);               
            }           
            foreach (var s in dischargeListBx.CheckedItems)
            {
                DischargeDictionary.Add(s.ToString(), true);              
            }
            foreach (var s in actionListBx.CheckedItems)
            {
                ActionDictionary.Add(s.ToString(), true);               
            }
            var DischargeJson = JsonConvert.SerializeObject(DischargeDictionary);
            var ActionJson = JsonConvert.SerializeObject(ActionDictionary);
            var SetupJson = JsonConvert.SerializeObject(SetupDictionary);
            string id = Guid.NewGuid().ToString();
            Orders i = new Orders(id, CustomerID, UserID, ItemID, orderDate.Text, recievedCbx.Text, dispenseDateTxt.Text, dispensedCbx.Text, subscriberTypeTxt.Text, diagnosisTxt.Text, surgeryTxt.Text, Convert.ToDateTime(clinicalDateTxt.Text).ToString("dd-MM-yyyy"), limitTxt.Text, heightTxt.Text, weightTxt.Text, instructionTxt.Text, periodTxt.Text, SetupJson, setupDate.Text, DischargeJson, Convert.ToDateTime(dispenseDateTxt.Text).ToString("dd-MM-yyyy"), ActionJson, Convert.ToDateTime(dateNotifiedTxt.Text).ToString("dd-MM-yyyy"), "", Convert.ToDateTime(dateAuthTxt.Text).ToString("dd-MM-yyyy"), DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, ActionJson, otherTxt.Text);
            if (DBConnect.InsertPostgre(i) != "")
            {

                MessageBox.Show("Information Saved");
                this.Close();
            }

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

        private void button1_Click(object sender, EventArgs e)
        {
            Print(panel1);
        }
        public void Print(System.Windows.Forms.Panel pnl)
        {
            panel1 = pnl;
            GetPrintArea(pnl);
            previewdlg.Document = printdoc1;
            try
            {
                previewdlg.ShowDialog();
            }
            catch { }
        }
        //Rest of the code
        Bitmap MemoryImage;
        public void GetPrintArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (MemoryImage != null)
            {
                e.Graphics.DrawImage(MemoryImage, 0, 0);
                base.OnPaint(e);
            }
        }
        void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }
    }
}

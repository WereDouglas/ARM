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
    public partial class AddInstructionDelivery : MetroFramework.Forms.MetroForm
    {
        Dictionary<string, string> UserDictionary = new Dictionary<string, string>();
        Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
        Dictionary<string, string> ProductDictionary = new Dictionary<string, string>();

        Dictionary<string, bool> SafetyDictionary = new Dictionary<string, bool>();
        Dictionary<string, bool> AppropriateDictionary = new Dictionary<string, bool>();
        Dictionary<string, bool> EquipmentDictionary = new Dictionary<string, bool>();
        Dictionary<string, bool> AdditionalDictionary = new Dictionary<string, bool>();

        string CustomerID;
        string UserID;
        string InstructionID;
        public AddInstructionDelivery(string id)
        {
            InitializeComponent();
            AutoCompleteUser();
            AutoCompleteCustomer();
            AutoCompleteProduct();
            if (!string.IsNullOrEmpty(id))
            {
                InstructionID = id;
                LoadEdit(id);
            }
            printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
        }
        private Instruction o;
        private void LoadEdit(string id)
        {
            InstructionID = id;
            o = new Instruction();//.Select(UsersID);
            o = Instruction.Select(id);

            CustomerID = o.CustomerID;
            customerCbx.Text = CustomerDictionary.First(e => e.Value == o.CustomerID).Key;
            customerCbx_SelectedIndexChanged(null, null);

            UserID = o.UserID;
            userCbx.Text = UserDictionary.First(e => e.Value == o.UserID).Key;
            userCbx_SelectedIndexChanged(null, null);

            ItemID = o.ItemID;
            productCbx.Text = ProductDictionary.First(e => e.Value == o.ItemID).Key;
            productCbx_SelectedIndexChanged(null, null);
            appropriateCbx.Text = o.Appropriate;

            Dictionary<string, bool> safetyValues = JsonConvert.DeserializeObject<Dictionary<string, bool>>(o.Safety);
            safetyListBx.Items.Clear();
            foreach (var t in safetyValues)
            {
                safetyListBx.Items.Add(t.Key, t.Value);
            }

            Dictionary<string, bool> appropSelValues = JsonConvert.DeserializeObject<Dictionary<string, bool>>(o.AppropriateSelection);
            appropListBx.Items.Clear();
            foreach (var t in appropSelValues)
            {
                appropListBx.Items.Add(t.Key, t.Value);
            }
            safetyOtherTxt.Text = o.SafetyOther;
            phoneTxt.Text = o.Phone;

            Dictionary<string, bool> equipValues = JsonConvert.DeserializeObject<Dictionary<string, bool>>(o.EquipmentType);
            equipmentTypeListBox.Items.Clear();
            foreach (var t in equipValues)
            {
                equipmentTypeListBox.Items.Add(t.Key, t.Value);
            }
            Dictionary<string, bool> additionalValues = JsonConvert.DeserializeObject<Dictionary<string, bool>>(o.Additional);
            additionalListBx.Items.Clear();
            foreach (var t in additionalValues)
            {
                additionalListBx.Items.Add(t.Key, t.Value);
            }

            signatureTxt.Text = o.Signature;
            followUpCbx.Text = o.FollowUp;

            kinnameTxt.Text = o.KinName;
            kinContactTxt.Text = o.KinContact;
            kinAddressTxt.Text = o.KinAddress;
            reasonTxt.Text = o.Reason;
            userSignatureTxt.Text = o.UserSignature;
            UserID = o.UserID;


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
            foreach (var s in safetyListBx.CheckedItems)
            {
                SafetyDictionary.Add(s.ToString(), true);
            }
            foreach (var s in appropListBx.CheckedItems)
            {
                AppropriateDictionary.Add(s.ToString(), true);
            }
            foreach (var s in equipmentTypeListBox.CheckedItems)
            {
                EquipmentDictionary.Add(s.ToString(), true);
            }
            foreach (var s in additionalListBx.CheckedItems)
            {
                AdditionalDictionary.Add(s.ToString(), true);
            }

            var SafetyJson = JsonConvert.SerializeObject(SafetyDictionary);
            var AppropriateJson = JsonConvert.SerializeObject(AppropriateDictionary);
            var EquipmentJson = JsonConvert.SerializeObject(EquipmentDictionary);
            var AdditionalJson = JsonConvert.SerializeObject(AdditionalDictionary);
            string id = Guid.NewGuid().ToString();
            Instruction i = new Instruction(id, CustomerID, UserID, ItemID, clinicalDateTxt.Text, typeListBx.SelectedItem.ToString(), altContactTxt.Text, SafetyJson, appropriateCbx.Text, AppropriateJson, safetyOtherTxt.Text, phoneTxt.Text, EquipmentJson, equipOtherTxt.Text, AdditionalJson, additionNotesTxt.Text, followUpCbx.Text, signatureTxt.Text, kinnameTxt.Text, kinContactTxt.Text, kinAddressTxt.Text, reasonTxt.Text, userSignatureTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false);
            if (DBConnect.Insert(i) != "")
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

        }
        Users u;

        private void userCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UserID = UserDictionary[userCbx.Text];
                u = new Users();//.Select(ItemID);
                u = Users.Select(UserID);
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
                serialTxt.Text = i.Barcode;
                equipOtherTxt.Text = i.Category;
                typeTxt.Text = i.Type;
                
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

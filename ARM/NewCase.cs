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
    public partial class NewCase : MetroFramework.Forms.MetroForm
    {
        Dictionary<string, string> UserDictionary = new Dictionary<string, string>();
        Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
        Dictionary<string, string> PractitionerDictionary = new Dictionary<string, string>();
        Dictionary<string, string> ProductDictionary = new Dictionary<string, string>();

        Dictionary<string, bool> TypeDictionary = new Dictionary<string, bool>();
        Dictionary<string, bool> PlaceDictionary = new Dictionary<string, bool>();
       

        string CustomerID;
        string UserID;
        string PractitionerID;
        string CaseID;
        string CoverageID;
        public NewCase(string id)
        {
            InitializeComponent();
            AutoCompleteUser();
            AutoCompleteCustomer();
            
            if (!string.IsNullOrEmpty(id))
            {
                CaseID = id;
                LoadEdit(id);
            }
            else {

                CaseID = Guid.NewGuid().ToString();

            }
            GenericCollection.transactions = new List<Transaction>();
            printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
        }
        private Orders o;
        private void LoadEdit(string id)
        {
            CaseID = id;
            o = new Orders();//.Select(UsersID);
            o = Orders.Select(id);

            CustomerID = o.CustomerID;
            customerCbx.Text = CustomerDictionary.First(e => e.Value == o.CustomerID).Key;
            customerCbx_SelectedIndexChanged(null, null);

            UserID = o.UserID;
           // practitionerCbx.Text = UserDictionary.First(e => e.Value == o.UserID).Key;
            //userCbx_SelectedIndexChanged(null, null);

          
          //  productCbx.Text = ProductDictionary.First(e => e.Value == o.ItemID).Key;
           
           
            //limitTxt.Text = o.EquipmentLimits;
            //heightTxt.Text = o.EquipmentHeights;
            //weightTxt.Text = o.EquipmentWeights;
            //periodTxt.Text = o.EquipmentPeriod;
            //instructionTxt.Text = o.EquipmentInstructions;
            //otherTxt.Text = o.Other;
            // dateAuthTxt.Text = Convert.ToDateTime(o.AuthorizationDate).ToString();
            // dateNotifiedTxt.Text = Convert.ToDateTime(o.NotificationDate).ToString();
            Dictionary<string, bool> setUpValues = JsonConvert.DeserializeObject<Dictionary<string, bool>>(o.SetupLocation);
            //setupListBx.Items.Clear();
            //foreach (var t in setUpValues)
            //{
            //    setupListBx.Items.Add(t.Key,t.Value);
            //}

            //Dictionary<string, bool> actionValues = JsonConvert.DeserializeObject<Dictionary<string, bool>>(o.Action);
            //actionListBx.Items.Clear();
            //foreach (var t in actionValues)
            //{
            //    actionListBx.Items.Add(t.Key, t.Value);
            //}

            //Dictionary<string, bool> dischargeValues = JsonConvert.DeserializeObject<Dictionary<string, bool>>(o.DischargeLocation);
            //dischargeListBx.Items.Clear();
            //foreach (var t in dischargeValues)
            //{
            //    dischargeListBx.Items.Add(t.Key, t.Value);
            //}

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
            foreach (var s in typeListBx.CheckedItems)
            {
                TypeDictionary.Add(s.ToString(), true);
            }
            foreach (var s in placeListBx.CheckedItems)
            {
                PlaceDictionary.Add(s.ToString(), true);
            }
            
            var TypeJson = JsonConvert.SerializeObject(TypeDictionary);
            var PlaceJson = JsonConvert.SerializeObject(PlaceDictionary);            
          
            Case i = new Case(CaseID, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"),noTxt.Text,providerNoTxt.Text,CoverageID,CustomerID, UserID,practictionerTypeCbx.Text,roleTypeCbx.Text,TypeJson,PlaceJson,informationTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Convert.ToDateTime(reqStart.Text).ToString("dd-MM-yyyy"), Convert.ToDateTime(reqEnd.Text).ToString("dd-MM-yyyy"),Convert.ToDateTime(reqStart.Text).ToString("dd-MM-yyyy"), Convert.ToDateTime(reqEnd.Text).ToString("dd-MM-yyyy"), false, Helper.CompanyID);
            if (DBConnect.InsertPostgre(i) != "")
            {
                foreach (Transaction t in GenericCollection.transactions)
                {
                    Transaction c = new Transaction(t.Id, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), noTxt.Text, t.ItemID,CaseID,"",t.Qty, t.Cost,t.Units, t.Total,"","","","","","", t.Created, false, Helper.CompanyID);
                    if (DBConnect.InsertPostgre(c) != "")
                    {
                    }
                }
                foreach (ICD10 t in GenericCollection.icd10)
                {
                    ICD10 c = new ICD10(t.Id,CaseID,t.Code, t.Name,t.Created, false, Helper.CompanyID);
                    if (DBConnect.InsertPostgre(c) != "")
                    {
                    }
                }
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
                    practitionerCbx.Items.Add(v.Name);
                    
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
        private void AutoCompletePractitioner(string customerID)
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            CustomerDictionary.Clear();
            foreach (Practitioner c in Practitioner.List())
            {
                AutoItem.Add((c.Name));

                if (!PractitionerDictionary.ContainsKey(c.Name))
                {
                    PractitionerDictionary.Add(c.Name, c.Id);
                    practitionerCbx.Items.Add(c.Name);
                }
            }
        }
        Customer c;
        Coverage ins;
        private void customerCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CustomerID = CustomerDictionary[customerCbx.Text];
                c = new Customer();//.Select(ItemID);
                c = Customer.Select(CustomerID);
                subscriberInfoTxt.Text = "Name: " + c.Name + "\t DOB: " + c.Dob + " \r\n Address: " + c.Address + "\r\n City/state: " + c.City + " " + c.State + "\t Zip: " + c.Zip + " \r\n  Phone: " + c.Contact + "\t Soc.Sec.#: " + c.Ssn;
               
                System.Drawing.Image img = Helper.Base64ToImage(c.Image);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                cusPbx.Image = bmp;
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(cusPbx.DisplayRectangle);
                cusPbx.Region = new Region(gp);
                cusPbx.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch { }
            AutoCompletePractitioner(CustomerID);

        }
        Users u;

        private void userCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UserID = UserDictionary[practitionerCbx.Text];
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
        Product i;
        private void productCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //ItemID = ProductDictionary[productCbx.Text];
                i = new Product();//.Select(ItemID);
                i = Product.Select(ItemID);
                System.Drawing.Image img = Helper.Base64ToImage(i.Image);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
              //  productPbx.Image = bmp;
               // productPbx.SizeMode = PictureBoxSizeMode.StretchImage;
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

        private void button5_Click(object sender, EventArgs e)
        {
            using (CustomerDemo form = new CustomerDemo(null, "Patient"))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void actionListBx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void practictionerTypeCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (AddDiagnosis form = new AddDiagnosis(CaseID,CustomerID))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadDiagnosis();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (AddPurchase form = new AddPurchase(CaseID,"", Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadTransactions();
                }
            }
        }
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
         //   totalTxt.Text = Total.ToString("N0");

            dtGridEquip.DataSource = t;

            dtGridEquip.AllowUserToAddRows = false;
            // dtGrid.Columns["View"].DefaultCellStyle.BackColor = Color.LightGreen;
            //  dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;

            dtGridEquip.Columns["id"].Visible = false;
            dtGridEquip.Columns["ItemID"].Visible = false;
        }
        public void LoadDiagnosis()
        {
            // create and execute query  
            t = new DataTable();

            t.Columns.Add("id");
            t.Columns.Add("Code");
            t.Columns.Add("Name");            
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));

            Image delete = new Bitmap(Properties.Resources.Cancel_16);

            foreach (ICD10 j in GenericCollection.icd10)
            {
                try
                {
                  
                    t.Rows.Add(new object[] { j.Id, j.Code, j.Name, delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message + "Viewing users {each transaction list }" + j.Name);
                }
            }           

            dtGrid.DataSource = t;
            dtGrid.AllowUserToAddRows = false;
            // dtGrid.Columns["View"].DefaultCellStyle.BackColor = Color.LightGreen;
            //  dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;

            dtGrid.Columns["id"].Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (CoverageDialog form = new CoverageDialog(CustomerID))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            using (PractitionerDialog form = new PractitionerDialog(CustomerID, ""))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    AutoCompletePractitioner(CustomerID);

                }
            }
        }

        private void practitionerCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PractitionerID = PractitionerDictionary[practitionerCbx.Text];
                Practitioner c = new Practitioner();//.Select(ItemID);
                c = Practitioner.Select(PractitionerID);
                physicianTxt.Text = "Name: " + c.Name + "\t Speciality" + c.Speciality + " \r\n Address: " + c.Address + "\r\n City/state: " + c.City + " " + c.State + "\t Zip: " + c.Zip + " \r\n  Phone: " + c.Contact + "\t";

                System.Drawing.Image img = Helper.Base64ToImage(c.Image);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                userPbx.Image = bmp;
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(cusPbx.DisplayRectangle);
                userPbx.Region = new Region(gp);
                userPbx.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch { }
        }
    }
}

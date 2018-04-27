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
        Dictionary<string, string> kinDictionary = new Dictionary<string, string>();
        Dictionary<string, bool> SetupDictionary = new Dictionary<string, bool>();
        Dictionary<string, bool> DischargeDictionary = new Dictionary<string, bool>();
        Dictionary<string, bool> ActionDictionary = new Dictionary<string, bool>();

        string CustomerID;
        string UserID;
        string OrderID;
        string CaseID;
        string EmergencyID;
        string PractitionerID;
        public OrderIntakeForm(string id)
        {
            InitializeComponent();
            AutoCompleteUser();
            AutoCompleteCustomer();
            AutoCompleteEmergency();
            if (!string.IsNullOrEmpty(id))
            {               
                
                CaseID = id;
                try {

                    Orders o = Orders.Select(CaseID);
                    LoadEdit(CaseID);

                } catch {


                }
            }
            printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
        }
        private Orders o;
        private Case cs;
        private void LoadEdit(string id)
        {
            OrderID = id;            
            o = new Orders();//.Select(UsersID);
            o = Orders.Select(CaseID);

            CustomerID = o.CustomerID;
          

            UserID = o.UserID;
            userCbx.Text = UserDictionary.First(e => e.Value == o.UserID).Key;
            userCbx_SelectedIndexChanged(null, null);

                   

            recievedCbx.Text = o.OrderBy;
            dispensedCbx.Text = o.DispenseBy;
            dispenseDateTxt.Text = Convert.ToDateTime(o.DispenseDateTime).ToString();
            diagnosisTxt.Text = o.Diagnosis;
            surgeryTxt.Text = o.Surgery;
            //limitTxt.Text = o.EquipmentLimits;
            //heightTxt.Text = o.EquipmentHeights;
            //weightTxt.Text = o.EquipmentWeights;
            //periodTxt.Text = o.EquipmentPeriod;
            //instructionTxt.Text = o.EquipmentInstructions;
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

            try
            {
                //CustomerID = CustomerDictionary[customerCbx.Text];
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
            try
            {

                foreach (Coverage c in Coverage.Select(CustomerID))
                {
                    insuranceInfoTxt.Text = "" + c.Type + "\r\n" + "Name: " + c.Name + "\t ID# : " + c.No + " \r\n  " + " \r\n  Type: " + c.Type;
                }

            }
            catch { }

            try
            {
                PractitionerID = o.PractitionerID;
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
        Dictionary<string, bool> SafetyDictionary = new Dictionary<string, bool>();
        Dictionary<string, bool> AppropriateDictionary = new Dictionary<string, bool>();
        Dictionary<string, bool> EquipmentDictionary = new Dictionary<string, bool>();
        Dictionary<string, bool> AdditionalDictionary = new Dictionary<string, bool>();
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
            foreach (var s in setupListBx.CheckedItems)
            {
                SetupDictionary.Add(s.ToString(),true);               
            }           
            foreach (var s in dischargeListBx.CheckedItems)
            {
                DischargeDictionary.Add(s.ToString(),true);              
            }
            foreach (var s in actionListBx.CheckedItems)
            {
                ActionDictionary.Add(s.ToString(),true);               
            }
            string appropriate = "";
            appropriate = yesRadioBtn.Checked ? "Yes" : "No";
            appropriate = noRadioBtn.Checked ? "No" : "Yes";


            appropriate = "Yes";
          
            var DischargeJson = JsonConvert.SerializeObject(DischargeDictionary);
            var ActionJson = JsonConvert.SerializeObject(ActionDictionary);
            var SetupJson = JsonConvert.SerializeObject(SetupDictionary);
            string id = Guid.NewGuid().ToString();
            Orders i = new Orders(id,CaseID, CustomerID, UserID, ItemID, orderDateTxt.Text, recievedCbx.Text, dispenseDateTxt.Text, dispensedCbx.Text,"", diagnosisTxt.Text,surgeryTxt.Text, Convert.ToDateTime(clinicalDateTxt.Text).ToString("dd-MM-yyyy"),SetupJson,setupDate.Text,DischargeJson,dischargeDate.Text,"",dateNotifiedTxt.Text,"",dateAuthTxt.Text,ActionJson,otherTxt.Text,PractitionerID,SafetyJson,appropriate,AppropriateJson,SafetyJson,kinContactTxt.Text,EquipmentJson,otherTxt.Text,AdditionalJson, additionNotesTxt.Text,followUpCbx.Text,signatureTxt.Text,EmergencyID,reasonTxt.Text,userSignatureTxt.Text, false, Helper.CompanyID);
            if (DBConnect.InsertPostgre(i) != "")
            {

                
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
        private void AutoCompleteEmergency()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            kinDictionary.Clear();
            string Q = "SELECT * FROM emergency WHERE customerID = '"+CustomerID+"' ";
            foreach (Emergency v in Emergency.List(Q))
            {
                AutoItem.Add((v.Name));

                if (!kinDictionary.ContainsKey(v.Name))
                {
                    kinDictionary.Add(v.Name, v.Id);
                    kinCbx.Items.Add(v.Name);
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
                 
                }
            }
        }
        Customer c;
        Coverage ins;
        private void customerCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        Users u;

        private void userCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }
        string ItemID;
        Product i;
        private void productCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
            using (CustomerDemo form = new CustomerDemo(CustomerID, "Patient"))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (AddPurchase form = new AddPurchase(CaseID, "", Convert.ToDateTime(orderDateTxt.Text).ToString("dd-MM-yyyy"), null))
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
            t.Columns.Add("Limit");
            t.Columns.Add("Setting");
            t.Columns.Add("Period");
            t.Columns.Add("Height");
            t.Columns.Add("Weight");
            t.Columns.Add("Instruction");
           
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));

            Image delete = new Bitmap(Properties.Resources.Cancel_16);
            string Q = "SELECT * FROM Transaction WHERE caseID = '" + CaseID + "'";
            foreach (Transaction j in Transaction.List(Q))
            {
                try
                {
                    k = Product.Select(j.ItemID);
                    t.Rows.Add(new object[] { j.Id, j.ItemID, k.Name, j.Qty, j.Cost.ToString("N0"), j.Total.ToString("N0"),j.Limit,j.Setting,j.Period,j.Height,j.Weight,j.Instruction, delete });

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

        private void kinCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EmergencyID = kinDictionary[kinCbx.Text];
                Emergency   c = new Emergency();//.Select(ItemID);
                c = Emergency.Select(EmergencyID);
                emergencyDetails.Text = "Name: " + c.Name + "\t \r\n Address: " + c.Address + "\r\n City/state: " + c.City + " " + c.State + "\t Zip: " + c.Zip + " \r\n  Phone: " + c.Contact + "\t Relationship" + c.Relationship + "\t ";

            }
            catch { }
        }
    }
}

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
        Dictionary<string, string> CoverDictionary = new Dictionary<string, string>();

        Dictionary<string, bool> TypeDictionary = new Dictionary<string, bool>();
        Dictionary<string, bool> PlaceDictionary = new Dictionary<string, bool>();


        string CustomerID;
        string UserID;
        string PractitionerID;
        string CaseID;
        string coverageID = "";
        public NewCase(string id)
        {
            InitializeComponent();
            AutoCompleteUser();
            AutoCompleteCustomer();
            GenericCollection.transactions = new List<Transaction>();
            GenericCollection.icd10 = new List<ICD10>();

            if (!string.IsNullOrEmpty(id))
            {
                CaseID = id;
                LoadEdit(id);
            }
            else
            {

                CaseID = Guid.NewGuid().ToString();
                updateBtn.Visible = false;
            }


            printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
            try
            {
                noTxt.Text = (DBConnect.Max("SELECT MAX(CAST(no AS DOUBLE PRECISION)) FROM cases") + 1).ToString();
            }
            catch
            {
                noTxt.Text = " 1 ";
            }
        }
        private void AutoCompleteCoverage(string cusID)
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            CoverDictionary.Clear();
            string Q = "SELECT * FROM coverage WHERE customerID = '" + cusID + "' ";
            foreach (Coverage c in Coverage.List(Q))
            {
                AutoItem.Add((c.Name));

                if (!CoverDictionary.ContainsKey(c.Name))
                {
                    CoverDictionary.Add(c.Name, c.Id);
                    coverageCbx.Items.Add(c.Name);
                }
            }
            //productTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            //productTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //productTxt.AutoCompleteCustomSource = AutoItem;

        }
        private Orders o;
        private void LoadEdit(string id)
        {
            btnSubmit.Visible = false;
            CaseID = id;
            Cases o = new Cases();//.Select(UsersID);
            o = Cases.Select(id);

            CustomerID = o.CustomerID;
            customerCbx.Text = CustomerDictionary.First(e => e.Value == o.CustomerID).Key;
            customerCbx_SelectedIndexChanged(null, null);

            practitionerCbx.Text = PractitionerDictionary.First(e => e.Value == o.PractitionerID).Key;
            practitionerCbx_SelectedIndexChanged(null, null);
            reqStart.Text = Convert.ToDateTime(o.ReqStart).ToString();
            practictionerTypeCbx.Text = o.PractitionerType;
            reqEnd.Text = Convert.ToDateTime(o.ReqEnd).ToString();
            roleTypeCbx.Text = o.RoleType;
            providerNoTxt.Text = o.ProvideNo;
            informationTxt.Text = o.Information;
            try
            {
                coverageCbx.Text = CoverDictionary.First(e => e.Value == o.CoverageID).Key;
            }
            catch (Exception r)
            {

                Helper.Exceptions(r.Message, "edit case loading Coverage Cbx" + r.Message);

            }
            coverageID = o.CoverageID;
            coverageCbx_SelectedIndexChanged(null, null);

            Dictionary<string, bool> typeValues = JsonConvert.DeserializeObject<Dictionary<string, bool>>(o.Type);
            string type = "";
            typeListBx.Items.Clear();
            foreach (var t in typeValues)
            {
                typeListBx.Items.Add(t.Key, t.Value);
            }

            Dictionary<string, bool> placeValues = JsonConvert.DeserializeObject<Dictionary<string, bool>>(o.Place);
            placeListBx.Items.Clear();
            foreach (var t in placeValues)
            {
                placeListBx.Items.Add(t.Key, t.Value);
            }


            string Q = "SELECT * FROM ICD10 WHERE caseID = '" + o.Id + "' ";
            GenericCollection.icd10 = ICD10.List(Q);
            string Q2 = "SELECT * FROM caseTransaction WHERE caseID = '" + o.Id + "' ";

            foreach (CaseTransaction j in CaseTransaction.List(Q2))
            {
                Transaction t = new Transaction(j.Id, j.Date, j.No, j.ItemID, j.CaseID, "", Convert.ToDouble(j.Qty), Convert.ToDouble(j.Cost), j.Units, j.Total, j.Tax, j.Coverage, j.Self, j.Payable, j.Limits, j.Setting, j.Period, j.Height, j.Weight, j.Instruction, j.Created, j.Sync, Helper.CompanyID);
                GenericCollection.transactions.Add(t);
            }

            LoadDiagnosis();
            LoadTransactions();
        }
        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("YES or No?", "Confirm submission ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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

                Cases i = new Cases(CaseID, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), noTxt.Text, providerNoTxt.Text, coverageID, CustomerID, PractitionerID, practictionerTypeCbx.Text, roleTypeCbx.Text, TypeJson, PlaceJson, informationTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Convert.ToDateTime(reqStart.Text).ToString("dd-MM-yyyy"), Convert.ToDateTime(reqEnd.Text).ToString("dd-MM-yyyy"), Convert.ToDateTime(reqStart.Text).ToString("dd-MM-yyyy"), Convert.ToDateTime(reqEnd.Text).ToString("dd-MM-yyyy"), false, Helper.CompanyID);
                if (DBConnect.InsertPostgre(i) != "")
                {
                    foreach (Transaction t in GenericCollection.transactions)
                    {
                        CaseTransaction c = new CaseTransaction(t.Id, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), noTxt.Text, t.ItemID, CaseID, "", t.Qty, t.Cost, t.Units, t.Total, t.Tax, t.Coverage, t.Self, t.Payable, t.Limits, t.Setting, t.Period, t.Height, t.Weight, t.Instruction, t.Created, false, Helper.CompanyID);
                        if (DBConnect.InsertPostgre(c) != "")
                        {
                            Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.InsertPostgre(c)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                            DBConnect.InsertPostgre(q);
                        }
                    }
                    foreach (ICD10 t in GenericCollection.icd10)
                    {
                        ICD10 c = new ICD10(t.Id, CaseID, t.Code, t.Name, t.Created, false, Helper.CompanyID);
                        if (DBConnect.InsertPostgre(c) != "")
                        {

                            Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.InsertPostgre(c)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                            DBConnect.InsertPostgre(q);
                        }
                    }
                    // ItemCoverage t = new ItemCoverage(id,TransID,ItemID,CoverID,Convert.ToDouble(percTxt.Text), Convert.ToDouble(amountTxt.Text),DateTime.Now.ToString("dd-MM-yyyy H:m:s"),false,Helper.CompanyID);


                    foreach (ItemCoverage t in GenericCollection.itemCoverage)
                    {

                    }
                    MessageBox.Show("Information Saved");
                    this.Close();
                }
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
                    // practitionerCbx.Items.Add(v.Name);

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
            PractitionerDictionary.Clear();
            string Q = "SELECT * FROM practitioner WHERE customerID = '" + CustomerID + "'";
            foreach (Practitioner c in Practitioner.List(Q))
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
                subscriberInfoTxt.Text = "Name: " + c.Name + "\t DOB: " + c.Dob + " \r\n Address: " + c.Address + "\r\n City/state: " + c.City + " " + c.State + "\t Zip: " + c.Zip + " \r\n  Phone: " + c.Contact + "\t Soc.Sec.#: " + c.Ssn + "\t Gender: " + c.Gender;

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
            AutoCompleteCoverage(CustomerID);


        }
        Users u;

        string ItemID;
        Product i;

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
                    AutoCompleteCustomer();
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
            using (AddDiagnosis form = new AddDiagnosis(CaseID, CustomerID))
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
            using (AddPurchase form = new AddPurchase(CaseID, noTxt.Text, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), CustomerID))
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
            using (InsuranceDialog form = new InsuranceDialog(CustomerID))
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

        private void coverageCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                coverageID = CoverDictionary[coverageCbx.Text];

            }
            catch { }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("YES or No?", "Are you sure you want to Update this Information? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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

                Cases i = new Cases(CaseID, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), noTxt.Text, providerNoTxt.Text, coverageID, CustomerID, PractitionerID, practictionerTypeCbx.Text, roleTypeCbx.Text, TypeJson, PlaceJson, informationTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Convert.ToDateTime(reqStart.Text).ToString("dd-MM-yyyy"), Convert.ToDateTime(reqEnd.Text).ToString("dd-MM-yyyy"), Convert.ToDateTime(reqStart.Text).ToString("dd-MM-yyyy"), Convert.ToDateTime(reqEnd.Text).ToString("dd-MM-yyyy"), false, Helper.CompanyID);
                DBConnect.UpdatePostgre(i, CaseID);
                if (MessageBox.Show("YES or NO?", "Would you like to add these products to your case list ?  ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from caseTransaction WHERE caseID ='" + CaseID + "'";
                    DBConnect.QueryPostgre(Query);
                    Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                    DBConnect.InsertPostgre(q);
                    foreach (Transaction t in GenericCollection.transactions)
                    {
                        CaseTransaction c = new CaseTransaction(t.Id, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), noTxt.Text, t.ItemID, CaseID, "", t.Qty, t.Cost, t.Units, t.Total, t.Tax, t.Coverage, t.Self, t.Payable, t.Limits, t.Setting, t.Period, t.Height, t.Weight, t.Instruction, t.Created, false, Helper.CompanyID);

                        DBConnect.UpdatePostgre(c, t.Id);
                        Queries qh = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.UpdatePostgre(c, t.Id)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                        DBConnect.InsertPostgre(qh);
                    }
                }
                if (MessageBox.Show("YES or NO?", "Would you like to add these products to your case list ?  ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from icd10 WHERE caseID ='" + CaseID + "'";
                    DBConnect.QueryPostgre(Query);
                    Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                    DBConnect.InsertPostgre(q);
                    foreach (ICD10 t in GenericCollection.icd10)
                    {
                        ICD10 c = new ICD10(t.Id, CaseID, t.Code, t.Name, t.Created, false, Helper.CompanyID);
                        DBConnect.UpdatePostgre(c, t.Id);
                        Queries qy = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.UpdatePostgre(c, t.Id)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                        DBConnect.InsertPostgre(qy);
                    }
                }

                // foreach (ItemCoverage t in GenericCollection.itemCoverage)
                // {

                // }
                MessageBox.Show("Information Saved");
                this.Close();

            }
        }
    }
}

using ARM.DB;
using ARM.Model;
using ARM.Util;
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
    public partial class DeliveryPickupForm : MetroFramework.Forms.MetroForm
    {
        string ID;
        string No;
        string CaseID;
        string CustomerID;
        string PractitionerID;

        public DeliveryPickupForm(string id, string no)
        {
            InitializeComponent();
            AutoCompleteUser();

            if (!string.IsNullOrEmpty(id))
            {
                ID = id;
                LoadDelivery(id);

            }
            if (!string.IsNullOrEmpty(no))
            {

                LoadOrder(no);
            }
            else
            {

            }

            printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);          
            addressLbl.Text = Helper.CompanyAddress;
            faxLbl.Text = Helper.CompanyFax;
            telLbl.Text = Helper.CompanyContact;

        }
        private void LoadOrder(string no)
        {
            updateBtn.Visible = false;
            Orders o;
            GenericCollection.transactions = new List<Transaction>();
            No = no;
		    noTxt.Text = no;			
			o = new Orders();//.Select(UsersID);
            o = Orders.SelectNo(no);
            CustomerID = o.CustomerID;
            PractitionerID = o.PractitionerID;
            No = o.No;
            UserID = o.UserID;
            userCbx.Text = UserDictionary.First(e => e.Value == o.UserID).Key; 

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
            string Q = "SELECT * FROM casetransaction WHERE caseID = '" + noTxt.Text + "'";
            foreach (CaseTransaction j in CaseTransaction.List(Q))
            {
                //try
                //{

                Transaction t = new Transaction(j.Id, j.Date, j.No, j.ItemID, j.CaseID, j.DeliveryID, j.Qty, j.Cost, j.Units, j.Total, j.Tax, j.Coverage, j.Self, j.Payable, j.Limits, j.Setting, j.Period, j.Height, j.Weight, j.Instruction, j.Created, false, Helper.CompanyID);
                GenericCollection.transactions.Add(t);
                //}
                //catch { }

            }
            LoadTransactions();
        }


        private void LoadDelivery(string id)
        {
            btnSubmit.Visible = false;
            GenericCollection.transactions = new List<Transaction>();
            ID = id;
            Delivery o = new Delivery();//.Select(UsersID);
            o = Delivery.Select(id);

            CustomerID = o.CustomerID;
            PractitionerID = o.PractitionerID;

            string Q = "SELECT * FROM transaction WHERE no = '" + noTxt.Text + "'";
            GenericCollection.transactions = Transaction.List(Q);
            LoadTransactions();
            dateTxt.Text = o.Date;

            //type
            commentTxt.Text = o.Comments;
            userCbx.Text = o.DeliveredBy;
            dateDeliveredTxt.Text = o.DateReceived;
            recievedByTxt.Text = o.ReceivedBy;
            signatureTxt.Text = o.Signature;
            totalTxt.Text = o.Total.ToString("N0");
			reasonTxt.Text = o.Reason;
			if (o.Deliveries == "Yes") { deliveryChk.Checked = true; }
			if (o.Followup == "Yes") { followupChk.Checked = true; }
            if (o.Pickup == "Yes") { pickupChk.Checked = true; }
           
			LoadOrder(o.No);
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
        public void LoadTransactions()
        {
            // create and execute query  
            t = new DataTable();
            t.Columns.Add("id");
            t.Columns.Add("Qty");
            t.Columns.Add("ItemID");
            t.Columns.Add("Product");
            t.Columns.Add("Cost");
            t.Columns.Add("Total");
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));
            Image delete = new Bitmap(Properties.Resources.Cancel_16);
            foreach (Transaction j in GenericCollection.transactions)
            {
                try
                {
                    k = Product.Select(j.ItemID);
                    t.Rows.Add(new object[] { j.Id, j.Qty, j.ItemID, k.Name, j.Cost.ToString("N0"), j.Total.ToString("N0"), delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message + "Viewing Items in Delivery form on load {each transaction list }" + j.ItemID);
                }
            }
            Total = GenericCollection.transactions.Sum(r => r.Total);
            totalTxt.Text = Total.ToString("N0");
            dtGrid.DataSource = t;
            //dtGrid.AllowUserToAddRows = false;
            //dtGrid.Columns["View"].DefaultCellStyle.BackColor = Color.LightGreen;
            //dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;

            dtGrid.Columns["id"].Visible = false;
            dtGrid.Columns["ItemID"].Visible = false;
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
        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        List<Users> users = new List<Users>();
        Product k = new Product();
        DataTable t = new DataTable();
        double Total = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
        Customer c;
        Users u;
        Coverage ins;

        string UserID;

        Dictionary<string, string> UserDictionary = new Dictionary<string, string>();
        Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
        Dictionary<string, string> ProductDictionary = new Dictionary<string, string>();

        private void userCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                UserID = UserDictionary[userCbx.Text];

            }
            catch { }
        }

        private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void totalTxt_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserID))
            {

                MessageBox.Show("Please select the user ");
                return;

            }
			string type = "";

			string deliver = deliveryChk.Checked ? "Yes" : "No";
			string followup = followupChk.Checked ? "Yes" : "No";
			string pickup = pickupChk.Checked ? "Yes" : "No";
			 if( deliveryChk.Checked) type = "Delivery" ;
			if (followupChk.Checked) type = "Follow up";
			if (pickupChk.Checked) type = "Pickup";
			

			double tax = GenericCollection.transactions.Sum(x => x.Tax);
            double amount = GenericCollection.transactions.Sum(x => x.Payable);
            string method = "Invoice";
            int ItemCount = GenericCollection.transactions.Count();

            string ids = Guid.NewGuid().ToString();
            Invoice iw = new Invoice(ids, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), noTxt.Text, "Credit", "Sale", Helper.CompanyName, CustomerID, method, amount, noTxt.Text, tax, amount, amount, amount, ItemCount, userCbx.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID);

            string save = DBConnect.InsertPostgre(iw);
            if ( save!= "")
            {
                Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                DBConnect.InsertPostgre(q);
            }
            Dictionary<string, string> transDic = new Dictionary<string, string>();
            string id = Guid.NewGuid().ToString();
            Delivery i = new Delivery(id, noTxt.Text, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"),deliver,followup,pickup, type, PractitionerID, CustomerID, commentTxt.Text, userCbx.Text, Convert.ToDateTime(dateDeliveredTxt.Text).ToString("dd-MM-yyyy"), recievedByTxt.Text, signatureTxt.Text, reasonTxt.Text, recievedByTxt.Text, Convert.ToDouble(totalTxt.Text), DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID);

            string savef = DBConnect.InsertPostgre(i);
            if ( savef!= "")
            {
                save = DBConnect.InsertPostgre(i);
                Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(savef), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                DBConnect.InsertPostgre(q);
                foreach (Transaction t in GenericCollection.transactions)
                {
                    string it = Guid.NewGuid().ToString();
                    if (!transDic.ContainsKey(it))
                    {
                        transDic.Add(it, t.Date);
                        Transaction c = new Transaction(it, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), noTxt.Text, t.ItemID, CaseID, id, t.Qty, t.Cost, t.Units, t.Total, t.Tax, t.Coverage, t.Self, t.Payable, t.Limits, t.Setting, t.Period, t.Height, t.Weight, t.Instruction, t.Created, false, Helper.CompanyID);
                       
                        save = DBConnect.InsertPostgre(c);
                        Queries qe = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.InsertPostgre(save)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                        DBConnect.InsertPostgre(qe);

                    }

                }

                MessageBox.Show("Information Saved");
                this.Close();
            }
        }

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
                {

                    if (MessageBox.Show("YES or No?", "Are you sure you want to remove this product ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                      
                        var itemToRemove = GenericCollection.transactions.Single(r => r.ItemID == dtGrid.Rows[e.RowIndex].Cells["ItemID"].Value.ToString());
                        GenericCollection.transactions.Remove(itemToRemove);
                        LoadTransactions();

                    }
                }

            }
            catch { }
        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
			// Print(panel1);
			DeliveryReport form = new DeliveryReport(noTxt.Text);//Print(panel1);
			form.Show();
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

        private void button7_Click(object sender, EventArgs e)
        {
            using (AddPurchase form = new AddPurchase(CaseID, "", Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadTransactions();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("YES or No?", "Confirm Transaction ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                GenerateInvoice();
            }
        }
        private void GenerateInvoice()
        {


            foreach (Transaction t in GenericCollection.transactions)
            {
                string ids = Guid.NewGuid().ToString();
                Transaction c = new Transaction(ids, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), noTxt.Text, t.ItemID, CaseID, t.DeliveryID, t.Qty, t.Cost, t.Units, t.Total, t.Tax, t.Coverage, t.Self, t.Payable, t.Limits, t.Setting, t.Period, t.Height, t.Weight, t.Instruction, t.Created, false, Helper.CompanyID);
                if (DBConnect.InsertPostgre(c) != "")
                {
                }
            }
            //string Pid = Guid.NewGuid().ToString();
            //Payment p = new Payment(Pid, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), noTxt.Text, typeCbx.Text, methodCbx.Text, Convert.ToDouble(amountTxt.Text), Convert.ToDouble(balanceTxt.Text), DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID);
            //DBConnect.InsertPostgre(p);


            using (ReceiptForm form = new ReceiptForm(noTxt.Text))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //  LoadData();
                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            using (ReceiptForm form = new ReceiptForm(noTxt.Text))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //  LoadData();
                }
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string type = "";
            string save = "";


			string deliver = deliveryChk.Checked ? "Yes" : "No";
			string followup = followupChk.Checked ? "Yes" : "No";
			string pickup = pickupChk.Checked ? "Yes" : "No";
			if (deliveryChk.Checked) type = "Delivery";
			if (followupChk.Checked) type = "Follow up";
			if (pickupChk.Checked) type = "Pickup";

			double tax = GenericCollection.transactions.Sum(x => x.Tax);
            double amount = GenericCollection.transactions.Sum(x => x.Payable);
            string method = "Invoice";
            int ItemCount = GenericCollection.transactions.Count();

            if (MessageBox.Show("YES or NO?", "Would you like to generate a new invoice based on this information?  ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string Query = "DELETE from invoice WHERE no ='" + noTxt.Text + "'";
                DBConnect.QueryPostgre(Query);
                Queries qe = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                DBConnect.InsertPostgre(qe);

                string ids = Guid.NewGuid().ToString();
                Invoice iw = new Invoice(ids, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), noTxt.Text, "Credit", "Sale", Helper.CompanyName, CustomerID, method, amount, noTxt.Text, tax, amount, amount, amount, ItemCount, userCbx.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID);
                 save = DBConnect.InsertPostgre(iw);               

                Queries qq = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                DBConnect.InsertPostgre(qq);
            }

            Dictionary<string, string> transDic = new Dictionary<string, string>();

            Delivery i = new Delivery(ID, noTxt.Text, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), deliver, followup, pickup, type, PractitionerID, CustomerID, commentTxt.Text, userCbx.Text, Convert.ToDateTime(dateDeliveredTxt.Text).ToString("dd-MM-yyyy"), recievedByTxt.Text, signatureTxt.Text, reasonTxt.Text, recievedByTxt.Text, Convert.ToDouble(totalTxt.Text), DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID);

			save = DBConnect.UpdatePostgre(i, ID);
            Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
            DBConnect.InsertPostgre(q);
            if (MessageBox.Show("YES or NO?", "Would you like to add these products to your invoice ?  ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string Query = "DELETE from transaction WHERE no ='" + noTxt.Text + "'";               
                DBConnect.QueryPostgre(Query);

                Queries qs = new Queries(Guid.NewGuid().ToString(), Helper.UserName,Helper.CleanString(Query), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                DBConnect.InsertPostgre(qs);
                foreach (Transaction t in GenericCollection.transactions)
                {
                    string it = Guid.NewGuid().ToString();
                    if (!transDic.ContainsKey(it))
                    {
                        transDic.Add(it, t.Date);

                        Transaction c = new Transaction(it, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), noTxt.Text, t.ItemID, noTxt.Text,ID, t.Qty, t.Cost, t.Units, t.Total, t.Tax, t.Coverage, t.Self, t.Payable, t.Limits, t.Setting, t.Period, t.Height, t.Weight, t.Instruction, t.Created, false, Helper.CompanyID);
                        save = DBConnect.InsertPostgre(c);

                        Queries qp = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                        DBConnect.InsertPostgre(qp);

                    }
                }
            }

            MessageBox.Show("Information Saved");
            this.Close();

        }
    }
}

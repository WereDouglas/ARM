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
        string DeliveryID;
        string OrderID;
        string CaseID;
        string CustomerID;
        string PractitionerID;
        private Orders o;
        public DeliveryPickupForm(string orderID, string deliveryID)
        {
            InitializeComponent();
            AutoCompleteUser();

            if (!string.IsNullOrEmpty(deliveryID))
            {
                DeliveryID = deliveryID;
                LoadDelivery(deliveryID);
            }
            LoadOrder(orderID);
            printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
        }
        private void LoadOrder(string id)
        {
            OrderID = id;
            o = new Orders();//.Select(UsersID);
            o = Orders.Select(OrderID);

            CustomerID = o.CustomerID;
            PractitionerID = o.PractitionerID;
            CaseID = o.CaseID;

            UserID = o.UserID;
            userCbx.Text = UserDictionary.First(e => e.Value == o.UserID).Key;
            userCbx_SelectedIndexChanged(null, null);


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
            string Q = "SELECT * FROM Transaction WHERE caseID = '" + CaseID + "'";
            GenericCollection.transactions = Transaction.List(Q);
            LoadTransactions();
        }


        private void LoadDelivery(string id)
        {
            DeliveryID = id;
            Delivery o = new Delivery();//.Select(UsersID);
            o = Delivery.Select(id);

            CustomerID = o.CustomerID;
            PractitionerID = o.PractitionerID;

            string Q = "SELECT * FROM Transaction WHERE deliveryID = '" + DeliveryID + "'";
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


            foreach (Transaction j in GenericCollection.transactions)
            {
                try
                {
                    k = Product.Select(j.ItemID);
                    t.Rows.Add(new object[] { j.Id, j.Qty, j.ItemID, k.Name, j.Cost.ToString("N0"), j.Total.ToString("N0") });

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
            // dtGrid.Columns["View"].DefaultCellStyle.BackColor = Color.LightGreen;
            //  dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;

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

        private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void totalTxt_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string type = "";

             type = (deliveryBtn.Checked) ? deliveryBtn.Text :pickupBtn.Text;
            type = (pickupBtn.Checked) ? pickupBtn.Text : deliveryBtn.Text;
            type = (followBtn.Checked) ? followBtn.Text : deliveryBtn.Text;

            string id = Guid.NewGuid().ToString();
            Delivery i = new Delivery(id, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"),CaseID,OrderID, type, PractitionerID, CustomerID, commentTxt.Text, userCbx.Text, Convert.ToDateTime(dateDeliveredTxt.Text).ToString("dd-MM-yyyy"), recievedByTxt.Text, signatureTxt.Text,"",recievedByTxt.Text,Convert.ToDouble(totalTxt.Text), DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID);
            if (DBConnect.InsertPostgre(i) != "")
            {               
                    foreach (Transaction t in GenericCollection.transactions)
                    {
                        Transaction c = new Transaction(t.Id, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"),"", t.ItemID, CaseID, "", t.Qty, t.Cost, t.Units, t.Total, "", "", "", "", "", "", t.Created, false, Helper.CompanyID);
                        if (DBConnect.InsertPostgre(c) != "")
                        {
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
                        // GenericCollection.transactions.Remove(u=>u.dtGrid.Columns["itemID"].Index);
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
    }
}

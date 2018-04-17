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
    public partial class FollowForm : MetroFramework.Forms.MetroForm
    {
        public Dictionary<string, bool> status = new Dictionary<string, bool>();
        public Dictionary<string, bool> ItemReview = new Dictionary<string, bool>();
        string FollowID;
        public FollowForm(string id)
        {
            InitializeComponent();
            AutoCompleteUser();
            AutoCompleteCustomer();
            AutoCompleteProduct();
            Helper.ItemReview.Clear();
            Helper.PatientStatus.Clear();
            GenericCollection.patientStatus = new List<PatientStatus>();
            GenericCollection.itemReviews = new List<ItemReview>();
            GenericCollection.itemStatus = new List<ItemStatus>();
            FollowID = Guid.NewGuid().ToString();
            printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
            if (!string.IsNullOrEmpty(id))
            {
                FollowID = id;
                LoadEdit(id);
            }
        }
        private Follow o;
        private void LoadEdit(string id)
        {
            FollowID = id;
            o = new Follow();//.Select(UsersID);
            o = Follow.Select(id);

            CustomerID = o.CustomerID;
            customerCbx.Text = CustomerDictionary.First(e => e.Value == o.CustomerID).Key;
            customerCbx_SelectedIndexChanged(null, null);

            UserID = o.UserID;
            userCbx.Text = UserDictionary.First(e => e.Value == o.UserID).Key;
            userCbx_SelectedIndexChanged(null, null);

            ItemID = o.ItemID;
            productCbx.Text = ProductDictionary.First(e => e.Value == o.ItemID).Key;
            productCbx_SelectedIndexChanged(null, null);

            typePhoneChk.Checked = (o.Type == "Phone") ? true : false;
            typeVisitChk.Checked = (o.Type == "Visit") ? true : false;
            diagnosisTxt.Text = o.Diagnosis;
            hospitalTxt.Text = o.Hospitalisation;
            sourceTxt.Text = o.Source;
            foreach (ItemReview i in Model.ItemReview.List(o.Id))
            {
                ItemReview t = new ItemReview(id, i.FollowID, i.Title, i.Status, i.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false);
                GenericCollection.itemReviews.Add(t);
            }
            LoadItemReview();
            foreach (ItemStatus i in Model.ItemStatus.List(o.Id))
            {
                ItemStatus t = new ItemStatus(id, i.FollowID, i.Title, i.Status, i.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false);
                GenericCollection.itemStatus.Add(t);
            }
            LoadItemStatus();
          
            foreach (PatientStatus i in Model.PatientStatus.List(o.Id))
            {
                PatientStatus t = new PatientStatus(id, i.FollowID, i.Title, i.Status, i.Details, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false);
                GenericCollection.patientStatus.Add(t);
            }
            LoadPatientStatus();
            lengthTxt.Text = o.Length;
            needTxt.Text = o.Need;
            goalTxt.Text = o.Goal;
            resultTxt.Text = o.Results;

            visitChk.Checked = (o.FollowVisit=="Yes") ? true : false;
            phoneChk.Checked = (o.FollowPhone =="Yes") ? true : false;
            nextTxt.Text = o.Next;
            puTxt.Text = o.Pu;
            authoriserTxt.Text = o.Authoriser;
            employeeTxt.Text = o.Signature;
            reasonTxt.Text = o.Reason;
            authSignatureTxt.Text = o.Authoriser;
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

        DataTable t = new DataTable();
        public void LoadItemReview()
        {
            // create and execute query  
            t = new DataTable();

            t.Columns.Add("id");
            t.Columns.Add("Title");
            t.Columns.Add("Status");
            t.Columns.Add("Details");

            t.Columns.Add(new DataColumn("Delete", typeof(Image)));
            Image delete = new Bitmap(Properties.Resources.Cancel_16);

            foreach (ItemReview j in GenericCollection.itemReviews)
            {
                try
                {

                    t.Rows.Add(new object[] { j.Id, j.Title, j.Status, j.Details, delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show(" " + m.Message);
                    Helper.Exceptions(m.Message + "Viewing itemReviews {each item Review list }" + j.Title);
                }
            }
            dtGridReview.DataSource = t;
            dtGridReview.AllowUserToAddRows = false;
            dtGridReview.Columns["id"].Visible = false;
        }
        public void LoadPatientStatus()
        {
            // create and execute query  
            t = new DataTable();

            t.Columns.Add("id");
            t.Columns.Add("Title");
            t.Columns.Add("Status");
            t.Columns.Add("Details");

            t.Columns.Add(new DataColumn("Delete", typeof(Image)));
            Image delete = new Bitmap(Properties.Resources.Cancel_16);

            foreach (PatientStatus j in GenericCollection.patientStatus)
            {
                try
                {
                    t.Rows.Add(new object[] { j.Id, j.Title, j.Status, j.Details, delete });
                }
                catch (Exception m)
                {
                    MessageBox.Show(" " + m.Message);
                    Helper.Exceptions(m.Message + "Viewing Patient Status {each item Review list }" + j.Title);
                }
            }
            dtGridPatientStatus.DataSource = t;
            dtGridPatientStatus.AllowUserToAddRows = false;
            dtGridPatientStatus.Columns["id"].Visible = false;
        }
        public void LoadItemStatus()
        {
            // create and execute query  
            t = new DataTable();

            t.Columns.Add("id");
            t.Columns.Add("Title");
            t.Columns.Add("Status");
            t.Columns.Add("Details");

            t.Columns.Add(new DataColumn("Delete", typeof(Image)));
            Image delete = new Bitmap(Properties.Resources.Cancel_16);

            foreach (ItemStatus j in GenericCollection.itemStatus)
            {
                try
                {
                    t.Rows.Add(new object[] { j.Id, j.Title, j.Status, j.Details, delete });
                }
                catch (Exception m)
                {
                    MessageBox.Show(" " + m.Message);
                    Helper.Exceptions(m.Message + "Viewing Item Status {each item Review list }" + j.Title);
                }
            }
            dtGridItemStatus.DataSource = t;
            dtGridItemStatus.AllowUserToAddRows = false;
            dtGridItemStatus.Columns["id"].Visible = false;
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            using (AddItemReview form = new AddItemReview("ItemReview", FollowID))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {

                    LoadItemReview();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (AddItemReview form = new AddItemReview("PatientStatus", FollowID))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadPatientStatus();


                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (AddItemReview form = new AddItemReview("ItemSetting", FollowID))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadItemStatus();
                }
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtGridReview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == dtGridReview.Columns["Delete"].Index && e.RowIndex >= 0)
                {

                    if (MessageBox.Show("YES or No?", "Are you sure you want to remove this review ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        var itemToRemove = GenericCollection.itemReviews.Single(r => r.Id == dtGridReview.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                        GenericCollection.itemReviews.Remove(itemToRemove);
                        LoadItemReview();

                    }
                }

            }
            catch { }
        }

        private void dtGridPatientStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == dtGridPatientStatus.Columns["Delete"].Index && e.RowIndex >= 0)
                {

                    if (MessageBox.Show("YES or No?", "Are you sure you want to remove this status ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        var itemToRemove = GenericCollection.patientStatus.Single(r => r.Id == dtGridPatientStatus.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                        GenericCollection.patientStatus.Remove(itemToRemove);
                        LoadPatientStatus();

                    }
                }

            }
            catch { }
        }

        private void dtGridItemStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dtGridItemStatus.Columns["Delete"].Index && e.RowIndex >= 0)
                {

                    if (MessageBox.Show("YES or No?", "Are you sure you want to remove this item status ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        var itemToRemove = GenericCollection.itemStatus.Single(r => r.Id == dtGridItemStatus.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                        GenericCollection.itemStatus.Remove(itemToRemove);
                        LoadItemStatus();

                    }
                }

            }
            catch { }
        }
        Customer c;
        Users u;
        Insurance ins;
        string CustomerID;
        string UserID;
        string OrderID;
        Dictionary<string, string> UserDictionary = new Dictionary<string, string>();
        Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
        Dictionary<string, string> ProductDictionary = new Dictionary<string, string>();
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
                serialTxt.Text = i.Barcode;
                equipOtherTxt.Text = i.Category;
                typeTxt.Text = i.Type;

            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string type = "none";
            string followVisit = "none";
            string followPhone = "none";

            type = (typePhoneChk.Checked) ? "Phone" : "Visit";
            type = (typeVisitChk.Checked) ? "Visit" : "Phone";
            followVisit = (visitChk.Checked) ? "Yes" : "No";
            followPhone = (phoneChk.Checked) ? "Yes" : "No";

            string id = Guid.NewGuid().ToString();
            Follow i = new Follow(FollowID, CustomerID, UserID, ItemID, type, diagnosisTxt.Text, hospitalTxt.Text, sourceTxt.Text, lengthTxt.Text, needTxt.Text, goalTxt.Text, resultTxt.Text, "", followVisit, followPhone, nextTxt.Text, puTxt.Text, authSignatureTxt.Text, authoriserTxt.Text, relationTxt.Text, reasonTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false);
            if (DBConnect.Insert(i) != "")
            {
                foreach (ItemReview t in GenericCollection.itemReviews)
                {
                    ItemReview c = new ItemReview(t.Id, FollowID, t.Title, t.Status, t.Status, t.Created, false);
                    DBConnect.Insert(c);
                }
                foreach (ItemStatus t in GenericCollection.itemStatus)
                {
                    ItemStatus c = new ItemStatus(t.Id, FollowID, t.Title, t.Status, t.Status, t.Created, false);
                    DBConnect.Insert(c);
                }
                foreach (PatientStatus t in GenericCollection.patientStatus)
                {
                    PatientStatus c = new PatientStatus(t.Id, FollowID, t.Title, t.Status, t.Status, t.Created, false);
                    DBConnect.Insert(c);
                }
                MessageBox.Show("Information Saved");
                this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
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

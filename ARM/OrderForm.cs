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
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();

            LoadData();

        }
        List<Orders> invoices = new List<Orders>();

        DataTable t = new DataTable();
        public void LoadData()
        {
            // create and execute query  
            t = new DataTable();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("ID");
            t.Columns.Add("uriCus");
            t.Columns.Add(new DataColumn("ImgCus", typeof(Bitmap)));//1  
            t.Columns.Add("Customer");
            t.Columns.Add("Physician");             
            t.Columns.Add("Date & Time");
            t.Columns.Add("By");
            t.Columns.Add("Dispensed On");
            t.Columns.Add("Dispensed By");
            t.Columns.Add("Category");
            t.Columns.Add("Diagnosis");
            t.Columns.Add("Surgery");
            t.Columns.Add("Clinical Date");           
            t.Columns.Add("Setup Location");
            t.Columns.Add("Setup Date");
            t.Columns.Add("Discharge location");
            t.Columns.Add("Discharge Date");
            t.Columns.Add("Notification");
            t.Columns.Add("Notification Date");
            t.Columns.Add("Authorization");
            t.Columns.Add("Authorization Date");
            t.Columns.Add("Created");
            t.Columns.Add("Sync");           
            t.Columns.Add("Action");
            t.Columns.Add("Other");          
            t.Columns.Add("New delivery");
            t.Columns.Add(new DataColumn("View", typeof(Image)));
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));

            Image view = new Bitmap(Properties.Resources.Note_Memo_16);
            Image delete = new Bitmap(Properties.Resources.Server_Delete_16);

            Bitmap b = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawString("Loading...", this.Font, new SolidBrush(Color.Black), 0f, 0f);
            }
            Bitmap b2 = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(b2))
            {
                g.DrawString("Loading...", this.Font, new SolidBrush(Color.Black), 0f, 0f);
            }

            foreach (Orders c in Orders.List())
            {
                string imageCus = "";
                string doctor = "";

                try { imageCus = Customer.Select(c.CustomerID).Image; } catch { }
                

               
                string cus = "";
               
                try { cus = Customer.Select(c.CustomerID).Name; } catch { }
                try { doctor = Practitioner.Select(c.PractitionerID).Name; } catch { }

                Dictionary<string, bool> placeValues = JsonConvert.DeserializeObject<Dictionary<string, bool>>(c.SetupLocation);
                string place = "";
                foreach (var t in placeValues)
                {
                    place = place + "\n" + t.Key + ":[" + t.Value + "]";
                }
                Dictionary<string, bool> typeValues = JsonConvert.DeserializeObject<Dictionary<string, bool>>(c.DischargeLocation);
                string type = "";
                foreach (var t in typeValues)
                {
                    type = type + "\n" + t.Key + ":[" + t.Value + "]";
                }

                Dictionary<string, bool> actionValues = JsonConvert.DeserializeObject<Dictionary<string, bool>>(c.Action);
                string action = "";
                foreach (var t in actionValues)
                {
                    action = action + "\n" + t.Key + ":[" + t.Value +"]";
                }

                try
                {
                    t.Rows.Add(new object[] { false, c.Id, imageCus as string, b, cus, doctor, c.OrderDateTime, c.OrderBy, c.DispenseDateTime, c.DispenseBy, c.CustomerType, c.Diagnosis, c.Surgery, c.ClinicalDate, place, c.SetupDate, type, c.DischargeDate, c.Notification, c.NotificationDate, c.Authoriz, c.AuthorizationDate, c.Created, c.Sync,action, c.Other,"New Delivery", view, delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message + "Viewing customer {each customer list } Setup date" + c.ClinicalDate);
                }
            }

            dtGrid.DataSource = t;
            ThreadPool.QueueUserWorkItem(delegate
            {
                foreach (DataRow row in t.Rows)
                {
                    try
                    {
                        Image img = Helper.Base64ToImageCropped(row["uriCus"].ToString().Replace('"', ' ').Trim());                       
                        row["ImgCus"] = img;
                    }
                    catch
                    {

                    }
                }
            });
            ThreadPool.QueueUserWorkItem(delegate
            {
                foreach (DataRow row in t.Rows)
                {
                    try
                    {

                        Image img = Helper.Base64ToImageCropped(row["uriPro"].ToString().Replace('"', ' ').Trim());                       
                        row["imgPro"] = img;
                    }
                    catch
                    {

                    }
                }
            });

            dtGrid.AllowUserToAddRows = false;
          //  dtGrid.Columns["Customer"].DefaultCellStyle.BackColor = Color.LightGreen;
            dtGrid.Columns["Physician"].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dtGrid.Columns["ID"].Visible = false;
          //  dtGrid.Columns["ImgCus"].DefaultCellStyle.BackColor = Color.LightGreen;
            dtGrid.Columns["uriCus"].Visible = false;

          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string filterField = "Name";
        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                t.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, searchTxt.Text);
            }
            catch (Exception c)
            {
                Helper.Exceptions(c.ToString() + "Searching users by selection");

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("YES or No?", "Are you sure you want to delete these invoices? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                foreach (var item in selectedIDs)
                {
                    string Query = "DELETE from orders WHERE id ='" + item + "'";
                    DBConnect.QueryPostgre(Query);
                    Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.InsertPostgre(Query)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                    DBConnect.InsertPostgre(q);
                    //  MessageBox.Show("Information deleted");
                }
            }
        }
        List<string> selectedIDs = new List<string>();
        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == dtGrid.Columns["Select"].Index && e.RowIndex >= 0)
            {
                if (selectedIDs.Contains(dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString()))
                {
                    selectedIDs.Remove(dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());

                }
                else
                {
                    selectedIDs.Add(dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                }
            }
            if (e.ColumnIndex == dtGrid.Columns["View"].Index && e.RowIndex >= 0)
            {
                using (OrderIntakeForm form = new OrderIntakeForm("",dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString()))
                {
                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            if (e.ColumnIndex == dtGrid.Columns["New delivery"].Index && e.RowIndex >= 0)
            {
                using (DeliveryPickupForm form = new DeliveryPickupForm(dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString(), ""))
                {
                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            try
            {

                if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
                {

                    if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Order? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string Query = "DELETE from orders WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString() + "'";
                        DBConnect.QueryPostgre(Query);
                        Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.InsertPostgre(Query)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                        DBConnect.InsertPostgre(q);
                        MessageBox.Show("Information deleted");
                        LoadData();

                    }

                }

            }
            catch { }
        }

        private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string Query = "UPDATE order SET sync ='false'";
            DBConnect.QueryPostgre(Query);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OrderIntakeForm o = new OrderIntakeForm("","");
            o.Show();
        }
    }
}

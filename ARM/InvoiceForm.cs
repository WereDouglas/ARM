﻿using ARM.DB;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
    public partial class InvoiceForm : Form
    {
        public InvoiceForm()
        {
            InitializeComponent();
            LoadData();
           // Test();

        }
        private void Test()
        {
            //Parent table
            DataTable dtstudent = new DataTable();
            // add column to datatable  
            dtstudent.Columns.Add("Student_ID", typeof(int));
            dtstudent.Columns.Add("Student_Name", typeof(string));
            dtstudent.Columns.Add("Student_RollNo", typeof(string));


            //Child table
            DataTable dtstudentMarks = new DataTable();
            dtstudentMarks.Columns.Add("Student_ID", typeof(int));
            dtstudentMarks.Columns.Add("Subject_ID", typeof(int));
            dtstudentMarks.Columns.Add("Subject_Name", typeof(string));
            dtstudentMarks.Columns.Add("Marks", typeof(int));



            //Adding Rows

            dtstudent.Rows.Add(111, "Devesh", "03021013014");
            dtstudent.Rows.Add(222, "ROLI", "0302101444");
            dtstudent.Rows.Add(333, "ROLI Ji", "030212222");
            dtstudent.Rows.Add(444, "NIKHIL", "KANPUR");

            // data for devesh ID=111
            dtstudentMarks.Rows.Add(111, "01", "Physics", 99);
            dtstudentMarks.Rows.Add(111, "02", "Maths", 77);
            dtstudentMarks.Rows.Add(111, "03", "C#", 100);
            dtstudentMarks.Rows.Add(111, "01", "Physics", 99);


            //data for ROLI ID=222
            dtstudentMarks.Rows.Add(222, "01", "Physics", 80);
            dtstudentMarks.Rows.Add(222, "02", "English", 95);
            dtstudentMarks.Rows.Add(222, "03", "Commerce", 95);
            dtstudentMarks.Rows.Add(222, "01", "BankPO", 99);



            DataSet dsDataset = new DataSet();
            //Add two DataTables  in Dataset

            dsDataset.Tables.Add(dtstudent);
            dsDataset.Tables.Add(dtstudentMarks);


            DataRelation Datatablerelation = new DataRelation("DetailsMarks", dsDataset.Tables[0].Columns[0], dsDataset.Tables[1].Columns[0],true);
            dsDataset.Relations.Add(Datatablerelation);
            dtGrid.DataSource = dsDataset.Tables[0];

        }
        List<Invoice> invoices = new List<Invoice>();

        DataTable t = new DataTable();
       
        public void LoadData()
        {

            // create and execute query  
            t = new DataTable();
           
            t.Columns.Add("No");
            t.Columns.Add(new DataColumn("Check", typeof(Image)));
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("ID");           
            t.Columns.Add("Date");
            t.Columns.Add("Type");
            t.Columns.Add("Category");
            t.Columns.Add("Vendor");
            t.Columns.Add("Customer");
            t.Columns.Add("Method");
            t.Columns.Add("Total");
            t.Columns.Add("Terms");
            t.Columns.Add("Tax");
            t.Columns.Add("Paid");
            t.Columns.Add("Balance");
            t.Columns.Add("By");
            t.Columns.Add("Qty");
            t.Columns.Add("Amount");
            t.Columns.Add("Sync");
            t.Columns.Add("Created");
            t.Columns.Add(new DataColumn("View", typeof(Image)));
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));

            Image view = new Bitmap(Properties.Resources.Note_Memo_16);
            Image delete = new Bitmap(Properties.Resources.Server_Delete_16);
            Image check = new Bitmap(Properties.Resources.Bill_16);

            foreach (Invoice c in Invoice.List())
            {
                string ven = "";
                string cus = "";
                try { ven = Vendor.Select(c.VendorID).Name; } catch { }
                try { cus = Customer.Select(c.CustomerID).Name; } catch { }
                try
                {
                    t.Rows.Add(new object[] { c.No, check, "false", c.Id,  c.Date, c.Type, c.Category, ven, cus, c.Method, c.Total.ToString("N0"), c.Terms, c.Tax.ToString("N0"), c.Paid.ToString("N0"), c.Balance.ToString("N0"), c.UserID, c.ItemCount, c.Amount.ToString("N0"), c.Sync, c.Created, view, delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message + "Viewing Invoice {each Invoice list }" + c.No);
                    Helper.Exceptions(m.Message ,"Viewing Invoice {each Invoice list }" + c.No);
                } 
            }
            DataTable trans = new DataTable();
            trans = new DataTable();
            trans.Columns.Add("No");
            trans.Columns.Add(new DataColumn("Select", typeof(bool)));
            trans.Columns.Add("ID");            
            trans.Columns.Add("Date");
            trans.Columns.Add("Product");
            trans.Columns.Add("Quantity");
            trans.Columns.Add("Cost");
            trans.Columns.Add("Total");
         
            trans.Columns.Add("Created");
            trans.Columns.Add(new DataColumn("Delete", typeof(Image)));
            foreach (Model.CaseTransaction c in Model.CaseTransaction.List())
            {
                string prod = "";
                try { prod = Product.Select(c.ItemID).Name; } catch { }
                try
                {
                    trans.Rows.Add(new object[] { c.No, "false", c.Id, c.Date, prod, c.Qty, c.Cost.ToString("N0"), c.Total.ToString("N0"),c.Created, delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message + "Viewing CaseTransaction {each CaseTransaction list }" + c.No);
                    Helper.Exceptions(m.Message , "Viewing Invoice form loading list {each CaseTransaction list }" + c.No);
                }
            }
            //DataSet dsDataset = new DataSet();
            //dsDataset.Tables.Add(t);
            //dsDataset.Tables.Add(trans);
            //DataRelation Datatablerelation = new DataRelation("No", dsDataset.Tables[0].Columns[0], dsDataset.Tables[1].Columns[0],"true",Helper.CompanyID);
            //dsDataset.Relations.Add(Datatablerelation);
            //dtGrid.DataSource = dsDataset.Tables[0];
            dtGrid.DataSource = t;

            dtGrid.AllowUserToAddRows = false;
            dtGrid.Columns["Paid"].DefaultCellStyle.BackColor = Color.LightGreen;
            dtGrid.Columns["Balance"].DefaultCellStyle.BackColor = Color.LightSalmon;
            dtGrid.Columns["ID"].Visible = false;
           // dataGrid1.DataSource = dsDataset.Tables[0];

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string filterField = "Date";
        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                t.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, searchTxt.Text);
            }
            catch (Exception c)
            {
                Helper.Exceptions(c.ToString() , "Invoice search filters ");

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
                    string Query = "DELETE from invoice WHERE id ='" + item + "'";
                    MySQL.Query(Query);
                    Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(MySQL.Insert(Query)), "false", DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                    MySQL.Insert(q);
					//  MessageBox.Show("Information deleted");
					Helper.Log(Helper.UserName, "Deleted invoice information " + item + "  " + DateTime.Now);
				}
            }
			LoadData();
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
                using (ReceiptForm form = new ReceiptForm(dtGrid.Rows[e.RowIndex].Cells["No"].Value.ToString()))
                {
                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        //  LoadData();
                    }
                }
            }
            if (e.ColumnIndex == dtGrid.Columns["Check"].Index && e.RowIndex >= 0)
            {
                using (ReceiptForm form = new ReceiptForm(dtGrid.Rows[e.RowIndex].Cells["No"].Value.ToString()))
                {
                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                      //  LoadData();
                    }
                }
            }
            try
            {

                if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Invoice? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string Query = "DELETE from invoice WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString() + "'";
                        MySQL.Query(Query);
                        Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(MySQL.Insert(Query)), "false", DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                        MySQL.Insert(q);
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = " Invoices.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                Helper.ToCsV(dtGrid, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            string Query = "UPDATE invoice SET sync ='false'";
            MySQL.Query(Query);
        }

		private void toolStripButton6_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in dtGrid.Rows)
			{
				row.Cells["select"].Value = true;
				if (!selectedIDs.Contains(row.Cells["id"].Value.ToString()))
				{
					selectedIDs.Add(row.Cells["id"].Value.ToString());
				}
			}

		}

		private void toolStripButton4_Click(object sender, EventArgs e)
		{

			List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
			foreach (DataGridViewRow row in dtGrid.Rows)
			{
				row.Cells["select"].Value = false;
				selectedIDs.Remove(row.Cells["id"].Value.ToString());
			}
		}
	}
}

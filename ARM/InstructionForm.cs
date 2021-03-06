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
    public partial class InstructionForm : Form
    {
        public InstructionForm()
        {
            InitializeComponent();
            LoadData();

        }
        List<Instruction> invoices = new List<Instruction>();

        DataTable t = new DataTable();
        public void LoadData()
        {
            // create and execute query  
            t = new DataTable();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("id");
            t.Columns.Add("uriCus");
            t.Columns.Add(new DataColumn("ImgCus", typeof(Bitmap)));//1  
            t.Columns.Add("Customer");            
            t.Columns.Add("No");
            t.Columns.Add("Alt Contact");			
			t.Columns.Add("Date & Time");			
			t.Columns.Add("Type");
			t.Columns.Add("Delivered");
			t.Columns.Add("Follow up visit recommended");
            t.Columns.Add("Follow up by phone as needed");
            t.Columns.Add("Patient signed");
			t.Columns.Add("Employee");
			t.Columns.Add("Employee signed");
            t.Columns.Add("Kin name");
            t.Columns.Add("Kin contact");                               
            t.Columns.Add("Created");
          
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

            foreach (Instruction c in Instruction.List())
            {
                string imageCus = "";  
                try { imageCus = Customer.Select(c.CustomerID).Image; } catch { }               
                string cus = "";
              
                try { cus = Customer.Select(c.CustomerID).Name; } catch { }
                try
                {
                    t.Rows.Add(new object[] { "false", c.Id, imageCus as string, b, cus,c.No,c.AltContact,c.Date,c.Type,c.Delivered,c.Visit,c.Phone,c.PatientSign,c.Employee,c.EmployeeSign,c.KinName,c.KinContact,c.Created,view, delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show("" + m.Message);
                    Helper.Exceptions(m.Message , "Viewing customer {each customer list } Setup date" + c.CustomerID);
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
            

            dtGrid.AllowUserToAddRows = false;
            dtGrid.Columns["Customer"].DefaultCellStyle.BackColor = Color.LightGreen;            
            dtGrid.Columns["id"].Visible = false;
            dtGrid.Columns["ImgCus"].DefaultCellStyle.BackColor = Color.LightGreen;
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
                Helper.Exceptions(c.Message , "Searching users by selection");

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("YES or No?", "Are you sure you want to delete these instructions? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                foreach (var item in selectedIDs)
                {
                    string Query = "DELETE from instruction WHERE id ='" + item + "'";
                    MySQL.Query(Query);
                    Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(MySQL.Insert(Query)), "false", DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                    MySQL.Insert(q);
					//  MessageBox.Show("Information deleted");
					Helper.Log(Helper.UserName, "Deleted DME instructions " + item + "  " + DateTime.Now);
				}
            }
        }
        List<string> selectedIDs = new List<string>();
        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == dtGrid.Columns["Select"].Index && e.RowIndex >= 0)
            {
				dtGrid.CurrentCell.Value = dtGrid.CurrentCell.FormattedValue.ToString() == "True" ? false : true;
				dtGrid.RefreshEdit();
				if (selectedIDs.Contains(dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString()))
				{
					selectedIDs.Remove(dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
				}
				else
				{
					selectedIDs.Add(dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
				}
			}
            if (e.ColumnIndex == dtGrid.Columns["View"].Index && e.RowIndex >= 0)
            {               
				InstructionReport form = new InstructionReport(dtGrid.Rows[e.RowIndex].Cells["no"].Value.ToString());
				form.Show();
			}
            try
            {
                if (e.ColumnIndex == dtGrid.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Instruction? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string Query = "DELETE from instruction WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
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

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string Query = "UPDATE instruction SET sync ='false'";
            MySQL.Query(Query);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
			InstructionDeliveryForm d = new InstructionDeliveryForm(null);
            d.Show();
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
		private void toolStripButton4_Click_1(object sender, EventArgs e)
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

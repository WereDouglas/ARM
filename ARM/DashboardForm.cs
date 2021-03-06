﻿using ARM.DB;
using ARM.Model;
using ARM.Util;
using Microsoft.Reporting.WinForms;
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
using System.Windows.Forms.Calendar;
using MySql.Data.MySqlClient;

namespace ARM
{
	public partial class DashboardForm : Form
	{
		private List<CalendarItem> _items = new List<CalendarItem>();
		public DashboardForm()
		{
			InitializeComponent();
			Report();

			//LoadData();
		}
		List<Product> items = new List<Product>();
		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		DataTable t = new DataTable();
		public void LoadData()
		{
			// create and execute query  
			t = new DataTable();
			t.Columns.Add("Name");
			t.Columns.Add("id");
			t.Columns.Add("uri");
			t.Columns.Add(new DataColumn("Img", typeof(Bitmap)));//1
			t.Columns.Add("No");
			t.Columns.Add("Contact");
			t.Columns.Add("Address");
			t.Columns.Add("City");
			t.Columns.Add("State");
			t.Columns.Add("Zip");


			Bitmap b = new Bitmap(50, 50);
			using (Graphics g = Graphics.FromImage(b))
			{
				g.DrawString("Loading...", this.Font, new SolidBrush(Color.Black), 0f, 0f);
			}

			foreach (Customer c in Customer.List())
			{
				try
				{
					t.Rows.Add(new object[] { c.Name, c.Id, c.Image as string, b, c.No, c.Contact, c.Address, c.City, c.State, c.Zip });

				}
				catch (Exception m)
				{
					MessageBox.Show("" + m.Message);
					Helper.Exceptions(m.Message, "Viewing customer {each customer list }" + c.Name);
				}
			}

			//dtGrid.DataSource = t;
			//dtGrid.Columns["uri"].Visible = false;
			//dtGrid.Columns["id"].Visible = false;
			//dtGrid.AllowUserToAddRows = false;			
			//dtGrid.RowTemplate.Height = 60;

			ThreadPool.QueueUserWorkItem(delegate
			{
				foreach (DataRow row in t.Rows)
				{
					try
					{

						Image img = Helper.Base64ToImage(row["uri"].ToString().Replace('"', ' ').Trim());
						System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
						Bitmap bps = new Bitmap(bmp, 50, 50);
						Image dstImage = Helper.CropToCircle(bps, Color.White);
						row["Img"] = dstImage;

					}
					catch
					{

					}
				}
			});

		}

		private void panel5_Paint(object sender, PaintEventArgs e)
		{

		}
		private void Report()
		{
			reportViewer1.LocalReport.DataSources.Clear();
			List<Invoice> reports = new List<Invoice>();
			MySQL.Close();
			MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM orders", MySQL.Conn);
			DataSet ds = new DataSet();
			da.Fill(ds);

			MySqlDataAdapter da1 = new MySqlDataAdapter("SELECT product.name AS self,product.description AS tax,casetransaction.cost,casetransaction.date as date,casetransaction.no as no,casetransaction.total,casetransaction.qty,casetransaction.cost,casetransaction.created,casetransaction.sync,casetransaction.height,casetransaction.limits,casetransaction.weight,casetransaction.setting,casetransaction.instruction,casetransaction.period FROM casetransaction LEFT join product ON casetransaction.itemID = product.id ", MySQL.Conn);
			DataSet ds1 = new DataSet();
			da1.Fill(ds1);

			  
			MySqlDataAdapter da3 = new MySqlDataAdapter("SELECT * FROM schedule  WHERE `date` >= '" + DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd") + "' AND  `date` <= '" + DateTime.Now.AddDays(10).ToString("yyyy-MM-dd") + "'", MySQL.Conn);
			DataSet ds3 = new DataSet();
			da3.Fill(ds3);

			MySqlDataAdapter da4 = new MySqlDataAdapter("SELECT * FROM customer ", MySQL.Conn);
			DataSet ds4 = new DataSet();
			da4.Fill(ds4);

			ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
			ReportDataSource datasource2 = new ReportDataSource("DataSet2", ds1.Tables[0]);
			ReportDataSource datasource3 = new ReportDataSource("DataSet3", ds3.Tables[0]);
			ReportDataSource datasource4 = new ReportDataSource("DataSet4", ds4.Tables[0]);

			reportViewer1.LocalReport.DataSources.Add(datasource);
			reportViewer1.LocalReport.DataSources.Add(datasource2);
			reportViewer1.LocalReport.DataSources.Add(datasource3);
			reportViewer1.LocalReport.DataSources.Add(datasource4);

			reportViewer1.RefreshReport();
		}

		private void DashboardForm_Load(object sender, EventArgs e)
		{
			this.reportViewer1.RefreshReport();
			invoiceLbl.Text = Invoice.List().Count().ToString();
			paidLbl.Text = Schedule.List().Where(t => t.Status.Contains("Paid")).Count().ToString();
			pendingLbl.Text = Schedule.List().Where(t => t.Status.Contains("Pending")).Count().ToString();
			customerLbl.Text = Customer.List().Count().ToString();
			itemLbl.Text = Product.List().Count().ToString();
		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}

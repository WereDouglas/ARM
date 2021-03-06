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

namespace ARM
{
	public partial class InstructionReport : Form
	{
		Dictionary<string, string> VendorDictionary = new Dictionary<string, string>();
		Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
		public InstructionReport(string No)
		{
			InitializeComponent();
			LoadReceipt(No);
		}
		private void LoadReceipt(string No)
		{

			reportViewer1.LocalReport.DataSources.Clear();

			Orders v = new Orders();
			Customer c = new Customer();
			Company y = new Company();
			v = Orders.SelectNo(No);
			y = Company.Select();
			/**Company Customer***/
			MySQL.Close();
			Microsoft.Reporting.WinForms.ReportParameter rp = new Microsoft.Reporting.WinForms.ReportParameter("image", Helper.CompanyImage);
		    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp });

			MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM instruction WHERE no='" + No + "'", MySQL.Conn);
			DataSet ds = new DataSet();
			da.Fill(ds);

			MySql.Data.MySqlClient.MySqlDataAdapter da2 = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM customer WHERE id='" + v.CustomerID + "'", MySQL.Conn);
			DataSet ds2 = new DataSet();
			da2.Fill(ds2);

			MySql.Data.MySqlClient.MySqlDataAdapter da3 = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT product.name AS itemID ,product.code AS self,product.serial AS tax,casetransaction.cost,casetransaction.date as date,casetransaction.no as no,casetransaction.total as total,casetransaction.qty as qty,casetransaction.cost,casetransaction.created,casetransaction.sync,casetransaction.height,casetransaction.limits,casetransaction.weight,casetransaction.setting,casetransaction.instruction,casetransaction.period FROM casetransaction LEFT join product ON casetransaction.itemID = product.id  WHERE casetransaction.no='" + No + "'", MySQL.Conn);
			DataSet ds3 = new DataSet();
			da3.Fill(ds3);
			



			ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
			ReportDataSource datasource2 = new ReportDataSource("DataSet2", ds2.Tables[0]);
			ReportDataSource datasource3 = new ReportDataSource("DataSet3", ds3.Tables[0]);
			
			
			reportViewer1.LocalReport.DataSources.Add(datasource);
			reportViewer1.LocalReport.DataSources.Add(datasource2);
			reportViewer1.LocalReport.DataSources.Add(datasource3);
			
		
			reportViewer1.RefreshReport();
		}

		List<Users> users = new List<Users>();
		Product k = new Product();
		DataTable t = new DataTable();
		double Total = 0;

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void InstructionReport_Load(object sender, EventArgs e)
		{
			this.reportViewer1.RefreshReport();
		}
		private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
		string VendorID = "";
		Vendor v;
		private void InvoiceBindingSource_CurrentChanged(object sender, EventArgs e)
		{

		}

		private void CaseTransactionBingSource_CurrentChanged(object sender, EventArgs e)
		{

		}
	}
}

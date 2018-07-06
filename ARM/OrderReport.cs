using ARM.DB;
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
	public partial class OrderReport : Form
	{
		Dictionary<string, string> VendorDictionary = new Dictionary<string, string>();
		Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
		public OrderReport(string No)
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

			Microsoft.Reporting.WinForms.ReportParameter rp = new Microsoft.Reporting.WinForms.ReportParameter("image", Helper.CompanyImage);
		    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp });


			Npgsql.NpgsqlDataAdapter da = new Npgsql.NpgsqlDataAdapter("SELECT * FROM orders WHERE no='" + No + "'", DBConnect.conn);
			DataSet ds = new DataSet();
			da.Fill(ds);

			Npgsql.NpgsqlDataAdapter da2 = new Npgsql.NpgsqlDataAdapter("SELECT * FROM customer WHERE id='" + v.CustomerID + "'", DBConnect.conn);
			DataSet ds2 = new DataSet();
			da2.Fill(ds2);

			Npgsql.NpgsqlDataAdapter da3 = new Npgsql.NpgsqlDataAdapter("SELECT product.name AS itemID ,product.code AS self,product.description AS tax,casetransaction.cost,casetransaction.date as date,casetransaction.no as no,casetransaction.total as total,casetransaction.qty as qty,casetransaction.cost,casetransaction.created,casetransaction.sync,casetransaction.height,casetransaction.limits,casetransaction.weight,casetransaction.setting,casetransaction.instruction,casetransaction.period FROM casetransaction LEFT join product ON casetransaction.itemID = product.id  WHERE casetransaction.no='" + No + "'", DBConnect.conn);
			DataSet ds3 = new DataSet();
			da3.Fill(ds3);


			Npgsql.NpgsqlDataAdapter da4 = new Npgsql.NpgsqlDataAdapter("SELECT * FROM coverage WHERE customerID='" + v.CustomerID + "'", DBConnect.conn);
			DataSet ds4 = new DataSet();
			da4.Fill(ds4);

			Npgsql.NpgsqlDataAdapter da5 = new Npgsql.NpgsqlDataAdapter("SELECT * FROM practitioner WHERE id='" + v.PractitionerID + "'", DBConnect.conn);
			DataSet ds5 = new DataSet();
			da5.Fill(ds5);


			ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
			ReportDataSource datasource2 = new ReportDataSource("DataSet2", ds2.Tables[0]);
			ReportDataSource datasource3 = new ReportDataSource("DataSet3", ds3.Tables[0]);
			ReportDataSource datasource4 = new ReportDataSource("DataSet4", ds4.Tables[0]);
			ReportDataSource datasource5 = new ReportDataSource("DataSet5", ds5.Tables[0]);
			reportViewer1.LocalReport.DataSources.Add(datasource);
			reportViewer1.LocalReport.DataSources.Add(datasource2);
			reportViewer1.LocalReport.DataSources.Add(datasource3);
			reportViewer1.LocalReport.DataSources.Add(datasource4);
			reportViewer1.LocalReport.DataSources.Add(datasource5);
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

		private void OrderReport_Load(object sender, EventArgs e)
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

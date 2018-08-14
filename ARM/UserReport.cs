using ARM.DB;
using ARM.Model;
using ARM.Util;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
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
	public partial class UserReport : Form
	{
		Dictionary<string, string> VendorDictionary = new Dictionary<string, string>();
		Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
		public UserReport()
		{
			InitializeComponent();
			LoadReceipt();
		}
		private void LoadReceipt()
		{
			reportViewer1.LocalReport.DataSources.Clear();		
			
			/**Company Customer***/ 

			Microsoft.Reporting.WinForms.ReportParameter rp = new Microsoft.Reporting.WinForms.ReportParameter("image", Helper.CompanyImage);
		    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp });

			MySQL.Close();
			MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM users order by name ASC", MySQL.Conn);
			DataSet ds = new DataSet();
			da.Fill(ds);
			


			ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
			
			reportViewer1.LocalReport.DataSources.Add(datasource);
			
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

		private void UserReport_Load(object sender, EventArgs e)
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

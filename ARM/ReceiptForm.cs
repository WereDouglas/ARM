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
    public partial class ReceiptForm : Form
    {
        Dictionary<string, string> VendorDictionary = new Dictionary<string, string>();
        Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
        public ReceiptForm(string No)
        {
            InitializeComponent();

            LoadReceipt(No);
        }
        private void LoadReceipt(string No)
        {

            reportViewer1.LocalReport.DataSources.Clear();
            
            Invoice v = new Invoice();
            Customer c = new Customer();
            Company y = new Company();
            v = Invoice.Select(No);
            c = Customer.Select(v.CustomerID);
            y = Company.Select();
            /**Company Customer***/
            if (v.Category.Contains("Purchase")) {

                Microsoft.Reporting.WinForms.ReportParameter rpImage = new Microsoft.Reporting.WinForms.ReportParameter("customerImage", Helper.CompanyImage);
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rpImage });

                Microsoft.Reporting.WinForms.ReportParameter rpName = new Microsoft.Reporting.WinForms.ReportParameter("customerName",Helper.CompanyName);
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rpName });
                Microsoft.Reporting.WinForms.ReportParameter rpAddress = new Microsoft.Reporting.WinForms.ReportParameter("customerAddress", Helper.CompanyAddress+" " + y.City+  " " +y.State + "  " + y.Zip );
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rpAddress });
                Microsoft.Reporting.WinForms.ReportParameter rpContact = new Microsoft.Reporting.WinForms.ReportParameter("customerContact", Helper.CompanyContact);
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rpContact });

                /**Company information***/
                Microsoft.Reporting.WinForms.ReportParameter rp2Name = new Microsoft.Reporting.WinForms.ReportParameter("companyName", c.Name);
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp2Name });
                Microsoft.Reporting.WinForms.ReportParameter rp2Address = new Microsoft.Reporting.WinForms.ReportParameter("companyAddress", c.Address + " "  + c.City + " "+ c.State + " " + c.Zip);
				this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp2Address });
                Microsoft.Reporting.WinForms.ReportParameter rp2Contact = new Microsoft.Reporting.WinForms.ReportParameter("companyContact", c.Contact);
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp2Contact });

                Microsoft.Reporting.WinForms.ReportParameter rp = new Microsoft.Reporting.WinForms.ReportParameter("image", c.Image);
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp });



            }
            if (v.Category.Contains("Sale"))
            {
                Microsoft.Reporting.WinForms.ReportParameter rp = new Microsoft.Reporting.WinForms.ReportParameter("image",Helper.CompanyImage);
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp });
                Microsoft.Reporting.WinForms.ReportParameter rpImage = new Microsoft.Reporting.WinForms.ReportParameter("customerImage", c.Image);
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rpImage });

                Microsoft.Reporting.WinForms.ReportParameter rpName = new Microsoft.Reporting.WinForms.ReportParameter("customerName", c.Name);
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rpName });
                Microsoft.Reporting.WinForms.ReportParameter rpAddress = new Microsoft.Reporting.WinForms.ReportParameter("customerAddress", c.Address + " " + c.City + " "+ c.State + " " + c.Zip);
				this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rpAddress });
                Microsoft.Reporting.WinForms.ReportParameter rpContact = new Microsoft.Reporting.WinForms.ReportParameter("customerContact", c.Contact);
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rpContact });

                /**Company information***/
                Microsoft.Reporting.WinForms.ReportParameter rp2Name = new Microsoft.Reporting.WinForms.ReportParameter("companyName", y.Name);
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp2Name });
                Microsoft.Reporting.WinForms.ReportParameter rp2Address = new Microsoft.Reporting.WinForms.ReportParameter("companyAddress", Helper.CompanyAddress + " " + y.City + " "+ " " + y.State + " " + y.Zip);
				this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp2Address });
                Microsoft.Reporting.WinForms.ReportParameter rp2Contact = new Microsoft.Reporting.WinForms.ReportParameter("companyContact", y.Contact);
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp2Contact });

            }          


            /**total tax balance**/
            Microsoft.Reporting.WinForms.ReportParameter rp3Total = new Microsoft.Reporting.WinForms.ReportParameter("total", v.Total.ToString("n2"));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp3Total });
            Microsoft.Reporting.WinForms.ReportParameter rp3Tax = new Microsoft.Reporting.WinForms.ReportParameter("tax", v.Tax.ToString("n2"));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp3Tax });
            Microsoft.Reporting.WinForms.ReportParameter rp3Bal = new Microsoft.Reporting.WinForms.ReportParameter("balance", v.Balance.ToString("n2"));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp3Bal });

            MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT product.name AS itemID ,casetransaction.cost,casetransaction.date as date,casetransaction.no as no,casetransaction.total as total,casetransaction.qty as qty,casetransaction.cost,casetransaction.created,casetransaction.sync FROM casetransaction LEFT join product ON casetransaction.itemID = product.id  WHERE casetransaction.no='" + No + "'", MySQL.Conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            MySql.Data.MySqlClient.MySqlDataAdapter da2 = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM invoice WHERE no='" + No + "'", MySQL.Conn);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

           
            ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportDataSource datasource2 = new ReportDataSource("DataSet2", ds2.Tables[0]);
            reportViewer1.LocalReport.DataSources.Add(datasource);
            reportViewer1.LocalReport.DataSources.Add(datasource2);
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


        private void ReceiptForm_Load(object sender, EventArgs e)
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

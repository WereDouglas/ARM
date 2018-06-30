using ARM.DB;
using ARM.Model;
using ARM.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
    public partial class LogsForm : Form
    {
        string From = "";
        string To = "";
        ToolStripControlHost dateFrom;
        ToolStripControlHost dateTo;

        public LogsForm()
        {
            InitializeComponent();

            fromDate = DateTime.Now.ToString("dd-MM-yyyy");
            toDate = DateTime.Now.ToString("dd-MM-yyyy");
            LoadData(fromDate, toDate);
           
        }
       
        List<Logs> ex = new List<Logs>();
        
        DataTable t = new DataTable();
        public void LoadData(string start, string end)
        {
            t = new DataTable();
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("Id");           
            t.Columns.Add("Name");
			t.Columns.Add("Action");
			t.Columns.Add("Sync");
            t.Columns.Add("Created");      
           
           
            string Q = "SELECT * FROM logs WHERE  (created::date >= '" + start + "'::date AND  created::date <= '" + end + "'::date)";
            foreach (Logs c in Logs.List(Q))
            {
                try
                {
                    t.Rows.Add(new object[] { false, c.Id, c.Name,c.Actions,c.Sync,c.Created });

                }
                catch (Exception m)
                {
                    MessageBox.Show(""+ m.Message);
                   
                }
            }
            dtGrid.DataSource = t; 
            dtGrid.AllowUserToAddRows = false;            
         //   dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;           
            dtGrid.Columns["Id"].Visible = false;   

        }
        string filterField = "Message";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                t.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, searchTxt.Text);
            }
            catch (Exception c)
            {
                Helper.Exceptions(c.ToString() , "Searching Logs by filter Field");

            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string start = Convert.ToDateTime(dateFrom.Text).ToString("dd-MM-yyyy");
            string end = Convert.ToDateTime(dateTo.Text).ToString("dd-MM-yyyy");

            string Query = "DELETE from logs WHERE (created::date >= '" + start + "'::date AND  created::date <= '" + end + "'::date)  ";
            DBConnect.QueryPostgre(Query);
            Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.InsertPostgre(Query)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
            DBConnect.InsertPostgre(q);

            Helper.Log( Helper.UserName, "Exception DELETION FOR THE PERIOD OF " + start +"to "+ end);
        }

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        string toDate;
        string fromDate;

        private void button1_Click(object sender, EventArgs e)
        {
            fromDate = Convert.ToDateTime(fromDateTxt.Text).ToString("dd-MM-yyyy");
            toDate = Convert.ToDateTime(toDateTxt.Text).ToString("dd-MM-yyyy");
            LoadingWindow.ShowSplashScreen();
            LoadData(fromDate, toDate);
            LoadingWindow.CloseForm();

        }
    }
}

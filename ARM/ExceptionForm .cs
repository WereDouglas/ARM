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
    public partial class ExceptionForm : Form
    {
        string From = "";
        string To = "";
        ToolStripControlHost dateFrom;
        ToolStripControlHost dateTo;

        public ExceptionForm()
        {
            InitializeComponent();
            
            From = DateTime.Now.ToString("dd-MM-yyyy");
            To = DateTime.Now.ToString("dd-MM-yyyy");
           
            LoadData(From, To);
           
        }
       
        List<Exceptions> ex = new List<Exceptions>();
        
        DataTable t = new DataTable();
        public void LoadData(string start, string end)
        {
            //string SQL = "SELECT * FROM exceptions WHERE  (created::date >= '" + start + "'::date AND  created::date <= '" + end + "'::date) ;";
            // create and execute query  
            t.Columns.Add(new DataColumn("Select", typeof(bool)));
            t.Columns.Add("Id");           
            t.Columns.Add("Message");
          
            t.Columns.Add("Sync");
            t.Columns.Add("Created");      
            t.Columns.Add(new DataColumn("Delete", typeof(Image)));//1

            Image delete = new Bitmap(Properties.Resources.Garbage_Closed_24);
            foreach (Exceptions c in Exceptions.List(start,end))
            {
                try
                {
                    t.Rows.Add(new object[] { false, c.Id, c.Message,c.Sync,c.Created, delete });

                }
                catch (Exception m)
                {
                    MessageBox.Show(""+ m.Message);
                    Helper.Exceptions(m.Message + "Viewing customer {Exception list opening }");
                }
            }

            dtGrid.DataSource = t; 
            dtGrid.AllowUserToAddRows = false;            
            dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;           
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
                Helper.Exceptions(c.ToString() + "Searching Exceptions by filter Field");

            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string start = Convert.ToDateTime(dateFrom.Text).ToString("yyyy-MM-dd");
            string end = Convert.ToDateTime(dateTo.Text).ToString("yyyy-MM-dd");

            string Query = "DELETE from exceptions WHERE (created::date >= '" + start + "'::date AND  created::date <= '" + end + "'::date)  ";
            DBConnect.QueryPostgre(Query);
            //Helper.Log(Helper.userID, Helper.username, "Exception DELETION");
        }

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

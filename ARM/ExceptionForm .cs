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
            Fromdate();
            Todate();
            From = DateTime.Now.ToString("dd-MM-yyyy");
            To = DateTime.Now.ToString("dd-MM-yyyy");
           
            LoadData(From, To);
           
        }
        private void Fromdate()
        {

            // Create a new ToolStripControlHost, passing in a control.
            dateFrom = new ToolStripControlHost(new DateTimePicker());

            // Set the font on the ToolStripControlHost, this will affect the hosted control.
            dateFrom.Font = new Font("Arial", 7.0F, FontStyle.Italic);

            // Set the Width property, this will also affect the hosted control.
            dateFrom.Width = 100;
            dateFrom.DisplayStyle = ToolStripItemDisplayStyle.Text;

            // Setting the Text property requires a string that converts to a 
            // DateTime type since that is what the hosted control requires.
            dateFrom.Text = "12/23/2005";

            // Cast the Control property back to the original type to set a 
            // type-specific property.
            ((DateTimePicker)dateFrom.Control).Format = DateTimePickerFormat.Short;

            // Add the control host to the ToolStrip.
            toolStrip1.Items.Add(dateFrom);

        }
        private void Todate()
        {

            // Create a new ToolStripControlHost, passing in a control.
            dateTo = new ToolStripControlHost(new DateTimePicker());

            // Set the font on the ToolStripControlHost, this will affect the hosted control.
            dateTo.Font = new Font("Arial", 7.0F, FontStyle.Italic);

            // Set the Width property, this will also affect the hosted control.
            dateTo.Width = 100;
            dateTo.DisplayStyle = ToolStripItemDisplayStyle.Text;

            // Setting the Text property requires a string that converts to a 
            // DateTime type since that is what the hosted control requires.
            dateTo.Text = "12/23/2005";

            // Cast the Control property back to the original type to set a 
            // type-specific property.
            ((DateTimePicker)dateTo.Control).Format = DateTimePickerFormat.Short;

            // Add the control host to the ToolStrip.
            toolStrip1.Items.Add(dateTo);

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
            DBConnect.save(Query);
            //Helper.Log(Helper.userID, Helper.username, "Exception DELETION");
        }
    }
}

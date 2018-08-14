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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
    public partial class CoverageDialog : MetroFramework.Forms.MetroForm
    {         
        string CustomerID;        
        public CoverageDialog(string customerID)
        {
            InitializeComponent();
            CustomerID = customerID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = Guid.NewGuid().ToString();
            Coverage t = new Coverage(id,CustomerID, nameTxt.Text,typeCbx.Text,catCbx.Text,noTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "false", Helper.CompanyID, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"));
			string saves = MySQL.Insert(t);
            if (saves != "")
            {
                Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(saves), "false", DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                MySQL.Insert(q);
                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }

        }

    }
}

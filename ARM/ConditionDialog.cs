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
    public partial class ConditionDialog : MetroFramework.Forms.MetroForm
    {  
       
        string CustomerID;
        
        public ConditionDialog(string customerID)
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
            Condition t = new Condition(id, CustomerID, nameTxt.Text,typeCbx.Text,detailsTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID);
            if (DBConnect.InsertPostgre(t) != "")
            {
                Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.InsertPostgre(t)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                DBConnect.InsertPostgre(q);
                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }

        }

    }
}

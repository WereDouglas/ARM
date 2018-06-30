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
    public partial class AddDiagnosis : MetroFramework.Forms.MetroForm
    {
        Dictionary<string, string> CoverDictionary = new Dictionary<string, string>();
       
        string Date;
        string CustomerID;
        string No;
        string CoverID;
        double Total;
        public AddDiagnosis(string no, string customerID)
        {
            InitializeComponent();
            CustomerID = customerID;
            No = no;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            string id = Guid.NewGuid().ToString();

			string less = lessChk.Checked ? "Yes" : "No";
			string greater = greaterChk.Checked ? "Yes" : "No";
			ICD10 t = new ICD10(id, No, codeTxt.Text,nameTxt.Text, diagnosisTxt.Text,less,greater,Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"), DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID);
            GenericCollection.icd10.Add(t);
            this.DialogResult = DialogResult.OK;
            this.Dispose();

        }

    }
}

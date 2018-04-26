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
        string No;
        string Date;
        string CustomerID;
        string CaseID;
        string CoverID;
        double Total;
        public AddDiagnosis(string caseID, string customerID)
        {
            InitializeComponent();


            CustomerID = customerID;
            CaseID = caseID;




        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            string id = Guid.NewGuid().ToString();
            ICD10 t = new ICD10(id, CaseID, codeTxt.Text, nameTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID);
            GenericCollection.icd10.Add(t);
            this.DialogResult = DialogResult.OK;
            this.Dispose();

        }

    }
}

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
    public partial class FollowForm : MetroFramework.Forms.MetroForm
    {
        public Dictionary<string,bool> status = new Dictionary<string, bool>();
        public  Dictionary<string,Dictionary<string,bool>>PatientStatus = new Dictionary<string, Dictionary<string, bool>>();
        
        public FollowForm()
        {
            InitializeComponent();
            status.Add("Improved",false);
            status.Add("Same", false);
            status.Add("Worse", true);

            PatientStatus.Add("Difficulty Breathing",status);
            PatientStatus.Add("ADL", status);
            PatientStatus.Add("Important Information", status);
            
            foreach (var r in PatientStatus)
            {
                CheckBox  chb = new CheckBox();
                bool t = false;
                foreach (var m in r.Value) {
                    chb.Checked = m.Value;
                    chb.Text = m.Key;
                    t = m.Value;
                   // reviewListBox.Items.Add(r.Key, t);
                }
               
            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (AddPurchase form = new AddPurchase())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }
    }
}

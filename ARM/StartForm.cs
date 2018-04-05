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
    public partial class StartForm : MetroFramework.Forms.MetroForm
    {
        public int r = 9;
        public StartForm()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MedicalForm frm = new MedicalForm();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomeForm f = new HomeForm();
            f.Show();
        }
    }
}

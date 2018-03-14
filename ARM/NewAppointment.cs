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
    public partial class NewAppointment : MetroFramework.Forms.MetroForm
    {
        public NewAppointment(string start, string end, string date)
        {
            InitializeComponent();
            if (!String.IsNullOrEmpty(start))
            {
                startTimeTxt.Text = Convert.ToDateTime(start).ToString("HH:MM");
                endTimeTxt.Text = Convert.ToDateTime(end).ToString("HH:MM");
                dateTxt.Text = date;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

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
    public partial class FollowForm : MetroFramework.Forms.MetroForm
    {
        public Dictionary<string, bool> status = new Dictionary<string, bool>();
      
        public Dictionary<string, bool> ItemReview = new Dictionary<string, bool>();
        public FollowForm()
        {
            InitializeComponent();
            Helper.ItemReview.Clear();
            Helper.PatientStatus.Clear();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            using (AddFollowUpItemReviewForm form = new AddFollowUpItemReviewForm("ItemReview"))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    reviewList.Items.Clear();                    
                    foreach (var r in Helper.ItemReview)
                    {
                        reviewList.Items.Add(r.Key, r.Value);

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (AddFollowUpItemReviewForm form = new AddFollowUpItemReviewForm("PatientStatus"))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    statusList.Items.Clear();
                    foreach (var r in Helper.PatientStatus)
                    {
                        statusList.Items.Add(r.Key +" "+r.Value, true);

                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (AddFollowUpItemReviewForm form = new AddFollowUpItemReviewForm("ItemSetting"))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    settingListBx.Items.Clear();
                    foreach (var r in Helper.ItemSetting)
                    {
                        settingListBx.Items.Add(r.Key + " " + r.Value);

                    }
                }
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

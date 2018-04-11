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
    public partial class AddFollowUpItemReviewForm : MetroFramework.Forms.MetroForm
    {
        string currentDialog = "";
        public AddFollowUpItemReviewForm(string set)
        {
            InitializeComponent();
            if (set == "ItemReview")
            {
                currentDialog = "ItemReview";
                detailsCbx.Items.Add("SAFETY AND ENVIRONMENT");
                detailsCbx.Items.Add("OXYGEN TIPS && HAZARDA");
                detailsCbx.Items.Add("OTHER HOME CARE SERVICES");
                detailsCbx.Items.Add("EQUIPMENT USE,OPERATION");
                // stateCbx.Visible = false;
                stateCbx.Items.Add("Yes");
                stateCbx.Items.Add("No");

            }
            if (set == "PatientStatus")
            {
                currentDialog = "PatientStatus";

                detailsCbx.Items.Add("DIFFICULTY IN BREATHING");
                detailsCbx.Items.Add("ADL");

                stateCbx.Items.Add("Improved");
                stateCbx.Items.Add("Same");
                stateCbx.Items.Add("Worse");
            }
            if (set == "ItemSetting")
            {
                currentDialog = "ItemSetting";
                detailsCbx.Items.Add("FREQUENCY OF USE:");
                detailsCbx.Items.Add("DURATION");
                detailsCbx.Items.Add("SETTINGS");

                stateCbx.Items.Add("INCREASE");
                stateCbx.Items.Add("DECREASE");
                stateCbx.Items.Add("SAME");
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (currentDialog == "ItemReview")
            {
                if (Helper.ItemReview.ContainsKey(detailsCbx.Text + ":" + detailsTxt.Text))
                {
                    MessageBox.Show("Selection exists !");
                    return;
                }
                if (stateCbx.Text == "Yes")
                {
                    Helper.ItemReview.Add(detailsCbx.Text + ":" + detailsTxt.Text, true);
                }
                if (stateCbx.Text == "No")
                {
                    Helper.ItemReview.Add(detailsCbx.Text + ":" + detailsTxt.Text, false);
                }
            }
            if (currentDialog == "PatientStatus")
            {
                if (Helper.PatientStatus.ContainsKey(detailsCbx.Text + ":" + detailsTxt.Text))
                {
                    MessageBox.Show("Selection exists !");
                    return;
                }
                Helper.PatientStatus.Add(detailsCbx.Text + ":" + detailsTxt.Text, stateCbx.Text);
            }
            if (currentDialog == "ItemSetting")
            {
                if (Helper.ItemSetting.ContainsKey(detailsCbx.Text + ":" + detailsTxt.Text))
                {
                    MessageBox.Show("Selection exists !");
                    return;
                }
                Helper.ItemSetting.Add(detailsCbx.Text + ":" + detailsTxt.Text, stateCbx.Text);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}

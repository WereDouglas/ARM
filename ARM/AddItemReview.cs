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
    public partial class AddItemReview : MetroFramework.Forms.MetroForm
    {
        string currentDialog = "";
        string FollowID = "";
        public AddItemReview(string set,string followID)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(followID)) {

                FollowID = followID;
            }
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
                string id = Guid.NewGuid().ToString();
                ItemReview t = new ItemReview(id, FollowID, detailsCbx.Text, stateCbx.Text, detailsTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false);
                GenericCollection.itemReviews.Add(t);
                this.DialogResult = DialogResult.OK;
                this.Dispose();
                return;
            }
            if (currentDialog == "PatientStatus")
            {
                if (Helper.PatientStatus.ContainsKey(detailsCbx.Text + ":" + detailsTxt.Text))
                {
                    MessageBox.Show("Selection exists !");
                    return;
                }
                Helper.PatientStatus.Add(detailsCbx.Text + ":" + detailsTxt.Text, stateCbx.Text);
                string id = Guid.NewGuid().ToString();
                PatientStatus t = new PatientStatus(id, FollowID, detailsCbx.Text, stateCbx.Text, detailsTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false);
                GenericCollection.patientStatus.Add(t);
                this.DialogResult = DialogResult.OK;
                this.Dispose();
                return;
            }
            if (currentDialog == "ItemSetting")
            {
                if (Helper.ItemSetting.ContainsKey(detailsCbx.Text + ":" + detailsTxt.Text))
                {
                    MessageBox.Show("Selection exists !");
                    return;
                }
                Helper.ItemSetting.Add(detailsCbx.Text + ":" + detailsTxt.Text, stateCbx.Text);
                string id = Guid.NewGuid().ToString();
                ItemStatus t = new ItemStatus(id, FollowID, detailsCbx.Text, stateCbx.Text, detailsTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false);
                GenericCollection.itemStatus.Add(t);
                this.DialogResult = DialogResult.OK;
                this.Dispose();
                return;

            }
            

        }
    }
}

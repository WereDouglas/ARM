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
    public partial class ParentForm : MetroFramework.Forms.MetroForm
    {
        public ParentForm()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
            FollowForm f = new FollowForm();
            f.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DmeForm d = new DmeForm();
            d.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddItemForm it = new AddItemForm();
            it.Show();
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddItemForm it = new AddItemForm();
            it.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            using (AddItemForm form = new AddItemForm())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddItemForm it = new AddItemForm();
            it.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void deliveryPickupTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void orderIntakeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dMEInstructionDeliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void followUpPlanOfCareToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PurchaseForm form = new PurchaseForm())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PurchaseForm form = new PurchaseForm())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddCustomerForm form = new AddCustomerForm())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (AddCustomerForm form = new AddCustomerForm())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            using (AddSupplierForm form = new AddSupplierForm())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeliveryPickupForm f = new DeliveryPickupForm();
            f.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FollowForm f = new FollowForm();
            f.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OrderIntakeForm o = new OrderIntakeForm();
            o.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DmeForm d = new DmeForm();
            d.Show();
        }

        private void unitsOfMeasureToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class MedicalForm : MetroFramework.Forms.MetroForm
    {
        public MedicalForm()
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


        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddItem form = new AddItem(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            using (AddItem form = new AddItem(null))
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
            AddItem it = new AddItem(null);
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
            using (AddCustomerForm form = new AddCustomerForm(null))
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
            using (AddCustomerForm form = new AddCustomerForm(null))
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

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            PhysiciansForm frm = new PhysiciansForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
           
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CustomerForm frm = new CustomerForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void exceptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExceptionForm frm = new ExceptionForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddVendor form = new AddVendor(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            VendorForm frm = new VendorForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            UserForm frm = new UserForm();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddUser form = new AddUser(null))
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

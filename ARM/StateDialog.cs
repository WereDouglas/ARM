using ARM.DB;
using ARM.Model;
using ARM.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
    public partial class StateDialog : MetroFramework.Forms.MetroForm
    {

        string ID;
        public StateDialog(string id)
        {
            InitializeComponent();
            ID = id;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string Query = "UPDATE schedule SET status = '" + stateCbx.Text + "' WHERE id ='" + ID + "'";
            
            MySQL.Query(Query);
            Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), "false", DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
            MySQL.Insert(q);

            MessageBox.Show("Information Updated ! ");
            this.DialogResult = DialogResult.OK;
            this.Dispose();


        }
        string Query;
        private void Update(string itemID)
        {

            //MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            //string fullimage = Helper.ImageToBase64(stream);
            //Item c = new Item(itemID, nameTxt.Text, categoryCbx.Text, typeCbx.Text, descriptionxt.Text, costTxt.Text, batchTxt.Text, serialTxt.Text, barTxt.Text, unitTxt.Text, unitDescTxt.Text, manuTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "false", fullimage);
            //DBConnect.Update(c, itemID);
            //MessageBox.Show("Information Updated");
            //this.DialogResult = DialogResult.OK;
            //this.Dispose();
        }
        Customer c;
        private void customerCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        Users u;
        Rate r;
        private void StateDialog_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("YES or No?", "Are you sure you want to delete this Schedule? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string Query = "DELETE from schedule WHERE id ='" + ID + "'";
                MySQL.Query(Query);

                Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(Query), "false", DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                MySQL.Insert(q);
                MessageBox.Show("Information deleted");
            }
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}

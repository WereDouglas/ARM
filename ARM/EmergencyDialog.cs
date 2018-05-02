using ARM.DB;
using ARM.Model;
using ARM.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
    public partial class EmergencyDialog : MetroFramework.Forms.MetroForm
    {  
       
        string CustomerID;
        
        public EmergencyDialog(string customerID)
        {
            InitializeComponent();
            CustomerID = customerID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                imgCapture.Image = new Bitmap(open.FileName);
                imgCapture.SizeMode = PictureBoxSizeMode.StretchImage;
                fileUrlTxtBx.Text = open.FileName;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = Helper.ImageToBase64(stream);

            Emergency c = new Emergency(Guid.NewGuid().ToString(),CustomerID, nameTxt.Text, contactTxt.Text, addressTxt.Text, noTxt.Text, cityTxt.Text, stateTxt.Text, zipTxt.Text,genderCbx.Text,relationshipCbx.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"),false, Helper.CompanyID, fullimage);

            string save = DBConnect.InsertPostgre(c);
            if ( save!= "")
            {
                Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                DBConnect.InsertPostgre(q);

                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

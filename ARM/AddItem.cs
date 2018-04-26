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
    public partial class AddItem : MetroFramework.Forms.MetroForm
    {
        string ItemID;
        public AddItem(string itemID)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(itemID))
            {

                Profile(itemID);
            }
        }
        private Product c;
        private void Profile(string itemID)
        {
            ItemID = itemID;
            c = new Product();//.Select(ItemID);
            c = Product.Select(ItemID);
            nameTxt.Text = c.Name;
            categoryCbx.Text = c.Category;
            typeCbx.Text = c.Type;
            descriptionxt.Text = c.Description;
            costTxt.Text = c.Cost;
            barTxt.Text = c.Barcode;
            serialTxt.Text = c.SerialNo;
            unitTxt.Text = c.UnitOfMeasure;
            unitDescTxt.Text = c.MeasureDescription;
            manuTxt.Text = c.Manufacturer;
         
            try
            {
                Image img = Helper.Base64ToImage(c.Image.ToString());
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                //Bitmap bps = new Bitmap(bmp, 50, 50);
                imgCapture.Image = bmp;
                imgCapture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception t)
            {
                MessageBox.Show(t.Message);
                Helper.Exceptions(t.Message + "view load image for Item  ");

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ItemID))
            {
                Update(ItemID);
                return;
            }
            MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = Helper.ImageToBase64(stream);

            string id = Guid.NewGuid().ToString();
            Product c = new Product(id, nameTxt.Text, categoryCbx.Text, typeCbx.Text, descriptionxt.Text, costTxt.Text, batchTxt.Text, serialTxt.Text,barTxt.Text,unitTxt.Text,unitDescTxt.Text,manuTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false,Helper.CompanyID, fullimage);
            if (DBConnect.InsertPostgre(c) != "")
            {
                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }
        string Query;
        private void Update(string itemID)
        {

            MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = Helper.ImageToBase64(stream);
            Product c = new Product(itemID, nameTxt.Text, categoryCbx.Text, typeCbx.Text, descriptionxt.Text, costTxt.Text, batchTxt.Text, serialTxt.Text, barTxt.Text, unitTxt.Text, unitDescTxt.Text, manuTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, Helper.CompanyID, fullimage);
            DBConnect.UpdatePostgre(c, itemID);
            MessageBox.Show("Information Updated");
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }


        private void metroLabel9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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
    }
}

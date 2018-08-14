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
            serialTxt.Text = c.Serial;
            unitTxt.Text = c.UnitOfMeasure;
            unitDescTxt.Text = c.MeasureDescription;
            manuTxt.Text = c.Manufacturer;
            codeTxt.Text = c.Code;

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
                Helper.Exceptions(t.Message , "view load image for Item  ");

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
			if (string.IsNullOrEmpty(costTxt.Text))
			{
				MessageBox.Show("Please input the cost ");
				return;
			}

			MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg); ;
            if (!string.IsNullOrEmpty(ext))
            {

                if (ext.Contains("png"))
                {
                    stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Png);
                }
                else if (ext.Contains("Jpeg"))
                {
                    stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else if (ext.Contains("jpg"))
                {
                    stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
                }

            }

            else
            {
                stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);

            }
             //stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string fullimage = Helper.ImageToBase64(stream);

            string id = Guid.NewGuid().ToString();
            Product c = new Product(id, nameTxt.Text, codeTxt.Text, categoryCbx.Text, typeCbx.Text,Helper.CleanString(descriptionxt.Text), costTxt.Text, batchTxt.Text, serialTxt.Text, barTxt.Text, unitTxt.Text,Helper.CleanString(unitDescTxt.Text), manuTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "false", Helper.CompanyID, fullimage, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"));

			string save = MySQL.Insert(c);
            if (save != "")
            {
                Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), "false", DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                MySQL.Insert(q);
                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }
        string Query;
        private void Update(string itemID)
        {
            MemoryStream stream = null;
            if (ext.Contains("png"))
            {
                stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Png);
            }
            else if (ext.Contains("Jpeg"))
            {
                stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else if (ext.Contains("jpg"))
            {
                stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            string fullimage = Helper.ImageToBase64(stream);
            Product c = new Product(ItemID, nameTxt.Text, codeTxt.Text, categoryCbx.Text, typeCbx.Text, descriptionxt.Text, costTxt.Text, batchTxt.Text, serialTxt.Text, barTxt.Text, unitTxt.Text, unitDescTxt.Text, manuTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "false", Helper.CompanyID, fullimage, Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"));
			DBConnect.UpdateMySql(c, itemID);

           
            MessageBox.Show("Information Updated");
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }


        private void metroLabel9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        string ext;
        private void imgCapture_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;*.png)|*.jpg; *.jpeg; *.gif; *.bmp;*.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(open.FileName);
                var fileSize = fi.Length;
                ext = Path.GetExtension(open.FileName);
                // display image in picture box
                imgCapture.Image = new Bitmap(open.FileName);
                imgCapture.SizeMode = PictureBoxSizeMode.StretchImage;
                fileUrlTxtBx.Text = open.FileName;
            }
        }

        private void AddItem_Load(object sender, EventArgs e)
        {

        }
    }
}

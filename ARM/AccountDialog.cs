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
    public partial class AccountDialog : MetroFramework.Forms.MetroForm
    {

        Dictionary<string, string> UserDictionary = new Dictionary<string, string>();
        Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
        string CustomerID;
        string UserID;
        public AccountDialog(string userID)
        {
            InitializeComponent();
            if (!String.IsNullOrEmpty(userID))
            {


            }
            AutoCompleteUser();
        }
        private void AutoCompleteUser()
        {

            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            UserDictionary.Clear();
            foreach (Users v in Users.List())
            {
                AutoItem.Add((v.Name));

                if (!UserDictionary.ContainsKey(v.Name))
                {
                    UserDictionary.Add(v.Name, v.Id);
                    userCbx.Items.Add(v.Name);
                }
            }
           
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string ID = Guid.NewGuid().ToString();
            Account r = new Account(ID, UserID,bankTxt.Text, accountTxt.Text, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"),false,Helper.CompanyID);
            if (DBConnect.InsertPostgre(r) != "")
            {
                Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(DBConnect.InsertPostgre(r)), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                DBConnect.InsertPostgre(q);
                MessageBox.Show("Information Saved");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }

        }
        string Query;
        private void Update(string itemID)
        {

            //MemoryStream stream = Helper.ImageToStream(imgCapture.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            //string fullimage = Helper.ImageToBase64(stream);
            //Item c = new Item(itemID, nameTxt.Text, categoryCbx.Text, typeCbx.Text, descriptionxt.Text, costTxt.Text, batchTxt.Text, serialTxt.Text, barTxt.Text, unitTxt.Text, unitDescTxt.Text, manuTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), false, fullimage);
            //DBConnect.Update(c, itemID);
            //MessageBox.Show("Information Updated");
            //this.DialogResult = DialogResult.OK;
            //this.Dispose();
        }

        Users u;
        Rate r;
        private void userCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                UserID = UserDictionary[userCbx.Text];
                u = new Users();//.Select(ItemID);
                u = Users.Select(UserID);
                Image img = Helper.Base64ToImage(u.Image);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                userPbx.Image = bmp;
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(userPbx.DisplayRectangle);
                userPbx.Region = new Region(gp);
                userPbx.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch { }
        }

        private void AccountDialog_Load(object sender, EventArgs e)
        {

        }

        private void costTxt_Click(object sender, EventArgs e)
        {

        }

        private void accountTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
            && !char.IsDigit(e.KeyChar)
            && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow two decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}

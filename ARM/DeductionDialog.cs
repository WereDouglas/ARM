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
    public partial class DeductionDialog : MetroFramework.Forms.MetroForm
    {

        Dictionary<string, string> UserDictionary = new Dictionary<string, string>();
        Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
        string CustomerID;
        string UserID;
        public DeductionDialog(string id,string userID)
        {
            InitializeComponent();           
           
            if (!string.IsNullOrEmpty(id)) {

                noLbl.Text = id;
            }
            if (!string.IsNullOrEmpty(userID))
            {

                UserID = userID;
            }
        }
            


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string ID = Guid.NewGuid().ToString();
            Deduction r = new Deduction(ID,Convert.ToDateTime(dateTxt.Text).ToString("dd-MM-yyyy"),noLbl.Text,UserID,categoryCbx.Text,detailsTxt.Text,Convert.ToDouble(amountTxt.Text),paidCbx.Text,DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"),"false",Helper.CompanyID);
            string saves = MySQL.Insert(r);
            if (saves != "")
            {
                Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(saves), "false", DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
                MySQL.Insert(q);
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
            //Item c = new Item(itemID, nameTxt.Text, categoryCbx.Text, typeCbx.Text, descriptionxt.Text, costTxt.Text, batchTxt.Text, serialTxt.Text, barTxt.Text, unitTxt.Text, unitDescTxt.Text, manuTxt.Text, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), "false", fullimage);
            //DBConnect.Update(c, itemID);
            //MessageBox.Show("Information Updated");
            //this.DialogResult = DialogResult.OK;
            //this.Dispose();
        }
        
        Users u;
        Rate r;
     

        private void DeductionDialog_Load(object sender, EventArgs e)
        {

        }

    }
}

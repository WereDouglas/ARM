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
using System.Xml.Linq;

namespace ARM
{
    public partial class SettingsForm : MetroFramework.Forms.MetroForm
    {

        Dictionary<string, string> UserDictionary = new Dictionary<string, string>();
        Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
        string CustomerID;
        string UserID;
        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();


        }
        private void LoadSettings()
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(Helper.XMLFile());
                var servers = from person in xmlDoc.Descendants("Server")
                              select new
                              {
                                  Name = person.Element("Name").Value,
                                  Ip = person.Element("Ip").Value
                                  
                              };


                foreach (var server in servers)
                {
                    localNameTxt.Text = server.Name;
                    Helper.serverName = server.Name;
                    ipTxt.Text = server.Ip;

                }
            }
            catch(Exception p ) { MessageBox.Show(p.Message); }


        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XElement xml = new XElement("Servers",
           new XElement("Server",
           new XElement("Name", localNameTxt.Text),
           new XElement("Ip", ipTxt.Text)

           )
           );

            xml.Save(Helper.XMLFile());
            MessageBox.Show("Information Updated");
            this.DialogResult = DialogResult.OK;
            this.Dispose();

        }

        private void userCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void costTxt_Click(object sender, EventArgs e)
        {

        }

        private void localNameTxt_Leave(object sender, EventArgs e)
        {
            try
            {
                Helper.serverIP = Helper.IPAddressCheck(localNameTxt.Text);
                ipTxt.Text = Helper.serverIP;
            }
            catch(Exception c) {
                MessageBox.Show(c.Message + "");


            }
        }
    }
}

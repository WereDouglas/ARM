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
                                  Remote = person.Element("Remote").Value,
								  IP = person.Element("IP").Value,
								  Default = person.Element("Default").Value,
                                  Port = person.Element("Port").Value
                              };


                foreach (var server in servers)
                {
                    localNameTxt.Text = server.Name;
                    Helper.serverName = server.Name;
					Helper.serverIP = server.IP;
					ipTxt.Text = server.IP;
                    remoteTxt.Text = server.Remote;
                    defaultTxt.Text = server.Default;
                    portTxt.Text = server.Port;

                }
            }
            catch (Exception p) { MessageBox.Show(p.Message); }

        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(defaultTxt.Text))
            {
                MessageBox.Show("Please select Yes or No for default settings ");
                defaultTxt.BackColor = Color.Red;
                return;
            }
			if (string.IsNullOrEmpty(ipTxt.Text))
			{
				MessageBox.Show("Please input the server IP ");
				ipTxt.BackColor = Color.Red;
				return;
			}
			if (!Helper.ValidateIPv4(ipTxt.Text))
			{
				MessageBox.Show("Invalid IP address please input IP address manually ! ");
				Helper.serverIP = "";
				ipTxt.Text = "";
				return;
			}

			XElement xml = new XElement("Servers",
            new XElement("Server",
            new XElement("Name", localNameTxt.Text),
			new XElement("IP", ipTxt.Text),
			new XElement("Remote", remoteTxt.Text),
            new XElement("Default", defaultTxt.Text),
            new XElement("Port", portTxt.Text)
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

        private void localNameTxt_Leave(object sender, EventArgs e)
        {
            try
            {
				ipTxt.Text = Helper.IPAddressCheck(localNameTxt.Text);
                 
            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message + "");


            }
			if (!Helper.ValidateIPv4(ipTxt.Text)) {

				MessageBox.Show("Invalid IP address please input IP address manually ! ");
				//Helper.serverIP = "";
				
			}
			

		}

        private void defaultTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (defaultTxt.Text == "Default")
                {

					ipTxt.Text = Helper.IPAddressCheck(localNameTxt.Text);
					if (!Helper.ValidateIPv4(ipTxt.Text))
					{

						MessageBox.Show("Invalid IP address please input IP address manually ! ");
						Helper.serverIP = "";
						ipTxt.Text = "";
					}


				}
                else if (defaultTxt.Text == "Remote")
                {
                    if (string.IsNullOrEmpty(remoteTxt.Text))
                    {
                        MessageBox.Show("Please input the remote url ");
                        return;

                    }
                    Helper.serverIP = Helper.IPAddressCheck(remoteNameTxt.Text);
                   

                   // Helper.serverIP = (remoteTxt.Text);
                }

            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message + "");


            }

        }

        private void remoteNameTxt_Leave(object sender, EventArgs e)
        {
            try
            {

                Helper.serverIP = Helper.IPAddressCheck(remoteNameTxt.Text);               
                remoteTxt.Text = Helper.serverIP;
            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message + "");


            }
        }
    }
}

using ARM.Model;
using ARM.Util;
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
	public partial class AdministrationForm : Form
	{
		public AdministrationForm()
		{
			InitializeComponent();
			newInstallation();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			HrmForm f = new HrmForm();
			f.Show();	
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MedicalForm frm = new MedicalForm();
			frm.Show();
			
			
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void newInstallation()
		{
			try
			{
				string c = Company.List().First().Name;

				Image img = Helper.Base64ToImage(Company.List().First().Image);
				System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
				//Bitmap bps = new Bitmap(bmp, 50, 50);
				pictureBox2.Image = bmp;
				pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
				Helper.CompanyID = Company.List().First().Id;
			}
			catch
			{


			}

		}
	}
}

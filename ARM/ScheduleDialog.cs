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
	public partial class ScheduleDialog : MetroFramework.Forms.MetroForm
	{

		Dictionary<string, string> UserDictionary = new Dictionary<string, string>();
		Dictionary<string, string> CustomerDictionary = new Dictionary<string, string>();
		string CustomerID;
		string UserID;
		public ScheduleDialog(string start, string end, string date)
		{
			InitializeComponent();


			if (!String.IsNullOrEmpty(start))
			{

				//startHrTxt.Text = Convert.ToDateTime(start).ToShortTimeString();
				//endHrTxt.Text = Convert.ToDateTime(end).ToShortTimeString();
				openedDate.Text = date;

			}
			AutoCompleteCustomer();
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
			userCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
			userCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
			userCbx.AutoCompleteCustomSource = AutoItem;

		}
		private void AutoCompleteCustomer()
		{
			AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
			CustomerDictionary.Clear();
			foreach (Customer c in Customer.List())
			{
				AutoItem.Add((c.Name));

				if (!CustomerDictionary.ContainsKey(c.Name))
				{
					CustomerDictionary.Add(c.Name, c.Id);
					customerCbx.Items.Add(c.Name);
				}
			}
			customerCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
			customerCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
			customerCbx.AutoCompleteCustomSource = AutoItem;
		}


		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		Schedule _event;
		List<Schedule> ScheduleList = new List<Schedule>();
		private void button3_Click(object sender, EventArgs e)
		{

			Week = Helper.GetIso8601WeekOfYear(Convert.ToDateTime(this.openedDate.Text));
			string ID = Guid.NewGuid().ToString();
			foreach (Schedule m in ScheduleList)
			{

				if (Schedule.Exists(m.Starts, m.Ends, m.UserID))
				{
					MessageBox.Show("Schedule Exists for " + m.Date, "Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
					//return;
				}
				else
				{

					_event = new Schedule(m.Id,Convert.ToDateTime(m.Date).ToString("yyyy-MM-dd"),m.CustomerID, m.UserID, m.Starts, m.Ends, m.Location, m.Address, Helper.CleanString(m.Details),m.Indicator, m.Period,m.Category,m.Status, Convert.ToDouble(m.Cost), DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), false, Helper.CompanyID, Week);
					string save = DBConnect.InsertPostgre(_event);
					if (!string.IsNullOrEmpty(save))
					{
						Queries q = new Queries(Guid.NewGuid().ToString(), Helper.UserName, Helper.CleanString(save), false, DateTime.Now.ToString("dd-MM-yyyy H:m:s"), Helper.CompanyID);
						DBConnect.InsertPostgre(q);
					}
				}

			}



			MessageBox.Show("Information Saved");
			this.DialogResult = DialogResult.OK;
			this.Dispose();

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
		Customer c;
		private void customerCbx_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				CustomerID = CustomerDictionary[customerCbx.Text];
				c = new Customer();//.Select(ItemID);
				c = Customer.Select(CustomerID);
				locationTxt.Text = c.Address + " " + c.City + " " + c.State;
				Image img = Helper.Base64ToImage(c.Image);
				System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
				cusPbx.Image = bmp;
				GraphicsPath gp = new GraphicsPath();
				gp.AddEllipse(cusPbx.DisplayRectangle);
				cusPbx.Region = new Region(gp);
				cusPbx.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			catch { }
		}
		Users u;
		Rate r;
		private void userCbx_SelectedIndexChanged(object sender, EventArgs e)
		{
			rateTxt.Text = "";
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
			r = new Rate();
			r = Rate.Select(UserID);
			// costTxt_TextChanged(object sender, EventArgs e)
			try
			{
				rateTxt.Text = r.Amount.ToString();
				//totalTxt.Text = (r.Amount * Convert.ToDouble(periodTxt.Text)).ToString();
			}
			catch (Exception c)
			{
				MessageBox.Show("The selected persons has no hours defined ");
				Helper.Exceptions(c.ToString(), "Employee has no hourly rates defined " + u.Name);
				rateTxt.Text = "0";


			}
		}

		private void ScheduleDialog_Load(object sender, EventArgs e)
		{

		}

		private void categoryCbx_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void periodTxt_KeyPress(object sender, KeyPressEventArgs e)
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

		private void endDate_ValueChanged(object sender, EventArgs e)
		{
			categoryCbx_SelectedIndexChanged(null, null);
		}

		private void offListBx_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void costTxt_TextChanged(object sender, EventArgs e)
		{
			try
			{

				//totalTxt.Text = (Convert.ToDouble(rateTxt.Text) * Convert.ToDouble(periodTxt.Text)).ToString();
			}
			catch
			{
				// MessageBox.Show("The selected persons has no hours defined ");
				//  costTxt.Text = "0";
				// totalTxt.Text = "0";

			}
		}

		private void endHrTxt_Leave(object sender, EventArgs e)
		{
			categoryCbx_SelectedIndexChanged(null, null);

			fillUp(Convert.ToDateTime(openedDate.Text));
		}
		string month;


		private void openedDate_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				fillUp(Convert.ToDateTime(openedDate.Text));
			}
			catch { }
		}
		int Year;
		int Week;
		private void fillUp(DateTime d)
		{
			month = d.ToString("MMMM");
			Year = Convert.ToInt32(d.ToString("yyyy"));
			Week = Helper.GetIso8601WeekOfYear(d);
			//  weekLbl.Text = week.ToString();
			//  startLbl.Text = Helper.FirstDateOfWeek(year, week).Date.ToString("dd-MM-yyyy");
			// endLbl.Text = Convert.ToDateTime(startLbl.Text).AddDays(+6).Date.ToString("dd-MM-yyyy");
			weekTxt.Text = Week.ToString();
			monDateLbl.Text = Helper.FirstDateOfWeek(Year, Week).Date.ToString("dd-MM-yyyy");
			tueDate.Text = Convert.ToDateTime(monDateLbl.Text).AddDays(1).ToString("dd-MM-yyyy");
			wedDate.Text = Convert.ToDateTime(monDateLbl.Text).AddDays(2).ToString("dd-MM-yyyy");
			thuDate.Text = Convert.ToDateTime(monDateLbl.Text).AddDays(3).ToString("dd-MM-yyyy");
			friDate.Text = Convert.ToDateTime(monDateLbl.Text).AddDays(4).ToString("dd-MM-yyyy");
			satDate.Text = Convert.ToDateTime(monDateLbl.Text).AddDays(5).ToString("dd-MM-yyyy");
			sunDate.Text = Convert.ToDateTime(monDateLbl.Text).AddDays(6).ToString("dd-MM-yyyy");
			
		}
		private void monChk_CheckedChanged(object sender, EventArgs e)
		{
			if (monChk.Checked)
			{
				string startP = Convert.ToDateTime(monDateLbl.Text).ToString("yyyy-MM-dd") + "T" + monStart.Text;
				string endP = Convert.ToDateTime(monDateLbl.Text).ToString("yyyy-MM-dd") + "T" + monEnd.Text;
				DateTime start = Convert.ToDateTime(startP);
				DateTime end = Convert.ToDateTime(endP);

				var hours = (end - start).TotalHours;
				monhrsLbl.Text = Math.Round(hours).ToString();
				moncostLbl.Text = Cost(rateTxt.Text, monhrsLbl.Text).ToString();

				string id = Guid.NewGuid().ToString();
				_event = new Schedule(id, Convert.ToDateTime(monDateLbl.Text).ToString("yyyy-MM-dd"), CustomerID, UserID, startP, endP, locationTxt.Text, locationTxt.Text, Helper.CleanString(this.detailsTxt.Text), "", monhrsLbl.Text, "", "Pending", Convert.ToDouble(moncostLbl.Text), DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), false, Helper.CompanyID, Week);

				if (ScheduleList.FindIndex(f => f.Date == Convert.ToDateTime(monDateLbl.Text).ToString("yyyy-MM-dd")) <= 0)
				{
					ScheduleList.Add(_event);
				}
				else
				{
					MessageBox.Show("Schedule already Exists ");
				}
			}
			else
			{
				if (ScheduleList.FindIndex(f => f.Date == Convert.ToDateTime(monDateLbl.Text).ToString("yyyy-MM-dd")) >= 0)
				{
					ScheduleList.RemoveAll(x => x.Date == Convert.ToDateTime(monDateLbl.Text).ToString("yyyy-MM-dd"));
				}

			}
		}
		private double Cost(string rate, string hrs)
		{
			double ans = 0;
			try
			{
				ans = (Convert.ToDouble(rate) * Convert.ToDouble(hrs));
			}
			catch (Exception c)
			{
				Helper.Exceptions(c.ToString(), " Cost Method not computing on Shedule Dialog ");

			}
			return ans;
		}

		private void groupBox3_Enter(object sender, EventArgs e)
		{

		}

		private void tueChk_CheckedChanged(object sender, EventArgs e)
		{
			if (tueChk.Checked)
			{
				string startP = Convert.ToDateTime(tueDate.Text).ToString("yyyy-MM-dd") + "T" + tueStart.Text;
				string endP = Convert.ToDateTime(tueDate.Text).ToString("yyyy-MM-dd") + "T" + tueEnd.Text;
				DateTime start = Convert.ToDateTime(startP);
				DateTime end = Convert.ToDateTime(endP);

				var hours = (end - start).TotalHours;
				tueHrs.Text = Math.Round(hours).ToString();
				tueCost.Text = Cost(rateTxt.Text, tueHrs.Text).ToString();

				string id = Guid.NewGuid().ToString();
				_event = new Schedule(id, Convert.ToDateTime(tueDate.Text).ToString("yyyy-MM-dd"), CustomerID, UserID, startP, endP, locationTxt.Text, locationTxt.Text, Helper.CleanString(this.detailsTxt.Text), "", tueHrs.Text, "", "Pending", Convert.ToDouble(tueCost.Text), DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), false, Helper.CompanyID, Week);

				if (ScheduleList.FindIndex(f => f.Date == Convert.ToDateTime(tueDate.Text).ToString("yyyy-MM-dd")) <= 0)
				{
					ScheduleList.Add(_event);
				}
				else
				{
					MessageBox.Show("Schedule already Exists ");
				}
			}
			else
			{
				if (ScheduleList.FindIndex(f => f.Date == Convert.ToDateTime(tueDate.Text).ToString("yyyy-MM-dd")) >= 0)
				{
					ScheduleList.RemoveAll(x => x.Date == Convert.ToDateTime(tueDate.Text).ToString("yyyy-MM-dd"));
				}

			}

		}

		private void wedChk_CheckedChanged(object sender, EventArgs e)
		{
			if (wedChk.Checked)
			{
				string startP = Convert.ToDateTime(wedDate.Text).ToString("yyyy-MM-dd") + "T" + wedStart.Text;
				string endP = Convert.ToDateTime(wedDate.Text).ToString("yyyy-MM-dd") + "T" + wedEnd.Text;
				DateTime start = Convert.ToDateTime(startP);
				DateTime end = Convert.ToDateTime(endP);

				var hours = (end - start).TotalHours;
				wedHrs.Text = Math.Round(hours).ToString();
				wedCost.Text = Cost(rateTxt.Text, wedHrs.Text).ToString();

				string id = Guid.NewGuid().ToString();
				_event = new Schedule(id, Convert.ToDateTime(wedDate.Text).ToString("yyyy-MM-dd"), CustomerID, UserID, startP, endP, locationTxt.Text, locationTxt.Text, Helper.CleanString(this.detailsTxt.Text), "", wedHrs.Text, "", "Pending", Convert.ToDouble(wedCost.Text), DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), false, Helper.CompanyID, Week);

				if (ScheduleList.FindIndex(f => f.Date == Convert.ToDateTime(wedDate.Text).ToString("yyyy-MM-dd")) <= 0)
				{
					ScheduleList.Add(_event);
				}
				else
				{
					MessageBox.Show("Schedule already Exists ");
				}
			}
			else
			{
				if (ScheduleList.FindIndex(f => f.Date == Convert.ToDateTime(wedDate.Text).ToString("yyyy-MM-dd")) >= 0)
				{
					ScheduleList.RemoveAll(x => x.Date == Convert.ToDateTime(wedDate.Text).ToString("yyyy-MM-dd"));
				}

			}
		}

		private void thuChk_CheckedChanged(object sender, EventArgs e)
		{
			if (thuChk.Checked)
			{
				string startP = Convert.ToDateTime(thuDate.Text).ToString("yyyy-MM-dd") + "T" + thuStart.Text;
				string endP = Convert.ToDateTime(thuDate.Text).ToString("yyyy-MM-dd") + "T" + thuEnd.Text;
				DateTime start = Convert.ToDateTime(startP);
				DateTime end = Convert.ToDateTime(endP);

				var hours = (end - start).TotalHours;
				thuHrs.Text = Math.Round(hours).ToString();
				thuCost.Text = Cost(rateTxt.Text, thuHrs.Text).ToString();

				string id = Guid.NewGuid().ToString();
				_event = new Schedule(id, Convert.ToDateTime(thuDate.Text).ToString("yyyy-MM-dd"), CustomerID, UserID, startP, endP, locationTxt.Text, locationTxt.Text, Helper.CleanString(this.detailsTxt.Text), "", thuHrs.Text, "", "Pending", Convert.ToDouble(thuCost.Text), DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), false, Helper.CompanyID, Week);

				if (ScheduleList.FindIndex(f => f.Date == Convert.ToDateTime(thuDate.Text).ToString("yyyy-MM-dd")) <= 0)
				{
					ScheduleList.Add(_event);
				}
				else
				{
					MessageBox.Show("Schedule already Exists ");
				}
			}
			else
			{
				if (ScheduleList.FindIndex(f => f.Date == Convert.ToDateTime(thuDate.Text).ToString("yyyy-MM-dd")) >= 0)
				{
					ScheduleList.RemoveAll(x => x.Date == Convert.ToDateTime(thuDate.Text).ToString("yyyy-MM-dd"));
				}

			}
		}

		private void friChk_CheckedChanged(object sender, EventArgs e)
		{
			if (friChk.Checked)
			{
				string startP = Convert.ToDateTime(friDate.Text).ToString("yyyy-MM-dd") + "T" + friStart.Text;
				string endP = Convert.ToDateTime(friDate.Text).ToString("yyyy-MM-dd") + "T" + friEnd.Text;
				DateTime start = Convert.ToDateTime(startP);
				DateTime end = Convert.ToDateTime(endP);

				var hours = (end - start).TotalHours;
				friHrs.Text = Math.Round(hours).ToString();
				friCost.Text = Cost(rateTxt.Text, friHrs.Text).ToString();

				string id = Guid.NewGuid().ToString();
				_event = new Schedule(id, Convert.ToDateTime(friDate.Text).ToString("yyyy-MM-dd"), CustomerID, UserID, startP, endP, locationTxt.Text, locationTxt.Text, Helper.CleanString(this.detailsTxt.Text), "", friHrs.Text, "", "Pending", Convert.ToDouble(friCost.Text), DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), false, Helper.CompanyID, Week);

				if (ScheduleList.FindIndex(f => f.Date == Convert.ToDateTime(friDate.Text).ToString("yyyy-MM-dd")) <= 0)
				{
					ScheduleList.Add(_event);
				}
				else
				{
					MessageBox.Show("Schedule already Exists ");
				}
			}
			else
			{
				if (ScheduleList.FindIndex(f => f.Date == Convert.ToDateTime(friDate.Text).ToString("yyyy-MM-dd")) >= 0)
				{
					ScheduleList.RemoveAll(x => x.Date == Convert.ToDateTime(friDate.Text).ToString("yyyy-MM-dd"));
				}

			}
		}

		private void satChk_CheckedChanged(object sender, EventArgs e)
		{
			if (satChk.Checked)
			{
				string startP = Convert.ToDateTime(satDate.Text).ToString("yyyy-MM-dd") + "T" + satStart.Text;
				string endP = Convert.ToDateTime(satDate.Text).ToString("yyyy-MM-dd") + "T" + satEnd.Text;
				DateTime start = Convert.ToDateTime(startP);
				DateTime end = Convert.ToDateTime(endP);

				var hours = (end - start).TotalHours;
				satHrs.Text = Math.Round(hours).ToString();
				satCost.Text = Cost(rateTxt.Text, satHrs.Text).ToString();

				string id = Guid.NewGuid().ToString();
				_event = new Schedule(id, Convert.ToDateTime(satDate.Text).ToString("yyyy-MM-dd"), CustomerID, UserID, startP, endP, locationTxt.Text, locationTxt.Text, Helper.CleanString(this.detailsTxt.Text), "", satHrs.Text, "", "Pending", Convert.ToDouble(satCost.Text), DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), false, Helper.CompanyID, Week);

				if (ScheduleList.FindIndex(f => f.Date == Convert.ToDateTime(satDate.Text).ToString("yyyy-MM-dd")) <= 0)
				{
					ScheduleList.Add(_event);
				}
				else
				{
					MessageBox.Show("Schedule already Exists ");
				}
			}
			else
			{
				if (ScheduleList.FindIndex(f => f.Date == Convert.ToDateTime(satDate.Text).ToString("yyyy-MM-dd")) >= 0)
				{
					ScheduleList.RemoveAll(x => x.Date == Convert.ToDateTime(satDate.Text).ToString("yyyy-MM-dd"));
				}

			}

		}

		private void sunChk_CheckedChanged(object sender, EventArgs e)
		{
			if (sunChk.Checked)
			{
				string startP = Convert.ToDateTime(sunDate.Text).ToString("yyyy-MM-dd") + "T" + sunStart.Text;
				string endP = Convert.ToDateTime(sunDate.Text).ToString("yyyy-MM-dd") + "T" + sunEnd.Text;
				DateTime start = Convert.ToDateTime(startP);
				DateTime end = Convert.ToDateTime(endP);

				var hours = (end - start).TotalHours;
				sunHrs.Text = Math.Round(hours).ToString();
				sunCost.Text = Cost(rateTxt.Text, sunHrs.Text).ToString();

				string id = Guid.NewGuid().ToString();
				_event = new Schedule(id, Convert.ToDateTime(sunDate.Text).ToString("yyyy-MM-dd"), CustomerID, UserID, startP, endP, locationTxt.Text, locationTxt.Text, Helper.CleanString(this.detailsTxt.Text), "", sunHrs.Text, "", "Pending", Convert.ToDouble(sunCost.Text), DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), false, Helper.CompanyID, Week);

				if (ScheduleList.FindIndex(f => f.Date == Convert.ToDateTime(sunDate.Text).ToString("yyyy-MM-dd")) <= 0)
				{
					ScheduleList.Add(_event);
				}
				else
				{
					MessageBox.Show("Schedule already Exists ");
				}
			}
			else
			{
				if (ScheduleList.FindIndex(f => f.Date == Convert.ToDateTime(sunDate.Text).ToString("yyyy-MM-dd")) >= 0)
				{
					ScheduleList.RemoveAll(x => x.Date == Convert.ToDateTime(sunDate.Text).ToString("yyyy-MM-dd"));
				}

			}
		}
	}
}

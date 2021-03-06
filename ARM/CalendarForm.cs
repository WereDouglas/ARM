﻿using ARM.DB;
using ARM.Model;
using ARM.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;

namespace ARM
{
	public partial class CalendarForm : Form
	{
		Dictionary<string, string> UserDictionary = new Dictionary<string, string>();
		string UserID;
		private List<CalendarItem> _items = new List<CalendarItem>();
		public CalendarForm()
		{
			InitializeComponent();


			AutoCompleteUser();
		}
		List<Product> items = new List<Product>();
		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		string toDate;
		string fromDate;
		private void LoadingCalendar(string type)
		{

			_items.Clear();
			List<ItemInfo> lst = new List<ItemInfo>();
			string state = "";
			string Q = "";
			if (string.IsNullOrEmpty(UserID))
			{

				Q = "SELECT * FROM schedule  WHERE `date` >= '" + fromDate + "' AND  `date` <= '" + toDate + "' ";
			}
			else
			{
				Q = "SELECT * FROM schedule  WHERE `date` >= '" + fromDate + "' AND  `date` <= '" + toDate + "' AND userID = '" + UserID + "'";

			}

			//List<Schedule> events = Schedule.List(Q);

			foreach (Schedule e in GenericCollection.schedules)
			{
				string user = "";
				try { user = GenericCollection.users.Where(r=>r.Id==e.UserID).First().Name; } catch { }
				string cus = "";
				//Customer.Select(e.CustomerID).Name;
				try { cus = GenericCollection.customers.Where(r => r.Id == e.CustomerID).First().Name;    } catch { }
				//try
				//{
				CalendarItem cal = new CalendarItem(calendar1, Convert.ToDateTime(e.Starts), Convert.ToDateTime(e.Ends), cus + " C/O " + user + " $" + e.Cost + " " + e.Details);

				Image img = Helper.Base64ToImage(GenericCollection.customers.Where(r => r.Id == e.CustomerID).First().Image.Replace('"', ' ').Trim());
				System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
				Bitmap bps = new Bitmap(bmp, 30, 30);
				Image dstImage = Helper.CropToCircle(bps, Color.White);

				cal.Image = dstImage;
				//cal.ImageAlign = CalendarItemImageAlign.East;
				cal.Tag = e.Id;

				if (e.Status == "Paid")
				{
					cal.ApplyColor(Color.LightGreen);
				}
				if (e.Status == "Pending")
				{
					cal.ApplyColor(Color.Orange);
				}
				if (e.Status == "Cancelled")
				{
					cal.ApplyColor(Color.IndianRed);
				}

				_items.Add(cal);

				//}
				//catch { }
			}
			PlaceItems();
			UserID = "";


		}
		private void PlaceItems()
		{
			calendar1.Items.Clear();
			foreach (CalendarItem item in _items)
			{
				if (calendar1.ViewIntersects(item))
				{
					if (!calendar1.Items.Contains(item))
					{
						calendar1.Items.Add(item);
					}
				}
			}
		}
		private void calendar1_ItemCreated(object sender, System.Windows.Forms.Calendar.CalendarItemCancelEventArgs e)
		{
			var start = Convert.ToDateTime(e.Item.Date).ToString("yyyy-MM-dd") + "T" + Convert.ToDateTime(e.Item.Date).ToString("HH:mm:ss");
			var end = Convert.ToDateTime(e.Item.EndDate).ToString("yyyy-MM-dd") + "T" + Convert.ToDateTime(e.Item.EndDate).ToString("HH:mm:ss");

			using (ScheduleDialog form = new ScheduleDialog(start, end, e.Item.Date.ToString()))
			{
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{
					LoadingCalendar("Status");
					monthView1_SelectionChanged(null, null);
				}
			}
		}
		private void monthView1_SelectionChanged(object sender, EventArgs e)
		{
			this.calendar1.SetViewRange(this.monthView1.SelectionStart.Date, this.monthView1.SelectionEnd.Date);
		}

		private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
		{
			PlaceItems();
			//LoadingCalendar("Status");
		}

		private void calendar1_ItemClick(object sender, CalendarItemEventArgs e)
		{
			//MessageBox.Show(e.Item.Text);
			using (StateDialog form = new StateDialog(e.Item.Tag.ToString()))
			{
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{

				}
			}
		}

		private void calendar1_ItemDeleted(object sender, CalendarItemEventArgs e)
		{
			_items.Remove(e.Item);
		}

		private void hourToolStripMenuItem_Click(object sender, EventArgs e)
		{
			calendar1.TimeScale = CalendarTimeScale.SixtyMinutes;
		}

		private void minutesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			calendar1.TimeScale = CalendarTimeScale.ThirtyMinutes;
		}

		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			calendar1.TimeScale = CalendarTimeScale.FifteenMinutes;
		}

		private void minutesToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			calendar1.TimeScale = CalendarTimeScale.SixMinutes;
		}

		private void minutesToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			calendar1.TimeScale = CalendarTimeScale.TenMinutes;
		}

		private void minutesToolStripMenuItem3_Click(object sender, EventArgs e)
		{
			calendar1.TimeScale = CalendarTimeScale.FiveMinutes;
		}

		private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
		{
			calendar1.ActivateEditMode();
		}

		private void otherColorTagToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (ColorDialog dlg = new ColorDialog())
			{
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					foreach (CalendarItem item in calendar1.GetSelectedItems())
					{
						item.ApplyColor(dlg.Color);
						calendar1.Invalidate(item);
					}
				}
			}
		}

		private void selectImageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog dlg = new OpenFileDialog())
			{
				dlg.Filter = "*.gif|*.gif|*.png|*.png|*.jpg|*.jpg";

				if (dlg.ShowDialog(this) == DialogResult.OK)
				{
					Image img = Image.FromFile(dlg.FileName);

					foreach (CalendarItem item in calendar1.GetSelectedItems())
					{
						item.Image = img;
						calendar1.Invalidate(item);
					}
				}
			}
		}

		private void noneToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (CalendarItem item in calendar1.GetSelectedItems())
			{
				item.Pattern = System.Drawing.Drawing2D.HatchStyle.DiagonalCross;
				item.PatternColor = Color.Empty;
				calendar1.Invalidate(item);
			}
		}

		private void diagonalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (CalendarItem item in calendar1.GetSelectedItems())
			{
				item.Pattern = System.Drawing.Drawing2D.HatchStyle.ForwardDiagonal;
				item.PatternColor = Color.Red;
				calendar1.Invalidate(item);
			}
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			using (ScheduleDialog form = new ScheduleDialog(null, null, null))
			{
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			fromDate = Convert.ToDateTime(fromDateTxt.Text).ToString("yyyy-MM-dd");
			toDate = Convert.ToDateTime(toDateTxt.Text).ToString("yyyy-MM-dd");
			LoadingWindow.ShowSplashScreen();
			LoadingCalendar("Status");
			LoadingWindow.CloseForm();
		}

		Users u;
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
			try
			{
				LoadingCalendar("");
			}
			catch
			{
				MessageBox.Show("No values for the selected period  ");
			}
		}

		private void CalendarForm_Load(object sender, EventArgs e)
		{
			LoadingWindow.ShowSplashScreen();
			fromDateTxt.Text = fromDate = DateTime.Now.AddDays(-15).ToString("yyyy-MM-dd");
			toDateTxt.Text = toDate = DateTime.Now.AddDays(15).ToString("yyyy-MM-dd");

			LoadingCalendar("Status");
			LoadingWindow.CloseForm();
			this.calendar1.SetViewRange(DateTime.Now.AddDays(-7).Date, DateTime.Now.AddDays(7).Date);
		}

		private void calendar1_DayHeaderClick(object sender, CalendarDayEventArgs e)
		{
			calendar1.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);
		}
	}
}

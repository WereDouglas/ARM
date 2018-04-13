using ARM.DB;
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
        private List<CalendarItem> _items = new List<CalendarItem>();
        public CalendarForm()
        {
            InitializeComponent();
            LoadingCalendar();
        }
        List<Item> items = new List<Item>();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadingCalendar()
        {

            _items.Clear();
            List<ItemInfo> lst = new List<ItemInfo>();
            string state = "";

            List<Schedule> events = Schedule.List();

            foreach (Schedule e in events)
            {
                string user = "";
                try { user = Users.Select(e.UserID).Name; } catch { }
                string cus = "";
                try { cus = Customer.Select(e.UserID).Name; } catch { }
                try
                {
                    CalendarItem cal = new CalendarItem(calendar1, Convert.ToDateTime(e.Starts), Convert.ToDateTime(e.Ends), user + " " + cus + " " + e.Cost + " " + e.Details);

                    if (e.Category == "Shift")
                    {
                        cal.ApplyColor(Color.LightGreen);
                    }
                    else
                    {
                        cal.ApplyColor(Color.Salmon);
                    }
                    //if (state == "Medium") { cal.ApplyColor(Color.LightGreen); }
                    //if (state == "Low") { cal.ApplyColor(Color.CornflowerBlue); }
                    //if (state == "High") { cal.ApplyColor(Color.Salmon); }
                    // if (state == "none") { cal.ApplyColor(Color.LightSeaGreen); }

                    _items.Add(cal);

                }
                catch { }
            }
            PlaceItems();

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
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {

                }
            }
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            this.calendar1.SetViewRange(this.monthView1.SelectionStart.Date, this.monthView1.SelectionEnd.Date);
        }
    }
}

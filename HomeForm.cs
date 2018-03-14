using ARM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsCalendar;

namespace ARM
{
    public partial class HomeForm : MetroFramework.Forms.MetroForm
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (NewAppointment form = new NewAppointment(null, null, null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //tabControl1.SelectedTab = saleTab;
                    //string query2 = "SELECT * FROM sale WHERE date= '" + Helper.CurrentYear + "'";
                    //this.SaleBindingSource.DataSource = Sale.List(query2);
                    //reportViewer1.RefreshReport();


                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        /**dealing with calendar issues */
        public static List<Schedule> events;
        private List<CalendarItem> _items = new List<CalendarItem>();

        Schedule _event;
        private void calendar1_ItemCreated(object sender, WindowsFormsCalendar.CalendarItemCancelEventArgs e)
        {
            var start = Convert.ToDateTime(e.Item.Date).ToString("yyyy-MM-dd") + "T" + Convert.ToDateTime(e.Item.Date).ToString("HH:mm:ss");
            var end = Convert.ToDateTime(e.Item.EndDate).ToString("yyyy-MM-dd") + "T" + Convert.ToDateTime(e.Item.EndDate).ToString("HH:mm:ss");

            using (NewAppointment form = new NewAppointment(start, end, e.Item.Date.ToString()))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // LoadingCalendarLite();
                }
            }
        }
        private void LoadingCalendarLite()
        {

            _items.Clear();
            List<ItemInfo> lst = new List<ItemInfo>();
            string state = "";

            List<Schedule> events = Model.Schedule.List();

            foreach (Schedule e in events)
            {
                try
                {
                    CalendarItem cal = new CalendarItem(calendar1, Convert.ToDateTime(e.Starts), Convert.ToDateTime(e.Ends), e.EmpID + " " + e.EmpID + " " + e.Starts + "" + e.Details);

                    if (e.Indicator == " ")
                    {
                        state = "none";
                    }
                    else
                    {
                        state = e.Indicator;
                    }
                    if (state == "Medium") { cal.ApplyColor(Color.LightGreen); }
                    if (state == "Low") { cal.ApplyColor(Color.CornflowerBlue); }
                    if (state == "High") { cal.ApplyColor(Color.Salmon); }
                    if (state == "none") { cal.ApplyColor(Color.LightSeaGreen); }

                    _items.Add(cal);

                    // t.Rows.Add(new object[] { Reader.GetString(0), Helper.ImageFolder + Reader.GetString(8), b, Reader.GetString(2), Reader.GetString(3), Reader.GetString(7), Reader.GetString(5), Reader.GetString(9), Reader.GetString(14) + "", Reader.GetString(6), "" + Reader.GetString(13) + "" });
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

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            this.calendar1.SetViewRange(this.monthView1.SelectionStart.Date, this.monthView1.SelectionEnd.Date);

        }
    }
}

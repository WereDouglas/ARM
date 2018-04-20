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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ARM
{
    public partial class LoadingWindow : MetroFramework.Forms.MetroForm
    {
        private delegate void CloseDelegate();
        private static LoadingWindow splashForm;
        public LoadingWindow()
        {
            InitializeComponent();

        }
        static public void ShowSplashScreen()
        {
            // Make sure it is only launched once.           
            Thread thread = new Thread(new ThreadStart(LoadingWindow.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        static private void ShowForm()
        {
            splashForm = new LoadingWindow();
            Application.Run(splashForm);
        }

        static public void CloseForm()
        {
            try
            {
                splashForm.Invoke(new CloseDelegate(LoadingWindow.CloseFormInternal));
            }
            catch { }
        }

        static private void CloseFormInternal()
        {
            splashForm.Close();
        }

        private void LoadingWindow_Load(object sender, EventArgs e)
        {

        }

    }
}

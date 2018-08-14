using ARM.DB;
using ARM.Sync;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
	public partial class ProcessWindow : Form
	{
		private delegate void CloseDelegate();
		private static ProcessWindow splashForm;
		public static ProcessWindow _Form1;
		private BackgroundWorker backgroundWorker = new BackgroundWorker();
		public ProcessWindow()
		{
			InitializeComponent();
			_Form1 = this;
			backgroundWorker.DoWork += backgroundWorker1_DoWork;
			backgroundWorker.ProgressChanged += backgroundWorker1_ProgressChanged;
			backgroundWorker.WorkerReportsProgress = true;
			if (!backgroundWorker.IsBusy)
			{
				InitializeCulture();
				backgroundWorker.RunWorkerAsync();
				return;
			}
			else
			{
				MessageBox.Show("Processing ....................");
			}
		}
		static protected void InitializeCulture()
		{
			CultureInfo CI = new CultureInfo("en-Gb");
			CI.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";

			Thread.CurrentThread.CurrentCulture = CI;
			Thread.CurrentThread.CurrentUICulture = CI;
			//  base.InitializeCulture();
		}
		static public void ShowSplashScreen()
		{
			// Make sure it is only launched once.           
			Thread thread = new Thread(new ThreadStart(ProcessWindow.ShowForm));
			thread.IsBackground = true;
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();

		}
		private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{

			if (MySQL.Open())
			{
				for (int i = 0; i <= 5; i++)
				{
					FeedBack("PROCESS " + i.ToString());
					process(i); backgroundWorker.ReportProgress(i);
					Thread.Sleep(1500);
					if (i == 5)
					{
						FeedBack("complete");
					}
				}
			}
			else
			{
				FeedBack("No internet connection ");
				backgroundWorker.Dispose();
				FeedBack("complete");
			}

		}
		private void process(int count)
		{
			int val = count;
			switch (val)
			{
				case 1:
					Downloading.Schedules();
					break;
				case 2:
					Downloading.User();
					break;
				case 3:
					Downloading.Customers();
					break;
				case 4:
					Downloading.Coverages();
					break;
				case 5:
					Downloading.Rates();
					break;
				case 6:
					Downloading.Responsibles();
					break;
				case 7:
					Downloading.Accounts();
					break;
				case 8:
					Downloading.Responsibles();
					break;
				case 14:
					Downloading.Practitioners();
					break;
				case 15:
					Downloading.Emergencies();
					break;
				case 16:
					Downloading.Pays();
					break;
				case 17:
					// Downloading.CaseTransactions();
					break;
				case 18:
					//  Uploading.Payments();
					break;
				case 19:
					// Downloading.Payments();
					break;
				case 20:
					// Uploading.Order();
					break;
				case 21:
					// Downloading.Order();
					break;
				case 22:
					// Uploading.Instructions();
					break;
				case 23:
					// Downloading.Instructions();
					break;
				case 24:
					// Uploading.Follows();
					break;
				case 25:
					//  Downloading.Follows();//.SendEmail();
					break;
				case 26:
					// Uploading.ItemReviews();
					break;
				case 27:
					// Downloading.ItemReviews();
					break;
				case 28:
					// Uploading.Vendors();
					break;
				case 29:
					//  Downloading.Vendors();
					break;
				case 30:
					// Uploading.ItemStatuses();
					break;
				case 31:
					//  Downloading.ItemStatuses();
					break;
				case 32:
					// Uploading.Rates();
					break;
				case 33:
					// Downloading.Rates();
					break;
				case 34:
					//  Uploading.Accounts();
					break;
				case 35:
					// Downloading.Accounts();
					break;
				case 36:
					//  Uploading.Repsonsibles();
					break;
				case 37:
					// Downloading.Repsonsibles();
					break;
				case 38:
					// Uploading.Insurances();
					break;
				case 39:
					//  Downloading.Coverages();
					break;
				case 41:

					if (DBConnect.CloseMySqlConn())
					{
						FeedBack("Uploading and Downloading of information complete");
						backgroundWorker.Dispose();
						return;
					}
					else
					{
						FeedBack("No valid connection ");
					}
					break;
				case 42:

					break;
				default:
					FeedBack("Processing");
					break;
			}

		}


		private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			try
			{
				progressBar1.Value = e.ProgressPercentage;
			}
			catch { }
		}
		public void FeedBack(string text)
		{
			try
			{
				Invoke((MethodInvoker)delegate
				{
					// processLbl.Text = "Last:  " + Helper.lastSync;
					processLbl.Text = processLbl.Text + text + "\r\n";
					processLbl.ForeColor = Color.White;
				});
				if (text == "complete")
				{
					this.DialogResult = DialogResult.OK;
					this.Dispose();
				}
			}
			catch
			{


			}



		}
		static private void ShowForm()
		{
			splashForm = new ProcessWindow();
			Application.Run(splashForm);
		}
		static public void CloseForm()
		{
			try
			{
				splashForm.Invoke(new CloseDelegate(ProcessWindow.CloseFormInternal));
			}
			catch
			{


			}
		}

		static private void CloseFormInternal()
		{
			splashForm.Close();
		}

		
		private void processLbl_TextChanged_1(object sender, EventArgs e)
		{
			processLbl.SelectionStart = processLbl.Text.Length;
			processLbl.ScrollToCaret();
		}
	}
}

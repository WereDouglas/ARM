namespace ARM
{
    partial class PurchaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.htmlToolTip1 = new MetroFramework.Drawing.Html.HtmlToolTip();
            this.calendar1 = new WindowsFormsCalendar.Calendar();
            this.SuspendLayout();
            // 
            // htmlToolTip1
            // 
            this.htmlToolTip1.OwnerDraw = true;
            // 
            // calendar1
            // 
            this.calendar1.AllowDrop = true;
            this.calendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendar1.BackColor = System.Drawing.Color.White;
            this.calendar1.CalendarTimeFormat = WindowsFormsCalendar.CalendarTimeFormat.TwentyFourHour;
            this.calendar1.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.calendar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.calendar1.ItemsBackgroundColor = System.Drawing.Color.DimGray;
            this.calendar1.ItemsFont = new System.Drawing.Font("Trebuchet MS", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendar1.ItemsForeColor = System.Drawing.Color.Silver;
            this.calendar1.Location = new System.Drawing.Point(14, 63);
            this.calendar1.MaximumFullDays = 31;
            this.calendar1.Name = "calendar1";
            this.calendar1.Scrollbars = WindowsFormsCalendar.CalendarScrollBars.Vertical;
            this.calendar1.Size = new System.Drawing.Size(1247, 668);
            this.calendar1.TabIndex = 6;
            this.calendar1.Text = "calendar1";
            this.calendar1.TimeScale = WindowsFormsCalendar.CalendarTimeScale.SixtyMinutes;
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 754);
            this.Controls.Add(this.calendar1);
            this.Name = "PurchaseForm";
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = " Purchase Order";
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Drawing.Html.HtmlToolTip htmlToolTip1;
        private WindowsFormsCalendar.Calendar calendar1;
    }
}
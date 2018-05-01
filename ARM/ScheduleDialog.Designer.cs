namespace ARM
{
    partial class ScheduleDialog
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
            this.categoryCbx = new MetroFramework.Controls.MetroComboBox();
            this.openedDate = new MetroFramework.Controls.MetroDateTime();
            this.customerCbx = new MetroFramework.Controls.MetroComboBox();
            this.userCbx = new MetroFramework.Controls.MetroComboBox();
            this.statusCbx = new MetroFramework.Controls.MetroComboBox();
            this.startHrTxt = new System.Windows.Forms.DateTimePicker();
            this.endHrTxt = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalTxt = new MetroFramework.Controls.MetroTextBox();
            this.locationTxt = new MetroFramework.Controls.MetroTextBox();
            this.periodTxt = new MetroFramework.Controls.MetroTextBox();
            this.userPbx = new System.Windows.Forms.PictureBox();
            this.cusPbx = new System.Windows.Forms.PictureBox();
            this.costTxt = new MetroFramework.Controls.MetroTextBox();
            this.detailsTxt = new MetroFramework.Controls.MetroTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.repeatCbx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.endDate = new MetroFramework.Controls.MetroDateTime();
            this.offListBx = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userPbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusPbx)).BeginInit();
            this.SuspendLayout();
            // 
            // htmlToolTip1
            // 
            this.htmlToolTip1.OwnerDraw = true;
            // 
            // categoryCbx
            // 
            this.categoryCbx.FormattingEnabled = true;
            this.categoryCbx.ItemHeight = 23;
            this.categoryCbx.Items.AddRange(new object[] {
            "Shift",
            "Appointment"});
            this.categoryCbx.Location = new System.Drawing.Point(123, 202);
            this.categoryCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.categoryCbx.Name = "categoryCbx";
            this.categoryCbx.PromptText = "Shift/Appointment";
            this.categoryCbx.Size = new System.Drawing.Size(339, 29);
            this.categoryCbx.TabIndex = 4;
            this.categoryCbx.UseSelectable = true;
            this.categoryCbx.SelectedIndexChanged += new System.EventHandler(this.categoryCbx_SelectedIndexChanged);
            // 
            // openedDate
            // 
            this.openedDate.AllowDrop = true;
            this.openedDate.Location = new System.Drawing.Point(123, 137);
            this.openedDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.openedDate.Name = "openedDate";
            this.openedDate.Size = new System.Drawing.Size(211, 29);
            this.openedDate.TabIndex = 0;
            // 
            // customerCbx
            // 
            this.customerCbx.FormattingEnabled = true;
            this.customerCbx.ItemHeight = 23;
            this.customerCbx.Location = new System.Drawing.Point(123, 99);
            this.customerCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customerCbx.Name = "customerCbx";
            this.customerCbx.PromptText = "Patient";
            this.customerCbx.Size = new System.Drawing.Size(339, 29);
            this.customerCbx.TabIndex = 1;
            this.customerCbx.UseSelectable = true;
            this.customerCbx.SelectedIndexChanged += new System.EventHandler(this.customerCbx_SelectedIndexChanged);
            // 
            // userCbx
            // 
            this.userCbx.FormattingEnabled = true;
            this.userCbx.ItemHeight = 23;
            this.userCbx.Location = new System.Drawing.Point(123, 280);
            this.userCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userCbx.Name = "userCbx";
            this.userCbx.PromptText = "Physician";
            this.userCbx.Size = new System.Drawing.Size(339, 29);
            this.userCbx.TabIndex = 6;
            this.userCbx.UseSelectable = true;
            this.userCbx.SelectedIndexChanged += new System.EventHandler(this.userCbx_SelectedIndexChanged);
            // 
            // statusCbx
            // 
            this.statusCbx.FormattingEnabled = true;
            this.statusCbx.ItemHeight = 23;
            this.statusCbx.Items.AddRange(new object[] {
            "Paid",
            "Pending",
            "Cancelled"});
            this.statusCbx.Location = new System.Drawing.Point(123, 415);
            this.statusCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.statusCbx.Name = "statusCbx";
            this.statusCbx.PromptText = "Status";
            this.statusCbx.Size = new System.Drawing.Size(339, 29);
            this.statusCbx.TabIndex = 9;
            this.statusCbx.UseSelectable = true;
            // 
            // startHrTxt
            // 
            this.startHrTxt.CalendarFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startHrTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startHrTxt.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startHrTxt.Location = new System.Drawing.Point(350, 139);
            this.startHrTxt.Name = "startHrTxt";
            this.startHrTxt.ShowUpDown = true;
            this.startHrTxt.Size = new System.Drawing.Size(112, 27);
            this.startHrTxt.TabIndex = 2;
            // 
            // endHrTxt
            // 
            this.endHrTxt.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.endHrTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endHrTxt.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endHrTxt.Location = new System.Drawing.Point(350, 172);
            this.endHrTxt.Name = "endHrTxt";
            this.endHrTxt.ShowUpDown = true;
            this.endHrTxt.Size = new System.Drawing.Size(112, 27);
            this.endHrTxt.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(45, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 19);
            this.label1.TabIndex = 186;
            this.label1.Text = "Start:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(45, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 19);
            this.label2.TabIndex = 187;
            this.label2.Text = "End:";
            // 
            // totalTxt
            // 
            // 
            // 
            // 
            this.totalTxt.CustomButton.Image = null;
            this.totalTxt.CustomButton.Location = new System.Drawing.Point(305, 1);
            this.totalTxt.CustomButton.Name = "";
            this.totalTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.totalTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.totalTxt.CustomButton.TabIndex = 1;
            this.totalTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.totalTxt.CustomButton.UseSelectable = true;
            this.totalTxt.CustomButton.Visible = false;
            this.totalTxt.DisplayIcon = true;
            this.totalTxt.Icon = global::ARM.Properties.Resources.Layers_01_16;
            this.totalTxt.Lines = new string[0];
            this.totalTxt.Location = new System.Drawing.Point(123, 376);
            this.totalTxt.MaxLength = 32767;
            this.totalTxt.Name = "totalTxt";
            this.totalTxt.PasswordChar = '\0';
            this.totalTxt.PromptText = "Total Charge";
            this.totalTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.totalTxt.SelectedText = "";
            this.totalTxt.SelectionLength = 0;
            this.totalTxt.SelectionStart = 0;
            this.totalTxt.ShortcutsEnabled = true;
            this.totalTxt.Size = new System.Drawing.Size(339, 35);
            this.totalTxt.TabIndex = 8;
            this.totalTxt.UseSelectable = true;
            this.totalTxt.WaterMark = "Total Charge";
            this.totalTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.totalTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.totalTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.periodTxt_KeyPress);
            // 
            // locationTxt
            // 
            // 
            // 
            // 
            this.locationTxt.CustomButton.Image = null;
            this.locationTxt.CustomButton.Location = new System.Drawing.Point(289, 2);
            this.locationTxt.CustomButton.Name = "";
            this.locationTxt.CustomButton.Size = new System.Drawing.Size(47, 47);
            this.locationTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.locationTxt.CustomButton.TabIndex = 1;
            this.locationTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.locationTxt.CustomButton.UseSelectable = true;
            this.locationTxt.CustomButton.Visible = false;
            this.locationTxt.DisplayIcon = true;
            this.locationTxt.Icon = global::ARM.Properties.Resources.Map_Location_24;
            this.locationTxt.Lines = new string[0];
            this.locationTxt.Location = new System.Drawing.Point(123, 497);
            this.locationTxt.MaxLength = 32767;
            this.locationTxt.Multiline = true;
            this.locationTxt.Name = "locationTxt";
            this.locationTxt.PasswordChar = '\0';
            this.locationTxt.PromptText = "Location";
            this.locationTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.locationTxt.SelectedText = "";
            this.locationTxt.SelectionLength = 0;
            this.locationTxt.SelectionStart = 0;
            this.locationTxt.ShortcutsEnabled = true;
            this.locationTxt.Size = new System.Drawing.Size(339, 52);
            this.locationTxt.TabIndex = 11;
            this.locationTxt.UseSelectable = true;
            this.locationTxt.WaterMark = "Location";
            this.locationTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.locationTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // periodTxt
            // 
            // 
            // 
            // 
            this.periodTxt.CustomButton.Image = null;
            this.periodTxt.CustomButton.Location = new System.Drawing.Point(305, 1);
            this.periodTxt.CustomButton.Name = "";
            this.periodTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.periodTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.periodTxt.CustomButton.TabIndex = 1;
            this.periodTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.periodTxt.CustomButton.UseSelectable = true;
            this.periodTxt.CustomButton.Visible = false;
            this.periodTxt.DisplayIcon = true;
            this.periodTxt.Icon = global::ARM.Properties.Resources.Clock_01_24;
            this.periodTxt.Lines = new string[0];
            this.periodTxt.Location = new System.Drawing.Point(123, 238);
            this.periodTxt.MaxLength = 32767;
            this.periodTxt.Name = "periodTxt";
            this.periodTxt.PasswordChar = '\0';
            this.periodTxt.PromptText = "Period";
            this.periodTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.periodTxt.SelectedText = "";
            this.periodTxt.SelectionLength = 0;
            this.periodTxt.SelectionStart = 0;
            this.periodTxt.ShortcutsEnabled = true;
            this.periodTxt.Size = new System.Drawing.Size(339, 35);
            this.periodTxt.TabIndex = 5;
            this.periodTxt.UseSelectable = true;
            this.periodTxt.WaterMark = "Period";
            this.periodTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.periodTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.periodTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.periodTxt_KeyPress);
            // 
            // userPbx
            // 
            this.userPbx.Image = global::ARM.Properties.Resources.User_Profile_128;
            this.userPbx.Location = new System.Drawing.Point(49, 280);
            this.userPbx.Name = "userPbx";
            this.userPbx.Size = new System.Drawing.Size(68, 40);
            this.userPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userPbx.TabIndex = 179;
            this.userPbx.TabStop = false;
            // 
            // cusPbx
            // 
            this.cusPbx.Image = global::ARM.Properties.Resources.User_Profile_128;
            this.cusPbx.Location = new System.Drawing.Point(49, 96);
            this.cusPbx.Name = "cusPbx";
            this.cusPbx.Size = new System.Drawing.Size(68, 46);
            this.cusPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cusPbx.TabIndex = 178;
            this.cusPbx.TabStop = false;
            // 
            // costTxt
            // 
            // 
            // 
            // 
            this.costTxt.CustomButton.Image = null;
            this.costTxt.CustomButton.Location = new System.Drawing.Point(305, 1);
            this.costTxt.CustomButton.Name = "";
            this.costTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.costTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.costTxt.CustomButton.TabIndex = 1;
            this.costTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.costTxt.CustomButton.UseSelectable = true;
            this.costTxt.CustomButton.Visible = false;
            this.costTxt.DisplayIcon = true;
            this.costTxt.Icon = global::ARM.Properties.Resources.Layers_01_16;
            this.costTxt.Lines = new string[0];
            this.costTxt.Location = new System.Drawing.Point(123, 454);
            this.costTxt.MaxLength = 32767;
            this.costTxt.Name = "costTxt";
            this.costTxt.PasswordChar = '\0';
            this.costTxt.PromptText = "Rate/Hr";
            this.costTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.costTxt.SelectedText = "";
            this.costTxt.SelectionLength = 0;
            this.costTxt.SelectionStart = 0;
            this.costTxt.ShortcutsEnabled = true;
            this.costTxt.Size = new System.Drawing.Size(339, 35);
            this.costTxt.TabIndex = 10;
            this.costTxt.UseSelectable = true;
            this.costTxt.WaterMark = "Rate/Hr";
            this.costTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.costTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.costTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.periodTxt_KeyPress);
            // 
            // detailsTxt
            // 
            // 
            // 
            // 
            this.detailsTxt.CustomButton.Image = null;
            this.detailsTxt.CustomButton.Location = new System.Drawing.Point(293, 1);
            this.detailsTxt.CustomButton.Name = "";
            this.detailsTxt.CustomButton.Size = new System.Drawing.Size(45, 45);
            this.detailsTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.detailsTxt.CustomButton.TabIndex = 1;
            this.detailsTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.detailsTxt.CustomButton.UseSelectable = true;
            this.detailsTxt.CustomButton.Visible = false;
            this.detailsTxt.DisplayIcon = true;
            this.detailsTxt.Icon = global::ARM.Properties.Resources.Receipt_24;
            this.detailsTxt.Lines = new string[0];
            this.detailsTxt.Location = new System.Drawing.Point(123, 316);
            this.detailsTxt.MaxLength = 32767;
            this.detailsTxt.Multiline = true;
            this.detailsTxt.Name = "detailsTxt";
            this.detailsTxt.PasswordChar = '\0';
            this.detailsTxt.PromptText = "Details";
            this.detailsTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.detailsTxt.SelectedText = "";
            this.detailsTxt.SelectionLength = 0;
            this.detailsTxt.SelectionStart = 0;
            this.detailsTxt.ShortcutsEnabled = true;
            this.detailsTxt.Size = new System.Drawing.Size(339, 47);
            this.detailsTxt.TabIndex = 7;
            this.detailsTxt.UseSelectable = true;
            this.detailsTxt.WaterMark = "Details";
            this.detailsTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.detailsTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Image = global::ARM.Properties.Resources.Submit_01_32;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(350, 589);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button3.Size = new System.Drawing.Size(108, 49);
            this.button3.TabIndex = 12;
            this.button3.Text = "Submit";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Image = global::ARM.Properties.Resources.Cancel_48;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(135, 598);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(108, 49);
            this.button2.TabIndex = 13;
            this.button2.Text = "Cancel";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // repeatCbx
            // 
            this.repeatCbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatCbx.FormattingEnabled = true;
            this.repeatCbx.Items.AddRange(new object[] {
            "1",
            "7",
            "30",
            "120",
            "240"});
            this.repeatCbx.Location = new System.Drawing.Point(123, 555);
            this.repeatCbx.Name = "repeatCbx";
            this.repeatCbx.Size = new System.Drawing.Size(339, 28);
            this.repeatCbx.TabIndex = 189;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(34, 564);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 190;
            this.label3.Text = "No of Days";
            // 
            // endDate
            // 
            this.endDate.AllowDrop = true;
            this.endDate.Location = new System.Drawing.Point(123, 169);
            this.endDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(211, 29);
            this.endDate.TabIndex = 191;
            this.endDate.ValueChanged += new System.EventHandler(this.endDate_ValueChanged);
            // 
            // offListBx
            // 
            this.offListBx.FormattingEnabled = true;
            this.offListBx.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday ",
            "Friday",
            "Saturday",
            "Sunday"});
            this.offListBx.Location = new System.Drawing.Point(468, 380);
            this.offListBx.Name = "offListBx";
            this.offListBx.Size = new System.Drawing.Size(211, 109);
            this.offListBx.TabIndex = 192;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(468, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 19);
            this.label4.TabIndex = 193;
            this.label4.Text = "Select off days";
            // 
            // ScheduleDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 661);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.offListBx);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.repeatCbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endHrTxt);
            this.Controls.Add(this.startHrTxt);
            this.Controls.Add(this.totalTxt);
            this.Controls.Add(this.locationTxt);
            this.Controls.Add(this.periodTxt);
            this.Controls.Add(this.statusCbx);
            this.Controls.Add(this.userPbx);
            this.Controls.Add(this.cusPbx);
            this.Controls.Add(this.userCbx);
            this.Controls.Add(this.customerCbx);
            this.Controls.Add(this.openedDate);
            this.Controls.Add(this.categoryCbx);
            this.Controls.Add(this.costTxt);
            this.Controls.Add(this.detailsTxt);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Name = "ScheduleDialog";
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "Scheduling";
            this.Load += new System.EventHandler(this.ScheduleDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userPbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusPbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Drawing.Html.HtmlToolTip htmlToolTip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private MetroFramework.Controls.MetroTextBox costTxt;
        private MetroFramework.Controls.MetroTextBox detailsTxt;
        private MetroFramework.Controls.MetroComboBox categoryCbx;
        private MetroFramework.Controls.MetroDateTime openedDate;
        private MetroFramework.Controls.MetroComboBox customerCbx;
        private MetroFramework.Controls.MetroComboBox userCbx;
        private System.Windows.Forms.PictureBox cusPbx;
        private System.Windows.Forms.PictureBox userPbx;
        private MetroFramework.Controls.MetroComboBox statusCbx;
        private MetroFramework.Controls.MetroTextBox periodTxt;
        private MetroFramework.Controls.MetroTextBox locationTxt;
        private MetroFramework.Controls.MetroTextBox totalTxt;
        private System.Windows.Forms.DateTimePicker startHrTxt;
        private System.Windows.Forms.DateTimePicker endHrTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox repeatCbx;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroDateTime endDate;
        private System.Windows.Forms.CheckedListBox offListBx;
        private System.Windows.Forms.Label label4;
    }
}
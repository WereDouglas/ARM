namespace ARM
{
    partial class PractitionerDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PractitionerDialog));
            this.htmlToolTip1 = new MetroFramework.Drawing.Html.HtmlToolTip();
            this.categoryCbx = new MetroFramework.Controls.MetroComboBox();
            this.fileUrlTxtBx = new System.Windows.Forms.TextBox();
            this.genderCbx = new MetroFramework.Controls.MetroComboBox();
            this.zipTxt = new MetroFramework.Controls.MetroTextBox();
            this.stateTxt = new MetroFramework.Controls.MetroTextBox();
            this.cityTxt = new MetroFramework.Controls.MetroTextBox();
            this.addressTxt = new MetroFramework.Controls.MetroTextBox();
            this.contactTxt = new MetroFramework.Controls.MetroTextBox();
            this.nameTxt = new MetroFramework.Controls.MetroTextBox();
            this.emailTxt = new MetroFramework.Controls.MetroTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.imgCapture = new System.Windows.Forms.PictureBox();
            this.npiTxt = new MetroFramework.Controls.MetroTextBox();
            this.officeTxt = new MetroFramework.Controls.MetroTextBox();
            this.specialityTxt = new MetroFramework.Controls.MetroTextBox();
            this.idTxt = new MetroFramework.Controls.MetroTextBox();
            this.tinTxt = new MetroFramework.Controls.MetroTextBox();
            this.faxTxt = new MetroFramework.Controls.MetroTextBox();
            this.officePhoneTxt = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.updateBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).BeginInit();
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
            "Administrator",
            "Physician",
            "Employee",
            "Other"});
            this.categoryCbx.Location = new System.Drawing.Point(294, 256);
            this.categoryCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.categoryCbx.Name = "categoryCbx";
            this.categoryCbx.PromptText = "Category/type";
            this.categoryCbx.Size = new System.Drawing.Size(180, 29);
            this.categoryCbx.TabIndex = 3;
            this.categoryCbx.UseSelectable = true;
            // 
            // fileUrlTxtBx
            // 
            this.fileUrlTxtBx.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.fileUrlTxtBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileUrlTxtBx.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileUrlTxtBx.Location = new System.Drawing.Point(63, 550);
            this.fileUrlTxtBx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileUrlTxtBx.Name = "fileUrlTxtBx";
            this.fileUrlTxtBx.Size = new System.Drawing.Size(411, 14);
            this.fileUrlTxtBx.TabIndex = 15;
            this.fileUrlTxtBx.Visible = false;
            // 
            // genderCbx
            // 
            this.genderCbx.FormattingEnabled = true;
            this.genderCbx.ItemHeight = 23;
            this.genderCbx.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.genderCbx.Location = new System.Drawing.Point(58, 508);
            this.genderCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.genderCbx.Name = "genderCbx";
            this.genderCbx.PromptText = "Gender";
            this.genderCbx.Size = new System.Drawing.Size(219, 29);
            this.genderCbx.TabIndex = 10;
            this.genderCbx.UseSelectable = true;
            // 
            // zipTxt
            // 
            // 
            // 
            // 
            this.zipTxt.CustomButton.Image = null;
            this.zipTxt.CustomButton.Location = new System.Drawing.Point(187, 1);
            this.zipTxt.CustomButton.Name = "";
            this.zipTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.zipTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.zipTxt.CustomButton.TabIndex = 1;
            this.zipTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.zipTxt.CustomButton.UseSelectable = true;
            this.zipTxt.CustomButton.Visible = false;
            this.zipTxt.DisplayIcon = true;
            this.zipTxt.Icon = global::ARM.Properties.Resources.Map_24;
            this.zipTxt.Lines = new string[0];
            this.zipTxt.Location = new System.Drawing.Point(56, 426);
            this.zipTxt.MaxLength = 32767;
            this.zipTxt.Name = "zipTxt";
            this.zipTxt.PasswordChar = '\0';
            this.zipTxt.PromptText = "Zip code";
            this.zipTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.zipTxt.SelectedText = "";
            this.zipTxt.SelectionLength = 0;
            this.zipTxt.SelectionStart = 0;
            this.zipTxt.ShortcutsEnabled = true;
            this.zipTxt.Size = new System.Drawing.Size(221, 35);
            this.zipTxt.TabIndex = 9;
            this.zipTxt.UseSelectable = true;
            this.zipTxt.WaterMark = "Zip code";
            this.zipTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.zipTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.zipTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zipTxt_KeyPress);
            // 
            // stateTxt
            // 
            // 
            // 
            // 
            this.stateTxt.CustomButton.Image = null;
            this.stateTxt.CustomButton.Location = new System.Drawing.Point(185, 1);
            this.stateTxt.CustomButton.Name = "";
            this.stateTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.stateTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.stateTxt.CustomButton.TabIndex = 1;
            this.stateTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.stateTxt.CustomButton.UseSelectable = true;
            this.stateTxt.CustomButton.Visible = false;
            this.stateTxt.DisplayIcon = true;
            this.stateTxt.Icon = global::ARM.Properties.Resources.Globe_24;
            this.stateTxt.Lines = new string[0];
            this.stateTxt.Location = new System.Drawing.Point(58, 467);
            this.stateTxt.MaxLength = 32767;
            this.stateTxt.Name = "stateTxt";
            this.stateTxt.PasswordChar = '\0';
            this.stateTxt.PromptText = "State";
            this.stateTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stateTxt.SelectedText = "";
            this.stateTxt.SelectionLength = 0;
            this.stateTxt.SelectionStart = 0;
            this.stateTxt.ShortcutsEnabled = true;
            this.stateTxt.Size = new System.Drawing.Size(219, 35);
            this.stateTxt.TabIndex = 8;
            this.stateTxt.UseSelectable = true;
            this.stateTxt.WaterMark = "State";
            this.stateTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.stateTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cityTxt
            // 
            // 
            // 
            // 
            this.cityTxt.CustomButton.Image = null;
            this.cityTxt.CustomButton.Location = new System.Drawing.Point(189, 1);
            this.cityTxt.CustomButton.Name = "";
            this.cityTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.cityTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.cityTxt.CustomButton.TabIndex = 1;
            this.cityTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cityTxt.CustomButton.UseSelectable = true;
            this.cityTxt.CustomButton.Visible = false;
            this.cityTxt.DisplayIcon = true;
            this.cityTxt.Icon = global::ARM.Properties.Resources.City_24__1_;
            this.cityTxt.Lines = new string[0];
            this.cityTxt.Location = new System.Drawing.Point(58, 384);
            this.cityTxt.MaxLength = 32767;
            this.cityTxt.Name = "cityTxt";
            this.cityTxt.PasswordChar = '\0';
            this.cityTxt.PromptText = "City";
            this.cityTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.cityTxt.SelectedText = "";
            this.cityTxt.SelectionLength = 0;
            this.cityTxt.SelectionStart = 0;
            this.cityTxt.ShortcutsEnabled = true;
            this.cityTxt.Size = new System.Drawing.Size(223, 35);
            this.cityTxt.TabIndex = 7;
            this.cityTxt.UseSelectable = true;
            this.cityTxt.WaterMark = "City";
            this.cityTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cityTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // addressTxt
            // 
            // 
            // 
            // 
            this.addressTxt.CustomButton.Image = null;
            this.addressTxt.CustomButton.Location = new System.Drawing.Point(179, 1);
            this.addressTxt.CustomButton.Name = "";
            this.addressTxt.CustomButton.Size = new System.Drawing.Size(43, 43);
            this.addressTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.addressTxt.CustomButton.TabIndex = 1;
            this.addressTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.addressTxt.CustomButton.UseSelectable = true;
            this.addressTxt.CustomButton.Visible = false;
            this.addressTxt.DisplayIcon = true;
            this.addressTxt.Icon = global::ARM.Properties.Resources.Map_Location_24;
            this.addressTxt.Lines = new string[0];
            this.addressTxt.Location = new System.Drawing.Point(56, 292);
            this.addressTxt.MaxLength = 32767;
            this.addressTxt.Multiline = true;
            this.addressTxt.Name = "addressTxt";
            this.addressTxt.PasswordChar = '\0';
            this.addressTxt.PromptText = "Address";
            this.addressTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.addressTxt.SelectedText = "";
            this.addressTxt.SelectionLength = 0;
            this.addressTxt.SelectionStart = 0;
            this.addressTxt.ShortcutsEnabled = true;
            this.addressTxt.Size = new System.Drawing.Size(223, 45);
            this.addressTxt.TabIndex = 4;
            this.addressTxt.UseSelectable = true;
            this.addressTxt.WaterMark = "Address";
            this.addressTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.addressTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // contactTxt
            // 
            // 
            // 
            // 
            this.contactTxt.CustomButton.Image = null;
            this.contactTxt.CustomButton.Location = new System.Drawing.Point(146, 1);
            this.contactTxt.CustomButton.Name = "";
            this.contactTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.contactTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.contactTxt.CustomButton.TabIndex = 1;
            this.contactTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.contactTxt.CustomButton.UseSelectable = true;
            this.contactTxt.CustomButton.Visible = false;
            this.contactTxt.DisplayIcon = true;
            this.contactTxt.Icon = global::ARM.Properties.Resources.Contact_24;
            this.contactTxt.Lines = new string[0];
            this.contactTxt.Location = new System.Drawing.Point(294, 209);
            this.contactTxt.MaxLength = 32767;
            this.contactTxt.Name = "contactTxt";
            this.contactTxt.PasswordChar = '\0';
            this.contactTxt.PromptText = "Contact/Phone";
            this.contactTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.contactTxt.SelectedText = "";
            this.contactTxt.SelectionLength = 0;
            this.contactTxt.SelectionStart = 0;
            this.contactTxt.ShortcutsEnabled = true;
            this.contactTxt.Size = new System.Drawing.Size(180, 35);
            this.contactTxt.TabIndex = 1;
            this.contactTxt.UseSelectable = true;
            this.contactTxt.WaterMark = "Contact/Phone";
            this.contactTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.contactTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.contactTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.contactTxt_KeyPress);
            // 
            // nameTxt
            // 
            // 
            // 
            // 
            this.nameTxt.CustomButton.Image = null;
            this.nameTxt.CustomButton.Location = new System.Drawing.Point(192, 1);
            this.nameTxt.CustomButton.Name = "";
            this.nameTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.nameTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.nameTxt.CustomButton.TabIndex = 1;
            this.nameTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.nameTxt.CustomButton.UseSelectable = true;
            this.nameTxt.CustomButton.Visible = false;
            this.nameTxt.DisplayIcon = true;
            this.nameTxt.Icon = global::ARM.Properties.Resources.User_Profile_24;
            this.nameTxt.Lines = new string[0];
            this.nameTxt.Location = new System.Drawing.Point(53, 209);
            this.nameTxt.MaxLength = 32767;
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.PasswordChar = '\0';
            this.nameTxt.PromptText = "Full name";
            this.nameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nameTxt.SelectedText = "";
            this.nameTxt.SelectionLength = 0;
            this.nameTxt.SelectionStart = 0;
            this.nameTxt.ShortcutsEnabled = true;
            this.nameTxt.Size = new System.Drawing.Size(226, 35);
            this.nameTxt.TabIndex = 0;
            this.nameTxt.UseSelectable = true;
            this.nameTxt.WaterMark = "Full name";
            this.nameTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.nameTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // emailTxt
            // 
            // 
            // 
            // 
            this.emailTxt.CustomButton.Image = null;
            this.emailTxt.CustomButton.Location = new System.Drawing.Point(192, 1);
            this.emailTxt.CustomButton.Name = "";
            this.emailTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.emailTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.emailTxt.CustomButton.TabIndex = 1;
            this.emailTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.emailTxt.CustomButton.UseSelectable = true;
            this.emailTxt.CustomButton.Visible = false;
            this.emailTxt.DisplayIcon = true;
            this.emailTxt.Icon = global::ARM.Properties.Resources.Mail_24;
            this.emailTxt.Lines = new string[0];
            this.emailTxt.Location = new System.Drawing.Point(53, 250);
            this.emailTxt.MaxLength = 32767;
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.PasswordChar = '\0';
            this.emailTxt.PromptText = "Email";
            this.emailTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.emailTxt.SelectedText = "";
            this.emailTxt.SelectionLength = 0;
            this.emailTxt.SelectionStart = 0;
            this.emailTxt.ShortcutsEnabled = true;
            this.emailTxt.Size = new System.Drawing.Size(226, 35);
            this.emailTxt.TabIndex = 2;
            this.emailTxt.UseSelectable = true;
            this.emailTxt.WaterMark = "Email";
            this.emailTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.emailTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.emailTxt.Leave += new System.EventHandler(this.emailTxt_Leave);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Image = global::ARM.Properties.Resources.Cancel_48;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(63, 573);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(107, 49);
            this.button2.TabIndex = 13;
            this.button2.Text = "Cancel";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Image = global::ARM.Properties.Resources.Submit_01_32;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(364, 571);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button3.Size = new System.Drawing.Size(103, 49);
            this.button3.TabIndex = 12;
            this.button3.Text = "Submit";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // imgCapture
            // 
            this.imgCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imgCapture.Image = global::ARM.Properties.Resources.temp1;
            this.imgCapture.Location = new System.Drawing.Point(99, 63);
            this.imgCapture.Name = "imgCapture";
            this.imgCapture.Size = new System.Drawing.Size(128, 128);
            this.imgCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgCapture.TabIndex = 25;
            this.imgCapture.TabStop = false;
            this.imgCapture.Click += new System.EventHandler(this.imgCapture_Click);
            // 
            // npiTxt
            // 
            // 
            // 
            // 
            this.npiTxt.CustomButton.Image = null;
            this.npiTxt.CustomButton.Location = new System.Drawing.Point(146, 1);
            this.npiTxt.CustomButton.Name = "";
            this.npiTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.npiTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.npiTxt.CustomButton.TabIndex = 1;
            this.npiTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.npiTxt.CustomButton.UseSelectable = true;
            this.npiTxt.CustomButton.Visible = false;
            this.npiTxt.DisplayIcon = true;
            this.npiTxt.Icon = global::ARM.Properties.Resources.Library_Books_24__1_;
            this.npiTxt.Lines = new string[0];
            this.npiTxt.Location = new System.Drawing.Point(294, 292);
            this.npiTxt.MaxLength = 32767;
            this.npiTxt.Name = "npiTxt";
            this.npiTxt.PasswordChar = '\0';
            this.npiTxt.PromptText = "NPI";
            this.npiTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.npiTxt.SelectedText = "";
            this.npiTxt.SelectionLength = 0;
            this.npiTxt.SelectionStart = 0;
            this.npiTxt.ShortcutsEnabled = true;
            this.npiTxt.Size = new System.Drawing.Size(180, 35);
            this.npiTxt.TabIndex = 111;
            this.npiTxt.UseSelectable = true;
            this.npiTxt.WaterMark = "NPI";
            this.npiTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.npiTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // officeTxt
            // 
            // 
            // 
            // 
            this.officeTxt.CustomButton.Image = null;
            this.officeTxt.CustomButton.Location = new System.Drawing.Point(187, 1);
            this.officeTxt.CustomButton.Name = "";
            this.officeTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.officeTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.officeTxt.CustomButton.TabIndex = 1;
            this.officeTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.officeTxt.CustomButton.UseSelectable = true;
            this.officeTxt.CustomButton.Visible = false;
            this.officeTxt.DisplayIcon = true;
            this.officeTxt.Icon = global::ARM.Properties.Resources.Mail_24;
            this.officeTxt.Lines = new string[0];
            this.officeTxt.Location = new System.Drawing.Point(58, 343);
            this.officeTxt.MaxLength = 32767;
            this.officeTxt.Name = "officeTxt";
            this.officeTxt.PasswordChar = '\0';
            this.officeTxt.PromptText = "Office";
            this.officeTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.officeTxt.SelectedText = "";
            this.officeTxt.SelectionLength = 0;
            this.officeTxt.SelectionStart = 0;
            this.officeTxt.ShortcutsEnabled = true;
            this.officeTxt.Size = new System.Drawing.Size(221, 35);
            this.officeTxt.TabIndex = 112;
            this.officeTxt.UseSelectable = true;
            this.officeTxt.WaterMark = "Office";
            this.officeTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.officeTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // specialityTxt
            // 
            // 
            // 
            // 
            this.specialityTxt.CustomButton.Image = null;
            this.specialityTxt.CustomButton.Location = new System.Drawing.Point(146, 1);
            this.specialityTxt.CustomButton.Name = "";
            this.specialityTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.specialityTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.specialityTxt.CustomButton.TabIndex = 1;
            this.specialityTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.specialityTxt.CustomButton.UseSelectable = true;
            this.specialityTxt.CustomButton.Visible = false;
            this.specialityTxt.DisplayIcon = true;
            this.specialityTxt.Icon = ((System.Drawing.Image)(resources.GetObject("specialityTxt.Icon")));
            this.specialityTxt.Lines = new string[0];
            this.specialityTxt.Location = new System.Drawing.Point(294, 508);
            this.specialityTxt.MaxLength = 32767;
            this.specialityTxt.Name = "specialityTxt";
            this.specialityTxt.PasswordChar = '\0';
            this.specialityTxt.PromptText = "Speciality";
            this.specialityTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.specialityTxt.SelectedText = "";
            this.specialityTxt.SelectionLength = 0;
            this.specialityTxt.SelectionStart = 0;
            this.specialityTxt.ShortcutsEnabled = true;
            this.specialityTxt.Size = new System.Drawing.Size(180, 35);
            this.specialityTxt.TabIndex = 113;
            this.specialityTxt.UseSelectable = true;
            this.specialityTxt.WaterMark = "Speciality";
            this.specialityTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.specialityTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // idTxt
            // 
            // 
            // 
            // 
            this.idTxt.CustomButton.Image = null;
            this.idTxt.CustomButton.Location = new System.Drawing.Point(146, 1);
            this.idTxt.CustomButton.Name = "";
            this.idTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.idTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.idTxt.CustomButton.TabIndex = 1;
            this.idTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.idTxt.CustomButton.UseSelectable = true;
            this.idTxt.CustomButton.Visible = false;
            this.idTxt.DisplayIcon = true;
            this.idTxt.Icon = global::ARM.Properties.Resources.Layers_01_16;
            this.idTxt.Lines = new string[0];
            this.idTxt.Location = new System.Drawing.Point(294, 338);
            this.idTxt.MaxLength = 32767;
            this.idTxt.Name = "idTxt";
            this.idTxt.PasswordChar = '\0';
            this.idTxt.PromptText = "ID #";
            this.idTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.idTxt.SelectedText = "";
            this.idTxt.SelectionLength = 0;
            this.idTxt.SelectionStart = 0;
            this.idTxt.ShortcutsEnabled = true;
            this.idTxt.Size = new System.Drawing.Size(180, 35);
            this.idTxt.TabIndex = 114;
            this.idTxt.UseSelectable = true;
            this.idTxt.WaterMark = "ID #";
            this.idTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.idTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tinTxt
            // 
            // 
            // 
            // 
            this.tinTxt.CustomButton.Image = null;
            this.tinTxt.CustomButton.Location = new System.Drawing.Point(146, 1);
            this.tinTxt.CustomButton.Name = "";
            this.tinTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.tinTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tinTxt.CustomButton.TabIndex = 1;
            this.tinTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tinTxt.CustomButton.UseSelectable = true;
            this.tinTxt.CustomButton.Visible = false;
            this.tinTxt.DisplayIcon = true;
            this.tinTxt.Icon = ((System.Drawing.Image)(resources.GetObject("tinTxt.Icon")));
            this.tinTxt.Lines = new string[0];
            this.tinTxt.Location = new System.Drawing.Point(294, 379);
            this.tinTxt.MaxLength = 32767;
            this.tinTxt.Name = "tinTxt";
            this.tinTxt.PasswordChar = '\0';
            this.tinTxt.PromptText = "TIN";
            this.tinTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tinTxt.SelectedText = "";
            this.tinTxt.SelectionLength = 0;
            this.tinTxt.SelectionStart = 0;
            this.tinTxt.ShortcutsEnabled = true;
            this.tinTxt.Size = new System.Drawing.Size(180, 35);
            this.tinTxt.TabIndex = 115;
            this.tinTxt.UseSelectable = true;
            this.tinTxt.WaterMark = "TIN";
            this.tinTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tinTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // faxTxt
            // 
            // 
            // 
            // 
            this.faxTxt.CustomButton.Image = null;
            this.faxTxt.CustomButton.Location = new System.Drawing.Point(146, 1);
            this.faxTxt.CustomButton.Name = "";
            this.faxTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.faxTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.faxTxt.CustomButton.TabIndex = 1;
            this.faxTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.faxTxt.CustomButton.UseSelectable = true;
            this.faxTxt.CustomButton.Visible = false;
            this.faxTxt.DisplayIcon = true;
            this.faxTxt.Icon = ((System.Drawing.Image)(resources.GetObject("faxTxt.Icon")));
            this.faxTxt.Lines = new string[0];
            this.faxTxt.Location = new System.Drawing.Point(294, 461);
            this.faxTxt.MaxLength = 32767;
            this.faxTxt.Name = "faxTxt";
            this.faxTxt.PasswordChar = '\0';
            this.faxTxt.PromptText = "Office Fax";
            this.faxTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.faxTxt.SelectedText = "";
            this.faxTxt.SelectionLength = 0;
            this.faxTxt.SelectionStart = 0;
            this.faxTxt.ShortcutsEnabled = true;
            this.faxTxt.Size = new System.Drawing.Size(180, 35);
            this.faxTxt.TabIndex = 116;
            this.faxTxt.UseSelectable = true;
            this.faxTxt.WaterMark = "Office Fax";
            this.faxTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.faxTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // officePhoneTxt
            // 
            // 
            // 
            // 
            this.officePhoneTxt.CustomButton.Image = null;
            this.officePhoneTxt.CustomButton.Location = new System.Drawing.Point(146, 1);
            this.officePhoneTxt.CustomButton.Name = "";
            this.officePhoneTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.officePhoneTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.officePhoneTxt.CustomButton.TabIndex = 1;
            this.officePhoneTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.officePhoneTxt.CustomButton.UseSelectable = true;
            this.officePhoneTxt.CustomButton.Visible = false;
            this.officePhoneTxt.DisplayIcon = true;
            this.officePhoneTxt.Icon = ((System.Drawing.Image)(resources.GetObject("officePhoneTxt.Icon")));
            this.officePhoneTxt.Lines = new string[0];
            this.officePhoneTxt.Location = new System.Drawing.Point(294, 420);
            this.officePhoneTxt.MaxLength = 32767;
            this.officePhoneTxt.Name = "officePhoneTxt";
            this.officePhoneTxt.PasswordChar = '\0';
            this.officePhoneTxt.PromptText = "Office Phone";
            this.officePhoneTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.officePhoneTxt.SelectedText = "";
            this.officePhoneTxt.SelectionLength = 0;
            this.officePhoneTxt.SelectionStart = 0;
            this.officePhoneTxt.ShortcutsEnabled = true;
            this.officePhoneTxt.Size = new System.Drawing.Size(180, 35);
            this.officePhoneTxt.TabIndex = 117;
            this.officePhoneTxt.UseSelectable = true;
            this.officePhoneTxt.WaterMark = "Office Phone";
            this.officePhoneTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.officePhoneTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(107, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 118;
            this.label1.Text = "Double Click to Browse ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.Color.Khaki;
            this.updateBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateBtn.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.updateBtn.Image = global::ARM.Properties.Resources.Note_04_24;
            this.updateBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.updateBtn.Location = new System.Drawing.Point(213, 571);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.updateBtn.Size = new System.Drawing.Size(107, 49);
            this.updateBtn.TabIndex = 247;
            this.updateBtn.Text = "Update";
            this.updateBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // PractitionerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 645);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.officePhoneTxt);
            this.Controls.Add(this.faxTxt);
            this.Controls.Add(this.tinTxt);
            this.Controls.Add(this.idTxt);
            this.Controls.Add(this.specialityTxt);
            this.Controls.Add(this.officeTxt);
            this.Controls.Add(this.npiTxt);
            this.Controls.Add(this.zipTxt);
            this.Controls.Add(this.stateTxt);
            this.Controls.Add(this.cityTxt);
            this.Controls.Add(this.addressTxt);
            this.Controls.Add(this.contactTxt);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.emailTxt);
            this.Controls.Add(this.genderCbx);
            this.Controls.Add(this.fileUrlTxtBx);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.categoryCbx);
            this.Controls.Add(this.imgCapture);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PractitionerDialog";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "Practitioner/Doctor";
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Drawing.Html.HtmlToolTip htmlToolTip1;
        private System.Windows.Forms.PictureBox imgCapture;
        private MetroFramework.Controls.MetroComboBox categoryCbx;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox fileUrlTxtBx;
        private MetroFramework.Controls.MetroComboBox genderCbx;
        private MetroFramework.Controls.MetroTextBox emailTxt;
        private MetroFramework.Controls.MetroTextBox nameTxt;
        private MetroFramework.Controls.MetroTextBox contactTxt;
        private MetroFramework.Controls.MetroTextBox addressTxt;
        private MetroFramework.Controls.MetroTextBox cityTxt;
        private MetroFramework.Controls.MetroTextBox stateTxt;
        private MetroFramework.Controls.MetroTextBox zipTxt;
        private MetroFramework.Controls.MetroTextBox npiTxt;
        private MetroFramework.Controls.MetroTextBox officeTxt;
        private MetroFramework.Controls.MetroTextBox specialityTxt;
        private MetroFramework.Controls.MetroTextBox idTxt;
        private MetroFramework.Controls.MetroTextBox tinTxt;
        private MetroFramework.Controls.MetroTextBox faxTxt;
        private MetroFramework.Controls.MetroTextBox officePhoneTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button updateBtn;
    }
}
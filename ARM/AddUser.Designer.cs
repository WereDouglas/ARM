namespace ARM
{
    partial class AddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUser));
            this.htmlToolTip1 = new MetroFramework.Drawing.Html.HtmlToolTip();
            this.categoryCbx = new MetroFramework.Controls.MetroComboBox();
            this.fileUrlTxtBx = new System.Windows.Forms.TextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.genderCbx = new MetroFramework.Controls.MetroComboBox();
            this.dobTxt = new MetroFramework.Controls.MetroDateTime();
            this.passwordTxt = new MetroFramework.Controls.MetroTextBox();
            this.zipTxt = new MetroFramework.Controls.MetroTextBox();
            this.stateTxt = new MetroFramework.Controls.MetroTextBox();
            this.cityTxt = new MetroFramework.Controls.MetroTextBox();
            this.addressTxt = new MetroFramework.Controls.MetroTextBox();
            this.contactTxt = new MetroFramework.Controls.MetroTextBox();
            this.nameTxt = new MetroFramework.Controls.MetroTextBox();
            this.emailTxt = new MetroFramework.Controls.MetroTextBox();
            this.confirmTxt = new MetroFramework.Controls.MetroTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.imgCapture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.specialityCbx = new MetroFramework.Controls.MetroComboBox();
            this.socialTxt = new MetroFramework.Controls.MetroTextBox();
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
            "Nurse",
            "Aid",
            "Other"});
            this.categoryCbx.Location = new System.Drawing.Point(312, 369);
            this.categoryCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.categoryCbx.Name = "categoryCbx";
            this.categoryCbx.PromptText = "Category/type";
            this.categoryCbx.Size = new System.Drawing.Size(194, 29);
            this.categoryCbx.TabIndex = 13;
            this.categoryCbx.UseSelectable = true;
            // 
            // fileUrlTxtBx
            // 
            this.fileUrlTxtBx.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.fileUrlTxtBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileUrlTxtBx.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileUrlTxtBx.Location = new System.Drawing.Point(53, 455);
            this.fileUrlTxtBx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileUrlTxtBx.Name = "fileUrlTxtBx";
            this.fileUrlTxtBx.Size = new System.Drawing.Size(223, 14);
            this.fileUrlTxtBx.TabIndex = 14;
            this.fileUrlTxtBx.Visible = false;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(312, 295);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(84, 19);
            this.metroLabel9.TabIndex = 110;
            this.metroLabel9.Text = "Date of birth";
            this.metroLabel9.Click += new System.EventHandler(this.metroLabel9_Click);
            // 
            // genderCbx
            // 
            this.genderCbx.FormattingEnabled = true;
            this.genderCbx.ItemHeight = 23;
            this.genderCbx.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.genderCbx.Location = new System.Drawing.Point(53, 418);
            this.genderCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.genderCbx.Name = "genderCbx";
            this.genderCbx.PromptText = "Gender";
            this.genderCbx.Size = new System.Drawing.Size(223, 29);
            this.genderCbx.TabIndex = 8;
            this.genderCbx.UseSelectable = true;
            this.genderCbx.SelectedIndexChanged += new System.EventHandler(this.genderCbx_SelectedIndexChanged);
            // 
            // dobTxt
            // 
            this.dobTxt.AllowDrop = true;
            this.dobTxt.Location = new System.Drawing.Point(312, 333);
            this.dobTxt.MinimumSize = new System.Drawing.Size(0, 29);
            this.dobTxt.Name = "dobTxt";
            this.dobTxt.Size = new System.Drawing.Size(194, 29);
            this.dobTxt.TabIndex = 12;
            // 
            // passwordTxt
            // 
            // 
            // 
            // 
            this.passwordTxt.CustomButton.Image = null;
            this.passwordTxt.CustomButton.Location = new System.Drawing.Point(166, 1);
            this.passwordTxt.CustomButton.Name = "";
            this.passwordTxt.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.passwordTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passwordTxt.CustomButton.TabIndex = 1;
            this.passwordTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passwordTxt.CustomButton.UseSelectable = true;
            this.passwordTxt.CustomButton.Visible = false;
            this.passwordTxt.DisplayIcon = true;
            this.passwordTxt.Icon = global::ARM.Properties.Resources.Lock_24;
            this.passwordTxt.Lines = new string[0];
            this.passwordTxt.Location = new System.Drawing.Point(312, 199);
            this.passwordTxt.MaxLength = 32767;
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.PasswordChar = '●';
            this.passwordTxt.PromptText = "Password";
            this.passwordTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordTxt.SelectedText = "";
            this.passwordTxt.SelectionLength = 0;
            this.passwordTxt.SelectionStart = 0;
            this.passwordTxt.ShortcutsEnabled = true;
            this.passwordTxt.Size = new System.Drawing.Size(194, 29);
            this.passwordTxt.TabIndex = 10;
            this.passwordTxt.UseSelectable = true;
            this.passwordTxt.UseSystemPasswordChar = true;
            this.passwordTxt.WaterMark = "Password";
            this.passwordTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passwordTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // zipTxt
            // 
            // 
            // 
            // 
            this.zipTxt.CustomButton.Image = null;
            this.zipTxt.CustomButton.Location = new System.Drawing.Point(189, 1);
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
            this.zipTxt.Location = new System.Drawing.Point(53, 295);
            this.zipTxt.MaxLength = 32767;
            this.zipTxt.Name = "zipTxt";
            this.zipTxt.PasswordChar = '\0';
            this.zipTxt.PromptText = "Zip code";
            this.zipTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.zipTxt.SelectedText = "";
            this.zipTxt.SelectionLength = 0;
            this.zipTxt.SelectionStart = 0;
            this.zipTxt.ShortcutsEnabled = true;
            this.zipTxt.Size = new System.Drawing.Size(223, 35);
            this.zipTxt.TabIndex = 5;
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
            this.stateTxt.CustomButton.Location = new System.Drawing.Point(189, 1);
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
            this.stateTxt.Location = new System.Drawing.Point(53, 335);
            this.stateTxt.MaxLength = 32767;
            this.stateTxt.Name = "stateTxt";
            this.stateTxt.PasswordChar = '\0';
            this.stateTxt.PromptText = "State";
            this.stateTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stateTxt.SelectedText = "";
            this.stateTxt.SelectionLength = 0;
            this.stateTxt.SelectionStart = 0;
            this.stateTxt.ShortcutsEnabled = true;
            this.stateTxt.Size = new System.Drawing.Size(223, 35);
            this.stateTxt.TabIndex = 6;
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
            this.cityTxt.Location = new System.Drawing.Point(53, 254);
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
            this.cityTxt.TabIndex = 4;
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
            this.addressTxt.CustomButton.Location = new System.Drawing.Point(163, 2);
            this.addressTxt.CustomButton.Name = "";
            this.addressTxt.CustomButton.Size = new System.Drawing.Size(57, 57);
            this.addressTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.addressTxt.CustomButton.TabIndex = 1;
            this.addressTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.addressTxt.CustomButton.UseSelectable = true;
            this.addressTxt.CustomButton.Visible = false;
            this.addressTxt.DisplayIcon = true;
            this.addressTxt.Icon = global::ARM.Properties.Resources.Map_Location_24;
            this.addressTxt.Lines = new string[0];
            this.addressTxt.Location = new System.Drawing.Point(53, 186);
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
            this.addressTxt.Size = new System.Drawing.Size(223, 62);
            this.addressTxt.TabIndex = 3;
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
            this.contactTxt.CustomButton.Location = new System.Drawing.Point(189, 1);
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
            this.contactTxt.Location = new System.Drawing.Point(53, 104);
            this.contactTxt.MaxLength = 32767;
            this.contactTxt.Name = "contactTxt";
            this.contactTxt.PasswordChar = '\0';
            this.contactTxt.PromptText = "Contact/Phone";
            this.contactTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.contactTxt.SelectedText = "";
            this.contactTxt.SelectionLength = 0;
            this.contactTxt.SelectionStart = 0;
            this.contactTxt.ShortcutsEnabled = true;
            this.contactTxt.Size = new System.Drawing.Size(223, 35);
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
            this.nameTxt.CustomButton.Location = new System.Drawing.Point(189, 1);
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
            this.nameTxt.Location = new System.Drawing.Point(53, 63);
            this.nameTxt.MaxLength = 32767;
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.PasswordChar = '\0';
            this.nameTxt.PromptText = "Full name";
            this.nameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nameTxt.SelectedText = "";
            this.nameTxt.SelectionLength = 0;
            this.nameTxt.SelectionStart = 0;
            this.nameTxt.ShortcutsEnabled = true;
            this.nameTxt.Size = new System.Drawing.Size(223, 35);
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
            this.emailTxt.CustomButton.Location = new System.Drawing.Point(189, 1);
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
            this.emailTxt.Location = new System.Drawing.Point(53, 145);
            this.emailTxt.MaxLength = 32767;
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.PasswordChar = '\0';
            this.emailTxt.PromptText = "Email";
            this.emailTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.emailTxt.SelectedText = "";
            this.emailTxt.SelectionLength = 0;
            this.emailTxt.SelectionStart = 0;
            this.emailTxt.ShortcutsEnabled = true;
            this.emailTxt.Size = new System.Drawing.Size(223, 35);
            this.emailTxt.TabIndex = 2;
            this.emailTxt.UseSelectable = true;
            this.emailTxt.WaterMark = "Email";
            this.emailTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.emailTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.emailTxt.Leave += new System.EventHandler(this.emailTxt_Leave);
            // 
            // confirmTxt
            // 
            // 
            // 
            // 
            this.confirmTxt.CustomButton.Image = null;
            this.confirmTxt.CustomButton.Location = new System.Drawing.Point(166, 1);
            this.confirmTxt.CustomButton.Name = "";
            this.confirmTxt.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.confirmTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.confirmTxt.CustomButton.TabIndex = 1;
            this.confirmTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.confirmTxt.CustomButton.UseSelectable = true;
            this.confirmTxt.CustomButton.Visible = false;
            this.confirmTxt.DisplayIcon = true;
            this.confirmTxt.Icon = global::ARM.Properties.Resources.Lock_24;
            this.confirmTxt.Lines = new string[0];
            this.confirmTxt.Location = new System.Drawing.Point(312, 235);
            this.confirmTxt.MaxLength = 32767;
            this.confirmTxt.Name = "confirmTxt";
            this.confirmTxt.PasswordChar = '●';
            this.confirmTxt.PromptText = "Confirm Password";
            this.confirmTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.confirmTxt.SelectedText = "";
            this.confirmTxt.SelectionLength = 0;
            this.confirmTxt.SelectionStart = 0;
            this.confirmTxt.ShortcutsEnabled = true;
            this.confirmTxt.Size = new System.Drawing.Size(194, 29);
            this.confirmTxt.TabIndex = 11;
            this.confirmTxt.UseSelectable = true;
            this.confirmTxt.UseSystemPasswordChar = true;
            this.confirmTxt.WaterMark = "Confirm Password";
            this.confirmTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.confirmTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.confirmTxt.Leave += new System.EventHandler(this.confirmTxt_Leave);
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
            this.button2.Location = new System.Drawing.Point(53, 476);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(107, 49);
            this.button2.TabIndex = 16;
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
            this.button3.Location = new System.Drawing.Point(394, 476);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button3.Size = new System.Drawing.Size(103, 49);
            this.button3.TabIndex = 15;
            this.button3.Text = "Submit";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // imgCapture
            // 
            this.imgCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imgCapture.Image = global::ARM.Properties.Resources.temp1;
            this.imgCapture.Location = new System.Drawing.Point(349, 52);
            this.imgCapture.Name = "imgCapture";
            this.imgCapture.Size = new System.Drawing.Size(128, 128);
            this.imgCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgCapture.TabIndex = 25;
            this.imgCapture.TabStop = false;
            this.imgCapture.Click += new System.EventHandler(this.imgCapture_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(325, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Double Click to Browse ";
            // 
            // specialityCbx
            // 
            this.specialityCbx.FormattingEnabled = true;
            this.specialityCbx.ItemHeight = 23;
            this.specialityCbx.Items.AddRange(new object[] {
            "LPN",
            "CNA",
            "RN",
            "Other"});
            this.specialityCbx.Location = new System.Drawing.Point(312, 410);
            this.specialityCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.specialityCbx.Name = "specialityCbx";
            this.specialityCbx.PromptText = "Speciality";
            this.specialityCbx.Size = new System.Drawing.Size(194, 29);
            this.specialityCbx.TabIndex = 14;
            this.specialityCbx.UseSelectable = true;
            // 
            // socialTxt
            // 
            // 
            // 
            // 
            this.socialTxt.CustomButton.Image = null;
            this.socialTxt.CustomButton.Location = new System.Drawing.Point(189, 1);
            this.socialTxt.CustomButton.Name = "";
            this.socialTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.socialTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.socialTxt.CustomButton.TabIndex = 1;
            this.socialTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.socialTxt.CustomButton.UseSelectable = true;
            this.socialTxt.CustomButton.Visible = false;
            this.socialTxt.DisplayIcon = true;
            this.socialTxt.Icon = global::ARM.Properties.Resources.City_24__1_;
            this.socialTxt.Lines = new string[0];
            this.socialTxt.Location = new System.Drawing.Point(53, 376);
            this.socialTxt.MaxLength = 32767;
            this.socialTxt.Name = "socialTxt";
            this.socialTxt.PasswordChar = '\0';
            this.socialTxt.PromptText = "SSN";
            this.socialTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.socialTxt.SelectedText = "";
            this.socialTxt.SelectionLength = 0;
            this.socialTxt.SelectionStart = 0;
            this.socialTxt.ShortcutsEnabled = true;
            this.socialTxt.Size = new System.Drawing.Size(223, 35);
            this.socialTxt.TabIndex = 7;
            this.socialTxt.UseSelectable = true;
            this.socialTxt.WaterMark = "SSN";
            this.socialTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.socialTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 564);
            this.Controls.Add(this.socialTxt);
            this.Controls.Add(this.specialityCbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.dobTxt);
            this.Controls.Add(this.zipTxt);
            this.Controls.Add(this.stateTxt);
            this.Controls.Add(this.cityTxt);
            this.Controls.Add(this.addressTxt);
            this.Controls.Add(this.contactTxt);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.emailTxt);
            this.Controls.Add(this.genderCbx);
            this.Controls.Add(this.confirmTxt);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.fileUrlTxtBx);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.categoryCbx);
            this.Controls.Add(this.imgCapture);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddUser";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "User";
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
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTextBox confirmTxt;
        private MetroFramework.Controls.MetroComboBox genderCbx;
        private MetroFramework.Controls.MetroTextBox emailTxt;
        private MetroFramework.Controls.MetroTextBox nameTxt;
        private MetroFramework.Controls.MetroTextBox contactTxt;
        private MetroFramework.Controls.MetroTextBox addressTxt;
        private MetroFramework.Controls.MetroTextBox cityTxt;
        private MetroFramework.Controls.MetroTextBox stateTxt;
        private MetroFramework.Controls.MetroTextBox zipTxt;
        private MetroFramework.Controls.MetroDateTime dobTxt;
        private MetroFramework.Controls.MetroTextBox passwordTxt;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroComboBox specialityCbx;
        private MetroFramework.Controls.MetroTextBox socialTxt;
    }
}
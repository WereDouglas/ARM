namespace ARM
{
    partial class LoginForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
			this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
			this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
			this.button3 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.passwordTxt = new MetroFramework.Controls.MetroTextBox();
			this.contactTxt = new MetroFramework.Controls.MetroTextBox();
			this.loginBtn = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
			this.metroPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// metroStyleManager1
			// 
			this.metroStyleManager1.Owner = null;
			// 
			// metroPanel1
			// 
			this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.metroPanel1.Controls.Add(this.button3);
			this.metroPanel1.Controls.Add(this.pictureBox1);
			this.metroPanel1.Controls.Add(this.passwordTxt);
			this.metroPanel1.Controls.Add(this.contactTxt);
			this.metroPanel1.Controls.Add(this.loginBtn);
			this.metroPanel1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.metroPanel1.HorizontalScrollbarBarColor = true;
			this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
			this.metroPanel1.HorizontalScrollbarSize = 12;
			this.metroPanel1.Location = new System.Drawing.Point(132, 89);
			this.metroPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.metroPanel1.Name = "metroPanel1";
			this.metroPanel1.Size = new System.Drawing.Size(345, 406);
			this.metroPanel1.TabIndex = 0;
			this.metroPanel1.VerticalScrollbarBarColor = true;
			this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
			this.metroPanel1.VerticalScrollbarSize = 10;
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.White;
			this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Font = new System.Drawing.Font("Trebuchet MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button3.ForeColor = System.Drawing.Color.DarkGoldenrod;
			this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button3.Location = new System.Drawing.Point(30, 338);
			this.button3.Name = "button3";
			this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.button3.Size = new System.Drawing.Size(287, 49);
			this.button3.TabIndex = 51;
			this.button3.Text = "Cancel";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.button3_Click_2);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = global::ARM.Properties.Resources.User_Profile_128;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox1.Location = new System.Drawing.Point(127, 17);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(111, 139);
			this.pictureBox1.TabIndex = 46;
			this.pictureBox1.TabStop = false;
			// 
			// passwordTxt
			// 
			this.passwordTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(164)))));
			// 
			// 
			// 
			this.passwordTxt.CustomButton.FlatAppearance.BorderSize = 0;
			this.passwordTxt.CustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.passwordTxt.CustomButton.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.passwordTxt.CustomButton.Image = null;
			this.passwordTxt.CustomButton.Location = new System.Drawing.Point(249, 2);
			this.passwordTxt.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.passwordTxt.CustomButton.Name = "";
			this.passwordTxt.CustomButton.Size = new System.Drawing.Size(35, 35);
			this.passwordTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.passwordTxt.CustomButton.TabIndex = 1;
			this.passwordTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.passwordTxt.CustomButton.UseSelectable = true;
			this.passwordTxt.CustomButton.Visible = false;
			this.passwordTxt.DisplayIcon = true;
			this.passwordTxt.Icon = global::ARM.Properties.Resources.Lock_24;
			this.passwordTxt.Lines = new string[0];
			this.passwordTxt.Location = new System.Drawing.Point(30, 212);
			this.passwordTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.passwordTxt.MaxLength = 32767;
			this.passwordTxt.Name = "passwordTxt";
			this.passwordTxt.PasswordChar = '●';
			this.passwordTxt.PromptText = "Password";
			this.passwordTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.passwordTxt.SelectedText = "";
			this.passwordTxt.SelectionLength = 0;
			this.passwordTxt.SelectionStart = 0;
			this.passwordTxt.ShortcutsEnabled = true;
			this.passwordTxt.Size = new System.Drawing.Size(287, 40);
			this.passwordTxt.TabIndex = 1;
			this.passwordTxt.UseCustomBackColor = true;
			this.passwordTxt.UseSelectable = true;
			this.passwordTxt.UseSystemPasswordChar = true;
			this.passwordTxt.WaterMark = "Password";
			this.passwordTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.passwordTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.passwordTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTxt_KeyDown);
			// 
			// contactTxt
			// 
			this.contactTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(164)))));
			// 
			// 
			// 
			this.contactTxt.CustomButton.FlatAppearance.BorderSize = 0;
			this.contactTxt.CustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.contactTxt.CustomButton.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.contactTxt.CustomButton.Image = null;
			this.contactTxt.CustomButton.Location = new System.Drawing.Point(249, 2);
			this.contactTxt.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.contactTxt.CustomButton.Name = "";
			this.contactTxt.CustomButton.Size = new System.Drawing.Size(35, 35);
			this.contactTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.contactTxt.CustomButton.TabIndex = 1;
			this.contactTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.contactTxt.CustomButton.UseSelectable = true;
			this.contactTxt.CustomButton.Visible = false;
			this.contactTxt.DisplayIcon = true;
			this.contactTxt.Icon = global::ARM.Properties.Resources.Contact_24;
			this.contactTxt.Lines = new string[0];
			this.contactTxt.Location = new System.Drawing.Point(30, 164);
			this.contactTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.contactTxt.MaxLength = 32767;
			this.contactTxt.Name = "contactTxt";
			this.contactTxt.PasswordChar = '\0';
			this.contactTxt.PromptText = "Contact";
			this.contactTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.contactTxt.SelectedText = "";
			this.contactTxt.SelectionLength = 0;
			this.contactTxt.SelectionStart = 0;
			this.contactTxt.ShortcutsEnabled = true;
			this.contactTxt.Size = new System.Drawing.Size(287, 40);
			this.contactTxt.TabIndex = 0;
			this.contactTxt.UseCustomBackColor = true;
			this.contactTxt.UseSelectable = true;
			this.contactTxt.WaterMark = "Contact";
			this.contactTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.contactTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			// 
			// loginBtn
			// 
			this.loginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
			this.loginBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.loginBtn.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.loginBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.loginBtn.Image = global::ARM.Properties.Resources.Submit_01_32;
			this.loginBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.loginBtn.Location = new System.Drawing.Point(30, 260);
			this.loginBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.loginBtn.Name = "loginBtn";
			this.loginBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.loginBtn.Size = new System.Drawing.Size(287, 71);
			this.loginBtn.TabIndex = 4;
			this.loginBtn.Text = "Login";
			this.loginBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.loginBtn.UseVisualStyleBackColor = false;
			this.loginBtn.Click += new System.EventHandler(this.button3_Click);
			// 
			// lblStatus
			// 
			this.lblStatus.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatus.Location = new System.Drawing.Point(11, 42);
			this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(580, 29);
			this.lblStatus.TabIndex = 3;
			this.lblStatus.Text = "  :  ";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button2
			// 
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Image = global::ARM.Properties.Resources.Customer_24;
			this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button2.Location = new System.Drawing.Point(234, 517);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(136, 35);
			this.button2.TabIndex = 50;
			this.button2.Text = "Register";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Image = global::ARM.Properties.Resources.Command_Refresh_16;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(449, 517);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(142, 35);
			this.button1.TabIndex = 0;
			this.button1.Text = "Advanced settings";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button4
			// 
			this.button4.FlatAppearance.BorderSize = 0;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.Image = global::ARM.Properties.Resources.Gear_24;
			this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button4.Location = new System.Drawing.Point(11, 517);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(147, 35);
			this.button4.TabIndex = 1;
			this.button4.Text = "Server Settings";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Visible = false;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox2.Location = new System.Drawing.Point(11, 582);
			this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(568, 32);
			this.pictureBox2.TabIndex = 49;
			this.pictureBox2.TabStop = false;
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(602, 617);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.metroPanel1);
			this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "LoginForm";
			this.Padding = new System.Windows.Forms.Padding(20, 74, 20, 25);
			this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
			this.Style = MetroFramework.MetroColorStyle.White;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
			this.Load += new System.EventHandler(this.LoginForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
			this.metroPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button loginBtn;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTextBox passwordTxt;
        private MetroFramework.Controls.MetroTextBox contactTxt;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
	}
}
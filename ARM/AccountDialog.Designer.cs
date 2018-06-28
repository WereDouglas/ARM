namespace ARM
{
    partial class AccountDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountDialog));
			this.htmlToolTip1 = new MetroFramework.Drawing.Html.HtmlToolTip();
			this.userCbx = new MetroFramework.Controls.MetroComboBox();
			this.routingTxt = new MetroFramework.Controls.MetroTextBox();
			this.bankTxt = new MetroFramework.Controls.MetroTextBox();
			this.userPbx = new System.Windows.Forms.PictureBox();
			this.accountTxt = new MetroFramework.Controls.MetroTextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.userPbx)).BeginInit();
			this.SuspendLayout();
			// 
			// htmlToolTip1
			// 
			this.htmlToolTip1.OwnerDraw = true;
			// 
			// userCbx
			// 
			this.userCbx.FormattingEnabled = true;
			this.userCbx.ItemHeight = 23;
			this.userCbx.Location = new System.Drawing.Point(75, 64);
			this.userCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.userCbx.Name = "userCbx";
			this.userCbx.PromptText = "Employee";
			this.userCbx.Size = new System.Drawing.Size(265, 29);
			this.userCbx.TabIndex = 1;
			this.userCbx.UseSelectable = true;
			this.userCbx.SelectedIndexChanged += new System.EventHandler(this.userCbx_SelectedIndexChanged);
			// 
			// routingTxt
			// 
			// 
			// 
			// 
			this.routingTxt.CustomButton.Image = null;
			this.routingTxt.CustomButton.Location = new System.Drawing.Point(231, 1);
			this.routingTxt.CustomButton.Name = "";
			this.routingTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
			this.routingTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.routingTxt.CustomButton.TabIndex = 1;
			this.routingTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.routingTxt.CustomButton.UseSelectable = true;
			this.routingTxt.CustomButton.Visible = false;
			this.routingTxt.DisplayIcon = true;
			this.routingTxt.Lines = new string[0];
			this.routingTxt.Location = new System.Drawing.Point(75, 217);
			this.routingTxt.MaxLength = 32767;
			this.routingTxt.Name = "routingTxt";
			this.routingTxt.PasswordChar = '\0';
			this.routingTxt.PromptText = "Routing Number";
			this.routingTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.routingTxt.SelectedText = "";
			this.routingTxt.SelectionLength = 0;
			this.routingTxt.SelectionStart = 0;
			this.routingTxt.ShortcutsEnabled = true;
			this.routingTxt.Size = new System.Drawing.Size(265, 35);
			this.routingTxt.TabIndex = 180;
			this.routingTxt.UseSelectable = true;
			this.routingTxt.WaterMark = "Routing Number";
			this.routingTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.routingTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// bankTxt
			// 
			// 
			// 
			// 
			this.bankTxt.CustomButton.Image = null;
			this.bankTxt.CustomButton.Location = new System.Drawing.Point(231, 1);
			this.bankTxt.CustomButton.Name = "";
			this.bankTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
			this.bankTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.bankTxt.CustomButton.TabIndex = 1;
			this.bankTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.bankTxt.CustomButton.UseSelectable = true;
			this.bankTxt.CustomButton.Visible = false;
			this.bankTxt.DisplayIcon = true;
			this.bankTxt.Lines = new string[0];
			this.bankTxt.Location = new System.Drawing.Point(75, 176);
			this.bankTxt.MaxLength = 32767;
			this.bankTxt.Name = "bankTxt";
			this.bankTxt.PasswordChar = '\0';
			this.bankTxt.PromptText = "Bank name";
			this.bankTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.bankTxt.SelectedText = "";
			this.bankTxt.SelectionLength = 0;
			this.bankTxt.SelectionStart = 0;
			this.bankTxt.ShortcutsEnabled = true;
			this.bankTxt.Size = new System.Drawing.Size(265, 35);
			this.bankTxt.TabIndex = 3;
			this.bankTxt.UseSelectable = true;
			this.bankTxt.WaterMark = "Bank name";
			this.bankTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.bankTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// userPbx
			// 
			this.userPbx.Image = global::ARM.Properties.Resources.User_Profile_128;
			this.userPbx.Location = new System.Drawing.Point(176, 99);
			this.userPbx.Name = "userPbx";
			this.userPbx.Size = new System.Drawing.Size(61, 71);
			this.userPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.userPbx.TabIndex = 179;
			this.userPbx.TabStop = false;
			// 
			// accountTxt
			// 
			// 
			// 
			// 
			this.accountTxt.CustomButton.Image = null;
			this.accountTxt.CustomButton.Location = new System.Drawing.Point(231, 1);
			this.accountTxt.CustomButton.Name = "";
			this.accountTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
			this.accountTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.accountTxt.CustomButton.TabIndex = 1;
			this.accountTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.accountTxt.CustomButton.UseSelectable = true;
			this.accountTxt.CustomButton.Visible = false;
			this.accountTxt.DisplayIcon = true;
			this.accountTxt.Lines = new string[0];
			this.accountTxt.Location = new System.Drawing.Point(75, 258);
			this.accountTxt.MaxLength = 32767;
			this.accountTxt.Name = "accountTxt";
			this.accountTxt.PasswordChar = '\0';
			this.accountTxt.PromptText = "Account number";
			this.accountTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.accountTxt.SelectedText = "";
			this.accountTxt.SelectionLength = 0;
			this.accountTxt.SelectionStart = 0;
			this.accountTxt.ShortcutsEnabled = true;
			this.accountTxt.Size = new System.Drawing.Size(265, 35);
			this.accountTxt.TabIndex = 2;
			this.accountTxt.UseSelectable = true;
			this.accountTxt.WaterMark = "Account number";
			this.accountTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.accountTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.accountTxt.Click += new System.EventHandler(this.costTxt_Click);
			this.accountTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.accountTxt_KeyPress);
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
			this.button3.Location = new System.Drawing.Point(232, 330);
			this.button3.Name = "button3";
			this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.button3.Size = new System.Drawing.Size(108, 49);
			this.button3.TabIndex = 4;
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
			this.button2.Location = new System.Drawing.Point(75, 330);
			this.button2.Name = "button2";
			this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.button2.Size = new System.Drawing.Size(108, 49);
			this.button2.TabIndex = 0;
			this.button2.Text = "Cancel";
			this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// AccountDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 402);
			this.Controls.Add(this.routingTxt);
			this.Controls.Add(this.bankTxt);
			this.Controls.Add(this.userPbx);
			this.Controls.Add(this.userCbx);
			this.Controls.Add(this.accountTxt);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AccountDialog";
			this.Style = MetroFramework.MetroColorStyle.White;
			this.Text = "Bank info/Details";
			this.Load += new System.EventHandler(this.AccountDialog_Load);
			((System.ComponentModel.ISupportInitialize)(this.userPbx)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Drawing.Html.HtmlToolTip htmlToolTip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private MetroFramework.Controls.MetroTextBox accountTxt;
        private MetroFramework.Controls.MetroComboBox userCbx;
        private System.Windows.Forms.PictureBox userPbx;
        private MetroFramework.Controls.MetroTextBox bankTxt;
        private MetroFramework.Controls.MetroTextBox routingTxt;
    }
}
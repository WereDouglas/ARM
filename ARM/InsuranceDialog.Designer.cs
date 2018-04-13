namespace ARM
{
    partial class InsuranceDialog
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
            this.customerCbx = new MetroFramework.Controls.MetroComboBox();
            this.typeCbx = new MetroFramework.Controls.MetroComboBox();
            this.zipTxt = new MetroFramework.Controls.MetroTextBox();
            this.contactTxt = new MetroFramework.Controls.MetroTextBox();
            this.addressTxt = new MetroFramework.Controls.MetroTextBox();
            this.nameTxt = new MetroFramework.Controls.MetroTextBox();
            this.cusPbx = new System.Windows.Forms.PictureBox();
            this.noTxt = new MetroFramework.Controls.MetroTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cusPbx)).BeginInit();
            this.SuspendLayout();
            // 
            // htmlToolTip1
            // 
            this.htmlToolTip1.OwnerDraw = true;
            // 
            // customerCbx
            // 
            this.customerCbx.FormattingEnabled = true;
            this.customerCbx.ItemHeight = 23;
            this.customerCbx.Location = new System.Drawing.Point(75, 82);
            this.customerCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customerCbx.Name = "customerCbx";
            this.customerCbx.PromptText = "Patient";
            this.customerCbx.Size = new System.Drawing.Size(265, 29);
            this.customerCbx.TabIndex = 133;
            this.customerCbx.UseSelectable = true;
            this.customerCbx.SelectedIndexChanged += new System.EventHandler(this.customerCbx_SelectedIndexChanged);
            // 
            // typeCbx
            // 
            this.typeCbx.FormattingEnabled = true;
            this.typeCbx.ItemHeight = 23;
            this.typeCbx.Items.AddRange(new object[] {
            "Primary",
            "Secondary"});
            this.typeCbx.Location = new System.Drawing.Point(75, 177);
            this.typeCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.typeCbx.Name = "typeCbx";
            this.typeCbx.PromptText = "Type of Insurance";
            this.typeCbx.Size = new System.Drawing.Size(265, 29);
            this.typeCbx.TabIndex = 180;
            this.typeCbx.UseSelectable = true;
            // 
            // zipTxt
            // 
            // 
            // 
            // 
            this.zipTxt.CustomButton.Image = null;
            this.zipTxt.CustomButton.Location = new System.Drawing.Point(231, 1);
            this.zipTxt.CustomButton.Name = "";
            this.zipTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.zipTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.zipTxt.CustomButton.TabIndex = 1;
            this.zipTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.zipTxt.CustomButton.UseSelectable = true;
            this.zipTxt.CustomButton.Visible = false;
            this.zipTxt.DisplayIcon = true;
            this.zipTxt.Icon = global::ARM.Properties.Resources.Layers_01_16;
            this.zipTxt.Lines = new string[0];
            this.zipTxt.Location = new System.Drawing.Point(75, 336);
            this.zipTxt.MaxLength = 32767;
            this.zipTxt.Name = "zipTxt";
            this.zipTxt.PasswordChar = '\0';
            this.zipTxt.PromptText = "Zip code";
            this.zipTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.zipTxt.SelectedText = "";
            this.zipTxt.SelectionLength = 0;
            this.zipTxt.SelectionStart = 0;
            this.zipTxt.ShortcutsEnabled = true;
            this.zipTxt.Size = new System.Drawing.Size(265, 35);
            this.zipTxt.TabIndex = 185;
            this.zipTxt.UseSelectable = true;
            this.zipTxt.WaterMark = "Zip code";
            this.zipTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.zipTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // contactTxt
            // 
            // 
            // 
            // 
            this.contactTxt.CustomButton.Image = null;
            this.contactTxt.CustomButton.Location = new System.Drawing.Point(231, 1);
            this.contactTxt.CustomButton.Name = "";
            this.contactTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.contactTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.contactTxt.CustomButton.TabIndex = 1;
            this.contactTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.contactTxt.CustomButton.UseSelectable = true;
            this.contactTxt.CustomButton.Visible = false;
            this.contactTxt.DisplayIcon = true;
            this.contactTxt.Icon = global::ARM.Properties.Resources.Layers_01_16;
            this.contactTxt.Lines = new string[0];
            this.contactTxt.Location = new System.Drawing.Point(75, 295);
            this.contactTxt.MaxLength = 32767;
            this.contactTxt.Name = "contactTxt";
            this.contactTxt.PasswordChar = '\0';
            this.contactTxt.PromptText = "Insurance Contact";
            this.contactTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.contactTxt.SelectedText = "";
            this.contactTxt.SelectionLength = 0;
            this.contactTxt.SelectionStart = 0;
            this.contactTxt.ShortcutsEnabled = true;
            this.contactTxt.Size = new System.Drawing.Size(265, 35);
            this.contactTxt.TabIndex = 184;
            this.contactTxt.UseSelectable = true;
            this.contactTxt.WaterMark = "Insurance Contact";
            this.contactTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.contactTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // addressTxt
            // 
            // 
            // 
            // 
            this.addressTxt.CustomButton.Image = null;
            this.addressTxt.CustomButton.Location = new System.Drawing.Point(231, 1);
            this.addressTxt.CustomButton.Name = "";
            this.addressTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.addressTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.addressTxt.CustomButton.TabIndex = 1;
            this.addressTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.addressTxt.CustomButton.UseSelectable = true;
            this.addressTxt.CustomButton.Visible = false;
            this.addressTxt.DisplayIcon = true;
            this.addressTxt.Icon = global::ARM.Properties.Resources.Layers_01_16;
            this.addressTxt.Lines = new string[0];
            this.addressTxt.Location = new System.Drawing.Point(75, 254);
            this.addressTxt.MaxLength = 32767;
            this.addressTxt.Name = "addressTxt";
            this.addressTxt.PasswordChar = '\0';
            this.addressTxt.PromptText = "Address";
            this.addressTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.addressTxt.SelectedText = "";
            this.addressTxt.SelectionLength = 0;
            this.addressTxt.SelectionStart = 0;
            this.addressTxt.ShortcutsEnabled = true;
            this.addressTxt.Size = new System.Drawing.Size(265, 35);
            this.addressTxt.TabIndex = 183;
            this.addressTxt.UseSelectable = true;
            this.addressTxt.WaterMark = "Address";
            this.addressTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.addressTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // nameTxt
            // 
            // 
            // 
            // 
            this.nameTxt.CustomButton.Image = null;
            this.nameTxt.CustomButton.Location = new System.Drawing.Point(231, 1);
            this.nameTxt.CustomButton.Name = "";
            this.nameTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.nameTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.nameTxt.CustomButton.TabIndex = 1;
            this.nameTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.nameTxt.CustomButton.UseSelectable = true;
            this.nameTxt.CustomButton.Visible = false;
            this.nameTxt.DisplayIcon = true;
            this.nameTxt.Icon = global::ARM.Properties.Resources.Orientation_Portrait_24;
            this.nameTxt.Lines = new string[0];
            this.nameTxt.Location = new System.Drawing.Point(75, 135);
            this.nameTxt.MaxLength = 32767;
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.PasswordChar = '\0';
            this.nameTxt.PromptText = "Name";
            this.nameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nameTxt.SelectedText = "";
            this.nameTxt.SelectionLength = 0;
            this.nameTxt.SelectionStart = 0;
            this.nameTxt.ShortcutsEnabled = true;
            this.nameTxt.Size = new System.Drawing.Size(265, 35);
            this.nameTxt.TabIndex = 181;
            this.nameTxt.UseSelectable = true;
            this.nameTxt.WaterMark = "Name";
            this.nameTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.nameTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cusPbx
            // 
            this.cusPbx.Image = global::ARM.Properties.Resources.User_Profile_128;
            this.cusPbx.Location = new System.Drawing.Point(5, 82);
            this.cusPbx.Name = "cusPbx";
            this.cusPbx.Size = new System.Drawing.Size(68, 46);
            this.cusPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cusPbx.TabIndex = 178;
            this.cusPbx.TabStop = false;
            // 
            // noTxt
            // 
            // 
            // 
            // 
            this.noTxt.CustomButton.Image = null;
            this.noTxt.CustomButton.Location = new System.Drawing.Point(231, 1);
            this.noTxt.CustomButton.Name = "";
            this.noTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.noTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.noTxt.CustomButton.TabIndex = 1;
            this.noTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.noTxt.CustomButton.UseSelectable = true;
            this.noTxt.CustomButton.Visible = false;
            this.noTxt.DisplayIcon = true;
            this.noTxt.Icon = global::ARM.Properties.Resources.Layers_01_16;
            this.noTxt.Lines = new string[0];
            this.noTxt.Location = new System.Drawing.Point(75, 213);
            this.noTxt.MaxLength = 32767;
            this.noTxt.Name = "noTxt";
            this.noTxt.PasswordChar = '\0';
            this.noTxt.PromptText = "No.";
            this.noTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.noTxt.SelectedText = "";
            this.noTxt.SelectionLength = 0;
            this.noTxt.SelectionStart = 0;
            this.noTxt.ShortcutsEnabled = true;
            this.noTxt.Size = new System.Drawing.Size(265, 35);
            this.noTxt.TabIndex = 4;
            this.noTxt.UseSelectable = true;
            this.noTxt.WaterMark = "No.";
            this.noTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.noTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
            this.button3.Location = new System.Drawing.Point(232, 448);
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
            this.button2.Location = new System.Drawing.Point(75, 448);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(108, 49);
            this.button2.TabIndex = 13;
            this.button2.Text = "Cancel";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // InsuranceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 505);
            this.Controls.Add(this.zipTxt);
            this.Controls.Add(this.contactTxt);
            this.Controls.Add(this.addressTxt);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.typeCbx);
            this.Controls.Add(this.cusPbx);
            this.Controls.Add(this.customerCbx);
            this.Controls.Add(this.noTxt);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Name = "InsuranceDialog";
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "Insurance";
            this.Load += new System.EventHandler(this.InsuranceDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cusPbx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Drawing.Html.HtmlToolTip htmlToolTip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private MetroFramework.Controls.MetroTextBox noTxt;
        private MetroFramework.Controls.MetroComboBox customerCbx;
        private System.Windows.Forms.PictureBox cusPbx;
        private MetroFramework.Controls.MetroComboBox typeCbx;
        private MetroFramework.Controls.MetroTextBox nameTxt;
        private MetroFramework.Controls.MetroTextBox addressTxt;
        private MetroFramework.Controls.MetroTextBox contactTxt;
        private MetroFramework.Controls.MetroTextBox zipTxt;
    }
}
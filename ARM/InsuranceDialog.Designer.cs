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
			this.catCbx = new System.Windows.Forms.ComboBox();
			this.typeCbx = new System.Windows.Forms.ComboBox();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.nameTxt = new MetroFramework.Controls.MetroTextBox();
			this.noTxt = new MetroFramework.Controls.MetroTextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.dateTxt = new System.Windows.Forms.DateTimePicker();
			this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
			this.SuspendLayout();
			// 
			// htmlToolTip1
			// 
			this.htmlToolTip1.OwnerDraw = true;
			// 
			// catCbx
			// 
			this.catCbx.AutoCompleteCustomSource.AddRange(new string[] {
            "State",
            "Federal"});
			this.catCbx.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.catCbx.FormattingEnabled = true;
			this.catCbx.Items.AddRange(new object[] {
            "Medicaid",
            "Medicare",
            "Other"});
			this.catCbx.Location = new System.Drawing.Point(82, 216);
			this.catCbx.Name = "catCbx";
			this.catCbx.Size = new System.Drawing.Size(286, 31);
			this.catCbx.TabIndex = 2;
			// 
			// typeCbx
			// 
			this.typeCbx.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.typeCbx.FormattingEnabled = true;
			this.typeCbx.Items.AddRange(new object[] {
            "Primary",
            "Secondary"});
			this.typeCbx.Location = new System.Drawing.Point(82, 179);
			this.typeCbx.Name = "typeCbx";
			this.typeCbx.Size = new System.Drawing.Size(286, 31);
			this.typeCbx.TabIndex = 1;
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.Location = new System.Drawing.Point(7, 179);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(36, 19);
			this.metroLabel1.TabIndex = 268;
			this.metroLabel1.Text = "Type";
			// 
			// metroLabel2
			// 
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.Location = new System.Drawing.Point(7, 216);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(64, 19);
			this.metroLabel2.TabIndex = 269;
			this.metroLabel2.Text = "Category";
			// 
			// nameTxt
			// 
			// 
			// 
			// 
			this.nameTxt.CustomButton.Image = null;
			this.nameTxt.CustomButton.Location = new System.Drawing.Point(252, 1);
			this.nameTxt.CustomButton.Name = "";
			this.nameTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
			this.nameTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.nameTxt.CustomButton.TabIndex = 1;
			this.nameTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.nameTxt.CustomButton.UseSelectable = true;
			this.nameTxt.CustomButton.Visible = false;
			this.nameTxt.DisplayIcon = true;
			this.nameTxt.Lines = new string[0];
			this.nameTxt.Location = new System.Drawing.Point(82, 133);
			this.nameTxt.MaxLength = 32767;
			this.nameTxt.Name = "nameTxt";
			this.nameTxt.PasswordChar = '\0';
			this.nameTxt.PromptText = "Insurance Company";
			this.nameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.nameTxt.SelectedText = "";
			this.nameTxt.SelectionLength = 0;
			this.nameTxt.SelectionStart = 0;
			this.nameTxt.ShortcutsEnabled = true;
			this.nameTxt.Size = new System.Drawing.Size(286, 35);
			this.nameTxt.TabIndex = 0;
			this.nameTxt.UseSelectable = true;
			this.nameTxt.WaterMark = "Insurance Company";
			this.nameTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.nameTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// noTxt
			// 
			// 
			// 
			// 
			this.noTxt.CustomButton.Image = null;
			this.noTxt.CustomButton.Location = new System.Drawing.Point(252, 1);
			this.noTxt.CustomButton.Name = "";
			this.noTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
			this.noTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.noTxt.CustomButton.TabIndex = 1;
			this.noTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.noTxt.CustomButton.UseSelectable = true;
			this.noTxt.CustomButton.Visible = false;
			this.noTxt.DisplayIcon = true;
			this.noTxt.Lines = new string[0];
			this.noTxt.Location = new System.Drawing.Point(82, 253);
			this.noTxt.MaxLength = 32767;
			this.noTxt.Name = "noTxt";
			this.noTxt.PasswordChar = '\0';
			this.noTxt.PromptText = "No.";
			this.noTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.noTxt.SelectedText = "";
			this.noTxt.SelectionLength = 0;
			this.noTxt.SelectionStart = 0;
			this.noTxt.ShortcutsEnabled = true;
			this.noTxt.Size = new System.Drawing.Size(286, 35);
			this.noTxt.TabIndex = 3;
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
			this.button3.Location = new System.Drawing.Point(260, 364);
			this.button3.Name = "button3";
			this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.button3.Size = new System.Drawing.Size(108, 49);
			this.button3.TabIndex = 5;
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
			this.button2.Location = new System.Drawing.Point(103, 364);
			this.button2.Name = "button2";
			this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.button2.Size = new System.Drawing.Size(108, 49);
			this.button2.TabIndex = 6;
			this.button2.Text = "Cancel";
			this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// dateTxt
			// 
			this.dateTxt.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTxt.Location = new System.Drawing.Point(82, 321);
			this.dateTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dateTxt.Name = "dateTxt";
			this.dateTxt.Size = new System.Drawing.Size(286, 26);
			this.dateTxt.TabIndex = 4;
			// 
			// metroLabel3
			// 
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.Location = new System.Drawing.Point(7, 253);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new System.Drawing.Size(63, 19);
			this.metroLabel3.TabIndex = 464;
			this.metroLabel3.Text = "Card No.";
			// 
			// metroLabel4
			// 
			this.metroLabel4.AutoSize = true;
			this.metroLabel4.Location = new System.Drawing.Point(7, 299);
			this.metroLabel4.Name = "metroLabel4";
			this.metroLabel4.Size = new System.Drawing.Size(75, 19);
			this.metroLabel4.TabIndex = 465;
			this.metroLabel4.Text = "Expiry date";
			// 
			// metroLabel5
			// 
			this.metroLabel5.AutoSize = true;
			this.metroLabel5.Location = new System.Drawing.Point(7, 111);
			this.metroLabel5.Name = "metroLabel5";
			this.metroLabel5.Size = new System.Drawing.Size(103, 19);
			this.metroLabel5.TabIndex = 466;
			this.metroLabel5.Text = "Company name";
			// 
			// InsuranceDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(429, 472);
			this.Controls.Add(this.metroLabel5);
			this.Controls.Add(this.metroLabel4);
			this.Controls.Add(this.metroLabel3);
			this.Controls.Add(this.dateTxt);
			this.Controls.Add(this.metroLabel2);
			this.Controls.Add(this.metroLabel1);
			this.Controls.Add(this.typeCbx);
			this.Controls.Add(this.catCbx);
			this.Controls.Add(this.nameTxt);
			this.Controls.Add(this.noTxt);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Name = "InsuranceDialog";
			this.Style = MetroFramework.MetroColorStyle.White;
			this.Text = "Coverage";
			this.Load += new System.EventHandler(this.InsuranceDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private MetroFramework.Drawing.Html.HtmlToolTip htmlToolTip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private MetroFramework.Controls.MetroTextBox noTxt;
        private MetroFramework.Controls.MetroTextBox nameTxt;
		private System.Windows.Forms.ComboBox catCbx;
		private System.Windows.Forms.ComboBox typeCbx;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private MetroFramework.Controls.MetroLabel metroLabel2;
		private System.Windows.Forms.DateTimePicker dateTxt;
		private MetroFramework.Controls.MetroLabel metroLabel3;
		private MetroFramework.Controls.MetroLabel metroLabel4;
		private MetroFramework.Controls.MetroLabel metroLabel5;
	}
}
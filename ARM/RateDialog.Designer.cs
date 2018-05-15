namespace ARM
{
    partial class RateDialog
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
            this.userCbx = new MetroFramework.Controls.MetroComboBox();
            this.unitCbx = new MetroFramework.Controls.MetroComboBox();
            this.userPbx = new System.Windows.Forms.PictureBox();
            this.costTxt = new MetroFramework.Controls.MetroTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.weeklyTxt = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.userCbx.Location = new System.Drawing.Point(86, 99);
            this.userCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userCbx.Name = "userCbx";
            this.userCbx.PromptText = "Physician";
            this.userCbx.Size = new System.Drawing.Size(254, 29);
            this.userCbx.TabIndex = 0;
            this.userCbx.UseSelectable = true;
            this.userCbx.SelectedIndexChanged += new System.EventHandler(this.userCbx_SelectedIndexChanged);
            // 
            // unitCbx
            // 
            this.unitCbx.FormattingEnabled = true;
            this.unitCbx.ItemHeight = 23;
            this.unitCbx.Items.AddRange(new object[] {
            "Hour",
            "Day",
            "Month"});
            this.unitCbx.Location = new System.Drawing.Point(86, 177);
            this.unitCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.unitCbx.Name = "unitCbx";
            this.unitCbx.PromptText = "Units";
            this.unitCbx.Size = new System.Drawing.Size(254, 29);
            this.unitCbx.TabIndex = 2;
            this.unitCbx.UseSelectable = true;
            // 
            // userPbx
            // 
            this.userPbx.Image = global::ARM.Properties.Resources.User_Profile_128;
            this.userPbx.Location = new System.Drawing.Point(346, 99);
            this.userPbx.Name = "userPbx";
            this.userPbx.Size = new System.Drawing.Size(74, 79);
            this.userPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userPbx.TabIndex = 179;
            this.userPbx.TabStop = false;
            // 
            // costTxt
            // 
            // 
            // 
            // 
            this.costTxt.CustomButton.Image = null;
            this.costTxt.CustomButton.Location = new System.Drawing.Point(231, 1);
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
            this.costTxt.Location = new System.Drawing.Point(86, 135);
            this.costTxt.MaxLength = 32767;
            this.costTxt.Name = "costTxt";
            this.costTxt.PasswordChar = '\0';
            this.costTxt.PromptText = "Rate/Hr";
            this.costTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.costTxt.SelectedText = "";
            this.costTxt.SelectionLength = 0;
            this.costTxt.SelectionStart = 0;
            this.costTxt.ShortcutsEnabled = true;
            this.costTxt.Size = new System.Drawing.Size(254, 35);
            this.costTxt.TabIndex = 1;
            this.costTxt.UseSelectable = true;
            this.costTxt.WaterMark = "Rate/Hr";
            this.costTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.costTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.costTxt.Click += new System.EventHandler(this.costTxt_Click);
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
            this.button3.Location = new System.Drawing.Point(232, 267);
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
            this.button2.Location = new System.Drawing.Point(86, 267);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(108, 49);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // weeklyTxt
            // 
            // 
            // 
            // 
            this.weeklyTxt.CustomButton.Image = null;
            this.weeklyTxt.CustomButton.Location = new System.Drawing.Point(188, 1);
            this.weeklyTxt.CustomButton.Name = "";
            this.weeklyTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.weeklyTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.weeklyTxt.CustomButton.TabIndex = 1;
            this.weeklyTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.weeklyTxt.CustomButton.UseSelectable = true;
            this.weeklyTxt.CustomButton.Visible = false;
            this.weeklyTxt.DisplayIcon = true;
            this.weeklyTxt.Icon = global::ARM.Properties.Resources.Layers_01_16;
            this.weeklyTxt.Lines = new string[0];
            this.weeklyTxt.Location = new System.Drawing.Point(86, 213);
            this.weeklyTxt.MaxLength = 32767;
            this.weeklyTxt.Name = "weeklyTxt";
            this.weeklyTxt.PasswordChar = '\0';
            this.weeklyTxt.PromptText = "Max week Hours";
            this.weeklyTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.weeklyTxt.SelectedText = "";
            this.weeklyTxt.SelectionLength = 0;
            this.weeklyTxt.SelectionStart = 0;
            this.weeklyTxt.ShortcutsEnabled = true;
            this.weeklyTxt.Size = new System.Drawing.Size(254, 35);
            this.weeklyTxt.TabIndex = 180;
            this.weeklyTxt.UseSelectable = true;
            this.weeklyTxt.WaterMark = "Max week Hours";
            this.weeklyTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.weeklyTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 181;
            this.label1.Text = "Max Hrs/Week";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 182;
            this.label2.Text = "Per/Units";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 183;
            this.label3.Text = "Payment @Hr";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 184;
            this.label4.Text = "Employee";
            // 
            // RateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 343);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.weeklyTxt);
            this.Controls.Add(this.unitCbx);
            this.Controls.Add(this.userPbx);
            this.Controls.Add(this.userCbx);
            this.Controls.Add(this.costTxt);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Name = "RateDialog";
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "Billable Hours";
            this.Load += new System.EventHandler(this.RateDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userPbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Drawing.Html.HtmlToolTip htmlToolTip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private MetroFramework.Controls.MetroTextBox costTxt;
        private MetroFramework.Controls.MetroComboBox userCbx;
        private System.Windows.Forms.PictureBox userPbx;
        private MetroFramework.Controls.MetroComboBox unitCbx;
        private MetroFramework.Controls.MetroTextBox weeklyTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
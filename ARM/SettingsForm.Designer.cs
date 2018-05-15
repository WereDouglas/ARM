namespace ARM
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.htmlToolTip1 = new MetroFramework.Drawing.Html.HtmlToolTip();
            this.ipTxt = new MetroFramework.Controls.MetroTextBox();
            this.localNameTxt = new MetroFramework.Controls.MetroTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.remoteTxt = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.defaultTxt = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.portTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.remoteNameTxt = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // htmlToolTip1
            // 
            this.htmlToolTip1.OwnerDraw = true;
            // 
            // ipTxt
            // 
            // 
            // 
            // 
            this.ipTxt.CustomButton.Image = null;
            this.ipTxt.CustomButton.Location = new System.Drawing.Point(231, 1);
            this.ipTxt.CustomButton.Name = "";
            this.ipTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.ipTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ipTxt.CustomButton.TabIndex = 1;
            this.ipTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ipTxt.CustomButton.UseSelectable = true;
            this.ipTxt.CustomButton.Visible = false;
            this.ipTxt.DisplayIcon = true;
            this.ipTxt.Icon = global::ARM.Properties.Resources.Shape_Cube_24;
            this.ipTxt.Lines = new string[0];
            this.ipTxt.Location = new System.Drawing.Point(87, 132);
            this.ipTxt.MaxLength = 32767;
            this.ipTxt.Name = "ipTxt";
            this.ipTxt.PasswordChar = '\0';
            this.ipTxt.PromptText = "Server IP Address";
            this.ipTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ipTxt.SelectedText = "";
            this.ipTxt.SelectionLength = 0;
            this.ipTxt.SelectionStart = 0;
            this.ipTxt.ShortcutsEnabled = true;
            this.ipTxt.Size = new System.Drawing.Size(265, 35);
            this.ipTxt.TabIndex = 1;
            this.ipTxt.UseSelectable = true;
            this.ipTxt.WaterMark = "Server IP Address";
            this.ipTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ipTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // localNameTxt
            // 
            // 
            // 
            // 
            this.localNameTxt.CustomButton.Image = null;
            this.localNameTxt.CustomButton.Location = new System.Drawing.Point(231, 1);
            this.localNameTxt.CustomButton.Name = "";
            this.localNameTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.localNameTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.localNameTxt.CustomButton.TabIndex = 1;
            this.localNameTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.localNameTxt.CustomButton.UseSelectable = true;
            this.localNameTxt.CustomButton.Visible = false;
            this.localNameTxt.DisplayIcon = true;
            this.localNameTxt.Icon = global::ARM.Properties.Resources.Globe_24;
            this.localNameTxt.Lines = new string[0];
            this.localNameTxt.Location = new System.Drawing.Point(87, 91);
            this.localNameTxt.MaxLength = 32767;
            this.localNameTxt.Name = "localNameTxt";
            this.localNameTxt.PasswordChar = '\0';
            this.localNameTxt.PromptText = "Server Name";
            this.localNameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.localNameTxt.SelectedText = "";
            this.localNameTxt.SelectionLength = 0;
            this.localNameTxt.SelectionStart = 0;
            this.localNameTxt.ShortcutsEnabled = true;
            this.localNameTxt.Size = new System.Drawing.Size(265, 35);
            this.localNameTxt.TabIndex = 0;
            this.localNameTxt.UseSelectable = true;
            this.localNameTxt.WaterMark = "Server Name";
            this.localNameTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.localNameTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.localNameTxt.Click += new System.EventHandler(this.costTxt_Click);
            this.localNameTxt.Leave += new System.EventHandler(this.localNameTxt_Leave);
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
            this.button3.Location = new System.Drawing.Point(244, 445);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button3.Size = new System.Drawing.Size(108, 49);
            this.button3.TabIndex = 2;
            this.button3.Text = "Save";
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
            this.button2.Location = new System.Drawing.Point(87, 445);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(108, 49);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // remoteTxt
            // 
            // 
            // 
            // 
            this.remoteTxt.CustomButton.Image = null;
            this.remoteTxt.CustomButton.Location = new System.Drawing.Point(231, 1);
            this.remoteTxt.CustomButton.Name = "";
            this.remoteTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.remoteTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.remoteTxt.CustomButton.TabIndex = 1;
            this.remoteTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.remoteTxt.CustomButton.UseSelectable = true;
            this.remoteTxt.CustomButton.Visible = false;
            this.remoteTxt.DisplayIcon = true;
            this.remoteTxt.Icon = global::ARM.Properties.Resources.Shape_Cube_24;
            this.remoteTxt.Lines = new string[0];
            this.remoteTxt.Location = new System.Drawing.Point(87, 258);
            this.remoteTxt.MaxLength = 32767;
            this.remoteTxt.Name = "remoteTxt";
            this.remoteTxt.PasswordChar = '\0';
            this.remoteTxt.PromptText = "Remote Address";
            this.remoteTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.remoteTxt.SelectedText = "";
            this.remoteTxt.SelectionLength = 0;
            this.remoteTxt.SelectionStart = 0;
            this.remoteTxt.ShortcutsEnabled = true;
            this.remoteTxt.Size = new System.Drawing.Size(265, 35);
            this.remoteTxt.TabIndex = 4;
            this.remoteTxt.UseSelectable = true;
            this.remoteTxt.WaterMark = "Remote Address";
            this.remoteTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.remoteTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Remote address";
            // 
            // defaultTxt
            // 
            this.defaultTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultTxt.FormattingEnabled = true;
            this.defaultTxt.Items.AddRange(new object[] {
            "Default",
            "Remote"});
            this.defaultTxt.Location = new System.Drawing.Point(87, 411);
            this.defaultTxt.Name = "defaultTxt";
            this.defaultTxt.Size = new System.Drawing.Size(265, 28);
            this.defaultTxt.TabIndex = 6;
            this.defaultTxt.SelectedIndexChanged += new System.EventHandler(this.defaultTxt_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Default Configuration";
            // 
            // portTxt
            // 
            this.portTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portTxt.Location = new System.Drawing.Point(87, 343);
            this.portTxt.Name = "portTxt";
            this.portTxt.Size = new System.Drawing.Size(265, 26);
            this.portTxt.TabIndex = 8;
            this.portTxt.Text = "5432";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Port";
            // 
            // remoteNameTxt
            // 
            // 
            // 
            // 
            this.remoteNameTxt.CustomButton.Image = null;
            this.remoteNameTxt.CustomButton.Location = new System.Drawing.Point(231, 1);
            this.remoteNameTxt.CustomButton.Name = "";
            this.remoteNameTxt.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.remoteNameTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.remoteNameTxt.CustomButton.TabIndex = 1;
            this.remoteNameTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.remoteNameTxt.CustomButton.UseSelectable = true;
            this.remoteNameTxt.CustomButton.Visible = false;
            this.remoteNameTxt.DisplayIcon = true;
            this.remoteNameTxt.Icon = global::ARM.Properties.Resources.Globe_24;
            this.remoteNameTxt.Lines = new string[0];
            this.remoteNameTxt.Location = new System.Drawing.Point(87, 217);
            this.remoteNameTxt.MaxLength = 32767;
            this.remoteNameTxt.Name = "remoteNameTxt";
            this.remoteNameTxt.PasswordChar = '\0';
            this.remoteNameTxt.PromptText = "Remote Server name";
            this.remoteNameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.remoteNameTxt.SelectedText = "";
            this.remoteNameTxt.SelectionLength = 0;
            this.remoteNameTxt.SelectionStart = 0;
            this.remoteNameTxt.ShortcutsEnabled = true;
            this.remoteNameTxt.Size = new System.Drawing.Size(265, 35);
            this.remoteNameTxt.TabIndex = 10;
            this.remoteNameTxt.UseSelectable = true;
            this.remoteNameTxt.WaterMark = "Remote Server name";
            this.remoteNameTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.remoteNameTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.remoteNameTxt.Leave += new System.EventHandler(this.remoteNameTxt_Leave);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 535);
            this.Controls.Add(this.remoteNameTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.portTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.defaultTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.remoteTxt);
            this.Controls.Add(this.ipTxt);
            this.Controls.Add(this.localNameTxt);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "Server Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Drawing.Html.HtmlToolTip htmlToolTip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private MetroFramework.Controls.MetroTextBox localNameTxt;
        private MetroFramework.Controls.MetroTextBox ipTxt;
        private MetroFramework.Controls.MetroTextBox remoteTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox defaultTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox portTxt;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroTextBox remoteNameTxt;
    }
}
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
            this.ipTxt.Location = new System.Drawing.Point(75, 133);
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
            this.localNameTxt.Location = new System.Drawing.Point(75, 91);
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
            this.button3.Location = new System.Drawing.Point(232, 174);
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
            this.button2.Location = new System.Drawing.Point(75, 174);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(108, 49);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 255);
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

        }

        #endregion
        private MetroFramework.Drawing.Html.HtmlToolTip htmlToolTip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private MetroFramework.Controls.MetroTextBox localNameTxt;
        private MetroFramework.Controls.MetroTextBox ipTxt;
    }
}
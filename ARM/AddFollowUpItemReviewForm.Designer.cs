namespace ARM
{
    partial class AddFollowUpItemReviewForm
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
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.detailsCbx = new MetroFramework.Controls.MetroComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.statusLabel = new MetroFramework.Controls.MetroLabel();
            this.stateCbx = new MetroFramework.Controls.MetroComboBox();
            this.detailsTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // htmlToolTip1
            // 
            this.htmlToolTip1.OwnerDraw = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(485, 60);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(47, 19);
            this.metroLabel3.TabIndex = 28;
            this.metroLabel3.Text = "Details";
            // 
            // detailsCbx
            // 
            this.detailsCbx.FormattingEnabled = true;
            this.detailsCbx.ItemHeight = 23;
            this.detailsCbx.Location = new System.Drawing.Point(23, 95);
            this.detailsCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.detailsCbx.Name = "detailsCbx";
            this.detailsCbx.Size = new System.Drawing.Size(214, 29);
            this.detailsCbx.TabIndex = 27;
            this.detailsCbx.UseSelectable = true;
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
            this.button3.Location = new System.Drawing.Point(840, 135);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button3.Size = new System.Drawing.Size(79, 49);
            this.button3.TabIndex = 38;
            this.button3.Text = "Add";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            this.button2.Location = new System.Drawing.Point(23, 135);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(107, 49);
            this.button2.TabIndex = 39;
            this.button2.Text = "Cancel";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(243, 60);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(38, 19);
            this.statusLabel.TabIndex = 41;
            this.statusLabel.Text = "State";
            // 
            // stateCbx
            // 
            this.stateCbx.FormattingEnabled = true;
            this.stateCbx.ItemHeight = 23;
            this.stateCbx.Location = new System.Drawing.Point(243, 95);
            this.stateCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stateCbx.Name = "stateCbx";
            this.stateCbx.Size = new System.Drawing.Size(213, 29);
            this.stateCbx.TabIndex = 40;
            this.stateCbx.UseSelectable = true;
            // 
            // detailsTxt
            // 
            this.detailsTxt.Location = new System.Drawing.Point(471, 95);
            this.detailsTxt.Multiline = true;
            this.detailsTxt.Name = "detailsTxt";
            this.detailsTxt.Size = new System.Drawing.Size(448, 29);
            this.detailsTxt.TabIndex = 42;
            // 
            // AddFollowUpItemReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 214);
            this.Controls.Add(this.detailsTxt);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.stateCbx);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.detailsCbx);
            this.Name = "AddFollowUpItemReviewForm";
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "Add";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Drawing.Html.HtmlToolTip htmlToolTip1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox detailsCbx;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private MetroFramework.Controls.MetroLabel statusLabel;
        private MetroFramework.Controls.MetroComboBox stateCbx;
        private System.Windows.Forms.TextBox detailsTxt;
    }
}
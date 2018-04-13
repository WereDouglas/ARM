namespace ARM
{
    partial class CareDialog
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
            this.userCbx = new MetroFramework.Controls.MetroComboBox();
            this.userPbx = new System.Windows.Forms.PictureBox();
            this.cusPbx = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.userPbx)).BeginInit();
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
            this.customerCbx.Location = new System.Drawing.Point(75, 99);
            this.customerCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customerCbx.Name = "customerCbx";
            this.customerCbx.PromptText = "Patient";
            this.customerCbx.Size = new System.Drawing.Size(265, 29);
            this.customerCbx.TabIndex = 133;
            this.customerCbx.UseSelectable = true;
            this.customerCbx.SelectedIndexChanged += new System.EventHandler(this.customerCbx_SelectedIndexChanged);
            // 
            // userCbx
            // 
            this.userCbx.FormattingEnabled = true;
            this.userCbx.ItemHeight = 23;
            this.userCbx.Location = new System.Drawing.Point(75, 136);
            this.userCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userCbx.Name = "userCbx";
            this.userCbx.PromptText = "Physician";
            this.userCbx.Size = new System.Drawing.Size(265, 29);
            this.userCbx.TabIndex = 134;
            this.userCbx.UseSelectable = true;
            this.userCbx.SelectedIndexChanged += new System.EventHandler(this.userCbx_SelectedIndexChanged);
            // 
            // userPbx
            // 
            this.userPbx.Image = global::ARM.Properties.Resources.User_Profile_128;
            this.userPbx.Location = new System.Drawing.Point(1, 136);
            this.userPbx.Name = "userPbx";
            this.userPbx.Size = new System.Drawing.Size(68, 40);
            this.userPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userPbx.TabIndex = 179;
            this.userPbx.TabStop = false;
            // 
            // cusPbx
            // 
            this.cusPbx.Image = global::ARM.Properties.Resources.User_Profile_128;
            this.cusPbx.Location = new System.Drawing.Point(1, 82);
            this.cusPbx.Name = "cusPbx";
            this.cusPbx.Size = new System.Drawing.Size(68, 46);
            this.cusPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cusPbx.TabIndex = 178;
            this.cusPbx.TabStop = false;
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
            this.button3.Location = new System.Drawing.Point(232, 198);
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
            this.button2.Location = new System.Drawing.Point(75, 198);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(108, 49);
            this.button2.TabIndex = 13;
            this.button2.Text = "Cancel";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CareDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 289);
            this.Controls.Add(this.userPbx);
            this.Controls.Add(this.cusPbx);
            this.Controls.Add(this.userCbx);
            this.Controls.Add(this.customerCbx);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Name = "CareDialog";
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "Care";
            this.Load += new System.EventHandler(this.CareDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userPbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cusPbx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Drawing.Html.HtmlToolTip htmlToolTip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private MetroFramework.Controls.MetroComboBox customerCbx;
        private MetroFramework.Controls.MetroComboBox userCbx;
        private System.Windows.Forms.PictureBox cusPbx;
        private System.Windows.Forms.PictureBox userPbx;
    }
}
namespace ARM
{
    partial class AddDiagnosis
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDiagnosis));
			this.htmlToolTip1 = new MetroFramework.Drawing.Html.HtmlToolTip();
			this.label3 = new System.Windows.Forms.Label();
			this.codeTxt = new System.Windows.Forms.TextBox();
			this.diagnosisTxt = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.lessChk = new System.Windows.Forms.CheckBox();
			this.greaterChk = new System.Windows.Forms.CheckBox();
			this.dateTxt = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.nameTxt = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// htmlToolTip1
			// 
			this.htmlToolTip1.OwnerDraw = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 66);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 19);
			this.label3.TabIndex = 267;
			this.label3.Text = "ICD10 Code";
			// 
			// codeTxt
			// 
			this.codeTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.codeTxt.Location = new System.Drawing.Point(101, 63);
			this.codeTxt.Name = "codeTxt";
			this.codeTxt.Size = new System.Drawing.Size(231, 27);
			this.codeTxt.TabIndex = 268;
			// 
			// diagnosisTxt
			// 
			this.diagnosisTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.diagnosisTxt.Location = new System.Drawing.Point(101, 149);
			this.diagnosisTxt.Multiline = true;
			this.diagnosisTxt.Name = "diagnosisTxt";
			this.diagnosisTxt.Size = new System.Drawing.Size(231, 38);
			this.diagnosisTxt.TabIndex = 269;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 127);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(125, 19);
			this.label1.TabIndex = 270;
			this.label1.Text = "Clinical Diagnosis";
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
			this.button3.Location = new System.Drawing.Point(254, 294);
			this.button3.Name = "button3";
			this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.button3.Size = new System.Drawing.Size(87, 49);
			this.button3.TabIndex = 0;
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
			this.button2.Location = new System.Drawing.Point(16, 294);
			this.button2.Name = "button2";
			this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.button2.Size = new System.Drawing.Size(107, 49);
			this.button2.TabIndex = 1;
			this.button2.Text = "Cancel";
			this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// lessChk
			// 
			this.lessChk.AutoSize = true;
			this.lessChk.Location = new System.Drawing.Point(101, 193);
			this.lessChk.Name = "lessChk";
			this.lessChk.Size = new System.Drawing.Size(117, 17);
			this.lessChk.TabIndex = 506;
			this.lessChk.Text = "Less than 6 months";
			this.lessChk.UseVisualStyleBackColor = true;
			// 
			// greaterChk
			// 
			this.greaterChk.AutoSize = true;
			this.greaterChk.Location = new System.Drawing.Point(224, 193);
			this.greaterChk.Name = "greaterChk";
			this.greaterChk.Size = new System.Drawing.Size(133, 17);
			this.greaterChk.TabIndex = 507;
			this.greaterChk.Text = "Greater than 6 months";
			this.greaterChk.UseVisualStyleBackColor = true;
			// 
			// dateTxt
			// 
			this.dateTxt.Location = new System.Drawing.Point(101, 253);
			this.dateTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dateTxt.Name = "dateTxt";
			this.dateTxt.Size = new System.Drawing.Size(231, 21);
			this.dateTxt.TabIndex = 508;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 232);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(97, 19);
			this.label2.TabIndex = 509;
			this.label2.Text = "Date of onset";
			// 
			// nameTxt
			// 
			this.nameTxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nameTxt.Location = new System.Drawing.Point(101, 97);
			this.nameTxt.Name = "nameTxt";
			this.nameTxt.Size = new System.Drawing.Size(231, 27);
			this.nameTxt.TabIndex = 510;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(12, 100);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 19);
			this.label4.TabIndex = 511;
			this.label4.Text = "Title";
			// 
			// AddDiagnosis
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(382, 379);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.nameTxt);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dateTxt);
			this.Controls.Add(this.greaterChk);
			this.Controls.Add(this.lessChk);
			this.Controls.Add(this.codeTxt);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.diagnosisTxt);
			this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AddDiagnosis";
			this.Style = MetroFramework.MetroColorStyle.White;
			this.Text = "Diagnosis(ICD-10)";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private MetroFramework.Drawing.Html.HtmlToolTip htmlToolTip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codeTxt;
        private System.Windows.Forms.TextBox diagnosisTxt;
		private System.Windows.Forms.CheckBox lessChk;
		private System.Windows.Forms.CheckBox greaterChk;
		private System.Windows.Forms.DateTimePicker dateTxt;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox nameTxt;
		private System.Windows.Forms.Label label4;
	}
}
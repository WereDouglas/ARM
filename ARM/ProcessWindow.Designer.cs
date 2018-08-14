namespace ARM
{
	partial class ProcessWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessWindow));
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.processLbl = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(29, 191);
			this.progressBar1.Maximum = 18;
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(312, 23);
			this.progressBar1.TabIndex = 295;
			// 
			// processLbl
			// 
			this.processLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.processLbl.BackColor = System.Drawing.SystemColors.ControlText;
			this.processLbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.processLbl.ForeColor = System.Drawing.SystemColors.Info;
			this.processLbl.Location = new System.Drawing.Point(29, 220);
			this.processLbl.Multiline = true;
			this.processLbl.Name = "processLbl";
			this.processLbl.Size = new System.Drawing.Size(312, 147);
			this.processLbl.TabIndex = 294;
			this.processLbl.TextChanged += new System.EventHandler(this.processLbl_TextChanged_1);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::ARM.Properties.Resources.loading1;
			this.pictureBox1.Location = new System.Drawing.Point(29, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(312, 161);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 293;
			this.pictureBox1.TabStop = false;
			// 
			// ProcessWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.ClientSize = new System.Drawing.Size(371, 393);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.processLbl);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ProcessWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ProcessWindow";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.TextBox processLbl;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
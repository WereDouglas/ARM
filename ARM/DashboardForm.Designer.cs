namespace ARM
{
    partial class DashboardForm
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
			this.components = new System.ComponentModel.Container();
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.label14 = new System.Windows.Forms.Label();
			this.invoiceLbl = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.label8 = new System.Windows.Forms.Label();
			this.customerLbl = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.paidLbl = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.label11 = new System.Windows.Forms.Label();
			this.itemLbl = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.pendingLbl = new System.Windows.Forms.Label();
			this.InvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.InvoiceBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.37931F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.62069F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 566F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 506F));
			this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.reportViewer1, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.90282F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.09718F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 439F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1364, 641);
			this.tableLayoutPanel1.TabIndex = 1;
			this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
			// 
			// reportViewer1
			// 
			this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tableLayoutPanel1.SetColumnSpan(this.reportViewer1, 3);
			this.reportViewer1.DocumentMapWidth = 35;
			reportDataSource1.Name = "DataSetInvoice";
			reportDataSource1.Value = this.InvoiceBindingSource;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "ARM.DashboardReport.rdlc";
			this.reportViewer1.Location = new System.Drawing.Point(123, 196);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.ServerReport.BearerToken = null;
			this.reportViewer1.ShowToolBar = false;
			this.reportViewer1.Size = new System.Drawing.Size(1238, 433);
			this.reportViewer1.TabIndex = 51;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.panel1, 3);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Location = new System.Drawing.Point(123, 3);
			this.panel1.Name = "panel1";
			this.tableLayoutPanel1.SetRowSpan(this.panel1, 2);
			this.panel1.Size = new System.Drawing.Size(1238, 187);
			this.panel1.TabIndex = 50;
			// 
			// panel6
			// 
			this.panel6.BackgroundImage = global::ARM.Properties.Resources.fancybox_overlay;
			this.panel6.Controls.Add(this.label14);
			this.panel6.Controls.Add(this.invoiceLbl);
			this.panel6.Location = new System.Drawing.Point(3, 3);
			this.panel6.Name = "panel6";
			this.tableLayoutPanel1.SetRowSpan(this.panel6, 3);
			this.panel6.Size = new System.Drawing.Size(114, 626);
			this.panel6.TabIndex = 1;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.BackColor = System.Drawing.Color.Transparent;
			this.label14.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label14.Location = new System.Drawing.Point(14, 99);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(52, 18);
			this.label14.TabIndex = 3;
			this.label14.Text = "Invoices";
			// 
			// invoiceLbl
			// 
			this.invoiceLbl.BackColor = System.Drawing.Color.Transparent;
			this.invoiceLbl.Font = new System.Drawing.Font("Trebuchet MS", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.invoiceLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.invoiceLbl.Location = new System.Drawing.Point(3, 19);
			this.invoiceLbl.Name = "invoiceLbl";
			this.invoiceLbl.Size = new System.Drawing.Size(65, 81);
			this.invoiceLbl.TabIndex = 1;
			this.invoiceLbl.Text = "0";
			this.invoiceLbl.UseMnemonic = false;
			// 
			// panel4
			// 
			this.panel4.BackgroundImage = global::ARM.Properties.Resources.statistic_box_yellow;
			this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.panel4.Controls.Add(this.label8);
			this.panel4.Controls.Add(this.customerLbl);
			this.panel4.Location = new System.Drawing.Point(3, 9);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(271, 199);
			this.panel4.TabIndex = 4;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label8.Location = new System.Drawing.Point(20, 19);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(82, 24);
			this.label8.TabIndex = 1;
			this.label8.Text = "Patients";
			// 
			// customerLbl
			// 
			this.customerLbl.BackColor = System.Drawing.Color.Transparent;
			this.customerLbl.Font = new System.Drawing.Font("Trebuchet MS", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.customerLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.customerLbl.Location = new System.Drawing.Point(86, 49);
			this.customerLbl.Name = "customerLbl";
			this.customerLbl.Size = new System.Drawing.Size(146, 83);
			this.customerLbl.TabIndex = 0;
			this.customerLbl.Text = "3";
			this.customerLbl.UseMnemonic = false;
			// 
			// panel3
			// 
			this.panel3.BackgroundImage = global::ARM.Properties.Resources.statistic_box_purple;
			this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.panel3.Controls.Add(this.label5);
			this.panel3.Controls.Add(this.paidLbl);
			this.panel3.Location = new System.Drawing.Point(306, 9);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(271, 199);
			this.panel3.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label5.Location = new System.Drawing.Point(18, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(142, 24);
			this.label5.TabIndex = 1;
			this.label5.Text = "Paid Schedules";
			// 
			// paidLbl
			// 
			this.paidLbl.BackColor = System.Drawing.Color.Transparent;
			this.paidLbl.Font = new System.Drawing.Font("Trebuchet MS", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.paidLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.paidLbl.Location = new System.Drawing.Point(66, 51);
			this.paidLbl.Name = "paidLbl";
			this.paidLbl.Size = new System.Drawing.Size(136, 81);
			this.paidLbl.TabIndex = 0;
			this.paidLbl.Text = "3";
			this.paidLbl.UseMnemonic = false;
			// 
			// panel5
			// 
			this.panel5.BackgroundImage = global::ARM.Properties.Resources.statistic_box_green;
			this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.panel5.Controls.Add(this.label11);
			this.panel5.Controls.Add(this.itemLbl);
			this.panel5.Location = new System.Drawing.Point(620, 9);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(271, 199);
			this.panel5.TabIndex = 4;
			this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label11.Location = new System.Drawing.Point(23, 18);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(212, 24);
			this.label11.TabIndex = 1;
			this.label11.Text = "Products /Merchandise";
			// 
			// itemLbl
			// 
			this.itemLbl.BackColor = System.Drawing.Color.Transparent;
			this.itemLbl.Font = new System.Drawing.Font("Trebuchet MS", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.itemLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.itemLbl.Location = new System.Drawing.Point(74, 48);
			this.itemLbl.Name = "itemLbl";
			this.itemLbl.Size = new System.Drawing.Size(128, 65);
			this.itemLbl.TabIndex = 0;
			this.itemLbl.Text = "3";
			this.itemLbl.UseMnemonic = false;
			// 
			// panel2
			// 
			this.panel2.BackgroundImage = global::ARM.Properties.Resources.statistic_box_red;
			this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.pendingLbl);
			this.panel2.Location = new System.Drawing.Point(934, 9);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(271, 199);
			this.panel2.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label2.Location = new System.Drawing.Point(29, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(175, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "Pending Schedules";
			// 
			// pendingLbl
			// 
			this.pendingLbl.BackColor = System.Drawing.Color.Transparent;
			this.pendingLbl.Font = new System.Drawing.Font("Trebuchet MS", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pendingLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.pendingLbl.Location = new System.Drawing.Point(86, 48);
			this.pendingLbl.Name = "pendingLbl";
			this.pendingLbl.Size = new System.Drawing.Size(146, 74);
			this.pendingLbl.TabIndex = 0;
			this.pendingLbl.Text = "5";
			this.pendingLbl.UseMnemonic = false;
			// 
			// InvoiceBindingSource
			// 
			this.InvoiceBindingSource.DataSource = typeof(ARM.Model.Invoice);
			// 
			// DashboardForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.ClientSize = new System.Drawing.Size(1364, 641);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "DashboardForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "DashboardForm";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.DashboardForm_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.InvoiceBindingSource)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label pendingLbl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label paidLbl;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label customerLbl;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label itemLbl;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label invoiceLbl;
        private System.Windows.Forms.BindingSource InvoiceBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
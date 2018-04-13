namespace ARM
{
    partial class AddTransaction
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dateTxt = new MetroFramework.Controls.MetroDateTime();
            this.typeCbx = new MetroFramework.Controls.MetroComboBox();
            this.categoryCbx = new MetroFramework.Controls.MetroComboBox();
            this.methodCbx = new MetroFramework.Controls.MetroComboBox();
            this.termsTxt = new MetroFramework.Controls.MetroTextBox();
            this.taxTxt = new MetroFramework.Controls.MetroTextBox();
            this.balanceTxt = new MetroFramework.Controls.MetroTextBox();
            this.ItemCountTxt = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.amountTxt = new MetroFramework.Controls.MetroTextBox();
            this.vendorTxt = new MetroFramework.Controls.MetroTextBox();
            this.customerTxt = new MetroFramework.Controls.MetroTextBox();
            this.totalTxt = new MetroFramework.Controls.MetroTextBox();
            this.dtGrid = new System.Windows.Forms.DataGridView();
            this.noTxt = new MetroFramework.Controls.MetroTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.vendorPbx = new System.Windows.Forms.PictureBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.InvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorPbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(10);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1242, 52);
            this.toolStrip1.TabIndex = 46;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.08032F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.91968F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 46);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.8071749F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 99.19283F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1245, 502);
            this.tableLayoutPanel1.TabIndex = 47;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.noTxt);
            this.panel1.Controls.Add(this.dtGrid);
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.dateTxt);
            this.panel1.Controls.Add(this.typeCbx);
            this.panel1.Controls.Add(this.totalTxt);
            this.panel1.Controls.Add(this.categoryCbx);
            this.panel1.Controls.Add(this.customerTxt);
            this.panel1.Controls.Add(this.vendorTxt);
            this.panel1.Controls.Add(this.amountTxt);
            this.panel1.Controls.Add(this.metroLabel1);
            this.panel1.Controls.Add(this.ItemCountTxt);
            this.panel1.Controls.Add(this.balanceTxt);
            this.panel1.Controls.Add(this.taxTxt);
            this.panel1.Controls.Add(this.termsTxt);
            this.panel1.Controls.Add(this.methodCbx);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.vendorPbx);
            this.panel1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 6);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 2);
            this.panel1.Size = new System.Drawing.Size(1239, 493);
            this.panel1.TabIndex = 41;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.InvoiceBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ARM.InvoiceReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(467, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Padding = new System.Windows.Forms.Padding(5);
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(769, 477);
            this.reportViewer1.TabIndex = 0;
            // 
            // dateTxt
            // 
            this.dateTxt.DisplayFocus = true;
            this.dateTxt.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTxt.Location = new System.Drawing.Point(267, 3);
            this.dateTxt.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateTxt.Name = "dateTxt";
            this.dateTxt.Size = new System.Drawing.Size(189, 29);
            this.dateTxt.Style = MetroFramework.MetroColorStyle.Green;
            this.dateTxt.TabIndex = 2;
            this.dateTxt.UseStyleColors = true;
            // 
            // typeCbx
            // 
            this.typeCbx.FormattingEnabled = true;
            this.typeCbx.ItemHeight = 23;
            this.typeCbx.Items.AddRange(new object[] {
            "Credit",
            "Debit"});
            this.typeCbx.Location = new System.Drawing.Point(17, 91);
            this.typeCbx.Name = "typeCbx";
            this.typeCbx.PromptText = "Credit/Debit";
            this.typeCbx.Size = new System.Drawing.Size(241, 29);
            this.typeCbx.Style = MetroFramework.MetroColorStyle.Green;
            this.typeCbx.TabIndex = 4;
            this.typeCbx.Theme = MetroFramework.MetroThemeStyle.Light;
            this.typeCbx.UseSelectable = true;
            this.typeCbx.UseStyleColors = true;
            // 
            // categoryCbx
            // 
            this.categoryCbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.categoryCbx.FormattingEnabled = true;
            this.categoryCbx.ItemHeight = 23;
            this.categoryCbx.Items.AddRange(new object[] {
            "Sale",
            "Purchase",
            "Rent",
            "Maintenance"});
            this.categoryCbx.Location = new System.Drawing.Point(17, 0);
            this.categoryCbx.Name = "categoryCbx";
            this.categoryCbx.PromptText = "Purchase/Sale";
            this.categoryCbx.Size = new System.Drawing.Size(241, 29);
            this.categoryCbx.Style = MetroFramework.MetroColorStyle.Green;
            this.categoryCbx.TabIndex = 3;
            this.categoryCbx.UseSelectable = true;
            this.categoryCbx.UseStyleColors = true;
            this.categoryCbx.SelectedIndexChanged += new System.EventHandler(this.categoryCbx_SelectedIndexChanged);
            // 
            // methodCbx
            // 
            this.methodCbx.FormattingEnabled = true;
            this.methodCbx.ItemHeight = 23;
            this.methodCbx.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.methodCbx.Location = new System.Drawing.Point(13, 291);
            this.methodCbx.Name = "methodCbx";
            this.methodCbx.PromptText = "Method";
            this.methodCbx.Size = new System.Drawing.Size(238, 29);
            this.methodCbx.Style = MetroFramework.MetroColorStyle.Green;
            this.methodCbx.TabIndex = 6;
            this.methodCbx.UseSelectable = true;
            this.methodCbx.UseStyleColors = true;
            this.methodCbx.SelectedIndexChanged += new System.EventHandler(this.metroComboBox1_SelectedIndexChanged);
            // 
            // termsTxt
            // 
            // 
            // 
            // 
            this.termsTxt.CustomButton.Image = null;
            this.termsTxt.CustomButton.Location = new System.Drawing.Point(210, 1);
            this.termsTxt.CustomButton.Name = "";
            this.termsTxt.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.termsTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.termsTxt.CustomButton.TabIndex = 1;
            this.termsTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.termsTxt.CustomButton.UseSelectable = true;
            this.termsTxt.CustomButton.Visible = false;
            this.termsTxt.Lines = new string[0];
            this.termsTxt.Location = new System.Drawing.Point(13, 384);
            this.termsTxt.MaxLength = 32767;
            this.termsTxt.Multiline = true;
            this.termsTxt.Name = "termsTxt";
            this.termsTxt.PasswordChar = '\0';
            this.termsTxt.PromptText = "Terms && conditions";
            this.termsTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.termsTxt.SelectedText = "";
            this.termsTxt.SelectionLength = 0;
            this.termsTxt.SelectionStart = 0;
            this.termsTxt.ShortcutsEnabled = true;
            this.termsTxt.Size = new System.Drawing.Size(238, 29);
            this.termsTxt.Style = MetroFramework.MetroColorStyle.Green;
            this.termsTxt.TabIndex = 12;
            this.termsTxt.UseSelectable = true;
            this.termsTxt.WaterMark = "Terms && conditions";
            this.termsTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.termsTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // taxTxt
            // 
            // 
            // 
            // 
            this.taxTxt.CustomButton.Image = null;
            this.taxTxt.CustomButton.Location = new System.Drawing.Point(216, 1);
            this.taxTxt.CustomButton.Name = "";
            this.taxTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.taxTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.taxTxt.CustomButton.TabIndex = 1;
            this.taxTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.taxTxt.CustomButton.UseSelectable = true;
            this.taxTxt.CustomButton.Visible = false;
            this.taxTxt.Lines = new string[0];
            this.taxTxt.Location = new System.Drawing.Point(13, 355);
            this.taxTxt.MaxLength = 32767;
            this.taxTxt.Name = "taxTxt";
            this.taxTxt.PasswordChar = '\0';
            this.taxTxt.PromptText = "Tax";
            this.taxTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.taxTxt.SelectedText = "";
            this.taxTxt.SelectionLength = 0;
            this.taxTxt.SelectionStart = 0;
            this.taxTxt.ShortcutsEnabled = true;
            this.taxTxt.Size = new System.Drawing.Size(238, 23);
            this.taxTxt.Style = MetroFramework.MetroColorStyle.Green;
            this.taxTxt.TabIndex = 10;
            this.taxTxt.UseSelectable = true;
            this.taxTxt.WaterMark = "Tax";
            this.taxTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.taxTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // balanceTxt
            // 
            // 
            // 
            // 
            this.balanceTxt.CustomButton.FlatAppearance.BorderSize = 0;
            this.balanceTxt.CustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.balanceTxt.CustomButton.Image = null;
            this.balanceTxt.CustomButton.Location = new System.Drawing.Point(157, 1);
            this.balanceTxt.CustomButton.Name = "";
            this.balanceTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.balanceTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.balanceTxt.CustomButton.TabIndex = 1;
            this.balanceTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.balanceTxt.CustomButton.UseSelectable = true;
            this.balanceTxt.CustomButton.Visible = false;
            this.balanceTxt.Lines = new string[0];
            this.balanceTxt.Location = new System.Drawing.Point(269, 355);
            this.balanceTxt.MaxLength = 32767;
            this.balanceTxt.Name = "balanceTxt";
            this.balanceTxt.PasswordChar = '\0';
            this.balanceTxt.PromptText = "Balance";
            this.balanceTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.balanceTxt.SelectedText = "";
            this.balanceTxt.SelectionLength = 0;
            this.balanceTxt.SelectionStart = 0;
            this.balanceTxt.ShortcutsEnabled = true;
            this.balanceTxt.Size = new System.Drawing.Size(179, 23);
            this.balanceTxt.Style = MetroFramework.MetroColorStyle.White;
            this.balanceTxt.TabIndex = 11;
            this.balanceTxt.Theme = MetroFramework.MetroThemeStyle.Light;
            this.balanceTxt.UseSelectable = true;
            this.balanceTxt.UseStyleColors = true;
            this.balanceTxt.WaterMark = "Balance";
            this.balanceTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.balanceTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ItemCountTxt
            // 
            // 
            // 
            // 
            this.ItemCountTxt.CustomButton.FlatAppearance.BorderSize = 0;
            this.ItemCountTxt.CustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ItemCountTxt.CustomButton.Image = null;
            this.ItemCountTxt.CustomButton.Location = new System.Drawing.Point(157, 1);
            this.ItemCountTxt.CustomButton.Name = "";
            this.ItemCountTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ItemCountTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ItemCountTxt.CustomButton.TabIndex = 1;
            this.ItemCountTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ItemCountTxt.CustomButton.UseSelectable = true;
            this.ItemCountTxt.CustomButton.Visible = false;
            this.ItemCountTxt.Lines = new string[0];
            this.ItemCountTxt.Location = new System.Drawing.Point(269, 326);
            this.ItemCountTxt.MaxLength = 32767;
            this.ItemCountTxt.Name = "ItemCountTxt";
            this.ItemCountTxt.PasswordChar = '\0';
            this.ItemCountTxt.PromptText = "Count";
            this.ItemCountTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ItemCountTxt.SelectedText = "";
            this.ItemCountTxt.SelectionLength = 0;
            this.ItemCountTxt.SelectionStart = 0;
            this.ItemCountTxt.ShortcutsEnabled = true;
            this.ItemCountTxt.Size = new System.Drawing.Size(179, 23);
            this.ItemCountTxt.Style = MetroFramework.MetroColorStyle.White;
            this.ItemCountTxt.TabIndex = 9;
            this.ItemCountTxt.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ItemCountTxt.UseSelectable = true;
            this.ItemCountTxt.UseStyleColors = true;
            this.ItemCountTxt.WaterMark = "Count";
            this.ItemCountTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ItemCountTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.metroLabel1.Location = new System.Drawing.Point(39, 123);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(90, 23);
            this.metroLabel1.TabIndex = 248;
            this.metroLabel1.Text = "Products";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // amountTxt
            // 
            // 
            // 
            // 
            this.amountTxt.CustomButton.Image = null;
            this.amountTxt.CustomButton.Location = new System.Drawing.Point(216, 1);
            this.amountTxt.CustomButton.Name = "";
            this.amountTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.amountTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.amountTxt.CustomButton.TabIndex = 1;
            this.amountTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.amountTxt.CustomButton.UseSelectable = true;
            this.amountTxt.CustomButton.Visible = false;
            this.amountTxt.Lines = new string[0];
            this.amountTxt.Location = new System.Drawing.Point(13, 326);
            this.amountTxt.MaxLength = 32767;
            this.amountTxt.Name = "amountTxt";
            this.amountTxt.PasswordChar = '\0';
            this.amountTxt.PromptText = "Amount paid";
            this.amountTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.amountTxt.SelectedText = "";
            this.amountTxt.SelectionLength = 0;
            this.amountTxt.SelectionStart = 0;
            this.amountTxt.ShortcutsEnabled = true;
            this.amountTxt.Size = new System.Drawing.Size(238, 23);
            this.amountTxt.Style = MetroFramework.MetroColorStyle.Green;
            this.amountTxt.TabIndex = 8;
            this.amountTxt.UseSelectable = true;
            this.amountTxt.WaterMark = "Amount paid";
            this.amountTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.amountTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.amountTxt.TextChanged += new System.EventHandler(this.amountTxt_TextChanged);
            this.amountTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.amountTxt_KeyPress);
            // 
            // vendorTxt
            // 
            // 
            // 
            // 
            this.vendorTxt.CustomButton.Image = null;
            this.vendorTxt.CustomButton.Location = new System.Drawing.Point(219, 1);
            this.vendorTxt.CustomButton.Name = "";
            this.vendorTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.vendorTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.vendorTxt.CustomButton.TabIndex = 1;
            this.vendorTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.vendorTxt.CustomButton.UseSelectable = true;
            this.vendorTxt.CustomButton.Visible = false;
            this.vendorTxt.Lines = new string[0];
            this.vendorTxt.Location = new System.Drawing.Point(17, 33);
            this.vendorTxt.MaxLength = 32767;
            this.vendorTxt.Name = "vendorTxt";
            this.vendorTxt.PasswordChar = '\0';
            this.vendorTxt.PromptText = "Shipping from";
            this.vendorTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.vendorTxt.SelectedText = "";
            this.vendorTxt.SelectionLength = 0;
            this.vendorTxt.SelectionStart = 0;
            this.vendorTxt.ShortcutsEnabled = true;
            this.vendorTxt.Size = new System.Drawing.Size(241, 23);
            this.vendorTxt.Style = MetroFramework.MetroColorStyle.Green;
            this.vendorTxt.TabIndex = 0;
            this.vendorTxt.UseSelectable = true;
            this.vendorTxt.WaterMark = "Shipping from";
            this.vendorTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.vendorTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.vendorTxt.Leave += new System.EventHandler(this.vendorTxt_Leave);
            // 
            // customerTxt
            // 
            // 
            // 
            // 
            this.customerTxt.CustomButton.Image = null;
            this.customerTxt.CustomButton.Location = new System.Drawing.Point(219, 1);
            this.customerTxt.CustomButton.Name = "";
            this.customerTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.customerTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.customerTxt.CustomButton.TabIndex = 1;
            this.customerTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.customerTxt.CustomButton.UseSelectable = true;
            this.customerTxt.CustomButton.Visible = false;
            this.customerTxt.Lines = new string[0];
            this.customerTxt.Location = new System.Drawing.Point(17, 62);
            this.customerTxt.MaxLength = 32767;
            this.customerTxt.Name = "customerTxt";
            this.customerTxt.PasswordChar = '\0';
            this.customerTxt.PromptText = "Shipping to";
            this.customerTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.customerTxt.SelectedText = "";
            this.customerTxt.SelectionLength = 0;
            this.customerTxt.SelectionStart = 0;
            this.customerTxt.ShortcutsEnabled = true;
            this.customerTxt.Size = new System.Drawing.Size(241, 23);
            this.customerTxt.Style = MetroFramework.MetroColorStyle.Green;
            this.customerTxt.TabIndex = 1;
            this.customerTxt.UseSelectable = true;
            this.customerTxt.WaterMark = "Shipping to";
            this.customerTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.customerTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.customerTxt.Leave += new System.EventHandler(this.customerTxt_Leave);
            // 
            // totalTxt
            // 
            this.totalTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.totalTxt.CustomButton.FlatAppearance.BorderSize = 0;
            this.totalTxt.CustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.totalTxt.CustomButton.Image = null;
            this.totalTxt.CustomButton.Location = new System.Drawing.Point(157, 1);
            this.totalTxt.CustomButton.Name = "";
            this.totalTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.totalTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.totalTxt.CustomButton.TabIndex = 1;
            this.totalTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.totalTxt.CustomButton.UseSelectable = true;
            this.totalTxt.CustomButton.Visible = false;
            this.totalTxt.Lines = new string[0];
            this.totalTxt.Location = new System.Drawing.Point(269, 291);
            this.totalTxt.MaxLength = 32767;
            this.totalTxt.Name = "totalTxt";
            this.totalTxt.PasswordChar = '\0';
            this.totalTxt.PromptText = "Total";
            this.totalTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.totalTxt.SelectedText = "";
            this.totalTxt.SelectionLength = 0;
            this.totalTxt.SelectionStart = 0;
            this.totalTxt.ShortcutsEnabled = true;
            this.totalTxt.Size = new System.Drawing.Size(179, 23);
            this.totalTxt.Style = MetroFramework.MetroColorStyle.White;
            this.totalTxt.TabIndex = 7;
            this.totalTxt.Theme = MetroFramework.MetroThemeStyle.Light;
            this.totalTxt.UseSelectable = true;
            this.totalTxt.UseStyleColors = true;
            this.totalTxt.WaterMark = "Total";
            this.totalTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.totalTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dtGrid
            // 
            this.dtGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtGrid.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dtGrid.Location = new System.Drawing.Point(17, 156);
            this.dtGrid.Name = "dtGrid";
            this.dtGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGrid.RowHeadersWidth = 20;
            this.dtGrid.Size = new System.Drawing.Size(440, 129);
            this.dtGrid.TabIndex = 251;
            // 
            // noTxt
            // 
            // 
            // 
            // 
            this.noTxt.CustomButton.Image = null;
            this.noTxt.CustomButton.Location = new System.Drawing.Point(99, 1);
            this.noTxt.CustomButton.Name = "";
            this.noTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.noTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.noTxt.CustomButton.TabIndex = 1;
            this.noTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.noTxt.CustomButton.UseSelectable = true;
            this.noTxt.CustomButton.Visible = false;
            this.noTxt.DisplayIcon = true;
            this.noTxt.Icon = global::ARM.Properties.Resources.Layers_01_16;
            this.noTxt.Lines = new string[0];
            this.noTxt.Location = new System.Drawing.Point(335, 129);
            this.noTxt.MaxLength = 32767;
            this.noTxt.Name = "noTxt";
            this.noTxt.PasswordChar = '\0';
            this.noTxt.PromptText = "No.";
            this.noTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.noTxt.SelectedText = "";
            this.noTxt.SelectionLength = 0;
            this.noTxt.SelectionStart = 0;
            this.noTxt.ShortcutsEnabled = true;
            this.noTxt.Size = new System.Drawing.Size(121, 23);
            this.noTxt.Style = MetroFramework.MetroColorStyle.Green;
            this.noTxt.TabIndex = 42;
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
            this.button3.Location = new System.Drawing.Point(349, 419);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button3.Size = new System.Drawing.Size(99, 44);
            this.button3.TabIndex = 249;
            this.button3.Text = "Submit";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
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
            this.button2.Location = new System.Drawing.Point(13, 421);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(103, 41);
            this.button2.TabIndex = 250;
            this.button2.Text = "Cancel";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.BackgroundImage = global::ARM.Properties.Resources.Document_Add_01_24__1_;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(13, 126);
            this.button4.Name = "button4";
            this.button4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button4.Size = new System.Drawing.Size(20, 24);
            this.button4.TabIndex = 40;
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // vendorPbx
            // 
            this.vendorPbx.Location = new System.Drawing.Point(269, 38);
            this.vendorPbx.Name = "vendorPbx";
            this.vendorPbx.Size = new System.Drawing.Size(187, 85);
            this.vendorPbx.TabIndex = 35;
            this.vendorPbx.TabStop = false;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripLabel1.Image = global::ARM.Properties.Resources.Inventory_24;
            this.toolStripLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(98, 29);
            this.toolStripLabel1.Text = "Invoice";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::ARM.Properties.Resources.Cancel_16;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 29);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // InvoiceBindingSource
            // 
            this.InvoiceBindingSource.DataSource = typeof(ARM.Model.Invoice);
            // 
            // AddTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1245, 560);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddTransaction";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AddTransaction_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorPbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox vendorPbx;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource InvoiceBindingSource;
        private MetroFramework.Controls.MetroDateTime dateTxt;
        private MetroFramework.Controls.MetroTextBox noTxt;
        private MetroFramework.Controls.MetroComboBox typeCbx;
        private MetroFramework.Controls.MetroComboBox categoryCbx;
        private MetroFramework.Controls.MetroComboBox methodCbx;
        private MetroFramework.Controls.MetroTextBox termsTxt;
        private MetroFramework.Controls.MetroTextBox taxTxt;
        private MetroFramework.Controls.MetroTextBox balanceTxt;
        private MetroFramework.Controls.MetroTextBox ItemCountTxt;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox amountTxt;
        private MetroFramework.Controls.MetroTextBox vendorTxt;
        private MetroFramework.Controls.MetroTextBox customerTxt;
        private MetroFramework.Controls.MetroTextBox totalTxt;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dtGrid;
    }
}
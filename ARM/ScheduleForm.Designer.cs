﻿namespace ARM
{
    partial class ScheduleForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.searchTxt = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.dtGrid = new System.Windows.Forms.DataGridView();
			this.button1 = new System.Windows.Forms.Button();
			this.toDateTxt = new System.Windows.Forms.DateTimePicker();
			this.fromDateTxt = new System.Windows.Forms.DateTimePicker();
			this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.AutoSize = false;
			this.toolStrip1.BackColor = System.Drawing.Color.White;
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButton1,
            this.searchTxt,
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton4});
			this.toolStrip1.Location = new System.Drawing.Point(5, 5);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(10);
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(1190, 57);
			this.toolStrip1.TabIndex = 46;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.GrayText;
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(60, 34);
			this.toolStripLabel1.Text = "Shifts";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = global::ARM.Properties.Resources.Cancel_16;
			this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 34);
			this.toolStripButton1.Text = "toolStripButton1";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// searchTxt
			// 
			this.searchTxt.BackColor = System.Drawing.SystemColors.Menu;
			this.searchTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.searchTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.searchTxt.Name = "searchTxt";
			this.searchTxt.Size = new System.Drawing.Size(250, 37);
			this.searchTxt.TextChanged += new System.EventHandler(this.searchTxt_TextChanged);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton3.Image = global::ARM.Properties.Resources.Garbage_Open_24__1_;
			this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(28, 34);
			this.toolStripButton3.Text = "toolStripButton3";
			this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = global::ARM.Properties.Resources.Document_Add_01_16;
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 34);
			this.toolStripButton2.Text = "toolStripButton2";
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton5.Image = global::ARM.Properties.Resources.Search_Find_16;
			this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.Size = new System.Drawing.Size(23, 34);
			this.toolStripButton5.Text = "toolStripButton5";
			// 
			// dtGrid
			// 
			this.dtGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dtGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			this.dtGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dtGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dtGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5);
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dtGrid.DefaultCellStyle = dataGridViewCellStyle5;
			this.dtGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dtGrid.GridColor = System.Drawing.SystemColors.ButtonFace;
			this.dtGrid.Location = new System.Drawing.Point(5, 62);
			this.dtGrid.Name = "dtGrid";
			this.dtGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ActiveCaption;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dtGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.dtGrid.RowHeadersWidth = 20;
			this.dtGrid.Size = new System.Drawing.Size(1190, 487);
			this.dtGrid.TabIndex = 48;
			this.dtGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrid_CellClick);
			this.dtGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrid_CellEndEdit);
			// 
			// button1
			// 
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Image = global::ARM.Properties.Resources.Submit_02_161;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.Location = new System.Drawing.Point(1030, 17);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(38, 23);
			this.button1.TabIndex = 54;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// toDateTxt
			// 
			this.toDateTxt.CalendarFont = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toDateTxt.Location = new System.Drawing.Point(788, 19);
			this.toDateTxt.Name = "toDateTxt";
			this.toDateTxt.Size = new System.Drawing.Size(236, 20);
			this.toDateTxt.TabIndex = 53;
			// 
			// fromDateTxt
			// 
			this.fromDateTxt.CalendarFont = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fromDateTxt.Location = new System.Drawing.Point(528, 20);
			this.fromDateTxt.Name = "fromDateTxt";
			this.fromDateTxt.Size = new System.Drawing.Size(241, 20);
			this.fromDateTxt.TabIndex = 52;
			// 
			// toolStripButton6
			// 
			this.toolStripButton6.Image = global::ARM.Properties.Resources.Task_01_24__2_;
			this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton6.Name = "toolStripButton6";
			this.toolStripButton6.Size = new System.Drawing.Size(60, 34);
			this.toolStripButton6.Text = "Check";
			this.toolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.Image = global::ARM.Properties.Resources.Report_Delete_24;
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(73, 34);
			this.toolStripButton4.Text = "Uncheck";
			this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click_1);
			// 
			// ScheduleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.ClientSize = new System.Drawing.Size(1200, 554);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.toDateTxt);
			this.Controls.Add(this.fromDateTxt);
			this.Controls.Add(this.dtGrid);
			this.Controls.Add(this.toolStrip1);
			this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ScheduleForm";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ScheduleForm";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtGrid)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripTextBox searchTxt;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.DataGridView dtGrid;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker toDateTxt;
        private System.Windows.Forms.DateTimePicker fromDateTxt;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
		private System.Windows.Forms.ToolStripButton toolStripButton6;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
	}
}
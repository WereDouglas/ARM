namespace ARM
{
    partial class AddCoverage
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCoverage));
			this.htmlToolTip1 = new MetroFramework.Drawing.Html.HtmlToolTip();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label8 = new System.Windows.Forms.Label();
			this.percTxt = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.amountTxt = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.productLbl = new System.Windows.Forms.Label();
			this.CoverageCbx = new MetroFramework.Controls.MetroComboBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// htmlToolTip1
			// 
			this.htmlToolTip1.OwnerDraw = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.30769F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 218F));
			this.tableLayoutPanel1.Controls.Add(this.label8, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.percTxt, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.label10, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.amountTxt, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.productLbl, 0, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(21, 100);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.13726F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.86274F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(688, 87);
			this.tableLayoutPanel1.TabIndex = 256;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(355, 2);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(73, 13);
			this.label8.TabIndex = 209;
			this.label8.Text = "Percentage % ";
			// 
			// percTxt
			// 
			this.percTxt.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.percTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.percTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.percTxt.Location = new System.Drawing.Point(355, 43);
			this.percTxt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.percTxt.Name = "percTxt";
			this.percTxt.Size = new System.Drawing.Size(108, 24);
			this.percTxt.TabIndex = 2;
			this.percTxt.Text = "0";
			this.percTxt.TextChanged += new System.EventHandler(this.qtyTxt_TextChanged);
			this.percTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.qtyTxt_KeyPress);
			this.percTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.qtyTxt_KeyUp);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(471, 2);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(85, 13);
			this.label10.TabIndex = 266;
			this.label10.Text = "Amount Covered";
			// 
			// amountTxt
			// 
			this.amountTxt.BackColor = System.Drawing.SystemColors.ControlDark;
			this.amountTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.amountTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.amountTxt.Location = new System.Drawing.Point(471, 43);
			this.amountTxt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.amountTxt.Name = "amountTxt";
			this.amountTxt.Size = new System.Drawing.Size(137, 24);
			this.amountTxt.TabIndex = 3;
			this.amountTxt.Text = "0";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 13);
			this.label3.TabIndex = 267;
			this.label3.Text = "Product";
			// 
			// productLbl
			// 
			this.productLbl.AutoSize = true;
			this.productLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.productLbl.Location = new System.Drawing.Point(5, 38);
			this.productLbl.Name = "productLbl";
			this.productLbl.Size = new System.Drawing.Size(24, 25);
			this.productLbl.TabIndex = 268;
			this.productLbl.Text = "#";
			// 
			// CoverageCbx
			// 
			this.CoverageCbx.FormattingEnabled = true;
			this.CoverageCbx.ItemHeight = 23;
			this.CoverageCbx.Location = new System.Drawing.Point(21, 64);
			this.CoverageCbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.CoverageCbx.Name = "CoverageCbx";
			this.CoverageCbx.PromptText = "Coverage";
			this.CoverageCbx.Size = new System.Drawing.Size(378, 29);
			this.CoverageCbx.TabIndex = 0;
			this.CoverageCbx.UseSelectable = true;
			this.CoverageCbx.SelectedIndexChanged += new System.EventHandler(this.productTxt_SelectedIndexChanged);
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
			this.button3.Location = new System.Drawing.Point(610, 215);
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
			this.button2.Location = new System.Drawing.Point(21, 202);
			this.button2.Name = "button2";
			this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.button2.Size = new System.Drawing.Size(107, 49);
			this.button2.TabIndex = 1;
			this.button2.Text = "Cancel";
			this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// AddCoverage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(720, 275);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.CoverageCbx);
			this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AddCoverage";
			this.Style = MetroFramework.MetroColorStyle.White;
			this.Text = "Coverage";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Drawing.Html.HtmlToolTip htmlToolTip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private MetroFramework.Controls.MetroComboBox CoverageCbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox percTxt;
        private System.Windows.Forms.TextBox amountTxt;
        private System.Windows.Forms.Label productLbl;
    }
}
namespace App.PVCFC_RFID.Design
{
    partial class frmTrigger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrigger));
            this.tblMains = new System.Windows.Forms.TableLayoutPanel();
            this.tblFilter = new System.Windows.Forms.TableLayoutPanel();
            this.numTimeoutMan = new System.Windows.Forms.NumericUpDown();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnTrigger = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tblControlBtn = new System.Windows.Forms.TableLayoutPanel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.lblTotalRows = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tblMains.SuspendLayout();
            this.tblFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeoutMan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tblControlBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tblMains
            // 
            this.tblMains.ColumnCount = 2;
            this.tblMains.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblMains.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMains.Controls.Add(this.tblFilter, 0, 1);
            this.tblMains.Controls.Add(this.lblTitle, 0, 0);
            this.tblMains.Controls.Add(this.dataGridView1, 1, 2);
            this.tblMains.Controls.Add(this.tblControlBtn, 0, 3);
            this.tblMains.Controls.Add(this.pictureBox1, 0, 2);
            this.tblMains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMains.Location = new System.Drawing.Point(0, 0);
            this.tblMains.Margin = new System.Windows.Forms.Padding(4);
            this.tblMains.Name = "tblMains";
            this.tblMains.RowCount = 4;
            this.tblMains.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMains.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMains.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMains.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMains.Size = new System.Drawing.Size(1008, 561);
            this.tblMains.TabIndex = 0;
            // 
            // tblFilter
            // 
            this.tblFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblFilter.AutoSize = true;
            this.tblFilter.ColumnCount = 11;
            this.tblMains.SetColumnSpan(this.tblFilter, 2);
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFilter.Controls.Add(this.numTimeoutMan, 1, 0);
            this.tblFilter.Controls.Add(this.lblTimeout, 1, 0);
            this.tblFilter.Controls.Add(this.btnClear, 10, 0);
            this.tblFilter.Controls.Add(this.btnRead, 6, 0);
            this.tblFilter.Controls.Add(this.btnTrigger, 8, 0);
            this.tblFilter.Location = new System.Drawing.Point(4, 35);
            this.tblFilter.Margin = new System.Windows.Forms.Padding(4);
            this.tblFilter.Name = "tblFilter";
            this.tblFilter.RowCount = 1;
            this.tblFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFilter.Size = new System.Drawing.Size(1000, 46);
            this.tblFilter.TabIndex = 7;
            // 
            // numTimeoutMan
            // 
            this.numTimeoutMan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numTimeoutMan.Font = new System.Drawing.Font("Arial", 20.25F);
            this.numTimeoutMan.Location = new System.Drawing.Point(552, 3);
            this.numTimeoutMan.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numTimeoutMan.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTimeoutMan.Name = "numTimeoutMan";
            this.numTimeoutMan.Size = new System.Drawing.Size(106, 39);
            this.numTimeoutMan.TabIndex = 11;
            this.numTimeoutMan.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lblTimeout
            // 
            this.lblTimeout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTimeout.AutoSize = true;
            this.lblTimeout.Location = new System.Drawing.Point(486, 14);
            this.lblTimeout.Margin = new System.Windows.Forms.Padding(3);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(60, 17);
            this.lblTimeout.TabIndex = 10;
            this.lblTimeout.Text = "Timeout";
            // 
            // btnClear
            // 
            this.btnClear.AutoSize = true;
            this.btnClear.Location = new System.Drawing.Point(917, 3);
            this.btnClear.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 40);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnRead
            // 
            this.btnRead.AutoSize = true;
            this.btnRead.Location = new System.Drawing.Point(681, 3);
            this.btnRead.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnRead.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(95, 40);
            this.btnRead.TabIndex = 4;
            this.btnRead.Text = "Check data";
            this.btnRead.UseVisualStyleBackColor = true;
            // 
            // btnTrigger
            // 
            this.btnTrigger.AutoSize = true;
            this.btnTrigger.Location = new System.Drawing.Point(799, 3);
            this.btnTrigger.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnTrigger.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnTrigger.Name = "btnTrigger";
            this.btnTrigger.Size = new System.Drawing.Size(92, 40);
            this.btnTrigger.TabIndex = 12;
            this.btnTrigger.Text = "Trigger";
            this.btnTrigger.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.tblMains.SetColumnSpan(this.lblTitle, 2);
            this.lblTitle.Font = new System.Drawing.Font("Arial", 12.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(483, 6);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(42, 19);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Title";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(330, 89);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(674, 410);
            this.dataGridView1.TabIndex = 0;
            // 
            // tblControlBtn
            // 
            this.tblControlBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblControlBtn.ColumnCount = 5;
            this.tblMains.SetColumnSpan(this.tblControlBtn, 2);
            this.tblControlBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblControlBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblControlBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblControlBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblControlBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblControlBtn.Controls.Add(this.btnNext, 3, 0);
            this.tblControlBtn.Controls.Add(this.btnBack, 2, 0);
            this.tblControlBtn.Controls.Add(this.btnFirst, 1, 0);
            this.tblControlBtn.Controls.Add(this.lblTotalRows, 0, 0);
            this.tblControlBtn.Controls.Add(this.btnLast, 4, 0);
            this.tblControlBtn.Location = new System.Drawing.Point(4, 507);
            this.tblControlBtn.Margin = new System.Windows.Forms.Padding(4);
            this.tblControlBtn.Name = "tblControlBtn";
            this.tblControlBtn.RowCount = 1;
            this.tblControlBtn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblControlBtn.Size = new System.Drawing.Size(1000, 50);
            this.tblControlBtn.TabIndex = 1;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(831, 3);
            this.btnNext.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 40);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(745, 3);
            this.btnBack.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 40);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "<";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(659, 3);
            this.btnFirst.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(80, 40);
            this.btnFirst.TabIndex = 2;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = true;
            // 
            // lblTotalRows
            // 
            this.lblTotalRows.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalRows.AutoSize = true;
            this.lblTotalRows.Font = new System.Drawing.Font("Arial", 12.25F);
            this.lblTotalRows.Location = new System.Drawing.Point(3, 15);
            this.lblTotalRows.Name = "lblTotalRows";
            this.lblTotalRows.Size = new System.Drawing.Size(86, 19);
            this.lblTotalRows.TabIndex = 4;
            this.lblTotalRows.Text = "Tổng số: 0";
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(917, 3);
            this.btnLast.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(80, 40);
            this.btnLast.TabIndex = 3;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Location = new System.Drawing.Point(3, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 412);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // frmTrigger
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.tblMains);
            this.Font = new System.Drawing.Font("Arial", 11.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTrigger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmTrigger";
            this.tblMains.ResumeLayout(false);
            this.tblMains.PerformLayout();
            this.tblFilter.ResumeLayout(false);
            this.tblFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeoutMan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tblControlBtn.ResumeLayout(false);
            this.tblControlBtn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMains;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tblControlBtn;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Label lblTotalRows;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tblFilter;
        private System.Windows.Forms.NumericUpDown numTimeoutMan;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnTrigger;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
namespace App.DevCodeActivatorRFID.Design
{
    partial class frmProductDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductDetails));
            this.tblMains = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tblControlBtn = new System.Windows.Forms.TableLayoutPanel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.lblTotalRows = new System.Windows.Forms.Label();
            this.tblMains.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tblControlBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMains
            // 
            this.tblMains.ColumnCount = 1;
            this.tblMains.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMains.Controls.Add(this.lblTitle, 0, 0);
            this.tblMains.Controls.Add(this.dataGridView1, 0, 1);
            this.tblMains.Controls.Add(this.tblControlBtn, 0, 2);
            this.tblMains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMains.Location = new System.Drawing.Point(0, 0);
            this.tblMains.Margin = new System.Windows.Forms.Padding(4);
            this.tblMains.Name = "tblMains";
            this.tblMains.RowCount = 3;
            this.tblMains.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMains.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMains.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMains.Size = new System.Drawing.Size(1008, 561);
            this.tblMains.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
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
            this.dataGridView1.Location = new System.Drawing.Point(4, 35);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1000, 464);
            this.dataGridView1.TabIndex = 0;
            // 
            // tblControlBtn
            // 
            this.tblControlBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblControlBtn.ColumnCount = 5;
            this.tblControlBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblControlBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblControlBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblControlBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblControlBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblControlBtn.Controls.Add(this.btnNext, 3, 0);
            this.tblControlBtn.Controls.Add(this.btnBack, 2, 0);
            this.tblControlBtn.Controls.Add(this.btnFirst, 1, 0);
            this.tblControlBtn.Controls.Add(this.btnLast, 4, 0);
            this.tblControlBtn.Controls.Add(this.lblTotalRows, 0, 0);
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
            // frmProductDetails
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.tblMains);
            this.Font = new System.Drawing.Font("Arial", 11.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProductDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmProductDetails";
            this.tblMains.ResumeLayout(false);
            this.tblMains.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tblControlBtn.ResumeLayout(false);
            this.tblControlBtn.PerformLayout();
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
    }
}
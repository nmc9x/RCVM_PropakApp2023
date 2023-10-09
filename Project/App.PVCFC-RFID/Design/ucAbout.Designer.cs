namespace App.PVCFC_RFID.Design
{
    partial class ucAbout
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.grbGeneralInfo = new System.Windows.Forms.GroupBox();
            this.grbReleaseNote = new System.Windows.Forms.GroupBox();
            this.rchReleaseNote = new System.Windows.Forms.RichTextBox();
            this.lblGeneralInfo = new System.Windows.Forms.Label();
            this.gServerActivation = new System.Windows.Forms.GroupBox();
            this.lblServerActivation = new System.Windows.Forms.Label();
            this.tblMain.SuspendLayout();
            this.grbGeneralInfo.SuspendLayout();
            this.grbReleaseNote.SuspendLayout();
            this.gServerActivation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.gServerActivation, 0, 2);
            this.tblMain.Controls.Add(this.grbReleaseNote, 0, 4);
            this.tblMain.Controls.Add(this.grbGeneralInfo, 0, 0);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 5;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Size = new System.Drawing.Size(446, 397);
            this.tblMain.TabIndex = 0;
            // 
            // grbGeneralInfo
            // 
            this.grbGeneralInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbGeneralInfo.AutoSize = true;
            this.grbGeneralInfo.Controls.Add(this.lblGeneralInfo);
            this.grbGeneralInfo.Location = new System.Drawing.Point(3, 3);
            this.grbGeneralInfo.Name = "grbGeneralInfo";
            this.grbGeneralInfo.Padding = new System.Windows.Forms.Padding(8);
            this.grbGeneralInfo.Size = new System.Drawing.Size(440, 42);
            this.grbGeneralInfo.TabIndex = 7;
            this.grbGeneralInfo.TabStop = false;
            this.grbGeneralInfo.Text = "General info";
            // 
            // grbReleaseNote
            // 
            this.grbReleaseNote.Controls.Add(this.rchReleaseNote);
            this.grbReleaseNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbReleaseNote.Location = new System.Drawing.Point(3, 139);
            this.grbReleaseNote.Name = "grbReleaseNote";
            this.grbReleaseNote.Padding = new System.Windows.Forms.Padding(8);
            this.grbReleaseNote.Size = new System.Drawing.Size(440, 255);
            this.grbReleaseNote.TabIndex = 8;
            this.grbReleaseNote.TabStop = false;
            this.grbReleaseNote.Text = "Release note";
            // 
            // rchReleaseNote
            // 
            this.rchReleaseNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rchReleaseNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchReleaseNote.Location = new System.Drawing.Point(8, 21);
            this.rchReleaseNote.Name = "rchReleaseNote";
            this.rchReleaseNote.ReadOnly = true;
            this.rchReleaseNote.Size = new System.Drawing.Size(424, 226);
            this.rchReleaseNote.TabIndex = 0;
            this.rchReleaseNote.Text = "";
            // 
            // lblGeneralInfo
            // 
            this.lblGeneralInfo.AutoSize = true;
            this.lblGeneralInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGeneralInfo.Location = new System.Drawing.Point(8, 21);
            this.lblGeneralInfo.Name = "lblGeneralInfo";
            this.lblGeneralInfo.Size = new System.Drawing.Size(25, 13);
            this.lblGeneralInfo.TabIndex = 0;
            this.lblGeneralInfo.Text = "Info";
            // 
            // gServerActivation
            // 
            this.gServerActivation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gServerActivation.AutoSize = true;
            this.gServerActivation.Controls.Add(this.lblServerActivation);
            this.gServerActivation.Location = new System.Drawing.Point(3, 71);
            this.gServerActivation.Name = "gServerActivation";
            this.gServerActivation.Padding = new System.Windows.Forms.Padding(8);
            this.gServerActivation.Size = new System.Drawing.Size(440, 42);
            this.gServerActivation.TabIndex = 9;
            this.gServerActivation.TabStop = false;
            this.gServerActivation.Text = "General info";
            // 
            // lblServerActivation
            // 
            this.lblServerActivation.AutoSize = true;
            this.lblServerActivation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblServerActivation.Location = new System.Drawing.Point(8, 21);
            this.lblServerActivation.Name = "lblServerActivation";
            this.lblServerActivation.Size = new System.Drawing.Size(25, 13);
            this.lblServerActivation.TabIndex = 0;
            this.lblServerActivation.Text = "Info";
            // 
            // ucAbout
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tblMain);
            this.Name = "ucAbout";
            this.Size = new System.Drawing.Size(446, 397);
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            this.grbGeneralInfo.ResumeLayout(false);
            this.grbGeneralInfo.PerformLayout();
            this.grbReleaseNote.ResumeLayout(false);
            this.gServerActivation.ResumeLayout(false);
            this.gServerActivation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.GroupBox grbGeneralInfo;
        private System.Windows.Forms.GroupBox grbReleaseNote;
        private System.Windows.Forms.RichTextBox rchReleaseNote;
        private System.Windows.Forms.Label lblGeneralInfo;
        private System.Windows.Forms.GroupBox gServerActivation;
        private System.Windows.Forms.Label lblServerActivation;
    }
}

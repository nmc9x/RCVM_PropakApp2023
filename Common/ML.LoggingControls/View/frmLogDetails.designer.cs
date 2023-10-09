namespace ML.LoggingControls.View
{
    partial class frmLogDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogDetails));
            this.lblTitle = new System.Windows.Forms.Label();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblTypeValue = new System.Windows.Forms.Label();
            this.lblKeyword = new System.Windows.Forms.Label();
            this.lblCommand = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblKeywordValue = new System.Windows.Forms.Label();
            this.lblCommandValue = new System.Windows.Forms.Label();
            this.lblMessageValue = new System.Windows.Forms.Label();
            this.lblUserValue = new System.Windows.Forms.Label();
            this.picType = new System.Windows.Forms.PictureBox();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblDateTimeValue = new System.Windows.Forms.Label();
            this.btnOK = new ML.Controls.MLButton();
            this.tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picType)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(182)))), ((int)(((byte)(172)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(1, 1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblTitle.Size = new System.Drawing.Size(531, 48);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "Advanced form";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tblMain
            // 
            this.tblMain.AutoSize = true;
            this.tblMain.BackColor = System.Drawing.SystemColors.Control;
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.lblTypeValue, 1, 0);
            this.tblMain.Controls.Add(this.lblKeyword, 0, 4);
            this.tblMain.Controls.Add(this.lblCommand, 0, 6);
            this.tblMain.Controls.Add(this.lblMessage, 0, 8);
            this.tblMain.Controls.Add(this.lblUser, 0, 10);
            this.tblMain.Controls.Add(this.lblKeywordValue, 1, 4);
            this.tblMain.Controls.Add(this.lblCommandValue, 1, 6);
            this.tblMain.Controls.Add(this.lblMessageValue, 1, 8);
            this.tblMain.Controls.Add(this.lblUserValue, 1, 10);
            this.tblMain.Controls.Add(this.picType, 0, 0);
            this.tblMain.Controls.Add(this.lblDateTime, 0, 2);
            this.tblMain.Controls.Add(this.lblDateTimeValue, 1, 2);
            this.tblMain.Controls.Add(this.btnOK, 0, 12);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Font = new System.Drawing.Font("Arial", 12.25F);
            this.tblMain.Location = new System.Drawing.Point(1, 49);
            this.tblMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 14;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMain.Size = new System.Drawing.Size(531, 286);
            this.tblMain.TabIndex = 15;
            // 
            // lblTypeValue
            // 
            this.lblTypeValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTypeValue.AutoSize = true;
            this.lblTypeValue.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeValue.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTypeValue.Location = new System.Drawing.Point(92, 6);
            this.lblTypeValue.Name = "lblTypeValue";
            this.lblTypeValue.Size = new System.Drawing.Size(106, 19);
            this.lblTypeValue.TabIndex = 12;
            this.lblTypeValue.Text = "lblTypeValue";
            this.lblTypeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKeyword
            // 
            this.lblKeyword.AutoSize = true;
            this.lblKeyword.Location = new System.Drawing.Point(3, 71);
            this.lblKeyword.Name = "lblKeyword";
            this.lblKeyword.Size = new System.Drawing.Size(78, 19);
            this.lblKeyword.TabIndex = 1;
            this.lblKeyword.Text = "Key word";
            // 
            // lblCommand
            // 
            this.lblCommand.AutoSize = true;
            this.lblCommand.Location = new System.Drawing.Point(3, 100);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(83, 19);
            this.lblCommand.TabIndex = 2;
            this.lblCommand.Text = "Command";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(3, 129);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(74, 19);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Message";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(3, 158);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(43, 19);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "User";
            // 
            // lblKeywordValue
            // 
            this.lblKeywordValue.AutoSize = true;
            this.lblKeywordValue.Location = new System.Drawing.Point(92, 71);
            this.lblKeywordValue.Name = "lblKeywordValue";
            this.lblKeywordValue.Size = new System.Drawing.Size(83, 19);
            this.lblKeywordValue.TabIndex = 7;
            this.lblKeywordValue.Text = "[Keyword]";
            // 
            // lblCommandValue
            // 
            this.lblCommandValue.AutoSize = true;
            this.lblCommandValue.Location = new System.Drawing.Point(92, 100);
            this.lblCommandValue.Name = "lblCommandValue";
            this.lblCommandValue.Size = new System.Drawing.Size(93, 19);
            this.lblCommandValue.TabIndex = 8;
            this.lblCommandValue.Text = "[Command]";
            // 
            // lblMessageValue
            // 
            this.lblMessageValue.AutoSize = true;
            this.lblMessageValue.Location = new System.Drawing.Point(92, 129);
            this.lblMessageValue.Name = "lblMessageValue";
            this.lblMessageValue.Size = new System.Drawing.Size(97, 19);
            this.lblMessageValue.TabIndex = 9;
            this.lblMessageValue.Text = "[Messages] ";
            // 
            // lblUserValue
            // 
            this.lblUserValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUserValue.AutoSize = true;
            this.lblUserValue.Location = new System.Drawing.Point(92, 158);
            this.lblUserValue.Name = "lblUserValue";
            this.lblUserValue.Size = new System.Drawing.Size(20, 19);
            this.lblUserValue.TabIndex = 10;
            this.lblUserValue.Text = "- ";
            // 
            // picType
            // 
            this.picType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picType.Image = ((System.Drawing.Image)(resources.GetObject("picType.Image")));
            this.picType.Location = new System.Drawing.Point(52, 3);
            this.picType.Name = "picType";
            this.picType.Size = new System.Drawing.Size(34, 26);
            this.picType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picType.TabIndex = 8;
            this.picType.TabStop = false;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Location = new System.Drawing.Point(3, 42);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(73, 19);
            this.lblDateTime.TabIndex = 13;
            this.lblDateTime.Text = "Datetime";
            // 
            // lblDateTimeValue
            // 
            this.lblDateTimeValue.AutoSize = true;
            this.lblDateTimeValue.Location = new System.Drawing.Point(92, 42);
            this.lblDateTimeValue.Name = "lblDateTimeValue";
            this.lblDateTimeValue.Size = new System.Drawing.Size(83, 19);
            this.lblDateTimeValue.TabIndex = 14;
            this.lblDateTimeValue.Text = "[Datetime]";
            // 
            // btnOK
            // 
            this.btnOK.AllowLoopEvents = false;
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.BackColor = System.Drawing.Color.LightGray;
            this.btnOK.BackColorInNoneStyle = System.Drawing.SystemColors.ButtonFace;
            this.btnOK.BorderColorInNoneStyle = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.btnOK.BorderSizeInNoneStyle = 0;
            this.btnOK.ButtonStyle = ML.Controls.ButtonStylesEnum.Default;
            this.tblMain.SetColumnSpan(this.btnOK, 2);
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Arial", 12.25F);
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.ForeColorInInNoneStyle = System.Drawing.Color.White;
            this.btnOK.IsStandardButton = false;
            this.btnOK.Location = new System.Drawing.Point(228, 225);
            this.btnOK.MinimumSize = new System.Drawing.Size(75, 48);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 48);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // frmLogDetails
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(533, 336);
            this.Controls.Add(this.tblMain);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Arial", 10.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmLogDetails";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmLogDetails";
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.Label lblTypeValue;
        private System.Windows.Forms.Label lblKeyword;
        private System.Windows.Forms.Label lblCommand;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblKeywordValue;
        private System.Windows.Forms.Label lblCommandValue;
        private System.Windows.Forms.Label lblMessageValue;
        private System.Windows.Forms.Label lblUserValue;
        private System.Windows.Forms.PictureBox picType;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblDateTimeValue;
        private ML.Controls.MLButton btnOK;


    }
}
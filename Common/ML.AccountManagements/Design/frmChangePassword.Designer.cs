namespace ML.AccountManagements.Design
{
    partial class frmChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePassword));
            this.tblMainInfo = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mlBtnOK = new ML.Controls.MLButton();
            this.mlBtnCancel = new ML.Controls.MLButton();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblCurPassword = new System.Windows.Forms.Label();
            this.txtUserNameUserName = new System.Windows.Forms.TextBox();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblRetypePassword = new System.Windows.Forms.Label();
            this.txtRetypePassword = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tblMainInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tblMainInfo
            // 
            this.tblMainInfo.ColumnCount = 4;
            this.tblMainInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblMainInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblMainInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainInfo.Controls.Add(this.tableLayoutPanel1, 2, 11);
            this.tblMainInfo.Controls.Add(this.lblUserName, 1, 3);
            this.tblMainInfo.Controls.Add(this.lblCurPassword, 1, 5);
            this.tblMainInfo.Controls.Add(this.txtUserNameUserName, 2, 3);
            this.tblMainInfo.Controls.Add(this.txtCurrentPassword, 2, 5);
            this.tblMainInfo.Controls.Add(this.lblNewPassword, 1, 7);
            this.tblMainInfo.Controls.Add(this.txtNewPassword, 2, 7);
            this.tblMainInfo.Controls.Add(this.lblRetypePassword, 1, 9);
            this.tblMainInfo.Controls.Add(this.txtRetypePassword, 2, 9);
            this.tblMainInfo.Controls.Add(this.lblTitle, 1, 1);
            this.tblMainInfo.Controls.Add(this.pictureBox1, 1, 10);
            this.tblMainInfo.Controls.Add(this.lblMessage, 2, 10);
            this.tblMainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainInfo.Location = new System.Drawing.Point(0, 0);
            this.tblMainInfo.Margin = new System.Windows.Forms.Padding(4);
            this.tblMainInfo.Name = "tblMainInfo";
            this.tblMainInfo.RowCount = 13;
            this.tblMainInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMainInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMainInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMainInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMainInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tblMainInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainInfo.Size = new System.Drawing.Size(549, 379);
            this.tblMainInfo.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Controls.Add(this.mlBtnOK, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.mlBtnCancel, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(181, 289);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(322, 51);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // mlBtnOK
            // 
            this.mlBtnOK.AllowLoopEvents = false;
            this.mlBtnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mlBtnOK.BackColor = System.Drawing.SystemColors.ControlText;
            this.mlBtnOK.BackColorInNoneStyle = System.Drawing.SystemColors.ButtonFace;
            this.mlBtnOK.BorderColorInNoneStyle = System.Drawing.Color.Gray;
            this.mlBtnOK.BorderSizeInNoneStyle = 0;
            this.mlBtnOK.ButtonStyle = ML.Controls.ButtonStylesEnum.None;
            this.mlBtnOK.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.mlBtnOK.FlatAppearance.BorderSize = 0;
            this.mlBtnOK.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.mlBtnOK.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.mlBtnOK.Font = new System.Drawing.Font("Arial", 10.25F);
            this.mlBtnOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mlBtnOK.ForeColorInInNoneStyle = System.Drawing.Color.White;
            this.mlBtnOK.IsStandardButton = true;
            this.mlBtnOK.Location = new System.Drawing.Point(60, 4);
            this.mlBtnOK.Margin = new System.Windows.Forms.Padding(4);
            this.mlBtnOK.MinimumSize = new System.Drawing.Size(0, 44);
            this.mlBtnOK.Name = "mlBtnOK";
            this.mlBtnOK.Size = new System.Drawing.Size(112, 44);
            this.mlBtnOK.TabIndex = 0;
            this.mlBtnOK.Text = "Login";
            this.mlBtnOK.UseVisualStyleBackColor = true;
            // 
            // mlBtnCancel
            // 
            this.mlBtnCancel.AllowLoopEvents = false;
            this.mlBtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mlBtnCancel.BackColor = System.Drawing.SystemColors.ControlText;
            this.mlBtnCancel.BackColorInNoneStyle = System.Drawing.SystemColors.ButtonFace;
            this.mlBtnCancel.BorderColorInNoneStyle = System.Drawing.Color.Gray;
            this.mlBtnCancel.BorderSizeInNoneStyle = 0;
            this.mlBtnCancel.ButtonStyle = ML.Controls.ButtonStylesEnum.None;
            this.mlBtnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.mlBtnCancel.FlatAppearance.BorderSize = 0;
            this.mlBtnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.mlBtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.mlBtnCancel.Font = new System.Drawing.Font("Arial", 10.25F);
            this.mlBtnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mlBtnCancel.ForeColorInInNoneStyle = System.Drawing.Color.White;
            this.mlBtnCancel.IsStandardButton = true;
            this.mlBtnCancel.Location = new System.Drawing.Point(210, 4);
            this.mlBtnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.mlBtnCancel.MinimumSize = new System.Drawing.Size(0, 44);
            this.mlBtnCancel.Name = "mlBtnCancel";
            this.mlBtnCancel.Size = new System.Drawing.Size(112, 44);
            this.mlBtnCancel.TabIndex = 1;
            this.mlBtnCancel.Text = "Cancel";
            this.mlBtnCancel.UseVisualStyleBackColor = true;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(45, 85);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(80, 18);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "UserName";
            // 
            // lblCurPassword
            // 
            this.lblCurPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCurPassword.AutoSize = true;
            this.lblCurPassword.Location = new System.Drawing.Point(45, 127);
            this.lblCurPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurPassword.Name = "lblCurPassword";
            this.lblCurPassword.Size = new System.Drawing.Size(126, 18);
            this.lblCurPassword.TabIndex = 1;
            this.lblCurPassword.Text = "Current password";
            // 
            // txtUserNameUserName
            // 
            this.txtUserNameUserName.Location = new System.Drawing.Point(181, 82);
            this.txtUserNameUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserNameUserName.Name = "txtUserNameUserName";
            this.txtUserNameUserName.Size = new System.Drawing.Size(322, 24);
            this.txtUserNameUserName.TabIndex = 3;
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Location = new System.Drawing.Point(181, 124);
            this.txtCurrentPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '*';
            this.txtCurrentPassword.Size = new System.Drawing.Size(322, 24);
            this.txtCurrentPassword.TabIndex = 4;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(45, 169);
            this.lblNewPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(107, 18);
            this.lblNewPassword.TabIndex = 5;
            this.lblNewPassword.Text = "New password";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(181, 166);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(322, 24);
            this.txtNewPassword.TabIndex = 7;
            // 
            // lblRetypePassword
            // 
            this.lblRetypePassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRetypePassword.AutoSize = true;
            this.lblRetypePassword.Location = new System.Drawing.Point(45, 211);
            this.lblRetypePassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRetypePassword.Name = "lblRetypePassword";
            this.lblRetypePassword.Size = new System.Drawing.Size(128, 18);
            this.lblRetypePassword.TabIndex = 6;
            this.lblRetypePassword.Text = "Re-type password";
            // 
            // txtRetypePassword
            // 
            this.txtRetypePassword.Location = new System.Drawing.Point(181, 208);
            this.txtRetypePassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtRetypePassword.Name = "txtRetypePassword";
            this.txtRetypePassword.PasswordChar = '*';
            this.txtRetypePassword.Size = new System.Drawing.Size(322, 24);
            this.txtRetypePassword.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.tblMainInfo.SetColumnSpan(this.lblTitle, 2);
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTitle.Location = new System.Drawing.Point(192, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(163, 24);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Change password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.Image = global::ML.AccountManagements.Properties.Resources.Spinner;
            this.pictureBox1.Location = new System.Drawing.Point(126, 236);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblMessage.Location = new System.Drawing.Point(180, 236);
            this.lblMessage.MinimumSize = new System.Drawing.Size(0, 48);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(95, 48);
            this.lblMessage.TabIndex = 11;
            this.lblMessage.Text = "Please wait...";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmChangePassword
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(549, 379);
            this.Controls.Add(this.tblMainInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmChangePassword";
            this.Text = "frmChangePassword";
            this.tblMainInfo.ResumeLayout(false);
            this.tblMainInfo.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMainInfo;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblCurPassword;
        private System.Windows.Forms.TextBox txtUserNameUserName;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblRetypePassword;
        private System.Windows.Forms.TextBox txtRetypePassword;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.MLButton mlBtnOK;
        private Controls.MLButton mlBtnCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMessage;

    }
}
namespace ML.AccountManagements.Design
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.tblMainOnline = new System.Windows.Forms.TableLayoutPanel();
            this.lblUserNameOnline = new System.Windows.Forms.Label();
            this.lblPasswordOnline = new System.Windows.Forms.Label();
            this.chkRememberAccountOnline = new System.Windows.Forms.CheckBox();
            this.txtUserNameOnline = new System.Windows.Forms.TextBox();
            this.txtPasswordOnline = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblLinkServer = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabControlMainPageLoginOnline = new System.Windows.Forms.TabPage();
            this.tabControlMainPageLoginOffline = new System.Windows.Forms.TabPage();
            this.tblMainOffline = new System.Windows.Forms.TableLayoutPanel();
            this.lblUserNameOffline = new System.Windows.Forms.Label();
            this.lblPasswordOffline = new System.Windows.Forms.Label();
            this.txtUserNameOffline = new System.Windows.Forms.TextBox();
            this.txtPasswordOffline = new System.Windows.Forms.TextBox();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.tblControls = new System.Windows.Forms.TableLayoutPanel();
            this.mlBtnLogin = new ML.Controls.MLButton();
            this.mlBtnCancel = new ML.Controls.MLButton();
            this.tblMainOnline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabControlMainPageLoginOnline.SuspendLayout();
            this.tabControlMainPageLoginOffline.SuspendLayout();
            this.tblMainOffline.SuspendLayout();
            this.tblMain.SuspendLayout();
            this.tblControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMainOnline
            // 
            this.tblMainOnline.ColumnCount = 4;
            this.tblMainOnline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainOnline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblMainOnline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblMainOnline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainOnline.Controls.Add(this.lblUserNameOnline, 1, 3);
            this.tblMainOnline.Controls.Add(this.lblPasswordOnline, 1, 5);
            this.tblMainOnline.Controls.Add(this.chkRememberAccountOnline, 2, 7);
            this.tblMainOnline.Controls.Add(this.txtUserNameOnline, 2, 3);
            this.tblMainOnline.Controls.Add(this.txtPasswordOnline, 2, 5);
            this.tblMainOnline.Controls.Add(this.pictureBox1, 1, 8);
            this.tblMainOnline.Controls.Add(this.lblMsg, 2, 8);
            this.tblMainOnline.Controls.Add(this.lblLinkServer, 1, 9);
            this.tblMainOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainOnline.Location = new System.Drawing.Point(3, 3);
            this.tblMainOnline.Name = "tblMainOnline";
            this.tblMainOnline.RowCount = 10;
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainOnline.Size = new System.Drawing.Size(408, 288);
            this.tblMainOnline.TabIndex = 0;
            // 
            // lblUserNameOnline
            // 
            this.lblUserNameOnline.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUserNameOnline.AutoSize = true;
            this.lblUserNameOnline.Location = new System.Drawing.Point(36, 87);
            this.lblUserNameOnline.Name = "lblUserNameOnline";
            this.lblUserNameOnline.Size = new System.Drawing.Size(72, 16);
            this.lblUserNameOnline.TabIndex = 0;
            this.lblUserNameOnline.Text = "UserName";
            // 
            // lblPasswordOnline
            // 
            this.lblPasswordOnline.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPasswordOnline.AutoSize = true;
            this.lblPasswordOnline.Location = new System.Drawing.Point(36, 136);
            this.lblPasswordOnline.Name = "lblPasswordOnline";
            this.lblPasswordOnline.Size = new System.Drawing.Size(68, 16);
            this.lblPasswordOnline.TabIndex = 1;
            this.lblPasswordOnline.Text = "Password";
            // 
            // chkRememberAccountOnline
            // 
            this.chkRememberAccountOnline.AutoSize = true;
            this.chkRememberAccountOnline.Location = new System.Drawing.Point(114, 182);
            this.chkRememberAccountOnline.Name = "chkRememberAccountOnline";
            this.chkRememberAccountOnline.Size = new System.Drawing.Size(156, 20);
            this.chkRememberAccountOnline.TabIndex = 2;
            this.chkRememberAccountOnline.Text = "Remember accounts";
            this.chkRememberAccountOnline.UseVisualStyleBackColor = true;
            // 
            // txtUserNameOnline
            // 
            this.txtUserNameOnline.Location = new System.Drawing.Point(114, 84);
            this.txtUserNameOnline.Name = "txtUserNameOnline";
            this.txtUserNameOnline.Size = new System.Drawing.Size(258, 23);
            this.txtUserNameOnline.TabIndex = 3;
            // 
            // txtPasswordOnline
            // 
            this.txtPasswordOnline.Location = new System.Drawing.Point(114, 133);
            this.txtPasswordOnline.Name = "txtPasswordOnline";
            this.txtPasswordOnline.PasswordChar = '*';
            this.txtPasswordOnline.Size = new System.Drawing.Size(258, 23);
            this.txtPasswordOnline.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.Image = global::ML.AccountManagements.Properties.Resources.Spinner;
            this.pictureBox1.Location = new System.Drawing.Point(60, 212);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblMsg.Location = new System.Drawing.Point(114, 214);
            this.lblMsg.MinimumSize = new System.Drawing.Size(0, 48);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(90, 48);
            this.lblMsg.TabIndex = 5;
            this.lblMsg.Text = "Please wait...";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLinkServer
            // 
            this.lblLinkServer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLinkServer.AutoSize = true;
            this.tblMainOnline.SetColumnSpan(this.lblLinkServer, 3);
            this.lblLinkServer.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblLinkServer.Location = new System.Drawing.Point(36, 271);
            this.lblLinkServer.Name = "lblLinkServer";
            this.lblLinkServer.Size = new System.Drawing.Size(97, 16);
            this.lblLinkServer.TabIndex = 7;
            this.lblLinkServer.Text = "[lblLinkServer]";
            // 
            // lblLogin
            // 
            this.lblLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblLogin.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblLogin.Location = new System.Drawing.Point(222, 26);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(70, 22);
            this.lblLogin.TabIndex = 5;
            this.lblLogin.Text = "LOGIN";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabControlMainPageLoginOnline);
            this.tabControlMain.Controls.Add(this.tabControlMainPageLoginOffline);
            this.tabControlMain.Location = new System.Drawing.Point(46, 61);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(422, 323);
            this.tabControlMain.TabIndex = 7;
            // 
            // tabControlMainPageLoginOnline
            // 
            this.tabControlMainPageLoginOnline.Controls.Add(this.tblMainOnline);
            this.tabControlMainPageLoginOnline.Location = new System.Drawing.Point(4, 25);
            this.tabControlMainPageLoginOnline.Name = "tabControlMainPageLoginOnline";
            this.tabControlMainPageLoginOnline.Padding = new System.Windows.Forms.Padding(3);
            this.tabControlMainPageLoginOnline.Size = new System.Drawing.Size(414, 294);
            this.tabControlMainPageLoginOnline.TabIndex = 0;
            this.tabControlMainPageLoginOnline.Text = "Online";
            this.tabControlMainPageLoginOnline.UseVisualStyleBackColor = true;
            // 
            // tabControlMainPageLoginOffline
            // 
            this.tabControlMainPageLoginOffline.Controls.Add(this.tblMainOffline);
            this.tabControlMainPageLoginOffline.Location = new System.Drawing.Point(4, 25);
            this.tabControlMainPageLoginOffline.Name = "tabControlMainPageLoginOffline";
            this.tabControlMainPageLoginOffline.Padding = new System.Windows.Forms.Padding(3);
            this.tabControlMainPageLoginOffline.Size = new System.Drawing.Size(414, 294);
            this.tabControlMainPageLoginOffline.TabIndex = 1;
            this.tabControlMainPageLoginOffline.Text = "Offline";
            this.tabControlMainPageLoginOffline.UseVisualStyleBackColor = true;
            // 
            // tblMainOffline
            // 
            this.tblMainOffline.ColumnCount = 4;
            this.tblMainOffline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainOffline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblMainOffline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblMainOffline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainOffline.Controls.Add(this.lblUserNameOffline, 1, 3);
            this.tblMainOffline.Controls.Add(this.lblPasswordOffline, 1, 5);
            this.tblMainOffline.Controls.Add(this.txtUserNameOffline, 2, 3);
            this.tblMainOffline.Controls.Add(this.txtPasswordOffline, 2, 5);
            this.tblMainOffline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainOffline.Location = new System.Drawing.Point(3, 3);
            this.tblMainOffline.Name = "tblMainOffline";
            this.tblMainOffline.RowCount = 9;
            this.tblMainOffline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainOffline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainOffline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblMainOffline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainOffline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMainOffline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainOffline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblMainOffline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainOffline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainOffline.Size = new System.Drawing.Size(408, 288);
            this.tblMainOffline.TabIndex = 1;
            // 
            // lblUserNameOffline
            // 
            this.lblUserNameOffline.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUserNameOffline.AutoSize = true;
            this.lblUserNameOffline.Location = new System.Drawing.Point(36, 111);
            this.lblUserNameOffline.Name = "lblUserNameOffline";
            this.lblUserNameOffline.Size = new System.Drawing.Size(72, 16);
            this.lblUserNameOffline.TabIndex = 0;
            this.lblUserNameOffline.Text = "UserName";
            // 
            // lblPasswordOffline
            // 
            this.lblPasswordOffline.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPasswordOffline.AutoSize = true;
            this.lblPasswordOffline.Location = new System.Drawing.Point(36, 160);
            this.lblPasswordOffline.Name = "lblPasswordOffline";
            this.lblPasswordOffline.Size = new System.Drawing.Size(68, 16);
            this.lblPasswordOffline.TabIndex = 1;
            this.lblPasswordOffline.Text = "Password";
            // 
            // txtUserNameOffline
            // 
            this.txtUserNameOffline.Location = new System.Drawing.Point(114, 108);
            this.txtUserNameOffline.Name = "txtUserNameOffline";
            this.txtUserNameOffline.Size = new System.Drawing.Size(258, 23);
            this.txtUserNameOffline.TabIndex = 3;
            this.txtUserNameOffline.Text = "Support";
            // 
            // txtPasswordOffline
            // 
            this.txtPasswordOffline.Location = new System.Drawing.Point(114, 157);
            this.txtPasswordOffline.Name = "txtPasswordOffline";
            this.txtPasswordOffline.PasswordChar = '*';
            this.txtPasswordOffline.Size = new System.Drawing.Size(258, 23);
            this.txtPasswordOffline.TabIndex = 4;
            this.txtPasswordOffline.Text = "Support@2023";
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 3;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.Controls.Add(this.lblLogin, 1, 1);
            this.tblMain.Controls.Add(this.tblControls, 1, 4);
            this.tblMain.Controls.Add(this.tabControlMain, 1, 3);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 6;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.Size = new System.Drawing.Size(515, 473);
            this.tblMain.TabIndex = 8;
            // 
            // tblControls
            // 
            this.tblControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblControls.AutoSize = true;
            this.tblControls.ColumnCount = 5;
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblControls.Controls.Add(this.mlBtnLogin, 1, 0);
            this.tblControls.Controls.Add(this.mlBtnCancel, 3, 0);
            this.tblControls.Location = new System.Drawing.Point(46, 390);
            this.tblControls.Name = "tblControls";
            this.tblControls.RowCount = 1;
            this.tblControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblControls.Size = new System.Drawing.Size(422, 54);
            this.tblControls.TabIndex = 8;
            // 
            // mlBtnLogin
            // 
            this.mlBtnLogin.AllowLoopEvents = false;
            this.mlBtnLogin.AutoSize = true;
            this.mlBtnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mlBtnLogin.BackColor = System.Drawing.SystemColors.ControlText;
            this.mlBtnLogin.BackColorInNoneStyle = System.Drawing.SystemColors.ButtonFace;
            this.mlBtnLogin.BorderColorInNoneStyle = System.Drawing.Color.Gray;
            this.mlBtnLogin.BorderSizeInNoneStyle = 0;
            this.mlBtnLogin.ButtonStyle = ML.Controls.ButtonStylesEnum.None;
            this.mlBtnLogin.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.mlBtnLogin.FlatAppearance.BorderSize = 0;
            this.mlBtnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlText;
            this.mlBtnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlText;
            this.mlBtnLogin.Font = new System.Drawing.Font("Arial", 10.25F);
            this.mlBtnLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mlBtnLogin.ForeColorInInNoneStyle = System.Drawing.Color.White;
            this.mlBtnLogin.IsStandardButton = true;
            this.mlBtnLogin.Location = new System.Drawing.Point(114, 3);
            this.mlBtnLogin.MinimumSize = new System.Drawing.Size(84, 48);
            this.mlBtnLogin.Name = "mlBtnLogin";
            this.mlBtnLogin.Size = new System.Drawing.Size(84, 48);
            this.mlBtnLogin.TabIndex = 0;
            this.mlBtnLogin.Text = "Login";
            this.mlBtnLogin.UseVisualStyleBackColor = true;
            // 
            // mlBtnCancel
            // 
            this.mlBtnCancel.AllowLoopEvents = false;
            this.mlBtnCancel.AutoSize = true;
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
            this.mlBtnCancel.Location = new System.Drawing.Point(224, 3);
            this.mlBtnCancel.MinimumSize = new System.Drawing.Size(84, 48);
            this.mlBtnCancel.Name = "mlBtnCancel";
            this.mlBtnCancel.Size = new System.Drawing.Size(84, 48);
            this.mlBtnCancel.TabIndex = 1;
            this.mlBtnCancel.Text = "Cancel";
            this.mlBtnCancel.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(515, 473);
            this.Controls.Add(this.tblMain);
            this.Font = new System.Drawing.Font("Arial", 10.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.Text = "Form1";
            this.tblMainOnline.ResumeLayout(false);
            this.tblMainOnline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabControlMainPageLoginOnline.ResumeLayout(false);
            this.tabControlMainPageLoginOffline.ResumeLayout(false);
            this.tblMainOffline.ResumeLayout(false);
            this.tblMainOffline.PerformLayout();
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            this.tblControls.ResumeLayout(false);
            this.tblControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMainOnline;
        private System.Windows.Forms.Label lblUserNameOnline;
        private System.Windows.Forms.Label lblPasswordOnline;
        private System.Windows.Forms.CheckBox chkRememberAccountOnline;
        private System.Windows.Forms.TextBox txtUserNameOnline;
        private System.Windows.Forms.TextBox txtPasswordOnline;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabControlMainPageLoginOnline;
        private System.Windows.Forms.TabPage tabControlMainPageLoginOffline;
        private System.Windows.Forms.TableLayoutPanel tblMainOffline;
        private System.Windows.Forms.Label lblUserNameOffline;
        private System.Windows.Forms.Label lblPasswordOffline;
        private System.Windows.Forms.TextBox txtUserNameOffline;
        private System.Windows.Forms.TextBox txtPasswordOffline;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.TableLayoutPanel tblControls;
        private Controls.MLButton mlBtnLogin;
        private Controls.MLButton mlBtnCancel;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblLinkServer;
    }
}


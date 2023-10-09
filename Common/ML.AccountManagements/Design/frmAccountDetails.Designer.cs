namespace ML.AccountManagements.Design
{
    partial class frmAccountDetails
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
            this.tblMainOnline = new System.Windows.Forms.TableLayoutPanel();
            this.lblUserNameOnline = new System.Windows.Forms.Label();
            this.lblPasswordOnline = new System.Windows.Forms.Label();
            this.chkRememberAccountOnline = new System.Windows.Forms.CheckBox();
            this.tctUserNameOnline = new System.Windows.Forms.TextBox();
            this.txtPasswordOnline = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.tabControlMainPageLoginOffline = new System.Windows.Forms.TabControl();
            this.tabControlMainPageLoginOnline = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tblMainOffline = new System.Windows.Forms.TableLayoutPanel();
            this.lblUserNameOffline = new System.Windows.Forms.Label();
            this.lblPasswordOffline = new System.Windows.Forms.Label();
            this.txtUserNameOffline = new System.Windows.Forms.TextBox();
            this.txtPasswordOffline = new System.Windows.Forms.TextBox();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mlBtnLogin = new ML.Controls.MLButton();
            this.mlBtnCancel = new ML.Controls.MLButton();
            this.tblMainOnline.SuspendLayout();
            this.tabControlMainPageLoginOffline.SuspendLayout();
            this.tabControlMainPageLoginOnline.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tblMainOffline.SuspendLayout();
            this.tblMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tblMainOnline.Controls.Add(this.tctUserNameOnline, 2, 3);
            this.tblMainOnline.Controls.Add(this.txtPasswordOnline, 2, 5);
            this.tblMainOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainOnline.Location = new System.Drawing.Point(3, 3);
            this.tblMainOnline.Name = "tblMainOnline";
            this.tblMainOnline.RowCount = 9;
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainOnline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainOnline.Size = new System.Drawing.Size(408, 146);
            this.tblMainOnline.TabIndex = 0;
            // 
            // lblUserNameOnline
            // 
            this.lblUserNameOnline.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUserNameOnline.AutoSize = true;
            this.lblUserNameOnline.Location = new System.Drawing.Point(32, 30);
            this.lblUserNameOnline.Name = "lblUserNameOnline";
            this.lblUserNameOnline.Size = new System.Drawing.Size(80, 18);
            this.lblUserNameOnline.TabIndex = 0;
            this.lblUserNameOnline.Text = "UserName";
            // 
            // lblPasswordOnline
            // 
            this.lblPasswordOnline.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPasswordOnline.AutoSize = true;
            this.lblPasswordOnline.Location = new System.Drawing.Point(32, 70);
            this.lblPasswordOnline.Name = "lblPasswordOnline";
            this.lblPasswordOnline.Size = new System.Drawing.Size(75, 18);
            this.lblPasswordOnline.TabIndex = 1;
            this.lblPasswordOnline.Text = "Password";
            // 
            // chkRememberAccountOnline
            // 
            this.chkRememberAccountOnline.AutoSize = true;
            this.chkRememberAccountOnline.Location = new System.Drawing.Point(118, 107);
            this.chkRememberAccountOnline.Name = "chkRememberAccountOnline";
            this.chkRememberAccountOnline.Size = new System.Drawing.Size(166, 22);
            this.chkRememberAccountOnline.TabIndex = 2;
            this.chkRememberAccountOnline.Text = "Remember accounts";
            this.chkRememberAccountOnline.UseVisualStyleBackColor = true;
            // 
            // tctUserNameOnline
            // 
            this.tctUserNameOnline.Location = new System.Drawing.Point(118, 27);
            this.tctUserNameOnline.Name = "tctUserNameOnline";
            this.tctUserNameOnline.Size = new System.Drawing.Size(258, 24);
            this.tctUserNameOnline.TabIndex = 3;
            // 
            // txtPasswordOnline
            // 
            this.txtPasswordOnline.Location = new System.Drawing.Point(118, 67);
            this.txtPasswordOnline.Name = "txtPasswordOnline";
            this.txtPasswordOnline.Size = new System.Drawing.Size(258, 24);
            this.txtPasswordOnline.TabIndex = 4;
            // 
            // lblLogin
            // 
            this.lblLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblLogin.Location = new System.Drawing.Point(202, 29);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(67, 24);
            this.lblLogin.TabIndex = 5;
            this.lblLogin.Text = "LOGIN";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabControlMainPageLoginOffline
            // 
            this.tabControlMainPageLoginOffline.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMainPageLoginOffline.Controls.Add(this.tabControlMainPageLoginOnline);
            this.tabControlMainPageLoginOffline.Controls.Add(this.tabPage2);
            this.tabControlMainPageLoginOffline.Location = new System.Drawing.Point(25, 66);
            this.tabControlMainPageLoginOffline.Name = "tabControlMainPageLoginOffline";
            this.tabControlMainPageLoginOffline.SelectedIndex = 0;
            this.tabControlMainPageLoginOffline.Size = new System.Drawing.Size(422, 183);
            this.tabControlMainPageLoginOffline.TabIndex = 7;
            // 
            // tabControlMainPageLoginOnline
            // 
            this.tabControlMainPageLoginOnline.Controls.Add(this.tblMainOnline);
            this.tabControlMainPageLoginOnline.Location = new System.Drawing.Point(4, 27);
            this.tabControlMainPageLoginOnline.Name = "tabControlMainPageLoginOnline";
            this.tabControlMainPageLoginOnline.Padding = new System.Windows.Forms.Padding(3);
            this.tabControlMainPageLoginOnline.Size = new System.Drawing.Size(414, 152);
            this.tabControlMainPageLoginOnline.TabIndex = 0;
            this.tabControlMainPageLoginOnline.Text = "Online";
            this.tabControlMainPageLoginOnline.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tblMainOffline);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(414, 157);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Offline";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.tblMainOffline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMainOffline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainOffline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMainOffline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainOffline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMainOffline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMainOffline.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainOffline.Size = new System.Drawing.Size(408, 151);
            this.tblMainOffline.TabIndex = 1;
            // 
            // lblUserNameOffline
            // 
            this.lblUserNameOffline.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUserNameOffline.AutoSize = true;
            this.lblUserNameOffline.Location = new System.Drawing.Point(32, 46);
            this.lblUserNameOffline.Name = "lblUserNameOffline";
            this.lblUserNameOffline.Size = new System.Drawing.Size(80, 18);
            this.lblUserNameOffline.TabIndex = 0;
            this.lblUserNameOffline.Text = "UserName";
            // 
            // lblPasswordOffline
            // 
            this.lblPasswordOffline.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPasswordOffline.AutoSize = true;
            this.lblPasswordOffline.Location = new System.Drawing.Point(32, 86);
            this.lblPasswordOffline.Name = "lblPasswordOffline";
            this.lblPasswordOffline.Size = new System.Drawing.Size(75, 18);
            this.lblPasswordOffline.TabIndex = 1;
            this.lblPasswordOffline.Text = "Password";
            // 
            // txtUserNameOffline
            // 
            this.txtUserNameOffline.Location = new System.Drawing.Point(118, 43);
            this.txtUserNameOffline.Name = "txtUserNameOffline";
            this.txtUserNameOffline.Size = new System.Drawing.Size(258, 24);
            this.txtUserNameOffline.TabIndex = 3;
            // 
            // txtPasswordOffline
            // 
            this.txtPasswordOffline.Location = new System.Drawing.Point(118, 83);
            this.txtPasswordOffline.Name = "txtPasswordOffline";
            this.txtPasswordOffline.Size = new System.Drawing.Size(258, 24);
            this.txtPasswordOffline.TabIndex = 4;
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 3;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.Controls.Add(this.tabControlMainPageLoginOffline, 1, 3);
            this.tblMain.Controls.Add(this.lblLogin, 1, 1);
            this.tblMain.Controls.Add(this.tableLayoutPanel1, 1, 4);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 6;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.Size = new System.Drawing.Size(473, 315);
            this.tblMain.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.mlBtnLogin, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.mlBtnCancel, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(25, 255);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(422, 37);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // mlBtnLogin
            // 
            this.mlBtnLogin.AllowLoopEvents = false;
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
            this.mlBtnLogin.Location = new System.Drawing.Point(123, 3);
            this.mlBtnLogin.MinimumSize = new System.Drawing.Size(0, 32);
            this.mlBtnLogin.Name = "mlBtnLogin";
            this.mlBtnLogin.Size = new System.Drawing.Size(75, 32);
            this.mlBtnLogin.TabIndex = 0;
            this.mlBtnLogin.Text = "Login";
            this.mlBtnLogin.UseVisualStyleBackColor = true;
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
            this.mlBtnCancel.Location = new System.Drawing.Point(224, 3);
            this.mlBtnCancel.MinimumSize = new System.Drawing.Size(0, 32);
            this.mlBtnCancel.Name = "mlBtnCancel";
            this.mlBtnCancel.Size = new System.Drawing.Size(75, 32);
            this.mlBtnCancel.TabIndex = 1;
            this.mlBtnCancel.Text = "Cancel";
            this.mlBtnCancel.UseVisualStyleBackColor = true;
            // 
            // frmAccountDetails
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(473, 315);
            this.Controls.Add(this.tblMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.Name = "frmAccountDetails";
            this.Text = "Form1";
            this.tblMainOnline.ResumeLayout(false);
            this.tblMainOnline.PerformLayout();
            this.tabControlMainPageLoginOffline.ResumeLayout(false);
            this.tabControlMainPageLoginOnline.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tblMainOffline.ResumeLayout(false);
            this.tblMainOffline.PerformLayout();
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMainOnline;
        private System.Windows.Forms.Label lblUserNameOnline;
        private System.Windows.Forms.Label lblPasswordOnline;
        private System.Windows.Forms.CheckBox chkRememberAccountOnline;
        private System.Windows.Forms.TextBox tctUserNameOnline;
        private System.Windows.Forms.TextBox txtPasswordOnline;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TabControl tabControlMainPageLoginOffline;
        private System.Windows.Forms.TabPage tabControlMainPageLoginOnline;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tblMainOffline;
        private System.Windows.Forms.Label lblUserNameOffline;
        private System.Windows.Forms.Label lblPasswordOffline;
        private System.Windows.Forms.TextBox txtUserNameOffline;
        private System.Windows.Forms.TextBox txtPasswordOffline;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.MLButton mlBtnLogin;
        private Controls.MLButton mlBtnCancel;
    }
}


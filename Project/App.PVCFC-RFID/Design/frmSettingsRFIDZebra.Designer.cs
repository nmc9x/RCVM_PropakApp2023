namespace App.PVCFC_RFID.Design
{
    partial class frmSettingsRFIDZebra
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
            this.ucSettingsItemsRFIDZebraFX96001 = new App.PVCFC_RFID.Design.ucSettingsItemsRFIDZebraFX9600();
            this.SuspendLayout();
            // 
            // ucSettingsItemsRFIDZebraFX96001
            // 
            this.ucSettingsItemsRFIDZebraFX96001.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSettingsItemsRFIDZebraFX96001.Font = new System.Drawing.Font("Arial", 10.25F);
            this.ucSettingsItemsRFIDZebraFX96001.Index = 0;
            this.ucSettingsItemsRFIDZebraFX96001.Location = new System.Drawing.Point(24, 24);
            this.ucSettingsItemsRFIDZebraFX96001.Name = "ucSettingsItemsRFIDZebraFX96001";
            this.ucSettingsItemsRFIDZebraFX96001.Size = new System.Drawing.Size(989, 667);
            this.ucSettingsItemsRFIDZebraFX96001.TabIndex = 0;
            this.ucSettingsItemsRFIDZebraFX96001.Title = "";
            // 
            // frmSettingsRFIDZebra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 715);
            this.Controls.Add(this.ucSettingsItemsRFIDZebraFX96001);
            this.Name = "frmSettingsRFIDZebra";
            this.Padding = new System.Windows.Forms.Padding(24);
            this.Text = "frmSettingsRFIDZebra";
            this.ResumeLayout(false);

        }

        #endregion

        private ucSettingsItemsRFIDZebraFX9600 ucSettingsItemsRFIDZebraFX96001;
    }
}
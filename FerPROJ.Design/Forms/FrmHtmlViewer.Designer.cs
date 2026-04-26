namespace FerPROJ.Design.Forms {
    partial class FrmHtmlViewer {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            ((System.ComponentModel.ISupportInitialize)(this.baseKryptonPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // baseKryptonPanel
            // 
            this.baseKryptonPanel.Size = new System.Drawing.Size(800, 450);
            // 
            // FrmHtmlViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "FrmHtmlViewer";
            this.StateCommon.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Back.Color2 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Header.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Header.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.Text = "FrmHtmReport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmHtmlViewer_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.baseKryptonPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
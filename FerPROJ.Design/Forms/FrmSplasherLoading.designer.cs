
using FerPROJ.Design.Controls;

namespace FerPROJ.Design.Forms
{
    partial class FrmSplasherLoading
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
            this.panelLoading = new System.Windows.Forms.Panel();
            this.customLabelTitleLoading = new FerPROJ.Design.Controls.CLabelTitle();
            this.panelLoading.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLoading
            // 
            this.panelLoading.Controls.Add(this.customLabelTitleLoading);
            this.panelLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoading.Location = new System.Drawing.Point(3, 3);
            this.panelLoading.Name = "panelLoading";
            this.panelLoading.Size = new System.Drawing.Size(170, 31);
            this.panelLoading.TabIndex = 0;
            // 
            // customLabelTitleLoading
            // 
            this.customLabelTitleLoading.BackColor = System.Drawing.Color.Black;
            this.customLabelTitleLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customLabelTitleLoading.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabelTitleLoading.ForeColor = System.Drawing.Color.White;
            this.customLabelTitleLoading.Location = new System.Drawing.Point(0, 0);
            this.customLabelTitleLoading.Name = "customLabelTitleLoading";
            this.customLabelTitleLoading.Size = new System.Drawing.Size(170, 31);
            this.customLabelTitleLoading.TabIndex = 0;
            this.customLabelTitleLoading.Text = "Loading. . . ";
            this.customLabelTitleLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmSplasherLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(176, 37);
            this.Controls.Add(this.panelLoading);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.ForeColor = System.Drawing.Color.Silver;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSplasherLoading";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCRSplasherMain";
            this.TopMost = true;
            this.panelLoading.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLoading;
        private CLabelTitle customLabelTitleLoading;
    }
}
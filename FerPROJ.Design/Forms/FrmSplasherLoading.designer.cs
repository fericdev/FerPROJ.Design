
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.customLabelTitle1 = new FerPROJ.Design.Controls.CLabelTitle();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.customLabelTitle1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(97, 23);
            this.panel1.TabIndex = 0;
            // 
            // customLabelTitle1
            // 
            this.customLabelTitle1.BackColor = System.Drawing.Color.Black;
            this.customLabelTitle1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customLabelTitle1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabelTitle1.ForeColor = System.Drawing.Color.White;
            this.customLabelTitle1.Location = new System.Drawing.Point(0, 0);
            this.customLabelTitle1.Name = "customLabelTitle1";
            this.customLabelTitle1.Size = new System.Drawing.Size(97, 23);
            this.customLabelTitle1.TabIndex = 0;
            this.customLabelTitle1.Text = "Loading. . . ";
            this.customLabelTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmSplasherLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(103, 29);
            this.Controls.Add(this.panel1);
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
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CLabelTitle customLabelTitle1;
    }
}
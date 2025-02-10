
namespace FerPROJ.Design.Controls
{
    partial class CUserControl
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
            this.ucPanelMain = new System.Windows.Forms.Panel();
            this.ucPanelMain1 = new System.Windows.Forms.Panel();
            this.ucLabelMain4 = new System.Windows.Forms.Label();
            this.ucLabelMain3 = new System.Windows.Forms.Label();
            this.ucLabelMain2 = new System.Windows.Forms.Label();
            this.ucLabelMain1 = new System.Windows.Forms.Label();
            this.ucPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucPanelMain
            // 
            this.ucPanelMain.Controls.Add(this.ucPanelMain1);
            this.ucPanelMain.Controls.Add(this.ucLabelMain4);
            this.ucPanelMain.Controls.Add(this.ucLabelMain3);
            this.ucPanelMain.Controls.Add(this.ucLabelMain2);
            this.ucPanelMain.Controls.Add(this.ucLabelMain1);
            this.ucPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPanelMain.Location = new System.Drawing.Point(0, 0);
            this.ucPanelMain.Name = "ucPanelMain";
            this.ucPanelMain.Size = new System.Drawing.Size(799, 542);
            this.ucPanelMain.TabIndex = 0;
            // 
            // ucPanelMain1
            // 
            this.ucPanelMain1.AutoScroll = true;
            this.ucPanelMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPanelMain1.Location = new System.Drawing.Point(3, 3);
            this.ucPanelMain1.Name = "ucPanelMain1";
            this.ucPanelMain1.Size = new System.Drawing.Size(793, 536);
            this.ucPanelMain1.TabIndex = 4;
            // 
            // ucLabelMain4
            // 
            this.ucLabelMain4.BackColor = System.Drawing.Color.Black;
            this.ucLabelMain4.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucLabelMain4.Location = new System.Drawing.Point(3, 0);
            this.ucLabelMain4.Name = "ucLabelMain4";
            this.ucLabelMain4.Size = new System.Drawing.Size(793, 3);
            this.ucLabelMain4.TabIndex = 3;
            this.ucLabelMain4.Text = "1";
            // 
            // ucLabelMain3
            // 
            this.ucLabelMain3.BackColor = System.Drawing.Color.Black;
            this.ucLabelMain3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucLabelMain3.Location = new System.Drawing.Point(3, 539);
            this.ucLabelMain3.Name = "ucLabelMain3";
            this.ucLabelMain3.Size = new System.Drawing.Size(793, 3);
            this.ucLabelMain3.TabIndex = 2;
            this.ucLabelMain3.Text = "1";
            // 
            // ucLabelMain2
            // 
            this.ucLabelMain2.BackColor = System.Drawing.Color.Black;
            this.ucLabelMain2.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucLabelMain2.Location = new System.Drawing.Point(796, 0);
            this.ucLabelMain2.Name = "ucLabelMain2";
            this.ucLabelMain2.Size = new System.Drawing.Size(3, 542);
            this.ucLabelMain2.TabIndex = 1;
            this.ucLabelMain2.Text = "1";
            // 
            // ucLabelMain1
            // 
            this.ucLabelMain1.BackColor = System.Drawing.Color.Black;
            this.ucLabelMain1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucLabelMain1.Location = new System.Drawing.Point(0, 0);
            this.ucLabelMain1.Name = "ucLabelMain1";
            this.ucLabelMain1.Size = new System.Drawing.Size(3, 542);
            this.ucLabelMain1.TabIndex = 0;
            this.ucLabelMain1.Text = "1";
            // 
            // CUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.ucPanelMain);
            this.Name = "CUserControl";
            this.Size = new System.Drawing.Size(799, 542);
            this.Load += new System.EventHandler(this.ucCustom_Load);
            this.ucPanelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.Label ucLabelMain4;
        protected System.Windows.Forms.Label ucLabelMain3;
        protected System.Windows.Forms.Label ucLabelMain2;
        protected System.Windows.Forms.Label ucLabelMain1;
        protected System.Windows.Forms.Panel ucPanelMain;
        protected System.Windows.Forms.Panel ucPanelMain1;
    }
}

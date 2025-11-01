namespace FerPROJ.Design.Forms {
    partial class FrmContextMenu {
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
            this.panelBackgroundContextMenu = new System.Windows.Forms.Panel();
            this.flowLayoutPanelContextMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.panelBackgroundContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBackgroundContextMenu
            // 
            this.panelBackgroundContextMenu.Controls.Add(this.flowLayoutPanelContextMenu);
            this.panelBackgroundContextMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackgroundContextMenu.Location = new System.Drawing.Point(10, 0);
            this.panelBackgroundContextMenu.Name = "panelBackgroundContextMenu";
            this.panelBackgroundContextMenu.Size = new System.Drawing.Size(222, 87);
            this.panelBackgroundContextMenu.TabIndex = 0;
            // 
            // flowLayoutPanelContextMenu
            // 
            this.flowLayoutPanelContextMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelContextMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelContextMenu.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelContextMenu.Name = "flowLayoutPanelContextMenu";
            this.flowLayoutPanelContextMenu.Size = new System.Drawing.Size(222, 87);
            this.flowLayoutPanelContextMenu.TabIndex = 0;
            // 
            // FrmContextMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(242, 97);
            this.Controls.Add(this.panelBackgroundContextMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmContextMenu";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select:";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmContextMenu_FormClosed);
            this.Load += new System.EventHandler(this.FrmContextMenu_Load);
            this.panelBackgroundContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBackgroundContextMenu;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelContextMenu;
    }
}
namespace BECMS.Main {
    partial class CUserControlMenu {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.baseFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // baseFlowLayoutPanel
            // 
            this.baseFlowLayoutPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.baseFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.baseFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.baseFlowLayoutPanel.Name = "baseFlowLayoutPanel";
            this.baseFlowLayoutPanel.Size = new System.Drawing.Size(275, 846);
            this.baseFlowLayoutPanel.TabIndex = 0;
            // 
            // CUserControlMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.baseFlowLayoutPanel);
            this.Name = "CUserControlMenu";
            this.Size = new System.Drawing.Size(275, 846);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel baseFlowLayoutPanel;
    }
}

namespace FerPROJ.Design.UC {
    partial class UCTaskSidebarMain {
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
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelApprovalLinks = new System.Windows.Forms.Panel();
            this.panelReportMain = new System.Windows.Forms.Panel();
            this.cLabelDescApprovalMain = new FerPROJ.Design.Controls.CLabelDesc();
            this.cLabelDescReportMain = new FerPROJ.Design.Controls.CLabelDesc();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelApprovalLinks.SuspendLayout();
            this.panelReportMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoScroll = true;
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.panelApprovalLinks, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelReportMain, 0, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.25767F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.74233F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(200, 815);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelApprovalLinks
            // 
            this.panelApprovalLinks.Controls.Add(this.cLabelDescApprovalMain);
            this.panelApprovalLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelApprovalLinks.Location = new System.Drawing.Point(3, 3);
            this.panelApprovalLinks.Name = "panelApprovalLinks";
            this.panelApprovalLinks.Size = new System.Drawing.Size(194, 371);
            this.panelApprovalLinks.TabIndex = 0;
            // 
            // panelReportMain
            // 
            this.panelReportMain.Controls.Add(this.cLabelDescReportMain);
            this.panelReportMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReportMain.Location = new System.Drawing.Point(3, 380);
            this.panelReportMain.Name = "panelReportMain";
            this.panelReportMain.Size = new System.Drawing.Size(194, 432);
            this.panelReportMain.TabIndex = 1;
            // 
            // cLabelDescApprovalMain
            // 
            this.cLabelDescApprovalMain.BackColor = System.Drawing.Color.Navy;
            this.cLabelDescApprovalMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.cLabelDescApprovalMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cLabelDescApprovalMain.ForeColor = System.Drawing.Color.White;
            this.cLabelDescApprovalMain.Location = new System.Drawing.Point(0, 0);
            this.cLabelDescApprovalMain.Name = "cLabelDescApprovalMain";
            this.cLabelDescApprovalMain.Size = new System.Drawing.Size(194, 33);
            this.cLabelDescApprovalMain.TabIndex = 0;
            this.cLabelDescApprovalMain.Text = "Approval Links";
            this.cLabelDescApprovalMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cLabelDescReportMain
            // 
            this.cLabelDescReportMain.BackColor = System.Drawing.Color.Navy;
            this.cLabelDescReportMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.cLabelDescReportMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cLabelDescReportMain.ForeColor = System.Drawing.Color.White;
            this.cLabelDescReportMain.Location = new System.Drawing.Point(0, 0);
            this.cLabelDescReportMain.Name = "cLabelDescReportMain";
            this.cLabelDescReportMain.Size = new System.Drawing.Size(194, 33);
            this.cLabelDescReportMain.TabIndex = 1;
            this.cLabelDescReportMain.Text = "Reports";
            this.cLabelDescReportMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCTaskSidebarMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "UCTaskSidebarMain";
            this.Size = new System.Drawing.Size(200, 815);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelApprovalLinks.ResumeLayout(false);
            this.panelReportMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.CLabelDesc cLabelDescApprovalMain;
        private Controls.CLabelDesc cLabelDescReportMain;
        protected System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        protected System.Windows.Forms.Panel panelApprovalLinks;
        protected System.Windows.Forms.Panel panelReportMain;
    }
}

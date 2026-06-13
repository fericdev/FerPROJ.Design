namespace FerPROJ.Design.Forms {
    partial class FrmModernDashboard {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModernDashboard));
            this.pnlMainBot = new System.Windows.Forms.Panel();
            this.pnlMainTop = new System.Windows.Forms.Panel();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.tsMainSettings = new System.Windows.Forms.ToolStrip();
            this.tsMainDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.baseDashboardKryptonPanel = new Krypton.Toolkit.KryptonPanel();
            this.baseDashboardMainCPanel = new FerPROJ.Design.Forms.CPanel();
            this.baseDashboardReportCPanel = new FerPROJ.Design.Forms.CPanel();
            this.reportCUserControlMenuModern = new FerPROJ.Design.Controls.CUserControlMenuModern();
            this.reportBaseCLabelTitle = new FerPROJ.Design.Controls.CLabelTitle();
            this.baseDashboardNavMenuCPanel = new FerPROJ.Design.Forms.CPanel();
            this.profileCPanel = new FerPROJ.Design.Forms.CPanel();
            this.userNameCLabelDesc = new FerPROJ.Design.Controls.CLabelDesc();
            this.profilePictureKryptonPictureBox = new Krypton.Toolkit.KryptonPictureBox();
            this.menuCUserControlMenuModern = new FerPROJ.Design.Controls.CUserControlMenuModern();
            this.systemNameCLabelTitle = new FerPROJ.Design.Controls.CLabelTitle();
            this.lblMainVersionValue = new FerPROJ.Design.Controls.CLabelDesc();
            this.lblMainTimeValue = new FerPROJ.Design.Controls.CLabelDesc();
            this.lblMainTime = new FerPROJ.Design.Controls.CLabelDesc();
            this.lblMainVersion = new FerPROJ.Design.Controls.CLabelDesc();
            this.lblMainDateValue = new FerPROJ.Design.Controls.CLabelDesc();
            this.lblMainDate = new FerPROJ.Design.Controls.CLabelDesc();
            ((System.ComponentModel.ISupportInitialize)(this.baseKryptonPanel)).BeginInit();
            this.pnlMainBot.SuspendLayout();
            this.pnlMainTop.SuspendLayout();
            this.tsMainSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseDashboardKryptonPanel)).BeginInit();
            this.baseDashboardKryptonPanel.SuspendLayout();
            this.baseDashboardReportCPanel.SuspendLayout();
            this.baseDashboardNavMenuCPanel.SuspendLayout();
            this.profileCPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureKryptonPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // baseKryptonPanel
            // 
            this.baseKryptonPanel.Size = new System.Drawing.Size(1253, 752);
            // 
            // pnlMainBot
            // 
            this.pnlMainBot.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.pnlMainBot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMainBot.Controls.Add(this.lblMainVersionValue);
            this.pnlMainBot.Controls.Add(this.lblMainTimeValue);
            this.pnlMainBot.Controls.Add(this.lblMainTime);
            this.pnlMainBot.Controls.Add(this.lblMainVersion);
            this.pnlMainBot.Controls.Add(this.lblMainDateValue);
            this.pnlMainBot.Controls.Add(this.lblMainDate);
            this.pnlMainBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMainBot.Location = new System.Drawing.Point(0, 722);
            this.pnlMainBot.Name = "pnlMainBot";
            this.pnlMainBot.Size = new System.Drawing.Size(1253, 30);
            this.pnlMainBot.TabIndex = 2;
            // 
            // pnlMainTop
            // 
            this.pnlMainTop.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.pnlMainTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMainTop.Controls.Add(this.systemNameCLabelTitle);
            this.pnlMainTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainTop.Location = new System.Drawing.Point(0, 0);
            this.pnlMainTop.Name = "pnlMainTop";
            this.pnlMainTop.Size = new System.Drawing.Size(1253, 96);
            this.pnlMainTop.TabIndex = 3;
            // 
            // timerMain
            // 
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // tsMainSettings
            // 
            this.tsMainSettings.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolTip;
            this.tsMainSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsMainSettings.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMainSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMainDropDown});
            this.tsMainSettings.Location = new System.Drawing.Point(0, 96);
            this.tsMainSettings.Name = "tsMainSettings";
            this.tsMainSettings.Size = new System.Drawing.Size(1253, 25);
            this.tsMainSettings.TabIndex = 4;
            this.tsMainSettings.Text = "toolStrip1";
            // 
            // tsMainDropDown
            // 
            this.tsMainDropDown.Image = global::FerPROJ.Design.Properties.Resources.icon_settings;
            this.tsMainDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMainDropDown.Name = "tsMainDropDown";
            this.tsMainDropDown.Size = new System.Drawing.Size(119, 22);
            this.tsMainDropDown.Text = "System Settings";
            // 
            // baseDashboardKryptonPanel
            // 
            this.baseDashboardKryptonPanel.Controls.Add(this.baseDashboardMainCPanel);
            this.baseDashboardKryptonPanel.Controls.Add(this.baseDashboardReportCPanel);
            this.baseDashboardKryptonPanel.Controls.Add(this.baseDashboardNavMenuCPanel);
            this.baseDashboardKryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseDashboardKryptonPanel.Location = new System.Drawing.Point(0, 121);
            this.baseDashboardKryptonPanel.Name = "baseDashboardKryptonPanel";
            this.baseDashboardKryptonPanel.Size = new System.Drawing.Size(1253, 601);
            this.baseDashboardKryptonPanel.TabIndex = 6;
            // 
            // baseDashboardMainCPanel
            // 
            this.baseDashboardMainCPanel.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.baseDashboardMainCPanel.BorderFocusColor = System.Drawing.Color.HotPink;
            this.baseDashboardMainCPanel.BorderRadius = 0;
            this.baseDashboardMainCPanel.BorderSize = 2;
            this.baseDashboardMainCPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.baseDashboardMainCPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseDashboardMainCPanel.Location = new System.Drawing.Point(265, 0);
            this.baseDashboardMainCPanel.Name = "baseDashboardMainCPanel";
            this.baseDashboardMainCPanel.Size = new System.Drawing.Size(728, 601);
            this.baseDashboardMainCPanel.TabIndex = 3;
            this.baseDashboardMainCPanel.UnderlinedStyle = false;
            // 
            // baseDashboardReportCPanel
            // 
            this.baseDashboardReportCPanel.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.baseDashboardReportCPanel.BorderFocusColor = System.Drawing.Color.HotPink;
            this.baseDashboardReportCPanel.BorderRadius = 0;
            this.baseDashboardReportCPanel.BorderSize = 2;
            this.baseDashboardReportCPanel.Controls.Add(this.reportCUserControlMenuModern);
            this.baseDashboardReportCPanel.Controls.Add(this.reportBaseCLabelTitle);
            this.baseDashboardReportCPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.baseDashboardReportCPanel.Location = new System.Drawing.Point(993, 0);
            this.baseDashboardReportCPanel.Name = "baseDashboardReportCPanel";
            this.baseDashboardReportCPanel.Size = new System.Drawing.Size(260, 601);
            this.baseDashboardReportCPanel.TabIndex = 2;
            this.baseDashboardReportCPanel.UnderlinedStyle = false;
            // 
            // reportCUserControlMenuModern
            // 
            this.reportCUserControlMenuModern.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.reportCUserControlMenuModern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportCUserControlMenuModern.Location = new System.Drawing.Point(0, 31);
            this.reportCUserControlMenuModern.Name = "reportCUserControlMenuModern";
            this.reportCUserControlMenuModern.Size = new System.Drawing.Size(260, 570);
            this.reportCUserControlMenuModern.TabIndex = 0;
            // 
            // reportBaseCLabelTitle
            // 
            this.reportBaseCLabelTitle.BackColor = System.Drawing.Color.Transparent;
            this.reportBaseCLabelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reportBaseCLabelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.reportBaseCLabelTitle.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.reportBaseCLabelTitle.Location = new System.Drawing.Point(0, 0);
            this.reportBaseCLabelTitle.Name = "reportBaseCLabelTitle";
            this.reportBaseCLabelTitle.Size = new System.Drawing.Size(260, 31);
            this.reportBaseCLabelTitle.TabIndex = 1;
            this.reportBaseCLabelTitle.Text = "Report Center";
            this.reportBaseCLabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // baseDashboardNavMenuCPanel
            // 
            this.baseDashboardNavMenuCPanel.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.baseDashboardNavMenuCPanel.BorderFocusColor = System.Drawing.Color.HotPink;
            this.baseDashboardNavMenuCPanel.BorderRadius = 0;
            this.baseDashboardNavMenuCPanel.BorderSize = 2;
            this.baseDashboardNavMenuCPanel.Controls.Add(this.menuCUserControlMenuModern);
            this.baseDashboardNavMenuCPanel.Controls.Add(this.profileCPanel);
            this.baseDashboardNavMenuCPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.baseDashboardNavMenuCPanel.Location = new System.Drawing.Point(0, 0);
            this.baseDashboardNavMenuCPanel.Name = "baseDashboardNavMenuCPanel";
            this.baseDashboardNavMenuCPanel.Size = new System.Drawing.Size(265, 601);
            this.baseDashboardNavMenuCPanel.TabIndex = 1;
            this.baseDashboardNavMenuCPanel.UnderlinedStyle = false;
            // 
            // profileCPanel
            // 
            this.profileCPanel.BackColor = System.Drawing.Color.Transparent;
            this.profileCPanel.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.profileCPanel.BorderFocusColor = System.Drawing.Color.HotPink;
            this.profileCPanel.BorderRadius = 0;
            this.profileCPanel.BorderSize = 2;
            this.profileCPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.profileCPanel.Controls.Add(this.profilePictureKryptonPictureBox);
            this.profileCPanel.Controls.Add(this.userNameCLabelDesc);
            this.profileCPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.profileCPanel.Location = new System.Drawing.Point(0, 0);
            this.profileCPanel.Name = "profileCPanel";
            this.profileCPanel.Size = new System.Drawing.Size(265, 179);
            this.profileCPanel.TabIndex = 1;
            this.profileCPanel.UnderlinedStyle = false;
            // 
            // userNameCLabelDesc
            // 
            this.userNameCLabelDesc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.userNameCLabelDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.userNameCLabelDesc.ForeColor = System.Drawing.Color.Black;
            this.userNameCLabelDesc.Location = new System.Drawing.Point(0, 147);
            this.userNameCLabelDesc.Name = "userNameCLabelDesc";
            this.userNameCLabelDesc.Size = new System.Drawing.Size(263, 30);
            this.userNameCLabelDesc.TabIndex = 2;
            this.userNameCLabelDesc.Text = "--";
            this.userNameCLabelDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // profilePictureKryptonPictureBox
            // 
            this.profilePictureKryptonPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("profilePictureKryptonPictureBox.BackgroundImage")));
            this.profilePictureKryptonPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.profilePictureKryptonPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profilePictureKryptonPictureBox.Location = new System.Drawing.Point(0, 0);
            this.profilePictureKryptonPictureBox.Name = "profilePictureKryptonPictureBox";
            this.profilePictureKryptonPictureBox.Size = new System.Drawing.Size(263, 147);
            this.profilePictureKryptonPictureBox.TabIndex = 0;
            this.profilePictureKryptonPictureBox.TabStop = false;
            // 
            // menuCUserControlMenuModern
            // 
            this.menuCUserControlMenuModern.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.menuCUserControlMenuModern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuCUserControlMenuModern.Location = new System.Drawing.Point(0, 179);
            this.menuCUserControlMenuModern.Name = "menuCUserControlMenuModern";
            this.menuCUserControlMenuModern.Size = new System.Drawing.Size(265, 422);
            this.menuCUserControlMenuModern.TabIndex = 0;
            // 
            // systemNameCLabelTitle
            // 
            this.systemNameCLabelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.systemNameCLabelTitle.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemNameCLabelTitle.ForeColor = System.Drawing.Color.White;
            this.systemNameCLabelTitle.Location = new System.Drawing.Point(0, 0);
            this.systemNameCLabelTitle.Name = "systemNameCLabelTitle";
            this.systemNameCLabelTitle.Size = new System.Drawing.Size(1251, 94);
            this.systemNameCLabelTitle.TabIndex = 0;
            this.systemNameCLabelTitle.Text = "cLabelTitle1";
            this.systemNameCLabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMainVersionValue
            // 
            this.lblMainVersionValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMainVersionValue.AutoSize = true;
            this.lblMainVersionValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblMainVersionValue.ForeColor = System.Drawing.Color.White;
            this.lblMainVersionValue.Location = new System.Drawing.Point(436, 4);
            this.lblMainVersionValue.Name = "lblMainVersionValue";
            this.lblMainVersionValue.Size = new System.Drawing.Size(18, 17);
            this.lblMainVersionValue.TabIndex = 7;
            this.lblMainVersionValue.Text = "--";
            // 
            // lblMainTimeValue
            // 
            this.lblMainTimeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMainTimeValue.AutoSize = true;
            this.lblMainTimeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblMainTimeValue.ForeColor = System.Drawing.Color.White;
            this.lblMainTimeValue.Location = new System.Drawing.Point(1145, 3);
            this.lblMainTimeValue.Name = "lblMainTimeValue";
            this.lblMainTimeValue.Size = new System.Drawing.Size(18, 17);
            this.lblMainTimeValue.TabIndex = 5;
            this.lblMainTimeValue.Text = "--";
            // 
            // lblMainTime
            // 
            this.lblMainTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMainTime.AutoSize = true;
            this.lblMainTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblMainTime.ForeColor = System.Drawing.Color.White;
            this.lblMainTime.Location = new System.Drawing.Point(1097, 3);
            this.lblMainTime.Name = "lblMainTime";
            this.lblMainTime.Size = new System.Drawing.Size(43, 17);
            this.lblMainTime.TabIndex = 4;
            this.lblMainTime.Text = "Time:";
            // 
            // lblMainVersion
            // 
            this.lblMainVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMainVersion.AutoSize = true;
            this.lblMainVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblMainVersion.ForeColor = System.Drawing.Color.White;
            this.lblMainVersion.Location = new System.Drawing.Point(309, 3);
            this.lblMainVersion.Name = "lblMainVersion";
            this.lblMainVersion.Size = new System.Drawing.Size(110, 17);
            this.lblMainVersion.TabIndex = 6;
            this.lblMainVersion.Text = "System Version:";
            // 
            // lblMainDateValue
            // 
            this.lblMainDateValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMainDateValue.AutoSize = true;
            this.lblMainDateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblMainDateValue.ForeColor = System.Drawing.Color.White;
            this.lblMainDateValue.Location = new System.Drawing.Point(903, 3);
            this.lblMainDateValue.Name = "lblMainDateValue";
            this.lblMainDateValue.Size = new System.Drawing.Size(18, 17);
            this.lblMainDateValue.TabIndex = 3;
            this.lblMainDateValue.Text = "--";
            // 
            // lblMainDate
            // 
            this.lblMainDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMainDate.AutoSize = true;
            this.lblMainDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblMainDate.ForeColor = System.Drawing.Color.White;
            this.lblMainDate.Location = new System.Drawing.Point(855, 3);
            this.lblMainDate.Name = "lblMainDate";
            this.lblMainDate.Size = new System.Drawing.Size(42, 17);
            this.lblMainDate.TabIndex = 2;
            this.lblMainDate.Text = "Date:";
            // 
            // FrmModernDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 752);
            this.Controls.Add(this.baseDashboardKryptonPanel);
            this.Controls.Add(this.tsMainSettings);
            this.Controls.Add(this.pnlMainTop);
            this.Controls.Add(this.pnlMainBot);
            this.Name = "FrmModernDashboard";
            this.StateCommon.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Back.Color2 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Header.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Header.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.Text = "FrmDashboard3";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDashboard3_Load);
            this.Controls.SetChildIndex(this.pnlMainBot, 0);
            this.Controls.SetChildIndex(this.pnlMainTop, 0);
            this.Controls.SetChildIndex(this.tsMainSettings, 0);
            this.Controls.SetChildIndex(this.baseDashboardKryptonPanel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.baseKryptonPanel)).EndInit();
            this.pnlMainBot.ResumeLayout(false);
            this.pnlMainBot.PerformLayout();
            this.pnlMainTop.ResumeLayout(false);
            this.tsMainSettings.ResumeLayout(false);
            this.tsMainSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseDashboardKryptonPanel)).EndInit();
            this.baseDashboardKryptonPanel.ResumeLayout(false);
            this.baseDashboardReportCPanel.ResumeLayout(false);
            this.baseDashboardNavMenuCPanel.ResumeLayout(false);
            this.profileCPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureKryptonPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.CLabelDesc lblMainVersionValue;
        private Controls.CLabelDesc lblMainTimeValue;
        private Controls.CLabelDesc lblMainTime;
        private Controls.CLabelDesc lblMainVersion;
        private Controls.CLabelDesc lblMainDateValue;
        private Controls.CLabelDesc lblMainDate;
        protected System.Windows.Forms.Panel pnlMainTop;
        protected System.Windows.Forms.Panel pnlMainBot;
        private System.Windows.Forms.Timer timerMain;
        public System.Windows.Forms.ToolStrip tsMainSettings;
        private System.Windows.Forms.ToolStripDropDownButton tsMainDropDown;
        public Krypton.Toolkit.KryptonPanel baseDashboardKryptonPanel;
        private Controls.CLabelTitle systemNameCLabelTitle;
        private CPanel baseDashboardNavMenuCPanel;
        private CPanel baseDashboardReportCPanel;
        private CPanel baseDashboardMainCPanel;
        private Controls.CUserControlMenuModern reportCUserControlMenuModern;
        private Controls.CUserControlMenuModern menuCUserControlMenuModern;
        private Controls.CLabelTitle reportBaseCLabelTitle;
        private CPanel profileCPanel;
        private Krypton.Toolkit.KryptonPictureBox profilePictureKryptonPictureBox;
        private Controls.CLabelDesc userNameCLabelDesc;
    }
}
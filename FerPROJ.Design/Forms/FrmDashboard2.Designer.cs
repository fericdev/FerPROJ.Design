namespace FerPROJ.Design.Forms {
    partial class FrmDashboard2 {
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
            this.pnlMainTop = new System.Windows.Forms.Panel();
            this.pnlMainBot = new System.Windows.Forms.Panel();
            this.lblMainVersionValue = new FerPROJ.Design.Controls.CLabelDesc();
            this.lblMainTimeValue = new FerPROJ.Design.Controls.CLabelDesc();
            this.lblMainTime = new FerPROJ.Design.Controls.CLabelDesc();
            this.lblMainVersion = new FerPROJ.Design.Controls.CLabelDesc();
            this.lblMainDateValue = new FerPROJ.Design.Controls.CLabelDesc();
            this.lblMainDate = new FerPROJ.Design.Controls.CLabelDesc();
            this.lblMainUserValue = new FerPROJ.Design.Controls.CLabelDesc();
            this.lblMainUser = new FerPROJ.Design.Controls.CLabelDesc();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlMainBot.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainTop
            // 
            this.pnlMainTop.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.pnlMainTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMainTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainTop.Location = new System.Drawing.Point(0, 0);
            this.pnlMainTop.Name = "pnlMainTop";
            this.pnlMainTop.Size = new System.Drawing.Size(1074, 96);
            this.pnlMainTop.TabIndex = 0;
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
            this.pnlMainBot.Controls.Add(this.lblMainUserValue);
            this.pnlMainBot.Controls.Add(this.lblMainUser);
            this.pnlMainBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMainBot.Location = new System.Drawing.Point(0, 494);
            this.pnlMainBot.Name = "pnlMainBot";
            this.pnlMainBot.Size = new System.Drawing.Size(1074, 30);
            this.pnlMainBot.TabIndex = 1;
            // 
            // lblMainVersionValue
            // 
            this.lblMainVersionValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMainVersionValue.AutoSize = true;
            this.lblMainVersionValue.Font = new System.Drawing.Font("Poppins", 10F);
            this.lblMainVersionValue.ForeColor = System.Drawing.Color.White;
            this.lblMainVersionValue.Location = new System.Drawing.Point(436, 4);
            this.lblMainVersionValue.Name = "lblMainVersionValue";
            this.lblMainVersionValue.Size = new System.Drawing.Size(28, 25);
            this.lblMainVersionValue.TabIndex = 7;
            this.lblMainVersionValue.Text = "--";
            // 
            // lblMainTimeValue
            // 
            this.lblMainTimeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMainTimeValue.AutoSize = true;
            this.lblMainTimeValue.Font = new System.Drawing.Font("Poppins", 10F);
            this.lblMainTimeValue.ForeColor = System.Drawing.Color.White;
            this.lblMainTimeValue.Location = new System.Drawing.Point(966, 3);
            this.lblMainTimeValue.Name = "lblMainTimeValue";
            this.lblMainTimeValue.Size = new System.Drawing.Size(28, 25);
            this.lblMainTimeValue.TabIndex = 5;
            this.lblMainTimeValue.Text = "--";
            // 
            // lblMainTime
            // 
            this.lblMainTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMainTime.AutoSize = true;
            this.lblMainTime.Font = new System.Drawing.Font("Poppins", 10F);
            this.lblMainTime.ForeColor = System.Drawing.Color.White;
            this.lblMainTime.Location = new System.Drawing.Point(918, 3);
            this.lblMainTime.Name = "lblMainTime";
            this.lblMainTime.Size = new System.Drawing.Size(49, 25);
            this.lblMainTime.TabIndex = 4;
            this.lblMainTime.Text = "Time:";
            // 
            // lblMainVersion
            // 
            this.lblMainVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMainVersion.AutoSize = true;
            this.lblMainVersion.Font = new System.Drawing.Font("Poppins", 10F);
            this.lblMainVersion.ForeColor = System.Drawing.Color.White;
            this.lblMainVersion.Location = new System.Drawing.Point(309, 3);
            this.lblMainVersion.Name = "lblMainVersion";
            this.lblMainVersion.Size = new System.Drawing.Size(121, 25);
            this.lblMainVersion.TabIndex = 6;
            this.lblMainVersion.Text = "System Version:";
            // 
            // lblMainDateValue
            // 
            this.lblMainDateValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMainDateValue.AutoSize = true;
            this.lblMainDateValue.Font = new System.Drawing.Font("Poppins", 10F);
            this.lblMainDateValue.ForeColor = System.Drawing.Color.White;
            this.lblMainDateValue.Location = new System.Drawing.Point(724, 3);
            this.lblMainDateValue.Name = "lblMainDateValue";
            this.lblMainDateValue.Size = new System.Drawing.Size(28, 25);
            this.lblMainDateValue.TabIndex = 3;
            this.lblMainDateValue.Text = "--";
            // 
            // lblMainDate
            // 
            this.lblMainDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMainDate.AutoSize = true;
            this.lblMainDate.Font = new System.Drawing.Font("Poppins", 10F);
            this.lblMainDate.ForeColor = System.Drawing.Color.White;
            this.lblMainDate.Location = new System.Drawing.Point(676, 3);
            this.lblMainDate.Name = "lblMainDate";
            this.lblMainDate.Size = new System.Drawing.Size(48, 25);
            this.lblMainDate.TabIndex = 2;
            this.lblMainDate.Text = "Date:";
            // 
            // lblMainUserValue
            // 
            this.lblMainUserValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMainUserValue.AutoSize = true;
            this.lblMainUserValue.Font = new System.Drawing.Font("Poppins", 10F);
            this.lblMainUserValue.ForeColor = System.Drawing.Color.White;
            this.lblMainUserValue.Location = new System.Drawing.Point(104, 4);
            this.lblMainUserValue.Name = "lblMainUserValue";
            this.lblMainUserValue.Size = new System.Drawing.Size(28, 25);
            this.lblMainUserValue.TabIndex = 1;
            this.lblMainUserValue.Text = "--";
            // 
            // lblMainUser
            // 
            this.lblMainUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMainUser.AutoSize = true;
            this.lblMainUser.Font = new System.Drawing.Font("Poppins", 10F);
            this.lblMainUser.ForeColor = System.Drawing.Color.White;
            this.lblMainUser.Location = new System.Drawing.Point(12, 4);
            this.lblMainUser.Name = "lblMainUser";
            this.lblMainUser.Size = new System.Drawing.Size(86, 25);
            this.lblMainUser.TabIndex = 0;
            this.lblMainUser.Text = "Username:";
            // 
            // mainTimer
            // 
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // FrmDashboard2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 524);
            this.Controls.Add(this.pnlMainBot);
            this.Controls.Add(this.pnlMainTop);
            this.Name = "FrmDashboard2";
            this.Text = "FrmDashboard2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDashboard2_Load);
            this.pnlMainBot.ResumeLayout(false);
            this.pnlMainBot.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMainBot;
        private Controls.CLabelDesc lblMainUser;
        private Controls.CLabelDesc lblMainUserValue;
        private Controls.CLabelDesc lblMainTimeValue;
        private Controls.CLabelDesc lblMainTime;
        private Controls.CLabelDesc lblMainDateValue;
        private Controls.CLabelDesc lblMainDate;
        private Controls.CLabelDesc lblMainVersionValue;
        private Controls.CLabelDesc lblMainVersion;
        protected System.Windows.Forms.Panel pnlMainTop;
        private System.Windows.Forms.Timer mainTimer;
    }
}
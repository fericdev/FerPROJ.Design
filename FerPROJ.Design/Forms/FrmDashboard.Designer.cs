
namespace FerPROJ.Design.Forms
{
    partial class FrmDashboard
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
            this.components = new System.ComponentModel.Container();
            this.dbPanel1 = new System.Windows.Forms.Panel();
            this.dbPanel8 = new System.Windows.Forms.Panel();
            this.dbPanel2 = new System.Windows.Forms.Panel();
            this.dbPanel3 = new System.Windows.Forms.Panel();
            this.dbPanel6 = new System.Windows.Forms.Panel();
            this.dbcLabelDesc2 = new FerPROJ.Design.Controls.CLabelDesc();
            this.dbcLabelDesc1 = new FerPROJ.Design.Controls.CLabelDesc();
            this.CurrentTime = new FerPROJ.Design.Controls.CLabelDesc();
            this.CurrentDate = new FerPROJ.Design.Controls.CLabelDesc();
            this.dbPanel5 = new System.Windows.Forms.Panel();
            this.cLabelDesc1 = new FerPROJ.Design.Controls.CLabelDesc();
            this.Username = new FerPROJ.Design.Controls.CLabelDesc();
            this.dbTimer = new System.Windows.Forms.Timer(this.components);
            this.dbPanel1.SuspendLayout();
            this.dbPanel2.SuspendLayout();
            this.dbPanel6.SuspendLayout();
            this.dbPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dbPanel1
            // 
            this.dbPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dbPanel1.Controls.Add(this.dbPanel8);
            this.dbPanel1.Controls.Add(this.dbPanel2);
            this.dbPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbPanel1.Location = new System.Drawing.Point(0, 0);
            this.dbPanel1.Name = "dbPanel1";
            this.dbPanel1.Size = new System.Drawing.Size(809, 489);
            this.dbPanel1.TabIndex = 0;
            // 
            // dbPanel8
            // 
            this.dbPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbPanel8.Location = new System.Drawing.Point(202, 0);
            this.dbPanel8.Name = "dbPanel8";
            this.dbPanel8.Size = new System.Drawing.Size(605, 487);
            this.dbPanel8.TabIndex = 1;
            // 
            // dbPanel2
            // 
            this.dbPanel2.BackColor = System.Drawing.Color.LightYellow;
            this.dbPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dbPanel2.Controls.Add(this.dbPanel3);
            this.dbPanel2.Controls.Add(this.dbPanel6);
            this.dbPanel2.Controls.Add(this.dbPanel5);
            this.dbPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.dbPanel2.Location = new System.Drawing.Point(0, 0);
            this.dbPanel2.Name = "dbPanel2";
            this.dbPanel2.Size = new System.Drawing.Size(202, 487);
            this.dbPanel2.TabIndex = 0;
            // 
            // dbPanel3
            // 
            this.dbPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dbPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbPanel3.Location = new System.Drawing.Point(0, 85);
            this.dbPanel3.Name = "dbPanel3";
            this.dbPanel3.Size = new System.Drawing.Size(200, 313);
            this.dbPanel3.TabIndex = 2;
            // 
            // dbPanel6
            // 
            this.dbPanel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dbPanel6.Controls.Add(this.dbcLabelDesc2);
            this.dbPanel6.Controls.Add(this.dbcLabelDesc1);
            this.dbPanel6.Controls.Add(this.CurrentTime);
            this.dbPanel6.Controls.Add(this.CurrentDate);
            this.dbPanel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dbPanel6.Location = new System.Drawing.Point(0, 398);
            this.dbPanel6.Name = "dbPanel6";
            this.dbPanel6.Size = new System.Drawing.Size(200, 87);
            this.dbPanel6.TabIndex = 1;
            // 
            // dbcLabelDesc2
            // 
            this.dbcLabelDesc2.AutoSize = true;
            this.dbcLabelDesc2.Font = new System.Drawing.Font("Poppins", 10F);
            this.dbcLabelDesc2.Location = new System.Drawing.Point(9, 45);
            this.dbcLabelDesc2.Name = "dbcLabelDesc2";
            this.dbcLabelDesc2.Size = new System.Drawing.Size(49, 25);
            this.dbcLabelDesc2.TabIndex = 4;
            this.dbcLabelDesc2.Text = "Time:";
            // 
            // dbcLabelDesc1
            // 
            this.dbcLabelDesc1.AutoSize = true;
            this.dbcLabelDesc1.Font = new System.Drawing.Font("Poppins", 10F);
            this.dbcLabelDesc1.Location = new System.Drawing.Point(9, 15);
            this.dbcLabelDesc1.Name = "dbcLabelDesc1";
            this.dbcLabelDesc1.Size = new System.Drawing.Size(48, 25);
            this.dbcLabelDesc1.TabIndex = 3;
            this.dbcLabelDesc1.Text = "Date:";
            // 
            // CurrentTime
            // 
            this.CurrentTime.AutoSize = true;
            this.CurrentTime.Font = new System.Drawing.Font("Poppins", 10F);
            this.CurrentTime.Location = new System.Drawing.Point(61, 45);
            this.CurrentTime.Name = "CurrentTime";
            this.CurrentTime.Size = new System.Drawing.Size(28, 25);
            this.CurrentTime.TabIndex = 2;
            this.CurrentTime.Text = "--";
            // 
            // CurrentDate
            // 
            this.CurrentDate.AutoSize = true;
            this.CurrentDate.Font = new System.Drawing.Font("Poppins", 10F);
            this.CurrentDate.Location = new System.Drawing.Point(61, 15);
            this.CurrentDate.Name = "CurrentDate";
            this.CurrentDate.Size = new System.Drawing.Size(28, 25);
            this.CurrentDate.TabIndex = 1;
            this.CurrentDate.Text = "--";
            // 
            // dbPanel5
            // 
            this.dbPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dbPanel5.Controls.Add(this.cLabelDesc1);
            this.dbPanel5.Controls.Add(this.Username);
            this.dbPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.dbPanel5.Location = new System.Drawing.Point(0, 0);
            this.dbPanel5.Name = "dbPanel5";
            this.dbPanel5.Size = new System.Drawing.Size(200, 85);
            this.dbPanel5.TabIndex = 0;
            // 
            // cLabelDesc1
            // 
            this.cLabelDesc1.AutoSize = true;
            this.cLabelDesc1.Font = new System.Drawing.Font("Poppins", 10F);
            this.cLabelDesc1.Location = new System.Drawing.Point(9, 29);
            this.cLabelDesc1.Name = "cLabelDesc1";
            this.cLabelDesc1.Size = new System.Drawing.Size(86, 25);
            this.cLabelDesc1.TabIndex = 4;
            this.cLabelDesc1.Text = "Username:";
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Poppins", 10F);
            this.Username.Location = new System.Drawing.Point(98, 29);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(28, 25);
            this.Username.TabIndex = 0;
            this.Username.Text = "--";
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 489);
            this.Controls.Add(this.dbPanel1);
            this.Name = "FrmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.dbPanel1.ResumeLayout(false);
            this.dbPanel2.ResumeLayout(false);
            this.dbPanel6.ResumeLayout(false);
            this.dbPanel6.PerformLayout();
            this.dbPanel5.ResumeLayout(false);
            this.dbPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel dbPanel1;
        private System.Windows.Forms.Panel dbPanel2;
        private Controls.CLabelDesc Username;
        private Controls.CLabelDesc CurrentTime;
        private Controls.CLabelDesc CurrentDate;
        protected System.Windows.Forms.Panel dbPanel5;
        protected System.Windows.Forms.Panel dbPanel6;
        protected System.Windows.Forms.Panel dbPanel3;
        private System.Windows.Forms.Timer dbTimer;
        private Controls.CLabelDesc dbcLabelDesc2;
        private Controls.CLabelDesc dbcLabelDesc1;
        private Controls.CLabelDesc cLabelDesc1;
        protected System.Windows.Forms.Panel dbPanel8;
    }
}
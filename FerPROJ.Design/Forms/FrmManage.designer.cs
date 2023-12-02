
using FerPROJ.Design.Controls;
using System;

namespace FerPROJ.Design.Forms
{
    partial class FrmManage
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
        private void InitializeComponent() {
            baseLbl1 = new System.Windows.Forms.Label();
            basePnl1 = new System.Windows.Forms.Panel();
            baseButtonAddNew = new CButton();
            basePnl2 = new System.Windows.Forms.Panel();
            baseButtonSave = new CButton();
            baseButtonUpdate = new CButton();
            baseButtonCancel = new CButton();
            basePanelMain = new System.Windows.Forms.Panel();
            PanelMain3 = new System.Windows.Forms.Panel();
            panelMain1 = new System.Windows.Forms.Panel();
            baselabelMain1 = new System.Windows.Forms.Label();
            customLabelDescMain2 = new CLabelDesc();
            pictureBoxMain1 = new System.Windows.Forms.PictureBox();
            customLabelDescMain1 = new CLabelDesc();
            basePnl1.SuspendLayout();
            basePnl2.SuspendLayout();
            basePanelMain.SuspendLayout();
            panelMain1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain1).BeginInit();
            SuspendLayout();
            // 
            // baseLbl1
            // 
            baseLbl1.BackColor = System.Drawing.Color.DimGray;
            baseLbl1.Dock = System.Windows.Forms.DockStyle.Top;
            baseLbl1.Location = new System.Drawing.Point(0, 0);
            baseLbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            baseLbl1.Name = "baseLbl1";
            baseLbl1.Size = new System.Drawing.Size(749, 1);
            baseLbl1.TabIndex = 0;
            baseLbl1.Text = "1";
            // 
            // basePnl1
            // 
            basePnl1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            basePnl1.Controls.Add(baseButtonAddNew);
            basePnl1.Controls.Add(basePnl2);
            basePnl1.Controls.Add(baseLbl1);
            basePnl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            basePnl1.Location = new System.Drawing.Point(8, 405);
            basePnl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            basePnl1.Name = "basePnl1";
            basePnl1.Size = new System.Drawing.Size(749, 82);
            basePnl1.TabIndex = 1;
            // 
            // baseButtonAddNew
            // 
            baseButtonAddNew.BackColor = System.Drawing.Color.RoyalBlue;
            baseButtonAddNew.BackgroundColor = System.Drawing.Color.RoyalBlue;
            baseButtonAddNew.BorderColor = System.Drawing.Color.Green;
            baseButtonAddNew.BorderRadius = 20;
            baseButtonAddNew.BorderSize = 0;
            baseButtonAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            baseButtonAddNew.FlatAppearance.BorderSize = 0;
            baseButtonAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            baseButtonAddNew.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            baseButtonAddNew.ForeColor = System.Drawing.Color.White;
            baseButtonAddNew.Location = new System.Drawing.Point(24, 17);
            baseButtonAddNew.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            baseButtonAddNew.Name = "baseButtonAddNew";
            baseButtonAddNew.Size = new System.Drawing.Size(133, 46);
            baseButtonAddNew.TabIndex = 1;
            baseButtonAddNew.Text = "Save and New";
            baseButtonAddNew.TextColor = System.Drawing.Color.White;
            baseButtonAddNew.UseVisualStyleBackColor = false;
            baseButtonAddNew.Click += baseButtonAddNew_Click;
            // 
            // basePnl2
            // 
            basePnl2.Controls.Add(baseButtonSave);
            basePnl2.Controls.Add(baseButtonUpdate);
            basePnl2.Controls.Add(baseButtonCancel);
            basePnl2.Dock = System.Windows.Forms.DockStyle.Right;
            basePnl2.Location = new System.Drawing.Point(475, 1);
            basePnl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            basePnl2.Name = "basePnl2";
            basePnl2.Size = new System.Drawing.Size(274, 81);
            basePnl2.TabIndex = 2;
            // 
            // baseButtonSave
            // 
            baseButtonSave.BackColor = System.Drawing.Color.SpringGreen;
            baseButtonSave.BackgroundColor = System.Drawing.Color.SpringGreen;
            baseButtonSave.BorderColor = System.Drawing.Color.Green;
            baseButtonSave.BorderRadius = 20;
            baseButtonSave.BorderSize = 0;
            baseButtonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            baseButtonSave.FlatAppearance.BorderSize = 0;
            baseButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            baseButtonSave.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            baseButtonSave.ForeColor = System.Drawing.Color.Black;
            baseButtonSave.Location = new System.Drawing.Point(18, 16);
            baseButtonSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            baseButtonSave.Name = "baseButtonSave";
            baseButtonSave.Size = new System.Drawing.Size(118, 46);
            baseButtonSave.TabIndex = 1;
            baseButtonSave.Text = "Save";
            baseButtonSave.TextColor = System.Drawing.Color.Black;
            baseButtonSave.UseVisualStyleBackColor = false;
            baseButtonSave.Click += btnSaveMain_Click;
            // 
            // baseButtonUpdate
            // 
            baseButtonUpdate.BackColor = System.Drawing.Color.SpringGreen;
            baseButtonUpdate.BackgroundColor = System.Drawing.Color.SpringGreen;
            baseButtonUpdate.BorderColor = System.Drawing.Color.Green;
            baseButtonUpdate.BorderRadius = 20;
            baseButtonUpdate.BorderSize = 0;
            baseButtonUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            baseButtonUpdate.FlatAppearance.BorderSize = 0;
            baseButtonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            baseButtonUpdate.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            baseButtonUpdate.ForeColor = System.Drawing.Color.Black;
            baseButtonUpdate.Location = new System.Drawing.Point(18, 16);
            baseButtonUpdate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            baseButtonUpdate.Name = "baseButtonUpdate";
            baseButtonUpdate.Size = new System.Drawing.Size(118, 46);
            baseButtonUpdate.TabIndex = 0;
            baseButtonUpdate.Text = "Update";
            baseButtonUpdate.TextColor = System.Drawing.Color.Black;
            baseButtonUpdate.UseVisualStyleBackColor = false;
            baseButtonUpdate.Visible = false;
            baseButtonUpdate.Click += btnUpdateMain_Click;
            // 
            // baseButtonCancel
            // 
            baseButtonCancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            baseButtonCancel.BackColor = System.Drawing.Color.Crimson;
            baseButtonCancel.BackgroundColor = System.Drawing.Color.Crimson;
            baseButtonCancel.BorderColor = System.Drawing.Color.Green;
            baseButtonCancel.BorderRadius = 20;
            baseButtonCancel.BorderSize = 0;
            baseButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            baseButtonCancel.FlatAppearance.BorderSize = 0;
            baseButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            baseButtonCancel.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            baseButtonCancel.ForeColor = System.Drawing.Color.White;
            baseButtonCancel.Location = new System.Drawing.Point(142, 16);
            baseButtonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            baseButtonCancel.Name = "baseButtonCancel";
            baseButtonCancel.Size = new System.Drawing.Size(110, 46);
            baseButtonCancel.TabIndex = 1;
            baseButtonCancel.Text = "Cancel";
            baseButtonCancel.TextColor = System.Drawing.Color.White;
            baseButtonCancel.UseVisualStyleBackColor = false;
            baseButtonCancel.Click += baseButtonCancel_Click;
            // 
            // basePanelMain
            // 
            basePanelMain.Controls.Add(PanelMain3);
            basePanelMain.Controls.Add(panelMain1);
            basePanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            basePanelMain.Location = new System.Drawing.Point(8, 8);
            basePanelMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            basePanelMain.Name = "basePanelMain";
            basePanelMain.Size = new System.Drawing.Size(749, 397);
            basePanelMain.TabIndex = 2;
            // 
            // PanelMain3
            // 
            PanelMain3.BackColor = System.Drawing.SystemColors.ButtonFace;
            PanelMain3.Dock = System.Windows.Forms.DockStyle.Fill;
            PanelMain3.Location = new System.Drawing.Point(0, 84);
            PanelMain3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PanelMain3.Name = "PanelMain3";
            PanelMain3.Size = new System.Drawing.Size(749, 313);
            PanelMain3.TabIndex = 1;
            // 
            // panelMain1
            // 
            panelMain1.BackColor = System.Drawing.Color.DodgerBlue;
            panelMain1.Controls.Add(baselabelMain1);
            panelMain1.Controls.Add(customLabelDescMain2);
            panelMain1.Controls.Add(pictureBoxMain1);
            panelMain1.Controls.Add(customLabelDescMain1);
            panelMain1.Dock = System.Windows.Forms.DockStyle.Top;
            panelMain1.Location = new System.Drawing.Point(0, 0);
            panelMain1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelMain1.Name = "panelMain1";
            panelMain1.Size = new System.Drawing.Size(749, 84);
            panelMain1.TabIndex = 6;
            // 
            // baselabelMain1
            // 
            baselabelMain1.BackColor = System.Drawing.Color.DimGray;
            baselabelMain1.Dock = System.Windows.Forms.DockStyle.Bottom;
            baselabelMain1.Location = new System.Drawing.Point(0, 83);
            baselabelMain1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            baselabelMain1.Name = "baselabelMain1";
            baselabelMain1.Size = new System.Drawing.Size(749, 1);
            baselabelMain1.TabIndex = 6;
            baselabelMain1.Text = "1";
            // 
            // customLabelDescMain2
            // 
            customLabelDescMain2.AutoSize = true;
            customLabelDescMain2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            customLabelDescMain2.ForeColor = System.Drawing.Color.White;
            customLabelDescMain2.Location = new System.Drawing.Point(121, 46);
            customLabelDescMain2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            customLabelDescMain2.Name = "customLabelDescMain2";
            customLabelDescMain2.Size = new System.Drawing.Size(364, 23);
            customLabelDescMain2.TabIndex = 5;
            customLabelDescMain2.Text = "Centralized control and insights for efficient operations.";
            // 
            // pictureBoxMain1
            // 
            pictureBoxMain1.BackgroundImage = Properties.Resources.Hopstarter_Button_Button_Info_64;
            pictureBoxMain1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBoxMain1.Location = new System.Drawing.Point(24, 14);
            pictureBoxMain1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBoxMain1.Name = "pictureBoxMain1";
            pictureBoxMain1.Size = new System.Drawing.Size(70, 58);
            pictureBoxMain1.TabIndex = 3;
            pictureBoxMain1.TabStop = false;
            // 
            // customLabelDescMain1
            // 
            customLabelDescMain1.AutoSize = true;
            customLabelDescMain1.Font = new System.Drawing.Font("Poppins SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            customLabelDescMain1.ForeColor = System.Drawing.Color.White;
            customLabelDescMain1.Location = new System.Drawing.Point(102, 17);
            customLabelDescMain1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            customLabelDescMain1.Name = "customLabelDescMain1";
            customLabelDescMain1.Size = new System.Drawing.Size(132, 23);
            customLabelDescMain1.TabIndex = 4;
            customLabelDescMain1.Text = "Management Hub";
            // 
            // FrmManage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.DodgerBlue;
            ClientSize = new System.Drawing.Size(765, 495);
            Controls.Add(basePanelMain);
            Controls.Add(basePnl1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmManage";
            Padding = new System.Windows.Forms.Padding(8);
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FrmManageMain";
            basePnl1.ResumeLayout(false);
            basePnl2.ResumeLayout(false);
            basePanelMain.ResumeLayout(false);
            panelMain1.ResumeLayout(false);
            panelMain1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label baseLbl1;
        private System.Windows.Forms.Panel basePnl1;
        protected System.Windows.Forms.Panel basePnl2;
        protected CButton baseButtonUpdate;
        protected CButton baseButtonSave;
        protected CButton baseButtonCancel;
        private System.Windows.Forms.Panel basePanelMain;
        protected System.Windows.Forms.Panel PanelMain3;
        protected CButton baseButtonAddNew;
        private Controls.CLabelDesc customLabelDescMain2;
        private Controls.CLabelDesc customLabelDescMain1;
        private System.Windows.Forms.PictureBox pictureBoxMain1;
        private System.Windows.Forms.Panel panelMain1;
        private System.Windows.Forms.Label baselabelMain1;
    }
}
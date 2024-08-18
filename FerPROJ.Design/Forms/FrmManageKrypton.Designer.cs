
using FerPROJ.Design.Controls;
using System;

namespace FerPROJ.Design.Forms
{
    partial class FrmManageKrypton
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
            this.baseLbl1 = new System.Windows.Forms.Label();
            this.basePnl1 = new System.Windows.Forms.Panel();
            this.baseButtonAddNew = new FerPROJ.Design.Controls.CButton();
            this.basePnl2 = new System.Windows.Forms.Panel();
            this.baseButtonSave = new FerPROJ.Design.Controls.CButton();
            this.baseButtonUpdate = new FerPROJ.Design.Controls.CButton();
            this.baseButtonCancel = new FerPROJ.Design.Controls.CButton();
            this.basePanelMain = new System.Windows.Forms.Panel();
            this.PanelMain3 = new System.Windows.Forms.Panel();
            this.panelMain1 = new System.Windows.Forms.Panel();
            this.baselabelMain1 = new System.Windows.Forms.Label();
            this.customLabelDescMain2 = new FerPROJ.Design.Controls.CLabelDesc();
            this.pictureBoxMain1 = new System.Windows.Forms.PictureBox();
            this.customLabelDescMain1 = new FerPROJ.Design.Controls.CLabelDesc();
            this.basePnl1.SuspendLayout();
            this.basePnl2.SuspendLayout();
            this.basePanelMain.SuspendLayout();
            this.panelMain1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain1)).BeginInit();
            this.SuspendLayout();
            // 
            // baseLbl1
            // 
            this.baseLbl1.BackColor = System.Drawing.Color.DimGray;
            this.baseLbl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.baseLbl1.Location = new System.Drawing.Point(0, 0);
            this.baseLbl1.Name = "baseLbl1";
            this.baseLbl1.Size = new System.Drawing.Size(634, 1);
            this.baseLbl1.TabIndex = 0;
            this.baseLbl1.Text = "1";
            // 
            // basePnl1
            // 
            this.basePnl1.BackColor = System.Drawing.Color.Navy;
            this.basePnl1.Controls.Add(this.baseButtonAddNew);
            this.basePnl1.Controls.Add(this.basePnl2);
            this.basePnl1.Controls.Add(this.baseLbl1);
            this.basePnl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.basePnl1.Location = new System.Drawing.Point(7, 363);
            this.basePnl1.Name = "basePnl1";
            this.basePnl1.Size = new System.Drawing.Size(634, 71);
            this.basePnl1.TabIndex = 1;
            // 
            // baseButtonAddNew
            // 
            this.baseButtonAddNew.BackColor = System.Drawing.Color.RoyalBlue;
            this.baseButtonAddNew.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.baseButtonAddNew.BorderColor = System.Drawing.Color.Green;
            this.baseButtonAddNew.BorderRadius = 20;
            this.baseButtonAddNew.BorderSize = 0;
            this.baseButtonAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.baseButtonAddNew.FlatAppearance.BorderSize = 0;
            this.baseButtonAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.baseButtonAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseButtonAddNew.ForeColor = System.Drawing.Color.White;
            this.baseButtonAddNew.Location = new System.Drawing.Point(21, 15);
            this.baseButtonAddNew.Name = "baseButtonAddNew";
            this.baseButtonAddNew.Size = new System.Drawing.Size(114, 40);
            this.baseButtonAddNew.TabIndex = 1;
            this.baseButtonAddNew.Text = "Save and New";
            this.baseButtonAddNew.TextColor = System.Drawing.Color.White;
            this.baseButtonAddNew.UseVisualStyleBackColor = false;
            this.baseButtonAddNew.Click += new System.EventHandler(this.baseButtonAddNew_Click);
            // 
            // basePnl2
            // 
            this.basePnl2.Controls.Add(this.baseButtonSave);
            this.basePnl2.Controls.Add(this.baseButtonUpdate);
            this.basePnl2.Controls.Add(this.baseButtonCancel);
            this.basePnl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.basePnl2.Location = new System.Drawing.Point(399, 1);
            this.basePnl2.Name = "basePnl2";
            this.basePnl2.Size = new System.Drawing.Size(235, 70);
            this.basePnl2.TabIndex = 2;
            // 
            // baseButtonSave
            // 
            this.baseButtonSave.BackColor = System.Drawing.Color.SpringGreen;
            this.baseButtonSave.BackgroundColor = System.Drawing.Color.SpringGreen;
            this.baseButtonSave.BorderColor = System.Drawing.Color.Green;
            this.baseButtonSave.BorderRadius = 20;
            this.baseButtonSave.BorderSize = 0;
            this.baseButtonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.baseButtonSave.FlatAppearance.BorderSize = 0;
            this.baseButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.baseButtonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseButtonSave.ForeColor = System.Drawing.Color.Black;
            this.baseButtonSave.Location = new System.Drawing.Point(15, 14);
            this.baseButtonSave.Name = "baseButtonSave";
            this.baseButtonSave.Size = new System.Drawing.Size(101, 40);
            this.baseButtonSave.TabIndex = 1;
            this.baseButtonSave.Text = "Save";
            this.baseButtonSave.TextColor = System.Drawing.Color.Black;
            this.baseButtonSave.UseVisualStyleBackColor = false;
            this.baseButtonSave.Click += new System.EventHandler(this.btnSaveMain_Click);
            // 
            // baseButtonUpdate
            // 
            this.baseButtonUpdate.BackColor = System.Drawing.Color.SpringGreen;
            this.baseButtonUpdate.BackgroundColor = System.Drawing.Color.SpringGreen;
            this.baseButtonUpdate.BorderColor = System.Drawing.Color.Green;
            this.baseButtonUpdate.BorderRadius = 20;
            this.baseButtonUpdate.BorderSize = 0;
            this.baseButtonUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.baseButtonUpdate.FlatAppearance.BorderSize = 0;
            this.baseButtonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.baseButtonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseButtonUpdate.ForeColor = System.Drawing.Color.Black;
            this.baseButtonUpdate.Location = new System.Drawing.Point(15, 14);
            this.baseButtonUpdate.Name = "baseButtonUpdate";
            this.baseButtonUpdate.Size = new System.Drawing.Size(101, 40);
            this.baseButtonUpdate.TabIndex = 0;
            this.baseButtonUpdate.Text = "Update";
            this.baseButtonUpdate.TextColor = System.Drawing.Color.Black;
            this.baseButtonUpdate.UseVisualStyleBackColor = false;
            this.baseButtonUpdate.Visible = false;
            this.baseButtonUpdate.Click += new System.EventHandler(this.btnUpdateMain_Click);
            // 
            // baseButtonCancel
            // 
            this.baseButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.baseButtonCancel.BackColor = System.Drawing.Color.Crimson;
            this.baseButtonCancel.BackgroundColor = System.Drawing.Color.Crimson;
            this.baseButtonCancel.BorderColor = System.Drawing.Color.Green;
            this.baseButtonCancel.BorderRadius = 20;
            this.baseButtonCancel.BorderSize = 0;
            this.baseButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.baseButtonCancel.FlatAppearance.BorderSize = 0;
            this.baseButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.baseButtonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseButtonCancel.ForeColor = System.Drawing.Color.White;
            this.baseButtonCancel.Location = new System.Drawing.Point(122, 14);
            this.baseButtonCancel.Name = "baseButtonCancel";
            this.baseButtonCancel.Size = new System.Drawing.Size(94, 40);
            this.baseButtonCancel.TabIndex = 1;
            this.baseButtonCancel.Text = "Cancel";
            this.baseButtonCancel.TextColor = System.Drawing.Color.White;
            this.baseButtonCancel.UseVisualStyleBackColor = false;
            this.baseButtonCancel.Click += new System.EventHandler(this.baseButtonCancel_Click);
            // 
            // basePanelMain
            // 
            this.basePanelMain.Controls.Add(this.PanelMain3);
            this.basePanelMain.Controls.Add(this.panelMain1);
            this.basePanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.basePanelMain.Location = new System.Drawing.Point(7, 7);
            this.basePanelMain.Name = "basePanelMain";
            this.basePanelMain.Size = new System.Drawing.Size(634, 356);
            this.basePanelMain.TabIndex = 2;
            // 
            // PanelMain3
            // 
            this.PanelMain3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PanelMain3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain3.Location = new System.Drawing.Point(0, 73);
            this.PanelMain3.Name = "PanelMain3";
            this.PanelMain3.Size = new System.Drawing.Size(634, 283);
            this.PanelMain3.TabIndex = 1;
            // 
            // panelMain1
            // 
            this.panelMain1.BackColor = System.Drawing.Color.Navy;
            this.panelMain1.Controls.Add(this.baselabelMain1);
            this.panelMain1.Controls.Add(this.customLabelDescMain2);
            this.panelMain1.Controls.Add(this.pictureBoxMain1);
            this.panelMain1.Controls.Add(this.customLabelDescMain1);
            this.panelMain1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain1.Location = new System.Drawing.Point(0, 0);
            this.panelMain1.Name = "panelMain1";
            this.panelMain1.Size = new System.Drawing.Size(634, 73);
            this.panelMain1.TabIndex = 6;
            // 
            // baselabelMain1
            // 
            this.baselabelMain1.BackColor = System.Drawing.Color.DimGray;
            this.baselabelMain1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.baselabelMain1.Location = new System.Drawing.Point(0, 72);
            this.baselabelMain1.Name = "baselabelMain1";
            this.baselabelMain1.Size = new System.Drawing.Size(634, 1);
            this.baselabelMain1.TabIndex = 6;
            this.baselabelMain1.Text = "1";
            // 
            // customLabelDescMain2
            // 
            this.customLabelDescMain2.AutoSize = true;
            this.customLabelDescMain2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabelDescMain2.ForeColor = System.Drawing.Color.White;
            this.customLabelDescMain2.Location = new System.Drawing.Point(104, 40);
            this.customLabelDescMain2.Name = "customLabelDescMain2";
            this.customLabelDescMain2.Size = new System.Drawing.Size(327, 16);
            this.customLabelDescMain2.TabIndex = 5;
            this.customLabelDescMain2.Text = "Centralized control and insights for efficient operations.";
            // 
            // pictureBoxMain1
            // 
            this.pictureBoxMain1.BackgroundImage = global::FerPROJ.Design.Properties.Resources.Hopstarter_Button_Button_Info_64;
            this.pictureBoxMain1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxMain1.Location = new System.Drawing.Point(21, 12);
            this.pictureBoxMain1.Name = "pictureBoxMain1";
            this.pictureBoxMain1.Size = new System.Drawing.Size(60, 50);
            this.pictureBoxMain1.TabIndex = 3;
            this.pictureBoxMain1.TabStop = false;
            // 
            // customLabelDescMain1
            // 
            this.customLabelDescMain1.AutoSize = true;
            this.customLabelDescMain1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabelDescMain1.ForeColor = System.Drawing.Color.White;
            this.customLabelDescMain1.Location = new System.Drawing.Point(87, 15);
            this.customLabelDescMain1.Name = "customLabelDescMain1";
            this.customLabelDescMain1.Size = new System.Drawing.Size(128, 16);
            this.customLabelDescMain1.TabIndex = 4;
            this.customLabelDescMain1.Text = "Management Hub";
            // 
            // FrmManageKrypton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(648, 441);
            this.Controls.Add(this.basePanelMain);
            this.Controls.Add(this.basePnl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmManageKrypton";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmManageMain";
            this.basePnl1.ResumeLayout(false);
            this.basePnl2.ResumeLayout(false);
            this.basePanelMain.ResumeLayout(false);
            this.panelMain1.ResumeLayout(false);
            this.panelMain1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain1)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label baselabelMain1;
        protected System.Windows.Forms.Panel panelMain1;
    }
}
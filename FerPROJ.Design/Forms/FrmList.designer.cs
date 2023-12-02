
using FerPROJ.Design.Controls;
using System;
using System.ComponentModel;
using System.Drawing;

namespace FerPROJ.Design.Forms
{
    partial class FrmList
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
        /// 

        private void InitializeComponent() {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmList));
            baseLbl1 = new System.Windows.Forms.Label();
            basePnl1 = new System.Windows.Forms.Panel();
            customLabelDescMain1 = new CLabelDesc();
            SearchTextBox = new CTextBox();
            basePnl2 = new System.Windows.Forms.Panel();
            baseButtonSelect = new CButton();
            baseButtonCancel = new CButton();
            baseDateToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            customLabelDescMain3 = new CLabelDesc();
            baseDateFromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            customLabelDescMain2 = new CLabelDesc();
            PanelMain1 = new System.Windows.Forms.Panel();
            PanelMain4 = new System.Windows.Forms.Panel();
            mainToolStrip = new System.Windows.Forms.ToolStrip();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            tsbMainAddItem = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            tsbMainEditItem = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            tsbMainDeleteItem = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            tsbMainViewItem = new System.Windows.Forms.ToolStripButton();
            tsbMainRefresh = new System.Windows.Forms.ToolStripButton();
            panelMain11 = new System.Windows.Forms.Panel();
            PnlFormList = new System.Windows.Forms.Panel();
            baselabelmain12 = new System.Windows.Forms.Label();
            customLabelDescMain11 = new CLabelDesc();
            pictureBoxMain1 = new System.Windows.Forms.PictureBox();
            customLabelDescMain10 = new CLabelDesc();
            basePnl1.SuspendLayout();
            basePnl2.SuspendLayout();
            PanelMain1.SuspendLayout();
            PanelMain4.SuspendLayout();
            mainToolStrip.SuspendLayout();
            panelMain11.SuspendLayout();
            PnlFormList.SuspendLayout();
            ((ISupportInitialize)pictureBoxMain1).BeginInit();
            SuspendLayout();
            // 
            // baseLbl1
            // 
            baseLbl1.BackColor = Color.DimGray;
            baseLbl1.Dock = System.Windows.Forms.DockStyle.Top;
            baseLbl1.Location = new Point(0, 0);
            baseLbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            baseLbl1.Name = "baseLbl1";
            baseLbl1.Size = new Size(839, 1);
            baseLbl1.TabIndex = 0;
            baseLbl1.Text = "1";
            // 
            // basePnl1
            // 
            basePnl1.BackColor = SystemColors.GradientInactiveCaption;
            basePnl1.Controls.Add(customLabelDescMain1);
            basePnl1.Controls.Add(SearchTextBox);
            basePnl1.Controls.Add(basePnl2);
            basePnl1.Controls.Add(baseLbl1);
            basePnl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            basePnl1.Location = new Point(0, 420);
            basePnl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            basePnl1.Name = "basePnl1";
            basePnl1.Size = new Size(839, 82);
            basePnl1.TabIndex = 1;
            // 
            // customLabelDescMain1
            // 
            customLabelDescMain1.AutoSize = true;
            customLabelDescMain1.Font = new Font("Poppins", 10F);
            customLabelDescMain1.Location = new Point(5, 9);
            customLabelDescMain1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            customLabelDescMain1.Name = "customLabelDescMain1";
            customLabelDescMain1.Size = new Size(64, 25);
            customLabelDescMain1.TabIndex = 3;
            customLabelDescMain1.Text = "Search:";
            // 
            // SearchTextBox
            // 
            SearchTextBox.BackColor = SystemColors.Window;
            SearchTextBox.BorderColor = Color.MediumSlateBlue;
            SearchTextBox.BorderFocusColor = Color.HotPink;
            SearchTextBox.BorderRadius = 15;
            SearchTextBox.BorderSize = 2;
            SearchTextBox.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchTextBox.ForeColor = Color.FromArgb(64, 64, 64);
            SearchTextBox.Location = new Point(88, 30);
            SearchTextBox.Margin = new System.Windows.Forms.Padding(5);
            SearchTextBox.Multiline = false;
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.OnFocus = false;
            SearchTextBox.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            SearchTextBox.PasswordChar = false;
            SearchTextBox.PlaceholderColor = Color.DarkGray;
            SearchTextBox.PlaceholderText = "";
            SearchTextBox.Size = new Size(356, 33);
            SearchTextBox.TabIndex = 1;
            SearchTextBox.TextProperty = null;
            SearchTextBox.Texts = "";
            SearchTextBox.UnderlinedStyle = false;
            SearchTextBox._TextChanged += SearchTextValue__TextChanged;
            // 
            // basePnl2
            // 
            basePnl2.Controls.Add(baseButtonSelect);
            basePnl2.Controls.Add(baseButtonCancel);
            basePnl2.Dock = System.Windows.Forms.DockStyle.Right;
            basePnl2.Location = new Point(557, 1);
            basePnl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            basePnl2.Name = "basePnl2";
            basePnl2.Size = new Size(282, 81);
            basePnl2.TabIndex = 2;
            // 
            // baseButtonSelect
            // 
            baseButtonSelect.BackColor = Color.DodgerBlue;
            baseButtonSelect.BackgroundColor = Color.DodgerBlue;
            baseButtonSelect.BorderColor = Color.Green;
            baseButtonSelect.BorderRadius = 20;
            baseButtonSelect.BorderSize = 0;
            baseButtonSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            baseButtonSelect.FlatAppearance.BorderSize = 0;
            baseButtonSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            baseButtonSelect.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            baseButtonSelect.ForeColor = Color.White;
            baseButtonSelect.Location = new Point(23, 16);
            baseButtonSelect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            baseButtonSelect.Name = "baseButtonSelect";
            baseButtonSelect.Size = new Size(118, 46);
            baseButtonSelect.TabIndex = 0;
            baseButtonSelect.Text = "Select";
            baseButtonSelect.TextColor = Color.White;
            baseButtonSelect.UseVisualStyleBackColor = false;
            baseButtonSelect.Click += baseButtonSelect_Click;
            // 
            // baseButtonCancel
            // 
            baseButtonCancel.BackColor = Color.Crimson;
            baseButtonCancel.BackgroundColor = Color.Crimson;
            baseButtonCancel.BorderColor = Color.Green;
            baseButtonCancel.BorderRadius = 20;
            baseButtonCancel.BorderSize = 0;
            baseButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            baseButtonCancel.FlatAppearance.BorderSize = 0;
            baseButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            baseButtonCancel.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            baseButtonCancel.ForeColor = Color.White;
            baseButtonCancel.Location = new Point(148, 16);
            baseButtonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            baseButtonCancel.Name = "baseButtonCancel";
            baseButtonCancel.Size = new Size(118, 46);
            baseButtonCancel.TabIndex = 1;
            baseButtonCancel.Text = "Cancel";
            baseButtonCancel.TextColor = Color.White;
            baseButtonCancel.UseVisualStyleBackColor = false;
            baseButtonCancel.Click += baseButtonCancel_Click;
            // 
            // baseDateToDateTimePicker
            // 
            baseDateToDateTimePicker.CalendarFont = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            baseDateToDateTimePicker.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            baseDateToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            baseDateToDateTimePicker.Location = new Point(153, 41);
            baseDateToDateTimePicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            baseDateToDateTimePicker.Name = "baseDateToDateTimePicker";
            baseDateToDateTimePicker.Size = new Size(133, 27);
            baseDateToDateTimePicker.TabIndex = 7;
            baseDateToDateTimePicker.ValueChanged += baseDateFromDateTimePicker_ValueChanged;
            // 
            // customLabelDescMain3
            // 
            customLabelDescMain3.AutoSize = true;
            customLabelDescMain3.Font = new Font("Poppins", 10F);
            customLabelDescMain3.ForeColor = Color.White;
            customLabelDescMain3.Location = new Point(153, 9);
            customLabelDescMain3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            customLabelDescMain3.Name = "customLabelDescMain3";
            customLabelDescMain3.Size = new Size(69, 25);
            customLabelDescMain3.TabIndex = 6;
            customLabelDescMain3.Text = "Date To:";
            // 
            // baseDateFromDateTimePicker
            // 
            baseDateFromDateTimePicker.CalendarFont = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            baseDateFromDateTimePicker.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            baseDateFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            baseDateFromDateTimePicker.Location = new Point(10, 41);
            baseDateFromDateTimePicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            baseDateFromDateTimePicker.Name = "baseDateFromDateTimePicker";
            baseDateFromDateTimePicker.Size = new Size(126, 27);
            baseDateFromDateTimePicker.TabIndex = 5;
            baseDateFromDateTimePicker.ValueChanged += baseDateFromDateTimePicker_ValueChanged;
            // 
            // customLabelDescMain2
            // 
            customLabelDescMain2.AutoSize = true;
            customLabelDescMain2.Font = new Font("Poppins", 10F);
            customLabelDescMain2.ForeColor = Color.White;
            customLabelDescMain2.Location = new Point(10, 9);
            customLabelDescMain2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            customLabelDescMain2.Name = "customLabelDescMain2";
            customLabelDescMain2.Size = new Size(87, 25);
            customLabelDescMain2.TabIndex = 4;
            customLabelDescMain2.Text = "Date From:";
            // 
            // PanelMain1
            // 
            PanelMain1.Controls.Add(PanelMain4);
            PanelMain1.Controls.Add(panelMain11);
            PanelMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            PanelMain1.Location = new Point(8, 8);
            PanelMain1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PanelMain1.Name = "PanelMain1";
            PanelMain1.Size = new Size(839, 586);
            PanelMain1.TabIndex = 2;
            // 
            // PanelMain4
            // 
            PanelMain4.BackColor = SystemColors.ButtonFace;
            PanelMain4.Controls.Add(mainToolStrip);
            PanelMain4.Controls.Add(basePnl1);
            PanelMain4.Dock = System.Windows.Forms.DockStyle.Fill;
            PanelMain4.Location = new Point(0, 84);
            PanelMain4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PanelMain4.Name = "PanelMain4";
            PanelMain4.Size = new Size(839, 502);
            PanelMain4.TabIndex = 1;
            // 
            // mainToolStrip
            // 
            mainToolStrip.AutoSize = false;
            mainToolStrip.BackColor = SystemColors.ButtonFace;
            mainToolStrip.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripSeparator4, tsbMainAddItem, toolStripSeparator1, tsbMainEditItem, toolStripSeparator2, tsbMainDeleteItem, toolStripSeparator3, tsbMainViewItem, tsbMainRefresh });
            mainToolStrip.Location = new Point(0, 0);
            mainToolStrip.Name = "mainToolStrip";
            mainToolStrip.Padding = new System.Windows.Forms.Padding(0);
            mainToolStrip.Size = new Size(839, 47);
            mainToolStrip.TabIndex = 4;
            mainToolStrip.Text = "toolStrip1";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 47);
            // 
            // tsbMainAddItem
            // 
            tsbMainAddItem.Image = (Image)resources.GetObject("tsbMainAddItem.Image");
            tsbMainAddItem.ImageTransparentColor = Color.Magenta;
            tsbMainAddItem.Name = "tsbMainAddItem";
            tsbMainAddItem.Size = new Size(83, 44);
            tsbMainAddItem.Text = "Add Item";
            tsbMainAddItem.Click += tsbMainAddItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 47);
            // 
            // tsbMainEditItem
            // 
            tsbMainEditItem.Image = (Image)resources.GetObject("tsbMainEditItem.Image");
            tsbMainEditItem.ImageTransparentColor = Color.Magenta;
            tsbMainEditItem.Name = "tsbMainEditItem";
            tsbMainEditItem.Size = new Size(80, 44);
            tsbMainEditItem.Text = "Edit Item";
            tsbMainEditItem.Click += tsbMainEditItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 47);
            // 
            // tsbMainDeleteItem
            // 
            tsbMainDeleteItem.Image = (Image)resources.GetObject("tsbMainDeleteItem.Image");
            tsbMainDeleteItem.ImageTransparentColor = Color.Magenta;
            tsbMainDeleteItem.Name = "tsbMainDeleteItem";
            tsbMainDeleteItem.Size = new Size(95, 44);
            tsbMainDeleteItem.Text = "Delete Item";
            tsbMainDeleteItem.Click += tsbMainDeleteItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 47);
            // 
            // tsbMainViewItem
            // 
            tsbMainViewItem.Image = (Image)resources.GetObject("tsbMainViewItem.Image");
            tsbMainViewItem.ImageTransparentColor = Color.Magenta;
            tsbMainViewItem.Name = "tsbMainViewItem";
            tsbMainViewItem.Size = new Size(87, 44);
            tsbMainViewItem.Text = "View Item";
            tsbMainViewItem.Click += tsbMainViewItem_Click;
            // 
            // tsbMainRefresh
            // 
            tsbMainRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tsbMainRefresh.Image = (Image)resources.GetObject("tsbMainRefresh.Image");
            tsbMainRefresh.ImageTransparentColor = Color.Magenta;
            tsbMainRefresh.Name = "tsbMainRefresh";
            tsbMainRefresh.Size = new Size(79, 44);
            tsbMainRefresh.Text = "Resfresh";
            tsbMainRefresh.Click += tsbMainRefresh_Click;
            // 
            // panelMain11
            // 
            panelMain11.BackColor = Color.DodgerBlue;
            panelMain11.Controls.Add(PnlFormList);
            panelMain11.Controls.Add(baselabelmain12);
            panelMain11.Controls.Add(customLabelDescMain11);
            panelMain11.Controls.Add(pictureBoxMain1);
            panelMain11.Controls.Add(customLabelDescMain10);
            panelMain11.Dock = System.Windows.Forms.DockStyle.Top;
            panelMain11.Location = new Point(0, 0);
            panelMain11.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelMain11.Name = "panelMain11";
            panelMain11.Size = new Size(839, 84);
            panelMain11.TabIndex = 3;
            // 
            // PnlFormList
            // 
            PnlFormList.Controls.Add(baseDateToDateTimePicker);
            PnlFormList.Controls.Add(customLabelDescMain2);
            PnlFormList.Controls.Add(baseDateFromDateTimePicker);
            PnlFormList.Controls.Add(customLabelDescMain3);
            PnlFormList.Dock = System.Windows.Forms.DockStyle.Right;
            PnlFormList.Location = new Point(541, 0);
            PnlFormList.Name = "PnlFormList";
            PnlFormList.Size = new Size(298, 83);
            PnlFormList.TabIndex = 4;
            // 
            // baselabelmain12
            // 
            baselabelmain12.BackColor = Color.DimGray;
            baselabelmain12.Dock = System.Windows.Forms.DockStyle.Bottom;
            baselabelmain12.Location = new Point(0, 83);
            baselabelmain12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            baselabelmain12.Name = "baselabelmain12";
            baselabelmain12.Size = new Size(839, 1);
            baselabelmain12.TabIndex = 3;
            baselabelmain12.Text = "1";
            // 
            // customLabelDescMain11
            // 
            customLabelDescMain11.AutoSize = true;
            customLabelDescMain11.Font = new Font("Poppins", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            customLabelDescMain11.ForeColor = Color.White;
            customLabelDescMain11.Location = new Point(120, 45);
            customLabelDescMain11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            customLabelDescMain11.Name = "customLabelDescMain11";
            customLabelDescMain11.Size = new Size(364, 23);
            customLabelDescMain11.TabIndex = 2;
            customLabelDescMain11.Text = "Centralized control and insights for efficient operations.";
            // 
            // pictureBoxMain1
            // 
            pictureBoxMain1.BackgroundImage = Properties.Resources.Hopstarter_Button_Button_Info_64;
            pictureBoxMain1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBoxMain1.Location = new Point(23, 13);
            pictureBoxMain1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBoxMain1.Name = "pictureBoxMain1";
            pictureBoxMain1.Size = new Size(70, 58);
            pictureBoxMain1.TabIndex = 0;
            pictureBoxMain1.TabStop = false;
            // 
            // customLabelDescMain10
            // 
            customLabelDescMain10.AutoSize = true;
            customLabelDescMain10.Font = new Font("Poppins SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customLabelDescMain10.ForeColor = Color.White;
            customLabelDescMain10.Location = new Point(100, 16);
            customLabelDescMain10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            customLabelDescMain10.Name = "customLabelDescMain10";
            customLabelDescMain10.Size = new Size(132, 23);
            customLabelDescMain10.TabIndex = 1;
            customLabelDescMain10.Text = "Management Hub";
            // 
            // FrmList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = Color.DodgerBlue;
            ClientSize = new Size(855, 602);
            Controls.Add(PanelMain1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmList";
            Padding = new System.Windows.Forms.Padding(8);
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FrmListMain";
            Load += FrmListMain_Load;
            basePnl1.ResumeLayout(false);
            basePnl1.PerformLayout();
            basePnl2.ResumeLayout(false);
            PanelMain1.ResumeLayout(false);
            PanelMain4.ResumeLayout(false);
            mainToolStrip.ResumeLayout(false);
            mainToolStrip.PerformLayout();
            panelMain11.ResumeLayout(false);
            panelMain11.PerformLayout();
            PnlFormList.ResumeLayout(false);
            PnlFormList.PerformLayout();
            ((ISupportInitialize)pictureBoxMain1).EndInit();
            ResumeLayout(false);
        }

        #endregion


        private System.Windows.Forms.Label baseLbl1;
        private System.Windows.Forms.Panel basePnl1;
        private System.Windows.Forms.Panel basePnl2;
        protected CButton baseButtonSelect;
        protected CButton baseButtonCancel;
        private System.Windows.Forms.Panel PanelMain1;
        protected System.Windows.Forms.Panel PanelMain4;
        private Controls.CLabelDesc customLabelDescMain11;
        private Controls.CLabelDesc customLabelDescMain10;
        private System.Windows.Forms.PictureBox pictureBoxMain1;
        private Controls.CLabelDesc customLabelDescMain1;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        protected System.Windows.Forms.ToolStripButton tsbMainAddItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        protected System.Windows.Forms.ToolStripButton tsbMainEditItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        protected System.Windows.Forms.ToolStripButton tsbMainDeleteItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        protected System.Windows.Forms.ToolStripButton tsbMainViewItem;
        protected System.Windows.Forms.ToolStripButton tsbMainRefresh;
        protected CTextBox SearchTextBox;
        private System.Windows.Forms.Panel panelMain11;
        private System.Windows.Forms.Label baselabelmain12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.DateTimePicker baseDateToDateTimePicker;
        private Controls.CLabelDesc customLabelDescMain3;
        private System.Windows.Forms.DateTimePicker baseDateFromDateTimePicker;
        private Controls.CLabelDesc customLabelDescMain2;
        private System.Windows.Forms.Panel PnlFormList;
    }
}
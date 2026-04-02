namespace FerPROJ.Design.Forms {
    partial class FrmReportFilter {
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
            this.cDateTimePickerKryptonDateFrom = new FerPROJ.Design.Controls.CDateTimePickerKrypton();
            this.cDateTimePickerKryptonDateTo = new FerPROJ.Design.Controls.CDateTimePickerKrypton();
            this.searchFromKryptonLabel = new Krypton.Toolkit.KryptonLabel();
            this.searchToKryptonLabel = new Krypton.Toolkit.KryptonLabel();
            this.basePnl2.SuspendLayout();
            this.PanelMain3.SuspendLayout();
            this.SuspendLayout();
            // 
            // basePnl2
            // 
            this.basePnl2.Location = new System.Drawing.Point(107, 1);
            // 
            // baseButtonUpdate
            // 
            this.baseButtonUpdate.FlatAppearance.BorderSize = 0;
            // 
            // baseButtonSave
            // 
            this.baseButtonSave.FlatAppearance.BorderSize = 0;
            this.baseButtonSave.Text = "OK";
            // 
            // baseButtonCancel
            // 
            this.baseButtonCancel.FlatAppearance.BorderSize = 0;
            // 
            // PanelMain3
            // 
            this.PanelMain3.Controls.Add(this.searchToKryptonLabel);
            this.PanelMain3.Controls.Add(this.searchFromKryptonLabel);
            this.PanelMain3.Controls.Add(this.cDateTimePickerKryptonDateTo);
            this.PanelMain3.Controls.Add(this.cDateTimePickerKryptonDateFrom);
            this.PanelMain3.Location = new System.Drawing.Point(0, 0);
            this.PanelMain3.Size = new System.Drawing.Size(342, 186);
            // 
            // baseButtonAddNew
            // 
            this.baseButtonAddNew.FlatAppearance.BorderSize = 0;
            // 
            // cDateTimePickerKryptonDateFrom
            // 
            this.cDateTimePickerKryptonDateFrom.Location = new System.Drawing.Point(31, 49);
            this.cDateTimePickerKryptonDateFrom.Name = "cDateTimePickerKryptonDateFrom";
            this.cDateTimePickerKryptonDateFrom.Size = new System.Drawing.Size(280, 27);
            this.cDateTimePickerKryptonDateFrom.StateActive.Border.Color1 = System.Drawing.Color.DarkGray;
            this.cDateTimePickerKryptonDateFrom.StateActive.Border.Color2 = System.Drawing.Color.White;
            this.cDateTimePickerKryptonDateFrom.StateActive.Border.Rounding = 10F;
            this.cDateTimePickerKryptonDateFrom.StateActive.Content.Color1 = System.Drawing.Color.Black;
            this.cDateTimePickerKryptonDateFrom.StateCommon.Border.Color1 = System.Drawing.Color.DarkGray;
            this.cDateTimePickerKryptonDateFrom.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.cDateTimePickerKryptonDateFrom.StateCommon.Border.Rounding = 10F;
            this.cDateTimePickerKryptonDateFrom.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.cDateTimePickerKryptonDateFrom.StateNormal.Border.Color1 = System.Drawing.Color.DarkGray;
            this.cDateTimePickerKryptonDateFrom.StateNormal.Border.Color2 = System.Drawing.Color.White;
            this.cDateTimePickerKryptonDateFrom.TabIndex = 0;
            // 
            // cDateTimePickerKryptonDateTo
            // 
            this.cDateTimePickerKryptonDateTo.Location = new System.Drawing.Point(31, 132);
            this.cDateTimePickerKryptonDateTo.Name = "cDateTimePickerKryptonDateTo";
            this.cDateTimePickerKryptonDateTo.Size = new System.Drawing.Size(280, 27);
            this.cDateTimePickerKryptonDateTo.StateActive.Border.Color1 = System.Drawing.Color.DarkGray;
            this.cDateTimePickerKryptonDateTo.StateActive.Border.Color2 = System.Drawing.Color.White;
            this.cDateTimePickerKryptonDateTo.StateActive.Border.Rounding = 10F;
            this.cDateTimePickerKryptonDateTo.StateActive.Content.Color1 = System.Drawing.Color.Black;
            this.cDateTimePickerKryptonDateTo.StateCommon.Border.Color1 = System.Drawing.Color.DarkGray;
            this.cDateTimePickerKryptonDateTo.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.cDateTimePickerKryptonDateTo.StateCommon.Border.Rounding = 10F;
            this.cDateTimePickerKryptonDateTo.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.cDateTimePickerKryptonDateTo.StateNormal.Border.Color1 = System.Drawing.Color.DarkGray;
            this.cDateTimePickerKryptonDateTo.StateNormal.Border.Color2 = System.Drawing.Color.White;
            this.cDateTimePickerKryptonDateTo.TabIndex = 1;
            // 
            // searchFromKryptonLabel
            // 
            this.searchFromKryptonLabel.Location = new System.Drawing.Point(31, 18);
            this.searchFromKryptonLabel.Name = "searchFromKryptonLabel";
            this.searchFromKryptonLabel.Size = new System.Drawing.Size(99, 25);
            this.searchFromKryptonLabel.StateCommon.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchFromKryptonLabel.TabIndex = 2;
            this.searchFromKryptonLabel.Values.Text = "Date From:";
            // 
            // searchToKryptonLabel
            // 
            this.searchToKryptonLabel.Location = new System.Drawing.Point(31, 101);
            this.searchToKryptonLabel.Name = "searchToKryptonLabel";
            this.searchToKryptonLabel.Size = new System.Drawing.Size(99, 25);
            this.searchToKryptonLabel.StateCommon.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchToKryptonLabel.TabIndex = 3;
            this.searchToKryptonLabel.Values.Text = "Date To:";
            // 
            // FrmReportFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 271);
            this.CurrentFormMode = FerPROJ.Design.Class.CBaseEnums.FormMode.Add;
            this.HideHeader = true;
            this.HideSaveNew = true;
            this.Name = "FrmReportFilter";
            this.OnSaveName = "OK";
            this.StateCommon.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Back.Color2 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Header.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Header.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.Text = "FrmReportFilter";
            this.basePnl2.ResumeLayout(false);
            this.PanelMain3.ResumeLayout(false);
            this.PanelMain3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CDateTimePickerKrypton cDateTimePickerKryptonDateFrom;
        private Krypton.Toolkit.KryptonLabel searchFromKryptonLabel;
        private Controls.CDateTimePickerKrypton cDateTimePickerKryptonDateTo;
        private Krypton.Toolkit.KryptonLabel searchToKryptonLabel;
    }
}
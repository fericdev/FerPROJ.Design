namespace FerPROJ.Design.Forms {
    partial class FrmSystemSettings {
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
            this.applicationIdCTextBoxKrypton = new FerPROJ.Design.Controls.CTextBoxKrypton();
            this.cLabelDesc1 = new FerPROJ.Design.Controls.CLabelDesc();
            this.basePnl2.SuspendLayout();
            this.PanelMain3.SuspendLayout();
            this.SuspendLayout();
            // 
            // basePnl2
            // 
            this.basePnl2.Location = new System.Drawing.Point(263, 1);
            // 
            // baseButtonUpdate
            // 
            this.baseButtonUpdate.FlatAppearance.BorderSize = 0;
            // 
            // baseButtonSave
            // 
            this.baseButtonSave.FlatAppearance.BorderSize = 0;
            // 
            // baseButtonCancel
            // 
            this.baseButtonCancel.FlatAppearance.BorderSize = 0;
            // 
            // PanelMain3
            // 
            this.PanelMain3.Controls.Add(this.cLabelDesc1);
            this.PanelMain3.Controls.Add(this.applicationIdCTextBoxKrypton);
            this.PanelMain3.Size = new System.Drawing.Size(498, 91);
            // 
            // baseButtonAddNew
            // 
            this.baseButtonAddNew.FlatAppearance.BorderSize = 0;
            // 
            // panelMain1
            // 
            this.panelMain1.Size = new System.Drawing.Size(498, 73);
            // 
            // applicationIdCTextBoxKrypton
            // 
            this.applicationIdCTextBoxKrypton.Location = new System.Drawing.Point(31, 42);
            this.applicationIdCTextBoxKrypton.Name = "applicationIdCTextBoxKrypton";
            this.applicationIdCTextBoxKrypton.Size = new System.Drawing.Size(428, 29);
            this.applicationIdCTextBoxKrypton.StateActive.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.applicationIdCTextBoxKrypton.StateActive.Border.Color1 = System.Drawing.Color.DarkGray;
            this.applicationIdCTextBoxKrypton.StateActive.Border.Color2 = System.Drawing.Color.White;
            this.applicationIdCTextBoxKrypton.StateActive.Border.Rounding = 10F;
            this.applicationIdCTextBoxKrypton.StateActive.Content.Color1 = System.Drawing.Color.Black;
            this.applicationIdCTextBoxKrypton.StateCommon.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.applicationIdCTextBoxKrypton.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.applicationIdCTextBoxKrypton.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.applicationIdCTextBoxKrypton.StateCommon.Border.Rounding = 10F;
            this.applicationIdCTextBoxKrypton.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.applicationIdCTextBoxKrypton.StateDisabled.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.applicationIdCTextBoxKrypton.StateDisabled.Border.Color1 = System.Drawing.Color.White;
            this.applicationIdCTextBoxKrypton.StateDisabled.Border.Color2 = System.Drawing.Color.White;
            this.applicationIdCTextBoxKrypton.StateDisabled.Border.Rounding = 10F;
            this.applicationIdCTextBoxKrypton.StateDisabled.Content.Color1 = System.Drawing.Color.Black;
            this.applicationIdCTextBoxKrypton.StateNormal.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.applicationIdCTextBoxKrypton.StateNormal.Border.Color1 = System.Drawing.Color.White;
            this.applicationIdCTextBoxKrypton.StateNormal.Border.Color2 = System.Drawing.Color.White;
            this.applicationIdCTextBoxKrypton.StateNormal.Border.Rounding = 10F;
            this.applicationIdCTextBoxKrypton.StateNormal.Content.Color1 = System.Drawing.Color.Black;
            this.applicationIdCTextBoxKrypton.TabIndex = 0;
            this.applicationIdCTextBoxKrypton.Text = "cTextBoxKrypton1";
            // 
            // cLabelDesc1
            // 
            this.cLabelDesc1.AutoSize = true;
            this.cLabelDesc1.Font = new System.Drawing.Font("Poppins", 10F);
            this.cLabelDesc1.Location = new System.Drawing.Point(26, 14);
            this.cLabelDesc1.Name = "cLabelDesc1";
            this.cLabelDesc1.Size = new System.Drawing.Size(109, 25);
            this.cLabelDesc1.TabIndex = 1;
            this.cLabelDesc1.Text = "Application ID:";
            // 
            // FrmSystemSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 249);
            this.CurrentFormMode = FerPROJ.Design.Class.CBaseEnums.FormMode.Add;
            this.Name = "FrmSystemSettings";
            this.StateCommon.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Back.Color2 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Header.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Header.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.Text = "FrmSystemSettings";
            this.basePnl2.ResumeLayout(false);
            this.PanelMain3.ResumeLayout(false);
            this.PanelMain3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CTextBoxKrypton applicationIdCTextBoxKrypton;
        private Controls.CLabelDesc cLabelDesc1;
    }
}
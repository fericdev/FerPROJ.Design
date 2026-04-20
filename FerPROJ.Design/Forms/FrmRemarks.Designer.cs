namespace FerPROJ.Design.Forms {
    partial class FrmRemarks {
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
            System.Windows.Forms.Label remarksLabel;
            System.Windows.Forms.Label formIdLabel;
            this.remarksCTextBoxKrypton = new FerPROJ.Design.Controls.CTextBoxKrypton();
            this.formIdCTextBoxKrypton = new FerPROJ.Design.Controls.CTextBoxKrypton();
            this.baseRemarksModelBindingSource = new System.Windows.Forms.BindingSource();
            remarksLabel = new System.Windows.Forms.Label();
            formIdLabel = new System.Windows.Forms.Label();
            this.basePnl2.SuspendLayout();
            this.PanelMain3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseRemarksModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // basePnl2
            // 
            this.basePnl2.Location = new System.Drawing.Point(199, 1);
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
            this.PanelMain3.Controls.Add(remarksLabel);
            this.PanelMain3.Controls.Add(this.remarksCTextBoxKrypton);
            this.PanelMain3.Controls.Add(formIdLabel);
            this.PanelMain3.Controls.Add(this.formIdCTextBoxKrypton);
            this.PanelMain3.Size = new System.Drawing.Size(434, 205);
            // 
            // baseButtonAddNew
            // 
            this.baseButtonAddNew.FlatAppearance.BorderSize = 0;
            // 
            // panelMain1
            // 
            this.panelMain1.Size = new System.Drawing.Size(434, 73);
            // 
            // remarksLabel
            // 
            remarksLabel.AutoSize = true;
            remarksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            remarksLabel.Location = new System.Drawing.Point(17, 70);
            remarksLabel.Name = "remarksLabel";
            remarksLabel.Size = new System.Drawing.Size(77, 20);
            remarksLabel.TabIndex = 14;
            remarksLabel.Text = "Remarks:";
            // 
            // formIdLabel
            // 
            formIdLabel.AutoSize = true;
            formIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            formIdLabel.Location = new System.Drawing.Point(17, 3);
            formIdLabel.Name = "formIdLabel";
            formIdLabel.Size = new System.Drawing.Size(68, 20);
            formIdLabel.TabIndex = 12;
            formIdLabel.Text = "Form Id:";
            // 
            // remarksCTextBoxKrypton
            // 
            this.remarksCTextBoxKrypton.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.baseRemarksModelBindingSource, "Remarks", true));
            this.remarksCTextBoxKrypton.Location = new System.Drawing.Point(20, 96);
            this.remarksCTextBoxKrypton.Multiline = true;
            this.remarksCTextBoxKrypton.Name = "remarksCTextBoxKrypton";
            this.remarksCTextBoxKrypton.Size = new System.Drawing.Size(395, 87);
            this.remarksCTextBoxKrypton.StateActive.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.remarksCTextBoxKrypton.StateActive.Border.Color1 = System.Drawing.Color.DarkGray;
            this.remarksCTextBoxKrypton.StateActive.Border.Color2 = System.Drawing.Color.White;
            this.remarksCTextBoxKrypton.StateActive.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.remarksCTextBoxKrypton.StateActive.Border.Rounding = 10F;
            this.remarksCTextBoxKrypton.StateActive.Content.Color1 = System.Drawing.Color.Black;
            this.remarksCTextBoxKrypton.StateCommon.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.remarksCTextBoxKrypton.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.remarksCTextBoxKrypton.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.remarksCTextBoxKrypton.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.remarksCTextBoxKrypton.StateCommon.Border.Rounding = 10F;
            this.remarksCTextBoxKrypton.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.remarksCTextBoxKrypton.StateDisabled.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.remarksCTextBoxKrypton.StateDisabled.Border.Color1 = System.Drawing.Color.White;
            this.remarksCTextBoxKrypton.StateDisabled.Border.Color2 = System.Drawing.Color.White;
            this.remarksCTextBoxKrypton.StateDisabled.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.remarksCTextBoxKrypton.StateDisabled.Border.Rounding = 10F;
            this.remarksCTextBoxKrypton.StateDisabled.Content.Color1 = System.Drawing.Color.Black;
            this.remarksCTextBoxKrypton.StateNormal.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.remarksCTextBoxKrypton.StateNormal.Border.Color1 = System.Drawing.Color.White;
            this.remarksCTextBoxKrypton.StateNormal.Border.Color2 = System.Drawing.Color.White;
            this.remarksCTextBoxKrypton.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.remarksCTextBoxKrypton.StateNormal.Border.Rounding = 10F;
            this.remarksCTextBoxKrypton.StateNormal.Content.Color1 = System.Drawing.Color.Black;
            this.remarksCTextBoxKrypton.TabIndex = 15;
            this.remarksCTextBoxKrypton.Text = "cTextBoxKrypton1";
            // 
            // formIdCTextBoxKrypton
            // 
            this.formIdCTextBoxKrypton.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.baseRemarksModelBindingSource, "FormId", true));
            this.formIdCTextBoxKrypton.Location = new System.Drawing.Point(21, 26);
            this.formIdCTextBoxKrypton.Name = "formIdCTextBoxKrypton";
            this.formIdCTextBoxKrypton.ReadOnly = true;
            this.formIdCTextBoxKrypton.Size = new System.Drawing.Size(394, 29);
            this.formIdCTextBoxKrypton.StateActive.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.formIdCTextBoxKrypton.StateActive.Border.Color1 = System.Drawing.Color.DarkGray;
            this.formIdCTextBoxKrypton.StateActive.Border.Color2 = System.Drawing.Color.White;
            this.formIdCTextBoxKrypton.StateActive.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.formIdCTextBoxKrypton.StateActive.Border.Rounding = 10F;
            this.formIdCTextBoxKrypton.StateActive.Content.Color1 = System.Drawing.Color.Black;
            this.formIdCTextBoxKrypton.StateCommon.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.formIdCTextBoxKrypton.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.formIdCTextBoxKrypton.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.formIdCTextBoxKrypton.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.formIdCTextBoxKrypton.StateCommon.Border.Rounding = 10F;
            this.formIdCTextBoxKrypton.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.formIdCTextBoxKrypton.StateDisabled.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.formIdCTextBoxKrypton.StateDisabled.Border.Color1 = System.Drawing.Color.White;
            this.formIdCTextBoxKrypton.StateDisabled.Border.Color2 = System.Drawing.Color.White;
            this.formIdCTextBoxKrypton.StateDisabled.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.formIdCTextBoxKrypton.StateDisabled.Border.Rounding = 10F;
            this.formIdCTextBoxKrypton.StateDisabled.Content.Color1 = System.Drawing.Color.Black;
            this.formIdCTextBoxKrypton.StateNormal.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.formIdCTextBoxKrypton.StateNormal.Border.Color1 = System.Drawing.Color.White;
            this.formIdCTextBoxKrypton.StateNormal.Border.Color2 = System.Drawing.Color.White;
            this.formIdCTextBoxKrypton.StateNormal.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.formIdCTextBoxKrypton.StateNormal.Border.Rounding = 10F;
            this.formIdCTextBoxKrypton.StateNormal.Content.Color1 = System.Drawing.Color.Black;
            this.formIdCTextBoxKrypton.TabIndex = 13;
            this.formIdCTextBoxKrypton.Text = "cTextBoxKrypton1";
            // 
            // baseRemarksModelBindingSource
            // 
            this.baseRemarksModelBindingSource.DataSource = typeof(FerPROJ.Design.BaseModels.RemarksModel);
            // 
            // FrmRemarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 363);
            this.CurrentFormMode = FerPROJ.Design.Class.CBaseEnums.FormMode.Add;
            this.Name = "FrmRemarks";
            this.StateCommon.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Back.Color2 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Header.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Header.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.Text = "FrmRemarks";
            this.basePnl2.ResumeLayout(false);
            this.PanelMain3.ResumeLayout(false);
            this.PanelMain3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseRemarksModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CTextBoxKrypton remarksCTextBoxKrypton;
        private Controls.CTextBoxKrypton formIdCTextBoxKrypton;
        private System.Windows.Forms.BindingSource baseRemarksModelBindingSource;
    }
}
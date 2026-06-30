namespace FerPROJ.Design.Forms {
    partial class FrmCamera {
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
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.cameraSourceCComboBoxKrypton = new FerPROJ.Design.Controls.CComboBoxKrypton();
            this.cLabelDesc1 = new FerPROJ.Design.Controls.CLabelDesc();
            this.basePnl2.SuspendLayout();
            this.PanelMain3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraSourceCComboBoxKrypton)).BeginInit();
            this.SuspendLayout();
            // 
            // basePnl2
            // 
            this.basePnl2.Location = new System.Drawing.Point(491, 1);
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
            this.PanelMain3.Controls.Add(this.cameraSourceCComboBoxKrypton);
            this.PanelMain3.Controls.Add(this.pictureBoxImage);
            this.PanelMain3.Location = new System.Drawing.Point(0, 0);
            this.PanelMain3.Size = new System.Drawing.Size(726, 552);
            // 
            // baseButtonAddNew
            // 
            this.baseButtonAddNew.FlatAppearance.BorderSize = 0;
            this.baseButtonAddNew.Text = "Select Image";
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxImage.Location = new System.Drawing.Point(0, 62);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(726, 490);
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            // 
            // cameraSourceCComboBoxKrypton
            // 
            this.cameraSourceCComboBoxKrypton.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cameraSourceCComboBoxKrypton.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cameraSourceCComboBoxKrypton.DropDownWidth = 680;
            this.cameraSourceCComboBoxKrypton.Location = new System.Drawing.Point(21, 28);
            this.cameraSourceCComboBoxKrypton.Name = "cameraSourceCComboBoxKrypton";
            this.cameraSourceCComboBoxKrypton.Size = new System.Drawing.Size(686, 28);
            this.cameraSourceCComboBoxKrypton.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.DarkGray;
            this.cameraSourceCComboBoxKrypton.StateActive.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.cameraSourceCComboBoxKrypton.StateActive.ComboBox.Border.Rounding = 10F;
            this.cameraSourceCComboBoxKrypton.StateActive.ComboBox.Content.Color1 = System.Drawing.Color.Black;
            this.cameraSourceCComboBoxKrypton.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cameraSourceCComboBoxKrypton.StateDisabled.ComboBox.Border.Color1 = System.Drawing.Color.DarkGray;
            this.cameraSourceCComboBoxKrypton.StateDisabled.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.cameraSourceCComboBoxKrypton.StateDisabled.ComboBox.Border.Rounding = 10F;
            this.cameraSourceCComboBoxKrypton.StateDisabled.ComboBox.Content.Color1 = System.Drawing.Color.Black;
            this.cameraSourceCComboBoxKrypton.TabIndex = 1;
            this.cameraSourceCComboBoxKrypton.Text = "cComboBoxKrypton1";
            // 
            // cLabelDesc1
            // 
            this.cLabelDesc1.AutoSize = true;
            this.cLabelDesc1.Font = new System.Drawing.Font("Poppins", 10F);
            this.cLabelDesc1.Location = new System.Drawing.Point(16, 0);
            this.cLabelDesc1.Name = "cLabelDesc1";
            this.cLabelDesc1.Size = new System.Drawing.Size(172, 25);
            this.cLabelDesc1.TabIndex = 2;
            this.cLabelDesc1.Text = "Select Camera Source:";
            // 
            // FrmCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 637);
            this.CurrentFormMode = FerPROJ.Design.Class.CBaseEnums.FormMode.Add;
            this.HideHeader = true;
            this.HideSaveNewOnUpdate = false;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "FrmCamera";
            this.OnSaveNewName = "Select Image";
            this.StateCommon.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Back.Color2 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Header.Border.Color1 = System.Drawing.Color.RoyalBlue;
            this.StateCommon.Header.Border.Color2 = System.Drawing.Color.RoyalBlue;
            this.Text = "Camera";
            this.basePnl2.ResumeLayout(false);
            this.PanelMain3.ResumeLayout(false);
            this.PanelMain3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraSourceCComboBoxKrypton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private Controls.CLabelDesc cLabelDesc1;
        private Controls.CComboBoxKrypton cameraSourceCComboBoxKrypton;
    }
}
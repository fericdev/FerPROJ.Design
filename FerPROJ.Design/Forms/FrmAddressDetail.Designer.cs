namespace FerPROJ.Design.Forms {
    partial class FrmAddressDetail {
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
            System.Windows.Forms.Label provinceLabel;
            System.Windows.Forms.Label purokLabel;
            System.Windows.Forms.Label typeLabel;
            System.Windows.Forms.Label zipCodeLabel;
            System.Windows.Forms.Label barangayLabel;
            System.Windows.Forms.Label cityLabel;
            System.Windows.Forms.Label regionLabel;
            System.Windows.Forms.Label countryLabel;
            System.Windows.Forms.Label label1;
            this.purokCComboBoxKrypton = new FerPROJ.Design.Controls.CComboBoxKrypton();
            this.baseAddressDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.provinceCComboBoxKrypton = new FerPROJ.Design.Controls.CComboBoxKrypton();
            this.typeCComboBoxKrypton = new FerPROJ.Design.Controls.CComboBoxKrypton();
            this.zipCodeCTextBoxKrypton = new FerPROJ.Design.Controls.CTextBoxKrypton();
            this.barangayCComboBoxKrypton = new FerPROJ.Design.Controls.CComboBoxKrypton();
            this.cityCComboBoxKrypton = new FerPROJ.Design.Controls.CComboBoxKrypton();
            this.regionCComboBoxKrypton = new FerPROJ.Design.Controls.CComboBoxKrypton();
            this.countryCComboBoxKrypton = new FerPROJ.Design.Controls.CComboBoxKrypton();
            this.remarksCTextBoxKrypton = new FerPROJ.Design.Controls.CTextBoxKrypton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            provinceLabel = new System.Windows.Forms.Label();
            purokLabel = new System.Windows.Forms.Label();
            typeLabel = new System.Windows.Forms.Label();
            zipCodeLabel = new System.Windows.Forms.Label();
            barangayLabel = new System.Windows.Forms.Label();
            cityLabel = new System.Windows.Forms.Label();
            regionLabel = new System.Windows.Forms.Label();
            countryLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.basePnl2.SuspendLayout();
            this.PanelMain3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.purokCComboBoxKrypton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseAddressDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinceCComboBoxKrypton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeCComboBoxKrypton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barangayCComboBoxKrypton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityCComboBoxKrypton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionCComboBoxKrypton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryCComboBoxKrypton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // basePnl2
            // 
            this.basePnl2.Location = new System.Drawing.Point(579, 1);
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
            this.PanelMain3.Controls.Add(label1);
            this.PanelMain3.Controls.Add(this.remarksCTextBoxKrypton);
            this.PanelMain3.Controls.Add(this.purokCComboBoxKrypton);
            this.PanelMain3.Controls.Add(provinceLabel);
            this.PanelMain3.Controls.Add(this.provinceCComboBoxKrypton);
            this.PanelMain3.Controls.Add(purokLabel);
            this.PanelMain3.Controls.Add(typeLabel);
            this.PanelMain3.Controls.Add(this.typeCComboBoxKrypton);
            this.PanelMain3.Controls.Add(zipCodeLabel);
            this.PanelMain3.Controls.Add(this.zipCodeCTextBoxKrypton);
            this.PanelMain3.Controls.Add(barangayLabel);
            this.PanelMain3.Controls.Add(this.barangayCComboBoxKrypton);
            this.PanelMain3.Controls.Add(cityLabel);
            this.PanelMain3.Controls.Add(this.cityCComboBoxKrypton);
            this.PanelMain3.Controls.Add(regionLabel);
            this.PanelMain3.Controls.Add(this.regionCComboBoxKrypton);
            this.PanelMain3.Controls.Add(countryLabel);
            this.PanelMain3.Controls.Add(this.countryCComboBoxKrypton);
            this.PanelMain3.Size = new System.Drawing.Size(814, 287);
            // 
            // baseButtonAddNew
            // 
            this.baseButtonAddNew.FlatAppearance.BorderSize = 0;
            // 
            // panelMain1
            // 
            this.panelMain1.Size = new System.Drawing.Size(814, 73);
            // 
            // provinceLabel
            // 
            provinceLabel.AutoSize = true;
            provinceLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            provinceLabel.Location = new System.Drawing.Point(17, 74);
            provinceLabel.Name = "provinceLabel";
            provinceLabel.Size = new System.Drawing.Size(75, 19);
            provinceLabel.TabIndex = 30;
            provinceLabel.Text = "Province:";
            // 
            // purokLabel
            // 
            purokLabel.AutoSize = true;
            purokLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            purokLabel.Location = new System.Drawing.Point(17, 173);
            purokLabel.Name = "purokLabel";
            purokLabel.Size = new System.Drawing.Size(56, 19);
            purokLabel.TabIndex = 29;
            purokLabel.Text = "Purok:";
            // 
            // typeLabel
            // 
            typeLabel.AutoSize = true;
            typeLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            typeLabel.Location = new System.Drawing.Point(400, 173);
            typeLabel.Name = "typeLabel";
            typeLabel.Size = new System.Drawing.Size(50, 19);
            typeLabel.TabIndex = 27;
            typeLabel.Text = "Type:";
            // 
            // zipCodeLabel
            // 
            zipCodeLabel.AutoSize = true;
            zipCodeLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            zipCodeLabel.Location = new System.Drawing.Point(400, 121);
            zipCodeLabel.Name = "zipCodeLabel";
            zipCodeLabel.Size = new System.Drawing.Size(78, 19);
            zipCodeLabel.TabIndex = 25;
            zipCodeLabel.Text = "Zip Code:";
            // 
            // barangayLabel
            // 
            barangayLabel.AutoSize = true;
            barangayLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            barangayLabel.Location = new System.Drawing.Point(17, 121);
            barangayLabel.Name = "barangayLabel";
            barangayLabel.Size = new System.Drawing.Size(80, 19);
            barangayLabel.TabIndex = 23;
            barangayLabel.Text = "Barangay:";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cityLabel.Location = new System.Drawing.Point(400, 74);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new System.Drawing.Size(42, 19);
            cityLabel.TabIndex = 21;
            cityLabel.Text = "City:";
            // 
            // regionLabel
            // 
            regionLabel.AutoSize = true;
            regionLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            regionLabel.Location = new System.Drawing.Point(398, 26);
            regionLabel.Name = "regionLabel";
            regionLabel.Size = new System.Drawing.Size(64, 19);
            regionLabel.TabIndex = 19;
            regionLabel.Text = "Region:";
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            countryLabel.Location = new System.Drawing.Point(17, 26);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new System.Drawing.Size(71, 19);
            countryLabel.TabIndex = 17;
            countryLabel.Text = "Country:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(17, 223);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(76, 19);
            label1.TabIndex = 34;
            label1.Text = "Remarks:";
            // 
            // purokCComboBoxKrypton
            // 
            this.purokCComboBoxKrypton.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.baseAddressDTOBindingSource, "Purok", true));
            this.purokCComboBoxKrypton.DropDownWidth = 257;
            this.purokCComboBoxKrypton.Location = new System.Drawing.Point(105, 173);
            this.purokCComboBoxKrypton.Name = "purokCComboBoxKrypton";
            this.purokCComboBoxKrypton.Size = new System.Drawing.Size(263, 27);
            this.purokCComboBoxKrypton.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.DarkGray;
            this.purokCComboBoxKrypton.StateActive.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.purokCComboBoxKrypton.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.purokCComboBoxKrypton.StateActive.ComboBox.Border.Rounding = 10;
            this.purokCComboBoxKrypton.StateActive.ComboBox.Content.Color1 = System.Drawing.Color.Black;
            this.purokCComboBoxKrypton.TabIndex = 32;
            // 
            // baseAddressDTOBindingSource
            // 
            this.baseAddressDTOBindingSource.DataSource = typeof(FerPROJ.Design.BaseModels.AddressModel);
            // 
            // provinceCComboBoxKrypton
            // 
            this.provinceCComboBoxKrypton.DropDownWidth = 162;
            this.provinceCComboBoxKrypton.Location = new System.Drawing.Point(105, 74);
            this.provinceCComboBoxKrypton.Name = "provinceCComboBoxKrypton";
            this.provinceCComboBoxKrypton.Size = new System.Drawing.Size(263, 27);
            this.provinceCComboBoxKrypton.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.DarkGray;
            this.provinceCComboBoxKrypton.StateActive.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.provinceCComboBoxKrypton.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.provinceCComboBoxKrypton.StateActive.ComboBox.Border.Rounding = 10;
            this.provinceCComboBoxKrypton.StateActive.ComboBox.Content.Color1 = System.Drawing.Color.Black;
            this.provinceCComboBoxKrypton.TabIndex = 31;
            this.provinceCComboBoxKrypton.SelectedIndexChanged += new System.EventHandler(this.provinceCComboBoxKrypton_SelectedIndexChanged);
            // 
            // typeCComboBoxKrypton
            // 
            this.typeCComboBoxKrypton.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.baseAddressDTOBindingSource, "Type", true));
            this.typeCComboBoxKrypton.DropDownWidth = 169;
            this.typeCComboBoxKrypton.Location = new System.Drawing.Point(488, 173);
            this.typeCComboBoxKrypton.Name = "typeCComboBoxKrypton";
            this.typeCComboBoxKrypton.Size = new System.Drawing.Size(280, 27);
            this.typeCComboBoxKrypton.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.DarkGray;
            this.typeCComboBoxKrypton.StateActive.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.typeCComboBoxKrypton.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.typeCComboBoxKrypton.StateActive.ComboBox.Border.Rounding = 10;
            this.typeCComboBoxKrypton.StateActive.ComboBox.Content.Color1 = System.Drawing.Color.Black;
            this.typeCComboBoxKrypton.TabIndex = 28;
            // 
            // zipCodeCTextBoxKrypton
            // 
            this.zipCodeCTextBoxKrypton.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.baseAddressDTOBindingSource, "ZipCode", true));
            this.zipCodeCTextBoxKrypton.Location = new System.Drawing.Point(488, 121);
            this.zipCodeCTextBoxKrypton.Name = "zipCodeCTextBoxKrypton";
            this.zipCodeCTextBoxKrypton.Size = new System.Drawing.Size(278, 29);
            this.zipCodeCTextBoxKrypton.StateActive.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.zipCodeCTextBoxKrypton.StateActive.Border.Color1 = System.Drawing.Color.DarkGray;
            this.zipCodeCTextBoxKrypton.StateActive.Border.Color2 = System.Drawing.Color.White;
            this.zipCodeCTextBoxKrypton.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.zipCodeCTextBoxKrypton.StateActive.Border.Rounding = 10;
            this.zipCodeCTextBoxKrypton.StateActive.Content.Color1 = System.Drawing.Color.Black;
            this.zipCodeCTextBoxKrypton.StateCommon.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.zipCodeCTextBoxKrypton.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.zipCodeCTextBoxKrypton.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.zipCodeCTextBoxKrypton.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.zipCodeCTextBoxKrypton.StateCommon.Border.Rounding = 10;
            this.zipCodeCTextBoxKrypton.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.zipCodeCTextBoxKrypton.StateNormal.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.zipCodeCTextBoxKrypton.StateNormal.Border.Color1 = System.Drawing.Color.White;
            this.zipCodeCTextBoxKrypton.StateNormal.Border.Color2 = System.Drawing.Color.White;
            this.zipCodeCTextBoxKrypton.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.zipCodeCTextBoxKrypton.StateNormal.Border.Rounding = 10;
            this.zipCodeCTextBoxKrypton.StateNormal.Content.Color1 = System.Drawing.Color.Black;
            this.zipCodeCTextBoxKrypton.TabIndex = 26;
            // 
            // barangayCComboBoxKrypton
            // 
            this.barangayCComboBoxKrypton.DropDownWidth = 169;
            this.barangayCComboBoxKrypton.Location = new System.Drawing.Point(105, 121);
            this.barangayCComboBoxKrypton.Name = "barangayCComboBoxKrypton";
            this.barangayCComboBoxKrypton.Size = new System.Drawing.Size(263, 27);
            this.barangayCComboBoxKrypton.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.DarkGray;
            this.barangayCComboBoxKrypton.StateActive.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.barangayCComboBoxKrypton.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.barangayCComboBoxKrypton.StateActive.ComboBox.Border.Rounding = 10;
            this.barangayCComboBoxKrypton.StateActive.ComboBox.Content.Color1 = System.Drawing.Color.Black;
            this.barangayCComboBoxKrypton.TabIndex = 24;
            this.barangayCComboBoxKrypton.SelectedIndexChanged += new System.EventHandler(this.barangayCComboBoxKrypton_SelectedIndexChanged);
            // 
            // cityCComboBoxKrypton
            // 
            this.cityCComboBoxKrypton.DropDownWidth = 162;
            this.cityCComboBoxKrypton.Location = new System.Drawing.Point(488, 74);
            this.cityCComboBoxKrypton.Name = "cityCComboBoxKrypton";
            this.cityCComboBoxKrypton.Size = new System.Drawing.Size(278, 27);
            this.cityCComboBoxKrypton.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.DarkGray;
            this.cityCComboBoxKrypton.StateActive.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.cityCComboBoxKrypton.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cityCComboBoxKrypton.StateActive.ComboBox.Border.Rounding = 10;
            this.cityCComboBoxKrypton.StateActive.ComboBox.Content.Color1 = System.Drawing.Color.Black;
            this.cityCComboBoxKrypton.TabIndex = 22;
            this.cityCComboBoxKrypton.SelectedIndexChanged += new System.EventHandler(this.cityCComboBoxKrypton_SelectedIndexChanged);
            // 
            // regionCComboBoxKrypton
            // 
            this.regionCComboBoxKrypton.DropDownWidth = 169;
            this.regionCComboBoxKrypton.Location = new System.Drawing.Point(486, 26);
            this.regionCComboBoxKrypton.Name = "regionCComboBoxKrypton";
            this.regionCComboBoxKrypton.Size = new System.Drawing.Size(280, 27);
            this.regionCComboBoxKrypton.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.DarkGray;
            this.regionCComboBoxKrypton.StateActive.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.regionCComboBoxKrypton.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.regionCComboBoxKrypton.StateActive.ComboBox.Border.Rounding = 10;
            this.regionCComboBoxKrypton.StateActive.ComboBox.Content.Color1 = System.Drawing.Color.Black;
            this.regionCComboBoxKrypton.TabIndex = 20;
            this.regionCComboBoxKrypton.SelectedIndexChanged += new System.EventHandler(this.regionCComboBoxKrypton_SelectedIndexChanged);
            // 
            // countryCComboBoxKrypton
            // 
            this.countryCComboBoxKrypton.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.baseAddressDTOBindingSource, "Country", true));
            this.countryCComboBoxKrypton.DropDownWidth = 115;
            this.countryCComboBoxKrypton.Location = new System.Drawing.Point(105, 26);
            this.countryCComboBoxKrypton.Name = "countryCComboBoxKrypton";
            this.countryCComboBoxKrypton.Size = new System.Drawing.Size(263, 27);
            this.countryCComboBoxKrypton.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.DarkGray;
            this.countryCComboBoxKrypton.StateActive.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.countryCComboBoxKrypton.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.countryCComboBoxKrypton.StateActive.ComboBox.Border.Rounding = 10;
            this.countryCComboBoxKrypton.StateActive.ComboBox.Content.Color1 = System.Drawing.Color.Black;
            this.countryCComboBoxKrypton.TabIndex = 18;
            // 
            // remarksCTextBoxKrypton
            // 
            this.remarksCTextBoxKrypton.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.baseAddressDTOBindingSource, "Remarks", true));
            this.remarksCTextBoxKrypton.Location = new System.Drawing.Point(107, 223);
            this.remarksCTextBoxKrypton.Name = "remarksCTextBoxKrypton";
            this.remarksCTextBoxKrypton.Size = new System.Drawing.Size(659, 29);
            this.remarksCTextBoxKrypton.StateActive.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.remarksCTextBoxKrypton.StateActive.Border.Color1 = System.Drawing.Color.DarkGray;
            this.remarksCTextBoxKrypton.StateActive.Border.Color2 = System.Drawing.Color.White;
            this.remarksCTextBoxKrypton.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.remarksCTextBoxKrypton.StateActive.Border.Rounding = 10;
            this.remarksCTextBoxKrypton.StateActive.Content.Color1 = System.Drawing.Color.Black;
            this.remarksCTextBoxKrypton.StateCommon.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.remarksCTextBoxKrypton.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.remarksCTextBoxKrypton.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.remarksCTextBoxKrypton.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.remarksCTextBoxKrypton.StateCommon.Border.Rounding = 10;
            this.remarksCTextBoxKrypton.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.remarksCTextBoxKrypton.StateNormal.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.remarksCTextBoxKrypton.StateNormal.Border.Color1 = System.Drawing.Color.White;
            this.remarksCTextBoxKrypton.StateNormal.Border.Color2 = System.Drawing.Color.White;
            this.remarksCTextBoxKrypton.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.remarksCTextBoxKrypton.StateNormal.Border.Rounding = 10;
            this.remarksCTextBoxKrypton.StateNormal.Content.Color1 = System.Drawing.Color.Black;
            this.remarksCTextBoxKrypton.TabIndex = 33;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.baseAddressDTOBindingSource;
            // 
            // FrmAddressDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 445);
            this.FormDescription = "This is where you can manage detailed address.";
            this.FormTitle = "Manage Address Info";
            this.Name = "FrmAddressDetail";
            this.Text = "Address Details";
            this.basePnl2.ResumeLayout(false);
            this.PanelMain3.ResumeLayout(false);
            this.PanelMain3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.purokCComboBoxKrypton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseAddressDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinceCComboBoxKrypton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeCComboBoxKrypton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barangayCComboBoxKrypton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityCComboBoxKrypton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionCComboBoxKrypton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryCComboBoxKrypton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CComboBoxKrypton purokCComboBoxKrypton;
        private Controls.CComboBoxKrypton provinceCComboBoxKrypton;
        private Controls.CComboBoxKrypton typeCComboBoxKrypton;
        private Controls.CTextBoxKrypton zipCodeCTextBoxKrypton;
        private Controls.CComboBoxKrypton barangayCComboBoxKrypton;
        private Controls.CComboBoxKrypton cityCComboBoxKrypton;
        private Controls.CComboBoxKrypton regionCComboBoxKrypton;
        private Controls.CComboBoxKrypton countryCComboBoxKrypton;
        private Controls.CTextBoxKrypton remarksCTextBoxKrypton;
        private System.Windows.Forms.BindingSource baseAddressDTOBindingSource;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
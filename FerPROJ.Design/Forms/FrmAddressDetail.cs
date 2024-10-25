using FerPROJ.Design.BaseDTO;
using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerPROJ.Design.Forms {
    public partial class FrmAddressDetail : FrmManageKrypton {

        public BaseAddressDTO Address { get; set; }

        public FrmAddressDetail(BaseAddressDTO baseAddress) {
            InitializeComponent();
            Address = baseAddress;
        }
        protected override async Task LoadComponents() {
            await LoadComboEnum();
            await LoadLocation();
            switch (CurrentFormMode) {
                case FormMode.Add:
                    break;
                case FormMode.Update:
                    regionCComboBoxKrypton.Text = Address.Region;
                    provinceCComboBoxKrypton.Text = Address.Province;
                    cityCComboBoxKrypton.Text = Address.City;
                    barangayCComboBoxKrypton.Text = Address.Barangay;
                    purokCComboBoxKrypton.Text = Address.Purok;
                    typeCComboBoxKrypton.Text = Address.Type;
                    break;
            }
            baseAddressDTOBindingSource.DataSource = Address;
        }
        private async Task LoadComboEnum() {
            typeCComboBoxKrypton.FillComboBoxEnum<CEnum.AddressType>();
            purokCComboBoxKrypton.FillComboBoxEnum<CEnum.PurokType>();
            await Task.CompletedTask;
        }
        private async Task LoadLocation() {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"json\philippine_provinces_cities_municipalities_and_barangays_2019v2.json");
            if (File.Exists(jsonFilePath)) {
                string jsonString = File.ReadAllText(jsonFilePath);
                Dictionary<string, Regions> regions = JsonSerializer.Deserialize<Dictionary<string, Regions>>(jsonString);


                regionCComboBoxKrypton.DataSource = new BindingSource(regions, null);
                regionCComboBoxKrypton.DisplayMember = "RegionName";
                regionCComboBoxKrypton.ValueMember = "Key";

                regionCComboBoxKrypton.SelectedIndexChanged += (sender, e) => {
                    if (regionCComboBoxKrypton.SelectedItem != null) {
                        string selectedRegionKey = ((KeyValuePair<string, Regions>)regionCComboBoxKrypton.SelectedItem).Key;
                        if (regions.ContainsKey(selectedRegionKey)) {
                            provinceCComboBoxKrypton.DataSource = new BindingSource(regions[selectedRegionKey].ProvinceList, null);
                            provinceCComboBoxKrypton.DisplayMember = "Key";  // Province name is the dictionary key
                            provinceCComboBoxKrypton.ValueMember = "Key";
                        }
                    }
                };

                // Handle province selection change
                provinceCComboBoxKrypton.SelectedIndexChanged += (sender, e) => {
                    if (provinceCComboBoxKrypton.SelectedItem != null) {
                        var selectedProvince = (KeyValuePair<string, Provinces>)provinceCComboBoxKrypton.SelectedItem;
                        if (selectedProvince.Value != null) {
                            cityCComboBoxKrypton.DataSource = new BindingSource(selectedProvince.Value.MunicipalityList, null);
                            cityCComboBoxKrypton.DisplayMember = "Key";  // Municipality name is the dictionary key
                            cityCComboBoxKrypton.ValueMember = "Key";
                        }
                    }
                };

                // Handle municipality selection change
                cityCComboBoxKrypton.SelectedIndexChanged += (sender, e) => {
                    if (cityCComboBoxKrypton.SelectedItem != null) {
                        var selectedMunicipality = (KeyValuePair<string, Municipalities>)cityCComboBoxKrypton.SelectedItem;
                        if (selectedMunicipality.Value != null) {
                            if (selectedMunicipality.Value.BarangayList != null && selectedMunicipality.Value.BarangayList.Count > 0) {
                                barangayCComboBoxKrypton.DataSource = selectedMunicipality.Value.BarangayList;
                            }
                            else {
                                Console.WriteLine("BarangayList is empty or null for the selected municipality.");
                                barangayCComboBoxKrypton.DataSource = null; // Clear the barangay ComboBox
                            }
                        }
                    }
                };
            }
            await Task.CompletedTask;
        }
        protected override async Task<bool> OnSaveData() {
            return await Task.FromResult(Address != null && Address.DataValidation());
        }
        protected override async Task<bool> OnUpdateData() {
            return await Task.FromResult(Address != null && Address.DataValidation());
        }

        private void regionCComboBoxKrypton_SelectedIndexChanged(object sender, EventArgs e) {
            if (regionCComboBoxKrypton.SelectedIndex != -1) {
                Address.Region = regionCComboBoxKrypton.Text;
            }
        }

        private void provinceCComboBoxKrypton_SelectedIndexChanged(object sender, EventArgs e) {
            if (provinceCComboBoxKrypton.SelectedIndex != -1) {
                Address.Province = provinceCComboBoxKrypton.Text;
            }
        }

        private void cityCComboBoxKrypton_SelectedIndexChanged(object sender, EventArgs e) {
            if (cityCComboBoxKrypton.SelectedIndex != -1) {
                Address.City = cityCComboBoxKrypton.Text;
            }
        }

        private void barangayCComboBoxKrypton_SelectedIndexChanged(object sender, EventArgs e) {
            if (barangayCComboBoxKrypton.SelectedIndex != -1) {
                Address.Barangay = barangayCComboBoxKrypton.Text;
            }
        }
    }
}

using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FerPROJ.Design.BaseModels {
    public class BaseAddressModel : BaseModel {
        public Guid AddressID { get; set; } = new Guid();
        [Required]
        public string Country => "Philippines";
        [Required]
        public string Region { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Barangay { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public string Type { get; set; }
        public string Purok { get; set; }
        public string Province { get; set; }
        public string Remarks { get; set; }
        public string AddressString => $"{Purok}, {Barangay}, {City}, {Province}, {Region}, {Country} {ZipCode}".Trim();       
        public override bool DataValidation() {
            if (Error != null) {
                CShowMessage.Warning(Error);
                return false;
            }
            return true;
        }
    }
    public class Regions {
        [JsonPropertyName("region_name")]
        public string RegionName { get; set; }

        [JsonPropertyName("province_list")]
        public Dictionary<string, Provinces> ProvinceList { get; set; }
    }

    public class Provinces {
        [JsonPropertyName("municipality_list")]
        public Dictionary<string, Municipalities> MunicipalityList { get; set; }
    }

    public class Municipalities {
        [JsonPropertyName("barangay_list")]
        public List<string> BarangayList { get; set; }
    }
}

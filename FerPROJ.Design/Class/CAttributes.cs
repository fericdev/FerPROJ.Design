using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public class CAttributes : Attribute {

        #region DGV Grid Properties
        public int Width { get; set; } = 200;
        public bool Visible { get; set; } = true;
        public bool Editable { get; set; } = false;
        public bool DisplayTotal { get; set; } = false;
        public bool IsImage { get; set; } = false;
        public int Order { get; set; } = 1000;
        public string Header { get; set; } = string.Empty;
        public FormatTypes FormatType { get; set; } = FormatTypes.Current;
        public ImageSizeTypes ImageSizeType { get; set; } = ImageSizeTypes.Small;
        #endregion

    }
    public enum FormatTypes {
        Current,
        Currency,
        TwoDecimal,
        Date,
        DateTime,
        Time
    }
    public enum  ImageSizeTypes {
        Small,
        Medium,
        Large
    }
}

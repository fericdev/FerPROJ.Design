using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public class CDGVAttributes : Attribute {
        #region Properties
        public bool IsVisible { get; set; } = true;
        public bool IsExcluded { get; set; } = false;
        public bool IsEditable { get; set; } = false;
        #endregion
    }
}

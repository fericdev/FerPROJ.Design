using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class {
    public abstract class PropertyValidator : IDataErrorInfo {
        [Browsable(false)]
        public string this[string property] {

            get {
                var propertyDescriptor = TypeDescriptor.GetProperties(this)[property];
                if (propertyDescriptor == null) {
                    return string.Empty;
                }
                var results = new List<ValidationResult>();
                var result = Validator.TryValidateProperty(propertyDescriptor.GetValue(this), new ValidationContext(this, null, null) { MemberName = property }, results);
                if (!result) {
                    return results.First().ErrorMessage;
                }
                return string.Empty;
            }
        }
        [Browsable(false)]
        public string Error {
            get {
                var results = new List<ValidationResult>();
                var result = Validator.TryValidateObject(this, new ValidationContext(this, null, null), results, true);
                if (!result) {
                    return string.Join(Environment.NewLine, results.Select(e => e.ErrorMessage));
                }
                return null;
            }
        }
        [Browsable(false)]
        public bool Success => string.IsNullOrEmpty(Error);
        [Browsable(false)]
        public string ErrorMessage { get; set; }
        [Browsable(false)]
        public StringBuilder ErrorMessages { get; set; } = new StringBuilder();
        public abstract bool DataValidation();
        public bool AddErrorMessage(string message) {
            ErrorMessage = message;
            return false;
        }
    }
}

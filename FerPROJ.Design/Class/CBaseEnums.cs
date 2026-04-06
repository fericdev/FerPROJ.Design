using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class
{
    public class CBaseEnums
    {
        #region Global enums
        public enum FormMode {
            Add,
            Update,
            ReadOnly
        }

        public enum AllowedOpenDB
        {
            One,
            Two
        }
        public enum BankType
        {
            VISA,
            DEBIT,
            CREDIT,
            PREPAID
        }
        public enum Role
        {
            Administrator,
            Secretary
        }
        public enum Sort {
            DESC,
            ASC
        }
        public enum Status {
            ACTIVE,
            CANCELLED
        }
        public enum AddressType {
            Primary,
            Secondary,
        }
        public enum PurokType {
            Uno,
            Dos,
            Tres,
            Kwatro,
            Singko,
            Says,
            Syite,
            Utso,
            Nuwebi,
            Dyes,
            Unsi,
            Dosi
        }
        public enum GenderTypes {
            Male, 
            Female,
            Others
        }
        #endregion

        #region Form enums
        public enum FinalizeStatusTypes {
            Processing,
            Completed
        }
        #endregion
    }
}

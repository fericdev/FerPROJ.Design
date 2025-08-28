using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerPROJ.Design.Class
{
    public static class CBaseEnums
    {
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
        public enum Gender {
            Male, 
            Female,
            Others
        }
    }
}

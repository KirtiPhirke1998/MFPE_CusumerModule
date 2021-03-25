using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MFPE_InsureityPortal_Client.Models
{
    public class BusinessMaster
    {

        public int id { get; set; }
        public bool HasBusinessTypes { get; set; }

        public int AnnualTurnover { get; set; }

        public int capitalInvested { get; set; }

        [Range(0, 10, ErrorMessage = "Bussiness value should be in the range of 0 to 10")]

        public int BussinessValue { get; set; }
        // public int BussinessValue { get; set; }
        //private int businessValue;
        //public int BusinessValue
        //{
        //    get
        //    {
        //        if ((AnnualTurnover / capitalInvested) > 2)
        //        {
        //            businessValue = 9;
        //            return businessValue;
        //        }
        //        else if ((AnnualTurnover / capitalInvested) > 1)
        //        {
        //            businessValue = 8;
        //            return businessValue;
        //        }
        //        businessValue = 1;
        //        return businessValue;
        //    }
        //    set
        //    {

        //        businessValue = value;

        //    }

        //}
    }
}

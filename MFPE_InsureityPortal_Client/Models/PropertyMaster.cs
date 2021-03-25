using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFPE_InsureityPortal_Client.Models
{
    public class PropertyMaster
    {
        public int id { get; set; }
        public bool HasPropertyTypes { get; set; }

        public int CostofAsset { get; set; }

        public int SalvageValue { get; set; }

        public int UsefulLifeOfAsset { get; set; }

        public int PropertyValue { get; set; }

        //private int propertyValue;
        //public int PropertyValue
        //{
        //    get
        //    {
        //        if (((CostofAsset - SalvageValue) / UsefulLifeOfAsset) > 0)
        //        {
        //            propertyValue = 5;
        //            return propertyValue;
        //        }
        //        else
        //        {
        //            propertyValue = 9;
        //            return propertyValue;
        //        }


        //    }
        //    set
        //    {

        //        PropertyValue = value;

        //    }

        //}

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MFPE_CusumerModule.Models
{
    public class Property
    {
        public int id { get; set; }
        public string BuildingType { get; set; }

        public int BuildingAge { get; set; }

        public int PropertMasterId { get; set; }
        [ForeignKey("PropertMasterId")]
        public PropertyMaster PropertyMaster { get; set; }

        public int BussinessId { get; set; }
        [ForeignKey("BussinessId")]
        public Business Business  { get; set; }


    }
}

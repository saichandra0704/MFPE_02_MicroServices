using PolicyAdmin.ConsumerMS.API.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.ConsumerMS.API.Models.DAO
{
    public class PropertyMaster
    {
        public int Id { get; set; }
        public PropertyType PropertyType { get; set; }
        public int MinimumCostOfAsset { get; set; }
        public int MaximumCostOfAsset { get; set; }
        public int MinimumArea { get; set; }
        public int MaximumArea { get; set; }
        public int PropertyAgeMin { get; set; }
        public int PropertyAgeMax { get; set; }
        public int EstimatedLife{get;set;}

    }
}

using PolicyAdmin.ConsumerMS.API.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.ConsumerMS.API.Models.DAO
{
    public class BusinessMaster
    {
        public int Id { get; set; }
        public BusinessType BusinessType { get; set; }
        public double MinimumAnnualTurnOver { get; set; }
        public double  MinimumCapitalInvested { get; set; }
        public int MinimumBusinessAgeInYears { get; set; }
        public int MinimumTotalEmployees { get; set; }
    }
}

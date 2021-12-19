using PolicyAdmin.QuotesMS.API.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.QuotesMS.API.Models
{
    public class Policy
    {

        public int Id { get; set; }
        public PropertyType PropertyType { get; set; }
        public string ConsumerType { get; set; }
        public double AssuredSum { get; set; }
        public int Tenure { get; set; }
        public int BusinessValue { get; set; }
        public int PropertyValue { get; set; }
        public string Loacation { get; set; }
        public string policyType { get; set; }
    }
}

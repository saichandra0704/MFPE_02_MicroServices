using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PolicyAdmin.QuotesMS.API.Models.Enum;

namespace PolicyAdmin.QuotesMS.API.Models
{
    public class QuoteMaster
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Range(0,10)]
        public int PropertyValueRangeFrom { get; set; }

        [Required]
        [Range(0, 10)]
        public int PropertyValueRangeTo { get; set; }

        [Required]
        [Range(0, 10)]
        public int BusinessValueRangeFrom { get; set; }

        [Required]
        [Range(0, 10)]
        public int BusinessValueRangeTo { get; set; }

        [Required]
        public PropertyType PropertyType { get; set; }

        [Required]
        public int Quote { get; set; }
    }
}

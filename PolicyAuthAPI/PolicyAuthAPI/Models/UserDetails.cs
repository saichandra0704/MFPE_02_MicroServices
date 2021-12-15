using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Policy.Auth.API.Models
{
    public class UserDetails
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

using Policy.Auth.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Policy.Auth.API.Repository
{
    public interface IUserRepository
    {
        UserDetails GetUserDetails(UserDetails user);
    }
}

using Policy.Auth.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Policy.Auth.API.Provider
{
    public interface IUserProvider
    {
        public string LoginProvider(UserDetails user);
        public string GenerateJSONWebToken(UserDetails userInfo);
    }
}

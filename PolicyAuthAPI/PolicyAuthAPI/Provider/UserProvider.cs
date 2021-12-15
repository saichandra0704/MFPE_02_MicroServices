using Policy.Auth.API.Models;
using Policy.Auth.API.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Auth.API.Provider
{
    public class UserProvider : IUserProvider
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(UserProvider));
        private readonly IUserRepository userRepository;
        private IConfiguration _config;
        public UserProvider(IUserRepository userRepository, IConfiguration config)
        {
            this.userRepository = userRepository;
            this._config = config;
        }

        public string LoginProvider(UserDetails user)
        {
            try
            {
                UserDetails _user = userRepository.GetUserDetails(user);
                _log4net.Info(_user.Username);
                if (_user == null)
                {
                    return null;
                }
                else
                {
                    return GenerateJSONWebToken(user);
                }
            }
            catch (Exception e)
            {
                _log4net.Error("Exception occured while authenticating user/generating token as " + e.Message);
            }
            return null;
        }

        public string GenerateJSONWebToken(UserDetails userInfo)
        {
            _log4net.Info("Token Generation initiated");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

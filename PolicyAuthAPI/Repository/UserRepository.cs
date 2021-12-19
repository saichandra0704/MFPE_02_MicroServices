using Policy.Auth.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Policy.Auth.API.Repository
{
    public class UserRepository : IUserRepository
    {
        static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(UserRepository));
        private static List<UserDetails> user;
        public UserRepository()
        {
            user = new List<UserDetails>()
            {
                new UserDetails{Username="SaiChandra", Password="sai123"},
                new UserDetails{Username="HemaVallika", Password="hema123"},
                new UserDetails{Username="AslamDegala", Password="aslam123"},
                new UserDetails{Username="Poornima", Password="poornima123"},
                new UserDetails{Username="Shivani", Password="shivani123"}
            };
        }

        public UserDetails GetUserDetails(UserDetails userValue)
        {
            try
            {
                UserDetails userResult = user.FirstOrDefault(c => c.Username == userValue.Username && c.Password == userValue.Password);
                return userResult;
            }
            catch (Exception e)
            {
                _logger.Error("Error in getting user details as " + e.Message);
                return null;
            }
        }
    }

}
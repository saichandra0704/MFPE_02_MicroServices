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
                new UserDetails{Username="Admin1", Password="Admin1@123"},
                new UserDetails{Username="Admin2", Password="Admin2@123"},
                new UserDetails{Username="Admin3", Password="Admin3@123"}
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
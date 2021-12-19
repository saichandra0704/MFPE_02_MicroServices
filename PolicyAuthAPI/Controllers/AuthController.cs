using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Policy.Auth.API.Models;
using Policy.Auth.API.Provider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Policy.Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthController));
        private readonly IUserProvider _userProvider;

        public static string TokenString;

        public AuthController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserDetails login)
        {
            try
            {
                _log4net.Info("Authentication initiated for " + login.Username);
                IActionResult response = Unauthorized();
                string tokenString = _userProvider.LoginProvider(login);
                TokenString = tokenString;
                if (tokenString == null)
                {
                    _log4net.Error("Login failed for " + login.Username);

                    return NotFound();
                }
                else
                {
                    return Ok(new { token = tokenString});
                }
            }
            catch (Exception e)
            {
                _log4net.Error("Error in login for user " + login.Username + " as " + e.Message);
                return new StatusCodeResult(500);
            }
        }


        [HttpGet]
        public TokenData GetToken()
        {
            TokenData tokenData = new() { id = 1, _token = TokenString };
            return tokenData;
        }

    }
}
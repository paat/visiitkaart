using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VisiitkaartBackend.Services.Interfaces;

namespace VisiitkaartBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginTokenController : ControllerBase
    {
        private IConfiguration _configuration;
        private ICustomSignInService _signInService;

        public LoginTokenController(IConfiguration config, ICustomSignInService signInService)
        {
            _configuration = config;
            _signInService = signInService;
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            string jwtToken =_signInService.GetJwtToken(login.Username, login.Password);
            if (jwtToken != null)
            {
                response = Ok(new { token = jwtToken });
            }

            return response;
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

    }
}
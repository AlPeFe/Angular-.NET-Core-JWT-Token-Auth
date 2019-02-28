using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GamDroidClient.Models;
using GamDroidClient.WebHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamDroidClient.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IRestService _restService;

        public AuthController(IRestService restService)
        {
            _restService = restService;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel user)
        {
         
                if (user == null)
                {
                    return BadRequest("Invalid client request");
                }

                var result = await _restService.GetDeviceConfiguration(user);

                if (result.Response == true)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var tokeOptions = new JwtSecurityToken(
                        issuer: "https://localhost:44358",
                        audience: "https://localhost:44358",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signinCredentials
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(new { Token = tokenString });
                }
                else
                {
                    return Unauthorized();
                }
        }
    }
}

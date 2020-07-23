using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventsPortal.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;

        }

        //[HttpPost, Route("login")]
        //public async Task<IActionResult> AuthUser([FromBody] UserDTO userDTO)
        //{
        //    var searchList = await _userService.GetUsers();

        //    var counter = 0;

        //    foreach (var item in searchList)
        //    {
        //        if (item.Login == userDTO.Login && item.Password == userDTO.Password)
        //            counter++;
        //    }

        //    if (counter > 0)
        //    {
        //        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
        //        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        //        var claims = new List<Claim>
        //                    {
        //                        new Claim("Login", userDTO.Login)
        //                    };
        //        var tokenOptions = new JwtSecurityToken(
        //            issuer: "http://localhost:50816",
        //            audience: "http://localhost:50816",
        //            claims: claims,
        //            expires: DateTime.Now.AddMinutes(5),
        //            signingCredentials: signinCredentials
        //        );
        //        counter = 0;
        //        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        //        return Ok(new { Token = tokenString });
        //    }
        //    else
        //    {
        //        return Unauthorized();
        //    }
        //}
    }
}

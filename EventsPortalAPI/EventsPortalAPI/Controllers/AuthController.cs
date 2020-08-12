using Core.DTO;
using EventsPortalAPI.GoogleAuthModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventsPortalAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
                _userService = userService;
        }

        [HttpGet]
        public IActionResult Authenticate()
        {
            //    var s = User.Identity.Name;
            //    var claims = new List<Claim>
            //    {
            //        new Claim(ClaimsIdentity.DefaultNameClaimType, "qwe")
            //    };
            //    ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));


            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var tokeOptions = new JwtSecurityToken(
            issuer: "http://localhost:5000",
            audience: "http://localhost:5000",
            claims: new List<Claim>(),
            expires: DateTime.Now.AddMinutes(5),
            signingCredentials: signinCredentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new { Token = tokenString
    });
        
        
        }

        [HttpPost]
        public async Task<object> Savesresponse(GoogleUser googleUser)
        {
            var userList = await _userService.GetUsers();

            foreach (var user in userList)
            {
                if (user.Email == googleUser.email)
                {
                    //await Authenticate();
                    return new Response { Message = user.Token, UserName = user.Name, Status = "Exists" };
                }
            }
            var userDTO = new UserDTO()
            {
                GoogleId = googleUser.id,
                Email = googleUser.email,
                IdToken = googleUser.idToken,
                Image = googleUser.image,
                Name = googleUser.name,
                Provider = googleUser.provider,
                Token = googleUser.token
            };
            await _userService.AddUser(userDTO);
           // await Authenticate();

            return new Response { Message = googleUser.token, UserName = googleUser.name, Status = "OK" };
        }
    }
}

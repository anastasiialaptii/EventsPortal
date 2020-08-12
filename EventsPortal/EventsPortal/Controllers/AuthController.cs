﻿using EventsPortal.GoogleAuthModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EventsPortal.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
      //  private readonly IUserService _userService;

        public AuthController(/*IUserService userService*/)
        {
        //    _userService = userService;
        }

        [HttpGet]
        public async Task Authenticate()
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, "qwe")
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }


        //[HttpPost]
        //public async Task<object> Savesresponse(GoogleUser googleUser)
        //{
        //    var userList = await _userService.GetUsers();   

        //    foreach (var user in userList)
        //    {
        //        if (user.Email == googleUser.email)
        //        {
        //            await Authenticate();
        //            return new Response { Message = user.Token, UserName = user.Name, Status = "Exists" };
        //        }
        //    }
        //    var userDTO = new UserDTO()
        //    {
        //        GoogleId = googleUser.id,
        //        Email = googleUser.email,
        //        IdToken = googleUser.idToken,
        //        Image = googleUser.image,
        //        Name = googleUser.name,
        //        Provider = googleUser.provider,
        //        Token = googleUser.token
        //    };
        //    await _userService.AddUser(userDTO);
        //    await Authenticate();

        //    return new Response { Message = googleUser.token, UserName = googleUser.name, Status = "OK" };
        //}
    }
}

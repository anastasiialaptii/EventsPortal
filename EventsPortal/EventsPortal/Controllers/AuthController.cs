using EventsPortal.GoogleAuthModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;
using System.Threading.Tasks;

namespace EventsPortal.Controllers
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

        [HttpPost]
        public async Task<object> Savesresponse(GoogleUser googleUser)
        {

            var userList = await _userService.GetUsers();   

            foreach (var user in userList)
            {
                if (user.Email == googleUser.email)
                {
                    return new Response { Message = user.Token, Status = "Exists" };
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
            return new Response { Message = googleUser.token, Status = "OK" };
        }
    }
}

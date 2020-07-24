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

            var userList = await _userService.GetUsers();
        

            foreach (var user in userList)
            {
                if (user.Email == userDTO.Email)
                {
                    return new Response { Message = googleUser.idToken, Status = "Exists" };
                }
            }

            await _userService.AddUser(userDTO);
            return new Response { Message = googleUser.idToken, Status = "OK" };
        }
    }
}

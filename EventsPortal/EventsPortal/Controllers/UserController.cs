using AutoMapper;
using EventsPortal.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersPortal.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsersList()
        {
            return _mapper.Map<List<UserViewModel>>
                (await _userService.GetUsers()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetUserById(int? id)
        {
            if (id != null)
            {
                var serachItem = await _userService.GetUserById(id);

                if (serachItem != null)
                {
                    return _mapper.Map<UserViewModel>(serachItem);
                }
                else return NotFound();
            }
            else throw new ArgumentNullException();
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> CreateUser(UserViewModel UserViewModel)
        {
            if (UserViewModel != null)
            {
                await _userService.AddUser(
                    _mapper.Map<UserDTO>(UserViewModel));
            }
            return CreatedAtAction(nameof(GetUserById), new { id = UserViewModel.Id }, UserViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int? id)
        {
            if (id != null)
            {
                var searchItem = await _userService.GetUserById(id);
                if (searchItem != null)
                {
                    await _userService.DeleteUser(id);
                    return NoContent();
                }
                else return NotFound();
            }
            else throw new ArgumentNullException();
        }
    }
}

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace UsersPortal.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<UserDTO> GetUsersList()
        {
            return _userService.GetUsers();
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserDTO>> GetUserById(int? id)
        //{
        //    if (id != null)
        //    {
        //        var serachItem = await _userService.GetUser(id);

        //        if (serachItem != null)
        //        {
        //            return serachItem;
        //        }
        //        else return NotFound();
        //    }
        //    else throw new ArgumentNullException();
        //}

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO UserDTO)
        {
            if (UserDTO != null)
            {
                await _userService.AddUser(UserDTO);
            }
            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int? id)
        {
            if (id != null)
            {
                var searchItem =  _userService.GetUser(id);
                if (searchItem != null)
                {
                     _userService.DeleteUser(id);
                    return NoContent();
                }
                else return NotFound();
            }
            else throw new ArgumentNullException();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userDTO)
        {
            if (id != userDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await _userService.EditUser(userDTO);
            }
            catch (DBConcurrencyException)
            {
                if (_userService.GetUser(id) == null)
                {
                    return NotFound();
                }

                else
                {
                    throw;
                }
            }
            return Ok();
        }
    }
}

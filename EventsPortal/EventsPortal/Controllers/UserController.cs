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
        public async Task<IEnumerable<UserDTO>> GetUsersList()
        {
            return await _userService.GetUsers();
        }

        [HttpGet("{token}")]
        public async Task<int> GetUserByToken(string token)
        {
            return await _userService.GetUserByToken(token);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int? id)
        {
            if (id != null)
            {
                var serachItem = await _userService.GetUserById(id);

                if (serachItem != null)
                {
                    return serachItem;
                }
                else return NotFound();
            }
            else throw new ArgumentNullException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO UserDTO)
        {
            if (UserDTO != null)
            {
                await _userService.AddUser(UserDTO);
            }
            return CreatedAtAction(nameof(GetUserById), new { id = UserDTO.Id }, UserDTO);

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
                if (_userService.GetUserById(id) == null)
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


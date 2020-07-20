using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
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
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersList()
        {
            return _mapper.Map<List<UserDTO>>
                (await _userService.GetUsers()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int? id)
        {
            if (id != null)
            {
                var serachItem = await _userService.GetUserById(id);

                if (serachItem != null)
                {
                    return _mapper.Map<UserDTO>(serachItem);
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
                await _userService.AddUser(
                    _mapper.Map<UserDTO>(UserDTO));
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
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO UserDTO)
        {
            if (id != UserDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await _userService.EditUser(
               _mapper.Map<UserDTO>(UserDTO));
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


using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace UsersPortal.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
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

        [HttpGet, Route("c")]
        public /*IEnumerable<string> */async Task/*<ActionResult*/<IEnumerable<UserDTO>> GetUsersList()
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

        [HttpPost, Route("login")]
        public IActionResult CreateUser([FromBody] UserDTO UserDTO)
        {
            if (UserDTO == null)
            {
                return BadRequest("Invalid client request");
            }

            if (UserDTO.FirstName == "1" && UserDTO.LastName == "1")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("pirateKing@123"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, UserDTO.FirstName),
                    new Claim(ClaimTypes.Role, "Operator")
                };

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:50816",
                    audience: "http://localhost:50816",
                    claims: claims,
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


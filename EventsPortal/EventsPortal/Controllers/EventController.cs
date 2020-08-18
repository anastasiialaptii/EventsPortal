using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsPortal.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IUserService _userService;

        public EventController(IEventService eventService, IUserService userService)
        {
            _eventService = eventService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<EventDTO>> GetPublicEvents()
        {
            try
            {
                return Ok(_eventService.GetPublicEvents());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventDTO>> GetPublicOwnEvents()
        {
            try
            {
                return Ok(_eventService.GetPublicOwnEvents(User.Identity.Name));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet("{eventName}")]
        public ActionResult<IEnumerable<EventDTO>> SearchEvents(string eventName)
        {
            try
            {
                return Ok(_eventService.SearchEvents(User.Identity.Name, eventName));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<EventDTO> GetEvent(int? id)
        {
            try
            {
                return _eventService.GetEvent(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult<EventDTO>> CreateEvent([FromBody] EventDTO eventDTO)
        {
            try
            {
                if (eventDTO != null)
                {
                    eventDTO.OrganizerId = _userService.FindUserByEmail(User.Identity.Name).Id;
                    await _eventService.AddEvent(eventDTO);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpDelete("{id}/{userId}")]
        public async Task<ActionResult> DeleteEvent(int? id, string userId)
        {
            try
            {
                if (User.Identity.Name == userId)
                {
                    await _eventService.DeleteEvent(id);
                    return Ok();
                }
                else return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] EventDTO eventDTO)
        {
            try
            {
                await _eventService.EditEvent(eventDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}


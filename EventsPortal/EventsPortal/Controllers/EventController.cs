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
   // [Authorize]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IUserService _userService;

        public EventController(IEventService eventService, IUserService userService)
        {
            _eventService = eventService;
            _userService = userService;
        }

        //[HttpGet]
        //public async Task<IEnumerable<int>> GetAllowedEventToVisitList()
        //{
        //    return await _eventService.IsEventUserCreated(User.Identity.Name);
        //}
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<EventDTO> GetPublicEvents()
        {
            return _eventService.GetPublicEvents();
        }

        [HttpGet]
        public IEnumerable<EventDTO> GetPublicOwnEvents()
        {
            return _eventService.GetPublicOwnEvents(User.Identity.Name);
        }

        [HttpGet("{eventName}")]
        public IEnumerable<EventDTO> SearchEvents(string eventName)
        {
            return _eventService.SearchEvents(User.Identity.Name, eventName);
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


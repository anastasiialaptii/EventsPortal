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
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IUserService _userService;

        public EventController(IEventService eventService, IUserService userService)
        {
            _eventService = eventService;
            _userService = userService;
        }

        //[HttpGet("{userId}")]
        //public async Task<IEnumerable<int>> GetAlloweEventToVisitList(string userId)
        //{
        //    return await _eventService.IsEventUserCreated(userId);
        //}

        [HttpGet]
        [Authorize]
        public IEnumerable<EventDTO> GetPublicOwnEvents()
        {
            return _eventService.GetPublicOwnEvents(User.Identity.Name);
        }

        [HttpGet]
        public IEnumerable<EventDTO> GetPublicEvents()
        {
            return _eventService.GetPublicEvents();
        }

        //[HttpGet("{organizerId}/{searchEvent}")]
        //[HttpGet("{organizerId}")]
        //[HttpGet]
        //[Authorize]

        //public async Task<IEnumerable<EventDTO>> GetAllowedEventList(string organizerId, string searchEvent)
        //{
        //    var s = User.Identity.Name;
        //    return await _eventService.GetAllowedEventList(organizerId, searchEvent);
        //}

        //public async Task<IEnumerable<EventDTO>> GetAllEvents(string organizerId, string searchEvent)
        //{
        //    return await _eventService.GetAllowedEventList(organizerId, searchEvent);
        //}

        //[HttpGet("{searchEvent}")]
        //public async Task<IEnumerable<EventDTO>> GetSearchedEventList(string searchEvent)
        //{
        //    return await _eventService.GetSearchedEventList(searchEvent);
        //}

        [Authorize]
        [HttpGet("{id}")]
        public EventDTO GetEvent(int? id)
        {
            return _eventService.GetEvent(id);
        }

        [Authorize]
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

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int? id)
        {
            try
            {
                await _eventService.DeleteEvent(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [Authorize]
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
        //catch (DBConcurrencyException)
        //{
        //    if (_eventService.GetEvent(id) == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        throw;
        //    }
    }
}


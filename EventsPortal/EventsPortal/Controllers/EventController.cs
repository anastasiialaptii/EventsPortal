using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Threading.Tasks;

namespace EventsPortal.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var x = await _eventService.GetSearchedEventList("3");
            string test;
            foreach (var item in x)
            {
                test = item.ImageURI;
                return Ok("{\"image\"" + ":\"" + System.Convert.ToBase64String(System.IO.File.ReadAllBytes(test)) + "\"}");
            }
            return NoContent();
        }

        [HttpGet("{userId}")]
        public async Task<IEnumerable<int>> GetAlloweEventToVisitList(string userId)
        {
            return await _eventService.IsEventUserCreated(userId);
        }

        [HttpGet]
        public async Task<IEnumerable<EventDTO>> GetEventList()
        {
            return await _eventService.GetEvents();
        }

        [HttpGet("{startDate}")]
        public async Task<IEnumerable<EventDTO>> GetEventsByDate(string startDate)
        {
            return await _eventService.GetEventsByDate(startDate);
        }

        [HttpGet("{organizerId}/{searchEvent}")]
        [HttpGet("{organizerId}")]
        [HttpGet]
        [Authorize]
        
        public async Task<IEnumerable<EventDTO>> GetAllowedEventList(string organizerId, string searchEvent)
        {
            var s = User.Identity.Name;
            return await _eventService.GetAllowedEventList(organizerId, searchEvent);
        }


        public async Task<IEnumerable<EventDTO>> GetAllEvents(string organizerId, string searchEvent)
        {
            return await _eventService.GetAllowedEventList(organizerId, searchEvent);
        }

        [HttpGet("{searchEvent}")]
        public async Task<IEnumerable<EventDTO>> GetSearchedEventList(string searchEvent)
        {
            return await _eventService.GetSearchedEventList(searchEvent);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<EventDTO>> GetEventById(int? id)
        {
            if (id != null)
            {
                return await _eventService.GetEventById(id);
            }
            else throw new ArgumentNullException();
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult<EventDTO>> CreateEvent([FromBody] EventDTO eventDTO)
        {
            if (eventDTO != null)
            {
                await _eventService.AddEvent(eventDTO);
            }
            return CreatedAtAction(nameof(GetEventById), new { id = eventDTO.Id }, eventDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int? id)
        {
            if (id != null)
            {
                string userId = User.Claims.First(c => c.Type == "UserID").Value;

                var searchItem = await _eventService.GetEventById(id);
                if (searchItem != null)
                {
                    await _eventService.DeleteEvent(id);
                    return NoContent();
                }
                else return NotFound();
            }
            else throw new ArgumentNullException();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] EventDTO eventDTO)
        {
            if (id != eventDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await _eventService.EditEvent(eventDTO);
            }
            catch (DBConcurrencyException)
            {
                if (_eventService.GetEventById(id) == null)
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

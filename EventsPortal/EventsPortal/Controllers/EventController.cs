using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EventsPortal.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private IMapper _mapper;

        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IEnumerable<EventDTO>> GetEventsList()
        {
            return await _eventService.GetEvents();
        }

        [HttpGet]
        public async Task<IEnumerable<EventDTO>> GetPublicEventList()
        {
            return await _eventService.GetPublicEventList();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<EventDTO>> GetEventById(int? id)
        {
            if (id != null)
            {
                var searchItem = await _eventService.GetEventById(id);

                if (searchItem != null)
                {
                    return searchItem;
                }
                else return NotFound();
            }
            else throw new ArgumentNullException();
        }

        [HttpPost]
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

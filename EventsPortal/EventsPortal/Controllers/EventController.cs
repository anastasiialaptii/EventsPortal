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
        public Object GetEvents()
        {
            return _eventService.GetList();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDTO>>> GetEventsList()
        {
            return _mapper.Map<List<EventDTO>>
                (await _eventService.GetEvents()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDTO>> GetEventById(int? id)
        {
            if (id != null)
            {
                var serachItem = await _eventService.GetEventById(id);

                if (serachItem != null)
                {
                    return _mapper.Map<EventDTO>(serachItem);
                }
                else return NotFound();
            }
            else throw new ArgumentNullException();
        }

        [HttpPost]
        public async Task<ActionResult<EventDTO>> CreateEvent(EventDTO EventDTO)
        {
            if (EventDTO != null)
            {
                await _eventService.AddEvent(
                    _mapper.Map<EventDTO>(EventDTO));
            }
            return CreatedAtAction(nameof(GetEventById), new { id = EventDTO.Id }, EventDTO);
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
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] EventDTO EventDTO)
        {
            if (id != EventDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await _eventService.EditEvent(
               _mapper.Map<EventDTO>(EventDTO));
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

using AutoMapper;
using EventsPortal.ViewModel;
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
        public async Task<ActionResult<IEnumerable<EventViewModel>>> GetEventsList()
        {
            return _mapper.Map<List<EventViewModel>>
                (await _eventService.GetEvents()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventViewModel>> GetEventById(int? id)
        {
            if (id != null)
            {
                var serachItem = await _eventService.GetEventById(id);

                if (serachItem != null)
                {
                    return _mapper.Map<EventViewModel>(serachItem);
                }
                else return NotFound();
            }
            else throw new ArgumentNullException();
        }

        [HttpPost]
        public async Task<ActionResult<EventViewModel>> CreateEvent(EventViewModel eventViewModel)
        {
            if (eventViewModel != null)
            {
                await _eventService.AddEvent(
                    _mapper.Map<EventDTO>(eventViewModel));
            }
            return CreatedAtAction(nameof(GetEventById), new { id = eventViewModel.Id }, eventViewModel);
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
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] EventViewModel eventViewModel)
        {
            if (id != eventViewModel.Id)
            {
                return BadRequest();
            }
            try
            {
                await _eventService.EditEvent(
               _mapper.Map<EventDTO>(eventViewModel));
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

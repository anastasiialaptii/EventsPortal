using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Http.Headers;
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

        //[HttpGet]
        //public IActionResult RetPath()
        //{
        //    Byte[] b = System.IO.File.ReadAllBytes("Resources\\Images\\photo_2018-03-30_21-22-48.jpg");  
        //    return File(b, "image/jpeg");
        //}

        [HttpGet]
        public IActionResult  Get()
        {
            Byte[] b = System.IO.File.ReadAllBytes("Resources\\Images\\photo_2018-03-30_21-22-48.jpg");
          //   return (System.Convert.ToBase64String(b));
            //   return File(b, "image/jpeg");
            //return (b);


            return Ok ("{\"image\""+":\""+ System.Convert.ToBase64String(b)+"\"}");

        }

        [HttpGet]
        public async Task<IEnumerable<EventDTO>> GetEventList()
        {
            return await _eventService.GetEvents();
        }

        [HttpGet("{organizerId}")]
        public async Task<IEnumerable<EventDTO>> GetAllowedEventList(string organizerId)
        {
            return await _eventService.GetAllowedEventList(organizerId);
        }

        [HttpGet("{searchEvent}")]
        public async Task<IEnumerable<EventDTO>> GetSearchedEventList(string searchEvent)
        {
            return await _eventService.GetSearchedEventList(searchEvent);
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

using AutoMapper;
using EventsPortal.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Collections.Generic;
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
        public async Task<ActionResult<IEnumerable<EventViewModel>>> GetEventsList()
        {
            return _mapper.Map<List<EventViewModel>>
                (await _eventService.GetEvents()).ToList();
        }
    }
}

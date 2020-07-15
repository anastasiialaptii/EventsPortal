using Core.Entities;
using Data.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPortal.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IEventsTypeService _eventsTypeService;

        public TestController(IEventsTypeService eventsTypeService)
        {
            _eventsTypeService = eventsTypeService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<EventType>> GetAll()
        {
            return  _eventsTypeService.GetEventsType().ToList();
                
        }
    }
}

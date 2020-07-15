using AutoMapper;
using Core.Entities;
using Data.Repository;
using EventsPortal.ViewModel;
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
        private IMapper _mapper;

        public TestController(IEventsTypeService eventsTypeService, IMapper mapper)
        {
            _eventsTypeService = eventsTypeService;
            _mapper = mapper;

        }

        [HttpGet]
        public ActionResult<IEnumerable<EventTypeViewModel>> GetAll()
        {
            return  _mapper.Map<List<EventTypeViewModel>>(_eventsTypeService.GetEventsType().ToList());                
        }
    }
}

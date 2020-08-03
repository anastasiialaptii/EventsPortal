using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsPortal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _visitService;

        public VisitController(IVisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpGet("{eventId}")]
        public async Task<int> GetTotalVisitorsPerEvent(int eventId)
        {
            return await _visitService.GetTotalVisitorsPerEvent(eventId);
        }

        [HttpGet]
        public async Task<IEnumerable<VisitDTO>> GetVisitList()
        {
            return await _visitService.GetVisits();
        }

        [HttpGet("{eventId}")]
        public async Task<IEnumerable<VisitDTO>> GetVisitorsList(int eventId)
        {
            return await _visitService.GetVisitorsByEvent(eventId);
        }

        [HttpPost]
        public async Task CreateVisit([FromBody] VisitDTO visitDTO)
        {
            if (visitDTO != null)
            {
                await _visitService.AddVisit(visitDTO);
            }
        }
    }
}

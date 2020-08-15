using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsPortal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _visitService;

        public VisitController(IVisitService visitService)
        {
            _visitService = visitService;
        }

        //[HttpGet]
        //public async Task<IEnumerable<VisitDTO>> GetVisitList()
        //{
        //    return await _visitService.GetVisits();
        //}

        [HttpGet("{eventId}")]
        public IEnumerable<VisitDTO> GetVisitorsPerEvent(int eventId)
        {
            return _visitService.GetVisitorsPerEvent(eventId);
        }

        [HttpPost]
        public async Task <ActionResult> CreateVisit ([FromBody] VisitDTO visitDTO)
        {
            try
            {
                await _visitService.AddVisit(visitDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}

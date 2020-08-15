using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace EventsPortal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
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

        //[HttpGet("{eventId}")]
        //public async Task<IEnumerable<VisitDTO>> GetVisitorsList(int eventId)
        //{
        //    return await _visitService.GetVisitorsByEvent(eventId);
        //}

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

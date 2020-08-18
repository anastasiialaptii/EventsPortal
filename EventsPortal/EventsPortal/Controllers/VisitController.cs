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
    [Authorize]
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _visitService;
        private readonly IUserService _userService;

        public VisitController(IVisitService visitService, IUserService userService)
        {
            _visitService = visitService;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VisitDTO>> GetEnrollEvents()
        {
            try
            {
                return Ok(_visitService.GetEnrollEvents(_userService.FindUserByEmail(User.Identity.Name).Id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<VisitDTO>> GetConfirmedVisits()
        {
            try
            {
                return Ok(_visitService.GetConfirmedVisits(_userService.FindUserByEmail(User.Identity.Name).Id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet("{eventId}")]
        public ActionResult<IEnumerable<VisitDTO>> GetVisitorsPerEvent(int eventId)
        {
            try
            {
                return Ok(_visitService.GetVisitorsPerEvent(eventId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateVisit([FromBody] VisitDTO visitDTO)
        {
            try
            {
                visitDTO.UserId = _userService.FindUserByEmail(User.Identity.Name).Id;
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

using LeadManager.Domain.Interfaces;
using LeadManager.Domain.Models.Entrada;
using LeadManager.Domain.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagerAPI.Controllers
{
    [Route("Lead")]
    [Produces("application/json")]
    public class LeadController : ControllerBase
    {
        private readonly ILeadManagerService _leadManagerService;

        public LeadController(ILeadManagerService service)
        {
            _leadManagerService = service;
        }

        [HttpGet]
        public IActionResult GetLeads(int leadStatus)
        {
            var request = new LeadStatusRequest();

            if (request.ValidateStatus(leadStatus))
            {
                request.InsertStatus(leadStatus);
            };

            var returnRequest = _leadManagerService.GetListLeadsByStatus(request);

            return Ok(returnRequest);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStatusLead(int leadStatus, int id)
        {
            var request = new UpdateLeadStatusRequest();

            if (request.ValidateStatus(leadStatus))
            {
                request.InsertStatus(leadStatus);
                request.InsertStatus(id);
            };

            _leadManagerService.UpdateStatusLead(request);

            return Ok();
        }
    }
}

using LeadManager.Domain.Interfaces;
using LeadManager.Domain.Models.Entrada;
using LeadManager.Domain.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagerAPI.Controllers
{
    [Route("Job")]
    [Produces("application/json")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _leadManagerService;

        public JobController(IJobService service)
        {
            _leadManagerService = service;
        }

        [HttpGet]
        public IActionResult GetJobs(int leadStatus)
        {
            var request = new GetJobsStatusRequest();

            if (request.ValidateStatus(leadStatus))
            {
                request.InsertStatus(leadStatus);
            };

            var returnRequest = _leadManagerService.GetListJobsByStatus(request);

            return Ok(returnRequest);
        }
        
        [HttpPut]
        public IActionResult UpdateStatusLead( int id, int leadStatus)
        {
            var request = new UpdateLeadJobStatusRequest();

            if (request.ValidateStatus(leadStatus))
            {
                request.InsertStatus(leadStatus);
                request.InsertIdJob(id);
            };

            _leadManagerService.UpdateStatusLeadJob(request);

            return Ok();
        }
    }
}

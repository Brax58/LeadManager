using LeadManager.Domain.Interfaces;
using LeadManager.Domain.Models;
using LeadManager.Domain.Models.Entrada;
using LeadManager.Domain.Models.Request;

namespace LeadManager.Service.Services
{
    public class JobService : IJobService
    {
        public readonly IJobRepository _jobRepository;
        public readonly ILogLeadRepository _logLeadRepository;

        public JobService(IJobRepository jobRepository, ILogLeadRepository logLeadRepository)
        {
            _jobRepository = jobRepository;
            _logLeadRepository = logLeadRepository;
        }

        public IEnumerable<Job> GetListJobsByStatus(GetJobsStatusRequest request)
        {
            return _jobRepository.GetListJobsByStatus(request);
        }

        public void UpdateStatusLeadJob(UpdateLeadJobStatusRequest request)
        {
            var job = _jobRepository.GetById(request.IdJob);

            var actualLead = job.Lead;

            var statusText = Enum.GetName(request.StatusLead);

            job.Lead.ApplyingDiscounPrice();
            job.Lead.UpdateStatusLead(statusText);

            _jobRepository.Update(job);

            _logLeadRepository.InsertLogLead(new LeadLog(job.LeadID, statusText, job.Lead.Price, actualLead.Price));
        }
    }
}

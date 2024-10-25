using LeadManager.Domain.Models;
using LeadManager.Domain.Models.Entrada;
using LeadManager.Domain.Models.Request;

namespace LeadManager.Domain.Interfaces
{
    public interface IJobService
    {
        public IEnumerable<Job> GetListJobsByStatus(GetJobsStatusRequest request);
        public void UpdateStatusLeadJob(UpdateLeadJobStatusRequest request);
    }
}

using LeadManager.Domain.Models;
using LeadManager.Domain.Models.Entrada;

namespace LeadManager.Domain.Interfaces
{
    public interface IJobRepository
    {
        public IEnumerable<Job> GetListJobsByStatus(GetJobsStatusRequest request);
        public Job GetById(int? id);
        public void Update(Job request);
    }
}

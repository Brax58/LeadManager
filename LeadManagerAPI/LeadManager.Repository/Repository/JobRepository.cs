using LeadManager.Domain.Interfaces;
using LeadManager.Domain.Models;
using LeadManager.Domain.Models.Entrada;
using LeadManager.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace LeadManager.Repository.Repository
{
    public class JobRepository : BaseContext<Job>, IJobRepository
    {
        public JobRepository(LeadManagerContext context) : base(context) { }

        public IEnumerable<Job> GetListJobsByStatus(GetJobsStatusRequest request)
        {
            var returnRequest = new List<Job>();

            var statusText = Enum.GetName(request.StatusLead);

            returnRequest = GetAll().ToList();

            returnRequest.RemoveAll(x => x.Lead.Status != statusText);
            
            return returnRequest;
        }

        public override IEnumerable<Job> GetAll() =>
            db.Job.Include(x => x.Lead).ToList();

        public override Job GetById(int? id) =>
            db.Job.Include(x => x.Lead).FirstOrDefault(x => x.JobID == id);

        public override void Update(Job request)
        {
            db.Update(request);
        }
    }
}

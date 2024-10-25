using LeadManager.Domain.Interfaces;
using LeadManager.Domain.Models;
using LeadManager.Repository.Context;

namespace LeadManager.Repository.Repository
{
    public class LogLeadRepository : BaseContext<LeadLog>, ILogLeadRepository
    {
        public LogLeadRepository(LeadManagerContext context) : base(context) { }

        public void InsertLogLead(LeadLog request)
        {
            Add(request);
        }
    }
}

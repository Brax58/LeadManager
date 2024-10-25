using LeadManager.Domain.Models;

namespace LeadManager.Domain.Interfaces
{
    public interface ILogLeadRepository
    {
        public void InsertLogLead(LeadLog request);
    }
}

using LeadManager.Domain.Models;
using LeadManager.Domain.Models.Entrada;
using LeadManager.Domain.Models.Request;

namespace LeadManager.Domain.Interfaces
{
    public interface ILeadManagerService
    {
        public IEnumerable<Lead> GetListLeadsByStatus(LeadStatusRequest request);
        public void UpdateStatusLead(UpdateLeadStatusRequest request);
    }
}

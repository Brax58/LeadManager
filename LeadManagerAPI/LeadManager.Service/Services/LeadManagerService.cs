using LeadManager.Domain.Interfaces;
using LeadManager.Domain.Models;
using LeadManager.Domain.Models.Entrada;
using LeadManager.Domain.Models.Request;

namespace LeadManager.Service.Services
{
    public class LeadManagerService : ILeadManagerService
    {
        public readonly ILeadManagerRepository _LeadManagerRepository;

        public LeadManagerService(ILeadManagerRepository leadManagerRepository)
        {
            _LeadManagerRepository = leadManagerRepository;
        }

        public IEnumerable<Lead> GetListLeadsByStatus(LeadStatusRequest request) 
        {
            return _LeadManagerRepository.GetListLeadsByStatus(request);
        }

        public void UpdateStatusLead(UpdateLeadStatusRequest request)
        {
            var lead = _LeadManagerRepository.GetLeadById(request.IdLead);

            lead.ApplyingDiscounPrice();

            _LeadManagerRepository.UpdateStatusLead(lead);
        }
    }
}

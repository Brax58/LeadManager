using LeadManager.Domain.Interfaces;
using LeadManager.Domain.Models;
using LeadManager.Domain.Models.Entrada;
using LeadManager.Domain.Models.Request;

namespace LeadManager.Service.Services
{
    public class LeadManagerService : ILeadManagerService
    {
        public readonly ILeadRepository _LeadRepository;
        public readonly ILogLeadRepository _LogLeadRepository;

        public LeadManagerService(ILeadRepository leadRepository, ILogLeadRepository logLeadRepository)
        {
            _LeadRepository = leadRepository;
            _LogLeadRepository = logLeadRepository;
        }

        public IEnumerable<Lead> GetListLeadsByStatus(LeadStatusRequest request) 
        {
            return _LeadRepository.GetListLeadsByStatus(request);
        }

        public void UpdateStatusLead(UpdateLeadStatusRequest request)
        {
            var lead = _LeadRepository.GetLeadById(request.IdLead);

            var actualPrice = lead.Price;

            var statusText = Enum.GetName(request.StatusLead);

            lead.ApplyingDiscounPrice();

            _LeadRepository.UpdateStatusLead(lead);

            _LogLeadRepository.InsertLogLead(new LeadLog(lead.LeadID, statusText, lead.Price,actualPrice));
        }
    }
}

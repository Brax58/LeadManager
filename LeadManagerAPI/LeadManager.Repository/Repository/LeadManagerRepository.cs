using LeadManager.Domain.Interfaces;
using LeadManager.Domain.Models;
using LeadManager.Domain.Models.Entrada;
using LeadManager.Domain.Models.Request;
using LeadManager.Repository.Context;

namespace LeadManager.Repository.Repository
{
    public class LeadManagerRepository : BaseContext<Lead>, ILeadManagerRepository
    {
        public LeadManagerRepository(LeadManagerContext context) : base(context) { }

        public IEnumerable<Lead> GetListLeadsByStatus(LeadStatusRequest request)
        {
            var returnRequest = new List<Lead>();

            var statusText = Enum.GetName(request.StatusLead);

            returnRequest = GetAll().ToList();

            returnRequest.RemoveAll(x => x.Status != statusText);
            
            return returnRequest;
        }

        public void UpdateStatusLead(Lead request)
        {
            Update(request);
        }

        public Lead GetLeadById(int id)
        {
            return GetById(id);
        }
    }
}

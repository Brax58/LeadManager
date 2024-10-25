﻿using LeadManager.Domain.Models;
using LeadManager.Domain.Models.Entrada;

namespace LeadManager.Domain.Interfaces
{
    public interface ILeadManagerRepository
    {
        public IEnumerable<Lead> GetListLeadsByStatus(LeadStatusRequest request);
        public void UpdateStatusLead(Lead request);
        public Lead GetLeadById(int id);
    }
}
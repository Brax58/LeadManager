using LeadManager.Domain.Enum;

namespace LeadManager.Domain.Models.Request
{
    public class UpdateLeadJobStatusRequest
    {
        public int IdJob { get; set; }
        public EStatus StatusLead { get; set; }

        public UpdateLeadJobStatusRequest()
        {
            StatusLead = new EStatus();
            IdJob = 0;
        }

        public bool ValidateStatus(int status)
        {
            if (status > 0 && status < 4)
                return true;

            return false;
        }

        public void InsertStatus(int status)
        {
            if (status == (int)EStatus.Accepted)
                StatusLead = EStatus.Accepted;
            else if (status == (int)EStatus.Declined)
                StatusLead = EStatus.Declined;
            else if (status == (int)EStatus.Invited)
                StatusLead = EStatus.Invited;
        }

        public void InsertIdJob(int idLead) 
        {
            IdJob = idLead;
        }
    }
}

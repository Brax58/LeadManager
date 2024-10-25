using LeadManager.Domain.Enum;

namespace LeadManager.Domain.Models.Entrada
{
    public class GetJobsStatusRequest
    {
        public EStatus StatusLead { get; private set; }

        public GetJobsStatusRequest()
        {
            StatusLead = new EStatus();
        }

        public bool ValidateStatus(int status) 
        {
            if (status > 0 && status < 4)
                return true;

            return false;
        }

        public void InsertStatus(int status)
        {
            if(status == (int)EStatus.Accepted)
                StatusLead = EStatus.Accepted;
            else if (status == (int)EStatus.Declined)
                StatusLead = EStatus.Declined;
            else if (status == (int)EStatus.Invited)
                StatusLead = EStatus.Invited;
        }
    }
}

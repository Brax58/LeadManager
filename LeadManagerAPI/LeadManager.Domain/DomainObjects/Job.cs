namespace LeadManager.Domain.DomainObjects
{
    public class Job
    {
        public int JobID { get; set; }
        public int LeadID { get; set; }
        public string? JobDescription { get; set; }
        public DateTime JobDate { get; set; }
        public decimal JobPrice { get; set; }
        public string? JobCategory { get; set; }

        // Navigation properties
        public Lead Lead { get; set; }
    }
}

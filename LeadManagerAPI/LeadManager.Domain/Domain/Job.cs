using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadManager.Domain.DomainObjects
{
    [Table("Job")]
    public class Job
    {
        [Key]
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

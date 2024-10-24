using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadManager.Domain.DomainObjects
{
    [Table("Lead")]
    public class Lead
    {
        [Key]
        public int LeadID { get; set; }

        public string? ContactFirstName { get; set; }
        public string? ContactFullName { get; set; }
        public string? ContactPhoneNumber { get; set; }
        public string? ContactEmail { get; set; }
        public string? Suburb { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; } // Values: "Invited", "Accepted", "Declined"
        public DateTime DateCreated { get; set; } = DateTime.Now;

        // Navigation properties
        public ICollection<LeadLog> LeadLogs { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}

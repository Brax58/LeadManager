using Azure.Core;
using System.ComponentModel.DataAnnotations;

namespace LeadManager.Domain.Models
{
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
        public virtual ICollection<LeadLog> LeadLogs { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }

        public void ApplyingDiscounPrice()
        {
            if (Price >= 500 && Status == "Accepted")
                Price = Price - (Price * 0.10m);
        }
    }
}

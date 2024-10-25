using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadManager.Domain.Models
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Suburb { get; set; }

        // Navigation properties
        public virtual ICollection<Lead> Leads { get; set; }
    }
}

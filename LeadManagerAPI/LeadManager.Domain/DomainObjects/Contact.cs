namespace LeadManager.Domain.DomainObjects
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Suburb { get; set; }

        // Navigation properties
        public ICollection<Lead> Leads { get; set; }
    }
}

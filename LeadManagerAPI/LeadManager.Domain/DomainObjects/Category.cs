namespace LeadManager.Domain.DomainObjects
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Lead> Leads { get; set; }
    }
}

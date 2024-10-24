using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadManager.Domain.DomainObjects
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
        public ICollection<Lead> Leads { get; set; }
    }
}

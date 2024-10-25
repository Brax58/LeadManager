using System.ComponentModel.DataAnnotations;

namespace LeadManager.Domain.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}

using LeadManager.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace LeadManager.Repository.Context
{
    public class LeadManagerContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Lead> Lead { get; set; }
        public DbSet<LeadLog> LeadLog { get; set; }

        public LeadManagerContext(DbContextOptions<LeadManagerContext> options) :
            base(options)
        {
        }
    }
}

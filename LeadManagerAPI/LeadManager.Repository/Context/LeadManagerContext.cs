using LeadManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadManager.Repository.Context
{
    public class LeadManagerContext : DbContext
    {
        public LeadManagerContext(DbContextOptions<LeadManagerContext> options) : base(options) =>
            Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurando a tabela Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
                entity.HasKey(e => e.CategoryID);
                entity.Property(e => e.CategoryID).HasColumnName("CategoryID").IsRequired();
                entity.Property(e => e.CategoryName).HasColumnName("CategoryName").HasMaxLength(100).IsRequired();
            });

            // Configurando a tabela Contact
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");
                entity.HasKey(e => e.ContactID);
                entity.Property(e => e.ContactID).HasColumnName("ContactID").IsRequired();
                entity.Property(e => e.FullName).HasColumnName("FullName").HasMaxLength(200).IsRequired();
                entity.Property(e => e.Email).HasColumnName("Email").HasMaxLength(200);
                entity.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(20);
                entity.Property(e => e.Suburb).HasColumnName("Suburb").HasMaxLength(100);
            });

            // Configurando a tabela Lead
            modelBuilder.Entity<Lead>(entity =>
            {
                entity.ToTable("Lead");
                entity.HasKey(e => e.LeadID);
                entity.Property(e => e.LeadID).HasColumnName("LeadID").IsRequired();
                entity.Property(e => e.ContactFirstName).HasColumnName("ContactFirstName").HasMaxLength(100).IsRequired();
                entity.Property(e => e.ContactFullName).HasColumnName("ContactFullName").HasMaxLength(200);
                entity.Property(e => e.ContactPhoneNumber).HasColumnName("ContactPhoneNumber").HasMaxLength(20);
                entity.Property(e => e.ContactEmail).HasColumnName("ContactEmail").HasMaxLength(200);
                entity.Property(e => e.Suburb).HasColumnName("Suburb").HasMaxLength(100);
                entity.Property(e => e.Category).HasColumnName("Category").HasMaxLength(100);
                entity.Property(e => e.Price).HasColumnType("NUMERIC(10,2)");
                entity.Property(e => e.Description).HasColumnName("Description").HasColumnType("TEXT");
                entity.Property(e => e.Status).HasColumnName("Status").HasMaxLength(50);
                entity.Property(e => e.DateCreated).HasColumnName("DateCreated").HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            // Configurando a tabela Job
            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job");
                entity.HasKey(e => e.JobID);
                entity.Property(e => e.JobID).HasColumnName("JobID").IsRequired();
                entity.Property(e => e.JobDescription).HasColumnName("JobDescription").HasColumnType("TEXT");
                entity.Property(e => e.JobDate).HasColumnName("JobDate").HasColumnType("TIMESTAMP");
                entity.Property(e => e.JobPrice).HasColumnType("NUMERIC(10,2)");
                entity.Property(e => e.JobCategory).HasColumnName("JobCategory").HasMaxLength(100);

                // Relacionamento com Lead
                entity.HasOne(e => e.Lead)
                    .WithMany(l => l.Jobs)
                    .HasForeignKey(e => e.LeadID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configurando a tabela LeadLog
            modelBuilder.Entity<LeadLog>(entity =>
            {
                entity.ToTable("LeadLog");
                entity.HasKey(e => e.LogID);
                entity.Property(e => e.LogID).HasColumnName("LogID").IsRequired();
                entity.Property(e => e.Status).HasColumnName("Status").HasMaxLength(50);
                entity.Property(e => e.PriceApplied).HasColumnType("NUMERIC(10,2)");
                entity.Property(e => e.DiscountApplied).HasColumnType("NUMERIC(5,2)");
                entity.Property(e => e.ActionDate).HasColumnName("ActionDate").HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.NotificationSent).HasColumnName("NotificationSent");

                // Relacionamento com Lead
                entity.HasOne(e => e.Lead)
                    .WithMany(l => l.LeadLogs)
                    .HasForeignKey(e => e.LeadID)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Lead> Lead { get; set; }
        public DbSet<LeadLog> LeadLog { get; set; }
    }
}

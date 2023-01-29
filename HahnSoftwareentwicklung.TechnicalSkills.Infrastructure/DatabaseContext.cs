using HahnSoftwareentwicklung.TechnicalSkills.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HahnSoftwareentwicklung.TechnicalSkills.Infrastructure
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base (options) 
        {

        }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Map the batabase 
            modelBuilder.Entity<Person>(o =>
            {
                o.HasKey(x => x.Id);
            });
            //Map the entitie Name with the column Name in the database
            modelBuilder.Entity<Person>().OwnsOne(o => o.Name, conf =>
            {
                conf.Property(x => x.Value).HasColumnName("Name");
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
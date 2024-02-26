using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AdventureWorks_backend.Data
{
    // DataContext class represents the database context
    public class DataContext : DbContext
    {
        // Constructor to initialize DataContext with options
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // Ensure that the database is created
            Database.EnsureCreated();
        }

        // DbSet representing the 'Person' table in the database
        public DbSet<Person> Person => Set<Person>();

        // Method for configuring the model that was discovered by convention during entity type configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the 'Person' entity to map to the 'Person' table
            modelBuilder.Entity<Person>()
                .ToTable("Person");
        }
    }
}

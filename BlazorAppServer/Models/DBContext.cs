using Microsoft.EntityFrameworkCore;

namespace BlazorAppServer.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Models.Group> Groups { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("InMemoryDatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure table and column mappings, relationships, etc. here if needed
            modelBuilder.Entity<Models.Group>().ToTable("groups");
            modelBuilder.Entity<Models.Group>().Property(g => g.Id).HasColumnName("id");
            modelBuilder.Entity<Models.Group>().Property(g => g.Name).HasColumnName("name");
            modelBuilder.Entity<Models.Group>().Property(g => g.Description).HasColumnName("description");
            modelBuilder.Entity<Models.Group>().Property(g => g.CreatedBy).HasColumnName("createdBy");
        }
    }
}

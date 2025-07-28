using Microsoft.EntityFrameworkCore;

namespace GraphWithLabels.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Station> station { get; set; }
        public DbSet<DocTypes> StationNode { get; set; }
        public DbSet<DocTypes> DocInfo { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tell EF Core these are DTOs with no keys
            modelBuilder.Entity<StationNode>().HasNoKey();
            modelBuilder.Entity<DocInfo>().HasNoKey();
        }
    }
}

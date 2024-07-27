using Microsoft.EntityFrameworkCore;

namespace GraphWithLabels.Models
{
    public class Station
    {
        public int stationId { get; set; }  // Maps to the primary key in your table
        public string stataionName { get; set; }  // Maps to the stationName column
    }

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Station> station { get; set; }  // Represents the Stations table

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }

}

using Microsoft.EntityFrameworkCore;

namespace GraphWithLabels.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Station> station { get; set; }
        public DbSet<Layer> layer { get; set; }
        public DbSet<SectionTypes> sectionType { get; set; }
        public DbSet<SectionTypeTreeSectionCharts> sectionTypeTreeSectionChart { get; set; }
        public DbSet<TreeSectionCharts> treeSectionChart { get; set; }
        public DbSet<TreeSectionChartDocuments> treeSectionChartDocuments { get; set; }
        public DbSet<Documents> documents { get; set; }
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}

using System.Data.Entity;

namespace realization_graph_4._5.Models
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
        public DbSet<DocTypes> docTypes { get; set; }

        public ApplicationDbContext() : base("DefaultConnection") {
            this.Configuration.LazyLoadingEnabled = false;
        }

        // If you need to use a custom configuration, use the OnModelCreating method
        // to configure entity mappings.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // You can configure relationships or keys here if necessary
        }
    }
}

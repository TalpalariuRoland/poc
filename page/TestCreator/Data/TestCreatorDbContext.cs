using Microsoft.EntityFrameworkCore;
using TestCreator.Models.Domain;

namespace TestCreator.Data
{
    public class TestCreatorDbContext : DbContext
    {
        public TestCreatorDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PagesName> PagesName { get; set; }
        public DbSet<PageElements> PageElements { get; set; }
        public DbSet<ElementType> ElementTypes { get; set; }
    }
}

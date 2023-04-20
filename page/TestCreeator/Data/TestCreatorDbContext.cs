using Microsoft.EntityFrameworkCore;
using TestCreator.Models.Domain;

namespace TestCreeator.Data
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



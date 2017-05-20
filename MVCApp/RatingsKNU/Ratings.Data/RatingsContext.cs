using System.Data.Entity;
using Ratings.Data.Entities;

namespace Ratings.Data
{
    public class RatingsContext : DbContext
    {
        public RatingsContext()
            : base("name=RatingsContext")
        {
        }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Index> Indexes { get; set; }
        public DbSet<IndexValue> IndexValues { get; set; }
        public DbSet<ListLine> ListLines { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

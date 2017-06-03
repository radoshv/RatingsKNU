using System.Data.Entity;
using Ratings.Data.Entities;
using Ratings.Data.Migrations;

namespace Ratings.Data
{
    public class RatingsContext : DbContext
    {
        public RatingsContext()
            : base("name=RatingsContext")
        {
        }

        static RatingsContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RatingsContext, Configuration>());
        }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Index> Indices { get; set; }
        public DbSet<IndexValue> IndexValues { get; set; }
        public DbSet<ListLine> ListLines { get; set; }
        public DbSet<Rating> Ratings { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

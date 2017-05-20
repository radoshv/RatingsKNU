using Ratings.Data.Entities;

namespace Ratings.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ratings.Data.RatingsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Ratings.Data.RatingsContext context)
        {
            if (context.Faculties.Any()) return;

            context.Faculties.AddRange(new []
            {
                new Faculty {Id = Guid.Parse("{CA767C7C-91CB-4536-8549-9DF5F3B638A7}"), Name = "ФІТ"},
                new Faculty { Id = Guid.Parse("{6305E47E-BA92-428C-B4FD-EE0482635FFC}"), Name = "Факультет кібернетики" }
            });
        }
    }
}

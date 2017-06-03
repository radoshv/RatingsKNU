using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ratings.Data.Entities;
using Ratings.Data.Managers;

namespace Ratings.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RatingsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RatingsContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));

            if (!context.Faculties.Any())
            {
                context.Faculties.AddRange(new[]
                {
                    new Faculty {Id = Guid.Parse("{CA767C7C-91CB-4536-8549-9DF5F3B638A7}"), Name = "ФІТ"},
                    new Faculty
                    {
                        Id = Guid.Parse("{6305E47E-BA92-428C-B4FD-EE0482635FFC}"),
                        Name = "Факультет кібернетики"
                    }
                });
            }
            const string adminRoleName = "Admin";

            var roles = new List<string>
            {
                adminRoleName
            };

            foreach (var role in roles) // create roles
            {
                if (roleManager.RoleExists(role)) continue;
                var newRole = new ApplicationRole(role);
                roleManager.Create(newRole);
            }
            const string adminName = "admin@knu.ua";
            const string adminPass = "pass123";

            var admin = userManager.FindByName(adminName);
            if (admin == null) // create administrator
            {
                admin = new ApplicationUser { UserName = adminName, Email = adminName };
                userManager.Create(admin, adminPass);
                userManager.SetLockoutEnabled(admin.Id, false);
            }
            var rolesForUser = userManager.GetRoles(admin.Id);
            if (!rolesForUser.Contains(adminRoleName))
            {
                userManager.AddToRole(admin.Id, adminRoleName);
            }

            base.Seed(context);
        }
    }
}

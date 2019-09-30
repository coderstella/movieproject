using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using movieproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Database
{
    public static class DbContextExtension
    {
        public static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this MovieContext context)
        {
            // Seed data here - e.g.
            /*
            if (!context.Categories.Any())
            {
                List<Category> catList = new List<Category>();
                catList.Add(new Category { Title = "Action" });
                catList.Add(new Category { Title = "Adventure" });
                context.Categories.AddRange(catList);
                context.SaveChanges();
            }
            */
        }
    }
}

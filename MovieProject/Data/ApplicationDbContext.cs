using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieProject.Models;

namespace MovieProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=OnlineMovies;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
            });
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Title = "Action" },
                new Category { Id = 2, Title = "Adventure" },
                new Category { Id = 3, Title = "Animation" },
                new Category { Id = 4, Title = "Comedy" },
                new Category { Id = 5, Title = "Crime" },
                new Category { Id = 6, Title = "Drama" },
                new Category { Id = 7, Title = "Family" },
                new Category { Id = 8, Title = "Fantasy" },
                new Category { Id = 9, Title = "History" },
                new Category { Id = 10, Title = "Horror" },
                new Category { Id = 11, Title = "Romance" },
                new Category { Id = 12, Title = "Sci-Fi" },
                new Category { Id = 13, Title = "Thriller" }
                );
        }
    }
}

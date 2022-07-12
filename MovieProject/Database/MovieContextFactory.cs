using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Database
{
    public class MovieContextFactory : IDesignTimeDbContextFactory<MovieContext>
    {
        public MovieContextFactory()
        {}

        public MovieContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MovieContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=OnlineMovieShop;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new MovieContext(builder.Options);
        }
    }
}

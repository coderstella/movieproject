using Microsoft.EntityFrameworkCore;
using movieproject.Data;
using movieproject.Models;
using movieproject.Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MovieContext _context;
        public CategoryRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await _context.Categories.Include(category => category.Movies).ToListAsync();

            return categories;
        }
    }
}

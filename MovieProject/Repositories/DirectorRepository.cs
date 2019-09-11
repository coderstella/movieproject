using Microsoft.EntityFrameworkCore;
using MovieProject.Data;
using MovieProject.Models;
using MovieProject.Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly ApplicationDbContext _context;
        public DirectorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Director>> GetAllAsync()
        {
            var directors = await _context.Directors.ToListAsync();

            return directors;
        }

        public async Task<Director> GetByIdAsync(int id)
        {
            var director = await _context.Directors.Include(m => m.Movies).SingleAsync(d => d.Id == id);

            return director;
        }
        public async Task<int> Add(Director director)
        {
            _context.Directors.Add(director);
            await _context.SaveChangesAsync();

            return director.Id;
        }

        public async Task<Boolean> Update(Director director)
        {
            var directorInDb = _context.Directors.Single(d => d.Id == director.Id);

            if (directorInDb != null)
            {
                _context.Entry<Director>(directorInDb).State = EntityState.Detached;
                _context.Directors.Update(director);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Boolean> DeleteAsync(int id)
        {
            var directorInDb = _context.Directors.Find(id);

            if (directorInDb != null)
            {
                _context.Entry<Director>(directorInDb).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

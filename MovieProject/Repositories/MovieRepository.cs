﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieproject.Database;
using movieproject.Dtos;
using movieproject.Models;
using movieproject.Repositories.Interfaces;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using ReflectionIT.Mvc;
using Microsoft.AspNetCore.Routing;

namespace movieproject.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;
        public MovieRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task<PagingList<Movie>> GetPagingwithMoviesAsync(int? pageCount, int? itemPerPage, string category)
        {
            var movies = _context.Movies.AsNoTracking().OrderBy(m => m.Category);
            if (category != null)
            {
                movies = movies.Where(m => m.Category.Title == category).OrderBy(m => m.Name);
            }

            var paginatedList = await PagingList.CreateAsync(movies, itemPerPage ?? 3, pageCount ?? 1);
            paginatedList.RouteValue = new RouteValueDictionary
            {
                {  "category", category }
            };
            return paginatedList;
        }

        public async Task<IEnumerable<Movie>> GetFamousMovies()
        {
            return await _context.Movies.OrderByDescending(m => m.StarRate).Take(4).ToListAsync();
        }

        // New Director
        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            var movies = await _context.Movies.ToListAsync();

            return movies;
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            var movie = await _context.Movies.Include(c => c.Category).Include(d => d.Director).FirstOrDefaultAsync(m => m.Id == id);

            return movie;
        }

        public async Task<Movie> GetOneByIdAsync(int id)
        {
            var movie = await _context.Movies.SingleOrDefaultAsync(m => m.Id == id);

            return movie;
        }

        public async Task<int> Add(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie.Id;
        }

        public async Task<Boolean> Update(Movie movie)
        {
            var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
            
            if(movieInDb != null)
            {
                _context.Entry<Movie>(movieInDb).State = EntityState.Detached;
                _context.Movies.Update(movie);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Boolean> DeleteAsync(int id)
        {
            var movieInDb = _context.Movies.Find(id);

            if (movieInDb != null)
            {
                _context.Entry<Movie>(movieInDb).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Movie> GetSingleAsync(int id)
        {
            var singleMovie = await _context.Movies.SingleAsync(m => m.Id == id);

            return singleMovie;
        }

    }
}

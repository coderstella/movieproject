using Microsoft.AspNetCore.Mvc;
using MovieProject.Models;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<PagingList<Movie>> GetPagingwithMoviesAsync(int? pageCount, int? itemPerPage, string category);

        Task<IEnumerable<Movie>> GetAllAsync();

        Task<IEnumerable<Movie>> GetFamousMovies();

        Task<Movie> GetByIdAsync(int id);

        Task<Movie> GetOneByIdAsync(int id);

        Task<int> Add(Movie movie);

        Task<Boolean> Update(Movie movie);

        Task<Boolean> DeleteAsync(int id);
    }
}

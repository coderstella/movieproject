using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movieproject.Dtos;
using movieproject.Models;
using movieproject.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Services
{
    public interface IMovieLibraryService
    {
        Task<MovieListViewModel> GetAllMovieswithPagingAsync(int? pageCount, int? itemPerPage, string category);

        Task<MovieListViewModel> GetAllMoviesAsync();

        Task<IEnumerable<Movie>> GetAllMovies();

        Task<MovieDetailsViewModel> GetMovieByIdAsync(int id);

        Task<int> CreateMovie(CreateUpdateMovieDto movie, IFormFile posterImage);

        Task<Boolean> UpdateMovie(CreateUpdateMovieDto movieDto, IFormFile posterImage);

        Task<Boolean> DeleteMovie(int id);

        Task<IEnumerable<Category>> GetAllCategories();

        Task<IEnumerable<Director>> GetAllDirectors();

        Task<DirectorListViewModel> GetAllDirectorsList();

        Task<DirectorDetailsViewModel> GetDirectorById(int id);

        Task<CreateUpdateMovieDto> GetMovieToUpdate(int id);

        Task<int> AddDirectorReturnId(Director director);

        Task<int> CreaterDirector(Director director);

        Task<CategoryMovieCountViewModel> GetAllCategoriesMovies();

        Task<Boolean> UpdateDirector(Director director);

        Task<Boolean> DeleteDirector(int id);

        Task<Movie> GetSingleMovieAsync(int id);
    }
}

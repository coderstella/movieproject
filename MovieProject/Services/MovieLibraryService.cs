using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2;
using movieproject.Data;
using movieproject.Dtos;
using movieproject.Models;
using movieproject.Repositories;
using movieproject.Repositories.Interfaces;
using movieproject.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Services
{
    public class MovieLibraryService : IMovieLibraryService
    {
        private readonly IMovieRepository _movieRepository;

        private readonly ICategoryRepository _categoryRepository;

        private readonly IDirectorRepository _directorRepository;

        private readonly IFileUploadService _fileUploadService;

        private readonly IMapper _mapper;
        public MovieLibraryService(IMovieRepository movieRepository, IDirectorRepository directorRepository, ICategoryRepository categoryRepository, IMapper mapper, IFileUploadService fileUploadService)
        {
            _movieRepository = movieRepository;
            _directorRepository = directorRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _fileUploadService = fileUploadService;
        }


        public async Task<MovieListViewModel> GetAllMovieswithPagingAsync(int? pageCount, int? itemPerPage, string category)
        {
            var movies = await _movieRepository.GetPagingwithMoviesAsync(pageCount, itemPerPage, category);

            var viewModel = new MovieListViewModel
            {
                Movies = movies
            };

            return viewModel;
        }

        public async Task<MovieListViewModel> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetFamousMovies();

            var viewModel = new MovieListViewModel
            {
                Movies = movies
            };

            return viewModel;
        }

        // New Director
        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<MovieDetailsViewModel> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            var viewModel = new MovieDetailsViewModel
            {
                Movie = movie
            };

            return viewModel;
        }

        public async Task<CreateUpdateMovieDto> GetMovieToUpdate(int id)
        {
            var movie = await _movieRepository.GetOneByIdAsync(id);

            return _mapper.Map<CreateUpdateMovieDto>(movie);
        }

        public async Task<int> CreateMovie(CreateUpdateMovieDto movieDto, IFormFile posterImage)
        {
            if (posterImage != null)
            {
                movieDto.Poster = _fileUploadService.UploadFile(posterImage, "upload");
            }

            var newMovie = _mapper.Map<Movie>(movieDto);

            return await _movieRepository.Add(newMovie);
        }

        public async Task<Boolean> UpdateMovie(CreateUpdateMovieDto movieDto, IFormFile posterImage)
        {
            if (posterImage != null)
            {
                movieDto.Poster = _fileUploadService.UploadFile(posterImage, "upload");
            }

            var updateMovie = _mapper.Map<Movie>(movieDto);

            return await _movieRepository.Update(updateMovie);
        }

        public async Task<Boolean> DeleteMovie(int id)
        {
            var deletemovie = await _movieRepository.DeleteAsync(id);

            return deletemovie;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAllAsync();
        }

        // Category View Component
        public async Task<CategoryMovieCountViewModel> GetAllCategoriesMovies()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoryMovieCountList = _mapper.Map<IEnumerable<CategoryMovieCountDto>>(categories);
            var viewModel = new CategoryMovieCountViewModel
            {
                CategoryMoviesCount = categoryMovieCountList
            };

            return viewModel;
        }

        public async Task<IEnumerable<Director>> GetAllDirectors()
        {
            return await _directorRepository.GetAllAsync();
        }

        public async Task<DirectorListViewModel> GetAllDirectorsList()
        {
            var directors = await _directorRepository.GetAllAsync();

            var viewModel = new DirectorListViewModel
            {
                Directors = directors
            };

            return viewModel;
        }

        // director details
        public async Task<DirectorDetailsViewModel> GetDirectorById(int id)
        {
            var director = await _directorRepository.GetByIdAsync(id);

            var movies = await _movieRepository.GetAllAsync();

            var viewModel = new DirectorDetailsViewModel
            {
                Director = director,
                Movies = movies
            };

            return viewModel;
        }

        // movie form
        public async Task<int> AddDirectorReturnId(Director director)
        {
            return await _directorRepository.Add(director);
        }

        public async Task<int> CreaterDirector(Director director)
        {
            return await _directorRepository.Add(director);
        }

        public async Task<Boolean> UpdateDirector(Director director)
        {
            var updateDirector = await _directorRepository.Update(director);

            return updateDirector;
        }

        public async Task<Boolean> DeleteDirector(int id)
        {
            var deleteDirector = await _directorRepository.DeleteAsync(id);

            return deleteDirector;
        }

        // shopping cart
        public async Task<Movie> GetSingleMovieAsync(int id)
        {
            return await _movieRepository.GetSingleAsync(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieProject.Data;
using MovieProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Components
{
    [ViewComponent(Name = "FamousMovies")]
    public class FamousMoviesViewComponent : ViewComponent
    {
        private readonly IMovieLibraryService _movieLibraryService;
        public FamousMoviesViewComponent(IMovieLibraryService movieLibraryService)
        {
            _movieLibraryService = movieLibraryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var movies = await _movieLibraryService.GetAllMoviesAsync();

            return View(movies);
        }
    }
}

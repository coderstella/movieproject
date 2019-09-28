using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieproject.Data;
using movieproject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Components
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

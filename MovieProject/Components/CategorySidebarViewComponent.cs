using Microsoft.AspNetCore.Mvc;
using MovieProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Components
{
    [ViewComponent(Name = "CategorySidebar")]
    public class CategorySidebarViewComponent : ViewComponent
    {
        private readonly IMovieLibraryService _movieLibraryService;
        public CategorySidebarViewComponent(IMovieLibraryService movieLibraryService)
        {
            _movieLibraryService = movieLibraryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _movieLibraryService.GetAllCategoriesMovies();
            return View(result);
        }
    }
}

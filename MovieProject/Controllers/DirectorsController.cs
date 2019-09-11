using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieProject.Data;
using MovieProject.Models;
using MovieProject.Services;
using MovieProject.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieProject.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly IMovieLibraryService _movieLibraryService;

        public DirectorsController(IMovieLibraryService movieLibraryService)
        {
            _movieLibraryService = movieLibraryService;
        }

        // GET: Directors
        public async Task<IActionResult> Index()
        {
            var directors = await _movieLibraryService.GetAllDirectorsList();

            return View(directors);
        }

        public async Task<IActionResult> Details(int id)
        {
            var director = await _movieLibraryService.GetDirectorById(id);

            return View(director);
        }

        public async Task<IActionResult> New()
        {
            var movies = await _movieLibraryService.GetAllMovies();

            DirectorFormViewModel model = new DirectorFormViewModel
            {
                Director = new Director(),
                Movies = movies
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Director director)
        {
            if (director.Id == 0)
            {
                // New director
                var directorId = await _movieLibraryService.AddDirectorReturnId(director);
                if (directorId > 0)
                {
                    return RedirectToAction("Index", "Directors");
                }
            }
            else
            {
                //Update existing director
                if (await _movieLibraryService.UpdateDirector(director))
                {
                    RedirectToAction("Index", "Directors");
                }
                else
                {
                    RedirectToAction("Details", "Directors", new { Id = director.Id });
                }
            }

            return RedirectToAction("Index", "Directors");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (await _movieLibraryService.DeleteDirector(id))
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
            else
            {
                RedirectToAction("Index", "Directors");
            }

            return RedirectToAction("Index", "Directors");
        }
    }
}

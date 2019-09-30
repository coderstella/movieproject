using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using movieproject.Database;
using movieproject.Dtos;
using movieproject.Models;
using movieproject.Services;
using movieproject.ViewModels;

namespace movieproject.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class MoviesController : Controller
    {
        private readonly IMovieLibraryService _movieLibraryService;

        public MoviesController(IMovieLibraryService movieLibraryService)
        {
            _movieLibraryService = movieLibraryService;
        }

        //GET: Movies
        public async Task<IActionResult> Index(int? page, int? itemPerPage, string category)
        {
            var movies = await _movieLibraryService.GetAllMovieswithPagingAsync(page, itemPerPage, category);

            return View(movies);
        }

        //GET: /Movies/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieLibraryService.GetMovieByIdAsync(id);

            return View(movie);
        }

        //GET: /Movies/New
        public async Task<IActionResult> New()
        {
            var categories = await _movieLibraryService.GetAllCategories();
            var directors = await _movieLibraryService.GetAllDirectors();

            var viewModel = new MovieFormViewModel
            {
                Movie = new CreateUpdateMovieDto(),
                Categories = categories,
                Directors = directors
            };

            return View(viewModel);
        }

        //GET: /Movies/Edit/2
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieLibraryService.GetMovieToUpdate(id);
            var categories = await _movieLibraryService.GetAllCategories();
            var directors = await _movieLibraryService.GetAllDirectors();

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Directors = directors,
                Categories = categories
            };

            return View("New", viewModel);
        }

        private IActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CreateUpdateMovieDto movie, IFormFile posterImage, string newDirectorName)
        {
            if (movie.DirectorId <= 0 && !string.IsNullOrWhiteSpace(newDirectorName))
            {
                var newDirector = new Director { Name = newDirectorName };
                movie.DirectorId = await _movieLibraryService.AddDirectorReturnId(newDirector);
            }

            if (movie.Id == 0)
            {
                // New movie
                var movieId = await _movieLibraryService.CreateMovie(movie, posterImage);
                if (movieId > 0)
                {
                    return RedirectToAction("Index", "Movies");
                }
            }
            else
            {
                //Update existing movie
                if(await _movieLibraryService.UpdateMovie(movie, posterImage))
                {
                    RedirectToAction("Index", "Movies");
                }else
                {
                    RedirectToAction("Details", "Movies", new { Id = movie.Id });
                }
            }

            return RedirectToAction("Index", "Movies");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (await _movieLibraryService.DeleteMovie(id))
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
            else
            {
                RedirectToAction("Index", "Movies");
            }

            return RedirectToAction("Index", "Movies");
        }
    }
}
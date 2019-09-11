using Microsoft.AspNetCore.Http;
using MovieProject.Dtos;
using MovieProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.ViewModels
{
    public class MovieFormViewModel
    {
        public CreateUpdateMovieDto Movie { get; set; }
        public string NewDirectorName { get; set; }
        public IEnumerable<Director> Directors { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}

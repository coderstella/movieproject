using Microsoft.AspNetCore.Http;
using movieproject.Dtos;
using movieproject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.ViewModels
{
    public class MovieFormViewModel
    {
        public CreateUpdateMovieDto Movie { get; set; }
        public string NewDirectorName { get; set; }
        public IEnumerable<Director> Directors { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}

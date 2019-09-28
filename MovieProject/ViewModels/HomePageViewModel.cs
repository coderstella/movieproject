using movieproject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Movie> FavouriteMovies { get; set; }
    }
}

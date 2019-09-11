using MovieProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.ViewModels
{
    public class SearchMovieViewModel
    {
        [Required]
        [DisplayName("Serach")]
        public string SearchText { get; set; }

        public IEnumerable<Movie> MoveList { get; set; }
    }
}

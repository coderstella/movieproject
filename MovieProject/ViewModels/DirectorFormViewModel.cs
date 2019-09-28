using movieproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.ViewModels
{
    public class DirectorFormViewModel
    {
        public Director Director { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
    }
}

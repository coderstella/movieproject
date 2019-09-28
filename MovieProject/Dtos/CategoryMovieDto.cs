using movieproject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Dtos
{
    public class CategoryMovieCountDto
    {
        public string Name { get; set; }
        public int MoviesCount { get; set; }
    }
}

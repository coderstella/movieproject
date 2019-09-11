using MovieProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Dtos
{
    public class CategoryMovieCountDto
    {
        public string Name { get; set; }
        public int MoviesCount { get; set; }
    }
}

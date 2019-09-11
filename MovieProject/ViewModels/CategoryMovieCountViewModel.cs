using MovieProject.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.ViewModels
{
    public class CategoryMovieCountViewModel
    {
        public IEnumerable<CategoryMovieCountDto> CategoryMoviesCount { get; set; }
    }
}

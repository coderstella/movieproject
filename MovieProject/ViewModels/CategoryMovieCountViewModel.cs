using movieproject.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.ViewModels
{
    public class CategoryMovieCountViewModel
    {
        public IEnumerable<CategoryMovieCountDto> CategoryMoviesCount { get; set; }
    }
}

﻿using AutoMapper;
using movieproject.Dtos;
using movieproject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Models
{
    public class MyMappingProfiles : Profile
    {
        public MyMappingProfiles()
        {
            CreateMap<Movie, CreateUpdateMovieDto>().ReverseMap();

            // For Category left menu
            CreateMap<Category, CategoryMovieCountDto>()
                .ForMember(m => m.Name, opt => opt.MapFrom(d => d.Title))
                .ForMember(m => m.MoviesCount, opt => opt.MapFrom(d => d.Movies.Count));

        }
    }
}

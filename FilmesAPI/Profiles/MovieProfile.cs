﻿using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<Movie, ReadMovieDto>()
            .ForMember(movieDto => movieDto.Sessions,
            opt => opt.MapFrom(movie => movie.Sessions));
        CreateMap<UpdateMovieDto, Movie>();
    }
}

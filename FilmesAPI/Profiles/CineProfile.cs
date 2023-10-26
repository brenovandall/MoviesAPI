using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FislmesAPI.Data.Dtos;

namespace FilmesAPI.Profiles;

public class CineProfile : Profile
{
    public CineProfile()
    {
        CreateMap<CreateCineDto, Cine>();
        CreateMap<Cine, ReadCineDto>();
        CreateMap<UpdateCineDto, Cine>();
    }
    
}

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
        CreateMap<Cine, ReadCineDto>()
            .ForMember(cineDto => cineDto.Address, 
            opt => opt.MapFrom(cine => cine.Address))
            .ForMember(cineDto => cineDto.Sessions,
            opt => opt.MapFrom(cine => cine.Sessions)); ;
        CreateMap<UpdateCineDto, Cine>();
    }
    
}

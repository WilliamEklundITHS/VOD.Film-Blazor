using AutoMapper;
using VOD.Film.Common.DTOs;
using VOD.Film.Data.Entities.Models;

namespace VOD.Film.Data.Mappings
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDTO>();

            CreateMap<Genre, FilmGenre>()
            .ForMember(dest => dest.Genre, src => src.MapFrom(src => src))
            .ForMember(dest => dest.GenreId, src => src.MapFrom(src => src.Id));

            CreateMap<FilmGenre, GenreDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Genre.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Genre.Name));


        }
    }
}

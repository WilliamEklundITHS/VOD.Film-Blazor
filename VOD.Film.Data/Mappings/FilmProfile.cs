using AutoMapper;
using VOD.Film.Common.DTOs;
using VOD.Film.Data.Entities.Models;

namespace VOD.Film.Data.Mappings
{
    public class FilmProfile : Profile
    {

        public FilmProfile()
        {
            CreateMap<FilmModel, FilmDTO>().ReverseMap();
            CreateMap<FilmModel, FilmModel>();
            CreateMap<FilmRequestDTO, FilmModel>();

            CreateMap<FilmModel, FilmRequestDTO>()
      .ForMember(dest => dest.GenreIds, opt => opt.MapFrom(src =>
       src.FilmGenres!.Select(genre => genre.GenreId)))
      .ForMember(dest => dest.SimilarFilmsIds, opt => opt.MapFrom(src =>
       src.SimilarFilms!.Select(sf => sf.SimilarFilmId)));

            CreateMap<FilmDTO, FilmRequestDTO>()
            .ForMember(dest => dest.GenreIds, opt => opt.MapFrom(src =>
             src.FilmGenres!.Select(genre => genre.Id)))
            .ForMember(dest => dest.SimilarFilmsIds, opt => opt.MapFrom(src =>
             src.SimilarFilms!.Select(sf => sf.SimilarFilmId)));


            //For adding/updating film
            CreateMap<FilmModel, SimilarFilmModel>()
                .ForMember(dest => dest.SimilarFilmId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SimilarFilm, opt => opt.MapFrom(src => src));


            CreateMap<SimilarFilmModel, SimilarFilmDTO>()
          .ForMember(dest => dest.SimilarFilmId, opt => opt.MapFrom(src => src.SimilarFilm.Id))
          .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.SimilarFilm.Title))
          .ForMember(dest => dest.FilmPosterUrl, opt => opt.MapFrom(src => src.SimilarFilm.FilmPosterUrl));

        }
    }
}

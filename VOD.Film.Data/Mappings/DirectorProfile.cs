using AutoMapper;
using VOD.Film.Common.DTOs;
using VOD.Film.Data.Entities.Models;

namespace VOD.Film.Data.Mappings
{
    public class DirectorProfile : Profile
    {
        public DirectorProfile()
        {
            CreateMap<DirectorRequestDTO, Director>().ForMember(dest => dest.Film, opt => opt.Ignore()).ReverseMap();
            CreateMap<Director, DirectorDTO>();

            CreateMap<DirectorRequestDTO, DirectorDTO>();


        }
    }
}

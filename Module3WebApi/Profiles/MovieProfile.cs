using AutoMapper;
using Module3WebApi.Model;
using Module3WebApi.Model.DTOs.MovieDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module3WebApi.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            // Movie<->MovieReadDTO
            CreateMap<Movie, MovieReadDTO>()
                    .ForMember(adto => adto.Franchise, opt => opt
                    .MapFrom(a => a.FranchiseId))
                    .ForMember(adto => adto.Characters, opt => opt
                    .MapFrom(a => a.Characters.Select(a => a.Id).ToArray()))
                    .ReverseMap();
            // Movie<->MovieCreateDTO
            CreateMap<Movie, MovieCreateDTO>();
            //.ReverseMap();
            //Movie <->MovieUpdateDTO
            CreateMap<Movie, MovieUpdateDTO>()
                .ForMember(adto => adto.Franchise, opt => opt
                 .MapFrom(a => a.FranchiseId))
                .ReverseMap();
        }

    }
}

using AutoMapper;
using Module3WebApi.Model;
using Module3WebApi.Model.DTOs.CharacterDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module3WebApi.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            // Character<->CharacterReadDTO
            CreateMap<Character, CharacterReadDTO>()
            .ReverseMap();
            // Character<->CharacterCreateDTO
            CreateMap<Character, CharacterCreateDTO>()
            .ReverseMap();
            // Character<->CharacterUpdateDTO
            CreateMap<Character, CharacterUpdateDTO>()
                    .ReverseMap();

        }

    }
}

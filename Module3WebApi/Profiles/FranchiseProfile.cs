using AutoMapper;
using Module3WebApi.Model;
using Module3WebApi.Model.DTOs.FranchiceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module3WebApi.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            // Franchise<->FranchiseReadDTO
            CreateMap<Franchise, FranchiseReadDTO>()
                    .ReverseMap();
            // Franchise<->FranchiseCreateDTO
            CreateMap<Franchise, FranchiseCreateDTO>()
                    .ReverseMap();
            // Franchise<->FranchiseUpdateDTO
            CreateMap<Franchise, FranchiseUpdateDTO>()
                   .ReverseMap();
        }
    }
}

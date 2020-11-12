using AutoMapper;
using Skinet.API.Dtos;
using Skinet.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.API.Configurations.Profiles
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}

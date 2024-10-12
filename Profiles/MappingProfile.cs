using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AddressStandardizationService.models;
namespace AddressStandardizationService.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressRequest, AddressResponse>();
        }
    }
}

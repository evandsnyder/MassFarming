using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassFarming
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Farm, FarmDto>();
            CreateMap<Address, AddressDto>();

            CreateMap<AddressForCreationDto, Address>();
            CreateMap<FarmForUpdateDto, Farm>();
            CreateMap<FarmTypeForCreationDto, FarmType>();
            CreateMap<SchedulesForCreationDto, Schedule>();
            CreateMap<IsAForCreationDto, IsA>();
        }
    }
}

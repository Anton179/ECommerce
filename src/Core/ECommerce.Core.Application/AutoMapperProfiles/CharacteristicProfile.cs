using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Core.DataAccess.Dtos.CharacteristicsDtos;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Entities.CharacteristicsValue;

namespace ECommerce.Core.Application.AutoMapperProfiles
{
    public class CharacteristicProfile : Profile
    {
        public CharacteristicProfile()
        {
            CreateMap<CharacteristicNumberType, CharacteristicValueDto>();
            CreateMap<CharacteristicStringType, CharacteristicValueDto>();
            CreateMap<Characteristic, CharacteristicDto>();
        }
    }
}

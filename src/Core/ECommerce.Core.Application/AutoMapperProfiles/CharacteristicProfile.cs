using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Core.DataAccess.Dtos.CharacteristicsDtos;
using ECommerce.Core.DataAccess.Entities.Characteristics;

namespace ECommerce.Core.Application.AutoMapperProfiles
{
    public class CharacteristicProfile : Profile
    {
        public CharacteristicProfile()
        {
            CreateMap<Characteristic, CharacteristicDto>();
        }
    }
}

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
            CreateMap<CharacteristicValue, CharacteristicValueDto>()
                .IncludeAllDerived();

            CreateMap<CharacteristicDecimalType, CharacteristicValueDto>()
                .ForMember(ch => ch.Name, source => source.MapFrom(ch => ch.Characteristic.Name))
                .ForMember(ch => ch.Type, exp => exp.MapFrom(ch => typeof(decimal)))
                .ForMember(ch => ch.Value, exp => exp.MapFrom(ch => ch.ValueDec));
                

            CreateMap<CharacteristicStringType, CharacteristicValueDto>()
                .ForMember(ch => ch.Name, source => source.MapFrom(ch => ch.Characteristic.Name))
                .ForMember(ch => ch.Type, exp => exp.MapFrom(ch => typeof(string)))
                .ForMember(ch => ch.Value, exp => exp.MapFrom(ch => ch.ValueStr));

            CreateMap<CharacteristicIntType, CharacteristicValueDto>()
                .ForMember(ch => ch.Name, source => source.MapFrom(ch => ch.Characteristic.Name))
                .ForMember(ch => ch.Type, exp => exp.MapFrom(ch => typeof(int)))
                .ForMember(ch => ch.Value, exp => exp.MapFrom(ch => ch.ValueInt));
                

            CreateMap<CharacteristicDateType, CharacteristicValueDto>()
                .ForMember(ch => ch.Name, source => source.MapFrom(ch => ch.Characteristic.Name))
                .ForMember(ch => ch.Type, exp => exp.MapFrom(ch => typeof(DateTime)))
                .ForMember(ch => ch.Value, exp => exp.MapFrom(ch => ch.ValueDate.ToString("yyyy-MM-dd")));

            CreateMap<Characteristic, CharacteristicDto>();
        }
    }
}

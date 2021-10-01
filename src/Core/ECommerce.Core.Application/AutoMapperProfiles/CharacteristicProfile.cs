using AutoMapper;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Entities.CharacteristicsValue;
using System;
using ECommerce.Core.Application.Infrastructure.Dtos.CharacteristicsDtos;

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
                .ForMember(ch => ch.Type, exp => exp.MapFrom(ch => typeof(decimal).Name))
                .ForMember(ch => ch.Value, exp => exp.MapFrom(ch => ch.ValueDec));


            CreateMap<CharacteristicStringType, CharacteristicValueDto>()
                .ForMember(ch => ch.Name, source => source.MapFrom(ch => ch.Characteristic.Name))
                .ForMember(ch => ch.Type, exp => exp.MapFrom(ch => typeof(string).Name))
                .ForMember(ch => ch.Value, exp => exp.MapFrom(ch => ch.ValueStr));

            CreateMap<CharacteristicIntType, CharacteristicValueDto>()
                .ForMember(ch => ch.Name, source => source.MapFrom(ch => ch.Characteristic.Name))
                .ForMember(ch => ch.Type, exp => exp.MapFrom(ch => typeof(int).Name))
                .ForMember(ch => ch.Value, exp => exp.MapFrom(ch => ch.ValueInt));


            CreateMap<CharacteristicDateType, CharacteristicValueDto>()
                .ForMember(ch => ch.Name, source => source.MapFrom(ch => ch.Characteristic.Name))
                .ForMember(ch => ch.Type, exp => exp.MapFrom(ch => typeof(DateTime).Name))
                .ForMember(ch => ch.Value, exp => exp.MapFrom(ch => ch.ValueDate.ToString("yyyy-MM-dd")));

            CreateMap<CharacteristicValueDto, CharacteristicValue>()
                .IncludeAllDerived();

            CreateMap<CharacteristicValueDto, CharacteristicDecimalType>()
                .ForMember(ch => ch.ValueDec, source => source.MapFrom(ch => ch.Value));

            CreateMap<CharacteristicValueDto, CharacteristicStringType>()
                .ForMember(ch => ch.ValueStr, source => source.MapFrom(ch => ch.Value));

            CreateMap<CharacteristicValueDto, CharacteristicIntType>()
                .ForMember(ch => ch.ValueInt, source => source.MapFrom(ch => ch.Value));

            CreateMap<CharacteristicValueDto, CharacteristicDateType>()
                .ForMember(ch => ch.ValueDate, source => source.MapFrom(ch => ch.Value));

            CreateMap<Characteristic, CharacteristicDto>()
                .ForMember(ch => ch.CharacteristicId, source => source.MapFrom(ch => ch.Id));
        }
    }
}

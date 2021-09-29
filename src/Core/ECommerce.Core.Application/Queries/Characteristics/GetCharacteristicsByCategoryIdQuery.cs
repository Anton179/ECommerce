using ECommerce.Core.Application.Infrastructure.Dtos.CharacteristicsDtos;
using MediatR;
using System;
using System.Collections.Generic;

namespace ECommerce.Core.Application.Queries.Characteristics
{
    public class GetCharacteristicsByCategoryIdQuery : IRequest<List<CharacteristicDto>>
    {
        public Guid CategoryId { get; set; }
    }
}

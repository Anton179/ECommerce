using ECommerce.Core.DataAccess.Enums;
using MediatR;
using System;

namespace ECommerce.Core.Application.Commands.ProductCommands
{
    public class BaseCreateUpdateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryEnum Category { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public string ImageUrl { get; set; }
        public string CharacteristicsValue { get; set; }
    }
}

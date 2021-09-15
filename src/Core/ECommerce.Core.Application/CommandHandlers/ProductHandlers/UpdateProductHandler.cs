﻿using ECommerce.Core.Application.Commands.ProductCommands;
using ECommerce.Core.DataAccess.Entities;
using ECommerce.Core.DataAccess.Interfaces;
using ECommerce.Infrastructure.API.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Core.Application.CommandHandlers.ProductHandlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Guid>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMediator _mediator;
        private readonly ICurrentUserProvider _currentUserProvider;

        public UpdateProductHandler(IGenericRepository<Product> productRepository, IMediator mediator,
                                    ICurrentUserProvider currentUserProvider)
        {
            _productRepository = productRepository;
            _mediator = mediator;
            _currentUserProvider = currentUserProvider;
        }
        public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var product = await _productRepository.GetByIdAsync((Guid)request.Id);
            var vendorId = _currentUserProvider.GetUserId();

            if (product == null || product.OwnerId != vendorId)
            {
                throw new NotFoundException("Product not found!");
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = (decimal)request.Price;
            product.Weight = (double)request.Weight;
            product.InStock = (bool)request.InStock;
            product.ImageUrl = request.ImageUrl;

            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();

            return product.Id;
        }
    }
}

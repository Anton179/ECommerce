using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace ECommerce.Core.Application.Commands.UploadCommands
{
    public class UploadImageCommand : IRequest<object>
    {
        public Guid ProductId { get; set; }
        public IFormCollection FormCollection { get; set; }
    }
}

using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace ECommerce.Core.Application.Commands.UploadCommands
{
    public class UploadImageCommand : IRequest<object>
    {
        public string ImageId{ get; set; }
        public IFormCollection FormCollection { get; set; }
    }
}

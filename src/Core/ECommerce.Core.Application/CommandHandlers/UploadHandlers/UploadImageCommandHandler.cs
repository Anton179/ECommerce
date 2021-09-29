using ECommerce.Core.Application.Commands.UploadCommands;
using MediatR;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Core.Application.QueryHandlers.UploadHandlers
{
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, object>
    {
        public async Task<object> Handle(UploadImageCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var productId = request.ProductId;

            if (productId == default(Guid))
            {
                productId = Guid.NewGuid();
            }

            var file = request.FormCollection.Files.First();
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = productId.ToString() + ".png";
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return new { dbPath, productId };
            }
            
            throw new Exception("Internal server error");
        }
    }
}

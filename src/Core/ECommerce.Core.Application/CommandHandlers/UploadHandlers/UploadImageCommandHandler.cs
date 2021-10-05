using ECommerce.Core.Application.Commands.UploadCommands;
using MediatR;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Core.Application.QueryHandlers.UploadHandlers
{
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, object>
    {
        public async Task<object> Handle(UploadImageCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            var imageId = request.ImageId;

            if (string.IsNullOrWhiteSpace(imageId))
            {
                imageId = Guid.NewGuid().ToString() + ".png";
            }

            var file = request.FormCollection.Files.First();
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = imageId.ToString();
                var fullPath = Path.Combine(pathToSave, fileName);
                var imagePath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                imagePath = request.UriPath + "/" + imagePath;

                return new { imagePath, imageId };
            }

            throw new Exception("Internal server error");
        }
    }
}

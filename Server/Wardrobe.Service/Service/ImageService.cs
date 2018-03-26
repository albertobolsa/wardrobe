using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Wardrobe.DataAccess.Interfaces;
using Wardrobe.Model.Entities;
using Wardrobe.Service.Exceptions;
using Wardrobe.Service.Interfaces;
using Wardrobe.Service.Validation.Entities;

namespace Wardrobe.Service.Service
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _repository;
        public ImageService(IImageRepository repository)
        {
            _repository = repository;
        }

        public Image GetImage(Guid imageId)
        {
            var image = _repository.GetImage(imageId);
            if (image == null)
            {
                throw new Exception(string.Format(Resources.Error.ImageService_ImageNotFound_Template, imageId));
            }

            return image;
        }

        public void UploadAndLinkImageToClothingItem(string clothingItemId, IFormFileCollection files)
        {
            if (string.IsNullOrEmpty(clothingItemId))
            {
                throw new Exception(string.Format(Resources.Error.ImageService_InvalidClothingItemId_Template, clothingItemId));
            }

            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    var image = new Image
                    {
                        Id = Guid.NewGuid(),
                        Name = file.FileName
                    };

                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        image.ImageFile = ms.ToArray();
                    }

                    var validationResult = image.Validate();
                    if (validationResult.IsValid())
                    {
                        _repository.AddImage(image);
                    }
                    else
                    {
                        throw new ValidationException(validationResult);
                    }

                    _repository.LinkImageToClothingItem(imageId: image.Id, clothingItemId: Guid.Parse(clothingItemId));
                }
            }
        }

        public void UnlinkImageFromClothingItem(string imageId, string clothingItemId)
        {
            if (string.IsNullOrEmpty(clothingItemId) || string.IsNullOrEmpty(imageId))
            {
                throw new Exception(string.Format(Resources.Error.ImageService_InvalidImageOrClothingItemId_Template, imageId, clothingItemId));
            }

            _repository.UnlinkImageToClothingItem(imageId: Guid.Parse(imageId), clothingItemId: Guid.Parse(clothingItemId));
        }
    }
}

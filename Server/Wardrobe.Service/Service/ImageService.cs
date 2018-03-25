using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Wardrobe.DataAccess.Interfaces;
using Wardrobe.Model.Entities;
using Wardrobe.Service.Interfaces;

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
                throw new Exception("Image not found");
            }

            return image;
        }

        public void UploadAndLinkImageToClothingItem(string clothingItemId, IFormFileCollection files)
        {
            if (string.IsNullOrEmpty(clothingItemId))
            {
                throw new Exception("Error");
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

                    _repository.AddImage(image);
                    _repository.LinkImageToClothingItem(imageId: image.Id, clothingItemId: Guid.Parse(clothingItemId));
                }
            }
        }

        public void UnlinkImageFromClothingItem(string imageId, string clothingItemId)
        {
            if (string.IsNullOrEmpty(clothingItemId) || string.IsNullOrEmpty(imageId))
            {
                throw new Exception("Error");
            }

            _repository.UnlinkImageToClothingItem(imageId: Guid.Parse(imageId), clothingItemId: Guid.Parse(clothingItemId));
        }
    }
}

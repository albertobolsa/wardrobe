using System;
using Microsoft.AspNetCore.Http;
using Wardrobe.Model.Entities;

namespace Wardrobe.Service.Interfaces
{
    public interface IImageService
    {
        Image GetImage(Guid imageId);
        void UploadAndLinkImageToClothingItem(string clothingItemId, IFormFileCollection files);
        void UnlinkImageFromClothingItem(string imageId, string clothingItemId);
    }
}

using System;
using Wardrobe.Model.Entities;

namespace Wardrobe.DataAccess.Interfaces
{
    public interface IImageRepository
    {
        Guid AddImage(Image image);
        Image GetImage(Guid imageId);
        void DeleteImage(Guid imageId);
        void LinkImageToClothingItem(Guid imageId, Guid clothingItemId);
        void UnlinkImageToClothingItem(Guid imageId, Guid clothingItemId);
    }
}

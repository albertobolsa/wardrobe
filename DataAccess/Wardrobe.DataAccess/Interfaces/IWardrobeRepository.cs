using System;
using System.Collections.Generic;
using Wardrobe.Model.Entities;

namespace Wardrobe.DataAccess.Interfaces
{
    public interface IWardrobeRepository
    {
        List<Location> GetLocations(Guid userId);
        Location GetLocationById(Guid locationId);
        void AddLocation(Location location);
        void UpdateLocation(Guid id, Location location);
        void DeleteLocation(Guid id);
    }
}

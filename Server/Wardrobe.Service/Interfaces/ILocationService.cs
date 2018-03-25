using System;
using System.Collections.Generic;
using Wardrobe.Model.Entities;

namespace Wardrobe.Service.Interfaces
{
    public interface ILocationService
    {
        List<Location> GetLocations(Guid userId);
        Location GetLocationById(Guid locationId);
        void AddLocation(Location location);
        void UpdateLocation(Guid id, Location location);
        void DeleteLocation(Guid id);
    }
}

using System;
using System.Collections.Generic;
using Wardrobe.Model.Entities;

namespace Wardrobe.Service.Interfaces
{
    public interface ILocationService
    {
        List<Location> GetLocations();
        Location GetLocationById(Guid locationId);
        void AddLocation(Location location);
        void UpdateLocation(Guid locationId, Location location);
        void DeleteLocation(Guid locationId);
    }
}

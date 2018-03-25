using System;
using System.Collections.Generic;
using Wardrobe.DataAccess.Interfaces;
using Wardrobe.Model.Entities;
using Wardrobe.Service.Interfaces;

namespace Wardrobe.Service.Service
{
    public class LocationService : ILocationService
    {
        private readonly Guid TMP_USER = Guid.Parse("bef713c4-049a-42e8-b0f0-cfcee4cc7e2c");
        private readonly IWardrobeRepository _repository;

        public LocationService(IWardrobeRepository repository)
        {
            _repository = repository;
        }

        public List<Location> GetLocations(Guid userId)
        {
            return _repository.GetLocations(userId);
        }

        public Location GetLocationById(Guid locationId)
        {
            return _repository.GetLocationById(locationId);
        }

        public void AddLocation(Location location)
        {
            location.UserId = TMP_USER;
            location.Id = Guid.NewGuid();
            _repository.AddLocation(location);
        }

        public void UpdateLocation(Guid id, Location location)
        {
            _repository.UpdateLocation(id, location);
        }

        public void DeleteLocation(Guid id)
        {
            _repository.DeleteLocation(id);
        }
    }
}

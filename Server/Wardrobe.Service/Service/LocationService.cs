using System;
using System.Collections.Generic;
using Wardrobe.DataAccess.Interfaces;
using Wardrobe.Model.Entities;
using Wardrobe.Service.Exceptions;
using Wardrobe.Service.Interfaces;
using Wardrobe.Service.Validation.Entities;

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

        public List<Location> GetLocations()
        {
            return _repository.GetLocations();
        }

        public Location GetLocationById(Guid locationId)
        {
            return _repository.GetLocationById(locationId);
        }

        public void AddLocation(Location location)
        {
            location.UserId = TMP_USER;
            location.Id = Guid.NewGuid();

            var validationResult = location.Validate();
            if (validationResult.IsValid())
            {
                _repository.AddLocation(location);
            }
            else
            {
                throw new ValidationException(validationResult);
            }
        }

        public void UpdateLocation(Guid locationId, Location location)
        {
            var validationResult = location.Validate();
            if (validationResult.IsValid())
            {
                _repository.UpdateLocation(locationId, location);
            }
            else
            {
                throw new ValidationException(validationResult);
            }
        }

        public void DeleteLocation(Guid locationId)
        {
            _repository.DeleteLocation(locationId);
        }
    }
}

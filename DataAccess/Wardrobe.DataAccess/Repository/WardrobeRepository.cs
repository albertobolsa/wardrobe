using System;
using System.Collections.Generic;
using System.Linq;
using Wardrobe.DataAccess.Context;
using Wardrobe.DataAccess.Interfaces;
using Wardrobe.Model.Entities;

namespace Wardrobe.DataAccess.Repository
{
    public class WardrobeRepository : IWardrobeRepository
    {
        private readonly WardrobeDataContext _context;

        public WardrobeRepository(WardrobeDataContext dbContext)
        {
            _context = dbContext;
        }

        public List<Location> GetLocations(Guid userId)
        {
            return _context.Location.ToList();
        }

        public Location GetLocationById(Guid locationId)
        {
            return _context.Location.SingleOrDefault(l => l.Id == locationId);
        }

        public void AddLocation(Location location)
        {
            _context.Location.Add(location);
            _context.SaveChanges();
        }

        public void UpdateLocation(Guid id, Location location)
        {
            _context.Location.Update(location);
            _context.SaveChanges();
        }

        public void DeleteLocation(Guid id)
        {
            _context.Location.Remove(GetLocationById(id));
            _context.SaveChanges();
        }
    }
}

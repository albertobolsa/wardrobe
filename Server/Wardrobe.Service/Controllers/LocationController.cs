using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wardrobe.DataAccess.Interfaces;
using Wardrobe.Model.Entities;

namespace Wardrobe.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Location")]
    public class LocationController : BaseWardrobeController
    {
        public LocationController(IWardrobeRepository repository, ILogger<LocationController> logger) : base(repository, logger) { }

        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return Repository.GetLocations(Guid.NewGuid());
        }

        [HttpGet("{id}", Name = "GetLocation")]
        public Location Get(Guid id)
        {
            return Repository.GetLocationById(id);
        }
        
        [HttpPost]
        public void Post([FromBody]Location value)
        {
            value.UserId = Guid.Parse("bef713c4-049a-42e8-b0f0-cfcee4cc7e2c");
            value.Id = Guid.NewGuid();
            Repository.AddLocation(value);
        }
        
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Location value)
        {
            Repository.UpdateLocation(id, value);
        }
        
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            Repository.DeleteLocation(id);
        }
    }
}

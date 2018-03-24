using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Wardrobe.DataAccess.Interfaces;
using Wardrobe.Model.Entities;

namespace Wardrobe.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Location")]
    public class LocationController : BaseWardrobeController
    {
        public LocationController(IWardrobeRepository repository) : base(repository) { }

        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return Repository.GetLocations(Guid.NewGuid());
        }

        [HttpGet("{id}", Name = "Get")]
        public Location Get(Guid id)
        {
            return Repository.GetLocationById(id);
        }
        
        [HttpPost]
        public void Post([FromBody]Location value)
        {
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

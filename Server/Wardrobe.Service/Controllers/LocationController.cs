using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wardrobe.Model.Entities;
using Wardrobe.Service.Interfaces;

namespace Wardrobe.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Location")]
    public class LocationController : BaseWardrobeController
    {
        private readonly ILocationService _service;
        public LocationController(ILocationService service, ILogger<LocationController> logger) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return _service.GetLocations();
        }

        [HttpGet("{id}", Name = "GetLocation")]
        public Location Get(Guid id)
        {
            return _service.GetLocationById(id);
        }
        
        [HttpPost]
        public void Post([FromBody]Location value)
        {
            _service.AddLocation(value);
        }
        
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Location value)
        {
            _service.UpdateLocation(id, value);
        }
        
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _service.DeleteLocation(id);
        }
    }
}

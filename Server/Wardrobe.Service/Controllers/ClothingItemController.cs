using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wardrobe.Model.Entities;
using Wardrobe.Service.Interfaces;

namespace Wardrobe.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/ClothingItem")]
    public class ClothingItemController : BaseWardrobeController
    {
        private readonly IClothingItemService _service;
        public ClothingItemController(IClothingItemService service, ILogger<ClothingItemController> logger) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ClothingItem> Get()
        {
            return _service.GetClothingItems();
        }

        [HttpGet("{id}", Name = "GetClothingItemById")]
        public ClothingItem Get(Guid id)
        {
            return _service.GetClothingItemById(id);
        }

        [HttpGet("location/{locationId}", Name = "GetClothingItemsByLocation")]
        public IEnumerable<ClothingItem> GetByLocation(Guid locationId)
        {
            return _service.GetClothingItemsByLocationId(locationId);
        }

        [HttpPost]
        public void Post([FromBody]ClothingItem value)
        {
            _service.AddLocation(value);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]ClothingItem value)
        {
            _service.UpdateClothingItem(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _service.DeleteClothingItem(id);
        }
    }
}

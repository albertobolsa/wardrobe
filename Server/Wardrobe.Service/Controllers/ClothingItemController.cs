using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Wardrobe.DataAccess.Interfaces;
using Wardrobe.Model.Entities;

namespace Wardrobe.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/ClothingItem")]
    public class ClothingItemController : BaseWardrobeController
    {
        public ClothingItemController(IWardrobeRepository repository) : base(repository) { }

        [HttpGet]
        public IEnumerable<ClothingItem> Get()
        {
            return Repository.GetClothingItems(Guid.NewGuid());
        }

        [HttpGet("{id}", Name = "GetClothingItemById")]
        public ClothingItem Get(Guid id)
        {
            return Repository.GetClothingItemById(id);
        }

        [HttpGet("location/{locationId}", Name = "GetClothingItemsByLocation")]
        public IEnumerable<ClothingItem> GetByLocation(Guid locationId)
        {
            return Repository.GetClothingItemsByLocationId(locationId);
        }

        [HttpPost]
        public void Post([FromBody]ClothingItem value)
        {
            value.Id = Guid.NewGuid();
            Repository.AddLocation(value);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]ClothingItem value)
        {
            Repository.UpdateClothingItem(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            Repository.DeleteClothingItem(id);
        }
    }
}

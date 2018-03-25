using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Wardrobe.DataAccess.Interfaces;
using Wardrobe.Model.Entities;
using Wardrobe.Service.Controllers;

namespace Wardrobe.Service.Test.Controller
{
    [TestFixture]
    public class LocationControllerTests
    {
        private readonly Guid TestUser = Guid.Parse("c49c690b-2cb2-44f4-a067-60706b1ed0d3");
        private readonly IWardrobeRepository _Repository;
        private readonly ILogger _Logger;

        public LocationControllerTests(IWardrobeRepository repository, ILogger logger)
        {
            _Repository = repository;
            _Logger = logger;
        }

        [Test]
        public void LocationController_Get_ReturnsElements()
        {
            var controller = new LocationController(_Repository, null);
            var locations = controller.Get();
            Assert.AreEqual(true, locations.Any());
        }

        [Test]
        public void LocationController_Post_AddsNewElement()
        {
            var newLocation = new Location
            {
                Id = Guid.NewGuid(),
                Latitude = -1,
                Longitude = -1,
                Name = string.Format("Location {0}", DateTime.Now.TimeOfDay),
                UserId = TestUser
            };

            var controller = new LocationController(_Repository, null);
            controller.Post(newLocation);
            var location = controller.Get(newLocation.Id);

            Assert.AreEqual(location.Name, newLocation.Name);
        }

        [Test]
        public void LocationController_Put_UpdatesElement()
        {
            var newLocation = new Location
            {
                Id = Guid.NewGuid(),
                Latitude = -1,
                Longitude = -1,
                Name = string.Format("Location {0}", DateTime.Now.TimeOfDay),
                UserId = TestUser
            };

            var controller = new LocationController(_Repository, null);
            controller.Post(newLocation);
            var location = controller.Get(newLocation.Id);

            Assert.AreEqual(location.Name, newLocation.Name);

            newLocation.Name = string.Format("Replaced Name {0}", DateTime.Now.TimeOfDay);
            controller.Put(newLocation.Id, newLocation);
            location = controller.Get(newLocation.Id);

            Assert.AreEqual(location.Name, newLocation.Name);
        }

        [Test]
        public void LocationController_Delete_RemovesElement()
        {
            var newLocation = new Location
            {
                Id = Guid.NewGuid(),
                Latitude = -1,
                Longitude = -1,
                Name = string.Format("Location {0}", DateTime.Now.TimeOfDay),
                UserId = TestUser
            };

            var controller = new LocationController(_Repository, null);
            controller.Post(newLocation);
            var location = controller.Get(newLocation.Id);

            Assert.AreEqual(location.Name, newLocation.Name);

            controller.Delete(newLocation.Id);
            location = controller.Get(newLocation.Id);

            Assert.AreEqual(null, location);
        }
    }
}

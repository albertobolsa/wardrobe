using System;
using NUnit.Framework;
using Wardrobe.Model.Entities;
using Wardrobe.Service.Validation;
using Wardrobe.Service.Validation.Entities;
using V = Wardrobe.Service.Resources.Validation;

namespace Wardrobe.Service.Test.Validation
{
    [TestFixture]
    public class LocationValidatorTests
    {
        [Test]
        public void LocationValidatorTests_InvalidInput_ContainsErrors()
        {
            var testEntity = new Location();
            testEntity.Name = new string('*', 5000);
            testEntity.Latitude = -100;
            testEntity.Longitude = -200;

            var result = testEntity.Validate() as DictionaryValidationResult;

            Assert.AreEqual(false, result.IsValid());
            Assert.AreEqual(true, result.ContainsKey(V.Location_Id));
            Assert.AreEqual(true, result.ContainsKey(V.Location_Name));
            Assert.AreEqual(true, result.ContainsKey(V.Location_Latitude));
            Assert.AreEqual(true, result.ContainsKey(V.Location_Longitude));

            Console.WriteLine(result.GetValidationResult());
        }

        [Test]
        public void LocationValidatorTests_CorrectInput_IsValid()
        {
            var testEntity = new Location();
            testEntity.Id = Guid.NewGuid();
            testEntity.Name = "Location Name";
            testEntity.Latitude = 0;
            testEntity.Longitude = 0;

            var result = testEntity.Validate();

            Assert.AreEqual(true, result.IsValid());
        }
    }
}

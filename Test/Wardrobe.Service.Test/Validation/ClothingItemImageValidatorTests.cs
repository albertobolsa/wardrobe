using System;
using NUnit.Framework;
using Wardrobe.Model.Entities;
using Wardrobe.Service.Validation;
using Wardrobe.Service.Validation.Entities;
using V = Wardrobe.Service.Resources.Validation;

namespace Wardrobe.Service.Test.Validation
{
    [TestFixture]
    public class ClothingItemImageValidatorTests
    {
        [Test]
        public void ClothingItemImageValidatorTests_InvalidInput_ContainsErrors()
        {
            var testEntity = new ClothingItemImage();

            var result = testEntity.Validate() as DictionaryValidationResult;

            Assert.AreEqual(false, result.IsValid());
            Assert.AreEqual(true, result.ContainsKey(V.ClothingItemImage_ClothingItemId));
            Assert.AreEqual(true, result.ContainsKey(V.ClothingItemImage_ImageId));

            Console.WriteLine(result.GetValidationResult());
        }

        [Test]
        public void ClothingItemImageValidatorTests_CorrectInput_IsValid()
        {
            var testEntity = new ClothingItemImage();
            testEntity.ClothingItemId = Guid.NewGuid();
            testEntity.ImageId = Guid.NewGuid();

            var result = testEntity.Validate();

            Assert.AreEqual(true, result.IsValid());
        }
    }
}

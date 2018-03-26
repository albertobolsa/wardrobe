using System;
using NUnit.Framework;
using Wardrobe.Model.Entities;
using Wardrobe.Service.Validation;
using Wardrobe.Service.Validation.Entities;
using V = Wardrobe.Service.Resources.Validation;

namespace Wardrobe.Service.Test.Validation
{
    [TestFixture]
    public class ImageValidatorTests
    {
        [Test]
        public void LocationValidatorTests_InvalidInput_ContainsErrors()
        {
            var testEntity = new Image();
            testEntity.Name = new string('*', 5000); 

            var result = testEntity.Validate() as DictionaryValidationResult;

            Assert.AreEqual(false, result.IsValid());
            Assert.AreEqual(true, result.ContainsKey(V.Image_Id));
            Assert.AreEqual(true, result.ContainsKey(V.Image_Name));
            Assert.AreEqual(true, result.ContainsKey(V.Image_ImageFile));

            Console.WriteLine(result.GetValidationResult());
        }

        [Test]
        public void LocationValidatorTests_CorrectInput_IsValid()
        {
            var testEntity = new Image();
            testEntity.Id = Guid.NewGuid();
            testEntity.Name = "Image Name";
            testEntity.ImageFile = new byte[100];

            var result = testEntity.Validate();

            Assert.AreEqual(true, result.IsValid());
        }
    }
}

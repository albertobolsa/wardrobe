using System;
using System.Collections.Immutable;
using NUnit.Framework;
using Wardrobe.Model.Entities;
using Wardrobe.Service.Validation;
using Wardrobe.Service.Validation.Entities;
using V = Wardrobe.Service.Resources.Validation;

namespace Wardrobe.Service.Test.Validation
{
    [TestFixture]
    public class ClothingItemValidatorTests
    {
        [Test]
        public void ClothingItemValidatorTests_InvalidInput_ContainsErrors()
        {
            var clothingItem = new ClothingItem();
            var longString = new string('*', 5000);

            clothingItem.Type = longString;
            clothingItem.Size = longString;
            clothingItem.PurchaseLocation = longString;
            clothingItem.Currency = longString;
            clothingItem.Comments = longString;

            var result = clothingItem.Validate() as DictionaryValidationResult;

            Assert.AreEqual(false, result.IsValid());
            Assert.AreEqual(true, result.ContainsKey(V.ClothingItem_Id));
            Assert.AreEqual(true, result.ContainsKey(V.ClothingItem_Type));
            Assert.AreEqual(true, result.ContainsKey(V.ClothingItem_Size));
            Assert.AreEqual(true, result.ContainsKey(V.ClothingItem_PurchaseLocation));
            Assert.AreEqual(true, result.ContainsKey(V.ClothingItem_Currency));
            Assert.AreEqual(true, result.ContainsKey(V.ClothingItem_Comments));


            Console.WriteLine(result.GetValidationResult());
        }

        [Test]
        public void ClothingItemValidatorTests_CorrectInput_IsValid()
        {
            var clothingItem = new ClothingItem();
            clothingItem.Id = Guid.NewGuid();

            var result = clothingItem.Validate();

            Assert.AreEqual(true, result.IsValid());
        }
    }
}
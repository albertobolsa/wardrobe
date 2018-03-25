using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wardrobe.Model.Entities
{
    [Table("ClothingItem")]
    public class ClothingItem
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string PurchaseLocation { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public bool IsFit { get; set; }
        public bool IsArchived { get; set; }
        public string Comments { get; set; }
    }
}
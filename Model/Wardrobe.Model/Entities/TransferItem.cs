using System;

namespace Wardrobe.Model.Entities
{
    public class TransferItem
    {
        public Guid LocationId { get; set; }
        public Guid ClothingItemId { get; set; }
    }
}

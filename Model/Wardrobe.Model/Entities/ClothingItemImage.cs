using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wardrobe.Model.Entities
{
    [Table("ClothingItemImage")]
    public class ClothingItemImage
    {
        public Guid ClothingItemId { get; set; }
        public Guid ImageId { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wardrobe.Model.Entities
{
    [Table("Image")]
    public class Image
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] ImageFile { get; set; }
    }
}

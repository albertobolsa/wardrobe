using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wardrobe.Model.Entities
{
    [Table("Location")]
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Guid UserId { get; set; }
    }
}

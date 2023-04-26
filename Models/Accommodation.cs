using EgyptTouristWebSite.Models.MetaData;
using EgyptTouristWebSite.Models.SubTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptTouristWebSite.Models
{
 
    [ModelMetadataType(typeof(AccommodationMetaData))]
	public class Accommodation
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        [ForeignKey(nameof(Acctype))]
        public int TypeId { get; set; }
        public Acctype? Type { get; set; }
        public List<Tourist>? Tourists { get; set; }
        public string? Image { get; set; }
        public int Rate { get; set; } = 0;
        public double? X { get; set; }
        public double? Y { get; set; }

    }
}

using EgyptTouristWebSite.Models.MetaData;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptTouristWebSite.Models
{
	[ModelMetadataType(typeof(TouristMetaData))]
	public class Tourist
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public string Nationality { get; set; }
		public double X { get; set; }
		public double Y { get; set; }
		[ForeignKey("Accommodation")]
		public int? AccId { get; set; }

        public Accommodation? Accommodation { get; set; }
		[ForeignKey("TravelAgency")]
        public int? TravelAgencyId { get; set; }
        public TravelAgency? TravelAgency { get; set; }

        public List<Service>? Services { get; set; }
		public List<InterestingPlace>? InterestingPlaces { get; set;}


    }
}

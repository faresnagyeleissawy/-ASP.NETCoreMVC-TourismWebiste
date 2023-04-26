using EgyptTouristWebSite.Models.SubTypes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EgyptTouristWebSite.Models.MetaData { 
	public class ServiceMetaData
	{
		[Required]
		public int Id { get; set; }
		[Required]
		[MinLength(3)]
		[MaxLength(100)]
		public string Name { get; set; }
		[Required]
		[MinLength(1)]
		[MaxLength(100)]

		public string Description { get; set; }

		[Range(0,5)]
		public int Rate { get; set; }
		[Required]

		public double X { get; set; }
		[Required]

		public double Y { get; set; }
		[Required]

		public ServiceType Type { get; set; }
		[AllowNull]
		public List<Tourist>? Tourists { get; set; }
	}
}

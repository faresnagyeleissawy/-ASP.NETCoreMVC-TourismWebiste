using EgyptTouristWebSite.Models;
using Microsoft.EntityFrameworkCore;
namespace EgyptTouristWebSite.Context
{
	public class DataBaseContext: DbContext
	{
		public DbSet<Tourist> Tourists { get; set; }
		public DbSet<Accommodation> Accommodations { get; set; }
		public DbSet<InterestingPlace> InterestingPlaces { get; set; }
		public DbSet<Service> Services { get; set; }	
		public DbSet<Transportation> Transpotations { get; set; }
		public DbSet<TravelAgency> TravelAgencies { get; set; }
		public DbSet<TourGuide> TourGuides { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=TourismDB1;User Id=postgres;Password=000;");

		}

	}
}

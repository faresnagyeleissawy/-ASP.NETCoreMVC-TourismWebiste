using Microsoft.EntityFrameworkCore;

namespace EgyptTouristWebSite.Models
{
    public class DataBaseContext: DbContext
    {
        internal readonly object Transportation;

        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<InterestingPlace> InterestingPlaces { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Transportation> Transpotations { get; set; }
        public DbSet<TravelAgency> TravelAgencies { get; set; }
        public DbSet<TourGuide> TourGuides { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost; Port=5432; Database=TourismMVC; User Id=postgres; Password=0000;";
            optionsBuilder.UseNpgsql(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}

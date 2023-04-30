using EgyptTouristWebSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace EgyptTouristWebSite.ViewModel
{
    public class PlacesViewModel
    {
        static DataBaseContext _context = new DataBaseContext();
        
        // Types are Cultural, Leisure, Religious and Medical
        public static List<InterestingPlace> placesCultural = _context.InterestingPlaces.Include(p=>p.Type).Where(p => p.Type.Type == "Cultural").ToList();
        public static List<InterestingPlace> placesLeisure = _context.InterestingPlaces.Include(p => p.Type).Where(p => p.Type.Type == "Leisure").ToList();
        public static List<InterestingPlace> placesReligious = _context.InterestingPlaces.Include(p => p.Type).Where(p => p.Type.Type == "Religious").ToList();
        public static List<InterestingPlace> placesMedical = _context.InterestingPlaces.Include(p => p.Type).Where(p => p.Type.Type == "Medical").ToList();
        public List<List<InterestingPlace>> placesList = new() {
            placesCultural,
            placesLeisure,
            placesReligious,
            placesMedical,
        };
        //public List<List<InterestingPlace>> places = new() { placesCultural, placesLeisure, placesReligious, placesMedical };
        
    }
}

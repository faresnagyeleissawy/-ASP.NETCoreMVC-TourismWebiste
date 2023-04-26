using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptTouristWebSite.ViewModel
{
    public class AccommodationsViewModel
    {
        static DataBaseContext _context = new DataBaseContext();

        public static List<Accommodation> accHotels = _context.Accommodations.Include(a => a.Type).Where(a => a.Type.Type == "Hotel").ToList();
        public static List<Accommodation> accResorts = _context.Accommodations.Include(a => a.Type).Where(a => a.Type.Type == "Resort").ToList();
        public static List<Accommodation> accMotels = _context.Accommodations.Include(a => a.Type).Where(a => a.Type.Type == "Motel").ToList();
        public List<List<Accommodation>> accsList = new()
        {
            accHotels,
            accResorts,
            accMotels,
        };
    }
}

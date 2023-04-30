using EgyptTouristWebSite.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptTouristWebSite.ViewModel
{
    public class HomeViewModel
    {
        static DataBaseContext _context = new DataBaseContext();
        public List<Service> services = _context.Services.Include(i=>i.Type).Take(10).ToList();
        public List<Accommodation> accommodations = _context.Accommodations.Take(10).ToList();
        public List<InterestingPlace> places = _context.InterestingPlaces.Include(i=>i.Type).Take(10).ToList();

        
    }
}

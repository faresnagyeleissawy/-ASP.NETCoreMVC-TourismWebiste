using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EgyptTouristWebSite.ViewModel
{
    public class ServicesViewModel
    {
		static DataBaseContext context = new DataBaseContext();

        static List<Service> banks = context.Services.Include(s=>s.Type).Where(s => s.Type.Type == "Bank").ToList();
        static List<Service> embassies = context.Services.Include(s => s.Type).Where(s => s.Type.Type == "Embassy").ToList();
        static List<Service> malls = context.Services.Include(s => s.Type).Where(s => s.Type.Type == "Mall").ToList();
        static List<Service> restaurants = context.Services.Include(s => s.Type).Where(s => s.Type.Type == "Restaurant").ToList();
        public List<List<Service>> services = new()
            {
                banks, embassies, malls, restaurants
            };
    }
}

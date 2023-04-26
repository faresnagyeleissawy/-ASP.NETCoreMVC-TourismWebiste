using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository.Interfaces;
using EgyptTouristWebSite.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EgyptTouristWebSite.Repository
{
	public class ServiceRepository:IRepo<Service>
	{
		DataBaseContext context = new DataBaseContext();

		public void Add(Service service)
		{
		}
		public List<Service> GetByCategory(string type)
		{
			var services = context.Services.Include(s => s.Type).Where(s => s.Type.Type == type).ToList();
			return services;
		}
		public void Delete(int id)
		{
			Service service = GetById(id);
			context.Services.Remove(service);
			context.SaveChanges();
		}

		

		public Service GetById(int id)
		{
			var service = context.Services.Include(s=>s.Type).FirstOrDefault(p => p.Id == id);
			return service;
		}

        public List<Service> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

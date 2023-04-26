using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository.Interfaces;

namespace EgyptTouristWebSite.Repository
{
	public class TouristRepository : IRepo<Tourist>
	{
		DataBaseContext context = new DataBaseContext();

		public void Add(Tourist Tourist)
		{

		}

		public void Delete(int id)
		{
			Tourist tourist = GetById(id);
			context.Tourists.Remove(tourist);
			context.SaveChanges();
		}

		public List<Tourist> GetAll()
		{
			return context.Tourists.ToList();

		}

		public Tourist GetById(int id)
		{
			var tourist = context.Tourists.FirstOrDefault(p => p.Id == id);
			return tourist;
		}
	}
}

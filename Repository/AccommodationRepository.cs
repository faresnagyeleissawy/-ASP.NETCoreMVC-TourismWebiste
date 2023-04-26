using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace EgyptTouristWebSite.Repository
{
	public class AccommodationRepository:IRepo<Accommodation>
	{
		DataBaseContext context = new DataBaseContext();

		public void Add(Accommodation acc)
		{
		}
		public List<Accommodation> GetByFilter(string[] types, string[] prices, string[] ratings) {
			var list = context.Accommodations.Include(a=>a.Type).AsEnumerable();

            if (types.Length != 0)
			{
				list = list.Where(a => types.Contains(a.Type.Type));
			}
			if (ratings.Length != 0)
			{
				list = list.Where(a=>ratings.Contains(a.Rate.ToString()));
			}
			if (prices.Length != 0)
			{
				list = list.Where(a =>
				{
					foreach (var priceRange in prices)
					{
						var pricesValues = priceRange.Split('-');
						int minPrice = int.Parse(pricesValues[0]);
						int maxPrice = pricesValues.Length == 2 ? int.Parse(pricesValues[1]) : int.MaxValue;
						if (a.Price >= minPrice && a.Price <= maxPrice)
						{
							return true;
                        }
					}
                    return false;

                });
			}
			return list.ToList();
		}
        public List<Accommodation> GetByName(string name)
        {
            var accs = context.Accommodations.Include(a=>a.Type).Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
            return accs;
        }
        public void Delete(int id)
		{
			Accommodation acc = GetById(id);
			context.Accommodations.Remove(acc);
			context.SaveChanges();
		}

		public List<Accommodation> GetAll()
		{
			return context.Accommodations.ToList();

		}

		public Accommodation GetById(int id)
		{
			var acc = context.Accommodations.Include(a=>a.Type).FirstOrDefault(a => a.Id == id);
			return acc;
		}
        public List<Accommodation> GetByCat(string category)
        {
            var accsList = context.Accommodations.Include(a => a.Type).Where(a => a.Type.Type == category).ToList();

            return accsList;
        }
    }
}

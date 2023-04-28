using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository.Interfaces;
using EgyptTouristWebSite.Context;
namespace EgyptTouristWebSite.Repository
{
    public class TravelAgencyRepository: IRepo<TravelAgency>
    {
        DataBaseContext context=new DataBaseContext();


        public void Add(TravelAgency newtravel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            TravelAgency agency = GetById(id);
            context.TravelAgencies.Remove(agency);
            context.SaveChanges();
        }

        public List<TravelAgency> GetAll()
        {
            return context.TravelAgencies.ToList();
        }

        public TravelAgency GetById(int id)
        {
            return context.TravelAgencies.FirstOrDefault(e => e.Id == id);
        }
    }
}

using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository.Interfaces;
namespace EgyptTouristWebSite.Repository
{
    public class TourGuideRepositry : IRepo<TourGuide>
    {
        DataBaseContext context = new DataBaseContext();

        public void Add(TourGuide asd)
        {
        }

        public void Delete(int id)
        {
            TourGuide Tour = GetById(id);
            context.TourGuides.Remove(Tour);
            context.SaveChanges();
        }

        public List<TourGuide> GetAll()
        {
            return context.TourGuides.ToList();

        }

        public TourGuide GetById(int id)
        {
            var Tour = context.TourGuides.FirstOrDefault(p => p.Id == id);
            return Tour;
        }
    }
}

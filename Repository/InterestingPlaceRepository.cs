using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository.Interfaces;
using EgyptTouristWebSite.ViewModel;
using System.Xml.Linq;
using  EgyptTouristWebSite.Context;
using Microsoft.EntityFrameworkCore;

namespace EgyptTouristWebSite.repository
{
    public class InterestingPlaceRepository : IRepo<InterestingPlace>
    {
        DataBaseContext context=new DataBaseContext();

        public List<InterestingPlace> GetAll()
        {
            return context.InterestingPlaces.ToList();
        }

        public InterestingPlace GetById(int id)
        {
            var place = context.InterestingPlaces.Include(p=>p.Type).FirstOrDefault(p => p.Id == id);
            return place;
        }
        public List<InterestingPlace> GetByName(string name)
        {
            var place = context.InterestingPlaces.Where(p => p.Name.Contains(name)).ToList();
            return place;
        }
        public List<InterestingPlace> GetPlacesByName(string name)
        {
            return context.InterestingPlaces.Where(p => p.Name.Contains(name)).ToList();
        }
        public List<InterestingPlace> GetByCat(string category)
        {
            var placesList = context.InterestingPlaces.Include(p=>p.Type).Where(p=>p.Type.Type == category).ToList();
           
            return placesList;
        }
        //public void Add(ToAddNewInterstingPlaceViewModel interestingPlace)
        //{
        //    InterestingPlace newinterestingPlace = new InterestingPlace();
        //    interestingPlace.Name= newinterestingPlace.Name;
        //    interestingPlace.Category= newinterestingPlace.Category;
        //    interestingPlace.Rate = newinterestingPlace.Rate;
        //    newinterestingPlace.x = newinterestingPlace.x;
        //    newinterestingPlace.y = newinterestingPlace.y;
        //    newinterestingPlace.Type=newinterestingPlace.Type;
        //    newinterestingPlace.typeID=newinterestingPlace.typeID;
        //    newinterestingPlace.Website=newinterestingPlace.Website;
        //    newinterestingPlace.Desciption=newinterestingPlace.Desciption;
        //    context.InterestingPlaces.Add(newinterestingPlace);
        //    context.SaveChanges();
        //}
        public void Delete(int id)
        {
            InterestingPlace place=GetById(id);
            context.InterestingPlaces.Remove(place);
            context.SaveChanges();
        }

        public void Add(InterestingPlace asd)
        {
            throw new NotImplementedException();
        }
    }
}

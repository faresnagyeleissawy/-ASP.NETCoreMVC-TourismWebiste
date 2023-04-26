﻿using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository.Interfaces;
using EgyptTouristWebSite.Context;
namespace EgyptTouristWebSite.Repository
{
    public class TransportationRepository : IRepo<Transportation>
    {
        DataBaseContext context = new DataBaseContext();

        public void Add(Transportation asd)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            Transportation place = GetById(id);
            context.Transpotations.Remove(place);
            context.SaveChanges();
        }

        public List<Transportation> GetAll()
        {
            return context.Transpotations.ToList();
        }

        public Transportation GetById(int id)
        {
            var trans = context.Transpotations.FirstOrDefault(p => p.Id == id);
            return trans;
        }

        public Transportation GetByName(string name)
        {
            var trans = context.Transpotations.FirstOrDefault(p => p.NameOfcompany == name);
            return trans;
        }
    }
}

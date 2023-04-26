using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.repository;
using EgyptTouristWebSite.Repository;
using EgyptTouristWebSite.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EgyptTouristWebSite.Controllers
{
    public class InterestingPlaceController : Controller
    {
        DataBaseContext context = new DataBaseContext();
        InterestingPlaceRepository InterestingPlaceRepo = new InterestingPlaceRepository(); 

       
        public IActionResult ShowAllPlaces()
        {
            PlacesViewModel places = new PlacesViewModel();
            return View(places);
        }
        public IActionResult ShowPlacesByCategory(string category)
        {
            dynamic places = InterestingPlaceRepo.GetByCat(category);
            return View(places);
        }

        public IActionResult Details(int Id)
        {
            var place = InterestingPlaceRepo.GetById(Id);
            return View(place);
        }
        public IActionResult SearchByName(string name)
        {
            var place = InterestingPlaceRepo.GetByName(name);
            return View(place);
        }

        public IActionResult Delete(int id)
        {
            InterestingPlaceRepo.Delete(id);
            return View();  // Redirect To Action of Admin List of places
        }



    }
}

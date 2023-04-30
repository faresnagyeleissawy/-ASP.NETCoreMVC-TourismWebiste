using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository;
using EgyptTouristWebSite.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace EgyptTouristWebSite.Controllers
{
    public class AccommodationController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        DataBaseContext context = new DataBaseContext();
        AccommodationRepository AccommodationRepo = new AccommodationRepository();

        public IActionResult ShowAllPlaces()
        {
            AccommodationsViewModel model = new AccommodationsViewModel();
            return View(model);
        }
        public IActionResult ShowFilteredPlaces(string[] types, string[] prices, string[] ratings)
        {
            var places = AccommodationRepo.GetByFilter(types, prices, ratings);
            return PartialView("FilteredAccommodationsPartial",places);
        }
        public IActionResult Details(int id)
        {
            var acc = AccommodationRepo.GetById(id);
            return View(acc);
        }
        public IActionResult SearchByName(string searchString)
        {
            if(string.IsNullOrWhiteSpace(searchString)) { return Ok(); }
            var places = AccommodationRepo.GetByName(searchString);
            return PartialView("FilteredAccommodationsPartial", places);
        }
        public IActionResult ShowPlacesByCategory(string category)
        {
            dynamic places = AccommodationRepo.GetByCat(category);
            return View(places);
        }

        public IActionResult Delete(int id)
        {
            AccommodationRepo.Delete(id);
            return View();
        }
    }
}

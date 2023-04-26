using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.repository;
using EgyptTouristWebSite.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EgyptTouristWebSite.Controllers
{
    public class TourGuideController : Controller
    {
        DataBaseContext context = new DataBaseContext();
        TourGuideRepositry TourGuideRepo;

        public IActionResult ShowAllPlaces()
        {
            var Alltourguide = TourGuideRepo.GetAll();
            return View();
        }

        public IActionResult SearchById(int id)
        {
            var tourguide = TourGuideRepo.GetById(id);
            return View();
        }

        public IActionResult Delete(int id)
        {
            TourGuideRepo.Delete(id);
            return View();
        }
    }
}

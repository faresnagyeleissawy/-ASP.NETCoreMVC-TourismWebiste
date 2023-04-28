using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EgyptTouristWebSite.Controllers
{
    public class TravelAgencyController : Controller
    {
        DataBaseContext context = new DataBaseContext();
        TravelAgencyRepository TravelAgencyRepo = new TravelAgencyRepository();

        public IActionResult ShowAllPlaces()
        {
            var Allagency = TravelAgencyRepo.GetAll();
            return View(Allagency);
        }

        public IActionResult Details(int id)
        {
            var agency = TravelAgencyRepo.GetById(id);
            return View(agency);
        }

        public IActionResult Delete(int id)
        {
            TravelAgencyRepo.Delete(id);
            return View();
        }
    }
}

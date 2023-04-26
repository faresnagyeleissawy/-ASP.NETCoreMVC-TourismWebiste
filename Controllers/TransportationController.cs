using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.repository;
using EgyptTouristWebSite.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EgyptTouristWebSite.Controllers
{
    public class TransportationController : Controller
    {
        DataBaseContext context = new DataBaseContext();
        TransportationRepository TransportationRepo = new TransportationRepository();

        public IActionResult ShowAllPlaces()
        {
            var Alltrans = TransportationRepo.GetAll();
            return View();
        }

        public IActionResult SearchById(int id)
        {
            var trans = TransportationRepo.GetById(id);
            return View();
        }

        public IActionResult Delete(int id)
        {
            TransportationRepo.Delete(id);
            return View();
        }
    }
}

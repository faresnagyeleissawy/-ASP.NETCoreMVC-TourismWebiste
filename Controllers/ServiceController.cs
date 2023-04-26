using EgyptTouristWebSite.Context;
using EgyptTouristWebSite.Models;
using EgyptTouristWebSite.Repository;
using EgyptTouristWebSite.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EgyptTouristWebSite.Controllers
{
    public class ServiceController : Controller
    {
        

        DataBaseContext context = new DataBaseContext();
        ServiceRepository ServiceRepo = new ServiceRepository();

        public IActionResult ShowAllServices()
        {
            var allServices = new ServicesViewModel();
            return View(allServices);
        }
        public IActionResult ShowServicesByCategory(string category)
        {
            var serviceCat = ServiceRepo.GetByCategory(category);
            return View(serviceCat);
        }
        public IActionResult Details(int id)
        {
            var service = ServiceRepo.GetById(id);
            return View(service);
        }

        public IActionResult Delete(int id)
        {
            ServiceRepo.Delete(id);
            return View();
        }
    }
}

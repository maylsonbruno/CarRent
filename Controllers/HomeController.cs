using CarRent.Models;
using CarRent.Repositories.Interfaces;
using CarRent.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarRent.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRentReposityory _carRentRepository;

        public HomeController(ICarRentReposityory carRentRepository)
        {
            _carRentRepository = carRentRepository;
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel 
            { 
                  CarrosEtoque = _carRentRepository.CarrosEstoque
            };

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

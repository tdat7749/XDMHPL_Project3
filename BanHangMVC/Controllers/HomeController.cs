using BanHangMVC.Models;
using BanHangMVC.Request;
using BanHangMVC.Services.VegetableService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BanHangMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVegetableService _vegetableService;


        public HomeController(ILogger<HomeController> logger, IVegetableService vegetableService)
        {
            _logger = logger;
            _vegetableService = vegetableService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(GetVegetableRequest request)
        {
            var listVegetable = await _vegetableService.GetAllVegetable(request);
            return View(listVegetable);
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
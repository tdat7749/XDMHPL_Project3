using BanHangMVC.Services.VegetableService;
using Microsoft.AspNetCore.Mvc;

namespace BanHangMVC.Controllers
{
    [Route("san-pham")]
    public class ProductController : Controller
    {
        private readonly IVegetableService _vegetableService;
        public ProductController(IVegetableService vegetableService)
        {
            _vegetableService = vegetableService;
        }


        public async Task<IActionResult> Index([FromQuery]int id)
        {
            var vegetable = await _vegetableService.GetVegetableDetail(id);
            return View(vegetable);
        }
    }
}

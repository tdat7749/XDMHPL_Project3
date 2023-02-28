using BanHangMVC.Request;
using BanHangMVC.Services.CategoryService;
using BanHangMVC.Services.VegetableService;
using Microsoft.AspNetCore.Mvc;

namespace BanHangMVC.Controllers
{
    [Route("cua-hang")]
    public class ShopController : Controller
    {
        private readonly IVegetableService _vegetableService;
        private readonly ICategoryService _categoryService;
        public ShopController(IVegetableService vegetableService, ICategoryService categoryService)
        {
            _vegetableService = vegetableService;
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]GetVegetableRequest request)
        {
            var listVegetable = await _vegetableService.GetAllVegetable(request);
            var listCategory = await _categoryService.GetAllCategory();

            ViewBag.Categories = listCategory;

            return View(listVegetable);
        }
    }
}

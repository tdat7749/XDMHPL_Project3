using BanHangMVC.Request;
using BanHangMVC.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;

namespace BanHangMVC.Controllers
{
    [Route("dang-ky")]
    public class RegisterController : Controller
    {
        private readonly ICustomerService _customerService;
        public RegisterController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var session = HttpContext.Session.GetString("customer");
            if(session != null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _customerService.Register(request);
            if(result == false)
            {
                ModelState.AddModelError("", "Tài khoản của bạn đăng ký đã tồn tại");
                return View();
            }
            TempData["result"] = "Đăng ký tài khoản thành công !";
            return RedirectToAction("Index","Register");
        }
    }
}

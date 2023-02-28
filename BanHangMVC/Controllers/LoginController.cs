using BanHangMVC.Request;
using BanHangMVC.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BanHangMVC.Controllers
{
    [Route("dang-nhap")]
    public class LoginController : Controller
    {
        private readonly ICustomerService _customerService;
        public LoginController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var customer = HttpContext.Session.GetString("customer");
            if (customer != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index([FromForm]LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var customer = await _customerService.Login(request);
            if(customer == null)
            {
                ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu");
                return View();
            }

            var customerInformation = JsonConvert.SerializeObject(customer);


            HttpContext.Session.SetString("customer", customerInformation);
            return RedirectToAction("Index","Home");
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("customer");
            return RedirectToAction("Index", "Home");
        }
    }
}

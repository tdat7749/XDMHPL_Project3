using BanHangMVC.Request;
using BanHangMVC.Services.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace BanHangMVC.Controllers
{
    public class CartController : Controller
    {

        private readonly IOrderService _orderService;
        public CartController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody]CreateOrderRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _orderService.CreateOrder(request);
            return Json(new { message = "Đặt hàng thành công !",orderId = result });

        }
    }
}

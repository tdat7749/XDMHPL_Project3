using BanHangMVC.Models;
using BanHangMVC.Request;

namespace BanHangMVC.Services.OrderService
{
    public interface IOrderService
    {
        Task<int> CreateOrder(CreateOrderRequest request);
        Task<List<OrderVm>> GetAllOrderById(int id);
    }
}

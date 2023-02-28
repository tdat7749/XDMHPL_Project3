using BanHangMVC.Models;
using BanHangMVC.Request;

namespace BanHangMVC.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<bool> Register(RegisterRequest request);
        Task<CustomerVm> Login(LoginRequest request);
    }
}

using BanHangMVC.Entities;
using BanHangMVC.Models;
using BanHangMVC.Request;

namespace BanHangMVC.Services.VegetableService
{
    public interface IVegetableService
    {
        Task<List<VegetableVm>> GetAllVegetable(GetVegetableRequest request);

        Task<VegetableVm> GetVegetableDetail(int id);

        Task<bool> UpdateVegetable(List<OrderDetail> listOrderDetail);
    }
}

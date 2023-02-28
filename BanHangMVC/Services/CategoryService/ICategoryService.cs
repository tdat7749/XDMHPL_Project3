using BanHangMVC.Models;

namespace BanHangMVC.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task<List<CategoryVm>> GetAllCategory();
    }
}

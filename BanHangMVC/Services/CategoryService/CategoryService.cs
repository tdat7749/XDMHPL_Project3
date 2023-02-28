using BanHangMVC.EF;
using BanHangMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BanHangMVC.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly BanHangDbContext _context;

        public CategoryService(BanHangDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryVm>> GetAllCategory()
        {
            var query = from c in _context.Categories
                        select c;

            var categories = await query.Select(x => new CategoryVm()
            {
                Id =x.CategoryId,
                Name = x.Name
            }).ToListAsync();


            return categories;
        }
    }
}

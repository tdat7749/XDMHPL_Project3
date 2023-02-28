using BanHangMVC.EF;
using BanHangMVC.Entities;
using BanHangMVC.Models;
using BanHangMVC.Request;
using Microsoft.EntityFrameworkCore;

namespace BanHangMVC.Services.VegetableService
{
    public class VegetableService : IVegetableService
    {
        private readonly BanHangDbContext _context;
        public VegetableService(BanHangDbContext context)
        {
            _context = context;
        }

            public async Task<List<VegetableVm>> GetAllVegetable(GetVegetableRequest request)
            {
            try
            {
                var query = from v in _context.Vegetables
                            join c in _context.Categories on v.CategoryID equals c.CategoryId
                            select new { v, c };

                if (request.Keyword != null)
                {
                    query = query.Where(x => x.v.Name.Contains(request.Keyword) || x.c.Name.Contains(request.Keyword));
                }

                if (request.catId != null)
                {
                    query = query.Where(x => x.c.CategoryId == request.catId);
                }

                if(request.order == "best-seller")
                {
                    query = query.OrderByDescending(x => x.v.Sold);
                }


                var listVegetable = await query.Select(x => new VegetableVm()
                {
                    VegetableId = x.v.VegetableID,
                    Name = x.v.Name,
                    Category = x.c.Name,
                    Unit = x.v.Unit,
                    Price = x.v.Price,
                    Amount = x.v.Amount,
                    Image = x.v.Image,
                    Sold = x.v.Sold
                }).ToListAsync();

                return listVegetable;
            }
            catch
            {
                throw new Exception();
            }
            }

        public async Task<VegetableVm> GetVegetableDetail(int id)
        {
            try
            {
                var query = from v in _context.Vegetables
                            join c in _context.Categories on v.CategoryID equals c.CategoryId
                            orderby v.Price
                            where v.VegetableID == id
                            select new { v, c };

                var vegetable = await query.Select(x => new VegetableVm()
                {
                    VegetableId = x.v.VegetableID,
                    Name = x.v.Name,
                    Category = x.c.Name,
                    Unit = x.v.Unit,
                    Price = x.v.Price,
                    Amount = x.v.Amount,
                    Image = x.v.Image
                }).FirstOrDefaultAsync();

                return vegetable;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<bool> UpdateVegetable(List<OrderDetail> listOrderDetail)
        {
            foreach (var item in listOrderDetail)
            {
                var product = await _context.Vegetables.FindAsync(item.VegetableID);
                product.Amount = product.Amount - item.Quantity;
                product.Sold = product.Sold + item.Quantity;
            }
            return true;
        }
    }
}

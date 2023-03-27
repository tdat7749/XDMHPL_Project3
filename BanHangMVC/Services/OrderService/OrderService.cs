using BanHangMVC.EF;
using BanHangMVC.Entities;
using BanHangMVC.Models;
using BanHangMVC.Request;
using BanHangMVC.Services.VegetableService;
using Microsoft.EntityFrameworkCore;

namespace BanHangMVC.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly BanHangDbContext _context;
        private readonly IVegetableService _vegetableService;
        public OrderService(BanHangDbContext context,IVegetableService vegetableService)
        {
            _context = context;
            _vegetableService = vegetableService;
        }

        public async Task<int> CreateOrder(CreateOrderRequest request)
        {
                var listOrderDetail = new List<OrderDetail>();

                foreach (var item in request.OrderDetails)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.SubTotal = item.SubTotal;
                    orderDetail.VegetableID = item.VegetableID;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.Price = item.Price;
                    listOrderDetail.Add(orderDetail);
                }

                var order = new Order()
                {
                    CustomerID = request.CustomerId,
                    Total = request.Total,
                    Note = request.Note,
                    Address = request.Address,
                    Date = DateTime.Now,
                    OrderDetails = listOrderDetail
                };

                _context.Orders.Add(order);

                await _vegetableService.UpdateVegetable(listOrderDetail);
                return await _context.SaveChangesAsync();
        }

        public async Task<List<OrderVm>> GetAllOrderById(int id)
        {
            var query = from o in _context.Orders
                        join c in _context.Customers on o.CustomerID equals c.CustomerID
                        where o.CustomerID == id
                        select new { o,c };

            var orderDetail = from od in _context.OrderDetails
                              join v in _context.Vegetables on od.VegetableID equals v.VegetableID
                              select new { od, v };

            var listOrder = await query.Select(x => new OrderVm()
            {
                OrderId = x.o.OrderID,
                FullName = x.c.FullName,
                Total = x.o.Total,
                Note = x.o.Note,
                OrderDetails = orderDetail.Select(y => new OrderDetailVm()
                {
                    OrderID = y.od.OrderID,
                    VegetableID = y.v.VegetableID,
                    VegetableName = y.v.Name,
                    Quantity = y.od.Quantity,
                    Price = y.od.Price,
                    SubTotal = y.od.SubTotal,
                    Image = y.v.Image
                }).Where(a => a.OrderID == x.o.OrderID).ToList()
            }).ToListAsync();

            return listOrder;
        }
    }
}

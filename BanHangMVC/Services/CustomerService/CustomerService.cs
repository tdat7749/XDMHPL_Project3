using BanHangMVC.EF;
using BanHangMVC.Entities;
using BanHangMVC.Models;
using BanHangMVC.Request;
using Microsoft.EntityFrameworkCore;

namespace BanHangMVC.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly BanHangDbContext _context;
        public CustomerService(BanHangDbContext context)
        {
            _context = context;
        }
        public async Task<CustomerVm> Login(LoginRequest request)
        {
            var customer = await (from c in _context.Customers
                                  where c.UserName.ToLower() == request.UserName.ToLower() && c.Password == request.Password
                                  select c).FirstOrDefaultAsync();

            if(customer == null)
            {
                return null;
            }

            var customerVm = new CustomerVm();
            customerVm.NameFull = customer.FullName;
            customerVm.UserName = customer.UserName;
            customerVm.Id = customer.CustomerID;

            return customerVm;
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var checkCustomer = await (from c in _context.Customers
                                       where c.UserName.ToLower() == request.UserName.ToLower()
                                       select c).FirstOrDefaultAsync();

            if (checkCustomer != null)
            {
                return false;
            }

            var newCustomer = new Customer();
            newCustomer.UserName = request.UserName;
            newCustomer.Password = request.Password;
            newCustomer.FullName = request.FullName;
            newCustomer.Address = request.Address;
            newCustomer.City = request.City;

            _context.Customers.Add(newCustomer);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

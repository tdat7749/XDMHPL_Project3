using BanHangMVC.Entities;

namespace BanHangMVC.Request
{
    public class CreateOrderRequest
    {
        public int CustomerId { get; set; }
        public double Total { get; set; }
        public string Note { get; set; }

        public string Address { get; set; }

        public List<CreateOrderDetailRequest> OrderDetails { get; set; }
    }
}

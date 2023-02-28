using BanHangMVC.Entities;

namespace BanHangMVC.Models
{
    public class OrderVm
    {
        public int OrderId { get; set; }
        public string FullName { get; set; }
        public double Total { get; set; }
        public string Note { get; set; }
        public List<OrderDetailVm> OrderDetails { get; set; }
    }
}

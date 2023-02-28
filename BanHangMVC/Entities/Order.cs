namespace BanHangMVC.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public string Note { get; set; }

        public string Address { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }
    }
}

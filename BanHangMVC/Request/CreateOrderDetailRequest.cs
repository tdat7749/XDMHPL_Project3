namespace BanHangMVC.Request
{
    public class CreateOrderDetailRequest
    {
        public int VegetableID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double SubTotal { get; set; }
    }
}

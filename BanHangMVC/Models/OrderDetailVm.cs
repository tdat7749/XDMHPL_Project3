namespace BanHangMVC.Models
{
    public class OrderDetailVm
    {
        public int OrderID { get; set; }
        public int VegetableID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double SubTotal { get; set; }
        public string VegetableName { get; set; }
        public string Image { get; set; }

    }
}

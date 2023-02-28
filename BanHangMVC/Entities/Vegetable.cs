namespace BanHangMVC.Entities
{
    public class Vegetable
    {
        public int VegetableID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Amount { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

        public int Sold { get; set; }
        public Category Category { get; set; }
    }
}

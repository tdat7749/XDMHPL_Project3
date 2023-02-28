namespace BanHangMVC.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public List<Order> Orders { get; set; }
    }
}

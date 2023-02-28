namespace BanHangMVC.Request
{
    public class GetVegetableRequest
    {
        public string Keyword { get; set; }
        public string order { get; set; }
        public int? catId { get; set; }
    }
}

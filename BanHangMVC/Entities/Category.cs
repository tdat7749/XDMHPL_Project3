using System.ComponentModel.DataAnnotations.Schema;

namespace BanHangMVC.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Vegetable> Vegetables { get; set; }
    }
}

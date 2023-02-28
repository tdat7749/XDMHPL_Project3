using System.ComponentModel.DataAnnotations;

namespace BanHangMVC.Request
{
    public class LoginRequest
    {
        [Required(ErrorMessage ="Không được bỏ trống")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string Password { get; set; }
    }
}

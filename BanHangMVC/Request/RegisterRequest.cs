using System.ComponentModel.DataAnnotations;

namespace BanHangMVC.Request
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Không được bỏ trống")]
        [MinLength(6,ErrorMessage = "Tài khoản phải tối thiểu 6 ký tự")]
        [MaxLength(50,ErrorMessage = "Tài khoản chỉ được tối đa 50 ký tự")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải tối thiểu 6 ký tự")]
        [MaxLength(50, ErrorMessage = "Mật khẩu chỉ được tối đa 50 ký tự")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string City { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string FullName { get; set; }
    }
}

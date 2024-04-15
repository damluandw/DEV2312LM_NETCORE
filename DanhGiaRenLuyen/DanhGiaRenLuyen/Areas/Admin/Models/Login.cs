
using System.ComponentModel.DataAnnotations;

namespace DanhGiaRenLuyen.Areas.Admins.Models
{
    public class Login
    {
        [Required(ErrorMessage ="UserName không để trống")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không để trống")]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}

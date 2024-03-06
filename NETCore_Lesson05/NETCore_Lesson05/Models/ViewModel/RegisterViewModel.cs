using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NETCore_Lesson05.Models.ViewModel
{
    public class RegisterViewModel
    {
        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(20, MinimumLength =3, ErrorMessage ="Độ dài tên từ 3-20 ký tự")]
        public string UserName { get; set; }

        [DisplayName("Họ và tên")]
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        public string FullName { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Nhập lại mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DisplayName("Hòm thư")]
        [Required(ErrorMessage = "Chưa nhập email")]
        //[DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "Email không đúng định dạng (admin@gmail.com)")]
        public string Email { get; set; }

        [DisplayName("Điện thoại")]
        [RegularExpression(@"^0\d{9,12}$", ErrorMessage ="Phải bắt đầu bằng 0 và dài 10-12 số")]
        public string Phone { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime Birthday { get; set; }

    }
}

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NETCore_Lesson05_Lab01.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [

            Display(Name = "Họ và tên"),
            Required(ErrorMessage = "Họ và tên không được để trống"),
            MinLength(6, ErrorMessage = "Họ tên ít nhất là 6 ký tự"),
            MaxLength(20, ErrorMessage = "Họ tên tối đa là 20 ký tự")
        ]
        public string FullName { get; set; }

        [DisplayName("Hòm thư")]
        [Required(ErrorMessage = "Chưa nhập email")]
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress(ErrorMessage = "Địa chỉ email không đúng định dạng")]
        [RegularExpression(@"[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "Email không đúng định dạng (admin@gmail.com)")]
        public string Email { get; set; }

        [DisplayName("Điện thoại")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^0\d{9,12}$", ErrorMessage = "Phải bắt đầu bằng 0 và dài 10-12 số")]
        [Remote(action: "VerifyPhone", controller: "Account")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string Phone { get; set; }
        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(35, ErrorMessage = "Địa chỉ không được quá 35 ký tự")]
        public string Adress { get; set; }

        [DisplayName("Ảnh đại diện")]
        public string Avatar { get; set; }

        [DisplayName("Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }

        [DisplayName("Giới tính")]
        public string Gender { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Link Facebook cá nhân")]
        [Required(ErrorMessage = "Link Facebook không được để trống")]
        [Url(ErrorMessage = "Url phải đúng định dạng bao gồm http hoặc https, tên miền VD: https://facebook.com/admin")]
        public string Facebook { get; set; }
    }
}

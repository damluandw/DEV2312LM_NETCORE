﻿using System.ComponentModel.DataAnnotations;

namespace NETCore_Lesson12_Authentication2.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email không để trống")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mật khẩu không để trống")]
        public string Password { get; set; }
    }
}

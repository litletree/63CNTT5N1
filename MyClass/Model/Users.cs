using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Mật khẩu phải được xác nhận")]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        public string ConfrimPassword { get; set; }
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage ="Email không hợp lệ")]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}

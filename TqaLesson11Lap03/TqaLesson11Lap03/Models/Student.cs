
using System;
using System.ComponentModel.DataAnnotations;

namespace TqaLesson11Lap03.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải có từ 4 đến 100 ký tự")]
        [RegularExpression(@"^[\p{L}\p{M}]+(?:\s+[\p{L}\p{M}]+)*$", ErrorMessage = "Họ tên chỉ được chứa chữ cái và khoảng trắng")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        [RegularExpression(@"^[^@\s]+@gmail\.com$", ErrorMessage = "Email phải sử dụng địa chỉ gmail.com")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).+$", ErrorMessage = "Mật khẩu phải có chữ hoa, chữ thường, chữ số và ký tự đặc biệt")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngành học")]
        public string? Branch { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        public Gender? Gender { get; set; }

        public bool IsRegular { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }




        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1963-01-01", "2008-12-31", ParseLimitsInInvariantCulture = true, ErrorMessage = "Ngày sinh phải từ 01/01/1963 đến 31/12/2008")]
        public DateTime? DateOfBirth { get; set; }




        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0 đến 10")]
        public double? Score { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}

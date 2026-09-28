using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TqaLesson07Demo.Models
{
    public class TqaMember
    {
        public int Id { get; set; }
        [DisplayName("Tài Khoản")]
        [Required(ErrorMessage="Tài khoản không được để trống")]
        [StringLength(20,MinimumLength =3,ErrorMessage ="Tài khoản có độ dài khoảng từ 3-20 ký tự")]

        public string TqaUsername { get; set; }
        [DisplayName("mật khẩu")]
        [StringLength(100,MinimumLength =8,ErrorMessage ="Mật khẩu tối thiểu 8 kí tự")]
        public string TqaPassword { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        ErrorMessage = "Email không đúng định dạng (VD: example@gmail.com)")]
        public string TqaEmail { get; set; }
        [DisplayName("Điện thoại")]
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại")]
        [RegularExpression(@"^0\d{9,9}",ErrorMessage ="Điện thoại phải là 10 ký tự số , bắt đầu bằng số 0")]
        public string TqaPhone { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThinhQuangAnh_241230659.Models;

public partial class TaiSan
{
    public int MaTs { get; set; }

    public int MaLoai { get; set; }
    [Required(ErrorMessage =" Tên tài sản ko đc để trống")]
    public string TenTs { get; set; } = null!;
    [Required(ErrorMessage = " Nguyên giá ko đc để trống")]
    [Range(1,2000, ErrorMessage ="Nguyên giá phải là 1 số từ 1 đến 2000")]
    public decimal? NguyenGia { get; set; }
    [RegularExpression(@"^.*\.(.jpg|.jpeg|png|webp)$", ErrorMessage ="Ảnh phai có đuôi .jpg, .jpeg, .png hoặc .webp")]
    public string? Anh { get; set; }

    public virtual LoaiTaiSan? MaLoaiNavigation { get; set; } = null!;
}

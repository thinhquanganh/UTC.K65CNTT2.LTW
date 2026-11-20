using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThinhQuangAnh_241230659.Models;

public partial class Sach
{
    public int MaSach { get; set; }

    public int MaTl { get; set; }

    [Required(ErrorMessage = "Tên sách không được để trống")]
    public string TenSach { get; set; } = null!;

    [Required(ErrorMessage = "Giá sách không được để trống")]
    [Range(50, 1000, ErrorMessage = "Giá sách phải từ 50 đến 1000")]
    public decimal? Gia { get; set; }

    [Required(ErrorMessage = "Tên file ảnh không được để trống")]
    [RegularExpression(@"^.+\.(jpg|jpeg|png|webp)$", ErrorMessage = "File ảnh phải có đuôi .jpg, .jpeg, .png hoặc .webp")]
    public string? Anh { get; set; }

    public virtual TheLoai? MaTlNavigation { get; set; }
}
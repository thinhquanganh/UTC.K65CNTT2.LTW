using System;
using System.Collections.Generic;

namespace ThinhQuangAnh_241230659.Models;

public partial class LoaiTaiSan
{
    public int MaLoai { get; set; }

    public string TenLoai { get; set; } = null!;

    public virtual ICollection<TaiSan> TaiSans { get; set; } = new List<TaiSan>();
}

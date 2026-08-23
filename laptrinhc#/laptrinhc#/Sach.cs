using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace QuanLySach
{
    public class Sach
    {
        // Thuộc tính
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string TenTacGia { get; set; }
        public int SoLuong { get; set; }

        // Constructor không tham số
        public Sach() { }

        // Constructor đầy đủ tham số
        public Sach(string maSach, string tenSach, string tenTacGia, int soLuong)
        {
            MaSach = maSach;
            TenSach = tenSach;
            TenTacGia = tenTacGia;
            SoLuong = soLuong;
        }

        // Phương thức nhập thông tin cơ bản
        public virtual void NhapThongTin()
        {
            Console.Write("Nhập mã sách: ");
            MaSach = Console.ReadLine();
            Console.Write("Nhập tên sách: ");
            TenSach = Console.ReadLine();
            Console.Write("Nhập tên tác giả: ");
            TenTacGia = Console.ReadLine();
            Console.Write("Nhập số lượng tồn: ");
            SoLuong = int.Parse(Console.ReadLine());
        }

        // Phương thức xuất thông tin
        public virtual void XuatThongTin()
        {
            Console.WriteLine($"Mã sách: {MaSach} | Tên sách: {TenSach} | Tác giả: {TenTacGia} | Số lượng: {SoLuong}");
        }
    }
}
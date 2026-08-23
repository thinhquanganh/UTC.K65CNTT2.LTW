using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace QuanLySach
{
    // Kế thừa từ lớp Sach
    public class SachMoi : Sach
    {
        // Bổ sung thuộc tính QRCode
        public string QRCode { get; set; }

        public SachMoi() : base() { }

        public SachMoi(string maSach, string tenSach, string tenTacGia, int soLuong, string qrCode)
            : base(maSach, tenSach, tenTacGia, soLuong)
        {
            QRCode = qrCode;
        }

        // Ghi đè phương thức nhập thông tin
        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write("Nhập mã QRCode: ");
            QRCode = Console.ReadLine();
        }

        // Ghi đè phương thức xuất thông tin
        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine($"Mã QRCode: {QRCode}");
        }
    }
}

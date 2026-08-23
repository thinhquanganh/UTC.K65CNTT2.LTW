using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập font tiếng Việt cho Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            List<SachMoi> danhSachSach = new List<SachMoi>();

            Console.Write("Nhập số lượng đầu sách cần quản lý: ");
            int n = int.Parse(Console.ReadLine());

            // Nhập danh sách sách
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhập thông tin đầu sách thứ {i + 1} ---");
                SachMoi sach = new SachMoi();
                sach.NhapThongTin();
                danhSachSach.Add(sach);
            }

            // Kiểm tra sách theo QRCode
            Console.WriteLine("\n================ KIỂM TRA SÁCH ================");
            Console.Write("Nhập mã QRCode cần kiểm tra: ");
            string qrCanTim = Console.ReadLine();

            // Tìm kiếm sách theo mã QR
            SachMoi sachTimThay = danhSachSach.Find(s =>
                string.Equals(s.QRCode, qrCanTim, StringComparison.OrdinalIgnoreCase));

            if (sachTimThay != null)
            {
                if (sachTimThay.SoLuong > 0)
                {
                    Console.WriteLine($"\n=> KẾT QUẢ: Sách CÒN trong cửa hàng.");
                    Console.WriteLine($"Tên sách: {sachTimThay.TenSach}");
                    Console.WriteLine($"Tác giả: {sachTimThay.TenTacGia}");
                    Console.WriteLine($"Số lượng tồn kho: {sachTimThay.SoLuong}");
                }
                else
                {
                    Console.WriteLine($"\n=> KẾT QUẢ: Sách có trong danh mục nhưng đã HẾT HÀNG (Số lượng tồn: 0).");
                }
            }
            else
            {
                Console.WriteLine("\n=> KẾT QUẢ: Không tìm thấy sách nào có mã QRCode này trong cửa hàng.");
            }

            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}

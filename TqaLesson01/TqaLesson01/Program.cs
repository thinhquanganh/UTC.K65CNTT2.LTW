using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TqaLesson01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choise;
            List<Student> students = new List<Student>()
            {
                new Student{ masv = "sv001", hoTen = "Vu Dinh A", ngaySinh = new DateTime(2003, 1, 15), gioiTinh = true, email = "vudinha@gmail.com", soDienThoai = "0936547921", nganhHoc = "CNTT", dtb = 8.5f, trangThai = true },
                new Student{ masv = "sv002", hoTen = "Nguyen Van B", ngaySinh = new DateTime(2003, 5, 20), gioiTinh = true, email = "nguyenvanb@gmail.com", soDienThoai = "0978154721", nganhHoc = "KTPM", dtb = 7.0f, trangThai = true },
                new Student{ masv = "sv003", hoTen = "Tran Thi C", ngaySinh = new DateTime(2004, 11, 2), gioiTinh = false, email = "tranthic@gmail.com", soDienThoai = "0912345678", nganhHoc = "CNTT", dtb = 9.0f, trangThai = false }
            };

            do
            {
                menu();
                Console.Write("Moi ban chon: ");
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        ThemSinhVien(students);
                        break;
                    case "2":
                        HienThiThongTin(students);
                        break;
                    case "3":
                        TimTheoMa(students);
                        break;
                    case "4":
                        TimGanDungTheoHoTen(students);
                        break;
                    case "5":
                        CapNhatSinhVien(students);
                        break;
                    case "6":
                        XoaSinhVien(students);
                        break;
                    case "7":
                        SapXepTheoHoTen(students);
                        break;
                    case "8":
                        SapXepTheoDtb(students);
                        break;
                    case "9":
                        HienThiDtbTu8TroLen(students);
                        break;
                    case "10":
                        HienThiDiemCaoNhat(students);
                        break;
                    case "11":
                        TinhDtbToanBo(students);
                        break;
                    case "12":
                        ThongKeTheoNganh(students);
                        break;
                    case "13":
                        ThongKeTheoTrangThai(students);
                        break;
                    case "14":
                        Console.WriteLine("Ket thuc chuong trinh.");
                        break;
                    default:
                        Console.WriteLine("Ban chon sai, vui long chon lai!");
                        break;
                }
                Console.WriteLine("\nNhan Enter de tiep tuc...");
                Console.ReadLine();
            } while (choise != "14");
        }

        static void menu()
        {
            Console.Clear();
            Console.WriteLine("-------------- CHUC NANG --------------");
            Console.WriteLine("1.\tThem sinh vien\n" +
                              "2.\tHien thi danh sach\n" +
                              "3.\tTim sinh vien theo ma\n" +
                              "4.\tTim gan dung theo ho ten\n" +
                              "5.\tCap nhat sinh vien\n" +
                              "6.\tXoa sinh vien\n" +
                              "7.\tSap xep theo ho ten\n" +
                              "8.\tSap xep theo diem trung binh\n" +
                              "9.\tHien thi sinh vien co diem tu 8 tro len\n" +
                              "10.\tHien thi sinh vien co diem cao nhat\n" +
                              "11.\tTinh diem trung binh toan bo sinh vien\n" +
                              "12.\tThong ke sinh vien theo nganh\n" +
                              "13.\tThong ke sinh vien theo trang thai\n" +
                              "14.\tThoat");
            Console.WriteLine("---------------------------------------");
        }

        static void InMotSinhVien(Student sv)
        {
            string gt = sv.gioiTinh ? "Nam" : "Nu";
            string tt = sv.trangThai ? "Dang hoc" : "Nghi hoc";
            string ns = sv.ngaySinh.HasValue ? sv.ngaySinh.Value.ToString("dd/MM/yyyy") : "Chua co";
            Console.WriteLine($"MaSV: {sv.masv,-7} | HoTen: {sv.hoTen,-18} | NgaySinh: {ns,-10} | GT: {gt,-4} | Email: {sv.email,-20} | SDT: {sv.soDienThoai,-10} | Nganh: {sv.nganhHoc,-8} | DTB: {sv.dtb,-4} | TrangThai: {tt}");
        }

        static bool KiemTraEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        static void ThemSinhVien(List<Student> students)
        {
            Console.WriteLine("--- THEM SINH VIEN ---");
            Student sv = new Student();

            while (true)
            {
                Console.Write("Nhap ma sinh vien: ");
                sv.masv = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(sv.masv))
                {
                    Console.WriteLine("Chua nhap ma sinh vien!");
                    continue;
                }
                if (students.Any(s => s.masv.Equals(sv.masv, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Ma sinh vien da ton tai, vui long nhap lai!");
                }
                else break;
            }

            while (true)
            {
                Console.Write("Nhap ho ten: ");
                sv.hoTen = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(sv.hoTen)) break;
                Console.WriteLine("Chua nhap ho ten!");
            }

            while (true)
            {
                Console.Write("Nhap ngay sinh (dd/MM/yyyy): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ns))
                {
                    sv.ngaySinh = ns;
                    break;
                }
                Console.WriteLine("Ngay sinh khong dung dinh dang (dd/MM/yyyy) hoac khong hop le, vui long nhap lai!");
            }

            Console.Write("Gioi tinh (1: Nam, 0: Nu): ");
            sv.gioiTinh = Console.ReadLine() == "1";

            while (true)
            {
                Console.Write("Nhap email: ");
                sv.email = Console.ReadLine()?.Trim();
                if (KiemTraEmail(sv.email)) break;
                Console.WriteLine("Email sai dinh dang, vui long nhap lai!");
            }

            Console.Write("Nhap so dien thoai: ");
            sv.soDienThoai = Console.ReadLine();

            Console.Write("Nhap nganh hoc (in hoa): ");
            sv.nganhHoc = Console.ReadLine();

            while (true)
            {
                Console.Write("Nhap diem trung binh (0 - 10): ");
                if (float.TryParse(Console.ReadLine(), out float dtb) && dtb >= 0 && dtb <= 10)
                {
                    sv.dtb = dtb;
                    break;
                }
                Console.WriteLine("Diem phai nam trong khoang tu 0 den 10!");
            }

            Console.Write("Trang thai (1: Dang hoc, 0: Nghi hoc): ");
            sv.trangThai = Console.ReadLine() == "1";

            students.Add(sv);
            Console.WriteLine("Them sinh vien thanh cong!");
        }

        
        static void HienThiThongTin(List<Student> students)
        {
            Console.WriteLine("--- DANH SACH SINH VIEN ---");
            if (students.Count == 0)
            {
                Console.WriteLine("Danh sach trong!");
                return;
            }
            foreach (var item in students)
            {
                InMotSinhVien(item);
            }
        }

        
        static void TimTheoMa(List<Student> students)
        {
            Console.Write("Nhap ma sinh vien can tim: ");
            string ma = Console.ReadLine()?.Trim();
            var sv = students.FirstOrDefault(s => s.masv.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (sv != null)
            {
                InMotSinhVien(sv);
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien co ma: " + ma);
            }
        }

        
        static void TimGanDungTheoHoTen(List<Student> students)
        {
            Console.Write("Nhap tu khoa ho ten can tim: ");
            string tuKhoa = Console.ReadLine()?.Trim().ToLower();
            var ketQua = students.Where(s => s.hoTen.ToLower().Contains(tuKhoa)).ToList();

            if (ketQua.Count > 0)
            {
                Console.WriteLine($"Tim thay {ketQua.Count} sinh vien:");
                foreach (var sv in ketQua)
                {
                    InMotSinhVien(sv);
                }
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien phu hop!");
            }
        }

        
        static void CapNhatSinhVien(List<Student> students)
        {
            Console.Write("Nhap ma sinh vien can cap nhat: ");
            string ma = Console.ReadLine()?.Trim();
            var sv = students.FirstOrDefault(s => s.masv.Equals(ma, StringComparison.OrdinalIgnoreCase));

            if (sv == null)
            {
                Console.WriteLine("Khong tim thay sinh vien ton tai de cap nhat!");
                return;
            }

            Console.Write($"Nhap ho ten moi (hien tai: {sv.hoTen}, Enter de bo qua): ");
            string hoTenMoi = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(hoTenMoi)) sv.hoTen = hoTenMoi;

            while (true)
            {
                Console.Write($"Nhap ngay sinh moi (dd/MM/yyyy)(hien tai:{sv.ngaySinh}, Enter de bo qua): ");
                string nsStr = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(nsStr))
                    break; 

                if (DateTime.TryParseExact(nsStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ns))
                {
                    sv.ngaySinh = ns;
                    break;
                }
                Console.WriteLine("Ngay sinh khong dung dinh dang (dd/MM/yyyy), vui long nhap lai!");
            }

            Console.Write($"Gioi tinh (1: Nam, 0: Nu, Enter de bo qua): ");
            string gtStr = Console.ReadLine();
            if (gtStr == "1") sv.gioiTinh = true;
            else if (gtStr == "0") sv.gioiTinh = false;

            while (true)
            {
                Console.Write($"Nhap email moi (hien tai: {sv.email}, Enter de bo qua): ");
                string mail = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(mail)) break;
                if (KiemTraEmail(mail)) { sv.email = mail; break; }
                Console.WriteLine("Email sai dinh dang!");
            }

            Console.Write($"Nhap so dien thoai moi (hien tai: {sv.soDienThoai},Enter de bo qua): ");
            string sdt = Console.ReadLine();
            if (!string.IsNullOrEmpty(sdt)) sv.soDienThoai = sdt;

            Console.Write($"Nhap nganh hoc moi (hien tai: {sv.nganhHoc},Enter de bo qua): ");
            string nganh = Console.ReadLine();
            if (!string.IsNullOrEmpty(nganh)) sv.nganhHoc = nganh;

            while (true)
            {
                Console.Write($"Nhap diem trung binh moi (hien tai: {sv.dtb}, Enter de bo qua): ");
                string dtbStr = Console.ReadLine();
                if (string.IsNullOrEmpty(dtbStr)) break;
                if (float.TryParse(dtbStr, out float dtb) && dtb >= 0 && dtb <= 10)
                {
                    sv.dtb = dtb;
                    break;
                }
                Console.WriteLine("Diem phai nam trong khoang tu 0 den 10!");
            }

            Console.Write($"Trang thai (1: Dang hoc, 0: Nghi hoc, Enter de bo qua): ");
            string ttStr = Console.ReadLine();
            if (ttStr == "1") sv.trangThai = true;
            else if (ttStr == "0") sv.trangThai = false;

            Console.WriteLine("Cap nhat thanh cong!");
        }

        
        static void XoaSinhVien(List<Student> students)
        {
            Console.Write("Nhap ma sinh vien can xoa: ");
            string ma = Console.ReadLine()?.Trim();
            var sv = students.FirstOrDefault(s => s.masv.Equals(ma, StringComparison.OrdinalIgnoreCase));

            if (sv != null)
            {
                students.Remove(sv);
                Console.WriteLine("Xoa sinh vien thanh cong!");
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien ton tai de xoa!");
            }
        }

        
        static void SapXepTheoHoTen(List<Student> students)
        {
            students.Sort((a, b) => string.Compare(a.hoTen, b.hoTen, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Da sap xep danh sach tang dan theo ho ten!");
            HienThiThongTin(students);
        }

        
        static void SapXepTheoDtb(List<Student> students)
        {
            students.Sort((a, b) => b.dtb.CompareTo(a.dtb)); 
            Console.WriteLine("Da sap xep danh sach giam dan theo diem trung binh!");
            HienThiThongTin(students);
        }

      
        static void HienThiDtbTu8TroLen(List<Student> students)
        {
            Console.WriteLine("--- SINH VIEN CO DIEM TU 8.0 TRO LEN ---");
            var ds = students.Where(s => s.dtb >= 8.0f).ToList();
            if (ds.Count == 0)
            {
                Console.WriteLine("Khong co sinh vien nao co diem >= 8.0.");
                return;
            }
            foreach (var sv in ds)
            {
                InMotSinhVien(sv);
            }
        }

        
        static void HienThiDiemCaoNhat(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Danh sach trong!");
                return;
            }
            float maxScore = students.Max(s => s.dtb);
            var dsMax = students.Where(s => s.dtb == maxScore).ToList();

            Console.WriteLine($"--- SINH VIEN CO DIEM CAO NHAT ({maxScore}) ---");
            foreach (var sv in dsMax)
            {
                InMotSinhVien(sv);
            }
        }

       
        static void TinhDtbToanBo(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Danh sach trong, khong the tinh diem trung binh!");
                return;
            }
            double avg = students.Average(s => s.dtb);
            Console.WriteLine($"Diem trung binh cua toan bo sinh vien: {avg:F2}");
        }

       
        static void ThongKeTheoNganh(List<Student> students)
        {
            Console.WriteLine("--- THONG KE THEO NGANH HOC ---");
            var nhomNganh = students.GroupBy(s => string.IsNullOrEmpty(s.nganhHoc) ? "Chua xac dinh" : s.nganhHoc);
            foreach (var item in nhomNganh)
            {
                Console.WriteLine($"- Nganh {item.Key}: {item.Count()} sinh vien");
            }
        }

        static void ThongKeTheoTrangThai(List<Student> students)
        {
            Console.WriteLine("--- THONG KE THEO TRANG THAI HOC TAP ---");
            int dangHoc = students.Count(s => s.trangThai);
            int nghiHoc = students.Count(s => !s.trangThai);

            Console.WriteLine($"- Dang hoc: {dangHoc} sinh vien");
            Console.WriteLine($"- Nghi hoc: {nghiHoc} sinh vien");
        }
    }
}
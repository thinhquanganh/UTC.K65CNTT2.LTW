using Microsoft.AspNetCore.Mvc;
using TqaLesson3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TqaLesson3.Controllers
{
    public class TqaProductController : Controller
    {
        private List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Quần Áo" },
                new Category { Id = 2, Name = "Giày Dép" },
                new Category { Id = 3, Name = "Đồng Hồ" },
                new Category { Id = 4, Name = "Túi Xách" },
                new Category { Id = 5, Name = "Phụ Kiện" }
            };
        }

        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Bộ Đồ Thể Thao Nam",
                    Image = "/images/products/bodothethaonam.png",
                    Price = 350000,
                    SalePrice = 280000,
                    CategoryId = 1,
                    Description = "Bộ thể thao nam chất liệu thun lạnh co giãn 4 chiều, thấm hút mồ hôi cực tốt, thích hợp tập gym, chạy bộ và mặc ở nhà.",
                    Status = true,
                    CreatedAt = new DateTime(2026, 8, 20, 9, 30, 0)
                },
                new Product
                {
                    Id = 2,
                    Name = "Quần Kaki Ống Rộng",
                    Image = "/images/products/quankakiongrong.png",
                    Price = 290000,
                    SalePrice = 220000,
                    CategoryId = 1,
                    Description = "Quần kaki form ống suông phong cách trẻ trung năng động, dễ dàng phối với áo thun hoặc sơ mi dạo phố.",
                    Status = true,
                    CreatedAt = new DateTime(2026, 8, 22, 14, 15, 0)
                },
                new Product
                {
                    Id = 3,
                    Name = "Boot Nữ Cổ Cao Sành Điệu",
                    Image = "/images/products/bootnucocao.png",
                    Price = 580000,
                    SalePrice = 450000,
                    CategoryId = 2,
                    Description = "Boot da nữ cổ cao ôm chân tôn dáng, đế êm ái chống trượt, phong cách thời trang thu đông sang trọng.",
                    Status = true,
                    CreatedAt = new DateTime(2026, 8, 25, 10, 0, 0)
                },
                new Product
                {
                    Id = 4,
                    Name = "Đồng Hồ Đeo Tay Nam Cao Cấp",
                    Image = "/images/products/donghodeotaynam.png",
                    Price = 1250000,
                    SalePrice = 990000,
                    CategoryId = 3,
                    Description = "Đồng hồ đeo tay nam W06 dây da nâu mặt nâu lịch lãm sang trọng",
                    Status = true,
                    CreatedAt = new DateTime(2026, 8, 26, 16, 45, 0)
                },
                new Product
                {
                    Id = 5,
                    Name = "Đồng Hồ Thạch Anh Nữ (Quartz)",
                    Image = "/images/products/donghothachanh.png",
                    Price = 750000,
                    SalePrice = 590000,
                    CategoryId = 3,
                    Description = "Đồng hồ thạch anh thiết kế thanh lịch, viền đính đá tinh xảo tạo nét quyến rũ cho phái đẹp.",
                    Status = true,
                    CreatedAt = new DateTime(2026, 8, 28, 11, 20, 0)
                },
                new Product
                {
                    Id = 6,
                    Name = "Đồng Hồ Thể Thao Kỹ Thuật Số",
                    Image = "/images/products/donghothethaokythuatso.png",
                    Price = 450000,
                    SalePrice = 360000,
                    CategoryId = 3,
                    Description = "Đồng hồ thể thao kỹ thuật số nam Dây đeo silicon chống thấm nước Quà tặng đồng hồ đeo tay ngoài trời nhẹ",
                    Status = true,
                    CreatedAt = new DateTime(2026, 8, 30, 8, 0, 0)
                }
            };
        }

        [Route("san-pham", Name = "product_list")]
        public IActionResult Index(int? categoryId)
        {
            var categories = GetCategories();
            var products = GetProducts();

            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value).ToList();
            }

            ViewBag.Categories = categories;
            ViewBag.Products = products;
            ViewBag.SelectedCategory = categoryId;

            return View();
        }

        [Route("chi-tiet-san-pham", Name = "product_detail")]
        public IActionResult Detail(int id)
        {
            var product = GetProducts().FirstOrDefault(p => p.Id == id);
            ViewBag.Product = product;

            return View();
        }
    }
}
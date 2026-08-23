using Microsoft.AspNetCore.Mvc;
using TqaWeb01.Models;

namespace TqaWeb01.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var listProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Dép bông", Price = 49999, CreatedAt = new DateTime(2026, 8, 20), ImageUrl = "/images/depbongditrongnha.png" },
                new Product { Id = 2, Name = "Dép đế chống trượt", Price = 79999, CreatedAt = new DateTime(2026, 8, 20), ImageUrl = "/images/depdechongtruot.png" },
                new Product { Id = 3, Name = "Dép đi trong nhà", Price = 129999, CreatedAt = new DateTime(2026, 8, 20), ImageUrl = "/images/depditrongnha.png" },
                new Product { Id = 4, Name = "Dép quai ngang", Price = 59999, CreatedAt = new DateTime(2026, 8, 20), ImageUrl = "/images/depquaingang.png" }
            };
            return View(listProducts);
        }
    }
}
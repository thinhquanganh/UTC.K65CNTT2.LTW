using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lap07.Models;

namespace Lap07.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        
        public static List<Category> Categories = new List<Category>()
        {
            new Category { Id = 1, Name = "Điện thoại & Tablet" },
            new Category { Id = 2, Name = "Laptop & Máy tính" },
            new Category { Id = 3, Name = "Phụ kiện công nghệ" },
            new Category { Id = 4, Name = "Thiết bị âm thanh" }
        };

        
        public static List<Product> Products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Laptop ASUS TUF Gaming F15",
                Price = 20000000,
                SalePrice = 17500000,
                CategoryId = 2,
                Image = "LaptopAsus.png",
                Description = "Máy tính chơi game cấu hình mạnh mẽ, độ bền chuẩn quân sự."
            },
            new Product
            {
                Id = 2,
                Name = "iPhone 15 Pro Max 256GB",
                Price = 30000000,
                SalePrice = 26500000,
                CategoryId = 1,
                Image = "Iphon15.png",
                Description = "Flagship cao cấp vỏ titan sang trọng, hiệu năng đỉnh cao."
            }
        };

        private void LoadCategoriesToViewBag(int? selectedId = null)
        {
            ViewBag.CategoryId = new SelectList(Categories, "Id", "Name", selectedId);
        }

        
        public IActionResult Index()
        {
            ViewBag.Categories = Categories;
            return View(Products);
        }

        
        public IActionResult Details(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            ViewBag.CategoryName = Categories.FirstOrDefault(c => c.Id == product.CategoryId)?.Name;
            return View(product);
        }

        
        public IActionResult Create()
        {
            LoadCategoriesToViewBag();
            return View(new Product());
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product model)
        {
            if (model.ImageUpload == null || model.ImageUpload.Length == 0)
            {
                ModelState.AddModelError("ImageUpload", "Vui lòng chọn hình ảnh để tải lên");
            }

            if (ModelState.IsValid)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "products");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.ImageUpload!.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ImageUpload.CopyToAsync(fileStream);
                }

                model.Image = uniqueFileName;
                model.Id = Products.Any() ? Products.Max(p => p.Id) + 1 : 1;
                Products.Add(model);

                return RedirectToAction(nameof(Index));
            }

            LoadCategoriesToViewBag(model.CategoryId);
            return View(model);
        }

        
        public IActionResult Edit(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            LoadCategoriesToViewBag(product.CategoryId);
            return View(product);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product model)
        {
            var existingProduct = Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null) return NotFound();

            if (ModelState.IsValid)
            {
                if (model.ImageUpload != null && model.ImageUpload.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "products");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.ImageUpload.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ImageUpload.CopyToAsync(fileStream);
                    }

                    existingProduct.Image = uniqueFileName;
                }

                existingProduct.Name = model.Name;
                existingProduct.Price = model.Price;
                existingProduct.SalePrice = model.SalePrice;
                existingProduct.CategoryId = model.CategoryId;
                existingProduct.Description = model.Description;

                return RedirectToAction(nameof(Index));
            }

            LoadCategoriesToViewBag(model.CategoryId);
            return View(model);
        }

        
        public IActionResult Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            ViewBag.CategoryName = Categories.FirstOrDefault(c => c.Id == product.CategoryId)?.Name;
            return View(product);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                Products.Remove(product);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Lap07.Models
{
    public class Product : IValidatableObject
    {
        [Key]
        [Display(Name = "Mã sản phẩm")]
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Tên sản phẩm phải có từ 6 đến 150 ký tự")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Hình ảnh")]
        public string? Image { get; set; }

        
        [NotMapped]
        [Display(Name = "Chọn tệp ảnh")]
        public IFormFile? ImageUpload { get; set; }

        [Display(Name = "Giá bán chuẩn (VNĐ)")]
        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        [Range(100000, double.MaxValue, ErrorMessage = "Giá sản phẩm phải nhỏ nhất là 100.000 VNĐ")]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        [Display(Name = "Giá khuyến mãi (VNĐ)")]
        [Required(ErrorMessage = "Giá khuyến mãi không được để trống")]
        [Range(0, float.MaxValue, ErrorMessage = "Giá khuyến mại không được âm")]
        public float SalePrice { get; set; }

        [Display(Name = "Danh mục")]
        [Required(ErrorMessage = "Vui lòng chọn danh mục sản phẩm")]
        public int CategoryId { get; set; }

        [Display(Name = "Mô tả sản phẩm")]
        [Required(ErrorMessage = "Mô tả sản phẩm không được để trống")]
        [MaxLength(1500, ErrorMessage = "Mô tả không được vượt quá 1500 ký tự")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;

        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            if (SalePrice > (Price * 0.9f))
            {
                yield return new ValidationResult(
                    $"Giá khuyến mãi ({SalePrice:N0}đ) phải nhỏ hơn giá chuẩn ít nhất 10% (tối đa là {(Price * 0.9f):N0}đ)",
                    new[] { nameof(SalePrice) }
                );
            }

            
            if (!string.IsNullOrEmpty(Description))
            {
                string[] badWords = { "die", "admin", "fack", "fuck" };
                foreach (var word in badWords)
                {
                    if (Description.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        yield return new ValidationResult(
                            $"Mô tả sản phẩm chứa từ ngữ không phù hợp ('{word}')",
                            new[] { nameof(Description) }
                        );
                        break;
                    }
                }
            }
        }
    }
}
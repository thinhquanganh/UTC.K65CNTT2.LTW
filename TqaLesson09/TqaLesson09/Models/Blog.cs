
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TqaLesson09.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên bài viết")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public byte Status { get; set; } = 1;

        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; } = DateTime.Today;

        [StringLength(100)]
        public string? Image { get; set; }

        [StringLength(350)]
        public string? Description { get; set; }
    }
}

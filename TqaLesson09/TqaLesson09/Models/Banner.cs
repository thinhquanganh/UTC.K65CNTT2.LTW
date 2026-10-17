
using System.ComponentModel.DataAnnotations;

namespace TqaLesson09.Models
{
    public class Banner
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên Banner")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public byte Status { get; set; } = 1;

        public int Prioty { get; set; } = 0;

        [StringLength(100)]
        public string? Image { get; set; }

        [StringLength(350)]
        public string? Description { get; set; }
    }
}

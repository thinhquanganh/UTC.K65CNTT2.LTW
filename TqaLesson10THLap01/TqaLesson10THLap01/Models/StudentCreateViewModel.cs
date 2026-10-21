
using Microsoft.AspNetCore.Http;

namespace TqaLesson10THLap01.Models
{
    public class StudentCreateViewModel
    {
        public Student Student { get; set; } = new Student();
        public IFormFile? Photo { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;

namespace TqaLesson11Lap04.Models
{
    public class Learner
    {
        public Learner()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int LearnerID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string FirstMidName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập ngày nhập học")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngành học")]
        public int MajorID { get; set; }

        public virtual Major? Major { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}

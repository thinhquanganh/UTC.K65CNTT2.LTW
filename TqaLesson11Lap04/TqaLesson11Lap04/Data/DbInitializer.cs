
using TqaLesson11Lap04.Models;

namespace TqaLesson11Lap04.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<SchoolContext>();

            if (context.Majors.Any())
            {
                return;
            }

            var majors = new Major[]
            {
                new Major { MajorName = "IT" },
                new Major { MajorName = "Economics" },
                new Major { MajorName = "Mathematics" }
            };

            context.Majors.AddRange(majors);
            context.SaveChanges();

            var learners = new Learner[]
            {
                new Learner
                {
                    FirstMidName = "Carson",
                    LastName = "Alexander",
                    EnrollmentDate = new DateTime(2005, 9, 1),
                    MajorID = majors[0].MajorID
                },
                new Learner
                {
                    FirstMidName = "Meredith",
                    LastName = "Alonso",
                    EnrollmentDate = new DateTime(2002, 9, 1),
                    MajorID = majors[1].MajorID
                },
                new Learner
                {
                    FirstMidName = "Arturo",
                    LastName = "Anand",
                    EnrollmentDate = new DateTime(2002, 9, 1),
                    MajorID = majors[2].MajorID
                }
            };

            context.Learners.AddRange(learners);
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
                new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
                new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 }
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment
                {
                    LearnerID = learners[0].LearnerID,
                    CourseID = 1050,
                    Grade = 5.5f
                },
                new Enrollment
                {
                    LearnerID = learners[0].LearnerID,
                    CourseID = 4022,
                    Grade = 7.5f
                },
                new Enrollment
                {
                    LearnerID = learners[1].LearnerID,
                    CourseID = 1050,
                    Grade = 3.5f
                },
                new Enrollment
                {
                    LearnerID = learners[1].LearnerID,
                    CourseID = 4041,
                    Grade = 7f
                }
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}

namespace SchoolCourses.Models.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; } = null!;

        public int CourseId { get; set; }

        public Course Course { get; set; } = null!;

        public decimal? Grade { get; set; } // 2.00 – 6.00

        public DateTime EnrolledOn { get; set; }
    }
}

namespace SchoolCourses.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int ClassNumber { get; set; } // e.g., 12

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}

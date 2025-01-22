namespace Courses_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Course[] courses = { 
                new ProgrammingCourse("C#", true, 30, "beginners"),
                new ProgrammingCourse("Java", false, 32, "advanced"),
                new DesignCourse("Photoshop", false, 80, "beginners")
            };

            foreach(var course in courses)
            {
                Console.WriteLine($"Course duration: {course.GetDuration()}");
                Console.WriteLine($"Course level: {course.GetLevel()}");
                Console.WriteLine(course.GetDescription());
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}

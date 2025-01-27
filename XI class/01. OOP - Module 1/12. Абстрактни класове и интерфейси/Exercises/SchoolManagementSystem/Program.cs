namespace SchoolManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SchoolMember petar6 = new Student("Petar Petrov", 12, 6);
            SchoolMember ivan7 = new Student("Ivan Ivanov", 13, 7);
            SchoolMember mathTeacher = new Teacher("Ahmed Ahmed", 35, "Math");

            School ppmg = new School();
            ppmg.AddMember(petar6);
            ppmg.AddMember(ivan7);
            ppmg.AddMember(mathTeacher);

            ppmg.DisplaySchoolMembers();
        }
    }
}

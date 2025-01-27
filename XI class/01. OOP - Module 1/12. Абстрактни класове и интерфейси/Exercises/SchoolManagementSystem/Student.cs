namespace SchoolManagementSystem
{
    internal class Student : SchoolMember
    {
        public int GradeLevel { get; }

        public Student(string name, int age, int level) 
            : base(name, age)
        {
            GradeLevel = level;
        }

        public override void Display()
        {
            // "Ivan Ivanov ot 2 class, 8 years old"
            Console.WriteLine($"{Name} from {GradeLevel} class, {Age} years old.");
        }
    }
}

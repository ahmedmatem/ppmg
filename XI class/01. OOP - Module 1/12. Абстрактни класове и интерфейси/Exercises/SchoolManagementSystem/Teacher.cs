using System.Diagnostics;

namespace SchoolManagementSystem
{
    internal class Teacher : SchoolMember
    {
        public string Subject { get; }

        public Teacher(string name, int age, string subject) 
            : base(name, age)
        {
            Subject = subject;
        }

        public override void Display()
        {
            // "Ivan Ivanov - Math, 34 years old"
            Console.WriteLine($"{Name} - {Subject}, {Age} years old.");
        }
    }
}

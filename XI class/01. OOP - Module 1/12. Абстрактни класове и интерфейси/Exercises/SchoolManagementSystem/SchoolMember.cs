namespace SchoolManagementSystem
{
    internal abstract class SchoolMember : ISchoolMember
    {
        public string Name { get; } = null!;

        public int Age { get; }

        public SchoolMember(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public abstract void Display();
    }
}

namespace SchoolManagementSystem
{
    internal interface ISchoolMember
    {
        public string Name { get; }
        public int Age { get; }
        public void Display();
    }
}

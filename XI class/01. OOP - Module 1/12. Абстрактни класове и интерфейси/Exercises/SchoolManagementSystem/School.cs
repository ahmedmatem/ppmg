namespace SchoolManagementSystem
{
    internal class School
    {
        private List<SchoolMember> members = new List<SchoolMember>();

        public void AddMember(SchoolMember member)
        {
            members.Add(member);
        }

        public void DisplaySchoolMembers()
        {
            foreach(SchoolMember member in members)
            {
                member.Display();
            }
        }
    }
}

namespace _05.EmployeeManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEmployee fullTimeEmployee = new FullTimeEmployee("Joe", "IT", 8000);
            IEmployee partTimeEmployee = new PartTimeEmployee("Ivan", "Chess master", 20);
            IEmployee partTimeTeacher = new PartTimeEmployee("Peter", "Teacher", 10);

            EmployeeManager manager = new EmployeeManager();
            manager.AddEmployee(fullTimeEmployee);
            manager.AddEmployee(partTimeEmployee);
            manager.AddEmployee(partTimeTeacher);

            manager.DisplayEmployees();
        }
    }
}

namespace EmployeeManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Defining some employees
            IEmployee fullTimeEmployeeJoe = new FullTimeEmployee("Joe", "Sales", 60000); 
            IEmployee fullTimeEmployeeAna = new FullTimeEmployee("Ana", "Cleaner", 80000); 
            IEmployee partTimeEmployeeHue = new PartTimeEmployee("Hue", "Waiter", 50);

            // Defining a manager
            EmployeeManager manager = new EmployeeManager();
            manager.AddEmployee(fullTimeEmployeeJoe);
            manager.AddEmployee(fullTimeEmployeeAna);
            manager.AddEmployee(partTimeEmployeeHue);

            manager.DisplayEmployees();
        }
    }
}

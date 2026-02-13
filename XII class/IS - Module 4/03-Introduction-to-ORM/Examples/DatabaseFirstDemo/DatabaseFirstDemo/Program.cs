using DatabaseFirstDemo.Data.Models.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstDemo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniDbContext();

            //var employees = GetAllEmployees(context);
            var employees = GetTopNEmployees(context, 20);
            int number = 1;
            foreach (var employee in employees)
            {
                Console.WriteLine($"{number++}. {employee.FirstName} {employee.LastName}");
            }

            UpdateTown(context, 42, "Gecovo212");
        }

        private static List<Employee> GetAllEmployees(SoftUniDbContext ctx)
        {
            var employees = ctx.Employees
                .Include(e => e.Department)
                .ToList();
            if(employees is null)
            {
                return [];
            }

            return employees;
        }

        private static void UpdateTown(SoftUniDbContext context, int id, string townName)
        {
            var t = context.Towns.Where(t => t.TownId == id).FirstOrDefault();
            if(t == null)
            {
                return;
            }
            t.Name = townName;
            context.Towns.Update(t);
            context.SaveChanges();
        }

        private static void CreateTown(SoftUniDbContext context, string townName)
        {
            Town newTown = new Town();
            newTown.Name = townName;
            context.Towns.Add(newTown);
            context.SaveChanges();
        }

        private static List<Employee> GetTopNEmployees(SoftUniDbContext ctx, int n = 10)
        {
            var employees = ctx.Employees
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ThenByDescending(e => e.DepartmentId)
                .Take(n)
                .ToList();
            if (employees is null)
            {
                return [];
            }

            return employees;
        }
    }
}

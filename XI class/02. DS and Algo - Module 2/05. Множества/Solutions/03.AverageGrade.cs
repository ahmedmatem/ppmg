using System.Text;

namespace AverageGrade
{
// INPUT
//6
//Ivancho 5.20
//Mariika 5.50
//Mariika 2.50
//Stamat 2.00
//Mariika 3.46
//Stamat 3.00

#nullable disable
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Read number 'n' of the students from the console
            int n = int.Parse(Console.ReadLine());

            // 2. Read next 'n' - lines for each student in format
            // - {student_name} {grade}
            // Save data in the Dictionary<string,List<double>> grades
            Dictionary<string, List<double>> grades = 
                new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] tokens = line.Split(' ');
                string name = tokens[0];
                double grade = double.Parse(tokens[1]);
                if (!grades.ContainsKey(name))
                {
                    grades[name] = new List<double>();
                }
                grades[name].Add(grade);
            }

            // Print students information in format
            // {name} -> {gr1 gr2 ...}(avg: {avgGr})
            foreach (var grade in grades)
            {
                List<double> allStudentGrades = grade.Value;
                double avgGrade = allStudentGrades.Average();
                StringBuilder studentGrades = new StringBuilder();
                foreach (var g in allStudentGrades)
                {
                    studentGrades.Append($"{g:f2} ");
                }
                string name = grade.Key;
                Console.WriteLine($"{name} -> {studentGrades}(avg: {avgGrade:f2})");
            }
        }
    }
}

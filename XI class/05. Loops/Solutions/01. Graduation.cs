/*

Gosho
5
5.5
6
5.43
5.5
6
5.55
5
6
6
5.43
5

Mimi
5
6
5
6
5
6
6
2
3




 */

namespace Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();

            int failNumber = 0;
            double gradeSum = 0;
            double mark = 0;
            int currentClass = 1;
            while(currentClass <= 12)
            {
                mark = double.Parse(Console.ReadLine());
                if(mark >= 4)
                {
                    gradeSum += mark;
                    currentClass++;
                }
                else
                {
                    failNumber++;
                    if(failNumber > 1)
                    {
                        break;
                    }
                }
            }

            if(failNumber > 1)
            {
                Console.WriteLine($"{studentName} has been excluded at {currentClass} grade");
            }
            else
            {
                double averageGrade = gradeSum / 12;
                Console.WriteLine($"{studentName} graduated. Average grade: {averageGrade:f2}");
            }
        }
    }
}
namespace Methods_Lab
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Извикване на метода PrintStudentInfo()
            PrintStudentInfo("Ivan Ivanov", 16, 5.67);
        }

        // Метод, който отпечатва информация за ученик. 
        // Приема като параметри име(age), аъзраст(age) и успех(grade).
        // Не връща резутат, а печата на конзолата информацията в формат

        // Ivan Ivanov
        // -------------
        // Age: 16, Grade: 5.67
        static void PrintStudentInfo(string name, int age, double grade)
        {
            Console.WriteLine(name);
            Console.WriteLine("-------------");
            Console.WriteLine("Age: " + age + ", Grade: " + grade);
        }
    }
}

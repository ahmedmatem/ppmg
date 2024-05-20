namespace Calculator_Demo
{
#nullable disable

    public class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());

            if(IsEven(a))
            {
                Console.WriteLine("even");
            }
            else
            {
                Console.WriteLine("odd");
            }
        }

        // Вариант 1
        static bool IsEven(int a)
        {
            if(a % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //// Вариант 2
        //static bool IsEven(int a)
        //{
        //    return a % 2 == 0;
        //}
    }
}

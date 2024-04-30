using Microsoft.VisualBasic;

namespace Method_Signature
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Извикваме метода, който чертае запълнен квадрат със страна 10.
            DrawSquare(10);
        }

        // Метод, който чертае запълнен квадрат
        // Ako n = 4 имаме следния квадрат:
        //      --------    <-- DrawLine(4)
        //      -\/\/\/-    <-- DrawMiddleLine(4) ,(n-2) пъти, т.е 2 пъти
        //      -\/\/\/-    <-- DrawMiddleLine(4)
        //      --------    <-- DrawLine(4)
        static void DrawSquare(int n)
        {
            DrawLine(n);// '--------'
            for (int i = 0; i < n - 2; i++)
            {
                DrawMiddleLine(n);  // -\/\/\/-  <-- (n-2)  пъти
            }
            DrawLine(n);// '--------'
        }

        // Метод, който чертае ред само с тирета - '--------'
        static void DrawLine(int n)
        {
            for (int i = 0; i < 2 * n; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        // Метод, който чертае междинните редове - '-\/\/\/-'
        static void DrawMiddleLine(int n)
        {
            Console.Write("-");
            for (int i = 0;i < 2 * n - 2; i++)
            {
                if(i % 2 == 0)
                {
                    Console.Write(@"\");
                }
                else
                {
                    Console.Write("/");
                }
            }
            Console.WriteLine("-");
        }
    }
}

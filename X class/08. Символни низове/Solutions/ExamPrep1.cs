using System.ComponentModel;
using System.Data.SqlTypes;
using System;

namespace Exam1
{
#nullable disable

    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //1.Премахнете водещите и крайните празни места(Trim).
            input = input.Trim();

            //2.Проверете дали съдържа думата "School"(Contains).
            if (input.Contains("School"))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            //3.Намерете на коя позиция се появява първо буквата "а"(IndexOf).
            int positionOfA = input.IndexOf("a");
            int lastPositionOfA = input.LastIndexOf("cat");

            //4.Изведете първите 5 символа от низа(Substring).
            string first5Chars = input.Substring(0, 5);
            string allAfterFirst5Chars = input.Substring(5);

            //5.Превърнете целия низ в главни букви(ToUpper).
            input = input.ToUpper();
            // input = input.ToLower()

            //6.Ако низът съдържа думата "exam", заменете я с "test"(Replace).
            input = input.Replace("exam", "test");

        }
    }
}

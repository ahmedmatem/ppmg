using System.Data.SqlTypes;
using System;

namespace Exam2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Въведен е низ с пълното име на ученик(примерно: "Иван Иванов").
            string fullName = Console.ReadLine()!;

            //Изведете само фамилията на ученика с главни букви.
            //Ако между имената има повече от един интервал, ги премахнете.

            //Указания:
            //•	Премахнете излишните интервали(Trim, Replace).
            fullName = fullName.Trim();
            // string[] nameParts = fullName.Split(' ');
            //•	Намерете къде е интервалът между двете имена(IndexOf).
            int intervalPosition = fullName.IndexOf(" ");
            //•	Извлечете фамилията(Substring).
            string lastName = fullName.Substring(intervalPosition);

            //•	Превърнете я в главни букви(ToUpper).
            lastName = lastName.ToUpper();
            Console.WriteLine(lastName);

            //Пример:
            //Вход: " Иван Иванов "
            //Изход: "ИВАНОВ"

        }
    }
}

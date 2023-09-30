using System;

namespace GuessPassword
{
    class GuessPasword
    {
        static void Main(string[] args)
        {
            // записваме истинската парола в константа
            const string OROGINE_PASSWORD = "s3cr3t!P@ssw0rd";

            // прочитаме парола от конзолата
            string password = Console.ReadLine();

            // сравняваме двете пароли
            if(password == OROGINE_PASSWORD)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}

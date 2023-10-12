namespace Guess_Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // декларираме оригиналната парола
            const string RealPassword = "s3cr3t!P@ssw0rd";

            // прочитаме предполагаема парола от конзолата
            string password = Console.ReadLine();

            // сравняваме, дали двете пароли съвпадат
            if(password == RealPassword)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password");
            }
        }
    }
}
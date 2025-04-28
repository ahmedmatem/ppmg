namespace _03.Username
{
#nullable disable
    internal class Program
    {
        static void Main(string[] args)
        {
            // [ahmedmatem]@gmail.com
            string email = Console.ReadLine();

            int atPosition = email.IndexOf("@");
            // Console.WriteLine(atPosition);

            string username = email.Substring(0, atPosition);
            Console.WriteLine($"Username: {username}");

            string domain =email.Substring(atPosition + 1);
            Console.WriteLine($"Domain: {domain}");
        }
    }
}

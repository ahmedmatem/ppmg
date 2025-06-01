namespace _03.PrePostAction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrePostAction(10);
        }

        static void PrePostAction(int n)
        {
            if(n != 0)
            {
                // Отпеатваме n
                Console.WriteLine("PreAction: " + n);

                // Извиква себе си с единица по малка стойност
                PrePostAction(n - 1);

                Console.WriteLine("PostAction: " + n);
            }
            
        }
    }
}

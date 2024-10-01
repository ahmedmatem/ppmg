namespace _04._DepositConverter
{
    public class Program
    {
        // Напишете програма, която изчислява каква сума ще
        // получите в края на депозитния период при определен
        // лихвен процент. Използвайте следната формула: 
        // сума = депозирана сума  + срок на депозита* ((депозирана сума * годишен лихвен процент ) / 12)

        static void Main(string[] args)
        {
            double depAmount = double.Parse(Console.ReadLine());
            int depTime = int.Parse(Console.ReadLine());
            double interestInPercent = double.Parse(Console.ReadLine());

            double result = depAmount + depTime * ((depAmount * interestInPercent / 100) / 12);

            Console.WriteLine(result);
        }
    }
}

namespace _18._BonusPoints
{
    public class Program
    {
        static void Main(string[] args)
        {
            int startPoint = int.Parse(Console.ReadLine());
            double bonusPoints = 0;

            if(startPoint <= 100)
            {
                bonusPoints += 5;
            }
            else if(100 < startPoint && startPoint <= 1000)
            {
                bonusPoints += 0.2 * startPoint;
            }
            else
            {
                bonusPoints += 0.1 * startPoint;
            }

            // Additional bonus points
            if(startPoint % 2 == 0)
            {
                bonusPoints++;
            }
            if(startPoint % 10 == 5)
            {
                bonusPoints += 2;
            }

            Console.WriteLine(bonusPoints);
            Console.WriteLine(startPoint + bonusPoints);
        }
    }
}

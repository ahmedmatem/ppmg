namespace Traffic_Jam
{

//4
//Hummer H2
//Audi
//Lada
//Tesla
//Renault
//Trabant
//Mercedes
//MAN Truck
//green
//green
//Tesla
//Renault
//Trabant
//end


    internal class Program
    {
        static void Main(string[] args)
        {
            //The number of cars that can pass during the green light.
            int allowedNumberOfCarsOnGreenLight
                = int.Parse(Console.ReadLine()!);
            int allPassedCars = 0;

            Queue<string> cars = new Queue<string>();

            string input = Console.ReadLine()!;

            while(input != "end")
            {
                if(input == "green")
                {
                    int passedCarsDuringGreenLight = allowedNumberOfCarsOnGreenLight;
                    while(passedCarsDuringGreenLight > 0)
                    {
                        passedCarsDuringGreenLight--;
                        if (cars.Count > 0)
                        {
                            string car = cars.Dequeue();
                            Console.WriteLine($"{car} passed!");
                            allPassedCars++;
                        }
                    }                    
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine()!;
            }

            Console.WriteLine($"{allPassedCars} cars passed the crossroads.");
        }
    }
}

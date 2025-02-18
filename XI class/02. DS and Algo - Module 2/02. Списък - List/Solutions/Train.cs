namespace Train
{
#nullable disable
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> carriages = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int carriageCapacity = int.Parse(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputParts = input.Split();
                if (inputParts[0] == "Add")
                {
                    // Command Add was entered
                    int passengers = int.Parse(inputParts[1]);
                    carriages.Add(passengers);
                }
                else
                {
                    // Number of passengers that must be boarded in the train
                    int passengersToBoard = int.Parse(inputParts[0]);
                    for(int i = 0; i < carriages.Count; i++)
                    {
                        int freeSeats = carriageCapacity - carriages[i];
                        if(freeSeats >= passengersToBoard)
                        {
                            carriages[i] += passengersToBoard;
                            break;
                        }
                    }

                }
            }
            Console.WriteLine(string.Join("-|-", carriages));
        }
    }
}

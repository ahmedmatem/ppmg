namespace NumberByText
{
    /// <summary>
    /// Програмата отпечатва с думи на английски името на числото в интервала от 0 до 100.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // Прочитаме число в интервала [0..100] от конзолата
            int number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine("zero");
            }
            else if (number == 100)
            {
                Console.WriteLine("one hundred");
            }
            else
            {
                //Отделяме цифрата на единиците и десетиците в числото
                int edinici = number % 10;
                int desetici = number / 10;

                // проверка и печат на десетиците
                if(desetici == 1) // имаме число от вида 1Х, където Х е 0..9 
                {
                    // проверка на единиците
                    switch(edinici)
                    {
                        case 0:
                            Console.WriteLine("ten");
                            break;
                        case 1:
                            Console.WriteLine("eleven");
                            break;
                        case 2:
                            Console.WriteLine("twelve");
                            break;
                        case 3:
                            Console.WriteLine("thirteen");
                            break;
                        case 4:
                            Console.WriteLine("fourteen");
                            break;
                        case 5:
                            Console.WriteLine("fifteen");
                            break;
                        case 6:
                            Console.WriteLine("sixteen");
                            break;
                        case 7:
                            Console.WriteLine("seventeen");
                            break;
                        case 8:
                            Console.WriteLine("eighteen");
                            break;
                        // case 0 --> 10
                        case 9:
                            Console.WriteLine("nineteen");
                            break;
                        default:
                            break;
                    }
                }
                else if(desetici == 2)
                {
                    Console.Write("twenty ");
                }
                else if (desetici == 3)
                {
                    Console.Write("thirty ");
                }
                else if (desetici == 4)
                {
                    Console.Write("forty ");
                }
                else if (desetici == 5)
                {
                    Console.Write("fifty ");
                }
                else if (desetici == 6)
                {
                    Console.Write("sixty ");
                }
                else if (desetici == 7)
                {
                    Console.Write("seventy ");
                }
                else if (desetici == 8)
                {
                    Console.Write("eighty ");
                }
                else if (desetici == 9)
                {
                    Console.Write("ninety ");
                }

                if(desetici != 1) // при равно сме отпечатали резултата горе
                {
                    // проверка и печат на единиците
                    if (edinici == 1)
                    {
                        Console.WriteLine("one");
                    }
                    else if (edinici == 2)
                    {
                        Console.WriteLine("two");
                    }
                    else if (edinici == 3)
                    {
                        Console.WriteLine("three");
                    }
                    else if (edinici == 4)
                    {
                        Console.WriteLine("four");
                    }
                    else if (edinici == 5)
                    {
                        Console.WriteLine("five");
                    }
                    else if (edinici == 6)
                    {
                        Console.WriteLine("six");
                    }
                    else if (edinici == 7)
                    {
                        Console.WriteLine("seven");
                    }
                    else if (edinici == 8)
                    {
                        Console.WriteLine("eight");
                    }
                    else if (edinici == 9)
                    {
                        Console.WriteLine("nine");
                    }
                }
                
            }

            Console.ReadLine(); // пауза
        }
    }
}

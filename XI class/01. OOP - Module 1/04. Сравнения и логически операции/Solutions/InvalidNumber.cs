int number = int.Parse(Console.ReadLine());

//if (number < 100 || number > 200)
//{
//    Console.WriteLine("invalid");
//}

if(!(number >= 100 && number <= 200))
{
    Console.WriteLine("invalid");
}
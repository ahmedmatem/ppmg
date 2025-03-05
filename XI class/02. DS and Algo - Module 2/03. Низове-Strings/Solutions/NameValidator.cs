namespace NameValidator_v1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bool result = char.IsLetter(ch);
            //bool result = char.IsDigit(ch);
            //bool result = char.IsLetterOrDigit(ch);

            //string[] names = Console.ReadLine()!.Split(", ");
            string[] names = Console.ReadLine()!
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in names)
            {
                if (3 <= name.Length && name.Length <= 16)
                {
                    bool valid = true;
                    foreach (var ch in name)
                    {
                        if (!(char.IsLetterOrDigit(ch) || ch == '-' || ch == '_'))
                        {
                            valid = false;
                            break;
                        }
                    }
                    if (valid)
                    {
                        Console.WriteLine(name);
                    }
                }
            }
        }
    }
}

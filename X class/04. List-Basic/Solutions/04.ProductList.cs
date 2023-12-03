namespace ProductList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Прочитаме броя на продуктите, които ще бъдат въведени от конзолата
            int n = int.Parse(Console.ReadLine());

            // Създаваме празен списък от продукти
            List<string> products = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string product = Console.ReadLine();    // четем продуцт от конзолата
                products.Add(product);                  // Добавяме го към списъка
            }

            // сортиране на продуктите
            products.Sort();
            products.Reverse(); // Обръщане на реда на продуктите

            // Отпечатваме всеки продукт с номер пред него
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i+1}. {products[i]}");
            }
        }
    }
}
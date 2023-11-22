using System;

namespace PalindromeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            int lastElementPosition = word.Length - 1; // последен индеь
            int middlePosition = word.Length / 2; // индекса в среадата

            bool isPalindrome = true;
            int leftIndex, rightIndex;
            for (
                leftIndex = 0, rightIndex = lastElementPosition; // инициализация
                leftIndex < middlePosition; // проверка
                leftIndex++, rightIndex--) // стъпка
            {
                if(word[leftIndex] != word[rightIndex]) // проверка за съвпадение на символи
                {
                    isPalindrome = false;
                    break;
                }
            }

            if(isPalindrome)
            {
                Console.WriteLine($"{word} is a palindrme.");
            }
            else
            {
                Console.WriteLine($"{word} is NOT a palindrme.");
            }
        }
    }
}

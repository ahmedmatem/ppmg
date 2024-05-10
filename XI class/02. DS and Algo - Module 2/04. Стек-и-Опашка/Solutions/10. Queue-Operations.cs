namespace Stack_Operations
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            // 1. Read N, S, X numbers seprated by interval
            // for example: 5 2 13
            // Resut
            // N = 5, S = 2, X = 13
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int N = input[0];
            int S = input[1];
            int X = input[2];

            // 2. Read the next N(=5) numbers and push them in the stack.
            // Example: 1 13 45 32 4
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            //Stack<int> stack = new Stack<int>(numbers);
            Stack<int> stack = new Stack<int>();
            foreach (var number in numbers)
            {
                stack.Push(number);
            }

            // 3. Pop S number of elements from stack
            for(int i = 0; i < S; i++)
            {
                if(stack.Count() > 0)
                {
                    stack.Pop();
                }
            }
                        
            if(stack.Count() == 0) // stack is empty
            {
                // 4.1. Print 0 if the stack is empty
                Console.WriteLine(0);
            }
            else // stack is not empty
            {
                // 4.2 Print true if the X is in the stack
                bool xExists = stack.Contains(X);
                if (xExists)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    // 4.3. Print the smallest element in the stack

                    // Variant 1

                    //int smallestElement = stack.Min();
                    //Console.WriteLine(smallestElement);

                    // Variant 2

                    //int min = stack.Peek();
                    //while(stack.Count() > 0)
                    //{
                    //    int el = stack.Pop();
                    //    if (el < min)
                    //    {
                    //        min = el;
                    //    }
                    //}
                    //Console.WriteLine(min);

                    // Variant 3
                    int min = SmallestElement(stack);
                    Console.WriteLine(min);
                }
            }
        }

        /// <summary>
        /// Method finds the smallest element in the stack
        /// </summary>
        /// <param name="stack">Stack of numbers</param>
        /// <returns>Smallest element in the stack</returns>
        static int SmallestElement(Stack<int> stack)
        {
            int min = stack.Peek();
            while (stack.Count() > 0)
            {
                int el = stack.Pop();
                if (el < min)
                {
                    min = el;
                }
            }
            return min;
        }
    }
}

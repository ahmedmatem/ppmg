namespace Matching_Brackets
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine()!;

            Stack<int> openingBracketsIndexes = new Stack<int>();

            
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    openingBracketsIndexes.Push(i);
                }
                if (expression[i] == ')')
                {
                    int endOpeningBracketIndex = openingBracketsIndexes.Pop();
                    int subExpressionLength = i - endOpeningBracketIndex + 1;
                    string subExpression = expression
                        .Substring(endOpeningBracketIndex, subExpressionLength);
                    Console.WriteLine(subExpression);
                }
            }
        }
    }
}

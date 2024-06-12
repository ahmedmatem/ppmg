using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorial_Calculator
{
    public class Calculator
    {
        public static string Power(
            string firstNumber,
            string secondNumber)
        {
            BigInteger firstBigNumber = BigInteger.Parse(firstNumber);
            BigInteger secondBigNumber = BigInteger.Parse(secondNumber);
            BigInteger result = BigInteger.One;
            for (int i = 1; i <= secondBigNumber; i++)
            {
                result *= firstBigNumber;
            }
            return result.ToString();
        }

        public static string Factoriel(string number)
        {
            BigInteger result = BigInteger.One;
            BigInteger bigNumber = BigInteger.Parse(number);
            for (int i = 2; i <= bigNumber; i++)
            {
                result *= i;
            }
            return result.ToString();
        }
    }
}

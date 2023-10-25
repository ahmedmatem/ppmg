using System;

/**
 * Problem: Simple Calculator
 * 
 * Write a C# program that acts as a simple calculator. 
 * It should repeatedly prompt the user for two numbers and an operation 
 * (addition, subtraction, multiplication, or division) using a while loop.
 * Perform the calculation and display the result.
 **/

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            while((command = Console.ReadLine()) != "End")
            {
                // четем две числа от конзолата
                double firstNumber = double.Parse(command);
                double secondnumber = double.Parse(Console.ReadLine());
                // четем операция от конзолата - addition, subtraction, multiplication, or division
                string operation = Console.ReadLine();
                double result = operation switch
                {
                    "addition" => firstNumber + secondnumber,
                    "subtraction" => firstNumber - secondnumber,
                    "multiplication" => firstNumber * secondnumber,
                    "division" => firstNumber / secondnumber,
                };
                Console.WriteLine(result);
            }
            Console.WriteLine("Calculator is sweetched off.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    public class Student
    {
        // Полета (Fields)
        private string name;
        private double grade;
        private int credits;

        // Свойства (Properties)
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length > 2)
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("Name must be bigger than 2 symbols.");
                }
            }
        }

        public double Grade
        {
            get { return grade; }
            set
            {
                if (value >= 2 && value <= 6)
                {
                    grade = value;
                }
                else
                {
                    Console.WriteLine("Invalid grade.");
                }
            }
        }

        public int Credits
        {
            get { return credits; }
            set
            {
                if (value >= 0 && value <= 10) // кредити от 0 до 10
                {
                    credits = value;
                }
                else
                {
                    Console.WriteLine($"Invalid credits amount - {value}.");
                }
            }
        }

        // Конструктори (Constructors)

        public Student(string name)
        {
            Name = name;
            Grade = 6;
            Credits = 0;
        }

        public Student(string name, double grade, int credits)
            : this(name)
        {
            Grade = grade;
            Credits = credits;
        }

        // Методи (Methods)

        public void AddGrade(double grade)
        {
            if(grade >=2 && grade <= 6)
            {
                double newGrade = (Grade + grade) / 2;
                Grade = newGrade;
                Console.WriteLine($"New grade after adding of {grade} is {Grade}.");
            }
            else
            {
                Console.WriteLine("Adding grade is inpossible. Grade must be in [2..6].");
            }
        }

        public void AddCredits(int credits)
        {

            Credits += credits;
        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine("Student information");
            Console.WriteLine("===================");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Grade: {Grade}");
            Console.WriteLine($"Credits: {Credits}");
        }
    }
}

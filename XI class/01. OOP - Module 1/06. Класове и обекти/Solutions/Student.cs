namespace ClassDemo
{
    public class Student
    {
        // Полета (Fields)

        private double grade;
        private int credits;

		// Свойства (Properties)
        public string Name { get; set; }

		public double Grade
		{
			get { return grade; }
			set
			{ 
				if(value >= 2 && value <= 6)
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
				if(value >= 0 && value <= 10) // кредити от 0 до 10
				{
                    credits = value;
                }
				else
				{
                    Console.WriteLine("Invalid credits amount.");
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

		public void AddGrade(double newGrade)
		{
			double nextGrade = (Grade + newGrade) / 2;
			Grade = nextGrade;
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

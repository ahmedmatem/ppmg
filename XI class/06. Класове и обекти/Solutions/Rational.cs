namespace Rational_Numbers;

public class Rational
{
    // hidden Fields
    private int numerator;
    private int denominator;

    public Rational(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.Denominator = denominator;
        Simplify(); // simplifying rational number
    }    

    // Property Denominator watches denominator out of being 0
    public int Denominator
    {
        get { return denominator; }
        private set // hidden setter due to private access modificatory
        {
            if (value == 0)
            {
                throw new Exception("Denominator cannot be 0");
            }

            denominator = value;
        }
    }

    // Addition of two rational numbers
    public Rational Add(Rational r)
    {
        int a = (this.numerator * r.denominator) + (this.denominator * r.numerator);
        int b = this.denominator * r.denominator;

        int gcd = GCD(a, b);

        return new Rational(a / gcd, b / gcd);
    }

    // Subtraction of two rational numbers
    public Rational Subtract(Rational r)
    {
        int a = (this.numerator * r.denominator) - (this.denominator * r.numerator);
        int b = this.denominator * r.denominator;
        int gcd = GCD(a, b);
        return new Rational(a / gcd, b / gcd);
    }

    // Multiplication of two rational numbers
    public Rational MultiplyBy(Rational r)
    {
        int a = this.numerator * r.numerator;
        int b = this.denominator * r.denominator;
        int gcd = GCD(a, b);
        return new Rational(a / gcd, b / gcd);
    }

    // Division of two rational numbers
    public Rational DivideBy(Rational r)
    {
        int a = this.numerator * r.denominator;
        int b = this.denominator * r.numerator;
        int gcd = GCD(a, b);
        return new Rational(a / gcd, b / gcd);
    }

    // Simplifying
    private void Simplify()
    {
        int gcd = GCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;
    }

    // Comparison of two rational numbers
    public bool IsEqual(Rational r)
    {
        return this.numerator * r.denominator == this.Denominator * r.numerator;
    }


    // Return string that represent rational number in format {numerator}/{denominator}
    // Example: 3/4, -7/2.
    // If the number has denominator equals to 0 return only its numerator.
    public string Print()
    {
        if (denominator == 1)
        {
            return numerator.ToString();
        }

        return $"{numerator}/{Denominator}";
    }


    // Return string that represent rational number in decimal format.
    public string PrintAsDecimal()
    {
        double decimalNumber = (double)numerator / denominator;
        return decimalNumber.ToString();
    }

    // Get greatest common divider of two integers
    private int GCD(int a, int b)
    {
        while(b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}

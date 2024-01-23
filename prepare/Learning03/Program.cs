using Learning03;
using System;

class Program
{
    static void Main(string[] args)
    {
        var fraction = new Fraction();
        var fraction1 = new Fraction(5);
        var fraction2 = new Fraction(3,4);
        var fraction3 = new Fraction(1,3);

        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());

        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());
    }
}
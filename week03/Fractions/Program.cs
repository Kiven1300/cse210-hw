using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.\n");

        Fraction fraction1 = new Fraction();
        Console.WriteLine("Fraction 1 (no parameters):");
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());
        Console.WriteLine();

        Fraction fraction2 = new Fraction(5);
        Console.WriteLine("Fraction 2 (one parameter - 5):");
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());
        Console.WriteLine();

        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine("Fraction 3 (two parameters - 3/4):");
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());
        Console.WriteLine();

        Fraction fraction4 = new Fraction(6, 7);
        Console.WriteLine("Fraction 4 (6/7):");
        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());
        Console.WriteLine();

        Fraction fraction5 = new Fraction(1, 3);
        Console.WriteLine("Fraction 5 (1/3):");
        Console.WriteLine(fraction5.GetFractionString());
        Console.WriteLine(fraction5.GetDecimalValue());
        Console.WriteLine();

        Console.WriteLine("Testing getters and setters:");
        Fraction fraction6 = new Fraction();
        Console.WriteLine($"Initial fraction: {fraction6.GetFractionString()}");
        
        fraction6.SetTop(3);
        fraction6.SetBottom(5);
        Console.WriteLine($"After SetTop(3) and SetBottom(5): {fraction6.GetFractionString()}");
        Console.WriteLine($"GetTop(): {fraction6.GetTop()}");
        Console.WriteLine($"GetBottom(): {fraction6.GetBottom()}");
        Console.WriteLine($"Decimal value: {fraction6.GetDecimalValue()}");
    }
}
using Learning05;
using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>
        {
            new Square("Red", 22.9),
            new Rectangle("Blue", 15,7),
            new Circle("White", 50)
        };

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()} - Area: {shape.GetArea()}");
        }


    }
}
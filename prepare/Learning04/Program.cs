using Learning04;
using System;

class Program
{
    static void Main(string[] args)
    {
        var name = "Anderson Moroni";
        var topic = "Example of code";

        var assignment = new Assignment(name, topic);
        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine();

        var mathAssignment = new MathAssignment(name, topic, "8.3", "4.9");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());
        Console.WriteLine();

        var writeAssignment = new WritingAssignment(name, topic, "The Causes of World War III");
        Console.WriteLine(writeAssignment.GetSummary());
        Console.WriteLine(writeAssignment.GetWritingInformation());
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);
        string letter = string.Empty;

        // Verify the letter
        if(grade >= 90)
        {
            letter = "A";
        }
        else if(grade >= 80 && grade < 90)
        {
           letter = "B";
        }
        else if(grade >= 70 && grade < 80)
        {
            letter = "C";
        }
        else if(grade >= 60 && grade < 70)
        {
            letter = "D";
        }
        else if(grade < 60)
        {
            letter = "F";
        }

        // Show message
        if(grade >= 70)
        {
            Console.WriteLine($"Congratulation, your grade is {letter}");
        }
        else
        {
            Console.WriteLine($"Was almost there, try again, your grade is {letter}");
        }
    }
}
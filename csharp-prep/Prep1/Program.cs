using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is yout first name? ");
        string firstName = Console.ReadLine();

        Console.Write("What is yout last name? ");
        string lastName = Console.ReadLine();

        Console.Write("");
        Console.WriteLine($"You name is {lastName}, {firstName} {lastName} ");
    }
}
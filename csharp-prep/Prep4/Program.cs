using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int inputUser;
        List<int> numbers = new List<int>();

        do
        {
            Console.Write("Enter number: ");
            inputUser = int.Parse(Console.ReadLine());
            numbers.Add(inputUser);

        } while (inputUser != 0);

        Console.WriteLine($"The sum is: {numbers.Sum()}");
        Console.WriteLine($"The average is:: {numbers.Average()}");
        Console.WriteLine($"The largest number is: {numbers.Max()}");
    }
}

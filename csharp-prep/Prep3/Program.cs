using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);
        int userGuess;
        string playAgain = "yes";

        do
        {
            Console.Write("What is your guess? ");
            userGuess = int.Parse(Console.ReadLine());

            if(userGuess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if(userGuess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Do you want play again? [Yes] or [No]");
                playAgain = Console.ReadLine().ToLower();
                magicNumber = randomGenerator.Next(1, 100);

            }

        } while (playAgain == "yes");

    }
}
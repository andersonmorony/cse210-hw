using Develop03;
using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        var scripture = new Scripture();
        var entry = "";
        var pharse = scripture.GetPhase();

        while (entry.ToLower() != "quit")
        {
            // Always clear the console
            Console.Clear();

            // Display the scripture
            scripture.DisplayScripture();

            if(entry.ToLower() == "yes")
            {
                DisplayHidenWords();
            }

            // Ask for type
            Console.WriteLine("\n \nPress Enter to continue or type 'quit' to finish:");

            if (pharse.GetCounter() > 1)
            {
                Console.WriteLine("Do you need help? [YES] or Enter to continue:");
            }

            entry = Console.ReadLine();
        }

        void DisplayHidenWords()
        {
            var words = pharse.GetWordsHiden();
            Console.WriteLine("\nWords Removed - Count: {0}:", words.Count);
            foreach (var p in words)
            {
                Console.WriteLine(p);
            }
        }
    }

}
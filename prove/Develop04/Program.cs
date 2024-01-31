using Develop04;
using System;

class Program
{
    static void Main(string[] args)
    {
        string choosed = string.Empty;
        var breatinhgActivity = new Breathing("Welcome to the breating activity.", "This activity will help you relax by walking your though breathing in and out slowly. Clear you mind and focus on your breating.");
        var reflectionActivity = new Reflection("Welcome to the Reflection activity.", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        var listingActivity = new Listing("Welcome to the Listing activity.", "his activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        while (choosed != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1 - Start breathing activity");
            Console.WriteLine(" 2 - Start reflection activity");
            Console.WriteLine(" 3 - Start listing activity");
            Console.WriteLine(" 4 - Quit");
            Console.Write("Select a choice from the menu: ");
            
            choosed = Console.ReadLine();

            switch (choosed)
            {
                case "1":
                    Breathing();
                    break;
                case "2":
                    Reflection();
                    break;
                case "3":
                    Listing();
                    break;
            }
        }

        void Breathing()
        {
            breatinhgActivity.Start();
        }

        void Reflection()
        {
            reflectionActivity.Run();
        }

        void Listing()
        {
            listingActivity.Run();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop04
{
    public class Activity
    {
        private string _title;
        private string _description;
        protected int _seconds;

        public Activity(string title, string description)
        {
            _title = title;
            _description = description;
        }

        public string GetTitle()
        {
            return _title;
        }

        public string GetDescription()
        {
            return _description;
        }
        public void SetSeconds(int second)
        {
            _seconds = second;
        }
        public virtual void Run()
        {

        }

        public void DisplayWelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine(_title);
            Console.WriteLine();
            Console.WriteLine(_description);

            Console.Write("\nHow long in seconds, would you like for you session? ");

            // Save value
            var seconds = int.Parse(Console.ReadLine());
            _seconds = seconds;

            Console.Clear();
            Console.Write("Get ready...");
            showAnimation(3);
            Console.WriteLine();
        }

        public void DisplayEndMessage()
        {
            Console.WriteLine();
            Console.WriteLine("\nWell done!!");
            showAnimation(3);
            Console.WriteLine($"\nYou have completed another {_seconds} seconds of the Breathing Activity.");
            showAnimation(5);
        }

        public void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        public void showAnimation(int seconds)
        {
            DateTime current = DateTime.Now;
            DateTime FutureDate = current.AddSeconds(seconds);
            List<string> charAnimation = new List<string>
            {
                "-",
                "\\",
                "|",
                "/",
                "-",
                "\\",
                "|",
                "/"
            };

            while(current <  FutureDate)
            {
                foreach(string item in charAnimation)
                {
                    Console.Write(item);
                    Thread.Sleep(200);
                    Console.Write("\b \b");
                }
                current = DateTime.Now;
            }
        }
    }
}

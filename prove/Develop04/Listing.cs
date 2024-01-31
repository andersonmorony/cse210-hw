using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop04
{
    public class Listing : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        private List<string> _answers = new List<string>();
        public Listing(string title, string description)
            : base(title, description)
        {
            
        }

        public void Run()
        {
            if(_prompts.Any())
            {
                base.DisplayWelcomeMessage();

                DisplayPrompt();

                DateTime current = DateTime.Now;
                DateTime futureDate = current.AddSeconds(_seconds);
                _answers = new List<string>();

                while (current < futureDate)
                {
                    _answers.Add(Console.ReadLine());
                    current = DateTime.Now;
                }

                Console.WriteLine($"You listed {_answers.Count} items!");
            }
            else
            {
                Console.WriteLine();
                Console.Write("No have more prompts to answer, good job!");
                base.showAnimation(5);
            }

            base.DisplayEndMessage();

        }

        private string GetRandomPrompt()
        {
            Random random = new Random();
            var index = random.Next(_prompts.Count);
            var prompt = _prompts[index];
            _prompts.Remove(prompt);
            return prompt;
        }

        private void DisplayPrompt()
        {
            Console.WriteLine("\nList as many responses you can to the following prompt:");

            Console.WriteLine($"--- {GetRandomPrompt()} ---");
            Console.Write("You can begin in:");
            base.ShowCountDown(5);
            Console.WriteLine();
        }
    }
}

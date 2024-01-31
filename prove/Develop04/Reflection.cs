using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop04
{
    public class Reflection : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
        public Reflection(string title, string description) 
            : base(title, description)
        {

        }

        public void Run()
        {
            base.DisplayWelcomeMessage();

            if(_prompts.Any())
            {
                AddQuestions();
                DisplayPrompts();

                DateTime current = DateTime.Now;
                DateTime futureDate = current.AddSeconds(_seconds);

                while(current < futureDate)
                {

                    Console.Write(GetRandomQuestions());
                    base.showAnimation(1);
                    Console.WriteLine();
                    current = DateTime.Now;

                    if(!_questions.Any())
                    {
                        Console.Write("\nYou ponder all questions, good job!");
                        base.showAnimation(5);
                        break;
                    }
                }
            }
            else
            {
                Console.Write("\nNo have more prompt to ponder, good Job!");
                base.showAnimation(5);
            }

            base.DisplayEndMessage();

        }

        private string GetRandomPrompt()
        {
            Random rand = new Random();
            var index = rand.Next(_prompts.Count);
            var prompt = _prompts[index];
            _prompts.Remove(prompt);
            return prompt;
        }

        private string GetRandomQuestions()
        {
            var rand = new Random();
            var index = rand.Next(_questions.Count);
            var question = _questions[index];
            _questions.Remove(question);
            return question;
        }

        private void DisplayPrompts()
        {
            Console.WriteLine("Consider the following prompt:\n");

            Console.WriteLine($"--- {GetRandomPrompt()} --- \n");

            Console.WriteLine("When you have something in mind press enter to continue.");
            Console.ReadLine();

            Console.WriteLine("now ponder on each of the following questions as they related to this experience.");
            Console.Write("You may begin in:");
            base.ShowCountDown(5);

            Console.Clear();
        }

        private void AddQuestions()
        {
            _questions = new List<string>
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };
        }

    }
}

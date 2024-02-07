using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Develop05
{
    public class SimpleGoal : Goal
    {
        private bool _isCompleted;
        public SimpleGoal(string title, string description, double score) : base(title, description, score)
        {
        }
        public SimpleGoal(string title, string description, double score, DateTime date, bool isCompleted): base(title, description, score, date)
        {
            _isCompleted = isCompleted;
        }

        public override void DisplayGoal()
        {
           if(_isCompleted)
            {
                Console.WriteLine($"[X] Simple Goal: {base._title} ({base._description})");
            }
           else
            {
                Console.WriteLine($"[] Simple Goal: {base._title} ({base._description})");
            }
        }

        public override double SetDone()
        {
            _isCompleted = true;
            Console.WriteLine("\nYou did it! \n");
            return base.GetScore();
        }
        public override string WriteInFile()
        {
            return $"{this.GetType().Name},{_title},{_description},{base.GetScore()},{_date},{_isCompleted}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Develop05
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string title, string description, double score) : base(title, description, score)
        {
            
        }
        public EternalGoal(string title, string description, double score, DateTime date): base(title, description, score, date)
        {

        }
        public override void DisplayGoal()
        {
            Console.WriteLine($"[] Eternal Goal: {base._title} ({base._description}) - Started: {base._date.ToString("MM/dd/yyyy")}");
        }

        public override double SetDone()
        {
            return base.GetScore();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop05
{
    public class ChecklistGoal : Goal
    {
        private int _times;
        private int _timesCompleted;
        private double _bonus;
        private bool _isCompleted;
        public ChecklistGoal(string title, string description, double score, int times, double bonus) : base(title, description, score)
        {
            _times = times;
            _bonus = bonus;
        }

        public ChecklistGoal(string title, string description, double score, DateTime date, bool isComplete, double bonus, int times, int timesCompleted): base(title, description, score)
        {
            _times = times;
            _timesCompleted = timesCompleted;
            _bonus = bonus;
            _isCompleted = isComplete;
        }

        public override double SetDone()
        {
            if(_isCompleted)
            {
                return 0;
            }

            _timesCompleted++;

            if(_timesCompleted == _times)
            {
                _isCompleted = true;
                Console.WriteLine($"\n----- Congrats, you gain the bonus of {_bonus} points! -----\n");
                return _bonus + base.GetScore();
            }
            return base.GetScore();
        }

        public override void DisplayGoal()
        {
            if(_isCompleted)
            {
                Console.WriteLine($"[x] Checklist Goal: {base._title} ({base._description}) - {_timesCompleted}/{_times}");
            }
            else
            {
                Console.WriteLine($"[] Checklist Goal: {base._title} ({base._description}) - {_timesCompleted}/{_times}");
            }
        }
        public override string WriteInFile()
        {
            return $"{this.GetType().Name},{_title},{_description},{base.GetScore()},{_date},{_isCompleted},{_bonus},{_times},{_timesCompleted}";
        }
    }
}

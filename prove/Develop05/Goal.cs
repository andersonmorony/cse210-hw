using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop05
{
    public abstract class Goal
    {
        private double _score;
        protected string _title;
        protected string _description;
        protected DateTime _date;

        public Goal() { }
        public Goal(string title, string description, double score)
        {
            _title = title;
            _description = description;
            _score = score;
            _date = DateTime.Now;
        }
        public Goal(string title, string description, double score, DateTime currentDate)
        {
            _title = title;
            _description = description;
            _score = score;
            _date = currentDate;
        }

        public double GetScore()
        {
            return _score;
        }
        public virtual void DisplayGoal()
        {
            string message = $"[] {_title} - {_description}";
            Console.WriteLine(message);
        }
        public virtual string WriteInFile()
        {
            return $"{this.GetType().Name},{_title},{_description},{_score},{_date}";
        }
        
     
        public abstract double SetDone();

    }
}

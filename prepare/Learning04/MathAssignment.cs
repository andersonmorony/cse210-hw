using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning04
{
    public class MathAssignment : Assignment
    {
        private string _textboxSection;
        private string _problem;

        public MathAssignment(string name, string topic, string textbox, string problem) : base(name, topic)
        {
            _textboxSection = textbox;
            _problem = problem;
        }
        public string GetHomeworkList()
        {
            return $"Section {_textboxSection} Problem {_problem}";
        }
    }
}

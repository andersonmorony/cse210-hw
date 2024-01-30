using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning04
{
    public class Assignment
    {
        protected string _studantName;
        private string _topic;

        public Assignment(string name, string topic)
        {
            _studantName = name;
            _topic = topic;
        }

        public string GetSummary()
        {
            return $"{_studantName} - {_topic}";
        }
    }
}

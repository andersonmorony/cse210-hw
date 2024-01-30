using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning04
{
    public class WritingAssignment : Assignment
    {
        private string _title;

        public WritingAssignment(string name, string topic, string title): base(name, topic)
        {
            _title = title;
        }

        public string GetWritingInformation()
        {
            return $"{_title} by {_studantName}";
        }
    }
}

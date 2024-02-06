using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning05
{
    public class Rectangle : Shape
    {
        private double _length;
        private double _width;

        public Rectangle(string color, double length, double width) : base(color)
        {
            _length = length;
            _width = width;
        }

        public override double GetArea()
        {
            return _width * _length;
        }
    }
}

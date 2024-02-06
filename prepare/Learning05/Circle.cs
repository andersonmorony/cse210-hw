using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning05
{
    public class Circle : Shape
    {
        private double _radius;

        public Circle(string color, double radius) : base(color)
        {
            _radius = radius;
        }

        public override double GetArea()
        {
            return (_radius * _radius) * Math.PI;
        }
    }
}

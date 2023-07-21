using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class Circle
    {
        public uint Radius { get; private set; }
        public uint Diameter { get; private set; }

        public Circle(uint radius)
        {
            this.Radius = radius;
            this.Diameter = radius * 2;
        }

        public double GetCircumference()
        {
            double result = Math.Round(Radius * 2 * Math.PI, 3);
            return result;
        }

        public double GetArea()
        {
            double result = Math.Round(Radius * Radius * Math.PI, 3);

            return result;
        }
    }
}

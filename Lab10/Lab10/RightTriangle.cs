using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class RightTriangle
    {
        public uint Width { get; private set; }
        public uint Height { get; private set; }

        public RightTriangle(uint width, uint height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double GetPerimeter()
        {
            double thirside = Math.Sqrt(Width * Width + Height * Height);
            double result = Math.Round(Width + Height + thirside, 3);

            return result;
        }

        public double GetArea()
        {
            return (double)(Width * Height) / 2;
        }
    }
}

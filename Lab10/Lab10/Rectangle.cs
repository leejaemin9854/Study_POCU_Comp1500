using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class Rectangle
    {
        public uint Width { get; private set; }
        public uint Height { get; private set; }

        public Rectangle(uint width, uint height)
        {
            this.Width = width;
            this.Height = height;
        }


        public uint GetPerimeter()
        {
            return (Width + Height) * 2;
        }

        public uint GetArea()
        {
            return Width * Height;
        }
    }
}

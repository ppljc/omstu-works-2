using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Figure
    {
        private double _square;

        public Figure(double radius) // круг
        {
            this._square = Math.PI * radius * radius;
        }

        public Figure(double basis, double height, bool isTriangle) // прямоугольник или треугольник
        {
            if (isTriangle)
            { 
                this._square = 0.5 * basis * height;
            } else
            {
                this._square = basis * height;
            }
        }

        public double Square
        {
            get
            {
                return _square;
            }
        }
    }
}

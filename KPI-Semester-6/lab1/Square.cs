using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Square
    {
        private double Side { get; set; }

        public double GetPerimeter()
        {
            return 4 * Side;
        }

        public double GetArea()
        {
            return Math.Pow(Side, 2); 
        }
    }
}
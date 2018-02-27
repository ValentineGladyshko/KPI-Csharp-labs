using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Complex
    {
        private double x;
        private double y;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public Complex()
        {
            x = 0;
            y = 0;
        }

        public Complex(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            string result1 = X.ToString("F3");
            string result2 = Y.ToString("F3");

            
            if(X == Convert.ToDouble(result1))
                result1 = X + "";
            if (Y == Convert.ToDouble(result2))
                result2 = Y + "";

            return result1 + " + " + result2 + "i";
        }
    }
}

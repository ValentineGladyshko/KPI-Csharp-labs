using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    interface IOperationStrategy
    {
        Complex Execute(Complex a, Complex b);
    }

    class OperationAdd : IOperationStrategy
    {
        public Complex Execute(Complex a, Complex b)
        {
            return new Complex(a.X + b.X, a.Y + b.Y);
        }
    }

    class OperationSubtract : IOperationStrategy
    {
        public Complex Execute(Complex a, Complex b)
        {
            return new Complex(a.X - b.X, a.Y - b.Y);
        }
    }

    class OperationMultiply : IOperationStrategy
    {
        public Complex Execute(Complex a, Complex b)
        {
            return new Complex((a.X * b.X) - (a.Y * b.Y), (a.X * b.Y) + (a.Y * b.X));
        }
    }

    class OperationDivide : IOperationStrategy
    {
        public Complex Execute(Complex a, Complex b)
        {
            return new Complex(((a.X * b.X) + (a.Y * b.Y)) / (Math.Pow(b.X, 2) + Math.Pow(b.Y, 2)),
                ((a.X * b.Y) - (a.Y * b.X)) / (Math.Pow(b.X, 2) + Math.Pow(b.Y, 2)));
        }
    }
}

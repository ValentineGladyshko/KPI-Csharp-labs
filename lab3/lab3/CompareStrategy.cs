using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    interface ICompareStrategy
    {
        bool Execute(Complex a, Complex b);
    }

    class CompareLess : ICompareStrategy
    {
        public bool Execute(Complex a, Complex b)
        {
            return Math.Sqrt(Math.Pow(a.X, 2) + Math.Pow(a.Y, 2)) <
                Math.Sqrt(Math.Pow(b.X, 2) + Math.Pow(b.Y, 2));
        }
    }

    class CompareMore : ICompareStrategy
    {
        public bool Execute(Complex a, Complex b)
        {
            return Math.Sqrt(Math.Pow(a.X, 2) + Math.Pow(a.Y, 2)) >
                Math.Sqrt(Math.Pow(b.X, 2) + Math.Pow(b.Y, 2));
        }
    }

    class CompareEqual : ICompareStrategy
    {
        public bool Execute(Complex a, Complex b)
        {
            return Math.Sqrt(Math.Pow(a.X, 2) + Math.Pow(a.Y, 2)) ==
                Math.Sqrt(Math.Pow(b.X, 2) + Math.Pow(b.Y, 2));
        }
    }

    class CompareLessEqual : ICompareStrategy
    {
        public bool Execute(Complex a, Complex b)
        {
            return Math.Sqrt(Math.Pow(a.X, 2) + Math.Pow(a.Y, 2)) <=
                Math.Sqrt(Math.Pow(b.X, 2) + Math.Pow(b.Y, 2));
        }
    }

    class CompareMoreEqual : ICompareStrategy
    {
        public bool Execute(Complex a, Complex b)
        {
            return Math.Sqrt(Math.Pow(a.X, 2) + Math.Pow(a.Y, 2)) >=
                Math.Sqrt(Math.Pow(b.X, 2) + Math.Pow(b.Y, 2));
        }
    }
}

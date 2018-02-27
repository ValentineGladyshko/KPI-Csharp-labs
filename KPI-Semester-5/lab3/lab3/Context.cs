using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class ContextOperation
    {
        private IOperationStrategy strategy;

        public ContextOperation() {}
        public ContextOperation(IOperationStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy(IOperationStrategy strategy)
        {
            this.strategy = strategy;
        }

        public Complex Execute(Complex a, Complex b)
        {
            return strategy.Execute(a, b);
        }
    }

    class ContextCompare
    {
        private ICompareStrategy strategy;

        public ContextCompare() { }
        public ContextCompare(ICompareStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy(ICompareStrategy strategy)
        {
            this.strategy = strategy;
        }

        public bool Execute(Complex a, Complex b)
        {
            return strategy.Execute(a, b);
        }
    }
}

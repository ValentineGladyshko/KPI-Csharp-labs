using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Context
    {
        private IOperationStrategy strategy;

        public Context() {}
        public Context(IOperationStrategy strategy)
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
}

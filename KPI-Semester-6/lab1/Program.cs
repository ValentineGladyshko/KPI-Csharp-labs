using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection; 

[assembly: AssemblyVersion("1.0.0.0")]

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(6);
            Square square = new Square(6);
            Console.WriteLine("Circle area: {0}", circle.GetArea());
            Console.WriteLine("Square area: {0}", square.GetArea());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
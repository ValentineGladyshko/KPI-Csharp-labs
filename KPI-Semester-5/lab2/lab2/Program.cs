using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            DigitalClockDecorator clock = new DigitalClockDecorator(new Clock(12, 6, 6));
            clock.ShowTime();
            Console.WriteLine(clock.ToString());

            ClockWithArrowsDecorator clock1 = new ClockWithArrowsDecorator(new Clock(12, 6, 6));
            clock1.ShowTime();
            clock1.ShowArrowTurns();
            Console.WriteLine(clock1.ToString());

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

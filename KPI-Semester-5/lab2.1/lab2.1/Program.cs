using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter turn of Hour Arrow: ");
            double HourTurn = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter turn of Minute Arrow: ");
            double MinuteTurn = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter turn of Second Arrow: ");
            double SecondTurn = Convert.ToDouble(Console.ReadLine());

            ClockWithArrows ClockArrow = new ClockWithArrows(HourTurn, MinuteTurn, SecondTurn);
            Console.WriteLine(ClockArrow.ToString());

            Clock Clock = new Clock();
            Clock.SetTime(new ClockWithArrowsAdapter(ClockArrow));
            Clock.ShowTime();

            Console.Write("\nEnter Hours: ");
            int Hours = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Minutes: ");
            int Minutes = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Seconds: ");
            int Seconds = Convert.ToInt32(Console.ReadLine());

            //ClockArrow.SetTime(Hours, Minutes, Seconds); //показує трасформацію часу в повороти стрілок
            //Console.WriteLine(ClockArrow.ToString());
            Console.WriteLine();

            Clock.SetTime(new DigitalClock(Hours, Minutes, Seconds));
            Clock.ShowTime();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
